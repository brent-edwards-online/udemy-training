namespace MVCDemo.Repository
{
    using Dapper;
    using DNNTeaching.Entities;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;

    public class DataConnector
    {
        public IEnumerable<Employee> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=BRENT-ASUS\SQLEXPRESS;Database=brentedwardsonline;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                return conn.Query<Employee>("SELECT * FROM Employee");
            }
        }

        public bool Add(Employee e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=BRENT-ASUS\SQLEXPRESS;Database=brentedwardsonline;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
                {
                    string sql = "INSERT INTO Employee(FirstName, LastName, Email) values(@FirstName, @LastName, @Email); SELECT CAST(SCOPE_IDENTITY() as int);";
                    var returnId = conn.Query<int>(sql, e).SingleOrDefault();
                    e.Id = returnId;
                }
            }
            catch (System.Exception ex)
            {
                return false;
            }
            return true;
        }


    }
}
