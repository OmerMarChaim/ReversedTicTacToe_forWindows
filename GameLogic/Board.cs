using System;
using System.Collections.Generic;

namespace GameLogic
{
    public class Board
    {
        public event Action<(int row, int column), ePlayersMark> ReportNewPointDelegates;

        private readonly int r_Size;
        private ePlayersMark[,] m_Board;
        private readonly HashSet<(int, int)> r_FreeSpots;
        private const int k_QSign = -1;

        public Board(int i_Size)
        {
            r_Size = i_Size;
            m_Board = new ePlayersMark[i_Size, i_Size];
            r_FreeSpots = new HashSet<(int, int)>();
            for(int i = 0; i < i_Size; i++)
            {
                for(int j = 0; j < i_Size; j++)
                {
                    r_FreeSpots.Add((i, j));
                    m_Board[i, j] = ePlayersMark.Empty;
                }
            }
        }


    
    public int Size
        {
            get { return r_Size; }
        }
        public HashSet<(int, int)> FreeSpotsInBoard
        {
            get { return r_FreeSpots; }
        }
        public ePlayersMark[,] GameBoard
        {
            get { return m_Board; }
            set { m_Board = value; }
        }

        internal void SetValueOnBoard(int i_Row, int i_Column, ePlayersMark i_Symbol)
        {
            if(i_Row != k_QSign && i_Column != k_QSign)
            {
                m_Board[i_Row, i_Column] = i_Symbol;
                r_FreeSpots.Remove((i_Row, i_Column));
                notifyNewPointListener((i_Row, i_Column), i_Symbol);
            }
        }

        private void notifyNewPointListener((int, int) i_NewPoint, ePlayersMark i_Symbol)
        {
            ReportNewPointDelegates?.Invoke(i_NewPoint,i_Symbol);
        }


        internal bool IsEmptySpot(int i_Row, int i_Column)
        {
            bool isEmptySpot = m_Board[i_Row, i_Column] == ePlayersMark.Empty;

            return isEmptySpot;
        }

        internal bool IsFull()
        {
            return this.r_FreeSpots.Count == 0;
        }
    }
}