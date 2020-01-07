

namespace DaniaDaisy.DataAccess.Common
{
    public enum DataAccessLoggerType
    {
        File,
        Database,
        EventLog,
        AzureTable,
        Console,
    }
    public enum DataAccessOperation
    {
        Add,
        Delete,
        Update,
        Get,
    }

}
