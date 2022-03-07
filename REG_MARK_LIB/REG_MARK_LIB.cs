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
            char[] alpabet = new char[12] { 'A', 'B', 'E', 'K', 'M', 'H', 'O', 'P', 'C', 'T', 'Y', 'X' };
            char[] char_mark_array = mark.ToCharArray();
            char[] check_letters = new char[3] { char_mark_array[0], char_mark_array[4], char_mark_array[5] };
            foreach (char i in check_letters)
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
