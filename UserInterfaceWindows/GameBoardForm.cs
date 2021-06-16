using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReverseTicTacToeGame;

namespace UserInterfaceWindows
{
    class GameBoardForm : Form
    {
        private int m_Size;
        private const char k_Circle = 'O';
        private const char k_Cross = 'X';
        private Label labelPlyer1;
        private Label labelPlyer2;
        private readonly Button[,] m_ButtonsTable;
        private GameManeger m_GameManeger;

        public GameBoardForm(int i_Size, GameManeger i_GameManeger)
        {
            m_Size = i_Size;
            m_ButtonsTable = new Button[m_Size, m_Size];
            m_GameManeger = i_GameManeger;
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
                    Button newButton = initNewButton(wantedLeft, wantedTop);
                  
                    
                    wantedLeft = newButton.Left + 55;
                    m_ButtonsTable[i, j] = newButton;

                }
                wantedTop = m_ButtonsTable[i, 0].Bottom + 5;
                wantedLeft = 5;
            }
        }

        private Button initNewButton(int i_WantedLeft, int i_WantedTop)
        {
            Button newButton = new Button();
            newButton.Size = new Size(50, 50);
            newButton.Left = i_WantedLeft;
            newButton.Top = i_WantedTop;
            newButton.Click += newButton_Click;
            this.Controls.Add(newButton);
            return newButton;
        }

     

        private void newButton_Click(object i_Sender, EventArgs i_E)
        {
            for(int i = 0; i < m_Size; i++)
            {
                for(int j = 0; j < m_Size ; j++)
                {
                    if (m_ButtonsTable[i,j] as Button == (i_Sender as Button))
                    {
                        (int row, int col) newPoint = (i, j);
                        m_GameManeger.ValidPointFromUser(newPoint);
                        //todo
                        //just chack if work it doesnt work with computer player.
                     
                     
                    }
                }
            }
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

        public static void GetPointOfButton(object i_Sender)
        {
            throw new NotImplementedException();
        }

        public void setPoint((int row, int column) i_Arg1, ePlayersMark i_Arg2)
        {
            String symbolText = i_Arg2 == ePlayersMark.Player1 ? "X" : "O";
            (m_ButtonsTable[i_Arg1.row, i_Arg1.column] as Button).Text = symbolText;
            (m_ButtonsTable[i_Arg1.row, i_Arg1.column] as Button).Enabled = false;
        }

        public void showTieMessage()
        {
             MessageBox.Show("No one is going to win this game, there's a tie! This game is over without winner.");
        }

        public void showWinMessage(ePlayersMark i_SignOfTheWinner, string i_WinnerName)
        {
       


        }

        public void showQuitMessage(ePlayersMark i_SignOfTheWinner, string i_WinnerName)
        {
            MessageBox.Show($@"You Quit from the Game! The winner in this round is : {i_WinnerName} ! Who play with {i_SignOfTheWinner}
See YOU next Semester");
        this.Close();
        }
    }

    
}
