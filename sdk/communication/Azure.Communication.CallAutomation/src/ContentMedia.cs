// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The Azure Communication Services Content Client.
    /// </summary>
    public class ContentMedia
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        internal ContentRestClient ContentRestClient { get; }
        internal CallAutomationEventProcessor EventProcessor { get; }

        /// <summary>
        /// The call connection id.
        /// </summary>
        public virtual string CallConnectionId { get; internal set; }

        internal ContentMedia(string callConnectionId, ContentRestClient callContentRestClient, ClientDiagnostics clientDiagnostics, CallAutomationEventProcessor eventProcessor)
        {
            CallConnectionId = callConnectionId;
            ContentRestClient = callContentRestClient;
            _clientDiagnostics = clientDiagnostics;
            EventProcessor = eventProcessor;
        }

        /// <summary>Initializes a new instance of <see cref="ContentMedia"/> for mocking.</summary>
        protected ContentMedia()
        {
            _clientDiagnostics = null;
            ContentRestClient = null;
            CallConnectionId = null;
        }

        /// <summary>
        /// Send Dtmf tones in async mode.
        /// </summary>
        /// <param name="sendDtmfOptions">Configuration attributes for SendDtmf.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<SendDtmfResult>> SendDtmfAsync(SendDtmfOptions sendDtmfOptions,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContentMedia)}.{nameof(SendDtmf)}");
            scope.Start();
            try
            {
                SendDtmfRequestInternal request = CreateSendDtmfRequest(sendDtmfOptions);

                var response = await ContentRestClient.SendDtmfAsync(CallConnectionId, request, cancellationToken).ConfigureAwait(false);

                var result = new SendDtmfResult();
                result.SetEventProcessor(EventProcessor, CallConnectionId, request.OperationContext);

                return Response.FromValue(result, response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Send Dtmf tones.
        /// </summary>
        /// <param name="sendDtmfOptions">Configuration attributes for SendDtmf.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<SendDtmfResult> SendDtmf(SendDtmfOptions sendDtmfOptions,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContentMedia)}.{nameof(SendDtmf)}");
            scope.Start();
            try
            {
                SendDtmfRequestInternal request = CreateSendDtmfRequest(sendDtmfOptions);

                var response = ContentRestClient.SendDtmf(CallConnectionId, request, cancellationToken);

                var result = new SendDtmfResult();
                result.SetEventProcessor(EventProcessor, CallConnectionId, request.OperationContext);

                return Response.FromValue(result, response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private SendDtmfRequestInternal CreateSendDtmfRequest(SendDtmfOptions sendDtmfOptions)
        {
            if (sendDtmfOptions == null)
            {
                throw new ArgumentNullException(nameof(sendDtmfOptions));
            }

            SendDtmfOptionsInternal optionsInternal = new SendDtmfOptionsInternal
                (CommunicationIdentifierSerializer.Serialize(sendDtmfOptions.TargetParticipant), sendDtmfOptions.Tones);

            return new SendDtmfRequestInternal(optionsInternal);
        }
    }
}
