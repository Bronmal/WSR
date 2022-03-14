using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace REG_MARK_LIB
{
    public class REG_MARK_LIB
    {
        private string GetValue(Match matched, String key)
        {
            if (matched.Success)
                return matched.Groups[key].Value;
            return "";
        }

        private readonly Regex reg = new Regex(
            @"^(?<before>[abekmhopctyx])(?<number>[0-9]{3})(?<after>[abekmhopctyx]{2})(?<region>[0-9]{2,3})$",
            RegexOptions.IgnoreCase | RegexOptions.Compiled);

        private readonly char[] alphabet = new char[12] {'a', 'b', 'e', 'k', 'm', 'h', 'o', 'p', 'c', 't', 'y', 'x'};
        public bool CheckMark(string mark)
        {
            MatchCollection matches = reg.Matches(mark);
            if (matches.Count == 0)
            {
                return false;
            }

            return true;
        }

        public string GetNextMarkAfter(string mark)
        {
            MatchCollection matches = reg.Matches(mark);
            foreach (Match match in matches)
            {
                if (int.Parse(GetValue(match, "number")) < 999)
                {
                    return (GetValue(match, "before") + (int.Parse(GetValue(match, "number")) + 1).ToString("000") + GetValue(match, "after") + GetValue(match, "region")).ToUpper();
                }
                if (int.Parse(GetValue(match, "number")) == 999)
                {
                    char[] before = GetValue(match, "before").ToArray();
                    char[] after = GetValue(match, "after").ToArray();
                    char[] letters = before.Concat(after).ToArray();
                    for (int i=letters.Length-1 ; i > 0; i--)
                    {
                        if (letters[i] == alphabet[alphabet.Length - 1])
                        {
                            letters[i] = alphabet[0];
                            try
                            {
                                letters[i - 1] = alphabet[Array.IndexOf(alphabet, letters[i - 1]) + 1];
                            }
                            catch (IndexOutOfRangeException e)
                            {
                                continue;
                            }
                            
                        }
                    }
                    return (letters[0] + "000" + letters[1] + letters[2] + GetValue(match, "region")).ToUpper();
                }
            }
            return mark;
        }

    }
}
