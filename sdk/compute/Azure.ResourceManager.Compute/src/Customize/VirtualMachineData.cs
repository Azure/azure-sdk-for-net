// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Compute
{
    // Backward compatibility: flatten ScheduledEventsTerminateNotificationProfile from ScheduledEventsProfile.
    // In this library, some identities are v3 and some are not. The generator currently treats all identities
    // as v3 and serializes the combined identity type without a space, but VM identity uses the non-v3 wire value.
    [CodeGenSerialization(nameof(Identity), SerializationValueHook = nameof(SerializeIdentityValue))]
    public partial class VirtualMachineData
    {
        private void SerializeIdentityValue(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<ManagedServiceIdentity>)Identity).Write(writer, options);

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
