using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REG_MARK_LIB
{
    public class REG_MARK_LIB
    {
        public Boolean CheckMark(string mark)
        {
            char[] alpabet = new char[22] { 'A', 'B', 'E', 'K', 'M', 'H', 'O', 'P', 'C', 'T', 'Y', 'X', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            char[] char_mark_array = mark.ToUpper().ToCharArray();
            foreach (char i in char_mark_array)
            {
                if (!alpabet.Contains(i))
                {
                    return false;
                }
            }

            return true;
        }

    }
}
