using PMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PMS.DAL
{
    public class PersonRepository
    {
        public int AddPerson(Person person) {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PMSConnection"].ConnectionString))
            {
                connection.Open();
                string sql = "INSERT INTO [dbo].[tblPerson] ([PersonNumber],[Name],[Surname],[EnterDate],[Address],[SalaryRate],[TotalWorkTime])" +
                    "VALUES(@P_PersonNumber,@P_Name,@P_Surname,@P_EnterDate,@P_Address,@P_SalaryRate,@P_TotalWorkTime)";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.Add("@P_PersonNumber", SqlDbType.Int).Value = person.PersonNumber;
                    cmd.Parameters.Add("@P_Name", SqlDbType.VarChar, 50).Value = person.Name;
                    cmd.Parameters.Add("@P_Surname", SqlDbType.VarChar, 50).Value = person.Surname;
                    cmd.Parameters.Add("@P_EnterDate", SqlDbType.DateTime2, 50).Value = person.EnterDate; ;
                    cmd.Parameters.Add("@P_Address", SqlDbType.VarChar, 50).Value = person.Address; ;
                    cmd.Parameters.Add("@P_SalaryRate", SqlDbType.Float, 50).Value = person.SalaryRate; ;
                    cmd.Parameters.Add("@P_TotalWorkTime", SqlDbType.Int, 50).Value = person.TotalWorkTime; ;
                    cmd.CommandType = CommandType.Text;
                    return cmd.ExecuteNonQuery();
                }
            }
            return 0;
        }
        public Person findPersonByNumber(int personNumber) {

            Person person = null;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PMSConnection"].ConnectionString))
            {
                connection.Open();
                string sql = " select [Id]  ,[PersonNumber],[Name],[Surname] ,[EnterDate],[Address],[SalaryRate],[TotalWorkTime]  FROM [PMSDB].[dbo].[tblPerson] p where p.PersonNumber=@P_PersonNumber";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@P_PersonNumber", personNumber);
                // int result = command.ExecuteNonQuery();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        person = new Person();
                        person.Id =int.Parse( reader["Id"].ToString());
                        person.PersonNumber = int.Parse(reader["PersonNumber"].ToString());
                        person.Name =reader["Name"].ToString();
                        person.Name = reader["Surname"].ToString();
                        person.EnterDate =DateTime.Parse( reader["EnterDate"].ToString());
                        person.Address = reader["Address"].ToString();
                        person.SalaryRate = float.Parse(reader["SalaryRate"].ToString());
                        person.TotalWorkTime = int.Parse(reader["TotalWorkTime"].ToString());
                        return person;
                    }
                }

            }
            return person;
        }
    }
}
