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
        private Label m_Player1label;
        private Label m_Player2label;
        private TextBox m_Player1Name;
        private TextBox m_Player2Name;
        private CheckBox m_IsComputerBox;
        private Label m_RowsLabel;
        private Label m_ColsLabel;
        private Label m_BoardSize;
        private NumericUpDown m_RowsNumericUpDown;
        private NumericUpDown m_ColsNumericUpDown;
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
            Size NumericSize= new Size(40, 25);
            m_ColsNumericUpDown = new NumericUpDown();
            m_ColsNumericUpDown.Maximum = 10;
            m_ColsNumericUpDown.Minimum = 4;
            m_ColsNumericUpDown.Value = 5;
            m_ColsNumericUpDown.Size = NumericSize;
            m_ColsNumericUpDown.Location = new Point(100, 130);
            m_ColsNumericUpDown.Increment = 1;
            m_ColsNumericUpDown.ValueChanged += m_ColsNumericUpDown_Click;
            this.Controls.Add(m_ColsNumericUpDown);

            m_RowsNumericUpDown = new NumericUpDown();
            m_RowsNumericUpDown.Location = new Point(100, 160);
            m_RowsNumericUpDown.Maximum = 10;
            m_RowsNumericUpDown.Minimum = 4;
            m_RowsNumericUpDown.Value = 5;
            m_RowsNumericUpDown.Size = NumericSize;
            m_RowsNumericUpDown.Increment = 1;
            m_RowsNumericUpDown.ValueChanged += m_RowsNumericUpDown_Click;

            this.Controls.Add(m_RowsNumericUpDown);
        }

        private void m_RowsNumericUpDown_Click(object i_Sender, EventArgs i_E)
        {
            m_ColsNumericUpDown.Value = m_RowsNumericUpDown.Value;
        }

        private void m_ColsNumericUpDown_Click(object i_Sender, EventArgs i_E)
        {
                m_RowsNumericUpDown.Value = m_ColsNumericUpDown.Value;
        }

        private void setLabels()
        {
            Size labelSize = new Size(50, 20);
            m_Players = new Label();
            m_Players.Text = "Players:";
            m_Players.Location = new Point(10,10);
            m_Players.Size = labelSize;
            this.Controls.Add(m_Players);


            m_Player1label = new Label();
            m_Player1label.Text = "Player 1:";
            m_Player1label.Location = new Point(20, 40);
            m_Player1label.Size = labelSize;
            this.Controls.Add(m_Player1label);


            m_Player2label = new Label();
            m_Player2label.Text = "Player 2:";
            m_Player2label.Size = labelSize;
            m_Player2label.Location = new Point(50, 70);
            this.Controls.Add(m_Player2label);

            m_BoardSize = new Label();
            m_BoardSize.Text = "Board Size:";
            m_BoardSize.Location = new Point(20, 100);
            this.Controls.Add(m_BoardSize);
            
            m_ColsLabel=new Label();
            m_ColsLabel.Text = "Cols:";
            m_ColsLabel.Size = labelSize;
            m_ColsLabel.Location = new Point(30, 130);
           this.Controls.Add(m_ColsLabel);

        
           // this.Controls.Add(m_ColsLabel);




            m_RowsLabel = new Label();
            m_RowsLabel.Text = "Rows:";
            m_RowsLabel.Size = labelSize;
            m_RowsLabel.Location = new Point(30, 160);
            this.Controls.Add(m_RowsLabel);
    


            //todo
            ///add another Label
        }

        private void setPlayersTextBox()
        {
            m_Player1Name = new TextBox();
            m_Player1Name.Location = new Point(120, 40);
            this.Controls.Add(m_Player1Name);

            m_IsComputerBox = new CheckBox();
            m_IsComputerBox.Checked = false;
            m_IsComputerBox.Size = new Size(20, 20);
            m_IsComputerBox.Location = new Point(20, 70);
            this.Controls.Add(m_IsComputerBox);

            m_Player2Name = new TextBox();
            m_Player2Name.Location = new Point(150, 70);
            this.Controls.Add(m_Player2Name);

        }

        private void setButtonStart()
        {
            m_ButtonStart = new Button();
            m_ButtonStart.Text = "Let's Start";
            m_ButtonStart.Location = new Point(100, 200);
            this.Controls.Add(m_ButtonStart);

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // StartGameForm
            // 
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Name = "StartGameForm";
            this.ResumeLayout(false);

        }
    }
   

    
}
