// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        /// <summary>
        /// Updates the base Settings of the target resource.
        /// This method preserves the AutoRest-generated mockable API for backward compatibility.
        /// Use <see cref="SettingsResource.UpdateAsync(ArcSettingsData, CancellationToken)"/> instead.
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

            ResourceIdentifier id = SettingsResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, baseProvider, baseResourceType, baseResourceName, settingsResourceName);
            Response<SettingsResource> response = await new SettingsResource(Client, id).UpdateAsync(arcSettings.ToArcSettingsData(), cancellationToken).ConfigureAwait(false);
            return Response.FromValue(ArcSettings.FromArcSettingsData(response.Value.Data), response.GetRawResponse());
        }

        /// <summary>
        /// Updates the base Settings of the target resource.
        /// This method preserves the AutoRest-generated mockable API for backward compatibility.
        /// Use <see cref="SettingsResource.Update(ArcSettingsData, CancellationToken)"/> instead.
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

            ResourceIdentifier id = SettingsResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, baseProvider, baseResourceType, baseResourceName, settingsResourceName);
            Response<SettingsResource> response = new SettingsResource(Client, id).Update(arcSettings.ToArcSettingsData(), cancellationToken);
            return Response.FromValue(ArcSettings.FromArcSettingsData(response.Value.Data), response.GetRawResponse());
        }

        /// <summary>
        /// Gets a hybrid machine.
        /// This overload includes a string <paramref name="expand"/> parameter for backward compatibility.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<Response<HybridComputeMachineResource>> GetHybridComputeMachineAsync(string machineName, string expand = default, CancellationToken cancellationToken = default)
            => GetHybridComputeMachines().GetAsync(machineName, expand, cancellationToken);

        /// <summary>
        /// Gets a hybrid machine.
        /// This overload includes a string <paramref name="expand"/> parameter for backward compatibility.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<HybridComputeMachineResource> GetHybridComputeMachine(string machineName, string expand = default, CancellationToken cancellationToken = default)
            => GetHybridComputeMachines().Get(machineName, expand, cancellationToken);
    }
}
