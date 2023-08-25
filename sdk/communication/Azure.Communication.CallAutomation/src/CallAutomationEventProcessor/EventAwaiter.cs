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
        private const int DEFAULT_EVENT_EXPIRATION_SECONDS = 240;
        private readonly CancellationToken _cancellationToken;

        private Func<CallAutomationEventBase, bool> _predicate;

        private bool _disposed;

        internal TaskCompletionSource<EventProcessorArgs> taskSource { get; }
        internal Action<object, EventProcessorArgs> OnEventReceived => OnEventsReceived;

        internal EventAwaiter(Func<CallAutomationEventBase, bool> predicate, CancellationToken cancellationToken)
        {
            // With constructor, define predicate that matches the condition given.
            _predicate = predicate;

            if (cancellationToken == default)
            {
                // set default timeout
                CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(DEFAULT_EVENT_EXPIRATION_SECONDS));
                _cancellationToken = cts.Token;
            }
            else
            {
                _cancellationToken = cancellationToken;
            }

            _cancellationToken.Register(OnCancellationRequested);

            taskSource = new TaskCompletionSource<EventProcessorArgs>(TaskCreationOptions.RunContinuationsAsynchronously);
        }

        private void OnEventsReceived(object sender, EventProcessorArgs e)
        {
            // See if events sent matches filter set on constructor.
            if (_predicate(e.CallAutomationEvent))
            {
                // Complete the task source with the matching event.
                taskSource.TrySetResult(e);
            }
        }

        /// <summary>
        /// When cancellation procs, throw Exception on Task completion source.
        /// </summary>
        private void OnCancellationRequested()
        {
            taskSource.TrySetException(new[] { new OperationCanceledException() });
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

            _disposed = true;
        }
    }
}
