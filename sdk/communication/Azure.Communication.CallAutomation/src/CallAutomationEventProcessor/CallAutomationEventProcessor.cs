// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Azure.Messaging;
using System.Linq;
using System.Collections.Concurrent;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Call Automation's EventProcessor for incoming events for ease of use.
    /// </summary>
    public class CallAutomationEventProcessor
    {
        private EventBacklog _eventBacklog;
        private ConcurrentDictionary<(string, Type), EventHandler<EventProcessorArgs>> _ongoingEvents;
        private event EventHandler<EventProcessorArgs> _eventReceived;

        internal CallAutomationEventProcessor()
        {
            _eventBacklog = new EventBacklog();
            _ongoingEvents = new ConcurrentDictionary<(string, Type), EventHandler<EventProcessorArgs>>();
        }

        /// <summary>
        /// Process incoming events. Pass incoming events to get it processed to have other method like WaitForEventProcessor to function.
        /// </summary>
        /// <param name="events">Incoming CloudEvent object.</param>
        public void ProcessEvents(IEnumerable<CloudEvent> events)
        {
            var receivedEvent = CallAutomationEventParser.ParseMany(events.ToArray());
            ProcessEvents(receivedEvent);
        }

        /// <summary>
        /// Process incoming events. Pass incoming events to get it processed to have other method like WaitForEventProcessor to function.
        /// </summary>
        /// <param name="events">Incoming <see cref="CallAutomationEventBase"/>.</param>
        public void ProcessEvents(IEnumerable<CallAutomationEventBase> events)
        {
            // Note: There will always be only 1 event coming from the service
            CallAutomationEventBase receivedEvent = events.FirstOrDefault();

            if (receivedEvent != null)
            {
                string internalEventId = Guid.NewGuid().ToString();
                _ = _eventBacklog.TryAddEvent(internalEventId, receivedEvent);

                var handlers = Interlocked.CompareExchange(ref _eventReceived, null, null);
                if (handlers != null)
                {
                    // Invoke all handlers registered to Event Handler
                    var args = new EventProcessorArgs
                    {
                        EventArgsId = internalEventId,
                        CallAutomationEvent = receivedEvent
                    };
                    handlers(this, args);
                }

                // If this call is disconnect, remove all related items in memory
                if (receivedEvent is CallDisconnected)
                {
                    // remove from eventsbacklog
                    _eventBacklog.TryRemoveEvent(internalEventId);

                    // remove from ongoingevent list
                    RemoveFromOngoingEvent(receivedEvent.CallConnectionId);
                }
            }
        }

        /// <summary>
        /// Attach Ongoing EventProcessor for specific event.
        /// </summary>
        /// <typeparam name="TEvent">Call Automation Event Type.</typeparam>
        /// <param name="callConnectionId">CallConnectionId of the call.</param>
        /// <param name="eventProcessor">EventProcessor to be fired when the specified event arrives.</param>
        public void AttachOngoingEventProcessor<TEvent>(string callConnectionId, Action<TEvent> eventProcessor) where TEvent : CallAutomationEventBase
        {
            var ongoingAwaiter = new EventAwaiterOngoing<TEvent>(callConnectionId, eventProcessor);
            EventHandler<EventProcessorArgs> handler = (o, arg) => ongoingAwaiter.OnEventReceived(o, arg);

            // On new addition, add it to the dictionary
            // On update, update the last eventProcessor with new eventProcessor
            _ongoingEvents.AddOrUpdate((callConnectionId, typeof(TEvent)), handler, (key, oldValue) => handler);
            _eventReceived += handler;
        }

        /// <summary>
        /// Detach Ongoing EventProcessor for specific event.
        /// </summary>
        /// <typeparam name="TEvent">Call Automation Event Type.</typeparam>
        /// <param name="callConnectionId">CallConnectionId of the call.</param>
        public void DetachOngoingEventProcessor<TEvent>(string callConnectionId) where TEvent : CallAutomationEventBase
        {
            RemoveFromOngoingEvent(callConnectionId, typeof(TEvent));
        }

        /// <summary>
        /// Wait for matching incoming event. This is blocking Call. Returns the <see cref="CallAutomationEventBase"/> once it arrives in ProcessEvent method.
        /// </summary>
        /// <param name="predicate">Predicate for waiting on event.</param>
        /// <param name="cancellationToken">Cancellation Token can be used to set timeout or cancel this WaitForEventProcessor.</param>
        /// <returns>Returns <see cref="CallAutomationEventBase"/> once matching event arrives.</returns>
        public CallAutomationEventBase WaitForEventProcessor(Func<CallAutomationEventBase, bool> predicate, CancellationToken cancellationToken = default)
        {
            // Initialize awaiter and get event handler of it
            var awaiter = new EventAwaiter(predicate, cancellationToken);
            EventHandler<EventProcessorArgs> handler = (o, arg) => awaiter.OnEventReceived(o, arg);

            try
            {
                // Register eventhandler
                _eventReceived += handler;

                // See if events have arrived earlier and saved in backlog
                if (_eventBacklog.TryGetAndRemoveEvent(predicate, out var backlogEvent))
                {
                    _eventReceived -= handler;
                    awaiter.Dispose();
                    return backlogEvent.Value;
                }
                else
                {
                    // blocking call
                    // Wait for incoming event until timeout exception is arised from awaiter
                    var matchingEvent = awaiter.taskSource.Task;
                    matchingEvent.Wait(cancellationToken);

                    // Matching event found. Remove from EventProcessor & Backlogs
                    _eventReceived -= handler;
                    awaiter.Dispose();
                    _eventBacklog.TryRemoveEvent(matchingEvent.Result.EventArgsId);

                    return matchingEvent.Result.CallAutomationEvent;
                }
            }
            catch (Exception)
            {
                _eventReceived -= handler;
                awaiter.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Wait for matching incoming event. This is blocking Call. Returns the <see cref="CallAutomationEventBase"/> once it arrives in ProcessEvent method.
        /// </summary>
        /// <typeparam name="TEvent">Matching event type.</typeparam>
        /// <param name="connectionId">CallConnectionId of the call.</param>
        /// <param name="operationContext">OperationContext of the method.</param>
        /// <param name="cancellationToken">Cancellation Token can be used to set timeout or cancel this WaitForEventProcessor.</param>
        /// <returns>Returns the event once matching event arrives.</returns>
        public TEvent WaitForEventProcessor<TEvent>(string connectionId = default, string operationContext = default, CancellationToken cancellationToken = default) where TEvent : CallAutomationEventBase
            => (TEvent)WaitForEventProcessor(predicate
                => (predicate.CallConnectionId == connectionId || connectionId is null)
                && (predicate.OperationContext == operationContext || operationContext is null)
                && predicate is TEvent,
                cancellationToken);

        /// <summary>
        /// Wait for matching incoming event. Returns the <see cref="CallAutomationEventBase"/> once it arrives in ProcessEvent method.
        /// </summary>
        /// <param name="predicate">Predicate for waiting on event.</param>
        /// <param name="cancellationToken">Cancellation Token can be used to set timeout or cancel this WaitForEventProcessor.</param>
        /// <returns>Returns <see cref="CallAutomationEventBase"/> once matching event arrives.</returns>
        public async Task<CallAutomationEventBase> WaitForEventProcessorAsync(Func<CallAutomationEventBase, bool> predicate, CancellationToken cancellationToken = default)
        {
            // Initialize awaiter and get event handler of it
            var awaiter = new EventAwaiter(predicate, cancellationToken);
            EventHandler<EventProcessorArgs> handler = (o, arg) => awaiter.OnEventReceived(o, arg);

            try
            {
                // Register eventhandler
                _eventReceived += handler;

                // See if events have arrived earlier and saved in backlog
                if (_eventBacklog.TryGetAndRemoveEvent(predicate, out var backlogEvent))
                {
                    _eventReceived -= handler;
                    awaiter.Dispose();
                    return backlogEvent.Value;
                }
                else
                {
                    // Wait for incoming event until timeout exception is arised from awaiter
                    var matchingEvent = await awaiter.taskSource.Task.ConfigureAwait(false);

                    // Matching event found. Remove from EventProcessor & Backlogs
                    _eventReceived -= handler;
                    awaiter.Dispose();
                    _eventBacklog.TryRemoveEvent(matchingEvent.EventArgsId);

                    return matchingEvent.CallAutomationEvent;
                }
            }
            catch (Exception)
            {
                _eventReceived -= handler;
                awaiter.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Wait for matching incoming event. Returns the <see cref="CallAutomationEventBase"/> once it arrives in ProcessEvent method.
        /// </summary>
        /// <typeparam name="TEvent">Matching event type.</typeparam>
        /// <param name="connectionId">CallConnectionId of the call.</param>
        /// <param name="operationContext">OperationContext of the method.</param>
        /// <param name="cancellationToken">Cancellation Token can be used to set timeout or cancel this WaitForEventProcessor.</param>
        /// <returns>Returns the event once matching event arrives.</returns>
        public async Task<TEvent> WaitForEventProcessorAsync<TEvent>(string connectionId = default, string operationContext = default, CancellationToken cancellationToken = default) where TEvent : CallAutomationEventBase
            => (TEvent)await WaitForEventProcessorAsync(predicate
                => (predicate.CallConnectionId == connectionId || connectionId is null)
                && (predicate.OperationContext == operationContext || operationContext is null)
                && predicate is TEvent,
                cancellationToken).ConfigureAwait(false);

        private void RemoveFromOngoingEvent(string callConnectionId, Type eventType = null)
        {
            if (eventType == null)
            {
                // Remove all matching connectionId
                var keysToRemove = _ongoingEvents.Keys.Where(key => key.Item1 == callConnectionId).ToList();
                keysToRemove.ForEach(key =>
                {
                    if (_ongoingEvents.TryRemove(key, out var handler))
                    {
                        _eventReceived -= handler;
                    }
                });
            }
            else
            {
                if (_ongoingEvents.TryRemove((callConnectionId, eventType), out var handler))
                {
                    _eventReceived -= handler;
                }
            }
        }
    }
}
