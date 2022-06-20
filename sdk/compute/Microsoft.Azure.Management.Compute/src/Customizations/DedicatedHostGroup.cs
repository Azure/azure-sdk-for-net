using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Compute.Models
{
    public partial class DedicatedHostGroup : Resource
    {
        public DedicatedHostGroup(string location, int platformFaultDomainCount, string id, string name, string type, IDictionary<string, string> tags, IList<SubResourceReadOnly> hosts, DedicatedHostGroupInstanceView instanceView, bool? supportAutomaticPlacement, IList<string> zones)
            : base(location, id, name, type, tags)
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