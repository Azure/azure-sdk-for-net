
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_StorageManagementClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("Storage", "BlobContainers", "2018-02-01"),
                new Tuple<string, string, string>("Storage", "Operations", "2018-02-01"),
                new Tuple<string, string, string>("Storage", "Skus", "2018-02-01"),
                new Tuple<string, string, string>("Storage", "StorageAccounts", "2018-02-01"),
                new Tuple<string, string, string>("Storage", "Usage", "2018-02-01"),
            }.AsEnumerable();
        }
    }
}
