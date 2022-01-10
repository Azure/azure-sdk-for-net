// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Dns.Models;

namespace Azure.ResourceManager.Dns
{
    internal partial class RecordSetsRestOperations
    {
        internal HttpMessage CreateGetRequest(string subscriptionId, string resourceGroupName, string zoneName, RecordType recordType, string relativeRecordSetName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Network/dnsZones/", false);
            uri.AppendPath(zoneName, true);
            uri.AppendPath("/", false);
            uri.AppendPath(recordType.ToSerialString(), true);
            uri.AppendPath("/", false);
            uri.AppendPath(relativeRecordSetName, false);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            message.SetProperty("UserAgentOverride", _userAgent);
            return message;
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, or <paramref name="relativeRecordSetName"/> is null. </exception>
        public async Task<Response<ARecordData>> GetARecordAsync(string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, CancellationToken cancellationToken = default)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (zoneName == null)
            {
                throw new ArgumentNullException(nameof(zoneName));
            }
            if (relativeRecordSetName == null)
            {
                throw new ArgumentNullException(nameof(relativeRecordSetName));
            }

            using var message = CreateGetRequest(subscriptionId, resourceGroupName, zoneName, RecordType.A, relativeRecordSetName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ARecordData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ARecordData.DeserializeARecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((ARecordData)null, message.Response);
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, or <paramref name="relativeRecordSetName"/> is null. </exception>
        public Response<ARecordData> GetARecord(string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, CancellationToken cancellationToken = default)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (zoneName == null)
            {
                throw new ArgumentNullException(nameof(zoneName));
            }
            if (relativeRecordSetName == null)
            {
                throw new ArgumentNullException(nameof(relativeRecordSetName));
            }

            using var message = CreateGetRequest(subscriptionId, resourceGroupName, zoneName, RecordType.A, relativeRecordSetName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ARecordData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = ARecordData.DeserializeARecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((ARecordData)null, message.Response);
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }
    }
}
