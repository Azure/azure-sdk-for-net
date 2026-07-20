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

namespace Azure.ResourceManager.Dns
{
    internal partial class DnsMXRecordRestOperations
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
        public DnsMXRecordRestOperations(HttpPipeline pipeline, string applicationId, Uri endpoint = null, string apiVersion = default)
        {
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("https://management.azure.com");
            _apiVersion = apiVersion ?? "2023-07-01-preview";
            _userAgent = new TelemetryDetails(GetType().Assembly, applicationId);
        }

        internal HttpMessage CreateUpdateRequest(string subscriptionId, string resourceGroupName, string zoneName, DnsRecordType dnsRecordType, string relativeRecordSetName, DnsMXRecordData data, ETag? ifMatch)
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

        /// <summary> Updates a record set within a DNS zone. </summary>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the Update operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="relativeRecordSetName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<DnsMXRecordData>> UpdateAsync(string subscriptionId, string resourceGroupName, string zoneName, DnsRecordType dnsRecordType, string relativeRecordSetName, DnsMXRecordData data, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateUpdateRequest(subscriptionId, resourceGroupName, zoneName, dnsRecordType, relativeRecordSetName, data, ifMatch);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DnsMXRecordData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = DnsMXRecordData.DeserializeDnsMXRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Updates a record set within a DNS zone. </summary>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the Update operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="relativeRecordSetName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<DnsMXRecordData> Update(string subscriptionId, string resourceGroupName, string zoneName, DnsRecordType dnsRecordType, string relativeRecordSetName, DnsMXRecordData data, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateUpdateRequest(subscriptionId, resourceGroupName, zoneName, dnsRecordType, relativeRecordSetName, data, ifMatch);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DnsMXRecordData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = DnsMXRecordData.DeserializeDnsMXRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateCreateOrUpdateRequest(string subscriptionId, string resourceGroupName, string zoneName, DnsRecordType dnsRecordType, string relativeRecordSetName, DnsMXRecordData data, ETag? ifMatch, string ifNoneMatch)
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

        /// <summary> Creates or updates a record set within a DNS zone. </summary>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. Record sets of type SOA can be updated but not created (they are created when the DNS zone is created). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to &apos;*&apos; to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="relativeRecordSetName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<DnsMXRecordData>> CreateOrUpdateAsync(string subscriptionId, string resourceGroupName, string zoneName, DnsRecordType dnsRecordType, string relativeRecordSetName, DnsMXRecordData data, ETag? ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateOrUpdateRequest(subscriptionId, resourceGroupName, zoneName, dnsRecordType, relativeRecordSetName, data, ifMatch, ifNoneMatch);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    {
                        DnsMXRecordData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = DnsMXRecordData.DeserializeDnsMXRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Creates or updates a record set within a DNS zone. </summary>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. Record sets of type SOA can be updated but not created (they are created when the DNS zone is created). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to &apos;*&apos; to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/>, <paramref name="relativeRecordSetName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<DnsMXRecordData> CreateOrUpdate(string subscriptionId, string resourceGroupName, string zoneName, DnsRecordType dnsRecordType, string relativeRecordSetName, DnsMXRecordData data, ETag? ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateOrUpdateRequest(subscriptionId, resourceGroupName, zoneName, dnsRecordType, relativeRecordSetName, data, ifMatch, ifNoneMatch);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    {
                        DnsMXRecordData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = DnsMXRecordData.DeserializeDnsMXRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDeleteRequest(string subscriptionId, string resourceGroupName, string zoneName, DnsRecordType dnsRecordType, string relativeRecordSetName, ETag? ifMatch)
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
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. Record sets of type SOA cannot be deleted (they are deleted when the DNS zone is deleted). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always delete the current record set. Specify the last-seen etag value to prevent accidentally deleting any concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/> or <paramref name="relativeRecordSetName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response> DeleteAsync(string subscriptionId, string resourceGroupName, string zoneName, DnsRecordType dnsRecordType, string relativeRecordSetName, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));

            using var message = CreateDeleteRequest(subscriptionId, resourceGroupName, zoneName, dnsRecordType, relativeRecordSetName, ifMatch);
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
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. Record sets of type SOA cannot be deleted (they are deleted when the DNS zone is deleted). </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always delete the current record set. Specify the last-seen etag value to prevent accidentally deleting any concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/> or <paramref name="relativeRecordSetName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response Delete(string subscriptionId, string resourceGroupName, string zoneName, DnsRecordType dnsRecordType, string relativeRecordSetName, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));

            using var message = CreateDeleteRequest(subscriptionId, resourceGroupName, zoneName, dnsRecordType, relativeRecordSetName, ifMatch);
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

