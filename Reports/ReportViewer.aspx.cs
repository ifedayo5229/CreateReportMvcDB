using CreateReportMvcDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CreateReportMvcDB.Reports
{
    public partial class ReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if (!IsPostBack)
            {
                List<CustomerDto> Data = new List<CustomerDto>();
                DALcustomer _CustomerDAL = new DALcustomer();
                Data = _CustomerDAL.GetAllCustomers();


                this.ReportViewer1.LocalReport.ReportPath =Server.MapPath ("CustomerReport.rdlc");
                this.ReportViewer1.LocalReport.DataSources.Clear();
                this.ReportViewer1.LocalReport.DataSources.Add
                (new Microsoft.Reporting.WebForms.ReportDataSource("dsData",Data));
            } 
        }
    }
}