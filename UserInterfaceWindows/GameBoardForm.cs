using System;
using System.Drawing;
using System.Windows.Forms;
using ReverseTicTacToeGame;

namespace UserInterfaceWindows
{
    class GameBoardForm : Form
    {
        private int m_Size;
        private readonly ButtonInMetrix[,] r_ButtonsTable;
        private Label m_LabelPlayer1Score;
        private GameManager m_GameManager;

        public GameBoardForm(int i_Size, GameManager i_GameManager)
        {
            m_Size = i_Size;
            r_ButtonsTable = new ButtonInMetrix[m_Size, m_Size];
            m_GameManager = i_GameManager;

            initButtonsTableButton();
            InitializeComponent();

            this.Text = "Reverse Tic Tac Toe";
            this.Name = "GameBoardForm";
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void initButtonsTableButton()
        {
            int wantedTop = 5;
            int wantedLeft = 5;
            for(int i = 0; i < m_Size; i++)
            {
                for(int j = 0; j < m_Size; j++)
                {
                    ButtonInMetrix newButton = initNewButton(wantedLeft, wantedTop, i, j);
                    wantedLeft = newButton.Left + 55;
                    r_ButtonsTable[i, j] = newButton;
                }

                wantedTop = r_ButtonsTable[i, 0].Bottom + 5;
                wantedLeft = 5;
            }
        }

        private ButtonInMetrix initNewButton(int i_WantedLeft, int i_WantedTop, int i_RowNumber, int i_ColNumber)
        {
            ButtonInMetrix newButton = new ButtonInMetrix(i_RowNumber, i_ColNumber);
            newButton.Size = new Size(50, 50);
            newButton.Left = i_WantedLeft;
            newButton.Top = i_WantedTop;
            newButton.Click += newButton_Click;
            this.Controls.Add(newButton);

            return newButton;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            int rowNumber = (sender as ButtonInMetrix).RowNumber;
            int colNumber = (sender as ButtonInMetrix).ColNumber;
            (int row, int col) newPoint = (rowNumber, colNumber);
            m_GameManager.ValidPointFromUser(newPoint);
        }

        // This naming is due to the save word for designer
        // ReSharper disable once InconsistentNaming
        private void InitializeComponent()
        {
            this.m_LabelPlayer1Score = new Label();
            this.SuspendLayout();
            // 
            // labelPlayer1Score
            // 
            this.m_LabelPlayer1Score.AutoSize = true;
            this.m_LabelPlayer1Score.Location = new Point(
                    r_ButtonsTable[(m_Size) / 2 - 2, 0].Bottom,
                    r_ButtonsTable[m_Size - 1, 0].Bottom);
            this.m_LabelPlayer1Score.Name = "m_LabelPlayer1Score";
            this.m_LabelPlayer1Score.Padding = new Padding(5);
            this.m_LabelPlayer1Score.Size = new Size(79, 30);
            this.m_LabelPlayer1Score.TabIndex = 8;
            this.m_LabelPlayer1Score.Text =
                $@"{m_GameManager.Player1Name} : {m_GameManager.GetNumberOfWinPlayer1()}      {m_GameManager.Player2Name} : {m_GameManager.GetNumberOfWinPlayer2()} ";

            // 
            // GameBoardForm
            // 
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.ClientSize = new Size(r_ButtonsTable[0,m_Size-1].Right+20, m_LabelPlayer1Score.Bottom + 20);
            this.Controls.Add(this.m_LabelPlayer1Score);
            this.Name = "GameBoardForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        internal void SetPoint((int row, int column) i_SelectedPoint, ePlayersMark i_PlayerSign)
        {
            String symbolText = i_PlayerSign == ePlayersMark.Player1 ? "X" : "O";
            Color symbolColor = i_PlayerSign == ePlayersMark.Player1 ? Color.Red : Color.MistyRose;
            r_ButtonsTable[i_SelectedPoint.row, i_SelectedPoint.column].Text = symbolText;
            r_ButtonsTable[i_SelectedPoint.row, i_SelectedPoint.column].Enabled = false;
            r_ButtonsTable[i_SelectedPoint.row, i_SelectedPoint.column].BackColor = symbolColor;
        }

        internal void ShowTieMessage()
        {
            MessageBox.Show($"No one is going to win this game, there's a tie! This game is over without winner.", "Tie!");
        }

        internal void ShowWinMessage(ePlayersMark i_SignOfTheWinner, string i_WinnerName)
        {

            MessageBox.Show(
                $@"There is a win!
The winner in this round is {i_WinnerName}!
Who played with {(Char)i_SignOfTheWinner}", "Win!");
        }

        internal void ShowQuitMessage(ePlayersMark i_SignOfTheWinner, string i_WinnerName)
        {
            MessageBox.Show(
                $@"You Quit from the Game! The winner in this round is :
        {i_WinnerName} ! Who play with {(Char)i_SignOfTheWinner}
        See YOU next Semester");
            this.Close();
        }

        internal bool IsWantAnotherGame()
        {
            bool isWantAnother;
            string message = "Do you want to play another game?";
            string title = "Another Game";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult resultFromUser = MessageBox.Show(message, title, buttons);
            if(resultFromUser == DialogResult.No)
            {
                MessageBox.Show("Thank you for playing with us! see you next Semester ;) ","Goodbye");
                this.Close();
                isWantAnother = false;
            }
            else
            {
                m_GameManager.MakeNewGame();
                this.Hide();
                isWantAnother = true;
            }

            return isWantAnother;
        }
    }
}