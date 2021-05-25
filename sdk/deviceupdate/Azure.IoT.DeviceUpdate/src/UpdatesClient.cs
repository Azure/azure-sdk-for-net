// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.IoT.DeviceUpdate.Models;

namespace Azure.IoT.DeviceUpdate
{
    /// <summary>
    /// Update management service client.
    /// </summary>
    public partial class UpdatesClient
    {
        protected UpdatesClient()
        {}

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdatesClient"/>.
        /// </summary>
        public UpdatesClient(string accountEndpoint, string instanceId, TokenCredential credential)
            : this(accountEndpoint, instanceId, credential, new DeviceUpdateClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdatesClient"/>.
        /// </summary>
        public UpdatesClient(string accountEndpoint, string instanceId, TokenCredential credential, DeviceUpdateClientOptions options)
            : this(
                new ClientDiagnostics(options),
                HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, "6ee392c4-d339-4083-b04d-6b7947c6cf78/.default")),
                accountEndpoint,
                instanceId)
        {
        }

        /// <summary> Import new update version. </summary>
        /// <param name="updateToImport"> The update to be imported. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<string>> ImportUpdateAsync(ImportUpdateInput updateToImport, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("UpdatesClient.ImportUpdate");
            scope.Start();
            try
            {
                ResponseWithHeaders<UpdatesImportUpdateHeaders> response = await RestClient.ImportUpdateAsync(updateToImport, cancellationToken).ConfigureAwait(false);
                string jobId = GetJobIdFromLocationHeader(response?.Headers?.OperationLocation);
                return Response.FromValue(jobId, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Import new update version. </summary>
        /// <param name="updateToImport"> The update to be imported. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<string> ImportUpdate(ImportUpdateInput updateToImport, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("UpdatesClient.ImportUpdate");
            scope.Start();
            try
            {
                ResponseWithHeaders<UpdatesImportUpdateHeaders> response = RestClient.ImportUpdate(updateToImport, cancellationToken);
                string jobId = GetJobIdFromLocationHeader(response?.Headers?.OperationLocation);
                return Response.FromValue(jobId, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete a specific update version. </summary>
        /// <param name="provider"> Update provider. </param>
        /// <param name="name"> Update name. </param>
        /// <param name="version"> Update version. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<string>> DeleteUpdateAsync(string provider, string name, string version, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("UpdatesClient.DeleteUpdate");
            scope.Start();
            try
            {
                ResponseWithHeaders<UpdatesDeleteUpdateHeaders> response = await RestClient.DeleteUpdateAsync(provider, name, version, cancellationToken).ConfigureAwait(false);
                string jobId = GetJobIdFromLocationHeader(response.Headers.OperationLocation);
                return Response.FromValue(jobId, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete a specific update version. </summary>
        /// <param name="provider"> Update provider. </param>
        /// <param name="name"> Update name. </param>
        /// <param name="version"> Update version. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<string> DeleteUpdate(string provider, string name, string version, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("UpdatesClient.DeleteUpdate");
            scope.Start();
            try
            {
                ResponseWithHeaders<UpdatesDeleteUpdateHeaders> response = RestClient.DeleteUpdate(provider, name, version, cancellationToken);
                string jobId = GetJobIdFromLocationHeader(response?.Headers?.OperationLocation);
                return Response.FromValue(jobId, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private static string GetJobIdFromLocationHeader(string location)
        {
            string jobId = null;
            if (location != null)
            {
                jobId = location.Substring(location.LastIndexOf("/", StringComparison.Ordinal) + 1);
            }
            return jobId;
        }
    }
}
