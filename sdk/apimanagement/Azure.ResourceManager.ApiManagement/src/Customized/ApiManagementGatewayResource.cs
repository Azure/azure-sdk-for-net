// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager.ApiManagement.Models;

namespace Azure.ResourceManager.ApiManagement
{
    public partial class ApiManagementGatewayResource
    {
        // The old SDK returned IReadOnlyDictionary<string, BinaryData> from GetTrace, but the
        // generator emits IDictionary. The generated method is renamed to GetTraceRaw via
        // @@clientName in client.tsp, and these wrappers convert to IReadOnlyDictionary to
        // avoid a binary-breaking return-type change. Not spec-fixable: the generator always
        // emits IDictionary for Record<T> responses.

        /// <summary> Gets the Trace. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<IReadOnlyDictionary<string, BinaryData>>> GetTraceAsync(GatewayListTraceContract gatewayListTraceContract, CancellationToken cancellationToken = default)
        {
            Response<IDictionary<string, BinaryData>> response = await GetTraceRawAsync(gatewayListTraceContract, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(ToReadOnlyDictionary(response.Value), response.GetRawResponse());
        }

        /// <summary> Gets the Trace. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<IReadOnlyDictionary<string, BinaryData>> GetTrace(GatewayListTraceContract gatewayListTraceContract, CancellationToken cancellationToken = default)
        {
            Response<IDictionary<string, BinaryData>> response = GetTraceRaw(gatewayListTraceContract, cancellationToken);
            return Response.FromValue(ToReadOnlyDictionary(response.Value), response.GetRawResponse());
        }

        private static IReadOnlyDictionary<string, BinaryData> ToReadOnlyDictionary(IDictionary<string, BinaryData> value)
            => value as IReadOnlyDictionary<string, BinaryData> ?? new Dictionary<string, BinaryData>(value);
    }
}
