// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Communication.CallAutomation
{
    internal class EventAwaiter : IDisposable
    {
        private TimeSpan _exceptionTimeout;
        private Timer _expiringTimer;

        private IEnumerable<Type> _eventTypes;
        private string _callConnectionId;
        private string _operationContext;

        internal TaskCompletionSource<CallAutomationEventArgs> taskSource { get; }
        internal Action<object, CallAutomationEventArgs> OnEventRecieved => OnEventsReceived;

        internal EventAwaiter(IEnumerable<Type> eventTypes, string callConnectionId, string operationContext, TimeSpan defaultTimeout = default)
        {
            // With constructor, define filter that matches the condition given.
            _eventTypes = eventTypes;
            _callConnectionId = callConnectionId;
            _operationContext = operationContext;
            _exceptionTimeout = defaultTimeout == default ? TimeSpan.FromSeconds(40) : defaultTimeout;

            // timer is required for this eventawaiter to throw timeout exception on no events recieved
            _expiringTimer = new Timer(new TimerCallback(TimerProc));
            _expiringTimer.Change((int)_exceptionTimeout.TotalMilliseconds, 0);

            taskSource = new TaskCompletionSource<CallAutomationEventArgs>(TaskCreationOptions.RunContinuationsAsynchronously);
        }

        private void OnEventsReceived(object sender, CallAutomationEventArgs e)
        {
            // see if events sent matches filter set on constructor.
            if ((_callConnectionId == e.callAutomationEvent.CallConnectionId
                && _operationContext == e.callAutomationEvent.OperationContext
                && (!(_eventTypes?.Any() ?? false) || _eventTypes.Contains(e.callAutomationEvent.GetType()))))
            {
                // dispose expiring timer, as we don't want timer activating.
                _expiringTimer.Dispose();

                // Complete the task source with the matching event.
                taskSource.TrySetResult(e);
            }
        }

        /// <summary>
        /// When timer procs, throw Exception on Task completion source.
        /// </summary>
        private void TimerProc(object state)
        {
            taskSource.TrySetException(new[] { new TimeoutException() });
        }

        public void Dispose()
        {
            _expiringTimer.Dispose();
        }
    }
}
