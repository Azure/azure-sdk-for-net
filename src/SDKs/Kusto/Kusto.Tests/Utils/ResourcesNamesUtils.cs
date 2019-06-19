using System;
using System.Collections.Generic;
using System.Text;

namespace Kusto.Tests.Utils
{
    public static class ResourcesNamesUtils
    {
        public static string GetFullEventHubName(string clusterName, string databaseName, string eventhubConnectionName)
        {
            return $"{clusterName}/{databaseName}/{eventhubConnectionName}";
        }

        public static string GetFullDatabaseName(string clusterName, string databaseName)
        {
            return $"{clusterName}/{databaseName}";
        }
    }
}
