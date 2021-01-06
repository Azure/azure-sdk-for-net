// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Azure.Core.Pipeline;
using Azure.MixedReality.Authentication;
using Azure.MixedReality.RemoteRendering.Models;
using Azure.Core;

namespace Azure.MixedReality.RemoteRendering
{
    /// <summary>
    /// The client to use for interacting with the Azure Remote Rendering.
    /// </summary>
    public class RemoteRenderingClient
    {
        private readonly Guid _accountId;

        private readonly ClientDiagnostics _clientDiagnostics;

        private readonly HttpPipeline _pipeline;

        private readonly MixedRealityRemoteRenderingRestClient _restClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteRenderingClient"/> class.
        /// </summary>
        public RemoteRenderingClient(string accountId)
            : this(accountId, new RemoteRenderingClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteRenderingClient"/> class.
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="options">The options.</param>
        public RemoteRenderingClient(string accountId, RemoteRenderingClientOptions options)
        {
            _accountId = new Guid(accountId);
            _clientDiagnostics = new ClientDiagnostics(options);
            // TODO auth details.
            _pipeline = new HttpPipeline();
            _restClient = new MixedRealityRemoteRenderingRestClient(_clientDiagnostics, _pipeline);
        }

#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

        /// <summary> Initializes a new instance of RemoteRenderingClient for mocking. </summary>
        protected RemoteRenderingClient()
        {
        }

#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

        /// <summary>
        /// Creates a conversion using an asset stored in an Azure Blob Storage account.
        /// If the remote rendering account has been linked with the storage account no Shared Access Signatures (storageContainerReadListSas, storageContainerWriteSas) for storage access need to be provided.
        /// Documentation how to link your Azure Remote Rendering account with the Azure Blob Storage account can be found in the [documentation](https://docs.microsoft.com/azure/remote-rendering/how-tos/create-an-account#link-storage-accounts).
        /// All files in the input container starting with the blobPrefix will be retrieved to perform the conversion. To cut down on conversion times only necessary files should be available under the blobPrefix.
        /// .
        /// </summary>
        /// <param name="conversionId"> An ID uniquely identifying the conversion for the given account. The ID is case sensitive, can contain any combination of alphanumeric characters including hyphens and underscores, and cannot contain more than 256 characters. </param>
        /// <param name="settings"> The settings for an asset conversion. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="conversionId"/> or <paramref name="settings"/> is null. </exception>
        public Response<Conversion> CreateConversion(string conversionId, ConversionSettings settings, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RemoteRenderingClient)}.{nameof(CreateConversion)}");
            // TODO Add some attributes?
            //scope.AddAttribute(nameof(headerOptions.ClientRequestId), headerOptions.ClientRequestId);
            scope.Start();

            try
            {
                ResponseWithHeaders<object, MixedRealityRemoteRenderingCreateConversionHeaders> response = _restClient.CreateConversion(_accountId, conversionId, new ConversionRequest(settings), cancellationToken);

                switch (response.Value)
                {
                    case Conversion c:
                        return ResponseWithHeaders.FromValue(c, response.Headers, response.GetRawResponse());
                    case ErrorResponse e:
                        // TODO e.Error.Details
                        // TODO e.Error.InnerError
                        throw _clientDiagnostics.CreateRequestFailedException(response, e.Error.Message, e.Error.Code);
                    case null:
                    default:
                        throw _clientDiagnostics.CreateRequestFailedException(response);
                }
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
