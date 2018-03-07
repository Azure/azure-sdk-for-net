
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
                new Tuple<string, string, string>("RecoveryServices", "Operations", "2018-01-10"),
                new Tuple<string, string, string>("RecoveryServices", "RecoveryPoints", "2018-01-10"),
                new Tuple<string, string, string>("RecoveryServices", "ReplicationAlertSettings", "2018-01-10"),
                new Tuple<string, string, string>("RecoveryServices", "ReplicationEvents", "2018-01-10"),
                new Tuple<string, string, string>("RecoveryServices", "ReplicationFabrics", "2018-01-10"),
                new Tuple<string, string, string>("RecoveryServices", "ReplicationJobs", "2018-01-10"),
                new Tuple<string, string, string>("RecoveryServices", "ReplicationLogicalNetworks", "2018-01-10"),
                new Tuple<string, string, string>("RecoveryServices", "ReplicationNetworkMappings", "2018-01-10"),
                new Tuple<string, string, string>("RecoveryServices", "ReplicationNetworks", "2018-01-10"),
                new Tuple<string, string, string>("RecoveryServices", "ReplicationPolicies", "2018-01-10"),
                new Tuple<string, string, string>("RecoveryServices", "ReplicationProtectableItems", "2018-01-10"),
                new Tuple<string, string, string>("RecoveryServices", "ReplicationProtectedItems", "2018-01-10"),
                new Tuple<string, string, string>("RecoveryServices", "ReplicationProtectionContainerMappings", "2018-01-10"),
                new Tuple<string, string, string>("RecoveryServices", "ReplicationProtectionContainers", "2018-01-10"),
                new Tuple<string, string, string>("RecoveryServices", "ReplicationRecoveryPlans", "2018-01-10"),
                new Tuple<string, string, string>("RecoveryServices", "ReplicationRecoveryServicesProviders", "2018-01-10"),
                new Tuple<string, string, string>("RecoveryServices", "ReplicationStorageClassificationMappings", "2018-01-10"),
                new Tuple<string, string, string>("RecoveryServices", "ReplicationStorageClassifications", "2018-01-10"),
                new Tuple<string, string, string>("RecoveryServices", "ReplicationVaultHealth", "2018-01-10"),
                new Tuple<string, string, string>("RecoveryServices", "ReplicationvCenters", "2018-01-10"),
                new Tuple<string, string, string>("RecoveryServices", "TargetComputeSizes", "2018-01-10"),
            }.AsEnumerable();
        }
    }
}