        internal HttpMessage CreateGetRequest(string subscriptionId, string resourceGroupName, string zoneName, DnsRecordType dnsRecordType, string relativeRecordSetName)
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

        /// <summary> Gets a record set. </summary>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/> or <paramref name="relativeRecordSetName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<DnsMXRecordData>> GetAsync(string subscriptionId, string resourceGroupName, string zoneName, DnsRecordType dnsRecordType, string relativeRecordSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));

            using var message = CreateGetRequest(subscriptionId, resourceGroupName, zoneName, dnsRecordType, relativeRecordSetName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DnsMXRecordData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = DnsMXRecordData.DeserializeDnsMXRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((DnsMXRecordData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="dnsRecordType"> The type of DNS record in this record set. </param>
        /// <param name="relativeRecordSetName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="zoneName"/> or <paramref name="relativeRecordSetName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<DnsMXRecordData> Get(string subscriptionId, string resourceGroupName, string zoneName, DnsRecordType dnsRecordType, string relativeRecordSetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));
            Argument.AssertNotNull(relativeRecordSetName, nameof(relativeRecordSetName));

            using var message = CreateGetRequest(subscriptionId, resourceGroupName, zoneName, dnsRecordType, relativeRecordSetName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DnsMXRecordData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = DnsMXRecordData.DeserializeDnsMXRecordData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((DnsMXRecordData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateListByTypeRequest(string subscriptionId, string resourceGroupName, string zoneName, DnsRecordType dnsRecordType, int? top, string recordsetnamesuffix)
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
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="dnsRecordType"> The type of record sets to enumerate. </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<DnsMXRecordListResult>> ListByTypeAsync(string subscriptionId, string resourceGroupName, string zoneName, DnsRecordType dnsRecordType, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeRequest(subscriptionId, resourceGroupName, zoneName, dnsRecordType, top, recordsetnamesuffix);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DnsMXRecordListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = DnsMXRecordListResult.DeserializeDnsMXRecordListResult(document.RootElement);
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
        /// <param name="dnsRecordType"> The type of record sets to enumerate. </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<DnsMXRecordListResult> ListByType(string subscriptionId, string resourceGroupName, string zoneName, DnsRecordType dnsRecordType, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeRequest(subscriptionId, resourceGroupName, zoneName, dnsRecordType, top, recordsetnamesuffix);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DnsMXRecordListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = DnsMXRecordListResult.DeserializeDnsMXRecordListResult(document.RootElement);
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
        public async Task<Response<DnsMXRecordListResult>> ListByDnsZoneAsync(string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
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
                        DnsMXRecordListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = DnsMXRecordListResult.DeserializeDnsMXRecordListResult(document.RootElement);
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
        public Response<DnsMXRecordListResult> ListByDnsZone(string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
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
                        DnsMXRecordListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = DnsMXRecordListResult.DeserializeDnsMXRecordListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

#pragma warning disable CA1801 // Review unused parameters
        internal HttpMessage CreateListByTypeNextPageRequest(string nextLink, string subscriptionId, string resourceGroupName, string zoneName, DnsRecordType dnsRecordType, int? top, string recordsetnamesuffix)
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
        /// <param name="subscriptionId"> Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="dnsRecordType"> The type of record sets to enumerate. </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<DnsMXRecordListResult>> ListByTypeNextPageAsync(string nextLink, string subscriptionId, string resourceGroupName, string zoneName, DnsRecordType dnsRecordType, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeNextPageRequest(nextLink, subscriptionId, resourceGroupName, zoneName, dnsRecordType, top, recordsetnamesuffix);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DnsMXRecordListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = DnsMXRecordListResult.DeserializeDnsMXRecordListResult(document.RootElement);
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
        /// <param name="dnsRecordType"> The type of record sets to enumerate. </param>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<DnsMXRecordListResult> ListByTypeNextPage(string nextLink, string subscriptionId, string resourceGroupName, string zoneName, DnsRecordType dnsRecordType, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(zoneName, nameof(zoneName));

            using var message = CreateListByTypeNextPageRequest(nextLink, subscriptionId, resourceGroupName, zoneName, dnsRecordType, top, recordsetnamesuffix);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DnsMXRecordListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = DnsMXRecordListResult.DeserializeDnsMXRecordListResult(document.RootElement);
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
        public async Task<Response<DnsMXRecordListResult>> ListByDnsZoneNextPageAsync(string nextLink, string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
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
                        DnsMXRecordListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = DnsMXRecordListResult.DeserializeDnsMXRecordListResult(document.RootElement);
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
        public Response<DnsMXRecordListResult> ListByDnsZoneNextPage(string nextLink, string subscriptionId, string resourceGroupName, string zoneName, int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
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
                        DnsMXRecordListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = DnsMXRecordListResult.DeserializeDnsMXRecordListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
