
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_DataMigrationManagementClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("DataMigration", "Operations", "2018-03-31-preview"),
                new Tuple<string, string, string>("DataMigration", "Projects", "2018-03-31-preview"),
                new Tuple<string, string, string>("DataMigration", "ResourceSkus", "2018-03-31-preview"),
                new Tuple<string, string, string>("DataMigration", "Services", "2018-03-31-preview"),
                new Tuple<string, string, string>("DataMigration", "Tasks", "2018-03-31-preview"),
                new Tuple<string, string, string>("DataMigration", "Usages", "2018-03-31-preview"),
            }.AsEnumerable();
        }
    }
}
