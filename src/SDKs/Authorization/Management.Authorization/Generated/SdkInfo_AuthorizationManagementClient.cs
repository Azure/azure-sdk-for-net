
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_AuthorizationManagementClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("Authorization", "ClassicAdministrators", "2015-06-01"),
                new Tuple<string, string, string>("Authorization", "Permissions", "2018-01-01-preview"),
                new Tuple<string, string, string>("Authorization", "ProviderOperationsMetadata", "2018-01-01-preview"),
                new Tuple<string, string, string>("Authorization", "RoleAssignments", "2018-01-01-preview"),
                new Tuple<string, string, string>("Authorization", "RoleDefinitions", "2018-01-01-preview"),
                new Tuple<string, string, string>("AuthorizationManagementClient", "RoleAssignments", "2018-01-01-preview"),
                new Tuple<string, string, string>("AuthorizationManagementClient", "RoleDefinitions", "2018-01-01-preview"),
            }.AsEnumerable();
        }
    }
}
