using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIN_LIB
{
    public class VIN_LIB
    {
        public char[] alphabet = new char[30]
            {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'R', 'S', 'T', 'V', 'W', 'X', 'Y', '1', '2', '3', '4', '5', '6', '7', '8', '9'
            };
        public char[] alphabet_codes = new char[30]
            {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'R', 'S', 'T', 'V', 'W', 'X', 'Y', '1', '2', '3', '4', '5', '6', '7', '8', '9'
            };
        private string countryCodes =
            "AA-AH ЮАРAJ-AN Котд'Ивуар;BA-BE Ангола;BF-BK Кения;BL-BR Танзания;CA-CE Бенин;CF-CK Мадагаскар;CL-CR Тунис;DA-DE " +
            "Египет;DF-DK Марокко;DL-DR Замбия;EA-EE Эфиопия;EF-EK Мозамбик;FA-FE Гана;FF-FK Нигерия;JA-JT Япония;KA-KE " +
            "ШриЛанка;KF-KK Израиль;KL-KR Южная Корея;KS-K0 Казахстан;LA-L0 Китай;MA-ME Индия;MF-MK Индонезия;ML-MR " +
            "Таиланд;NF-NK Пакистан;NL-NR Турция;PA-PE Филиппины;PF-PK Сингапур;PL-PR Малайзия;RA-RE ОАЭ;RF-RK Тайвань;RL-RR " +
            "Вьетнам;RS-R0 Саудовска я Аравия;SA-SM Великобритания;SN-ST Германия;SU-SZ Польша;S1-S4 Латвия;TA-TH " +
            "Швейцария;TJ-TP Чехия;TR-TV Венгрия;TW-T1 Португалия;UH-UM Дания;UN-UT Ирландия;UU-UZ Румыния;U5-U7 " +
            "Словакия;VA-VE Австрия;VF-VR Франция;VS-VW Испания;VX-V2 Сербия;V3-V5 Хорватия;V0-V6 Эстония;WA-W0 " +
            "Германия;XA-XE Болгария;XF-XK Греция;XL-XR Нидерланды;XS-XW СССР/СНГ;XX-X2 Люксембург;X0-X3 Россия;YA-YE " +
            "Бельгия;YF-YK Финляндия;YL-YR Мальта;YS-YW Швеция;YX-Y2 Норвегия;Y3-Y5 Беларусь;Y0-Y6 Украина;ZA-ZR Италия;" +
            "1A-10 США;2A-20 Канада;3A-3W Мексика;3X-37 Коста Рика;30-38 Каймановы острова;4A-40 США;5A-50 США;6A-6W " +
            "Австралия;7A-7E Новая Зеландия;8A-8E Аргентина;8F-8K Чили;8L-8R Эквадор;8S-8W Перу;8X-82 Венесуэла;9A-9E " +
            "Бразилия;9F-9K Колумбия;9L-9R Парагвай;9S-9W Уругвай;9X-92 Тринидад и Тобаго;93-99 Бразилия;ZX-Z2 " +
            "Словения;Z3-Z5 Литва;Z0-Z6 Россия";
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
            Dictionary<string, string> countries = new Dictionary<string, string>();
            string[] country_codes = countryCodes.Split(';');
            foreach (string code in country_codes)
            {
                char[] sep = { ' ' };
                string[] codeInfo = code.Split(sep, 2);
                if ((codeInfo[0][1] >= 'A' && codeInfo[0][1] <= 'Z') && (codeInfo[0][4] >= '0' && codeInfo[0][4] <= '9'))
                    countries.Add(
                        codeInfo[0][0] + "[" + codeInfo[0][1] + "-Z0-" + codeInfo[0][4] + "]",
                        codeInfo[1]);
                else
                    countries.Add(
                        codeInfo[0][0] + "[" + codeInfo[0][1] + "-" + codeInfo[0][4] + "]",
                        codeInfo[1]);
            }

            List<string> codes = new List<string>();
            foreach (var i in countries)
            {          
                for (int c = Array.IndexOf(alphabet_codes, i.Key.ToArray()[2]); c < Array.IndexOf(alphabet_codes, i.Key.ToArray()[4])-1; c++)
                {
                    codes.Add(i.Key.ToArray()[0].ToString() + alphabet[c]);
                }
            }


            return vin;
        }
                

        public int GetTransportYear(String vin)
        {
            Dictionary<int, char> char_years = new Dictionary<int, char>();
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
