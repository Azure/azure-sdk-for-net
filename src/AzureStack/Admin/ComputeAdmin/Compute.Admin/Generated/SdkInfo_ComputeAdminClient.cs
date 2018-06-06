
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_ComputeAdminClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("Compute.Admin", "Operations", "2015-12-01-preview"),
                new Tuple<string, string, string>("Compute.Admin", "PlatformImages", "2015-12-01-preview"),
                new Tuple<string, string, string>("Compute.Admin", "Quotas", "2015-12-01-preview"),
                new Tuple<string, string, string>("Compute.Admin", "VMExtensions", "2015-12-01-preview"),
            }.AsEnumerable();
        }
    }
}
