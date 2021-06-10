using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterfaceWindows
{
    class StartGameForm : Form
    {
        private Label m_Players;
        private Button m_ButtonStart;
        private TextBox m_Player1Name;
        private TextBox m_Player2Name;
        private CheckBox m_IsComputerBox;
        private Label m_BoardSize;
        private NumericUpDown m_Rows;
        private NumericUpDown m_Cols;
        public StartGameForm()
        {

            this.Text = "Game Settings";
            m_Players = new Label();
          
            m_Players.Text = "Players:";
            m_Player1Name = new TextBox();
            m_Player1Name.Text = "Player 1:";
            m_IsComputerBox = new CheckBox();
            m_IsComputerBox.Checked = false;
            this.Controls.Add(m_Players);
            this.Controls.Add(m_Player1Name);
        }


   







    }
   

    
}
