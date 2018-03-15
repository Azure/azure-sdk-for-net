
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_KeyVaultManagementClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("KeyVault", "Operations", "2018-02-14-preview"),
                new Tuple<string, string, string>("KeyVault", "Vaults", "2018-02-14-preview"),
                new Tuple<string, string, string>("KeyVaultManagementClient", "Vaults", "2018-02-14-preview"),
            }.AsEnumerable();
        }
    }
}
