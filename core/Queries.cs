namespace DEGNETCORE.core
{
    public class Queries
    {
        public static string ListAllTables => "SHOW FULL TABLES;";
        public static string ListTableProperties (string tableName) => $"DESCRIBE {tableName};";
    }
}