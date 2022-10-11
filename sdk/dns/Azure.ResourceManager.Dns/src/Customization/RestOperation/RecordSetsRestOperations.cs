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
using Azure.ResourceManager.Dns.Models;
using Azure.ResourceManager.Models;

[assembly: CodeGenSuppressType("RecordSetsRestOperations")]

namespace Azure.ResourceManager.Dns
{
    internal partial class RecordSetsRestOperations
    {
        private readonly TelemetryDetails _userAgent;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> Initializes a new instance of RecordSetsRestOperations. </summary>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="applicationId"> The application id to use for user agent. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pipeline"/> or <paramref name="apiVersion"/> is null. </exception>
        public RecordSetsRestOperations(HttpPipeline pipeline, string applicationId, Uri endpoint = null, string apiVersion = default)
        {
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("https://management.azure.com");
            _apiVersion = apiVersion ?? "2018-05-01";
            _userAgent = new TelemetryDetails(GetType().Assembly, applicationId);
        }

        internal HttpMessage CreateUpdateRequest(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, ResourceData data, ETag? ifMatch)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Network/dnsZones/", false);
            uri.AppendPath(zoneName, true);
            uri.AppendPath("/", false);
            uri.AppendPath(dnsRecordType.ToSerialString(), true);
            uri.AppendPath("/", false);
            uri.AppendPath(relativeRecordSetName, false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            if (ifMatch != null)
            {
                request.Headers.Add("If-Match", ifMatch.Value);
            }
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(data);
            request.Content = content;
            _userAgent.Apply(message);
            return message;
        }

        internal HttpMessage CreateCreateOrUpdateRequest(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, ResourceData data, ETag? ifMatch, string ifNoneMatch)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Network/dnsZones/", false);
            uri.AppendPath(zoneName, true);
            uri.AppendPath("/", false);
            uri.AppendPath(dnsRecordType.ToSerialString(), true);
            uri.AppendPath("/", false);
            uri.AppendPath(relativeRecordSetName, false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            if (ifMatch != null)
            {
                request.Headers.Add("If-Match", ifMatch.Value);
            }
            if (ifNoneMatch != null)
            {
                request.Headers.Add("If-None-Match", ifNoneMatch);
            }
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(data);
            request.Content = content;
            _userAgent.Apply(message);
            return message;
        }

        internal HttpMessage CreateDeleteRequest(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, ETag? ifMatch)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Network/dnsZones/", false);
            uri.AppendPath(zoneName, true);
            uri.AppendPath("/", false);
            uri.AppendPath(dnsRecordType.ToSerialString(), true);
            uri.AppendPath("/", false);
            uri.AppendPath(relativeRecordSetName, false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            if (ifMatch != null)
            {
                request.Headers.Add("If-Match", ifMatch.Value);
            }
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Deletes a record set from a DNS zone. This operation cannot be undone. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. Record sets of type SOA cannot be deleted (they are deleted when the DNS zone is deleted). </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always delete the current record set. Specify the last-seen etag value to prevent accidentally deleting any concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/> or <paramref name="relativeRecordSetName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response> DeleteAsync(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));

            using var message = CreateDeleteRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName, ifMatch);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Deletes a record set from a DNS zone. This operation cannot be undone. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. Record sets of type SOA cannot be deleted (they are deleted when the DNS zone is deleted). </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always delete the current record set. Specify the last-seen etag value to prevent accidentally deleting any concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/> or <paramref name="relativeRecordSetName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response Delete(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));

