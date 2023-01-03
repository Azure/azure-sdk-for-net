// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallAutomation
{
    internal class EventAwaiterOngoing<TEvent> where TEvent : CallAutomationEventBase
    {
        private string _callConnectionId;
        private Action<TEvent> _eventHandler;

        internal Action<object, CallAutomationEventArgs> OnEventRecieved => OnEventsReceived;

        internal EventAwaiterOngoing(string callConnectionId, Action<TEvent> eventHandler)
        {
            _callConnectionId = callConnectionId;
            _eventHandler = eventHandler;
        }

        private void OnEventsReceived(object sender, CallAutomationEventArgs e)
        {
            if (e.callAutomationEvent is TEvent && _callConnectionId == e.callAutomationEvent.CallConnectionId)
            {
                _eventHandler.Invoke((TEvent)e.callAutomationEvent);
            }
        }
    }
}
