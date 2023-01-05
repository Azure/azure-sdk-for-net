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
    /// Call Automation's EventHandler for incoming events for ease of use.
    /// </summary>
    public class CallAutomationEventHandler
    {
        private TimeSpan _exceptionTimeout;
        private EventBacklog _eventBacklog;
        private ConcurrentDictionary<(string, Type), EventHandler<CallAutomationEventArgs>> _ongoingEvents;
        private event EventHandler<CallAutomationEventArgs> _eventReceived;

        internal CallAutomationEventHandler(EventHandlerOptions options)
        {
            _exceptionTimeout = options.TimeoutException;
            _eventBacklog = new EventBacklog();
            _ongoingEvents = new ConcurrentDictionary<(string, Type), EventHandler<CallAutomationEventArgs>>();
        }

        /// <summary>
        /// Process incoming events. Pass incoming events to get it processed to have other method like WaitForEvent to function.
        /// </summary>
        /// <param name="events">Incoming CloudEvent object.</param>
        public void ProcessEvents(IEnumerable<CloudEvent> events)
        {
            var recievedEvent = CallAutomationEventParser.ParseMany(events.ToArray());
            ProcessEvents(recievedEvent);
        }

        /// <summary>
        /// Process incoming events. Pass incoming events to get it processed to have other method like WaitForEvent to function.
        /// </summary>
        /// <param name="events">Incoming CallAutomationEventBase object.</param>
        public void ProcessEvents(IEnumerable<CallAutomationEventBase> events)
        {
            CallAutomationEventBase recievedEvent = events.FirstOrDefault();

            if (recievedEvent != null)
            {
                string internalEventId = Guid.NewGuid().ToString();
                _ = _eventBacklog.AddEvent(internalEventId, recievedEvent);

                var handlers = Interlocked.CompareExchange(ref _eventReceived, null, null);
                if (handlers != null)
                {
                    // Invoke all handlers registered to Event Handler
                    var args = new CallAutomationEventArgs
                    {
                        eventArgsId = internalEventId,
                        callAutomationEvent = recievedEvent
                    };
                    handlers(this, args);
                }

                // if this call is disconnect, remove all related items in memory
                if (recievedEvent is CallDisconnected)
                {
                    // remove from eventsbacklog
                    _eventBacklog.RemoveEvent(internalEventId);

                    // remove from ongoingevent list
                    RemoveFromOngoingEvent(recievedEvent.CallConnectionId);
                }
            }
        }

        /// <summary>
        /// Set Ongoing EventHandler for specific event.
        /// </summary>
        /// <typeparam name="TEvent">Call Automation Event Type.</typeparam>
        /// <param name="callConnectionId">CallConnectionId of the call.</param>
        /// <param name="eventHandler">EventHandler to be fired when the specified event arrives.</param>
        public void SetOngoingEventHandler<TEvent>(string callConnectionId, Action<TEvent> eventHandler) where TEvent : CallAutomationEventBase
        {
            var ongoingAwaiter = new EventAwaiterOngoing<TEvent>(callConnectionId, eventHandler);
            EventHandler<CallAutomationEventArgs> handler = (o, arg) => ongoingAwaiter.OnEventRecieved(o, arg);

            // on new addition, add it to the dictionary
            // on update, update the last eventhandler with new eventhandler
            _ongoingEvents.AddOrUpdate((callConnectionId, typeof(TEvent)), handler, (key, oldValue) => handler);
            _eventReceived += handler;
        }

        /// <summary>
        /// Unset Ongoing EventHandler for specific event.
        /// </summary>
        /// <typeparam name="TEvent">Call Automation Event Type.</typeparam>
        /// <param name="callConnectionId">CallConnectionId of the call.</param>
        public void UnsetOngoingEventHandler<TEvent>(string callConnectionId) where TEvent : CallAutomationEventBase
        {
            RemoveFromOngoingEvent(callConnectionId, typeof(TEvent));
        }

        /// <summary>
        /// Wait for any matching incoming event for the call. Returns the event once it arrives in ProcessEvent method.
        /// </summary>
        /// <param name="callConnectionId">CallConnectionId of the call.</param>
        /// <param name="operationContext">(Optional) Optional operationContext of the method call.</param>
        /// <returns>Returns CallAutomationEvent once matching event arrives.</returns>
        public async Task<CallAutomationEventBase> WaitForEvent(string callConnectionId, string operationContext = null)
            => await WaitForEvent(new List<Type> { }, callConnectionId, operationContext).ConfigureAwait(false);

        /// <summary>
        /// Wait for specific type of incoming event for the call. Returns the event once it arrives in ProcessEvent method.
        /// </summary>
        /// <typeparam name="T1">Matching CallAutomation's Event Type.</typeparam>
        /// <param name="callConnectionId">CallConnectionId of the call.</param>
        /// <param name="operationContext">(Optional) Optional operationContext of the method call.</param>
        /// <returns>Returns CallAutomationEvent once matching event arrives.</returns>
        public async Task<T1> WaitForEvent<T1>(string callConnectionId, string operationContext = null)
            where T1 : CallAutomationEventBase
            => (T1)await WaitForEvent(new List<Type> { typeof(T1) }, callConnectionId, operationContext).ConfigureAwait(false);

        /// <summary>
        /// Wait for specific types of incoming event for the call. Returns the event once it arrives in ProcessEvent method.
        /// </summary>
        /// <typeparam name="T1">Matching CallAutomation's Event Type.</typeparam>
        /// <typeparam name="T2">Matching CallAutomation's Event Type.</typeparam>
        /// <param name="callConnectionId">CallConnectionId of the call.</param>
        /// <param name="operationContext">(Optional) Optional operationContext of the method call.</param>
        /// <returns>Returns CallAutomationEvent once matching event arrives.</returns>
        public async Task<CallAutomationEventBase> WaitForEvent<T1, T2>(string callConnectionId, string operationContext = null)
            where T1 : CallAutomationEventBase
            where T2 : CallAutomationEventBase
            => await WaitForEvent(new List<Type> { typeof(T1), typeof(T2) }, callConnectionId, operationContext).ConfigureAwait(false);

        /// <summary>
        /// Wait for specific types of incoming event for the call. Returns the event once it arrives in ProcessEvent method.
        /// </summary>
        /// <typeparam name="T1">Matching CallAutomation's Event Type.</typeparam>
        /// <typeparam name="T2">Matching CallAutomation's Event Type.</typeparam>
        /// <typeparam name="T3">Matching CallAutomation's Event Type.</typeparam>
        /// <param name="callConnectionId">CallConnectionId of the call.</param>
        /// <param name="operationContext">(Optional) Optional operationContext of the method call.</param>
        /// <returns>Returns CallAutomationEvent once matching event arrives.</returns>
        public async Task<CallAutomationEventBase> WaitForEvent<T1, T2, T3>(string callConnectionId, string operationContext = null)
            where T1 : CallAutomationEventBase
            where T2 : CallAutomationEventBase
            where T3 : CallAutomationEventBase
           => await WaitForEvent(new List<Type> { typeof(T1), typeof(T2), typeof(T2) }, callConnectionId, operationContext).ConfigureAwait(false);

        /// <summary>
        /// Wait for specific types of incoming event for the call. Returns the event once it arrives in ProcessEvent method.
        /// </summary>
        /// <typeparam name="T1">Matching CallAutomation's Event Type.</typeparam>
        /// <typeparam name="T2">Matching CallAutomation's Event Type.</typeparam>
        /// <typeparam name="T3">Matching CallAutomation's Event Type.</typeparam>
        /// <typeparam name="T4">Matching CallAutomation's Event Type.</typeparam>
        /// <param name="callConnectionId">CallConnectionId of the call.</param>
        /// <param name="operationContext">(Optional) Optional operationContext of the method call.</param>
        /// <returns>Returns CallAutomationEvent once matching event arrives.</returns>
        public async Task<CallAutomationEventBase> WaitForEvent<T1, T2, T3, T4>(string callConnectionId, string operationContext = null)
            where T1 : CallAutomationEventBase
            where T2 : CallAutomationEventBase
            where T3 : CallAutomationEventBase
            where T4 : CallAutomationEventBase
            => await WaitForEvent(new List<Type> { typeof(T1), typeof(T2), typeof(T3), typeof(T4) }, callConnectionId, operationContext).ConfigureAwait(false);

        /// <summary>
        /// Wait for specific types of incoming event for the call. Returns the event once it arrives in ProcessEvent method.
        /// </summary>
        /// <typeparam name="T1">Matching CallAutomation's Event Type.</typeparam>
        /// <typeparam name="T2">Matching CallAutomation's Event Type.</typeparam>
        /// <typeparam name="T3">Matching CallAutomation's Event Type.</typeparam>
        /// <typeparam name="T4">Matching CallAutomation's Event Type.</typeparam>
        /// <typeparam name="T5">Matching CallAutomation's Event Type.</typeparam>
        /// <param name="callConnectionId">CallConnectionId of the call.</param>
        /// <param name="operationContext">(Optional) Optional operationContext of the method call.</param>
        /// <returns>Returns CallAutomationEvent once matching event arrives.</returns>
        public async Task<CallAutomationEventBase> WaitForEvent<T1, T2, T3, T4, T5>(string callConnectionId, string operationContext = null)
            where T1 : CallAutomationEventBase
            where T2 : CallAutomationEventBase
            where T3 : CallAutomationEventBase
            where T4 : CallAutomationEventBase
            where T5 : CallAutomationEventBase
            => await WaitForEvent(new List<Type> { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5) }, callConnectionId, operationContext).ConfigureAwait(false);

        private async Task<CallAutomationEventBase> WaitForEvent(IEnumerable<Type> eventTypesToWaitFor, string callConnectionId, string operationContext = null)
        {
            // initialize awaiter and get event handler of it
            var awaiter = new EventAwaiter(eventTypesToWaitFor, callConnectionId, operationContext, _exceptionTimeout);
            EventHandler<CallAutomationEventArgs> handler = (o, arg) => awaiter.OnEventRecieved(o, arg);

            try
            {
                // register event handler
                _eventReceived += handler;

                // see if events have arrived earlier and saved in backlog
                if (_eventBacklog.GetAndRemoveEvent(eventTypesToWaitFor, callConnectionId, operationContext, out var backlogEvent))
                {
                    awaiter.Dispose();
                    return backlogEvent.Value;
                }
                else
                {
                    // wait for incoming event until timeout exception is arised from awaiter.
                    var matchingEvent = await awaiter.taskSource.Task.ConfigureAwait(false);

                    // matching event found. Remove from EventHandler & Backlogs.
                    _eventReceived -= handler;
                    _eventBacklog.RemoveEvent(matchingEvent.eventArgsId);

                    return matchingEvent.callAutomationEvent;
                }
            }
            catch (Exception)
            {
                _eventReceived -= handler;
                awaiter.Dispose();
                throw;
            }
        }

        private void RemoveFromOngoingEvent(string callConnectionId, Type eventType = null)
        {
            if (eventType == null)
            {
                // remove all matching connectionId
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
                if (_ongoingEvents.TryRemove((callConnectionId, eventType.GetType()), out var handler))
                {
                    _eventReceived -= handler;
                }
            }
        }
    }
}
