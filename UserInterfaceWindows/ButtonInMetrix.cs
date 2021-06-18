using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterfaceWindows
{
    class ButtonInMetrix :Button
    {

        private int m_RowNumber;
        private int m_ColNumber;
        public ButtonInMetrix(int i_RowNumber, int i_ColNumber)
        {
            m_RowNumber = i_RowNumber;
            m_ColNumber = i_ColNumber;
        }

        public int RowNumber
        {
            get { return m_RowNumber; }
        }
        public int ColNumber
        {
            get { return m_ColNumber; }
        }

    }
}
