
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_FabricAdminClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("Fabric.Admin", "EdgeGatewayPools", "2016-05-01"),
                new Tuple<string, string, string>("Fabric.Admin", "EdgeGateways", "2016-05-01"),
                new Tuple<string, string, string>("Fabric.Admin", "Fabric", "2016-05-01"),
                new Tuple<string, string, string>("Fabric.Admin", "FabricLocations", "2016-05-01"),
                new Tuple<string, string, string>("Fabric.Admin", "FileShares", "2016-05-01"),
                new Tuple<string, string, string>("Fabric.Admin", "InfraRoleInstances", "2016-05-01"),
                new Tuple<string, string, string>("Fabric.Admin", "InfraRoles", "2016-05-01"),
                new Tuple<string, string, string>("Fabric.Admin", "IpPools", "2016-05-01"),
                new Tuple<string, string, string>("Fabric.Admin", "LogicalNetworks", "2016-05-01"),
                new Tuple<string, string, string>("Fabric.Admin", "LogicalSubnets", "2016-05-01"),
                new Tuple<string, string, string>("Fabric.Admin", "MacAddressPools", "2016-05-01"),
                new Tuple<string, string, string>("Fabric.Admin", "ScaleUnitNodes", "2016-05-01"),
                new Tuple<string, string, string>("Fabric.Admin", "ScaleUnits", "2016-05-01"),
                new Tuple<string, string, string>("Fabric.Admin", "SlbMuxInstances", "2016-05-01"),
                new Tuple<string, string, string>("Fabric.Admin", "StoragePools", "2016-05-01"),
                new Tuple<string, string, string>("Fabric.Admin", "StorageSystems", "2016-05-01"),
                new Tuple<string, string, string>("Fabric.Admin", "Volumes", "2016-05-01"),
            }.AsEnumerable();
        }
    }
}
