// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// In the old autorest-based SDK, GetDeviceCapacityInfo/GetNetworkSettings/GetUpdateSummary were simple
// methods on DataBoxEdgeDeviceResource that returned Response<Model> directly.
//
// In the new TypeSpec-based SDK, these are full ARM sub-resources accessible via
// GetDataBoxEdgeDeviceCapacityInfo(), GetDataBoxEdgeDeviceNetworkSettings(), and
// GetDataBoxEdgeDeviceUpdateSummary() respectively.
//
// These wrapper methods exist solely for ApiCompat backward-compatibility and are marked obsolete.
// They throw NotSupportedException to discourage use at runtime.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.DataBoxEdge.Models;

namespace Azure.ResourceManager.DataBoxEdge
{
    public partial class DataBoxEdgeDeviceResource
    {
        /// <summary> Gets the device capacity info. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("Use GetDataBoxEdgeDeviceCapacityInfo().Get().Data instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataBoxEdgeDeviceCapacityInfo> GetDeviceCapacityInfo(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Use GetDataBoxEdgeDeviceCapacityInfo().Get().Data instead.");

        /// <summary> Gets the device capacity info. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("Use GetDataBoxEdgeDeviceCapacityInfo().GetAsync().Data instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<DataBoxEdgeDeviceCapacityInfo>> GetDeviceCapacityInfoAsync(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Use GetDataBoxEdgeDeviceCapacityInfo().GetAsync().Data instead.");

        /// <summary> Gets the network settings of the specified Data Box Edge/Data Box Gateway device. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("Use GetDataBoxEdgeDeviceNetworkSettings().Get().Data instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataBoxEdgeDeviceNetworkSettings> GetNetworkSettings(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Use GetDataBoxEdgeDeviceNetworkSettings().Get().Data instead.");

        /// <summary> Gets the network settings of the specified Data Box Edge/Data Box Gateway device. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("Use GetDataBoxEdgeDeviceNetworkSettings().GetAsync().Data instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<DataBoxEdgeDeviceNetworkSettings>> GetNetworkSettingsAsync(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Use GetDataBoxEdgeDeviceNetworkSettings().GetAsync().Data instead.");

        /// <summary> Gets information about the availability of updates for the device. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("Use GetDataBoxEdgeDeviceUpdateSummary().Get().Data instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataBoxEdgeDeviceUpdateSummary> GetUpdateSummary(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Use GetDataBoxEdgeDeviceUpdateSummary().Get().Data instead.");

        /// <summary> Gets information about the availability of updates for the device. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("Use GetDataBoxEdgeDeviceUpdateSummary().GetAsync().Data instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<DataBoxEdgeDeviceUpdateSummary>> GetUpdateSummaryAsync(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Use GetDataBoxEdgeDeviceUpdateSummary().GetAsync().Data instead.");
    }
}
