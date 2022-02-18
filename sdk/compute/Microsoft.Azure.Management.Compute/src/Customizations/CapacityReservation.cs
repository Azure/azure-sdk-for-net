using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Compute.Models
{
    public partial class CapacityReservation : Resource
    {
        public CapacityReservation(string location, Sku sku, string id, string name, string type, IDictionary<string, string> tags, string reservationId, IList<SubResourceReadOnly> virtualMachinesAssociated, System.DateTime? provisioningTime, string provisioningState, CapacityReservationInstanceView instanceView, IList<string> zones)
            : base(location, id, name, type, tags)
        {
            ReservationId = reservationId;
            VirtualMachinesAssociated = virtualMachinesAssociated;
            ProvisioningTime = provisioningTime;
            ProvisioningState = provisioningState;
            InstanceView = instanceView;
            Sku = sku;
            Zones = zones;
            CustomInit();
        }
    }
}
