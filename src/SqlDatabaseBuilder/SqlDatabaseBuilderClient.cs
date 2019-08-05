using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDatabaseBuilder
{
    public class SqlDatabaseBuilderClient
    {
        private readonly SqlConnection _sqlConnection;
        private SqlCommand _sqlCommand;
        private StringBuilder _sqlCommandBuilder;

        public SqlDatabaseBuilderClient(string dbConnectionString)
        {
            _sqlConnection = new SqlConnection(dbConnectionString);
            _sqlCommand = new SqlCommand
            {
                Connection = _sqlConnection
            };
            _sqlCommandBuilder = new StringBuilder();
        }

        /// <summary>
        /// Create table with represented columns        
        /// </summary>
        /// <param name="tableName">Name of table</param>
        /// <param name="columns">List of sql columns</param>
        public async Task CreateTableAsync(string tableName, ICollection<SqlColumn> columns)
        {         
            if (columns.Count == 0)
            {
                columns.Add(new SqlColumn("Id", new SqlDataType(SqlStandartDataType.INT))
                {
                    IsPrimaryKey = true
                });
            }
            var uniqueColumns = new HashSet<SqlColumn>(columns, new SqlColumnEquality());

            _sqlCommandBuilder.Append($"CREATE TABLE {tableName} (");

            foreach (var column in uniqueColumns)
            {               
                if (column.IsPrimaryKey)
                {
                    _sqlCommandBuilder.Append($"{column.Name} {column.DataType.Name} {column.DefaultValue} PRIMARY KEY, ");
                }
                else
                {
                    _sqlCommandBuilder.Append($"{column.Name} {column.DataType.Name} {column.DefaultValue}, ");
                }
            }
            _sqlCommandBuilder.Append(");");

            await _sqlConnection.OpenAsync();
            _sqlCommand.CommandText = _sqlCommandBuilder.ToString();
            await _sqlCommand.ExecuteNonQueryAsync();
            _sqlConnection.Close();
        }
    }
}
