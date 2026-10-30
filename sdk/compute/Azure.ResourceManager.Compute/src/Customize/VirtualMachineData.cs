// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Compute
{
    // Backward compatibility: flatten ScheduledEventsTerminateNotificationProfile from ScheduledEventsProfile.
    // In this library, some identities are v3 and some are not. The generator currently treats all identities
    // as v3 and serializes the combined identity type without a space, but VM identity uses the non-v3 wire value.
    [CodeGenSerialization(nameof(Identity), "identity", SerializationValueHook = nameof(SerializeIdentityValue))]
    public partial class VirtualMachineData
    {
        private void SerializeIdentityValue(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<ManagedServiceIdentity>)Identity).Write(writer, options);

        /// <summary> Specifies the preferred VM size, for example Standard_D4s_v5. Azure may deploy a compatible alternative size based on capacity and placement considerations. Supported VM families for FlexProfile may vary by region. The recommended way to get the list of available sizes is using these APIs: [List all available virtual machine sizes in a region](https://docs.microsoft.com/rest/api/compute/resourceskus/list), [List all available virtual machine sizes for resizing](https://docs.microsoft.com/rest/api/compute/virtualmachines/listavailablesizes). </summary>
        public string FlexPreferredVmSize
        {
            get => Properties?.FlexProfile?.PreferredVmSize;
            set
            {
                if (Properties is null)
                    Properties = new VirtualMachineProperties();
                // The generated flattened setter constructs FlexProfile(null) instead of clearing the optional profile.
                // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/64305.
                Properties.FlexProfile = value is null ? null : new FlexProfile(value);
            }
        }

        /// <summary> Resource Id. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier CapacityReservationGroupId
        {
            get => Properties?.CapacityReservation?.CapacityReservationGroupId;
            set
            {
                if (Properties is null)
                    Properties = new VirtualMachineProperties();
                if (Properties.CapacityReservation is null)
                    Properties.CapacityReservation = new CapacityReservationProfile();
                Properties.CapacityReservation.CapacityReservationGroupId = value;
            }
        }

        /// <summary> Specifies Terminate Scheduled Event related configurations. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TerminateNotificationProfile ScheduledEventsTerminateNotificationProfile
        {
            get => ScheduledEventsProfile is null ? default : ScheduledEventsProfile.TerminateNotificationProfile;
            set
            {
                if (ScheduledEventsProfile is null)
                    ScheduledEventsProfile = new ComputeScheduledEventsProfile();
                ScheduledEventsProfile.TerminateNotificationProfile = value;
            }
        }
    }
}
