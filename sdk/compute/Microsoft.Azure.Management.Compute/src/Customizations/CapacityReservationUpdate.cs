namespace Microsoft.Azure.Management.Compute.Models
{
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class CapacityReservationUpdate : UpdateResource
    {
        public CapacityReservationUpdate(IDictionary<string, string> tags, string reservationId, IList<SubResourceReadOnly> virtualMachinesAssociated, System.DateTime? provisioningTime, string provisioningState, CapacityReservationInstanceView instanceView, Sku sku)
            : base(tags)
        {
            ReservationId = reservationId;
            VirtualMachinesAssociated = virtualMachinesAssociated;
            ProvisioningTime = provisioningTime;
            ProvisioningState = provisioningState;
            InstanceView = instanceView;
            Sku = sku;
            CustomInit();
        }
    }
}