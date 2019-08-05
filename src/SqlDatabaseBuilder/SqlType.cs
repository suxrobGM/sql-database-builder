namespace SqlDatabaseBuilder
{
    public enum SqlStandartDataType
    {
        INT,
        SMALLINT,
        BIGINT,
        DECIMAL,
        NUMERIC,
        FLOAT,
        REAL,
        VARCHAR,
        CHAR,
        TEXT,
        BOOLEAN,
        BINARY,
        VARBINARY,
        BLOB,
        DATE,
        TIME,
    }

    public class SqlDataType
    {
        public SqlDataType(SqlStandartDataType sqlStandartDataType)
        {
            Name = sqlStandartDataType.ToString();
        }

        public SqlDataType(string SqlDataType)
        {
            Name = SqlDataType;
        }

        public string Name { get; set; }
    }
}