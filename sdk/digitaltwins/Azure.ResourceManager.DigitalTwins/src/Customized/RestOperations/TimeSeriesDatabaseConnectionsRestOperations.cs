// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;
using Azure.ResourceManager.DigitalTwins.Models;
using System.Threading.Tasks;
using System.Threading;

namespace Azure.ResourceManager.DigitalTwins
{
    internal partial class TimeSeriesDatabaseConnectionsRestOperations
    {
        /// <summary> Delete a time series database connection. </summary>
        /// <param name="subscriptionId"> The subscription identifier. </param>
        /// <param name="resourceGroupName"> The name of the resource group that contains the DigitalTwinsInstance. </param>
        /// <param name="resourceName"> The name of the DigitalTwinsInstance. </param>
        /// <param name="timeSeriesDatabaseConnectionName"> Name of time series database connection. </param>
        /// <param name="cleanupConnectionArtifacts"> Specifies whether or not to attempt to clean up artifacts that were created in order to establish a connection to the time series database. This is a best-effort attempt that will fail if appropriate permissions are not in place. Setting this to &apos;true&apos; does not delete any recorded data. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="resourceName"/> or <paramref name="timeSeriesDatabaseConnectionName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="resourceName"/> or <paramref name="timeSeriesDatabaseConnectionName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<TimeSeriesDatabaseConnectionData>> DeleteAsync(string subscriptionId, string resourceGroupName, string resourceName, string timeSeriesDatabaseConnectionName, CleanupConnectionArtifact? cleanupConnectionArtifacts = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));
            Argument.AssertNotNullOrEmpty(timeSeriesDatabaseConnectionName, nameof(timeSeriesDatabaseConnectionName));

            TimeSeriesDatabaseConnectionData data = Get(subscriptionId, resourceGroupName, resourceName, timeSeriesDatabaseConnectionName, cancellationToken).Value;

            using var message = CreateDeleteRequest(subscriptionId, resourceGroupName, resourceName, timeSeriesDatabaseConnectionName, cleanupConnectionArtifacts);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return Response.FromValue(data, message.Response);
                case 202:
                    return Response.FromValue(data, message.Response);
                case 204:
                    return Response.FromValue(data, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Delete a time series database connection. </summary>
        /// <param name="subscriptionId"> The subscription identifier. </param>
        /// <param name="resourceGroupName"> The name of the resource group that contains the DigitalTwinsInstance. </param>
        /// <param name="resourceName"> The name of the DigitalTwinsInstance. </param>
        /// <param name="timeSeriesDatabaseConnectionName"> Name of time series database connection. </param>
        /// <param name="cleanupConnectionArtifacts"> Specifies whether or not to attempt to clean up artifacts that were created in order to establish a connection to the time series database. This is a best-effort attempt that will fail if appropriate permissions are not in place. Setting this to &apos;true&apos; does not delete any recorded data. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="resourceName"/> or <paramref name="timeSeriesDatabaseConnectionName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="resourceName"/> or <paramref name="timeSeriesDatabaseConnectionName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<TimeSeriesDatabaseConnectionData> Delete(string subscriptionId, string resourceGroupName, string resourceName, string timeSeriesDatabaseConnectionName, CleanupConnectionArtifact? cleanupConnectionArtifacts = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));
            Argument.AssertNotNullOrEmpty(timeSeriesDatabaseConnectionName, nameof(timeSeriesDatabaseConnectionName));

            TimeSeriesDatabaseConnectionData data = Get(subscriptionId, resourceGroupName, resourceName, timeSeriesDatabaseConnectionName, cancellationToken).Value;

            using var message = CreateDeleteRequest(subscriptionId, resourceGroupName, resourceName, timeSeriesDatabaseConnectionName, cleanupConnectionArtifacts);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return Response.FromValue(data, message.Response);
                case 202:
                    return Response.FromValue(data, message.Response);
                case 204:
                    return Response.FromValue(data, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
