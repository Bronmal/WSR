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
            string region = "";
            foreach (Match match in matches)
            {
                region = GetValue(match, "region");
            }
            return region;
        }

    }
}
