using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagmaMc.BetterForms.src
{
    internal static class Test
    {
        internal static void Main(string[] args)
        {
            InputData Box = InputBox.Show("a very information inputbox text to tell you what you need to input into the textbox below this message that needs to be atleast 3 letters long", "title", 3, true);
            if (!Box.Canceled)
                MessageBox.Show(Box.Value);
            Thread.Sleep(500);
        }
    }
}
