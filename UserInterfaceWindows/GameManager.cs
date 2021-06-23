using GameLogic;
using static GameLogic.GameLogic.eGameState;

namespace UserInterfaceWindows

{
    internal class GameManager
    {
        private readonly int r_BoardSize;
        private readonly string r_Player1Name;
        private readonly string r_Player2Name;
        private readonly GameLogic.GameLogic r_Game;
        private GameBoardForm m_GameBoardForm;
        private readonly bool r_Player2IsComputer;
        private readonly (int, int) m_QuitPoint = (-1, -1);

        internal GameManager(StartGameForm i_SettingsForm)
        {
            r_BoardSize = (int)i_SettingsForm.NumberOfColsAndRows;
            r_Player2IsComputer = !i_SettingsForm.IsComputerBox;
            r_Game = new GameLogic.GameLogic(r_BoardSize, false, r_Player2IsComputer);
            r_Player1Name = i_SettingsForm.Player1Name;
            r_Player2Name = i_SettingsForm.Player2Name;
            r_Game.GameOver += this.showGameOverStatus;
            r_Game.ReportChangePlayerDelegates += R_Game_ReportChangePlayerDelegates;
            this.initGameBoardForm();
        }

        private void R_Game_ReportChangePlayerDelegates(Player i_CurrentPlayer)
        {
            bool isCurrentPlayerIsPlayer1 = i_CurrentPlayer.Equals(r_Game.Player1) ;
            m_GameBoardForm.ChangeCurrentPlayer(isCurrentPlayerIsPlayer1);
        }

        public (int, int) QuitPoint
        {
            get { return m_QuitPoint; }
        }

        public string Player1Name
        {
            get { return r_Player1Name; }
        }
        public string Player2Name
        {
            get { return r_Player2Name; }
        }
        public bool Player2isComputer
        {
            get { return r_Player2IsComputer; }
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
            GameLogic.GameLogic.eGameState currentState = e.GameState;
            ePlayersMark signOfTheWinner = e.WinnerPlayer.Sign;
            string winnerName = signOfTheWinner == ePlayersMark.Player1 ? r_Player1Name : r_Player2Name;
            string loserName= signOfTheWinner == ePlayersMark.Player1 ? r_Player2Name : r_Player1Name;
            switch (currentState)
            {
                case Win:
                    m_GameBoardForm.ShowWinMessage(signOfTheWinner, winnerName);

                    break;
                case Tie:
                    m_GameBoardForm.ShowTieMessage();

                    break;
                case Quit:
                    m_GameBoardForm.ShowQuitMessage(signOfTheWinner, winnerName, loserName);

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
            return GameLogic.GameLogic.MaxBoardSize;
        }

        public static int GetValidMinSizeOfBoard()
        {
            return GameLogic.GameLogic.MinBoardSize;
        }

        internal void MakeNewGame()
        {
            this.r_Game.PreparingForAnotherGame();
        }
    }
}