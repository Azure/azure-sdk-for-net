using System.Collections.Generic;

namespace Microsoft.Azure.Management.Compute.Models
{
    public partial class VirtualMachineScaleSetUpdateIPConfiguration : SubResource
    {
        public VirtualMachineScaleSetUpdateIPConfiguration(string id = default(string), string name = default(string), ApiEntityReference subnet = default(ApiEntityReference), bool? primary = default(bool?), VirtualMachineScaleSetUpdatePublicIPAddressConfiguration publicIPAddressConfiguration = default(VirtualMachineScaleSetUpdatePublicIPAddressConfiguration), string privateIPAddressVersion = default(string), IList<SubResource> applicationGatewayBackendAddressPools = default(IList<SubResource>), IList<SubResource> applicationSecurityGroups = default(IList<SubResource>), IList<SubResource> loadBalancerBackendAddressPools = default(IList<SubResource>), IList<SubResource> loadBalancerInboundNatPools = default(IList<SubResource>))
            : base(id)
        {
            Name = name;
            Subnet = subnet;
            Primary = primary;
            PublicIPAddressConfiguration = publicIPAddressConfiguration;
            PrivateIPAddressVersion = privateIPAddressVersion;
            ApplicationGatewayBackendAddressPools = applicationGatewayBackendAddressPools;
            ApplicationSecurityGroups = applicationSecurityGroups;
            LoadBalancerBackendAddressPools = loadBalancerBackendAddressPools;
            LoadBalancerInboundNatPools = loadBalancerInboundNatPools;
            CustomInit();
        }

    }
}