using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using CreateReportMvcDB.Models;
using System.Data;
using System.Windows.Documents;

namespace CreateReportMvcDB
{
    public class DALcustomer
    {
        public List<CustomerDto>GetAllCustomers()
        {
            string cnnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnString);
            cnn.Open();


            SqlCommand command = new SqlCommand("stpGetAllCustomers", cnn);
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            List<CustomerDto> Data = new List<CustomerDto>();

            while (reader.Read())
            {
                Data.Add(new CustomerDto()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    Phone = reader["Phone"].ToString(),
                    Email = reader["Email"].ToString(),


                });

                


            }

            return Data;
        }
    }
}