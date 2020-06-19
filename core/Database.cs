using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using DEGNETCORE.core.models;
using MySql.Data.MySqlClient;

namespace DEGNETCORE.core
{
    public class Database
    {
        private string ConnectionString { get; set; }

        public Database(string connectionString) {
            this.ConnectionString = connectionString;

            this.TestConnection();
        }

        private IDbConnection Connection
        {
            get
            {
                var connection = new MySqlConnection(this.ConnectionString);
                connection.Open();
                
                return connection;
            }
        }
    
        private void TestConnection() {
            try {
                using (IDbConnection conn = Connection)
                {
                    conn.Close();
                }
            }
            catch(Exception e) {
                var errorMessage = $"DEG EXCEPTION: Invalid connection string {this.ConnectionString}, you must provide a valid connection string";
                Console.WriteLine(errorMessage);
                throw new Exception(errorMessage);
            }
        }

        /*
        * This will go trought the database and get all the table structure
        */
        public List<DEGTable> GetStructure() 
        {
            List<DEGTable> tables = new List<DEGTable>();
            
            using (IDbConnection conn = Connection)
            {
                var dataReader = conn.ExecuteReader(Queries.ListAllTables);

                using(var reader = dataReader) {

                    while (reader.Read())
                    {
                       var name = reader[0].ToString();
                       var type = reader[1].ToString();

                       if(type != "VIEW") {
                            var table = new DEGTable(name);
                            
                            tables.Add(table);
                       }
                    }
                }

                // Ge table properties
                foreach (DEGTable table in tables)
                {
                    dataReader = conn.ExecuteReader(
                        Queries.ListTableProperties(table.Name)
                    );

                    using(var reader = dataReader) {

                        while (reader.Read())
                        {
                            var property = reader[0].ToString();
                            var key = reader[3].ToString();

                            // Only add property if it isn´t a Foreign Key or 
                            // a Primary Key
                            if(String.IsNullOrEmpty(key)) {
                               table.AddProperty(property);
                            }
                        }
                    }
                }

                conn.Close();
            }

            return tables;
        }

    }
}