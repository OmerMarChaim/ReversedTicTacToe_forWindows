using System;
using System.Windows.Forms;

namespace UserInterfaceWindows
{
    class StartGameForm : Form
    {
        private Label m_Players;
        private Label m_Player1Label;
        private Label m_Player2Label;
        private Label m_RowsLabel;
        private Label m_ColsLabel;
        private Label m_BoardSize;
        private Button m_ButtonStart;
        private TextBox m_Player1Name;
        private TextBox m_Player2Name;
        private CheckBox m_IsComputerBox;
        private NumericUpDown m_RowsNumericUpDown;
        private NumericUpDown m_ColsNumericUpDown;
        private readonly int r_MaxSizeOfBoard;
        private readonly int r_MinSizeOfBoard;
        public string Player1Name
        {
            get { return m_Player1Name.Text; }
        }
        public string Player2Name
        {
            get { return m_Player2Name.Text; }
        }

        public bool IsComputerBox
        {
            get { return m_IsComputerBox.Checked; }
        }

        public decimal NumberOfColsAndRows
        {
            get { return m_ColsNumericUpDown.Value; }
        }

        public StartGameForm()
        {
            this.Text = "Game Settings";

            r_MaxSizeOfBoard = GameManager.GetValidMaxSizeOfBoard();
            r_MinSizeOfBoard = GameManager.GetValidMinSizeOfBoard();
            InitializeComponent();
            updateComponents();
            //action when start button press -> need to init game
        }

        private void updateComponents()
        {
            this.m_ColsNumericUpDown.Maximum = r_MaxSizeOfBoard;
            this.m_ColsNumericUpDown.Minimum = r_MinSizeOfBoard;
            this.m_RowsNumericUpDown.Maximum = r_MaxSizeOfBoard;
            this.m_RowsNumericUpDown.Minimum = r_MinSizeOfBoard;
        }

