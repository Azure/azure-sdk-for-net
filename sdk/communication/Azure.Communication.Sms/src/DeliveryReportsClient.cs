// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.Sms.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.Sms
{
    /// <summary>
    /// The Azure Communication Services SMS Delivery Reports client.
    /// </summary>
    public class DeliveryReportsClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;

        internal DeliveryReportsRestClient DeliveryReportsRestClient;

        internal DeliveryReportsClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint, string apiVersion = "2025-08-01-preview")
        {
            Argument.CheckNotNull(clientDiagnostics, nameof(clientDiagnostics));
            Argument.CheckNotNull(pipeline, nameof(pipeline));
            Argument.CheckNotNull(endpoint, nameof(endpoint));
            Argument.CheckNotNull(apiVersion, nameof(apiVersion));

            DeliveryReportsRestClient = new DeliveryReportsRestClient(clientDiagnostics, pipeline, endpoint, apiVersion);
            _clientDiagnostics = clientDiagnostics;
        }

        /// <summary>Initializes a new instance of <see cref="DeliveryReportsClient"/> for mocking.</summary>
        protected DeliveryReportsClient()
        {
            _clientDiagnostics = null;
            DeliveryReportsRestClient = null;
        }

        /// <summary>
        /// Gets delivery report for a specific outgoing message.
        /// </summary>
        /// <param name="outgoingMessageId">The identifier of the outgoing message.</param>
        /// <param name="cancellationToken">The cancellation token for the task.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="outgoingMessageId"/> is null.</exception>
        public virtual async Task<Response<DeliveryReport>> GetAsync(string outgoingMessageId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DeliveryReportsClient)}.{nameof(Get)}");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrWhiteSpace(outgoingMessageId, nameof(outgoingMessageId));

                Response<object> response = await DeliveryReportsRestClient.GetAsync(outgoingMessageId, cancellationToken).ConfigureAwait(false);

                if (response.Value is DeliveryReport deliveryReport)
                {
                    return Response.FromValue(deliveryReport, response.GetRawResponse());
                }
                else if (response.Value is ErrorResponse error)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                else
                {
                    throw new InvalidOperationException("Unexpected response type");
                }
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets delivery report for a specific outgoing message.
        /// </summary>
        /// <param name="outgoingMessageId">The identifier of the outgoing message.</param>
        /// <param name="cancellationToken">The cancellation token for the underlying request.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="outgoingMessageId"/> is null.</exception>
        public virtual Response<DeliveryReport> Get(string outgoingMessageId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DeliveryReportsClient)}.{nameof(Get)}");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrWhiteSpace(outgoingMessageId, nameof(outgoingMessageId));

                Response<object> response = DeliveryReportsRestClient.Get(outgoingMessageId, cancellationToken);

                if (response.Value is DeliveryReport deliveryReport)
                {
                    return Response.FromValue(deliveryReport, response.GetRawResponse());
                }
                else if (response.Value is ErrorResponse error)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                else
                {
                    throw new InvalidOperationException("Unexpected response type");
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
