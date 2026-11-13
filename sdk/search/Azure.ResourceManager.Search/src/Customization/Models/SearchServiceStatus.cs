// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.Search.Models
{
    /// <summary> The legacy status of a search service. Use <see cref="SearchServiceState"/> to represent all service statuses. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum SearchServiceStatus
    {
        /// <summary> The search service is running and no provisioning operations are underway. </summary>
        Running,
        /// <summary> The search service is being provisioned or scaled up or down. </summary>
        Provisioning,
        /// <summary> The search service is being deleted. </summary>
        Deleting,
        /// <summary> The search service is degraded because underlying search units are not healthy. </summary>
        Degraded,
        /// <summary> The search service is disabled and all API requests will be rejected. </summary>
        Disabled,
        /// <summary> The search service is in error state, indicating either a failure to provision or to be deleted. </summary>
        Error
    }
}
