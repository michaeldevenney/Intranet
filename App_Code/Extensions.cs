using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SubSonic;

namespace DAL
{    
    public partial class Project : ActiveRecord<Project>, IActiveRecord
    {
        public string DisplayName
        {
            get { return "(" + ProjectNumber + ") " + ProjectName; }
        }            
    }

    public partial class Report : ActiveRecord<Report>, IActiveRecord
    {
        /// <summary>
        /// Returns a collection of reports with links to SSRS server objects and name for display
        /// </summary>
        /// <param name="reportList">Name of report list to return, use ALL to return all reports.</param>
        /// <returns>ReportCollection</returns>
        public static ReportCollection GetReports(string reportList)
        {
            if (reportList == "ALL")
            {
                return new Select().From<Report>()
                    .Where("Active").IsEqualTo(true)
                    .OrderAsc("ReportName")
                    .ExecuteAsCollection<ReportCollection>();
            }
            else
            {
                return new Select().From<Report>()
                    .Where("List").IsEqualTo(reportList)
                    .And("Active").IsEqualTo(true)
                    .OrderAsc("ReportName")
                    .ExecuteAsCollection<ReportCollection>();
            }
        }
    }

    public partial class Estimate : ActiveRecord<Estimate>, IActiveRecord
    {
        public static EstimateSummaryCollection GetAllEstimates()
        {
            return new Select().From<EstimateSummary>()
                .OrderAsc("Received")
                .ExecuteAsCollection<EstimateSummaryCollection>();
        }

        public static EstimateSummaryCollection GetActiveEstimates()
        {
            return new Select().From<EstimateSummary>()
                .Where("Complete").IsEqualTo(false)
                .OrderAsc("Received")
                .ExecuteAsCollection<EstimateSummaryCollection>();
        }
    }
}