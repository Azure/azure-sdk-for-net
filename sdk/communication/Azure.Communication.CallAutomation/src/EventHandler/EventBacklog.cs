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
        private TimeSpan _expiringTimeout;

        private ConcurrentDictionary<string, (CallAutomationEventBase, Timer)> _eventBacklog;

        internal EventBacklog(TimeSpan defaultExpiringTimeout = default)
        {
            _expiringTimeout = defaultExpiringTimeout == default ? TimeSpan.FromSeconds(5) : defaultExpiringTimeout;
            _eventBacklog = new ConcurrentDictionary<string, (CallAutomationEventBase, Timer)>();
        }

        /// <summary>
        /// Adds event to EventsBacklog to be retrieved.
        /// </summary>
        /// <param name="backlogEventId">Internally used id for tracking the saved event.</param>
        /// <param name="eventsToBeSaved">Incoming Event to be saved.</param>
        /// <returns></returns>
        internal bool AddEvent(string backlogEventId, CallAutomationEventBase eventsToBeSaved)
        {
            // Set Timer for this events. Expires after awhile and deletes itself from the Dictionary.
            var expiringTimer = new Timer(new TimerCallback(TimerProc), backlogEventId, (int)_expiringTimeout.TotalMilliseconds, 0);

            return _eventBacklog.TryAdd(backlogEventId, (eventsToBeSaved, expiringTimer));
        }

        internal bool GetAndRemoveEvent(IEnumerable<Type> eventTypes, string callConnectionId, string operationContext, out KeyValuePair<string, CallAutomationEventBase> matchingEvent)
        {
            // Match any event that matches in the events backlog
            var matchingKvp = _eventBacklog.Where(kvp
                => callConnectionId == kvp.Value.Item1.CallConnectionId
                && operationContext == kvp.Value.Item1.OperationContext
                && (!(eventTypes?.Any() ?? false) || eventTypes.Contains(kvp.Value.Item1.GetType())))
                .FirstOrDefault();

            // try remove the item - if successful, return it as keyValuePair
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
        /// <returns></returns>
        internal bool RemoveEvent(string internalEventId) => _eventBacklog.TryRemove(internalEventId, out _);

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
