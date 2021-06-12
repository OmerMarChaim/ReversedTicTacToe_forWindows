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
        private GameLogic m_Game;
        private static StartGameForm m_SettingsForm;
        internal GameManeger(GameLogic i_Game)
        {
            m_Game = i_Game;
            m_SettingsForm = new StartGameForm();

            m_SettingsForm.ShowDialog();
        }

       
        public static void InitGame(string i_Player1Name, bool i_Player2IsComputer, string i_Player2Name, int i_Size) // Checked
        {
           
            int boardSize=i_Size;
           
            string player1Name =i_Player1Name;
            string player2Name = i_Player2Name;
            bool player1IsComputer = false; 
            bool player2IsComputer= i_Player2IsComputer; 

            GameLogic game = new GameLogic(boardSize, player1IsComputer, player2IsComputer);

            GameManeger gameUi = new GameManeger(game);

            m_SettingsForm.Hide();
            gameUi.startGame();

        }
        private void startGame() // Checked
        {
            bool wantAnotherGameFlag = true;

            while (wantAnotherGameFlag)
            {
                while (this.m_Game.CurrentGameState == GameLogic.eGameState.Playing)
                {
                 //  this.m_Game.OneRoundInGame();
                }

                updateTheUserInterfaceAccordingTheState();
                wantAnotherGameFlag = isUserWantAnotherGame();
            }
        }
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
        private static void TieMessage() // Checked
        {
           // Console.WriteLine("No one is going to win this game, there's a tie! This game is over without winner.");
        }

        private static void WinMessage(ePlayersMark i_SignOfTheWinner)
        {
           // Console.WriteLine($"Well done! The winner in this round is : {i_SignOfTheWinner}");
        }

        private static void QuitMessage(ePlayersMark i_SignOfTheWinner)
        {
           // Console.WriteLine($"You Quit from the Game! The winner in this round is : {i_SignOfTheWinner}");
        }










    }
}
