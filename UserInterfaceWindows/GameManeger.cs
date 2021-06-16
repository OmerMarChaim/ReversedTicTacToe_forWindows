using System;
using System.Windows.Forms;
using ReverseTicTacToeGame;
using static ReverseTicTacToeGame.GameLogic.eGameState;

namespace UserInterfaceWindows

{
    internal class GameManeger
    {
        private const char k_Circle = 'O';
        private const char k_Cross = 'X';
        private const char k_Empty = ' ';
        private const char k_Player1Sign = k_Cross;
        private const char k_Player2Sign = k_Circle;
        private int m_BoardSize;
        string m_Player1Name;
        string m_Player2Name;
        private const bool k_Player1IsComputer = false;
        private bool m_Player2IsComputer;
        private GameLogic m_Game;
        private StartGameForm m_SettingsForm;
        private GameBoardForm m_gameBoardForm;

        internal GameManeger(StartGameForm i_SettingsForm)
        {
            m_SettingsForm = i_SettingsForm;
            m_BoardSize  = (int)m_SettingsForm.NumberOfColsAndRows;
            m_Player2IsComputer = !m_SettingsForm.IsComputerBox;
            m_Game = new GameLogic(m_BoardSize, false, m_Player2IsComputer);
            m_Player1Name = m_SettingsForm.Player1Name;
            m_Player2Name = m_SettingsForm.Player2Name;
            m_Game.m_1ReportNewPointDelegates += this.reportNewPoint;
            this.InitGameBoardForm();
        }

        private void reportNewPoint((int row, int column) i_Arg1, ePlayersMark i_Arg2)
        {
            m_gameBoardForm.setPoint(i_Arg1, i_Arg2);

        }

     
        private void InitGameBoardForm()
        {
            m_gameBoardForm = new GameBoardForm(m_BoardSize ,this);
           m_gameBoardForm.ShowDialog();

        }

        // private void startGame() // Checked
        // {
        //     bool wantAnotherGameFlag = true;
        //
        //     while (wantAnotherGameFlag)
        //     {
        //         while (this.m_Game.CurrentGameState == GameLogic.eGameState.Playing)
        //         {
        //          //  this.m_Game.OneRoundInGame();
        //         }
        //
        //         updateTheUserInterfaceAccordingTheState();
        //         wantAnotherGameFlag = isUserWantAnotherGame();
        //     }
        // }
        // /// <summary>
        // /// chaeck by ui ig User Want another game
        // /// </summary>
        // /// <returns></returns>
        private bool isUserWantAnotherGame()
        {
           return m_gameBoardForm.isWantAnotherGame();
        }

        private void updateTheUserInterfaceAccordingTheState()
        {
            GameLogic.eGameState currentState = this.m_Game.CurrentGameState;
            ePlayersMark signOfTheWinner = this.m_Game.WinnerPlayer.Sign;
            String winnerName = signOfTheWinner == ePlayersMark.Player1 ? m_Player1Name : m_Player2Name;


            if (currentState.Equals(Win))
            {
                winMessage(signOfTheWinner,winnerName);
            }
            else if (currentState == Tie)
            {
                tieMessage();
            }
            else if (currentState == Quit)
            {
                quitMessage(signOfTheWinner, winnerName);
            }

            isUserWantAnotherGame();

        }

        private void tieMessage() // Checked
        {
            m_gameBoardForm.showTieMessage();

        }

        private void winMessage(ePlayersMark i_SignOfTheWinner, string i_WinnerName)
        {
            m_gameBoardForm.showWinMessage(i_SignOfTheWinner, i_WinnerName);

        }

        private void quitMessage(ePlayersMark i_SignOfTheWinner, string i_WinnerName)
        {
            m_gameBoardForm.showQuitMessage(i_SignOfTheWinner, i_WinnerName);

        }

        public void ValidPointFromUser((int row, int col) i_Point)
        {
            m_Game.OneRoundInGame(i_Point);
            if(this.m_Game.CurrentGameState != GameLogic.eGameState.Playing)
            {
                updateTheUserInterfaceAccordingTheState();

            }
            
        }

        public static int getValidMaxSizeOfBoard()
        {
            return GameLogic.MaxBoardSize;
        }
        
        public static int getValidMinSizeOfBoard()
        {
            return GameLogic.MinBoardSize;
        }

        internal void makeNewGame()
        {
            this.m_Game.PreparingForAnotherGame();
        }
    }
}