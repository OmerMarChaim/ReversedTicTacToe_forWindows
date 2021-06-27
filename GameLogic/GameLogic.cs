using System;
using System.Linq;

namespace GameLogic
{
    /// <summary>
    /// delegate to report if gameOver happen
    /// </summary>
    public delegate void GameOverEventHandler(object sender, GameOverEventArgs e);

    public class GameLogic
    { /// <summary>
        /// delegate to report who play the next move
        /// </summary>
        public event Action<Player> ReportChangePlayerDelegates;

        public event GameOverEventHandler GameOver;
        private Board m_GameBoard;
        private Player m_Player1;
        private Player m_Player2;
        private eGameState m_CurrentGameState;
        private Player m_WinnerPlayer;
        private const int k_MinBoardSize = 3;
        private const int k_MaxBoardSize = 9;
        private Random m_Random;
        private Player m_CurrentPlayer;
        private GameOverEventArgs m_GameOverArgs;

        public enum eGameState
        {
            Playing,
            Win,
            Tie,
            Quit
        }

        public GameLogic(int i_BoardSize, bool i_Player1IsComputer, bool i_Player2IsComputer)
        {
            m_GameBoard = new Board(i_BoardSize);
            m_Player1 = new Player(ePlayersMark.Player1, i_Player1IsComputer);
            m_Player2 = new Player(ePlayersMark.Player2, i_Player2IsComputer);
            m_CurrentGameState = eGameState.Playing;
            m_CurrentPlayer = m_Player1;
        }

        public eGameState CurrentGameState
        {
            get { return this.m_CurrentGameState; }
            private set { this.m_CurrentGameState = value; }
        }
        public Player WinnerPlayer
        {
            get { return m_WinnerPlayer; }
            set { m_WinnerPlayer = value; }
        }
        public Player Player1
        {
            get { return m_Player1; }
            set { m_Player1 = value; }
        }

        public Player Player2
        {
            get { return m_Player2; }
            set { m_Player2 = value; }
        }

        public Board GameBoard
        {
            get { return m_GameBoard; }
        }
        public static int MaxBoardSize
        {
            get { return k_MaxBoardSize; }
        }
        public static int MinBoardSize
        {
            get { return k_MinBoardSize; }
        }

        public void OneRoundInGame((int row, int column) i_Point)
        {
            for(int i = 0; i < 2; i++)
            {
                if(m_CurrentPlayer.IsComputer)
                {
                    i_Point = getRandomPointForComputer();
                }

                this.GameBoard.SetValueOnBoard(i_Point.row, i_Point.column, m_CurrentPlayer.Sign);

                updateStateOfGame(i_Point, m_CurrentPlayer);
                //Report to Form
                // i_GameUi.CleanAndShowBeforeNewTurn();
                m_CurrentPlayer = m_CurrentPlayer.Equals(m_Player1) ? m_Player2 : m_Player1;
                notifyCurrentPlayer();
            
                if (m_CurrentGameState != eGameState.Playing )
                {
                    notifyGameOverListener(m_CurrentGameState, m_WinnerPlayer);
                    break;

                }
                else if(!m_CurrentPlayer.IsComputer)
                {
                    break;
                }
            }
        }

        protected virtual void notifyCurrentPlayer()
        {
            ReportChangePlayerDelegates?.Invoke(m_CurrentPlayer);
        }

        protected virtual void notifyGameOverListener(eGameState i_CurrentGameState, Player i_WinnerPlayer)
        {
            if(m_GameOverArgs != null)
            {
                m_GameOverArgs.WinnerPlayer = i_WinnerPlayer;
                m_GameOverArgs.GameState = i_CurrentGameState;
            }
            else
            {
               m_GameOverArgs = new GameOverEventArgs(i_CurrentGameState, i_WinnerPlayer);

            }

            GameOver?.Invoke(this, m_GameOverArgs);
        }

        private void updateStateOfGame((int row, int column) i_LastPointEntered, Player i_Player)
        {
            if(isQuitPoint(i_LastPointEntered))
            {
                updateWinnerStatistics(i_Player);
                m_CurrentGameState = eGameState.Quit;
            }
            else if(thereIsWin(i_LastPointEntered, i_Player.Sign))
            {
                updateWinnerStatistics(i_Player);
                m_CurrentGameState = eGameState.Win;
            }
            else if(thereIsTie())
            {
                m_CurrentGameState = eGameState.Tie;
            }

            else
            {
                m_CurrentGameState = eGameState.Playing;
            }
        }

