
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
                new Tuple<string, string, string>("Storage", "BlobContainers", "2017-10-01"),
                new Tuple<string, string, string>("Storage", "Operations", "2017-10-01"),
                new Tuple<string, string, string>("Storage", "Skus", "2017-10-01"),
                new Tuple<string, string, string>("Storage", "StorageAccounts", "2017-10-01"),
                new Tuple<string, string, string>("Storage", "Usage", "2017-10-01"),
            }.AsEnumerable();
        }
    }
}
