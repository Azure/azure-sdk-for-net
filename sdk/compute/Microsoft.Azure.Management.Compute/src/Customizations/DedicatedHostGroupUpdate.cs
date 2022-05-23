using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Compute.Models
{
    public partial class DedicatedHostGroupUpdate : UpdateResource
    {
        public DedicatedHostGroupUpdate(int platformFaultDomainCount, IDictionary<string, string> tags, IList<SubResourceReadOnly> hosts, DedicatedHostGroupInstanceView instanceView, bool? supportAutomaticPlacement, IList<string> zones)
            : base(tags)
        {
            PlatformFaultDomainCount = platformFaultDomainCount;
            Hosts = hosts;
            InstanceView = instanceView;
            SupportAutomaticPlacement = supportAutomaticPlacement;
            Zones = zones;
            CustomInit();
        }
    }
}