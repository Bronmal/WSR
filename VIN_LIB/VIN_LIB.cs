using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIN_LIB
{
    public class VIN_LIB
    {
        public Boolean CheckVIN(String vin)
        {
            Dictionary<char, int> dict_char_and_int = new Dictionary<char, int>()
            {
                {'A', 1 },
                {'B', 2 },
                {'C', 3 },
                {'D', 4 },
                {'E', 5 },
                {'F', 6 },
                {'G', 7 },
                {'H', 8 },
                {'J', 1 },
                {'K', 2 },
                {'L', 3 },
                {'M', 4 },
                {'N', 5 },
                {'P', 7 },
                {'R', 9 },
                {'S', 2 },
                {'T', 3 },
                {'U', 4 },
                {'V', 5 },
                {'W', 6 },
                {'X', 7 },
                {'Y', 8 },
                {'Z', 9 }
            };

            int[] weight = new int[17]
            {
                8, 7, 6, 5, 4, 3, 2, 10, 0, 9, 8, 7, 6, 5, 4, 3, 2
            };

            if (vin.Length != 17)
            {
                return false;
            }

            char[] char_numbers_vin = vin.ToArray();
            foreach (char c in char_numbers_vin)
            {
                if (c == 'I' || c == 'O' || c == 'Q')
                {
                    return false;
                }
            }

            int[] changed_letter_to_num = new int[17];
            for(int c = 0; c < char_numbers_vin.Length; c++)
            {
                int temp;
                if (!int.TryParse(char_numbers_vin[c].ToString(), out temp))
                {
                    changed_letter_to_num[c] = dict_char_and_int[char_numbers_vin[c]];
                }
                else { changed_letter_to_num[c] = temp; }
                
            }
            double check_sum = 0;

            for (int i = 0; i < changed_letter_to_num.Length; i++)
            {
                if (i == 8) { continue; }
                check_sum = check_sum + (changed_letter_to_num[i] * weight[i]);
            }
            if (check_sum - (Math.Floor(check_sum * 11) * 11) == 10)
            {
                if (char_numbers_vin[8] != 'X')
                {
                    return false;
                }
            }
            if (check_sum - (Math.Floor(check_sum / 11) * 11) != changed_letter_to_num[8])
            {
                return false;
            }
            return true;
        }

        public String GetVINCountry(String vin)
        {
            return vin;
        }

        public int GetTransportYear(String vin)
        {
            Dictionary<int, char> char_years = new Dictionary<int, char>();
            char[] alphabet = new char[30]
            {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'R', 'S', 'T', 'V', 'W', 'X', 'Y', '1', '2', '3', '4', '5', '6', '7', '8', '9'
            };
            int years = 1980;
            int year_now = DateTime.Now.Year;
            while (years < year_now)
            {
                foreach (char i in alphabet)
                {
                    char_years.Add(years, i);
                    years++;
                }
            }
            char[] char_numbers_vin = vin.ToArray();
            foreach (char i in char_years.Values)
            {
                if (i == char_numbers_vin[9])
                {
                    return char_years.Where(x => x.Value == i).FirstOrDefault().Key;

                }
            }
            return -1;
        }
    }
}
