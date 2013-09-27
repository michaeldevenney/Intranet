using System;
using System.Globalization;
using SubSonic;
using System.Text;
using DAL;

namespace Shared
{
    /// <summary>
    /// Veritas specific methods for data access and utility functions like GetFormattedUserName, etc...
    /// </summary>
    public static class Data
    {
        public enum ProjectStatus { Active, Archived, Tentative }
        public enum UserStatus { Active, Terminated }

        #region ADDRESSES
        
        /// <summary>
        /// probably dumb that I wrote this since it's only one line of code... but here's your address.
        /// </summary>
        /// <param name="ID">Address ID</param>
        /// <returns>Strongly typed Address</returns>
        public static Address GetAddressByID(int? ID)
        {
            return new Address(ID);
        }
        
        /// <summary>
        /// Used for displaying a full address summarized on one line
        /// </summary>
        /// <param name="ID">Address ID</param>
        /// <returns>One line summary of the Address ID passed in</returns>
        public static string GetAddressSummaryOneLine(string ID)
        {
            // if passed an empty string return empty string
            if (ID == string.Empty) 
                return ID;

            int? addrID = int.Parse(ID);
            Address temp = new Address(addrID);
            StringBuilder summary = new StringBuilder();
            summary.Append(temp.Line1 + " - ");
            summary.Append(temp.Line2 + " - ");
            summary.Append(temp.Line3 + " - ");
            summary.Append(temp.Line4 + " - ");
            summary.Append(temp.Line5);

            return summary.ToString();
        }
        
        /// <summary>
        /// Used for displaying a full address in block format
        /// </summary>
        /// <param name="ID">Address ID</param>
        /// <returns>5 line summary of the Address ID passed in</returns>
        public static string GetAddressSummaryBlock(string ID)
        {
            // if passed an empty string return empty string
            if (ID == string.Empty)
                return ID;

            int? addrID = int.Parse(ID);
            Address temp = new Address(addrID);
            StringBuilder summary = new StringBuilder();
            summary.Append(temp.Line1 + "\r\n");
            summary.Append(temp.Line2 + "\r\n");
            summary.Append(temp.Line3 + "\r\n");
            summary.Append(temp.Line4 + "\r\n");
            summary.Append(temp.Line5);

            return summary.ToString();
        }

        #endregion 

        #region PROJECTS

        public static UserProjectCollection GetAssignedProjects(string inUserName)
        {
            return new UserProjectCollection().Where("UserName", Comparison.Equals, inUserName).Load();
        }

        public static ProjectWallHeightCollection GetProjectWalls(int inProjectID)
        {
            return new ProjectWallHeightCollection().Where("ProjectID", Comparison.Equals, inProjectID).Load();
        }

        public static ProjectCollection GetProjectsByStatus(ProjectStatus inStatus)
        {               
            return new Select().From<Project>()
                .Where("ProjectActivity").IsEqualTo(inStatus.ToString())
                .And("ProjectLead").IsEqualTo("Project")
                .And("ProjectNumber").IsNotEqualTo("_Archi")
                .OrderAsc("ProjectNumber")                
                .ExecuteAsCollection<ProjectCollection>();
        }

        public static ProjectCollection GetLeadsByStatus(ProjectStatus inStatus)
        {
            return new Select().From<Project>()
                .Where("ProjectActivity").IsEqualTo(inStatus)
                .And("ProjectLead").IsEqualTo("Lead")
                .OrderAsc("ProjectNumber")       
                .ExecuteAsCollection<ProjectCollection>();
        }

        public static ProjectCollection GetAllProjects()
        {
            return new Select().From<Project>()
                .Where("ProjectLead").IsEqualTo("Project")
                .OrderAsc("ProjectNumber")       
                .ExecuteAsCollection<ProjectCollection>();
        }

        public static ProjectCollection GetAllLeads()
        {
            return new Select().From<Project>()
                .Where("ProjectLead").IsEqualTo("Lead")
                .OrderAsc("ProjectNumber")       
                .ExecuteAsCollection<ProjectCollection>();
        }
               
        public static Project GetProjectByID(int inProjectID)
        {
            return new Project(inProjectID);
        }

        #endregion

        #region TAKEOFFs

        //public static TakeoffCollection GetProjectTakeoffs(int inProjectID)
        //{
        //    return new TakeoffCollection().Where("ProjectID", Comparison.Equals, inProjectID).Load();
        //}

        #endregion

        #region PROSPECTS

        public static ProspectCollection GetProspects()
        {
            return new ProspectCollection();
        }

        #endregion

        #region ROOMS / SURVEY POINTS

        public static Room GetRoomByID(string roomID)
        {
            return new Room(roomID);
        }

        public static RoomSurveyPoint GetSurveyPointByID(string surveyPointID)
        {
            return new RoomSurveyPoint(surveyPointID);
        }

        #endregion

        #region RFI

        public static Rfi GetRFIByID(string inRFI)
        {
            int RFI;

            if (int.TryParse(inRFI, out RFI))
            {
                return new Rfi(RFI);
            }
            else
            {
                throw new Exception("RFI ID passed to GetRFIByID function wasn't in the correct format.  Passed value: " + inRFI);
            }
        }

        #endregion

        #region LOOKUP LISTS

        public static LookupCollection GetLookupList(string inListName)
        {
            return new LookupCollection().Where("LookupList", Comparison.Equals, inListName).Load();
        }
               
        #endregion

        #region USERS

        public static UserCollection GetUsersByTitle(string inTitle)
        {
            return new Select().From<User>()
                .Where("Position").IsEqualTo(inTitle)
                .And("Status").IsEqualTo("Active")
                .OrderAsc("Name")
                .ExecuteAsCollection<UserCollection>();
        }

        /// <summary>
        /// Returns the ID value from the users table when supplied with a username in domain\username format
        /// </summary>
        /// <param name="inUsername">users login in domain\username format</param>
        /// <returns>ID for the User record (int)</returns>
        public static int? GetUserIDFromLogin(string inUsername)
        {
            string userLogin = inUsername.Substring(inUsername.IndexOf("\\") + 1);
            User u = new Select().From<User>().Where("Username").IsEqualTo(userLogin).ExecuteSingle<User>();
            return u.Id;
        }

        /// <summary>
        /// Returns a user object when supplied with a username in domain\username format
        /// </summary>
        /// <param name="inUsername">User's login in domain\username format</param>
        /// <returns>User object</returns>
        public static User GetUserFromLogin(string inUsername)
        {
            string userLogin = inUsername.Substring(inUsername.IndexOf("\\") + 1);
            return new Select().From<User>().Where("Username").IsEqualTo(userLogin).ExecuteSingle<User>();

        }

        public static User GetUserByID(int p)
        {
            return new User(p);
        }

        public static UserCollection GetUsersByStatus(UserStatus inStatus)
        {
            return new Select().From<User>()
                 .Where("Status").IsEqualTo(inStatus)
                 .ExecuteAsCollection<UserCollection>();
        }

        #endregion       
    }

    public static class Utils
    {
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
    }
       	
}