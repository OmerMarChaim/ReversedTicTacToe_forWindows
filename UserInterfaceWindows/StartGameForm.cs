using System;
using System.Collections.Generic;
using System.Drawing;
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
            setButtonStart();
            setPlayersTextBox();
            setLabels();
            setNumericUpDown();

            //action when start button press -> need to init game
         
        }

        private void setNumericUpDown()
        {
            throw new NotImplementedException();
        }

        private void setLabels()
        {
            m_Players = new Label();

            m_Players.Text = "Players:";
            this.Controls.Add(m_Players);
            //todo
            ///add another Label
        }

        private void setPlayersTextBox()
        {
            m_Player1Name = new TextBox();
            m_Player1Name.Text = "Player 1:";
            m_Player1Name.Location = new Point(10, 20);
            m_IsComputerBox = new CheckBox();
            m_IsComputerBox.Checked = false;
            m_IsComputerBox.Text = "Player2";
            m_Player2Name = new TextBox();
            m_Player2Name.Text = "Player 2:";
            m_Player2Name.Location = new Point(30, 60);
            m_IsComputerBox.Location = new Point(10, 40);
            this.Controls.Add(m_Player1Name);
            this.Controls.Add(m_IsComputerBox);
            this.Controls.Add(m_Player2Name);


        }

        private void setButtonStart()
        {
        //    throw new NotImplementedException();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // StartGameForm
            // 
            this.ClientSize = new System.Drawing.Size(412, 341);
            this.Name = "StartGameForm";
            this.ResumeLayout(false);

        }
    }
   

    
}
