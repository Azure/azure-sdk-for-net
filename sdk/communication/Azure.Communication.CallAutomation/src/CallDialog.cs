// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Azure.Core.Pipeline;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The Azure Communication Services Call Dialog client.
    /// </summary>
    public class CallDialog
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        internal CallDialogRestClient CallDialogRestClient;
        internal CallAutomationEventProcessor EventProcessor { get; }

        /// <summary>
        /// The call connection id.
        /// </summary>
        public virtual string CallConnectionId { get; internal set; }

        internal CallDialog(string callConnectionId, CallDialogRestClient callDialogRestClient, ClientDiagnostics clientDiagnostics, CallAutomationEventProcessor eventProcessor)
        {
            CallConnectionId = callConnectionId;
            CallDialogRestClient = callDialogRestClient;
            _clientDiagnostics = clientDiagnostics;
            EventProcessor = eventProcessor;
        }

        /// <summary>Initializes a new instance of <see cref="CallDialog"/> for mocking.</summary>
        protected CallDialog()
        {
            _clientDiagnostics = null;
            CallDialogRestClient = null;
            CallConnectionId = null;
        }

        /// <summary>
        /// Start Dialog.
        /// </summary>
        /// <param name="startDialogOptions">Configuration attributes for starting dialog.</param>
        /// <param name="cancellationToken"></param>
        /// <param name="dialogId">Dialog Id</param>
        /// <returns>Returns <see cref="DialogResult"/>, which can be used to wait for Dialog's related events.</returns>
        public virtual async Task<Response<DialogResult>> StartDialogAsync(StartDialogOptions startDialogOptions, Guid dialogId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(StartDialog)}");
            scope.Start();
            try
            {
                StartDialogRequestInternal request = CreateStartDialogRequest(startDialogOptions);

                var response = await CallDialogRestClient.StartDialogAsync
                    (CallConnectionId,
                    dialogId,
                    request,
                    cancellationToken).ConfigureAwait(false);

                var result = new DialogResult(response);
                result.SetEventProcessor(EventProcessor, CallConnectionId, request.OperationContext);

                return Response.FromValue(result, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Start Dialog.
        /// </summary>
        /// <param name="startDialogOptions">Configuration attributes for starting dialog.</param>
        /// <param name="cancellationToken"></param>
        /// <param name="dialogId">Dialog Id</param>
        /// <returns>Returns <see cref="DialogResult"/>, which can be used to wait for Dialog's related events.</returns>
        public virtual Response<DialogResult> StartDialog(StartDialogOptions startDialogOptions, Guid dialogId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(StartDialog)}");
            scope.Start();
            try
            {
                StartDialogRequestInternal request = CreateStartDialogRequest(startDialogOptions);

                var response = CallDialogRestClient.StartDialog
                    (CallConnectionId,
                    dialogId,
                    request,
                    cancellationToken);

                var result = new DialogResult(response);
                result.SetEventProcessor(EventProcessor, CallConnectionId, request.OperationContext);

                return Response.FromValue(result, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private static StartDialogRequestInternal CreateStartDialogRequest(StartDialogOptions startDialogOptions)
        {
            DialogOptionsInternal dialogOptionsInternal = new DialogOptionsInternal(CommunicationIdentifierSerializer.Serialize(startDialogOptions.TargetParticipant),
                startDialogOptions.BotAppId,
                startDialogOptions.DialogContext);
            StartDialogRequestInternal startDialogRequestInternal = new StartDialogRequestInternal(dialogOptionsInternal, startDialogOptions.DialogInputType)
            {
                OperationContext = startDialogOptions.OperationContext
            };
            return startDialogRequestInternal;
        }

        /// <summary>
        /// Stop Dialog.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="dialogId">Dialog Id</param>
        public virtual async Task<Response> StopDialogAsync(Guid dialogId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(StopDialog)}");
            scope.Start();
            try
            {
                var repeatabilityHeaders = new RepeatabilityHeaders();

                return await CallDialogRestClient.StopDialogAsync
                    (CallConnectionId,
                    dialogId,
                    cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Stop Dialog.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="dialogId">Dialog Id</param>
        public virtual Response StopDialog(Guid dialogId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallMedia)}.{nameof(StopDialog)}");
            scope.Start();
            try
            {
                var repeatabilityHeaders = new RepeatabilityHeaders();

                return CallDialogRestClient.StopDialog
                    (CallConnectionId,
                    dialogId,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
