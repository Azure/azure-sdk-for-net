// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Why: Baseline had GetDeviceCapacityInfo/GetNetworkSettings/GetUpdateSummary methods returning model types.
// New generator uses sub-resource pattern. These wrapper methods provide backward-compatible API.

using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.DataBoxEdge.Models;

namespace Azure.ResourceManager.DataBoxEdge
{
    public partial class DataBoxEdgeDeviceResource
    {
        /// <summary> Gets the device capacity info. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DataBoxEdgeDeviceCapacityInfo> GetDeviceCapacityInfo(CancellationToken cancellationToken = default)
        {
            var resource = GetDataBoxEdgeDeviceCapacityInfo();
            var response = resource.Get(cancellationToken);
            var model = new DataBoxEdgeDeviceCapacityInfo(response.Value.Data);
            return Response.FromValue(model, response.GetRawResponse());
        }

        /// <summary> Gets the device capacity info. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DataBoxEdgeDeviceCapacityInfo>> GetDeviceCapacityInfoAsync(CancellationToken cancellationToken = default)
        {
            var resource = GetDataBoxEdgeDeviceCapacityInfo();
            var response = await resource.GetAsync(cancellationToken).ConfigureAwait(false);
            var model = new DataBoxEdgeDeviceCapacityInfo(response.Value.Data);
            return Response.FromValue(model, response.GetRawResponse());
        }

        /// <summary> Gets the network settings of the specified Data Box Edge/Data Box Gateway device. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DataBoxEdgeDeviceNetworkSettings> GetNetworkSettings(CancellationToken cancellationToken = default)
        {
            var resource = GetDataBoxEdgeDeviceNetworkSettings();
            var response = resource.Get(cancellationToken);
            var model = new DataBoxEdgeDeviceNetworkSettings(response.Value.Data);
            return Response.FromValue(model, response.GetRawResponse());
        }

        /// <summary> Gets the network settings of the specified Data Box Edge/Data Box Gateway device. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DataBoxEdgeDeviceNetworkSettings>> GetNetworkSettingsAsync(CancellationToken cancellationToken = default)
        {
            var resource = GetDataBoxEdgeDeviceNetworkSettings();
            var response = await resource.GetAsync(cancellationToken).ConfigureAwait(false);
            var model = new DataBoxEdgeDeviceNetworkSettings(response.Value.Data);
            return Response.FromValue(model, response.GetRawResponse());
        }

        /// <summary> Gets information about the availability of updates for the device. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DataBoxEdgeDeviceUpdateSummary> GetUpdateSummary(CancellationToken cancellationToken = default)
        {
            var resource = GetDataBoxEdgeDeviceUpdateSummary();
            var response = resource.Get(cancellationToken);
            var model = new DataBoxEdgeDeviceUpdateSummary(response.Value.Data);
            return Response.FromValue(model, response.GetRawResponse());
        }

        /// <summary> Gets information about the availability of updates for the device. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DataBoxEdgeDeviceUpdateSummary>> GetUpdateSummaryAsync(CancellationToken cancellationToken = default)
        {
            var resource = GetDataBoxEdgeDeviceUpdateSummary();
            var response = await resource.GetAsync(cancellationToken).ConfigureAwait(false);
            var model = new DataBoxEdgeDeviceUpdateSummary(response.Value.Data);
            return Response.FromValue(model, response.GetRawResponse());
        }
    }
}
