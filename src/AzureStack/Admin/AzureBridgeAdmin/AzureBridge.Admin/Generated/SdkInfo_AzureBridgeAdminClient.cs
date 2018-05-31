
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_AzureBridgeAdminClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("AzureBridge.Admin", "Activations", "2016-01-01"),
                new Tuple<string, string, string>("AzureBridge.Admin", "DownloadedProducts", "2016-01-01"),
                new Tuple<string, string, string>("AzureBridge.Admin", "Products", "2016-01-01"),
            }.AsEnumerable();
        }
    }
}
