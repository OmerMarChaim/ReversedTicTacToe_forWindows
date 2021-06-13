using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterfaceWindows
{
    class GameBoardForm : Form
    {
        private int m_Size;
        private const char k_Circle = 'O';
        private const char k_Cross = 'X';
        private Label labelPlyer1;
        private Label labelPlyer2;
        private readonly Button[,] ButtonsTable;

        public GameBoardForm(int i_Size)
        {
            m_Size = i_Size;
            ButtonsTable = new Button[m_Size, m_Size];
            
            initButtonsTableButton();
            this.AutoSize = true;
            InitializeComponent();
        }

        private void initButtonsTableButton()
        {
            int wantedTop=5;
            int wantedLeft = 5;
            for (int i = 0; i < m_Size; i++)
            {
                for (int j = 0; j < m_Size; j++)
                {
                    ButtonsTable[i, j] = new Button();
                    Button newButton = ButtonsTable[i, j] as Button;
                    newButton.Size = new Size(50, 50);
                    newButton.Left = wantedLeft;
                    newButton.Top = wantedTop;
                    newButton.Click += newButton_Click;
                    this.Controls.Add(newButton);
                    wantedLeft = newButton.Left + 55;
                }
                wantedTop = ButtonsTable[i, 0].Bottom + 5;
                wantedLeft = 5;
            }
        }

        private void newButton_Click(object i_Sender, EventArgs i_E)
        {
          
        }

        private void InitializeComponent()
        {
            this.labelPlyer1 = new System.Windows.Forms.Label();
            this.labelPlyer2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelPlyer1
            // 
            this.labelPlyer1.Location = new System.Drawing.Point(0, 0);
            this.labelPlyer1.Name = "labelPlyer1";
            this.labelPlyer1.Size = new System.Drawing.Size(100, 23);
            this.labelPlyer1.TabIndex = 1;
            // 
            // labelPlyer2
            // 
            this.labelPlyer2.Location = new System.Drawing.Point(0, 0);
            this.labelPlyer2.Name = "labelPlyer2";
            this.labelPlyer2.Size = new System.Drawing.Size(100, 23);
            this.labelPlyer2.TabIndex = 0;
            // 
            // GameBoardForm
            // 
            this.ClientSize = new System.Drawing.Size(369, 297);
            this.Controls.Add(this.labelPlyer2);
            this.Controls.Add(this.labelPlyer1);
            this.Name = "GameBoardForm";
            this.ResumeLayout(false);

        }

       
    }

    
}
