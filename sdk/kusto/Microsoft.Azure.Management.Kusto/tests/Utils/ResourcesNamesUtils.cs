using System;
using System.Collections.Generic;
using System.Text;

namespace Kusto.Tests.Utils
{
    public static class ResourcesNamesUtils
    {
        public static string GetDatabaseChildFullName(string clusterName, string databaseName, string nestedResouceName)
        {
            return $"{clusterName}/{databaseName}/{nestedResouceName}";
        }

        public static string GetAttachedDatabaseConfigurationName(string clusterName, string attachedDatabaseConfigurationName)
        {
            return $"{clusterName}/{attachedDatabaseConfigurationName}";
        }

        public static string GetFullDatabaseName(string clusterName, string databaseName)
        {
            return $"{clusterName}/{databaseName}";
        }
    }
}
