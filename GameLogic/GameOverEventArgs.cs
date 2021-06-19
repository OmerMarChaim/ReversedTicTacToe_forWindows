using System;

namespace GameLogic
{
    public class GameOverEventArgs :EventArgs
    {
        private GameLogic.eGameState m_GameState;
        private Player m_WinnerPlayer;
        public GameOverEventArgs( GameLogic.eGameState i_GameState, Player i_WinnerPlayer)
        {
            m_GameState = i_GameState;
            m_WinnerPlayer = i_WinnerPlayer;
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
