// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager.ApiManagement.Models;

namespace Azure.ResourceManager.ApiManagement
{
    public partial class ApiManagementGatewayResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<IReadOnlyDictionary<string, BinaryData>>> GetTraceAsync(GatewayListTraceContract gatewayListTraceContract, CancellationToken cancellationToken = default)
        {
            Response<IDictionary<string, BinaryData>> response = await GetTraceRawAsync(gatewayListTraceContract, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(ToReadOnlyDictionary(response.Value), response.GetRawResponse());
        }

        /// <inheritdoc />
        public virtual Response<IReadOnlyDictionary<string, BinaryData>> GetTrace(GatewayListTraceContract gatewayListTraceContract, CancellationToken cancellationToken = default)
        {
            Response<IDictionary<string, BinaryData>> response = GetTraceRaw(gatewayListTraceContract, cancellationToken);
            return Response.FromValue(ToReadOnlyDictionary(response.Value), response.GetRawResponse());
        }

        private static IReadOnlyDictionary<string, BinaryData> ToReadOnlyDictionary(IDictionary<string, BinaryData> value)
            => value as IReadOnlyDictionary<string, BinaryData> ?? new Dictionary<string, BinaryData>(value);
    }
}
