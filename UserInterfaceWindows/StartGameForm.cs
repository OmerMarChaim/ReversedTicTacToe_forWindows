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
            m_Cols = new NumericUpDown();
            m_Cols.Maximum = 9;
            m_Cols.Minimum = 3;
            m_Cols.Value = 5;
            m_Cols.Size = new Size(40, 25);
            m_Cols.Location = new Point(100, 130);
            m_Cols.Increment = 1;
            this.Controls.Add(m_Cols);

            m_Rows = new NumericUpDown();
            m_Rows.Location = new Point(100, 160);
            m_Rows.Maximum = 9;
            m_Rows.Minimum = 3;
            m_Rows.Value = 5;
            m_Rows.Size = new Size(40, 25);
            m_Rows.Increment = 1;
            this.Controls.Add(m_Rows);
        }

        private void setLabels()
        {
            m_Players = new Label();
            m_Players.Text = "Players:";
            m_Players.Location = new Point(10,10);
            this.Controls.Add(m_Players);


            m_Player1label = new Label();
            m_Player1label.Text = "Player 1:";
            m_Player1label.Location = new Point(20, 40);
            this.Controls.Add(m_Player1label);


            m_Player2label = new Label();
            m_Player2label.Text = "Player 2:";
            m_Player2label.Size = new Size(50, 20);
            m_Player2label.Location = new Point(50, 70);
            this.Controls.Add(m_Player2label);

            m_BoardSize = new Label();
            m_BoardSize.Text = "Board Size:";
            m_BoardSize.Location = new Point(20, 100);
            this.Controls.Add(m_BoardSize);
            
            m_ColsLabel=new Label();
            m_ColsLabel.Text = "Cols:";
            m_ColsLabel.Size = new Size(50, 20);
            m_ColsLabel.Location = new Point(30, 130);
           this.Controls.Add(m_ColsLabel);

        
           // this.Controls.Add(m_ColsLabel);




            m_RowsLabel = new Label();
            m_RowsLabel.Text = "Rows:";
            m_RowsLabel.Size = new Size(50, 20);
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
