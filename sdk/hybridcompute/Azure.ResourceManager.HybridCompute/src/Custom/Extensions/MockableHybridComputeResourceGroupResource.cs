// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.HybridCompute;
using Azure.ResourceManager.HybridCompute.Models;

namespace Azure.ResourceManager.HybridCompute.Mocking
{
    public partial class MockableHybridComputeResourceGroupResource
    {
        // Backward-compat justification: the GA mockable resource group APIs exposed ArcSettings-based UpdateSetting overloads.
        /// <summary>
        /// Updates the base Settings of the target resource.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<ArcSettings>> UpdateSettingAsync(string baseProvider, string baseResourceType, string baseResourceName, string settingsResourceName, ArcSettings arcSettings, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(baseProvider, nameof(baseProvider));
            Argument.AssertNotNullOrEmpty(baseResourceType, nameof(baseResourceType));
            Argument.AssertNotNullOrEmpty(baseResourceName, nameof(baseResourceName));
            Argument.AssertNotNullOrEmpty(settingsResourceName, nameof(settingsResourceName));
            Argument.AssertNotNull(arcSettings, nameof(arcSettings));

            ResourceIdentifier id = HybridComputeSettingsResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, baseProvider, baseResourceType, baseResourceName, settingsResourceName);
            Response<HybridComputeSettingsResource> response = await new HybridComputeSettingsResource(Client, id).UpdateAsync(ToArcSettingsData(arcSettings), cancellationToken).ConfigureAwait(false);
            return Response.FromValue(FromArcSettingsData(response.Value.Data), response.GetRawResponse());
        }

        /// <summary>
        /// Updates the base Settings of the target resource.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<ArcSettings> UpdateSetting(string baseProvider, string baseResourceType, string baseResourceName, string settingsResourceName, ArcSettings arcSettings, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(baseProvider, nameof(baseProvider));
            Argument.AssertNotNullOrEmpty(baseResourceType, nameof(baseResourceType));
            Argument.AssertNotNullOrEmpty(baseResourceName, nameof(baseResourceName));
            Argument.AssertNotNullOrEmpty(settingsResourceName, nameof(settingsResourceName));
            Argument.AssertNotNull(arcSettings, nameof(arcSettings));

            ResourceIdentifier id = HybridComputeSettingsResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, baseProvider, baseResourceType, baseResourceName, settingsResourceName);
            Response<HybridComputeSettingsResource> response = new HybridComputeSettingsResource(Client, id).Update(ToArcSettingsData(arcSettings), cancellationToken);
            return Response.FromValue(FromArcSettingsData(response.Value.Data), response.GetRawResponse());
        }

        private static ArcSettingsData ToArcSettingsData(ArcSettings arcSettings)
        {
            string tenantId = arcSettings.TenantId?.ToString();
            SettingsGatewayProperties gatewayProperties = arcSettings.GatewayResourceId is null ? default : new SettingsGatewayProperties(arcSettings.GatewayResourceId, null);

            return new ArcSettingsData(
                arcSettings.Id,
                arcSettings.Name,
                arcSettings.ResourceType,
                arcSettings.SystemData,
                tenantId is null && gatewayProperties is null ? default : new SettingsProperties(tenantId, gatewayProperties, null),
                additionalBinaryDataProperties: null);
        }

        private static ArcSettings FromArcSettingsData(ArcSettingsData data)
        {
            if (data is null)
            {
                return null;
            }

            Guid? tenantId = Guid.TryParse(data.TenantId, out Guid parsedTenantId) ? parsedTenantId : default(Guid?);
            return ArmHybridComputeModelFactory.ArcSettings(data.Id, data.Name, data.ResourceType, data.SystemData, tenantId, data.GatewayResourceId);
        }

        // Backward-compat justification: the GA mockable resource group APIs exposed machine get overloads with an expand parameter.
        /// <summary>
        /// Retrieves information about the model view or the instance view of a hybrid machine.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<Response<HybridComputeMachineResource>> GetHybridComputeMachineAsync(string machineName, string expand = default, CancellationToken cancellationToken = default)
            => GetHybridComputeMachines().GetAsync(machineName, expand, cancellationToken);

        /// <summary>
        /// Retrieves information about the model view or the instance view of a hybrid machine.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<HybridComputeMachineResource> GetHybridComputeMachine(string machineName, string expand = default, CancellationToken cancellationToken = default)
            => GetHybridComputeMachines().Get(machineName, expand, cancellationToken);
    }
}
