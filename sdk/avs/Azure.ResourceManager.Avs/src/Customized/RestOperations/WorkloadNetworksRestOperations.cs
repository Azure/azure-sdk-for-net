// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Avs.Models;

namespace Azure.ResourceManager.Avs
{
    internal partial class WorkloadNetworksRestOperations
    {
        internal RequestUriBuilder CreateGetRequestUri(string subscriptionId, string resourceGroupName, string privateCloudName, WorkloadNetworkName workloadNetworkName)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.AVS/privateClouds/", false);
            uri.AppendPath(privateCloudName, true);
            uri.AppendPath("/workloadNetworks/", false);
            uri.AppendPath(workloadNetworkName.ToString(), true);
            uri.AppendQuery("api-version", _apiVersion, true);
            return uri;
        }

        internal HttpMessage CreateGetRequest(string subscriptionId, string resourceGroupName, string privateCloudName, WorkloadNetworkName workloadNetworkName)
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
            uri.AppendPath("/providers/Microsoft.AVS/privateClouds/", false);
            uri.AppendPath(privateCloudName, true);
            uri.AppendPath("/workloadNetworks/", false);
            uri.AppendPath(workloadNetworkName.ToString(), true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Get a private cloud workload network. </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. The name is case insensitive. </param>
        /// <param name="privateCloudName"> Name of the private cloud. </param>
        /// <param name="workloadNetworkName"> Name for the workload network in the private cloud. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="privateCloudName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="privateCloudName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public async Task<Response<WorkloadNetworkData>> GetAsync(string subscriptionId, string resourceGroupName, string privateCloudName, WorkloadNetworkName workloadNetworkName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(privateCloudName, nameof(privateCloudName));

            using var message = CreateGetRequest(subscriptionId, resourceGroupName, privateCloudName, workloadNetworkName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        WorkloadNetworkData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = WorkloadNetworkData.DeserializeWorkloadNetworkData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((WorkloadNetworkData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get a private cloud workload network. </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group. The name is case insensitive. </param>
        /// <param name="privateCloudName"> Name of the private cloud. </param>
        /// <param name="workloadNetworkName"> Name for the workload network in the private cloud. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="privateCloudName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="privateCloudName"/> is an empty string, and was expected to be non-empty. </exception>
       [EditorBrowsable(EditorBrowsableState.Never)]
        public Response<WorkloadNetworkData> Get(string subscriptionId, string resourceGroupName, string privateCloudName, WorkloadNetworkName workloadNetworkName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(privateCloudName, nameof(privateCloudName));

            using var message = CreateGetRequest(subscriptionId, resourceGroupName, privateCloudName, workloadNetworkName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        WorkloadNetworkData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = WorkloadNetworkData.DeserializeWorkloadNetworkData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((WorkloadNetworkData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}