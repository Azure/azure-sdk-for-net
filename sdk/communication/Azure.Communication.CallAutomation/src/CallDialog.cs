// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The Azure Communication Services Call Dialog Client.
    /// </summary>
    public class CallDialog
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        internal CallDialogRestClient CallDialogRestClient { get; }
        internal CallAutomationEventProcessor EventProcessor { get; }

        /// <summary>
        /// The call connection id.
        /// </summary>
        public virtual string CallConnectionId { get; internal set; }

        internal CallDialog(string callConnectionId, CallDialogRestClient callDialogRestClient, ClientDiagnostics clientDiagnostics, CallAutomationEventProcessor eventProcessor)
        {
            _clientDiagnostics = clientDiagnostics;
            CallDialogRestClient = callDialogRestClient;
            EventProcessor = eventProcessor;
            CallConnectionId = callConnectionId;
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
        /// <param name="StartDialog">Configuration attributes for starting dialog.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Returns <see cref="DialogResult"/>, which can be used to wait for Dialog's related events.</returns>
        public virtual async Task<Response<DialogResult>> StartDialogAsync(StartDialog StartDialog, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallDialog)}.{nameof(StartDialog)}");
            scope.Start();
            try
            {
                StartDialogRequestInternal request = CreateStartDialogRequest(StartDialog);

                var response = await CallDialogRestClient.StartDialogAsync
                    (CallConnectionId,
                    StartDialog.DialogId,
                    request,
                    cancellationToken).ConfigureAwait(false);

                var result = new DialogResult(StartDialog.DialogId);
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
        /// <param name="startDialog">Configuration attributes for starting dialog.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Returns <see cref="DialogResult"/>, which can be used to wait for Dialog's related events.</returns>
        public virtual Response<DialogResult> StartDialog(StartDialog startDialog, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallDialog)}.{nameof(StartDialog)}");
            scope.Start();
            try
            {
                StartDialogRequestInternal request = CreateStartDialogRequest(startDialog);

                var response = CallDialogRestClient.StartDialog
                    (CallConnectionId,
                    startDialog.DialogId,
                    request,
                    cancellationToken);

                var result = new DialogResult(startDialog.DialogId);
                result.SetEventProcessor(EventProcessor, CallConnectionId, request.OperationContext);

                return Response.FromValue(result, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private static StartDialogRequestInternal CreateStartDialogRequest(StartDialog startDialog)
        {
            StartDialogRequestInternal startDialogRequestInternal = new StartDialogRequestInternal(startDialog.Dialog)
            {
                OperationCallbackUri = startDialog.OperationCallbackUri,
                OperationContext = startDialog.OperationContext == default ? Guid.NewGuid().ToString() : startDialog.OperationContext
            };
            return startDialogRequestInternal;
        }

        /// <summary>
        /// Stop Dialog.
        /// </summary>
        /// <param name="dialogId"></param>
        /// <param name="operationCallbackUri"></param>
        /// <param name="cancellationToken"></param>
        public virtual async Task<Response<DialogResult>> StopDialogAsync(string dialogId, string operationCallbackUri = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallDialog)}.{nameof(StopDialog)}");
            scope.Start();
            try
            {
                var response = await CallDialogRestClient.StopDialogAsync
                    (CallConnectionId,
                    dialogId,
                    operationCallbackUri,
                    cancellationToken).ConfigureAwait(false);

                var result = new DialogResult(dialogId);
                result.SetEventProcessor(EventProcessor, CallConnectionId, null);

                return Response.FromValue(result, response);
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
        /// <param name="dialogId"></param>
        /// <param name="operationCallbackUri"></param>
        /// <param name="cancellationToken"></param>
        public virtual Response<DialogResult> StopDialog(string dialogId, string operationCallbackUri = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallDialog)}.{nameof(StopDialog)}");
            scope.Start();
            try
            {
                var response = CallDialogRestClient.StopDialog
                    (CallConnectionId,
                    dialogId,
                    operationCallbackUri,
                    cancellationToken);

                var result = new DialogResult(dialogId);
                result.SetEventProcessor(EventProcessor, CallConnectionId, null);

                return Response.FromValue(result, response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
