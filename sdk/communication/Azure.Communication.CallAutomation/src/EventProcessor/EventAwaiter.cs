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

        private Func<CallAutomationEventBase, bool> _predicate;

        private bool _disposed;

        internal TaskCompletionSource<EventProcessorArgs> taskSource { get; }
        internal Action<object, EventProcessorArgs> OnEventReceived => OnEventsReceived;

        internal EventAwaiter(Func<CallAutomationEventBase, bool> predicate, TimeSpan defaultTimeout)
        {
            // With constructor, define predicate that matches the condition given.
            _predicate = predicate;
            _exceptionTimeout = defaultTimeout;

            // Timer is required for this eventawaiter to throw timeout exception on no events received
            _expiringTimer = new Timer(new TimerCallback(TimerProc));
            _expiringTimer.Change((int)_exceptionTimeout.TotalMilliseconds, 0);

            taskSource = new TaskCompletionSource<EventProcessorArgs>(TaskCreationOptions.RunContinuationsAsynchronously);
        }

        private void OnEventsReceived(object sender, EventProcessorArgs e)
        {
            // See if events sent matches filter set on constructor.
            if (_predicate(e.CallAutomationEvent))
            {
                // Dispose expiring timer, as we don't want timer activating.
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
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _expiringTimer.Dispose();
            }

            _disposed = true;
        }
    }
}