        private void updateWinnerStatistics(Player i_LoserPlayer)
        {
            if(i_LoserPlayer.Sign == m_Player1.Sign)
            {
                m_Player2.NumberOfWins++;
                m_WinnerPlayer = m_Player2;
            }
            else
            {
                m_Player1.NumberOfWins++;
                m_WinnerPlayer = m_Player1;
            }
        }

        private (int, int) getRandomPointForComputer()
        {
            if(m_Random == null)
            {
                m_Random = new Random();
            }

            int randomIndex = m_Random.Next(0, this.GameBoard.FreeSpotsInBoard.Count);
            (int row, int column) testedPoint = this.GameBoard.FreeSpotsInBoard.ElementAt(randomIndex);

            return testedPoint;
        }

        private void createNewBoardForAnotherGame()
        {
            int boardSize = this.GameBoard.Size;
            this.m_CurrentPlayer = m_Player1;
            this.m_GameBoard = new Board(boardSize);
        }

        private bool thereIsWin((int row, int column) i_Point, ePlayersMark i_PlayerMarkSign)
        {
            int numberOfSignsToWin = this.GameBoard.Size;
            bool isWinInRowAndCol = checkWinInRowAndColumn(i_Point, i_PlayerMarkSign, numberOfSignsToWin);
            bool isWinInDiagonal = checkWinInMainDiagonal(i_PlayerMarkSign, numberOfSignsToWin);
            bool isWinInAntiDiagonal = checkWinInAntiDiagonal(i_PlayerMarkSign, numberOfSignsToWin);

            return isWinInDiagonal || isWinInAntiDiagonal || isWinInRowAndCol;
        }

        private bool checkWinInAntiDiagonal(ePlayersMark i_PlayerMarkSign, int i_NumberOfSignsToWin)
        {
            int counter = 0;

            // In square matrix - the anti diagonal the sum of row and column equal to the matrix size+1

            for(int i = 0; i < this.GameBoard.Size; i++)
            {
                if(m_GameBoard.GameBoard[i, m_GameBoard.Size - i - 1] == i_PlayerMarkSign)
                {
                    counter++;
                }
                else
                {
                    break;
                }
            }

            return counter == i_NumberOfSignsToWin;
        }

        private bool checkWinInMainDiagonal(ePlayersMark i_PlayerMark, int i_NumberOfSignsToWin)
        {
            int counter = 0;

            for(int i = 0; i < this.GameBoard.Size; i++)
            {
                if(this.GameBoard.GameBoard[i, i] == i_PlayerMark)
                {
                    counter++;
                }
                else
                {
                    break;
                }
            }

            return counter == i_NumberOfSignsToWin;
        }

        private bool checkWinInRowAndColumn(
            (int row, int column) i_Point,
            ePlayersMark i_PlayerMark,
            int i_NumberOfSignsToWin)
        {
            int counterRow = 0;
            int counterColumn = 0;

            for(int i = 0; i < this.GameBoard.Size; i++)
            {
                if(m_GameBoard.GameBoard[i_Point.row, i] == i_PlayerMark)
                {
                    counterRow++;
                }

                if(m_GameBoard.GameBoard[i, i_Point.column] == i_PlayerMark)
                {
                    counterColumn++;
                }
            }

            return (counterRow == i_NumberOfSignsToWin) || (counterColumn == i_NumberOfSignsToWin);
        }

        /* Tie happened when the board is full and a win didn't cause */
        private bool thereIsTie()
        {
            return this.GameBoard.IsFull();
        }

        /* we NOTE (-1,-1) as a sign of Q is appeared from the UI, (-1,-1) is not valid in ANY board game */
        private static bool isQuitPoint((int row, int column) i_Spot)
        {
            bool isQuitPoint = (i_Spot.row == -1) && (i_Spot.column == -1);

            return isQuitPoint;
        }

        internal bool IsEmptySpot(int i_Row, int i_Column)
        {
            bool isEmptySpot = this.GameBoard.IsEmptySpot(i_Row, i_Column);

            return isEmptySpot;
        }

        public void PreparingForAnotherGame()
        {
            CurrentGameState = eGameState.Playing;
            createNewBoardForAnotherGame();
        }
    }
}