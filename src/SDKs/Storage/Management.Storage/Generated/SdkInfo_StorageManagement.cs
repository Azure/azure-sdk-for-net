
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_StorageManagement
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("Storage", "Operations", "2018-03-01-preview"),
                new Tuple<string, string, string>("Storage", "Skus", "2018-03-01-preview"),
                new Tuple<string, string, string>("Storage", "StorageAccounts", "2018-03-01-preview"),
                new Tuple<string, string, string>("Storage", "Usage", "2018-03-01-preview"),
            }.AsEnumerable();
        }
    }
}
