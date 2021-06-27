using System.Windows.Forms;

namespace UserInterfaceWindows
{
    class ButtonInMatrix : Button
    {

        private readonly int r_RowNumber;
        private readonly int r_ColNumber;
        public ButtonInMatrix(int i_RowNumber, int i_ColNumber)
        {
            r_RowNumber = i_RowNumber;
            r_ColNumber = i_ColNumber;
        }

        public int RowNumber
        {
            get { return r_RowNumber; }
        }
        public int ColNumber
        {
            get { return r_ColNumber; }
        }

    }
}
