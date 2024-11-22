// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Event backlog that saves event for cases where events arrive earlier than the response of the method call.
    /// </summary>
    internal class EventBacklog
    {
        private const int DEFAULT_TIMEOUT = 5;
        private const int MAXIMUM_EVENTBACKLOGS_AT_ONCE = 10000;

        private TimeSpan _expiringTimeout;

        private ConcurrentDictionary<string, (CallAutomationEventBase, Timer)> _eventBacklog;

        internal EventBacklog(TimeSpan defaultExpiringTimeout = default)
        {
            _expiringTimeout = defaultExpiringTimeout == default ? TimeSpan.FromSeconds(DEFAULT_TIMEOUT) : defaultExpiringTimeout;
            _eventBacklog = new ConcurrentDictionary<string, (CallAutomationEventBase, Timer)>();
        }

        /// <summary>
        /// Adds event to EventsBacklog to be retrieved.
        /// </summary>
        /// <param name="backlogEventId">Internally used id for tracking the saved event.</param>
        /// <param name="eventsToBeSaved">Incoming Event to be saved.</param>
        /// <returns>Returns True if adding event is successful. False otherwise.</returns>
        internal bool TryAddEvent(string backlogEventId, CallAutomationEventBase eventsToBeSaved)
        {
            if (_eventBacklog.Count < MAXIMUM_EVENTBACKLOGS_AT_ONCE)
            {
                // Set Timer for this events. Expires after awhile and deletes itself from the Dictionary.
                var expiringTimer = new Timer(new TimerCallback(TimerProc), backlogEventId, (int)_expiringTimeout.TotalMilliseconds, 0);

                return _eventBacklog.TryAdd(backlogEventId, (eventsToBeSaved, expiringTimer));
            }
            else
            {
                return false;
            }
        }

        internal bool TryGetAndRemoveEvent(Func<CallAutomationEventBase, bool> predicate, out KeyValuePair<string, CallAutomationEventBase> matchingEvent)
        {
            // Match any event that matches in the events backlog
            var matchingKvp = _eventBacklog.FirstOrDefault(kvp => predicate(kvp.Value.Item1));
            matchingEvent = default;

            // Try remove the item - if successful, return it as keyValuePair
            if (matchingKvp.Key != default && _eventBacklog.TryRemove(matchingKvp.Key, out var returnedValue))
            {
                matchingEvent = new KeyValuePair<string, CallAutomationEventBase>(matchingEvent.Key, returnedValue.Item1);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Remove the event by Id.
        /// </summary>
        /// <param name="internalEventId">Key of the event in events backlog.</param>
        /// <returns>Returns True if removing event is successful. False otherwise.</returns>
        internal bool TryRemoveEvent(string internalEventId) => _eventBacklog.TryRemove(internalEventId, out _);

        /// <summary>
        /// When timer procs, it will remove itself from the dictionary.
        /// </summary>
        /// <param name="state">Key of the event in events backlog.</param>
        private void TimerProc(object state)
        {
            var internalEventId = (string)state;
            _ = _eventBacklog.TryRemove(internalEventId, out _);
        }
    }
}
