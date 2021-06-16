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
        private GameManager m_GameManager;

        public GameBoardForm(int i_Size, GameManager i_GameManager)
        {
            m_Size = i_Size;
            m_ButtonsTable = new Button[m_Size, m_Size];
            m_GameManager = i_GameManager;
            initButtonsTableButton();
            this.AutoSize = true;
           // InitializeComponent();
            this.labelPlyer1 = new System.Windows.Forms.Label();
            this.labelPlyer2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
           ///todo Omri
           /// put ths Labaels at the bottom of the page
           // 
            // labelPlyer1
            // 
            this.labelPlyer1.Location = new System.Drawing.Point(200, 5*m_Size+25 );
            this.labelPlyer1.Name = "Player1Point";
            this.labelPlyer1.Size = new System.Drawing.Size(100, 23);
            this.labelPlyer1.TabIndex = 1;
            this.labelPlyer1.Text = $" {m_GameManager.Player1Name} : {m_GameManager.getNumberOfWinPlayer1()}";
           // this.Controls.Add(labelPlyer1);
            // 
            // labelPlyer2
            // 
            this.labelPlyer2.Location = new System.Drawing.Point(0, 0);
            this.labelPlyer2.Name = "Player2Point";
            this.labelPlyer2.Size = new System.Drawing.Size(100, 23);
            this.labelPlyer2.TabIndex = 0;
            this.labelPlyer1.Text = $" {m_GameManager.Player2Name} : {m_GameManager.getNumberOfWinPlayer2()}";
        //    this.Controls.Add(labelPlyer2);

            this.AutoSize = true;
            this.Name = "GameBoardForm";
            this.StartPosition = FormStartPosition.CenterScreen;

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
                        m_GameManager.ValidPointFromUser(newPoint);
                 
                    }
                }
            }
        }

        private void InitializeComponent()
        {
           
            // 
            // GameBoardForm
            // 
            this.ClientSize = new System.Drawing.Size(369, 297);
            this.Controls.Add(this.labelPlyer2);
            this.Controls.Add(this.labelPlyer1);
        
            this.ResumeLayout(false);

        }


        public void setPoint((int row, int column) i_Arg1, ePlayersMark i_Arg2)
        {
            String symbolText = i_Arg2 == ePlayersMark.Player1 ? "X" : "O";
            Color symbolColor= i_Arg2== ePlayersMark.Player1 ?  Color.Red :Color.MistyRose; 
            (m_ButtonsTable[i_Arg1.row, i_Arg1.column] as Button).Text = symbolText;
            (m_ButtonsTable[i_Arg1.row, i_Arg1.column] as Button).Enabled = false;
            (m_ButtonsTable[i_Arg1.row, i_Arg1.column] as Button).BackColor= symbolColor;
        }

        public void showTieMessage()
        {
             MessageBox.Show("No one is going to win this game, there's a tie! This game is over without winner.");
        }

        public void showWinMessage(ePlayersMark i_SignOfTheWinner, string i_WinnerName)
        {
           // String signOfWinner= i_SignOfTheWinner==
            MessageBox.Show($@"There is a win! The winner in this round is : {i_WinnerName} ! Who play with {(Char)i_SignOfTheWinner}");
        }

        public void showQuitMessage(ePlayersMark i_SignOfTheWinner, string i_WinnerName)
        {
            MessageBox.Show($@"You Quit from the Game! The winner in this round is : {i_WinnerName} ! Who play with {(Char)i_SignOfTheWinner}
See YOU next Time");
        this.Close();
        }

        public bool isWantAnotherGame()
        {
            bool isWantAnother = false;
            string message = "Do you want to play another game?";
            string title = "Another Game";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult resultFromUser = MessageBox.Show(message, title, buttons);
            if(resultFromUser == DialogResult.No)
            {
                MessageBox.Show("Thank you for playing with us! see you Next Semester");
                this.Close();
                isWantAnother = false;
            }
            else
            {
                m_GameManager.makeNewGame();
                this.Close();
                isWantAnother = true;
            }

            return isWantAnother;
        }

    }

    
}
