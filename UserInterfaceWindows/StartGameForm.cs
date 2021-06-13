﻿using System;
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
            InitializeComponent();

            //action when start button press -> need to init game

        }


        private void InitializeComponent()
        {
            this.m_ButtonStart = new System.Windows.Forms.Button();
            this.m_Player1Name = new System.Windows.Forms.TextBox();
            this.m_IsComputerBox = new System.Windows.Forms.CheckBox();
            this.m_ColsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.m_RowsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.m_Player2Name = new System.Windows.Forms.TextBox();
            this.m_Players = new System.Windows.Forms.Label();
            this.m_Player1label = new System.Windows.Forms.Label();
            this.m_Player2label = new System.Windows.Forms.Label();
            this.m_BoardSize = new System.Windows.Forms.Label();
            this.m_ColsLabel = new System.Windows.Forms.Label();
            this.m_RowsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.m_ColsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_RowsNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // m_ButtonStart
            // 
            this.m_ButtonStart.Location = new System.Drawing.Point(20, 172);
            this.m_ButtonStart.Name = "m_ButtonStart";
            this.m_ButtonStart.Size = new System.Drawing.Size(200, 23);
            this.m_ButtonStart.TabIndex = 0;
            this.m_ButtonStart.Text = "Let\'s Start";
            this.m_ButtonStart.Click += new System.EventHandler(this.m_ButtonStart_Click);
            // 
            // m_Player1Name
            // 
            this.m_Player1Name.Location = new System.Drawing.Point(120, 40);
            this.m_Player1Name.Name = "m_Player1Name";
            this.m_Player1Name.Size = new System.Drawing.Size(100, 20);
            this.m_Player1Name.TabIndex = 1;
            // 
            // m_IsComputerBox
            // 
            this.m_IsComputerBox.Location = new System.Drawing.Point(20, 67);
            this.m_IsComputerBox.Name = "m_IsComputerBox";
            this.m_IsComputerBox.Size = new System.Drawing.Size(20, 20);
            this.m_IsComputerBox.TabIndex = 2;
            this.m_IsComputerBox.CheckedChanged += new System.EventHandler(this.m_IsComputerBox_CheckedChanged);
            // 
            // m_ColsNumericUpDown
            // 
            this.m_ColsNumericUpDown.Location = new System.Drawing.Point(71, 126);
            this.m_ColsNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.m_ColsNumericUpDown.Minimum = 3;
            this.m_ColsNumericUpDown.Name = "m_ColsNumericUpDown";
            this.m_ColsNumericUpDown.Size = new System.Drawing.Size(40, 20);
            this.m_ColsNumericUpDown.TabIndex = 3;
            this.m_ColsNumericUpDown.Value = 5;
            this.m_ColsNumericUpDown.ValueChanged += new System.EventHandler(this.m_ColsNumericUpDown_ValueChanged);
            // 
            // m_RowsNumericUpDown
            // 
            this.m_RowsNumericUpDown.Location = new System.Drawing.Point(163, 126);
            this.m_RowsNumericUpDown.Maximum = 9;
            this.m_RowsNumericUpDown.Minimum = 3;
            this.m_RowsNumericUpDown.Name = "m_RowsNumericUpDown";
            this.m_RowsNumericUpDown.Size = new System.Drawing.Size(40, 20);
            this.m_RowsNumericUpDown.TabIndex = 4;
            this.m_RowsNumericUpDown.Value = 5;
            this.m_RowsNumericUpDown.ValueChanged += new System.EventHandler(this.m_RowsNumericUpDown_ValueChanged);
            // 
            // m_Player2Name
            // 
            this.m_Player2Name.Enabled = false;
            this.m_Player2Name.Location = new System.Drawing.Point(120, 67);
            this.m_Player2Name.Name = "m_Player2Name";
            this.m_Player2Name.Size = new System.Drawing.Size(100, 20);
            this.m_Player2Name.TabIndex = 5;
            this.m_Player2Name.Text = "[Computer]";
            // 
            // m_Players
            // 
            this.m_Players.Location = new System.Drawing.Point(10, 10);
            this.m_Players.Name = "m_Players";
            this.m_Players.Size = new System.Drawing.Size(50, 20);
            this.m_Players.TabIndex = 6;
            this.m_Players.Text = "Players:";
            // 
            // m_Player1label
            // 
            this.m_Player1label.Location = new System.Drawing.Point(17, 40);
            this.m_Player1label.Name = "m_Player1label";
            this.m_Player1label.Size = new System.Drawing.Size(50, 20);
            this.m_Player1label.TabIndex = 7;
            this.m_Player1label.Text = "Player 1:";
            // 
            // m_Player2label
            // 
            this.m_Player2label.Location = new System.Drawing.Point(46, 70);
            this.m_Player2label.Name = "m_Player2label";
            this.m_Player2label.Size = new System.Drawing.Size(50, 17);
            this.m_Player2label.TabIndex = 8;
            this.m_Player2label.Text = "Player 2:";
            // 
            // m_BoardSize
            // 
            this.m_BoardSize.Location = new System.Drawing.Point(20, 100);
            this.m_BoardSize.Name = "m_BoardSize";
            this.m_BoardSize.Size = new System.Drawing.Size(100, 23);
            this.m_BoardSize.TabIndex = 9;
            this.m_BoardSize.Text = "Board Size:";
            // 
            // m_ColsLabel
            // 
            this.m_ColsLabel.Location = new System.Drawing.Point(30, 130);
            this.m_ColsLabel.Name = "m_ColsLabel";
            this.m_ColsLabel.Size = new System.Drawing.Size(50, 20);
            this.m_ColsLabel.TabIndex = 10;
            this.m_ColsLabel.Text = "Cols:";
            // 
            // m_RowsLabel
            // 
            this.m_RowsLabel.Location = new System.Drawing.Point(117, 128);
            this.m_RowsLabel.Name = "m_RowsLabel";
            this.m_RowsLabel.Size = new System.Drawing.Size(40, 20);
            this.m_RowsLabel.TabIndex = 11;
            this.m_RowsLabel.Text = "Rows:";
            // 
            // StartGameForm
            // 
            this.ClientSize = new System.Drawing.Size(279, 500);
            this.Controls.Add(this.m_ButtonStart);
            this.Controls.Add(this.m_Player1Name);
            this.Controls.Add(this.m_IsComputerBox);
            this.Controls.Add(this.m_ColsNumericUpDown);
            this.Controls.Add(this.m_RowsNumericUpDown);
            this.Controls.Add(this.m_Player2Name);
            this.Controls.Add(this.m_Players);
            this.Controls.Add(this.m_Player1label);
            this.Controls.Add(this.m_Player2label);
            this.Controls.Add(this.m_BoardSize);
            this.Controls.Add(this.m_ColsLabel);
            this.Controls.Add(this.m_RowsLabel);
            this.Name = "StartGameForm";
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
            m_IsComputerBox.Checked = !m_IsComputerBox.Checked;
            m_Player2Name.Enabled = !m_Player2Name.Enabled;
            if(m_Player2Name.Enabled == false)
            {
                m_Player2Name.Text = "[Computer]";
            }
        }

        private void m_ButtonStart_Click(object sender, EventArgs e)
        {

            this.Close();
        }
    }
}