        // ReSharper disable once InconsistentNaming
        private void InitializeComponent()
        {
            this.m_ButtonStart = new System.Windows.Forms.Button();
            this.m_Player1Name = new System.Windows.Forms.TextBox();
            this.m_IsComputerBox = new System.Windows.Forms.CheckBox();
            this.m_ColsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.m_RowsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.m_Player2Name = new System.Windows.Forms.TextBox();
            this.m_Players = new System.Windows.Forms.Label();
            this.m_Player1Label = new System.Windows.Forms.Label();
            this.m_Player2Label = new System.Windows.Forms.Label();
            this.m_BoardSize = new System.Windows.Forms.Label();
            this.m_ColsLabel = new System.Windows.Forms.Label();
            this.m_RowsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.m_ColsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_RowsNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // m_ButtonStart
            // 
            this.m_ButtonStart.Location = new System.Drawing.Point(14, 175);
            this.m_ButtonStart.Name = "m_ButtonStart";
            this.m_ButtonStart.Size = new System.Drawing.Size(233, 32);
            this.m_ButtonStart.TabIndex = 0;
            this.m_ButtonStart.Text = "Let\'s Start";
            this.m_ButtonStart.Click += new System.EventHandler(this.m_ButtonStart_Click);
            // 
            // m_Player1Name
            // 
            this.m_Player1Name.Location = new System.Drawing.Point(147, 37);
            this.m_Player1Name.Name = "m_Player1Name";
            this.m_Player1Name.Size = new System.Drawing.Size(100, 26);
            this.m_Player1Name.TabIndex = 1;
            // 
            // m_IsComputerBox
            // 
            this.m_IsComputerBox.Location = new System.Drawing.Point(34, 76);
            this.m_IsComputerBox.Name = "m_IsComputerBox";
            this.m_IsComputerBox.Size = new System.Drawing.Size(20, 20);
            this.m_IsComputerBox.TabIndex = 2;
            this.m_IsComputerBox.CheckedChanged += new System.EventHandler(this.m_IsComputerBox_CheckedChanged);
            // 
            // m_ColsNumericUpDown
            // 
            this.m_ColsNumericUpDown.AutoSize = true;
            this.m_ColsNumericUpDown.Location = new System.Drawing.Point(89, 131);
            
            this.m_ColsNumericUpDown.Name = "m_ColsNumericUpDown";
            this.m_ColsNumericUpDown.Size = new System.Drawing.Size(51, 26);
            this.m_ColsNumericUpDown.TabIndex = 3;
            this.m_ColsNumericUpDown.Value = new decimal(new int[] { 5, 0, 0, 0 });
            this.m_ColsNumericUpDown.ValueChanged += new System.EventHandler(this.m_ColsNumericUpDown_ValueChanged);
            // 
            // m_RowsNumericUpDown
            // 
            this.m_RowsNumericUpDown.AutoSize = true;
            this.m_RowsNumericUpDown.Location = new System.Drawing.Point(196, 131);
       
            this.m_RowsNumericUpDown.Name = "m_RowsNumericUpDown";
            this.m_RowsNumericUpDown.Size = new System.Drawing.Size(51, 26);
            this.m_RowsNumericUpDown.TabIndex = 4;
            this.m_RowsNumericUpDown.Value = new decimal(new int[] { 5, 0, 0, 0 });
            this.m_RowsNumericUpDown.ValueChanged += new System.EventHandler(this.m_RowsNumericUpDown_ValueChanged);
            // 
            // m_Player2Name
            // 
            this.m_Player2Name.Enabled = false;
            this.m_Player2Name.Location = new System.Drawing.Point(147, 72);
            this.m_Player2Name.Name = "m_Player2Name";
            this.m_Player2Name.Size = new System.Drawing.Size(100, 26);
            this.m_Player2Name.TabIndex = 5;
            this.m_Player2Name.Text = "Computer";
            // 
            // m_Players
            // 
            this.m_Players.Location = new System.Drawing.Point(10, 10);
            this.m_Players.Name = "m_Players";
            this.m_Players.Size = new System.Drawing.Size(70, 30);
            this.m_Players.TabIndex = 6;
            this.m_Players.Text = "Players:";
            // 
            // m_Player1label
            // 
            this.m_Player1Label.Location = new System.Drawing.Point(30, 40);
            this.m_Player1Label.Name = "m_Player1Label";
            this.m_Player1Label.Size = new System.Drawing.Size(78, 24);
            this.m_Player1Label.TabIndex = 7;
            this.m_Player1Label.Text = "Player 1:";
            // 
            // m_Player2label
            // 
            this.m_Player2Label.Location = new System.Drawing.Point(60, 75);
            this.m_Player2Label.Name = "m_Player2Label";
            this.m_Player2Label.Size = new System.Drawing.Size(74, 23);
            this.m_Player2Label.TabIndex = 8;
            this.m_Player2Label.Text = "Player 2:";
            // 
            // m_BoardSize
            // 
            this.m_BoardSize.Location = new System.Drawing.Point(10, 104);
            this.m_BoardSize.Name = "m_BoardSize";
            this.m_BoardSize.Size = new System.Drawing.Size(100, 23);
            this.m_BoardSize.TabIndex = 9;
            this.m_BoardSize.Text = "Board Size:";
            // 
            // m_ColsLabel
            // 
            this.m_ColsLabel.AutoSize = true;
            this.m_ColsLabel.Location = new System.Drawing.Point(146, 133);
            this.m_ColsLabel.Name = "m_ColsLabel";
            this.m_ColsLabel.Size = new System.Drawing.Size(44, 20);
            this.m_ColsLabel.TabIndex = 10;
            this.m_ColsLabel.Text = "Cols:";
            // 
            // m_RowsLabel
            // 
            this.m_RowsLabel.AutoSize = true;
            this.m_RowsLabel.Location = new System.Drawing.Point(30, 133);
            this.m_RowsLabel.Name = "m_RowsLabel";
            this.m_RowsLabel.Size = new System.Drawing.Size(53, 20);
            this.m_RowsLabel.TabIndex = 11;
            this.m_RowsLabel.Text = "Rows:";
            // 
            // StartGameForm
            // 
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(284, 236);
            this.Controls.Add(this.m_ButtonStart);
            this.Controls.Add(this.m_Player1Name);
            this.Controls.Add(this.m_IsComputerBox);
            this.Controls.Add(this.m_ColsNumericUpDown);
            this.Controls.Add(this.m_RowsNumericUpDown);
            this.Controls.Add(this.m_Player2Name);
            this.Controls.Add(this.m_Players);
            this.Controls.Add(this.m_Player1Label);
            this.Controls.Add(this.m_Player2Label);
            this.Controls.Add(this.m_BoardSize);
            this.Controls.Add(this.m_ColsLabel);
            this.Controls.Add(this.m_RowsLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StartGameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.m_ColsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_RowsNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void m_ColsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            m_RowsNumericUpDown.Value = m_ColsNumericUpDown.Value;
        }

        private void m_RowsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            m_ColsNumericUpDown.Value = m_RowsNumericUpDown.Value;
        }

        private void m_IsComputerBox_CheckedChanged(object sender, EventArgs e)
        {
            m_Player2Name.Enabled = !m_Player2Name.Enabled;
            if(m_Player2Name.Enabled == false)
            {
                m_Player2Name.Text = "Computer";
            }
        }

        private void m_ButtonStart_Click(object sender, EventArgs e)
        {
            bool isEmptyNameOfPlayer1 = m_Player1Name.Text == "";
            bool isEmptyNameOfPlayer2 = m_Player1Name.Text == "";
            if(isEmptyNameOfPlayer1 || isEmptyNameOfPlayer2)
            {
                MessageBox.Show("Empty Name field! You have to insert player name");
            }
            else
            {
                this.Hide();
                new GameManager(this);
            }
        }

    }
}