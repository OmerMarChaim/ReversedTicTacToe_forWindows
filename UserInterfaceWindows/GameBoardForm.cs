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
        private readonly Button[,] m_ButtonsTable;
        private Label labelPlayer1Score;
        private Label labelPlayer2Score;
        private GameManager m_GameManager;

        public GameBoardForm(int i_Size, GameManager i_GameManager)
        {
            m_Size = i_Size;
            m_ButtonsTable = new Button[m_Size, m_Size];
            m_GameManager = i_GameManager;
           
           
            this.AutoSize = true;
            // InitializeComponent();

            //  this.SuspendLayout();
        
            initButtonsTableButton();
            InitializeComponent();

            this.AutoSize = true;
            this.Text = "Reverse Tic Tac Toe";
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
                    ButtonInMetrix newButton = initNewButton(wantedLeft, wantedTop,i,j);
                    wantedLeft = newButton.Left + 55;
                    m_ButtonsTable[i, j] = newButton;

                }
                wantedTop = m_ButtonsTable[i, 0].Bottom + 5;
                wantedLeft = 5;
            }
        }

        private ButtonInMetrix initNewButton(int i_WantedLeft, int i_WantedTop,int i_RowNumber,int i_ColNumber)
        {
            ButtonInMetrix newButton = new ButtonInMetrix(i_RowNumber,i_ColNumber);
            newButton.Size = new Size(50, 50);
            newButton.Left = i_WantedLeft;
            newButton.Top = i_WantedTop;
            newButton.Click += newButton_Click;
            this.Controls.Add(newButton);
            return newButton;
        }

     

        private void newButton_Click(object i_Sender, EventArgs i_E)
        {
            int rowNumber = (i_Sender as ButtonInMetrix).RowNumber;
            int colNumber = (i_Sender as ButtonInMetrix).ColNumber;
            (int row, int col) newPoint = (rowNumber, colNumber);
            m_GameManager.ValidPointFromUser(newPoint);
                 
                    
        }

        private void InitializeComponent()
        {
            this.labelPlayer1Score = new System.Windows.Forms.Label();
            this.labelPlayer2Score = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelPlayer1Score
            // 
         //   this.labelPlayer1Score.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelPlayer1Score.AutoSize = true;
            this.labelPlayer1Score.Location = new System.Drawing.Point(m_ButtonsTable[(m_Size - 1)/2 - 1, 0].Bottom, m_ButtonsTable[m_Size-1,0].Bottom);
            this.labelPlayer1Score.Name = "labelPlayer1Score";
            this.labelPlayer1Score.Padding = new System.Windows.Forms.Padding(5);
            this.labelPlayer1Score.Size = new System.Drawing.Size(79, 30);
            this.labelPlayer1Score.TabIndex = 8;
            this.labelPlayer1Score.Text = $@"{m_GameManager.Player1Name} : {m_GameManager.getNumberOfWinPlayer1()}      {m_GameManager.Player2Name} : {m_GameManager.getNumberOfWinPlayer2()} ";
      
            // 
            // GameBoardForm
            // 
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1000, labelPlayer1Score.Bottom+20);
         //   this.Controls.Add(this.labelPlayer2Score);
            this.Controls.Add(this.labelPlayer1Score);
            this.Name = "GameBoardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        public void setPoint((int row, int column) i_SelectedPoint, ePlayersMark i_PlayerSign)
        {
            String symbolText = i_PlayerSign == ePlayersMark.Player1 ? "X" : "O";
            Color symbolColor= i_PlayerSign== ePlayersMark.Player1 ?  Color.Red :Color.MistyRose; 
            (m_ButtonsTable[i_SelectedPoint.row, i_SelectedPoint.column] as Button).Text = symbolText;
            (m_ButtonsTable[i_SelectedPoint.row, i_SelectedPoint.column] as Button).Enabled = false;
            (m_ButtonsTable[i_SelectedPoint.row, i_SelectedPoint.column] as Button).BackColor= symbolColor;
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
See YOU next Semester");
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
                MessageBox.Show("Thank you for playing with us! see YOU next Time");
                this.Close();
                isWantAnother = false;
            }
            else
            {
                m_GameManager.makeNewGame();
                this.Hide();
                isWantAnother = true;
            }

            return isWantAnother;
        }

    
    }

    
}
