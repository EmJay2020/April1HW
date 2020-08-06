using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MyLibrary
{
    public class DB
    {
        private string _connection;
        public DB(string cs)
        {
            _connection = cs;
        }
        public List<People> GetPeoples()
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            using (SqlCommand cmd = connection.CreateCommand())
            {
                cmd.CommandText = @"select * from Persons";
                connection.Open();
                List<People> result = new List<People>();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new People
                    {
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        Age = (int)reader["Age"]
                    });
                }
                return result;
            }

        }
        public void AddPeople(List<People> p)
        {
            foreach (People y in p)
            {
                using (SqlConnection connection = new SqlConnection(_connection))

                using (SqlCommand cmd = connection.CreateCommand())
                {

                    cmd.CommandText = @"insert into persons(FirstName, LastName, Age)
                                        Values(@firstname, @lastname, @age)";
                    cmd.Parameters.AddWithValue("@firstname", y.FirstName);
                    cmd.Parameters.AddWithValue("@lastname", y.LastName);
                    cmd.Parameters.AddWithValue("@age", y.Age);


                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
