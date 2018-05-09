
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_ContainerInstanceManagementClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("ContainerInstance", "ContainerGroupUsage", "2018-04-01"),
                new Tuple<string, string, string>("ContainerInstance", "ContainerGroups", "2018-04-01"),
                new Tuple<string, string, string>("ContainerInstance", "ContainerLogs", "2018-04-01"),
                new Tuple<string, string, string>("ContainerInstance", "Operations", "2018-04-01"),
                new Tuple<string, string, string>("ContainerInstance", "StartContainer", "2018-04-01"),
            }.AsEnumerable();
        }
    }
}
