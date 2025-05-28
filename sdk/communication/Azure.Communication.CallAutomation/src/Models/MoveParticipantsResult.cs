// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication;

namespace Azure.Communication.CallAutomation
{
    /// <summary>MoveParticipantsResult Result.</summary>
    public class MoveParticipantsResult
    {
        private CallAutomationEventProcessor _evHandler;
        private string _callConnectionId;
        private string _operationContext;

        internal MoveParticipantsResult(IReadOnlyList<CallParticipant> targetParticipants, string operationContext, string fromCall)
        {
            TargetParticipants = targetParticipants;
            OperationContext = operationContext;
            FromCall = fromCall;
        }

        internal MoveParticipantsResult(MoveParticipantsResponseInternal internalObj)
        {
            TargetParticipants = internalObj.Participants?.Select(p => new CallParticipant(p)).ToList();
            OperationContext = internalObj.OperationContext;
            FromCall = internalObj.FromCall;
        }

        /// <summary>Gets the list of participants.</summary>
        public IReadOnlyList<CallParticipant> TargetParticipants { get; }
        /// <summary>The operation context provided by client.</summary>
        public string OperationContext { get; }
        /// <summary>
        /// The invitation ID used to add the participants.
        /// </summary>
        public string FromCall { get; }

        internal void SetEventProcessor(CallAutomationEventProcessor evHandler, string callConnectionId, string operationContext)
        {
            _evHandler = evHandler;
            _callConnectionId = callConnectionId;
            _operationContext = operationContext;
        }

        /// <summary>
        /// This is blocking call. Wait for <see cref="MoveParticipantEventResult"/> using <see cref="CallAutomationEventProcessor"/>.
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token can be used to set timeout or cancel this WaitForEventProcessor.</param>
        /// <returns>Returns <see cref="MoveParticipantEventResult"/> which contains either <see cref="MoveParticipantSucceeded"/> event or <see cref="MoveParticipantFailed"/> event.</returns>
        public MoveParticipantEventResult WaitForEventProcessor(CancellationToken cancellationToken = default)
        {
            if (_evHandler is null)
            {
                throw new NullReferenceException(nameof(_evHandler));
            }

            var returnedEvent = _evHandler.WaitForEventProcessor(filter
                => filter.CallConnectionId == _callConnectionId
                && (filter.OperationContext == _operationContext || _operationContext is null)
                && (filter.GetType() == typeof(MoveParticipantSucceeded)
                || filter.GetType() == typeof(MoveParticipantFailed)),
                cancellationToken);

            return SetReturnedEvent(returnedEvent);
        }

        /// <summary>
        /// Wait for <see cref="MoveParticipantEventResult"/> using <see cref="CallAutomationEventProcessor"/>.
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token can be used to set timeout or cancel this WaitForEventProcessor.</param>
        /// <returns>Returns <see cref="MoveParticipantEventResult"/> which contains either <see cref="MoveParticipantSucceeded"/> event or <see cref="MoveParticipantFailed"/> event.</returns>
        public async Task<MoveParticipantEventResult> WaitForEventProcessorAsync(CancellationToken cancellationToken = default)
        {
            if (_evHandler is null)
            {
                throw new NullReferenceException(nameof(_evHandler));
            }

            var returnedEvent = await _evHandler.WaitForEventProcessorAsync(filter
                => filter.CallConnectionId == _callConnectionId
                && (filter.OperationContext == _operationContext || _operationContext is null)
                && (filter.GetType() == typeof(MoveParticipantSucceeded)
                || filter.GetType() == typeof(MoveParticipantFailed)),
                cancellationToken).ConfigureAwait(false);

            return SetReturnedEvent(returnedEvent);
        }

        private static MoveParticipantEventResult SetReturnedEvent(CallAutomationEventBase returnedEvent)
        {
            MoveParticipantEventResult result = default;
            switch (returnedEvent)
            {
                case MoveParticipantSucceeded succeeded:
                    result = new MoveParticipantEventResult(
                        true,
                        succeeded,
                        null,
                        succeeded.Participant);
                    break;
                case MoveParticipantFailed failed:
                    result = new MoveParticipantEventResult(
                        false,
                        null,
                        (MoveParticipantFailed)returnedEvent,
                        failed.Participant);
                    break;
                default:
                    throw new NotSupportedException(returnedEvent?.GetType().Name);
            }

            return result;
        }
    }
}
