using System;
using System.Collections.Generic;
using SqlDatabaseBuilder;

namespace Test
{
    class Program
    {
        static readonly string connectionString = "Server=(localdb)\\mssqllocaldb;Database=Test;Trusted_Connection=True;MultipleActiveResultSets=true";

        static void Main(string[] args)
        {
            var builder = new SqlDatabaseBuilderClient(connectionString);

            var columns = new List<SqlColumn>
            {
                new SqlColumn("Id", new SqlDataType(SqlStandartDataType.INT))
                { 
                    IsPrimaryKey = true
                },
                new SqlColumn("TestColumn1", new SqlDataType("NVARCHAR(20)")),
                new SqlColumn("TestColumn2", new SqlDataType("NVARCHAR(40)"))
            };

            builder.CreateTableAsync("TestTable", columns).Wait();

            Console.WriteLine("\nFinished!");
            Console.ReadLine();
        }
    }
}
