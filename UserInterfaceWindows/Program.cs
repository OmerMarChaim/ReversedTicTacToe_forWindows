using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReverseTicTacToeGame;

namespace UserInterfaceWindows
{
    class Program
    {
        public static void Main()
        {
            StartGameForm startGameForm = new StartGameForm();
            startGameForm.ShowDialog();
            
        }
    }
}
