// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallAutomation
{
    internal class EventAwaiterOngoing<TEvent> where TEvent : CallAutomationEventBase
    {
        private string _callConnectionId;
        private Action<TEvent> _eventProcessor;

        internal Action<object, EventProcessorArgs> OnEventReceived => OnEventsReceived;

        internal EventAwaiterOngoing(string callConnectionId, Action<TEvent> eventProcessor)
        {
            _callConnectionId = callConnectionId;
            _eventProcessor = eventProcessor;
        }

        private void OnEventsReceived(object sender, EventProcessorArgs e)
        {
            if (e.CallAutomationEvent is TEvent && _callConnectionId == e.CallAutomationEvent.CallConnectionId)
            {
                _eventProcessor.Invoke((TEvent)e.CallAutomationEvent);
            }
        }
    }
}
