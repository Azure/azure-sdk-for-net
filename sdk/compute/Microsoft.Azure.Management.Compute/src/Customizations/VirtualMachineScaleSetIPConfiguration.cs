using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Compute.Models
{
    public partial class VirtualMachineScaleSetIPConfiguration
    {
        public VirtualMachineScaleSetIPConfiguration(string name, string id, ApiEntityReference subnet = default(ApiEntityReference), bool? primary = default(bool?), VirtualMachineScaleSetPublicIPAddressConfiguration publicIPAddressConfiguration = default(VirtualMachineScaleSetPublicIPAddressConfiguration), string privateIPAddressVersion = default(string), IList<SubResource> applicationGatewayBackendAddressPools = default(IList<SubResource>), IList<SubResource> applicationSecurityGroups = default(IList<SubResource>), IList<SubResource> loadBalancerBackendAddressPools = default(IList<SubResource>), IList<SubResource> loadBalancerInboundNatPools = default(IList<SubResource>))
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