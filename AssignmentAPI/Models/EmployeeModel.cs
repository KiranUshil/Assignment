using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentAPI.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public short Age { get; set; }
        [Required]
        public double Salary { get; set; }


        public bool add_employee(EmployeeModel employee) {
            bool bAdded = false;
            short result = 0;
            string sResult = string.Empty;
            short rowAffected = 0;
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Parameters.Add("@name", System.Data.SqlDbType.VarChar).SqlValue = employee.Name;
                sqlCommand.Parameters.Add("@salary", System.Data.SqlDbType.Float).SqlValue = employee.Salary;
                sqlCommand.Parameters.Add("@age", System.Data.SqlDbType.SmallInt).SqlValue = employee.Age;

                sqlCommand.CommandText = "sp_addemp";
                DbModel.DbConnection dbConnection = new DbModel.DbConnection();
               rowAffected = dbConnection.SqlNonQueryExecutorWithCommand(sqlCommand, ref result,ref sResult);
                if(rowAffected >0)
                {
                    bAdded = true;
                }
            }
            catch (Exception exc)
            { 

            }
            return bAdded;
        }

        public bool update_employee(EmployeeModel employee)
        {
            bool bUpdated = false;
            short result = 0;
            string sResult = string.Empty;
            short rowAffected = 0;
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Parameters.Add("@name", System.Data.SqlDbType.VarChar).SqlValue = employee.Name;
                sqlCommand.Parameters.Add("@salary", System.Data.SqlDbType.Float).SqlValue = employee.Salary;
                sqlCommand.Parameters.Add("@age", System.Data.SqlDbType.SmallInt).SqlValue = employee.Age;
                sqlCommand.Parameters.Add("@id", System.Data.SqlDbType.Int).SqlValue = employee.Id;

                sqlCommand.CommandText = "sp_updateemployee";
                DbModel.DbConnection dbConnection = new DbModel.DbConnection();
                rowAffected = dbConnection.SqlNonQueryExecutorWithCommand(sqlCommand, ref result, ref sResult);
                if (rowAffected > 0)
                {
                    bUpdated = true;
                }
            }
            catch (Exception exc)
            {

            }
            return bUpdated;
        }

        public bool delete_employee(int id)
        {
            bool bDeleted = false;
            short result = 0;
            string sResult = string.Empty;
            short rowAffected = 0;
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                

                sqlCommand.CommandText = "sp_deletemployee";
                DbModel.DbConnection dbConnection = new DbModel.DbConnection();
                rowAffected = dbConnection.SqlNonQueryExecutorWithCommand(sqlCommand, ref result, ref sResult);
                if (rowAffected > 0)
                {
                    bDeleted = true;
                }
            }
            catch (Exception exc)
            {

            }
            return bDeleted;
        }

        public List<EmployeeModel> get_all()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                short result = 0;
                string sResult = string.Empty;
                sqlCommand.CommandText = "sp_getallemp";
                System.Data.DataTable dataTable = new DataTable();
                DbModel.DbConnection dbConnection = new DbModel.DbConnection();
                dataTable = dbConnection.SqlQueryExecutorWithCommand(sqlCommand, ref result, ref sResult);
                if(dataTable != null && dataTable.Rows.Count > 0)
                {
                    foreach(DataRow dr in dataTable.Rows)
                    {
                        EmployeeModel employee = new EmployeeModel();
                        employee.Name = dr["emp_name"].ToString();
                        employee.Age = Convert.ToInt16(dr["age"]);
                        employee.Salary = Convert.ToDouble(dr["salary"]);
                        employee.Id = Convert.ToInt32(dr["emp_id"]);
                        employees.Add(employee);
                    }
                }
            }
            catch
            {

            }
            finally
            {

            }
            return employees;
        }


        public EmployeeModel get_emp(int id)
        {
            EmployeeModel employee = new EmployeeModel();
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Parameters.Add("@id", SqlDbType.Int).SqlValue = id;
                short result = 0;
                string sResult = string.Empty;
                sqlCommand.CommandText = "sp_get_emp";
                System.Data.DataTable dataTable = new DataTable();
                DbModel.DbConnection dbConnection = new DbModel.DbConnection();
                dataTable = dbConnection.SqlQueryExecutorWithCommand(sqlCommand, ref result, ref sResult);
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    
                        employee.Name = dataTable.Rows[0]["emp_name"].ToString();
                        employee.Age = Convert.ToInt16(dataTable.Rows[0]["age"]);
                        employee.Salary = Convert.ToDouble(dataTable.Rows[0]["salary"]);
                        employee.Id = Convert.ToInt32(dataTable.Rows[0]["emp_id"]);
                    
                }
            }
            catch
            {

            }
            finally
            {

            }
            return employee;
        }

    }
}
