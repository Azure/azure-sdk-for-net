
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_ComputeManagementClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("Compute", "AvailabilitySets", "2017-12-01"),
                new Tuple<string, string, string>("Compute", "Disks", "2017-03-30"),
                new Tuple<string, string, string>("Compute", "Images", "2017-12-01"),
                new Tuple<string, string, string>("Compute", "LogAnalytics", "2017-12-01"),
                new Tuple<string, string, string>("Compute", "ResourceSkus", "2017-09-01"),
                new Tuple<string, string, string>("Compute", "Snapshots", "2017-03-30"),
                new Tuple<string, string, string>("Compute", "Usage", "2017-12-01"),
                new Tuple<string, string, string>("Compute", "VirtualMachineExtensionImages", "2017-12-01"),
                new Tuple<string, string, string>("Compute", "VirtualMachineExtensions", "2017-12-01"),
                new Tuple<string, string, string>("Compute", "VirtualMachineImages", "2017-12-01"),
                new Tuple<string, string, string>("Compute", "VirtualMachineRunCommands", "2017-12-01"),
                new Tuple<string, string, string>("Compute", "VirtualMachineScaleSetExtensions", "2017-12-01"),
                new Tuple<string, string, string>("Compute", "VirtualMachineScaleSetRollingUpgrades", "2017-12-01"),
                new Tuple<string, string, string>("Compute", "VirtualMachineScaleSetVMs", "2017-12-01"),
                new Tuple<string, string, string>("Compute", "VirtualMachineScaleSets", "2017-12-01"),
                new Tuple<string, string, string>("Compute", "VirtualMachineSizes", "2017-12-01"),
                new Tuple<string, string, string>("Compute", "VirtualMachines", "2017-12-01"),
                new Tuple<string, string, string>("ContainerService", "ContainerServices", "2017-01-31"),
            }.AsEnumerable();
        }
    }
}
