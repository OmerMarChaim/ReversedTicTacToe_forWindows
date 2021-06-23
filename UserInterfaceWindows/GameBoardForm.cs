using System;
using System.Drawing;
using System.Windows.Forms;
using GameLogic;

namespace UserInterfaceWindows
{
    class GameBoardForm : Form
    {
        private readonly int r_Size;
        private readonly ButtonInMatrix[,] r_ButtonsTable;
        private Label m_LabelPlayersScore;
        private Label m_LabelPlayersScore1;
        private readonly string r_Player2Name;
        private readonly GameManager m_GameManager;

        public GameBoardForm(int i_Size, GameManager i_GameManager)
        {
            r_Size = i_Size;
            r_ButtonsTable = new ButtonInMatrix[r_Size, r_Size];
            m_GameManager = i_GameManager;

            r_Player2Name = m_GameManager.Player2isComputer ? "Computer" : "Player 1";
            initButtonsTableButton();
            InitializeComponent();
            updateComponents();
        }

        private void updateComponents()
        {
            this.m_LabelPlayersScore.Location = new Point(
                r_ButtonsTable[r_Size / 2, 0].Right,
                r_ButtonsTable[r_Size - 1, 0].Bottom);
            this.m_LabelPlayersScore.Text =
                $@"Player 1 : {m_GameManager.GetNumberOfWinPlayer1()} ";

            this.m_LabelPlayersScore1.Left = m_LabelPlayersScore.Right + 10;
            this.m_LabelPlayersScore1.Top = m_LabelPlayersScore.Top;
            this.m_LabelPlayersScore1.Text =
                $@"{r_Player2Name} : {m_GameManager.GetNumberOfWinPlayer2()} ";
        }

        private void initButtonsTableButton()
        {
            int wantedTop = 5;
            int wantedLeft = 5;
            for(int i = 0; i < r_Size; i++)
            {
                for(int j = 0; j < r_Size; j++)
                {
                    ButtonInMatrix newButton = initNewButton(wantedLeft, wantedTop, i, j);
                    wantedLeft = newButton.Left + 55;
                    r_ButtonsTable[i, j] = newButton;
                }

                wantedTop = r_ButtonsTable[i, 0].Bottom + 5;
                wantedLeft = 5;
            }
        }

        private ButtonInMatrix initNewButton(int i_WantedLeft, int i_WantedTop, int i_RowNumber, int i_ColNumber)
        {
            ButtonInMatrix newButton = new ButtonInMatrix(i_RowNumber, i_ColNumber);
            newButton.Size = new Size(50, 50);
            newButton.Left = i_WantedLeft;
            newButton.Top = i_WantedTop;
            newButton.Click += newButton_Click;
            this.Controls.Add(newButton);

            return newButton;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            int rowNumber = (sender as ButtonInMatrix).RowNumber;
            int colNumber = (sender as ButtonInMatrix).ColNumber;
            (int row, int col) newPoint = (rowNumber, colNumber);
            m_GameManager.ValidPointFromUser(newPoint);
        }

        // This naming is due to the save word for designer
        // ReSharper disable once InconsistentNaming
        private void InitializeComponent()
        {
            this.m_LabelPlayersScore = new Label();
            this.m_LabelPlayersScore1 = new Label();

            this.SuspendLayout();

            // 
            // LabelPlayersScore
            // 
            this.m_LabelPlayersScore.AutoSize = true;
            this.m_LabelPlayersScore.Name = "m_LabelPlayersScore";
            this.m_LabelPlayersScore.Padding = new Padding(5);
            this.m_LabelPlayersScore.Size = new Size(79, 30);
            this.m_LabelPlayersScore.TabIndex = 8;
            this.m_LabelPlayersScore.Font = new Font(m_LabelPlayersScore.Font, FontStyle.Bold);
            //{m_GameManager.Player1Name} 
            // 
            // LabelPlayersScore
            // 
            this.m_LabelPlayersScore1.AutoSize = true;
            this.m_LabelPlayersScore1.Name = "m_LabelPlayersScore";
            this.m_LabelPlayersScore1.Padding = new Padding(5);
            this.m_LabelPlayersScore1.Size = new Size(79, 30);
            this.m_LabelPlayersScore1.TabIndex = 8;

            // 
            // GameBoardForm
            // 
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.ClientSize = new Size(m_LabelPlayersScore1.Right+20, m_LabelPlayersScore1.Bottom + 20);
            this.Controls.Add(this.m_LabelPlayersScore);
            this.Controls.Add(this.m_LabelPlayersScore1);

            this.Name = "GameBoardForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Text = "Reverse Tic Tac Toe";
            this.FormClosed += GameBoardForm_FormClosed;
         
        }

        private void GameBoardForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(e.CloseReason.Equals(CloseReason.UserClosing))
            {
                m_GameManager.ValidPointFromUser(m_GameManager.QuitPoint);
            }
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
            MessageBox.Show("No one is going to win this game, there's a tie! This game is over without winner.", "Tie!");
        }

        internal void ShowWinMessage(ePlayersMark i_SignOfTheWinner, string i_WinnerName)
        {

            MessageBox.Show(
                $@"There is a win!
The winner in this round is :
    {i_WinnerName} ! Who played with {(Char)i_SignOfTheWinner}", "Win!");
        }

        internal void ShowQuitMessage(ePlayersMark i_SignOfTheWinner, string i_WinnerName, string i_LoserName)
        {
            MessageBox.Show(
                $@"{i_LoserName} Quit from the Game! The winner in this round is :
    {i_WinnerName} ! Who play with {(Char)i_SignOfTheWinner}");
        }

        internal bool IsWantAnotherGame()
        {
            bool isWantAnother;
            const string wantAnotherGameMessage = "Do you want to play another game?";
            const string wantAnotherGameTitle = "Another Game";
            const MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult resultFromUser = MessageBox.Show(wantAnotherGameMessage, wantAnotherGameTitle, buttons);
            if(resultFromUser == DialogResult.No)
            {
                string finalResult = $@"{m_GameManager.Player1Name} : {m_GameManager.GetNumberOfWinPlayer1()}  {m_GameManager.Player2Name} : {m_GameManager.GetNumberOfWinPlayer2()} ";

                MessageBox.Show($@"Thank you for playing with us! 
the final Result is :
{finalResult}
see you next Semester ;) ","Goodbye");
                this.Hide();
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

        public void ChangeCurrentPlayer(bool i_Is1CurrentPlayer)
        {
            if(i_Is1CurrentPlayer)
            {
                this.m_LabelPlayersScore.Font = new Font(m_LabelPlayersScore.Font, FontStyle.Bold);
                this.m_LabelPlayersScore1.Font = new Font(m_LabelPlayersScore.Font, FontStyle.Regular);
            }
            else
            {
                this.m_LabelPlayersScore1.Font = new Font(m_LabelPlayersScore.Font, FontStyle.Bold);
                this.m_LabelPlayersScore.Font = new Font(m_LabelPlayersScore.Font, FontStyle.Regular);
            }
        }
    }
}