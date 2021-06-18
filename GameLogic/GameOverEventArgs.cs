﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReverseTicTacToeGame;

namespace UserInterfaceWindows
{
    public class GameOverEventArgs :EventArgs
    {
        private GameLogic.eGameState m_GameState;
        private Player m_WinnerPlayer;
        public GameOverEventArgs(  GameLogic.eGameState i_GameState, Player i_WinnerPlayer)
        {
            m_GameState = i_GameState;
            m_WinnerPlayer = i_WinnerPlayer;
        }

        public GameOverEventArgs()
        {
            
        }

        public GameLogic.eGameState GameState
        {
            get { return m_GameState;}
            set { m_GameState = value; }
        }
        public Player WinnerPlayer
        {
            get { return m_WinnerPlayer; }
            set { m_WinnerPlayer = value; }

        }
    }
}
