using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReverseTicTacToeGame;
using UserInterfaceWindows;
using System.Windows.Forms;
using System.Drawing;

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

        internal GameManeger(StartGameForm i_SettingsForm)
        {
            m_SettingsForm = i_SettingsForm;
            m_BoardSize  = (int)m_SettingsForm.NumberOfColsAndRows;
            m_Player2IsComputer = m_SettingsForm.IsComputerBox;
            m_Game = new GameLogic(m_BoardSize, false, m_Player2IsComputer);
            m_Player1Name = m_SettingsForm.Player1Name;
            m_Player2Name = m_SettingsForm.Player2Name;
            this.startGame();
        }

        private void initGameForm()
        {
            
        }

        private void startGame()
        {
            GameBoardForm gameBoardForm = new GameBoardForm(m_BoardSize);
            gameBoardForm.ShowDialog();

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
        /// <summary>
        /// chaeck by ui ig User Want another game
        /// </summary>
        /// <returns></returns>
        private bool isUserWantAnotherGame()
        {
            throw new NotImplementedException();
        }

        private void updateTheUserInterfaceAccordingTheState()
        {
            throw new NotImplementedException();
        }

        private static void tieMessage() // Checked
        {
            // Console.WriteLine("No one is going to win this game, there's a tie! This game is over without winner.");
        }

        private static void winMessage(ePlayersMark i_SignOfTheWinner)
        {
            // Console.WriteLine($"Well done! The winner in this round is : {i_SignOfTheWinner}");
        }

        private static void quitMessage(ePlayersMark i_SignOfTheWinner)
        {
            // Console.WriteLine($"You Quit from the Game! The winner in this round is : {i_SignOfTheWinner}");
        }
    }
}