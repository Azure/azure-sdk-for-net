
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_ResourceManagementClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("ResourceManagementClient", "DeploymentOperations", "2017-05-10"),
                new Tuple<string, string, string>("ResourceManagementClient", "Providers", "2017-05-10"),
                new Tuple<string, string, string>("ResourceManagementClient", "ResourceGroups", "2017-05-10"),
                new Tuple<string, string, string>("ResourceManagementClient", "Resources", "2017-05-10"),
                new Tuple<string, string, string>("ResourceManagementClient", "Tags", "2017-05-10"),
                new Tuple<string, string, string>("Resources", "Deployments", "2017-05-10"),
            }.AsEnumerable();
        }
    }
}
