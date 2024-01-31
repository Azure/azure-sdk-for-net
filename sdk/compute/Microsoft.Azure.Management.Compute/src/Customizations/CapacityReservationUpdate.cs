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

        public CapacityReservationUpdate(IDictionary<string, string> tags, string reservationId, IList<SubResourceReadOnly> virtualMachinesAssociated = default(IList<SubResourceReadOnly>), System.DateTime? provisioningTime = default(System.DateTime?), string provisioningState = default(string), CapacityReservationInstanceView instanceView = default(CapacityReservationInstanceView), System.DateTime? timeCreated = default(System.DateTime?), Sku sku = default(Sku))
            : base(tags)
        {
            ReservationId = reservationId;
            VirtualMachinesAssociated = virtualMachinesAssociated;
            ProvisioningTime = provisioningTime;
            ProvisioningState = provisioningState;
            InstanceView = instanceView;
            TimeCreated = timeCreated;
            Sku = sku;
            CustomInit();
        }
    }
}