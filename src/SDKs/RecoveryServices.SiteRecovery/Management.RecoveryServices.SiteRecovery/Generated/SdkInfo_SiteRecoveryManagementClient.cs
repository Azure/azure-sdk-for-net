
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_SiteRecoveryManagementClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("RecoveryServices", "Operations", "2016-08-10"),
                new Tuple<string, string, string>("RecoveryServices", "RecoveryPoints", "2016-08-10"),
                new Tuple<string, string, string>("RecoveryServices", "ReplicationAlertSettings", "2016-08-10"),
                new Tuple<string, string, string>("RecoveryServices", "ReplicationEvents", "2016-08-10"),
                new Tuple<string, string, string>("RecoveryServices", "ReplicationFabrics", "2016-08-10"),
                new Tuple<string, string, string>("RecoveryServices", "ReplicationJobs", "2016-08-10"),
                new Tuple<string, string, string>("RecoveryServices", "ReplicationLogicalNetworks", "2016-08-10"),
                new Tuple<string, string, string>("RecoveryServices", "ReplicationNetworkMappings", "2016-08-10"),
                new Tuple<string, string, string>("RecoveryServices", "ReplicationNetworks", "2016-08-10"),
                new Tuple<string, string, string>("RecoveryServices", "ReplicationPolicies", "2016-08-10"),
                new Tuple<string, string, string>("RecoveryServices", "ReplicationProtectableItems", "2016-08-10"),
                new Tuple<string, string, string>("RecoveryServices", "ReplicationProtectedItems", "2016-08-10"),
                new Tuple<string, string, string>("RecoveryServices", "ReplicationProtectionContainerMappings", "2016-08-10"),
                new Tuple<string, string, string>("RecoveryServices", "ReplicationProtectionContainers", "2016-08-10"),
                new Tuple<string, string, string>("RecoveryServices", "ReplicationRecoveryPlans", "2016-08-10"),
                new Tuple<string, string, string>("RecoveryServices", "ReplicationRecoveryServicesProviders", "2016-08-10"),
                new Tuple<string, string, string>("RecoveryServices", "ReplicationStorageClassificationMappings", "2016-08-10"),
                new Tuple<string, string, string>("RecoveryServices", "ReplicationStorageClassifications", "2016-08-10"),
                new Tuple<string, string, string>("RecoveryServices", "ReplicationVaultHealth", "2016-08-10"),
                new Tuple<string, string, string>("RecoveryServices", "ReplicationvCenters", "2016-08-10"),
            }.AsEnumerable();
        }
    }
}
