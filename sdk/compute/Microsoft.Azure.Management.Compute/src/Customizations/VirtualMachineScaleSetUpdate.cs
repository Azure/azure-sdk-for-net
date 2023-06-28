using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Compute.Models
{
    public partial class VirtualMachineScaleSetUpdate : UpdateResource
    {
        public VirtualMachineScaleSetUpdate(IDictionary<string, string> tags, Sku sku, Plan plan, UpgradePolicy upgradePolicy, AutomaticRepairsPolicy automaticRepairsPolicy, VirtualMachineScaleSetUpdateVMProfile virtualMachineProfile, bool? overprovision, bool? doNotRunExtensionsOnOverprovisionedVMs, bool? singlePlacementGroup, AdditionalCapabilities additionalCapabilities, ScaleInPolicy scaleInPolicy, SubResource proximityPlacementGroup, VirtualMachineScaleSetIdentity identity)
            : base(tags)
        {
            Sku = sku;
            Plan = plan;
            UpgradePolicy = upgradePolicy;
            AutomaticRepairsPolicy = automaticRepairsPolicy;
            VirtualMachineProfile = virtualMachineProfile;
            Overprovision = overprovision;
            DoNotRunExtensionsOnOverprovisionedVMs = doNotRunExtensionsOnOverprovisionedVMs;
            SinglePlacementGroup = singlePlacementGroup;
            AdditionalCapabilities = additionalCapabilities;
            ScaleInPolicy = scaleInPolicy;
            ProximityPlacementGroup = proximityPlacementGroup;
            Identity = identity;
            CustomInit();
        }
    }
}