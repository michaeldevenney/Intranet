using System;
using System.Configuration;
using System.Globalization;
using SubSonic;
using System.Text;
using System.Web.SessionState;
using System.Web;


namespace Shared
{    
    public static class Utils
    {
        private delegate T ParseDelegate<T>(string s);

        /// <summary>
        /// Returns True if the passed character is between A-M
        /// </summary>
        /// <param name="inStartingChar">First character of the string being tested</param>
        /// <returns>true if passed character is between A and M</returns>
        public static bool BetweenAandM(string inStartingChar)
        {
            char[] firstChar = inStartingChar.ToLower().ToCharArray();
            char nChar = 'n';
            char testChar = firstChar[0];


            return (testChar < nChar); 
        }

        /// <summary>
        /// This method is used on our external sites to format the first.last type usernames to a readable format
        /// </summary>
        /// <param name="inUserName"></param>
        /// <returns></returns>
        public static string GetFormattedUserNameExternal(string inUserName)
        {
            string tempUser = inUserName;
            tempUser = tempUser.Replace(".", " ");
            TextInfo UsaTextInfo = new CultureInfo("en-US", false).TextInfo;
            tempUser = UsaTextInfo.ToTitleCase(tempUser);
            return tempUser;
        }

        /// <summary>
        /// This method is used on our internal sites to format the domain\first.last type usernames to a readable format
        /// </summary>
        /// <param name="inUserName"></param>
        /// <returns></returns>
        public static string GetFormattedUserNameInternal(string inUserName)
        {
            string tempUser = inUserName;
            tempUser = tempUser.Substring(tempUser.LastIndexOf("\\") + 1);
            tempUser = tempUser.Replace(".", " ");

            TextInfo UsaTextInfo = new CultureInfo("en-US", false).TextInfo;
            tempUser = UsaTextInfo.ToTitleCase(tempUser);

            return tempUser;
        }

        public static decimal NullSafeDecimal(decimal? inbound)
        {
            return inbound == null ? 0m : decimal.Parse(inbound.ToString());
        }

        public static bool? NullSafeBool(string inbound)
        {
            switch (inbound)
            {
                case "0":
                    return false;
                case "1":
                    return true;
                default:
                    return null;
            }
        }

        public static string NullableBoolToRadioButton(bool? inbound)
        {
            switch (inbound)
            {
                case true:
                    return "1";
                case false:
                    return "0";
                default:
                    return null;
            }
        }
         

        public static int? ParseNullableInt(string s)
        {
            return ParseNullable<int>(s, int.Parse);
        }

        public static DateTime? ParseNullableDateTime(string s)
        {
            return ParseNullable<DateTime>(s, DateTime.Parse);
        }

        private static Nullable<T> ParseNullable<T>(string inValue, ParseDelegate<T> parse) where T : struct
        {
            if (string.IsNullOrEmpty(inValue))
            {
                return null;
            }
            else
            {
                return parse(inValue);
            }
        }

        public static int NullSafeInt(int? inbound)
        {
            return inbound == null ? 0 : int.Parse(inbound.ToString());
        }

        public static DateTime NullSafeDate(DateTime? dateTime)
        {
            throw new NotImplementedException();
        }
    }

    public class SessionVar
    {
        static HttpSessionState Session
        {
            get
            {
                if (HttpContext.Current == null)
                    throw new ApplicationException("No Http Context, No Session to Get!");

                return HttpContext.Current.Session;
            }
        }

        public static T Get<T>(string key)
        {
            if (Session[key] == null)
                return default(T);
            else
                return (T)Session[key];
        }

        public static void Set<T>(string key, T value)
        {
            Session[key] = value;
        }
    }
     
  	public static class Folders
  	{
        public static string ExecPath = ConfigurationManager.AppSettings["ExecFolderPath"];
        public static string ProjectsPath = ConfigurationManager.AppSettings["ExecFolderPath"];
        public static string ProspectsPath = ConfigurationManager.AppSettings["ExecFolderPath"];
  	}
}