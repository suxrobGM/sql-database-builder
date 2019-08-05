using System;
using System.Collections.Generic;
using System.Text;

namespace SqlDatabaseBuilder
{
    public class SqlColumn
    {
        public SqlColumn(string columnName, SqlDataType dataType)
        {
            Name = columnName;
            DataType = dataType;
        }

        public string Name { get; set; }
        public SqlDataType DataType { get; set; }
        public string DefaultValue { get; set; }
        public bool IsPrimaryKey { get; set; }
    }

    internal class SqlColumnEquality : IEqualityComparer<SqlColumn>
    {
        public bool Equals(SqlColumn column1, SqlColumn column2)
        {
            return column1.Name == column2.Name;
        }

        public int GetHashCode(SqlColumn column)
        {
            return column.Name.ToLower().GetHashCode();
        }
    }
}
