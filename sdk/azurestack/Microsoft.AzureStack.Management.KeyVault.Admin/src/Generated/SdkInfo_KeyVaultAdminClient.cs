
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_KeyVaultAdminClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("KeyVault.Admin", "Operations", "2017-02-01-preview"),
                new Tuple<string, string, string>("KeyVault.Admin", "Quotas", "2017-02-01-preview"),
            }.AsEnumerable();
        }
    }
}