            using var message = CreateDeleteRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName, ifMatch);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetRequest(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Network/dnsZones/", false);
            uri.AppendPath(zoneName, true);
            uri.AppendPath("/", false);
            uri.AppendPath(dnsRecordType.ToSerialString(), true);
            uri.AppendPath("/", false);
            uri.AppendPath(relativeRecordSetName, false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        internal HttpMessage CreateListByTypeRequest(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, int? top, string recordsetnamesuffix)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Network/dnsZones/", false);
            uri.AppendPath(zoneName, true);
            uri.AppendPath("/", false);
            uri.AppendPath(dnsRecordType.ToSerialString(), true);
            if (top != null)
            {
                uri.AppendQuery("$top", top.Value, true);
            }
            if (recordsetnamesuffix != null)
            {
                uri.AppendQuery("$recordsetnamesuffix", recordsetnamesuffix, true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="dnsRecordType"> The type of record sets to enumerate. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<RecordSetListResult>> ListByTypeAsync(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RecordSetListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = RecordSetListResult.DeserializeRecordSetListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="dnsRecordType"> The type of record sets to enumerate. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<RecordSetListResult> ListByType(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RecordSetListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = RecordSetListResult.DeserializeRecordSetListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateListByDnsZoneRequest(string subscriptionId, string resourceGroupName, string zoneName, int? top, string recordsetnamesuffix)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Network/dnsZones/", false);
            uri.AppendPath(zoneName, true);
            uri.AppendPath("/recordsets", false);
            if (top != null)
            {
                uri.AppendQuery("$top", top.Value, true);
            }
            if (recordsetnamesuffix != null)
            {
                uri.AppendQuery("$recordsetnamesuffix", recordsetnamesuffix, true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Lists all record sets in a DNS zone. </summary>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<RecordSetListResult>> ListByDnsZoneAsync(string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByDnsZoneRequest(subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RecordSetListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = RecordSetListResult.DeserializeRecordSetListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists all record sets in a DNS zone. </summary>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<RecordSetListResult> ListByDnsZone(string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByDnsZoneRequest(subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RecordSetListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = RecordSetListResult.DeserializeRecordSetListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

#pragma warning disable CA1801 // Review unused parameters
        internal HttpMessage CreateListByTypeNextPageRequest(string nextLink, DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, int? top, string recordsetnamesuffix)
#pragma warning restore CA1801 // Review unused parameters
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="dnsRecordType"> The type of record sets to enumerate. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<RecordSetListResult>> ListByTypeNextPageAsync(string nextLink, DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeNextPageRequest(nextLink, dnsRecordType, subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RecordSetListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = RecordSetListResult.DeserializeRecordSetListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="dnsRecordType"> The type of record sets to enumerate. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<RecordSetListResult> ListByTypeNextPage(string nextLink, DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeNextPageRequest(nextLink, dnsRecordType, subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RecordSetListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = RecordSetListResult.DeserializeRecordSetListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

#pragma warning disable CA1801 // Review unused parameters
        internal HttpMessage CreateListByDnsZoneNextPageRequest(string nextLink, string subscriptionId, string resourceGroupName, string zoneName, int? top, string recordsetnamesuffix)
#pragma warning restore CA1801 // Review unused parameters
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Lists all record sets in a DNS zone. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<RecordSetListResult>> ListByDnsZoneNextPageAsync(string nextLink, string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByDnsZoneNextPageRequest(nextLink, subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RecordSetListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = RecordSetListResult.DeserializeRecordSetListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists all record sets in a DNS zone. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<RecordSetListResult> ListByDnsZoneNextPage(string nextLink, string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByDnsZoneNextPageRequest(nextLink, subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RecordSetListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = RecordSetListResult.DeserializeRecordSetListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        #region AaaaRecordData Operation

        /// <summary> Updates a record set within a DNS zone. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="aaaaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the Update operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="aaaaRecordName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<AaaaRecordData>> UpdateAsync(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string aaaaRecordName, AaaaRecordData data, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(aaaaRecordName, nameof(aaaaRecordName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateUpdateRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, aaaaRecordName, data, ifMatch);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        AaaaRecordData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = AaaaRecordData.DeserializeAaaaRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Updates a record set within a DNS zone. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="aaaaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the Update operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="aaaaRecordName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<AaaaRecordData> Update(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string aaaaRecordName, AaaaRecordData data, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(aaaaRecordName, nameof(aaaaRecordName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateUpdateRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, aaaaRecordName, data, ifMatch);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        AaaaRecordData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = AaaaRecordData.DeserializeAaaaRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Creates or updates a record set within a DNS zone. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. Record sets of type SOA can be updated but not created (they are created when the DNS zone is created). </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="aaaaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to &apos;*&apos; to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="aaaaRecordName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<AaaaRecordData>> CreateOrUpdateAsync(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string aaaaRecordName, AaaaRecordData data, ETag? ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(aaaaRecordName, nameof(aaaaRecordName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateOrUpdateRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, aaaaRecordName, data, ifMatch, ifNoneMatch);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    {
                        AaaaRecordData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = AaaaRecordData.DeserializeAaaaRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Creates or updates a record set within a DNS zone. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. Record sets of type SOA can be updated but not created (they are created when the DNS zone is created). </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="aaaaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to &apos;*&apos; to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="aaaaRecordName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<AaaaRecordData> CreateOrUpdate(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string aaaaRecordName, AaaaRecordData data, ETag? ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(aaaaRecordName, nameof(aaaaRecordName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateOrUpdateRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, aaaaRecordName, data, ifMatch, ifNoneMatch);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    {
                        AaaaRecordData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = AaaaRecordData.DeserializeAaaaRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="aaaaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/> or <paramref name="aaaaRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<AaaaRecordData>> GetAaaaRecordAsync(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string aaaaRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(aaaaRecordName, nameof(aaaaRecordName));

            using var message = CreateGetRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, aaaaRecordName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        AaaaRecordData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = AaaaRecordData.DeserializeAaaaRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((AaaaRecordData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="aaaaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/> or <paramref name="aaaaRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<AaaaRecordData> GetAaaaRecord(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string aaaaRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(aaaaRecordName, nameof(aaaaRecordName));

            using var message = CreateGetRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, aaaaRecordName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        AaaaRecordData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = AaaaRecordData.DeserializeAaaaRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((AaaaRecordData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<AaaaRecordListResult> ListAaaaRecord(string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeRequest("AAAA".ToDnsRecordType(), subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        AaaaRecordListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = AaaaRecordListResult.DeserializeAaaaRecordListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<AaaaRecordListResult>> ListAaaaRecordAsync(string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeRequest("AAAA".ToDnsRecordType(), subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        AaaaRecordListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = AaaaRecordListResult.DeserializeAaaaRecordListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<AaaaRecordListResult> ListAaaaRecordNextPage(string nextLink, string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeNextPageRequest(nextLink, "AAAA".ToDnsRecordType(), subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        AaaaRecordListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = AaaaRecordListResult.DeserializeAaaaRecordListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<AaaaRecordListResult>> ListAaaaRecordNextPageAsync(string nextLink, string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeNextPageRequest(nextLink, "AAAA".ToDnsRecordType(), subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        AaaaRecordListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = AaaaRecordListResult.DeserializeAaaaRecordListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        #endregion

        #region ARecordData Operation

        /// <summary> Updates a record set within a DNS zone. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="aRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the Update operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="aRecordName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<ARecordData>> UpdateAsync(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string aRecordName, ARecordData data, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(aRecordName, nameof(aRecordName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateUpdateRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, aRecordName, data, ifMatch);
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
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Updates a record set within a DNS zone. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="aRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the Update operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="aRecordName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<ARecordData> Update(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string aRecordName, ARecordData data, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(aRecordName, nameof(aRecordName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateUpdateRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, aRecordName, data, ifMatch);
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
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Creates or updates a record set within a DNS zone. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. Record sets of type SOA can be updated but not created (they are created when the DNS zone is created). </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="aRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to &apos;*&apos; to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="aRecordName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<ARecordData>> CreateOrUpdateAsync(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string aRecordName, ARecordData data, ETag? ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(aRecordName, nameof(aRecordName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateOrUpdateRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, aRecordName, data, ifMatch, ifNoneMatch);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    {
                        ARecordData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ARecordData.DeserializeARecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Creates or updates a record set within a DNS zone. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. Record sets of type SOA can be updated but not created (they are created when the DNS zone is created). </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="aRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to &apos;*&apos; to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="aRecordName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<ARecordData> CreateOrUpdate(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string aRecordName, ARecordData data, ETag? ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(aRecordName, nameof(aRecordName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateOrUpdateRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, aRecordName, data, ifMatch, ifNoneMatch);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    {
                        ARecordData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = ARecordData.DeserializeARecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="aRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/> or <paramref name="aRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<ARecordData>> GetARecordAsync(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string aRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(aRecordName, nameof(aRecordName));

            using var message = CreateGetRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, aRecordName);
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
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="aRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/> or <paramref name="aRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<ARecordData> GetARecord(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string aRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(aRecordName, nameof(aRecordName));

            using var message = CreateGetRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, aRecordName);
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
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<ARecordListResult> ListARecord(string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeRequest("A".ToDnsRecordType(), subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ARecordListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = ARecordListResult.DeserializeARecordListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<ARecordListResult>> ListARecordAsync(string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeRequest("A".ToDnsRecordType(), subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ARecordListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ARecordListResult.DeserializeARecordListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<ARecordListResult> ListARecordNextPage(string nextLink, string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeNextPageRequest(nextLink, "A".ToDnsRecordType(), subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ARecordListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = ARecordListResult.DeserializeARecordListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<ARecordListResult>> ListARecordNextPageAsync(string nextLink, string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeNextPageRequest(nextLink, "A".ToDnsRecordType(), subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ARecordListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ARecordListResult.DeserializeARecordListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        #endregion

        #region CaaRecordData Operation

        /// <summary> Updates a record set within a DNS zone. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the Update operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="relativeRecordSetName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<CaaRecordData>> UpdateAsync(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, CaaRecordData data, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateUpdateRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName, data, ifMatch);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        CaaRecordData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = CaaRecordData.DeserializeCaaRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Updates a record set within a DNS zone. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the Update operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="relativeRecordSetName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<CaaRecordData> Update(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, CaaRecordData data, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateUpdateRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName, data, ifMatch);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        CaaRecordData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = CaaRecordData.DeserializeCaaRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Creates or updates a record set within a DNS zone. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. Record sets of type SOA can be updated but not created (they are created when the DNS zone is created). </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to &apos;*&apos; to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="relativeRecordSetName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<CaaRecordData>> CreateOrUpdateAsync(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, CaaRecordData data, ETag? ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateOrUpdateRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName, data, ifMatch, ifNoneMatch);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    {
                        CaaRecordData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = CaaRecordData.DeserializeCaaRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Creates or updates a record set within a DNS zone. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. Record sets of type SOA can be updated but not created (they are created when the DNS zone is created). </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to &apos;*&apos; to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="relativeRecordSetName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<CaaRecordData> CreateOrUpdate(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, CaaRecordData data, ETag? ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateOrUpdateRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName, data, ifMatch, ifNoneMatch);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    {
                        CaaRecordData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = CaaRecordData.DeserializeCaaRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/> or <paramref name="relativeRecordSetName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<CaaRecordData>> GetCaaRecordAsync(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));

            using var message = CreateGetRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        CaaRecordData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = CaaRecordData.DeserializeCaaRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((CaaRecordData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/> or <paramref name="relativeRecordSetName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<CaaRecordData> GetCaaRecord(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));

            using var message = CreateGetRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        CaaRecordData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = CaaRecordData.DeserializeCaaRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((CaaRecordData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<CaaRecordListResult> ListCaaRecord(string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeRequest("Caa".ToDnsRecordType(), subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        CaaRecordListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = CaaRecordListResult.DeserializeCaaRecordListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<CaaRecordListResult>> ListCaaRecordAsync(string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeRequest("Caa".ToDnsRecordType(), subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        CaaRecordListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = CaaRecordListResult.DeserializeCaaRecordListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<CaaRecordListResult> ListCaaRecordNextPage(string nextLink, string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeNextPageRequest(nextLink, "Caa".ToDnsRecordType(), subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        CaaRecordListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = CaaRecordListResult.DeserializeCaaRecordListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<CaaRecordListResult>> ListCaaRecordNextPageAsync(string nextLink, string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeNextPageRequest(nextLink, "Caa".ToDnsRecordType(), subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        CaaRecordListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = CaaRecordListResult.DeserializeCaaRecordListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        #endregion

        #region CnameRecordData Operation

        /// <summary> Updates a record set within a DNS zone. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the Update operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="relativeRecordSetName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<CnameRecordData>> UpdateAsync(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, CnameRecordData data, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateUpdateRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName, data, ifMatch);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        CnameRecordData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = CnameRecordData.DeserializeCnameRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Updates a record set within a DNS zone. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the Update operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="relativeRecordSetName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<CnameRecordData> Update(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, CnameRecordData data, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateUpdateRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName, data, ifMatch);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        CnameRecordData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = CnameRecordData.DeserializeCnameRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Creates or updates a record set within a DNS zone. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. Record sets of type SOA can be updated but not created (they are created when the DNS zone is created). </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to &apos;*&apos; to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="relativeRecordSetName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<CnameRecordData>> CreateOrUpdateAsync(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, CnameRecordData data, ETag? ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateOrUpdateRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName, data, ifMatch, ifNoneMatch);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    {
                        CnameRecordData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = CnameRecordData.DeserializeCnameRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Creates or updates a record set within a DNS zone. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. Record sets of type SOA can be updated but not created (they are created when the DNS zone is created). </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to &apos;*&apos; to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="relativeRecordSetName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<CnameRecordData> CreateOrUpdate(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, CnameRecordData data, ETag? ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateOrUpdateRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName, data, ifMatch, ifNoneMatch);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    {
                        CnameRecordData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = CnameRecordData.DeserializeCnameRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/> or <paramref name="relativeRecordSetName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<CnameRecordData>> GetCnameRecordAsync(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));

            using var message = CreateGetRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        CnameRecordData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = CnameRecordData.DeserializeCnameRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((CnameRecordData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/> or <paramref name="relativeRecordSetName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<CnameRecordData> GetCnameRecord(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));

            using var message = CreateGetRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        CnameRecordData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = CnameRecordData.DeserializeCnameRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((CnameRecordData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<CnameRecordListResult> ListCnameRecord(string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeRequest("Cname".ToDnsRecordType(), subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        CnameRecordListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = CnameRecordListResult.DeserializeCnameRecordListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<CnameRecordListResult>> ListCnameRecordAsync(string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeRequest("Cname".ToDnsRecordType(), subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        CnameRecordListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = CnameRecordListResult.DeserializeCnameRecordListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<CnameRecordListResult> ListCnameRecordNextPage(string nextLink, string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeNextPageRequest(nextLink, "Cname".ToDnsRecordType(), subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        CnameRecordListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = CnameRecordListResult.DeserializeCnameRecordListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<CnameRecordListResult>> ListCnameRecordNextPageAsync(string nextLink, string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeNextPageRequest(nextLink, "Cname".ToDnsRecordType(), subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        CnameRecordListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = CnameRecordListResult.DeserializeCnameRecordListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        #endregion

        #region MXRecordData Operation

        /// <summary> Updates a record set within a DNS zone. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the Update operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="relativeRecordSetName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<MXRecordData>> UpdateAsync(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, MXRecordData data, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateUpdateRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName, data, ifMatch);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MXRecordData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = MXRecordData.DeserializeMXRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Updates a record set within a DNS zone. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the Update operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="relativeRecordSetName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<MXRecordData> Update(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, MXRecordData data, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateUpdateRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName, data, ifMatch);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MXRecordData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = MXRecordData.DeserializeMXRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Creates or updates a record set within a DNS zone. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. Record sets of type SOA can be updated but not created (they are created when the DNS zone is created). </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to &apos;*&apos; to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="relativeRecordSetName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<MXRecordData>> CreateOrUpdateAsync(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, MXRecordData data, ETag? ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateOrUpdateRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName, data, ifMatch, ifNoneMatch);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    {
                        MXRecordData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = MXRecordData.DeserializeMXRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Creates or updates a record set within a DNS zone. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. Record sets of type SOA can be updated but not created (they are created when the DNS zone is created). </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to &apos;*&apos; to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="relativeRecordSetName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<MXRecordData> CreateOrUpdate(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, MXRecordData data, ETag? ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateOrUpdateRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName, data, ifMatch, ifNoneMatch);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    {
                        MXRecordData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = MXRecordData.DeserializeMXRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/> or <paramref name="relativeRecordSetName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<MXRecordData>> GetMXRecordAsync(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));

            using var message = CreateGetRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MXRecordData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = MXRecordData.DeserializeMXRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((MXRecordData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/> or <paramref name="relativeRecordSetName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<MXRecordData> GetMXRecord(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));

            using var message = CreateGetRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MXRecordData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = MXRecordData.DeserializeMXRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((MXRecordData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<MXRecordListResult> ListMXRecord(string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeRequest("MX".ToDnsRecordType(), subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MXRecordListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = MXRecordListResult.DeserializeMXRecordListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<MXRecordListResult>> ListMXRecordAsync(string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeRequest("MX".ToDnsRecordType(), subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MXRecordListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = MXRecordListResult.DeserializeMXRecordListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<MXRecordListResult> ListMXRecordNextPage(string nextLink, string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeNextPageRequest(nextLink, "MX".ToDnsRecordType(), subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MXRecordListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = MXRecordListResult.DeserializeMXRecordListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<MXRecordListResult>> ListMXRecordNextPageAsync(string nextLink, string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeNextPageRequest(nextLink, "MX".ToDnsRecordType(), subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        MXRecordListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = MXRecordListResult.DeserializeMXRecordListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        #endregion

        #region NSRecordData Operation

        /// <summary> Updates a record set within a DNS zone. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the Update operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="relativeRecordSetName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<NSRecordData>> UpdateAsync(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, NSRecordData data, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateUpdateRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName, data, ifMatch);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        NSRecordData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = NSRecordData.DeserializeNSRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Updates a record set within a DNS zone. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the Update operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="relativeRecordSetName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<NSRecordData> Update(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, NSRecordData data, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateUpdateRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName, data, ifMatch);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        NSRecordData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = NSRecordData.DeserializeNSRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Creates or updates a record set within a DNS zone. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. Record sets of type SOA can be updated but not created (they are created when the DNS zone is created). </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to &apos;*&apos; to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="relativeRecordSetName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<NSRecordData>> CreateOrUpdateAsync(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, NSRecordData data, ETag? ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateOrUpdateRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName, data, ifMatch, ifNoneMatch);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    {
                        NSRecordData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = NSRecordData.DeserializeNSRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Creates or updates a record set within a DNS zone. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. Record sets of type SOA can be updated but not created (they are created when the DNS zone is created). </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to &apos;*&apos; to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="relativeRecordSetName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<NSRecordData> CreateOrUpdate(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, NSRecordData data, ETag? ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateOrUpdateRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName, data, ifMatch, ifNoneMatch);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    {
                        NSRecordData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = NSRecordData.DeserializeNSRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/> or <paramref name="relativeRecordSetName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<NSRecordData>> GetNSRecordAsync(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));

            using var message = CreateGetRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        NSRecordData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = NSRecordData.DeserializeNSRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((NSRecordData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/> or <paramref name="relativeRecordSetName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<NSRecordData> GetNSRecord(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));

            using var message = CreateGetRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        NSRecordData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = NSRecordData.DeserializeNSRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((NSRecordData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<NSRecordListResult> ListNSRecord(string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeRequest("NS".ToDnsRecordType(), subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        NSRecordListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = NSRecordListResult.DeserializeNSRecordListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<NSRecordListResult>> ListNSRecordAsync(string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeRequest("NS".ToDnsRecordType(), subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        NSRecordListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = NSRecordListResult.DeserializeNSRecordListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<NSRecordListResult> ListNSRecordNextPage(string nextLink, string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeNextPageRequest(nextLink, "NS".ToDnsRecordType(), subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        NSRecordListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = NSRecordListResult.DeserializeNSRecordListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<NSRecordListResult>> ListNSRecordNextPageAsync(string nextLink, string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeNextPageRequest(nextLink, "NS".ToDnsRecordType(), subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        NSRecordListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = NSRecordListResult.DeserializeNSRecordListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        #endregion

        #region PtrRecordData Operation

        /// <summary> Updates a record set within a DNS zone. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the Update operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="relativeRecordSetName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<PtrRecordData>> UpdateAsync(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, PtrRecordData data, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateUpdateRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName, data, ifMatch);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        PtrRecordData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = PtrRecordData.DeserializePtrRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Updates a record set within a DNS zone. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the Update operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="relativeRecordSetName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<PtrRecordData> Update(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, PtrRecordData data, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateUpdateRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName, data, ifMatch);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        PtrRecordData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = PtrRecordData.DeserializePtrRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Creates or updates a record set within a DNS zone. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. Record sets of type SOA can be updated but not created (they are created when the DNS zone is created). </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to &apos;*&apos; to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="relativeRecordSetName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<PtrRecordData>> CreateOrUpdateAsync(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, PtrRecordData data, ETag? ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateOrUpdateRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName, data, ifMatch, ifNoneMatch);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    {
                        PtrRecordData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = PtrRecordData.DeserializePtrRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Creates or updates a record set within a DNS zone. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. Record sets of type SOA can be updated but not created (they are created when the DNS zone is created). </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to &apos;*&apos; to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="relativeRecordSetName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<PtrRecordData> CreateOrUpdate(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, PtrRecordData data, ETag? ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateOrUpdateRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName, data, ifMatch, ifNoneMatch);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    {
                        PtrRecordData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = PtrRecordData.DeserializePtrRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/> or <paramref name="relativeRecordSetName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<PtrRecordData>> GetPtrRecordAsync(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));

            using var message = CreateGetRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        PtrRecordData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = PtrRecordData.DeserializePtrRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((PtrRecordData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/> or <paramref name="relativeRecordSetName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<PtrRecordData> GetPtrRecord(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));

            using var message = CreateGetRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        PtrRecordData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = PtrRecordData.DeserializePtrRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((PtrRecordData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<PtrRecordListResult> ListPtrRecord(string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeRequest("Ptr".ToDnsRecordType(), subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        PtrRecordListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = PtrRecordListResult.DeserializePtrRecordListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<PtrRecordListResult>> ListPtrRecordAsync(string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeRequest("Ptr".ToDnsRecordType(), subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        PtrRecordListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = PtrRecordListResult.DeserializePtrRecordListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<PtrRecordListResult> ListPtrRecordNextPage(string nextLink, string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeNextPageRequest(nextLink, "Ptr".ToDnsRecordType(), subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        PtrRecordListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = PtrRecordListResult.DeserializePtrRecordListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<PtrRecordListResult>> ListPtrRecordNextPageAsync(string nextLink, string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeNextPageRequest(nextLink, "Ptr".ToDnsRecordType(), subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        PtrRecordListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = PtrRecordListResult.DeserializePtrRecordListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        #endregion

        #region SoaRecordData Operation

        /// <summary> Updates a record set within a DNS zone. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the Update operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="relativeRecordSetName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<SoaRecordData>> UpdateAsync(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, SoaRecordData data, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateUpdateRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName, data, ifMatch);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SoaRecordData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = SoaRecordData.DeserializeSoaRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Updates a record set within a DNS zone. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the Update operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="relativeRecordSetName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<SoaRecordData> Update(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, SoaRecordData data, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateUpdateRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName, data, ifMatch);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SoaRecordData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = SoaRecordData.DeserializeSoaRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Creates or updates a record set within a DNS zone. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. Record sets of type SOA can be updated but not created (they are created when the DNS zone is created). </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to &apos;*&apos; to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="relativeRecordSetName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<SoaRecordData>> CreateOrUpdateAsync(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, SoaRecordData data, ETag? ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateOrUpdateRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName, data, ifMatch, ifNoneMatch);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    {
                        SoaRecordData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = SoaRecordData.DeserializeSoaRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Creates or updates a record set within a DNS zone. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. Record sets of type SOA can be updated but not created (they are created when the DNS zone is created). </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to &apos;*&apos; to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="relativeRecordSetName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<SoaRecordData> CreateOrUpdate(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, SoaRecordData data, ETag? ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateOrUpdateRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName, data, ifMatch, ifNoneMatch);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    {
                        SoaRecordData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = SoaRecordData.DeserializeSoaRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/> or <paramref name="relativeRecordSetName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<SoaRecordData>> GetSoaRecordAsync(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));

            using var message = CreateGetRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SoaRecordData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = SoaRecordData.DeserializeSoaRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((SoaRecordData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/> or <paramref name="relativeRecordSetName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<SoaRecordData> GetSoaRecord(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));

            using var message = CreateGetRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SoaRecordData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = SoaRecordData.DeserializeSoaRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((SoaRecordData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<SoaRecordListResult> ListSoaRecord(string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeRequest("Soa".ToDnsRecordType(), subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SoaRecordListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = SoaRecordListResult.DeserializeSoaRecordListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<SoaRecordListResult>> ListSoaRecordAsync(string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeRequest("Soa".ToDnsRecordType(), subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SoaRecordListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = SoaRecordListResult.DeserializeSoaRecordListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<SoaRecordListResult> ListSoaRecordNextPage(string nextLink, string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeNextPageRequest(nextLink, "Soa".ToDnsRecordType(), subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SoaRecordListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = SoaRecordListResult.DeserializeSoaRecordListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<SoaRecordListResult>> ListSoaRecordNextPageAsync(string nextLink, string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeNextPageRequest(nextLink, "Soa".ToDnsRecordType(), subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SoaRecordListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = SoaRecordListResult.DeserializeSoaRecordListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        #endregion

        #region SrvRecordData Operation

        /// <summary> Updates a record set within a DNS zone. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the Update operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="relativeRecordSetName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<SrvRecordData>> UpdateAsync(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, SrvRecordData data, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateUpdateRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName, data, ifMatch);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SrvRecordData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = SrvRecordData.DeserializeSrvRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Updates a record set within a DNS zone. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the Update operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="relativeRecordSetName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<SrvRecordData> Update(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, SrvRecordData data, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateUpdateRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName, data, ifMatch);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SrvRecordData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = SrvRecordData.DeserializeSrvRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Creates or updates a record set within a DNS zone. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. Record sets of type SOA can be updated but not created (they are created when the DNS zone is created). </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to &apos;*&apos; to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="relativeRecordSetName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<SrvRecordData>> CreateOrUpdateAsync(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, SrvRecordData data, ETag? ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateOrUpdateRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName, data, ifMatch, ifNoneMatch);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    {
                        SrvRecordData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = SrvRecordData.DeserializeSrvRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Creates or updates a record set within a DNS zone. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. Record sets of type SOA can be updated but not created (they are created when the DNS zone is created). </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to &apos;*&apos; to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="relativeRecordSetName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<SrvRecordData> CreateOrUpdate(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, SrvRecordData data, ETag? ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateOrUpdateRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName, data, ifMatch, ifNoneMatch);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    {
                        SrvRecordData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = SrvRecordData.DeserializeSrvRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="srvRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/> or <paramref name="srvRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<SrvRecordData>> GetSrvRecordAsync(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string srvRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(srvRecordName, nameof(srvRecordName));

            using var message = CreateGetRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, srvRecordName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SrvRecordData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = SrvRecordData.DeserializeSrvRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((SrvRecordData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/> or <paramref name="relativeRecordSetName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<SrvRecordData> GetSrvRecord(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));

            using var message = CreateGetRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SrvRecordData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = SrvRecordData.DeserializeSrvRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((SrvRecordData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<SrvRecordListResult> ListSrvRecord(string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeRequest("Srv".ToDnsRecordType(), subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SrvRecordListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = SrvRecordListResult.DeserializeSrvRecordListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<SrvRecordListResult>> ListSrvRecordAsync(string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeRequest("Srv".ToDnsRecordType(), subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SrvRecordListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = SrvRecordListResult.DeserializeSrvRecordListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<SrvRecordListResult> ListSrvRecordNextPage(string nextLink, string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeNextPageRequest(nextLink, "Srv".ToDnsRecordType(), subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SrvRecordListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = SrvRecordListResult.DeserializeSrvRecordListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<SrvRecordListResult>> ListSrvRecordNextPageAsync(string nextLink, string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeNextPageRequest(nextLink, "Srv".ToDnsRecordType(), subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SrvRecordListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = SrvRecordListResult.DeserializeSrvRecordListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        #endregion

        #region TxtRecordData Operation

        /// <summary> Updates a record set within a DNS zone. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the Update operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="relativeRecordSetName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<TxtRecordData>> UpdateAsync(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, TxtRecordData data, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateUpdateRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName, data, ifMatch);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        TxtRecordData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = TxtRecordData.DeserializeTxtRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Updates a record set within a DNS zone. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the Update operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="relativeRecordSetName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<TxtRecordData> Update(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, TxtRecordData data, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateUpdateRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName, data, ifMatch);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        TxtRecordData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = TxtRecordData.DeserializeTxtRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Creates or updates a record set within a DNS zone. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. Record sets of type SOA can be updated but not created (they are created when the DNS zone is created). </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to &apos;*&apos; to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="relativeRecordSetName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<TxtRecordData>> CreateOrUpdateAsync(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, TxtRecordData data, ETag? ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateOrUpdateRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName, data, ifMatch, ifNoneMatch);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    {
                        TxtRecordData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = TxtRecordData.DeserializeTxtRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Creates or updates a record set within a DNS zone. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. Record sets of type SOA can be updated but not created (they are created when the DNS zone is created). </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to &apos;*&apos; to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="relativeRecordSetName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<TxtRecordData> CreateOrUpdate(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, TxtRecordData data, ETag? ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateOrUpdateRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName, data, ifMatch, ifNoneMatch);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    {
                        TxtRecordData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = TxtRecordData.DeserializeTxtRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/> or <paramref name="relativeRecordSetName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<TxtRecordData>> GetTxtRecordAsync(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));

            using var message = CreateGetRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        TxtRecordData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = TxtRecordData.DeserializeTxtRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((TxtRecordData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/> or <paramref name="relativeRecordSetName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<TxtRecordData> GetTxtRecord(DnsRecordType dnsRecordType, string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));

            using var message = CreateGetRequest(dnsRecordType, subscriptionId, resourceGroupName, zoneName, relativeRecordSetName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        TxtRecordData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = TxtRecordData.DeserializeTxtRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((TxtRecordData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<TxtRecordListResult> ListTxtRecord(string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeRequest("Txt".ToDnsRecordType(), subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        TxtRecordListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = TxtRecordListResult.DeserializeTxtRecordListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<TxtRecordListResult>> ListTxtRecordAsync(string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeRequest("Txt".ToDnsRecordType(), subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        TxtRecordListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = TxtRecordListResult.DeserializeTxtRecordListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<TxtRecordListResult> ListTxtRecordNextPage(string nextLink, string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeNextPageRequest(nextLink, "Txt".ToDnsRecordType(), subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        TxtRecordListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = TxtRecordListResult.DeserializeTxtRecordListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists the record sets of a specified type in a DNS zone. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<TxtRecordListResult>> ListTxtRecordNextPageAsync(string nextLink, string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeNextPageRequest(nextLink, "Txt".ToDnsRecordType(), subscriptionId, resourceGroupName, zoneName, top, recordsetnamesuffix);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        TxtRecordListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = TxtRecordListResult.DeserializeTxtRecordListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        #endregion
    }
}
