using ReverseTicTacToeGame;
using static ReverseTicTacToeGame.GameLogic.eGameState;

namespace UserInterfaceWindows

{
    internal class GameManager
    {


        private readonly int r_BoardSize;
        private readonly string r_Player1Name;
        private readonly string r_Player2Name;
        private readonly GameLogic r_Game;
        private GameBoardForm m_GameBoardForm;

        internal GameManager(StartGameForm i_SettingsForm)
        {
            r_BoardSize = (int)i_SettingsForm.NumberOfColsAndRows;
            bool player2IsComputer = !i_SettingsForm.IsComputerBox;
            r_Game = new GameLogic(r_BoardSize, false, player2IsComputer);
            r_Player1Name = i_SettingsForm.Player1Name;
            r_Player2Name = i_SettingsForm.Player2Name;
            r_Game.GameOver += this.showGameOverStatus;
            this.initGameBoardForm();
        }

        public string Player1Name
        {
            get { return r_Player1Name; }
        }
        public string Player2Name
        {
            get { return r_Player2Name; }
        }

        private void reportNewPoint((int row, int column) i_Point, ePlayersMark i_PlayerSign)
        {
            m_GameBoardForm.SetPoint(i_Point, i_PlayerSign);
        }

        private void initGameBoardForm()
        {
            m_GameBoardForm = new GameBoardForm(r_BoardSize, this);
            r_Game.GameBoard.ReportNewPointDelegates += this.reportNewPoint;
            m_GameBoardForm.ShowDialog();
        }

        private void showGameOverStatus(object sender, GameOverEventArgs e)
        {
            GameLogic.eGameState currentState = e.GameState;
            ePlayersMark signOfTheWinner = e.WinnerPlayer.Sign;
            string winnerName = signOfTheWinner == ePlayersMark.Player1 ? r_Player1Name : r_Player2Name;

            switch (currentState)
            {
                case Win:
                 //   winMessage(signOfTheWinner, winnerName);
                    m_GameBoardForm.ShowWinMessage(signOfTheWinner, winnerName);

                    break;
                case Tie:
                    m_GameBoardForm.ShowTieMessage();

                    break;
                case Quit:
                 //   quitMessage(signOfTheWinner, winnerName);
                    m_GameBoardForm.ShowQuitMessage(signOfTheWinner, winnerName);

                    break;
              
            }
            if (isUserWantAnotherGame())
            {
                initGameBoardForm();
            }

        }

        private bool isUserWantAnotherGame()
        {
            return m_GameBoardForm.IsWantAnotherGame();
        }

        private void tieMessage() // Checked
        {
            m_GameBoardForm.ShowTieMessage();
        }

        private void winMessage(ePlayersMark i_SignOfTheWinner, string i_WinnerName)
        {
            m_GameBoardForm.ShowWinMessage(i_SignOfTheWinner, i_WinnerName);
        }

        private void quitMessage(ePlayersMark i_SignOfTheWinner, string i_WinnerName)
        {
            m_GameBoardForm.ShowQuitMessage(i_SignOfTheWinner, i_WinnerName);
        }

        public void ValidPointFromUser((int row, int col) i_Point)
        {
            r_Game.OneRoundInGame(i_Point);
        }

        public int GetNumberOfWinPlayer1()
        {
            return r_Game.Player1.NumberOfWins;
        }

        public int GetNumberOfWinPlayer2()
        {
            return r_Game.Player2.NumberOfWins;
        }

        public static int GetValidMaxSizeOfBoard()
        {
            return GameLogic.MaxBoardSize;
        }

        public static int GetValidMinSizeOfBoard()
        {
            return GameLogic.MinBoardSize;
        }

        internal void MakeNewGame()
        {
            this.r_Game.PreparingForAnotherGame();
        }
    }
}