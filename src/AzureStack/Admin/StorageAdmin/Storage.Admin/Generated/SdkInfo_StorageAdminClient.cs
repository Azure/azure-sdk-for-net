
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_StorageAdminClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("Storage.Admin", "Acquisitions", "2015-12-01-preview"),
                new Tuple<string, string, string>("Storage.Admin", "BlobServices", "2015-12-01-preview"),
                new Tuple<string, string, string>("Storage.Admin", "Containers", "2015-12-01-preview"),
                new Tuple<string, string, string>("Storage.Admin", "Farms", "2015-12-01-preview"),
                new Tuple<string, string, string>("Storage.Admin", "Operations", "2015-12-01-preview"),
                new Tuple<string, string, string>("Storage.Admin", "QueueServices", "2015-12-01-preview"),
                new Tuple<string, string, string>("Storage.Admin", "Shares", "2015-12-01-preview"),
                new Tuple<string, string, string>("Storage.Admin", "StorageAccounts", "2015-12-01-preview"),
                new Tuple<string, string, string>("Storage.Admin", "StorageQuotas", "2015-12-01-preview"),
                new Tuple<string, string, string>("Storage.Admin", "TableServices", "2015-12-01-preview"),
            }.AsEnumerable();
        }
    }
}
