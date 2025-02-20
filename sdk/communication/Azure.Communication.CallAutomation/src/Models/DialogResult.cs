// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Communication.CallAutomation
{
    /// <summary>DialogResult</summary>
    public class DialogResult
    {
        private CallAutomationEventProcessor _evHandler;
        private string _callConnectionId;
        private string _operationContext;
        internal DialogResult(string dialogId)
        {
            DialogId = dialogId;
        }

        internal void SetEventProcessor(CallAutomationEventProcessor evHandler, string callConnectionId, string operationContext)
        {
            _evHandler = evHandler;
            _callConnectionId = callConnectionId;
            _operationContext = operationContext;
        }

        /// <summary> Dialog ID </summary>
        public string DialogId { get; }

        /// <summary>
        /// Wait for <see cref="DialogEventResult"/> using <see cref="CallAutomationEventProcessor"/>.
        /// </summary>
        /// <returns>Returns <see cref="DialogEventResult"/> which contains either <see cref="DialogCompleted"/> event, <see cref="DialogConsent"/> event, <see cref="DialogFailed"/> event, <see cref="DialogHangup"/> event, <see cref="DialogStarted"/> event, <see cref="DialogTransfer"/>, <see cref="DialogSensitivityUpdate"/>, <see cref="DialogLanguageChange"/>, <see cref="DialogUpdated"/> event.</returns>
        public DialogEventResult WaitForEventProcessor(CancellationToken cancellationToken = default)
        {
            if (_evHandler is null)
            {
                throw new NullReferenceException(nameof(_evHandler));
            }

            var returnedEvent = _evHandler.WaitForEventProcessor(filter
                => filter.CallConnectionId == _callConnectionId
                && (filter.OperationContext == _operationContext || _operationContext is null)
                && (filter.GetType() == typeof(DialogCompleted)
                || filter.GetType() == typeof(DialogConsent)
                || filter.GetType() == typeof(DialogFailed)
                || filter.GetType() == typeof(DialogHangup)
                || filter.GetType() == typeof(DialogStarted)
                || filter.GetType() == typeof(DialogTransfer)
                || filter.GetType() == typeof(DialogSensitivityUpdate)
                || filter.GetType() == typeof(DialogLanguageChange)
                || filter.GetType() == typeof(DialogUpdated)),
                cancellationToken);

            return SetReturnedEvent(returnedEvent);
        }

        /// <summary>
        /// Wait for <see cref="DialogEventResult"/> using <see cref="CallAutomationEventProcessor"/>.
        /// </summary>
        /// <returns>Returns <see cref="DialogEventResult"/> which contains either <see cref="DialogCompleted"/> event, <see cref="DialogConsent"/> event, <see cref="DialogFailed"/> event, <see cref="DialogHangup"/> event, <see cref="DialogStarted"/> event, <see cref="DialogTransfer"/>, <see cref="DialogSensitivityUpdate"/>, <see cref="DialogLanguageChange"/>, <see cref="DialogUpdated"/> event.</returns>
        public async Task<DialogEventResult> WaitForEventProcessorAsync(CancellationToken cancellationToken = default)
        {
            if (_evHandler is null)
            {
                throw new NullReferenceException(nameof(_evHandler));
            }

            var returnedEvent = await _evHandler.WaitForEventProcessorAsync(filter
                => filter.CallConnectionId == _callConnectionId
                && (filter.OperationContext == _operationContext || _operationContext is null)
                && (filter.GetType() == typeof(DialogCompleted)
                || filter.GetType() == typeof(DialogConsent)
                || filter.GetType() == typeof(DialogFailed)
                || filter.GetType() == typeof(DialogHangup)
                || filter.GetType() == typeof(DialogStarted)
                || filter.GetType() == typeof(DialogTransfer)
                || filter.GetType() == typeof(DialogSensitivityUpdate)
                || filter.GetType() == typeof(DialogLanguageChange)
                || filter.GetType() == typeof(DialogUpdated)),
                cancellationToken).ConfigureAwait(false);

            return SetReturnedEvent(returnedEvent);
        }

        private static DialogEventResult SetReturnedEvent(CallAutomationEventBase returnedEvent)
        {
            DialogEventResult result = default;
            switch (returnedEvent)
            {
                case DialogCompleted:
                    result = new DialogEventResult(true, (DialogCompleted)returnedEvent, null, null, null, null, null, null, null, null);
                    break;
                case DialogConsent:
                    result = new DialogEventResult(true, null, (DialogConsent)returnedEvent, null, null, null, null, null, null, null);
                    break;
                case DialogFailed:
                    result = new DialogEventResult(false, null, null, (DialogFailed)returnedEvent, null, null, null, null, null, null);
                    break;
                case DialogHangup:
                    result = new DialogEventResult(true, null, null, null, (DialogHangup)returnedEvent, null, null, null, null, null);
                    break;
                case DialogStarted:
                    result = new DialogEventResult(true, null, null, null, null, (DialogStarted)returnedEvent, null, null, null, null);
                    break;
                case DialogTransfer:
                    result = new DialogEventResult(true, null, null, null, null, null, (DialogTransfer)returnedEvent, null, null, null);
                    break;
                case DialogSensitivityUpdate:
                    result = new DialogEventResult(true, null, null, null, null, null, null, (DialogSensitivityUpdate)returnedEvent, null, null);
                    break;
                case DialogLanguageChange:
                    result = new DialogEventResult(true, null, null, null, null, null, null, null, (DialogLanguageChange)returnedEvent, null);
                    break;
                case DialogUpdated:
                    result = new DialogEventResult(true, null, null, null, null, null, null, null, null, (DialogUpdated)returnedEvent);
                    break;
                default:
                    throw new NotSupportedException(returnedEvent.GetType().Name);
            }

            return result;
        }
    }
}
