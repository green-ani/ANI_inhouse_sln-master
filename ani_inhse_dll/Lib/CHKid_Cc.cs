using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ani_inhse.Lib
{
    public class CHKid_Cc
    {
        public string InputIdNr = "";
        public string AcctNr = "";
        public char CalCheckSum = ' ';
        public string FormatID = "";
        private string codeword = "8723549016872354901687235490168723549016";

        public bool FormatOk = false;
        public bool CheckSumOk = false;
        public bool hasSymbol = false;


        //***********************************************************************************************//

        public CHKid_Cc(string idnr)
        {
            InputIdNr = idnr;

            FormatID = format_id(idnr);


            if (FormatOk == true)
            {
                CalCheckSum = idcheckdiigt(FormatID);
            }

            if (CheckSumOk == true)
            {
                AcctNr = acct_nr(FormatID);
            }


        }

        //***********************************************************************************************//






        //***********************************************************************************************//



        //***********************************************************************************************//

        private string digit_char_string(string formatidnr)
        {
            char[] idchars = new char[9];
            char[] xidchars = new char[9];
            int xx = formatidnr.Length;



            idchars[1] = codeword[(Convert.ToInt16(formatidnr[xx - 8]) / 10)];
            idchars[8] = codeword[(Convert.ToInt16(formatidnr[xx - 8]) % 10)];

            for (int ii = 7; ii >= 2; ii--)
            {
                idchars[ii] = codeword[(Convert.ToInt16(formatidnr[ii]) - 48)];
            }

            for (int ii = 1; ii <= 4; ii++)
            {
                xidchars[ii * 2] = idchars[ii * 2 - 1];
                xidchars[ii * 2 - 1] = idchars[ii * 2];
            }

            string yy = string.Join("", xidchars);
            return yy;
        }


        //***********************************************************************************************//




        //***********************************************************************************************//
        private char idcheckdiigt(string thisidnumber)
        {
            char[] idchars = thisidnumber.ToCharArray();
            char[] xidchars = new char[8];

            int[] digitsum = new int[8];
            int thesum = 0;
            int startpoint = 1;
            if (thisidnumber.Length == 8)
            {
                xidchars[0] = (char)91;
            }
            else
            {
                startpoint = 0;
            }


            Array.Copy(idchars, 0, xidchars, startpoint, thisidnumber.Length - 1);





            for (int jj = 0; jj <= 1; jj++)
            {
                thesum = thesum + (xidchars[jj] - 55) * (9 - jj);
            }

            for (int jj = 2; jj <= 7; jj++)
            {
                thesum = thesum + (xidchars[jj] - 48) * (9 - jj);
            }


            thesum = 11 - thesum % 11;

            char calcheckdigit = checksumchar(thesum);
            if (thisidnumber[thisidnumber.Length - 1].Equals(calcheckdigit) == true)
            {
                CheckSumOk = true;

            }

            return calcheckdigit;


        }


        //***********************************************************************************************//
        private char checksumchar(int thisint)
        {
            if (thisint < 10)
            {
                string str = thisint.ToString();
                return str[0];
            }

            if (thisint == 10)
            {

                return 'A';
            }

            else
            {

                return '0';
            }

        }


        //***********************************************************************************************//



        //***********************************************************************************************//



        //***********************************************************************************************//



        //***********************************************************************************************//
        private string acct_nr(string formathkidnr)
        {
            string acctnr = digit_char_string(formathkidnr);

            StringBuilder sb = new StringBuilder(acctnr);
            char char9 = '9';
            char charx = '8';
            switch (formathkidnr.Length)
            {
                case 8:
                    sb[0] = char9;
                    break;
                case 9:
                    sb[0] = charx;
                    break;
            }

            return sb.ToString();
        }


        //***********************************************************************************************//
        private string format_id(string thisidstring)
        {

            char[] ca = thisidstring.ToCharArray();
            for (int ii = 0; ii <= thisidstring.Length - 1; ii++)
            {
                if (char.IsLetterOrDigit(ca[ii]) == false)
                {
                    ca[ii] = ' ';
                    hasSymbol = true;
                }
            }

            string kk = string.Join("", ca);
            kk = kk.Replace(" ", string.Empty);

            if (check_length_of_format_id_nr(kk, 9, 8) != true)
            {
                return "Incorrect Length";
            }

            if (check_parts_of_format_id_nr(kk) != true || hasSymbol)
            {
                return "Incorrect Format";
            }

            FormatOk = true;


            string upperkk = kk.ToUpper();
            return upperkk;

        }

        //***********************************************************************************************//
        private bool check_length_of_format_id_nr(string thisidnrstring, int thismax, int thismin)
        {

            if (thisidnrstring.Length > thismax || thisidnrstring.Length < thismin)
            {
                return false;
            }

            return true;

        }

        //***********************************************************************************************//

        private bool check_parts_of_format_id_nr(string thisidnrstring)
        {

            int mm = thisidnrstring.Length;
            for (int kk = (mm - 2); kk <= (mm - 7); kk--)
            {
                if (char.IsDigit(thisidnrstring[kk]) != true)
                    return false;
            }


            int ll = mm - 8;

            do
            {
                if (char.IsLetter(thisidnrstring[ll]) != true)
                    return false;
                ll--;
            }
            while (ll > 0);

            return true;
        }

    }
}
