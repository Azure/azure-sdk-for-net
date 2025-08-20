// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using Microsoft.Azure.EventHubs.Primitives;

    /// <summary>
    /// Diagnostic extension methods for <see cref="EventData"/>.
    /// </summary>
    public static class EventDataDiagnosticExtensions
    {
        /// <summary>
        /// Creates <see cref="Activity"/> based on the tracing context stored in the <see cref="EventData"/>
        /// <param name="eventData">The event received from EventHub</param>
        /// <param name="activityName">Optional Activity name</param>
        /// <returns>New <see cref="Activity"/> with tracing context</returns>
        /// </summary>
        /// <remarks>
        /// Tracing context is used to correlate telemetry between producer and consumer and 
        /// represented by 'Diagnostic-Id' and 'Correlation-Context' properties in <see cref="EventData.Properties"/>.
        /// 
        /// .NET SDK automatically injects context when sending message to the ServiceBus (if diagnostics is enabled by tracing system).
        /// 
        /// <para>
        /// 'Diagnostic-Id' uniquely identifies operation that enqueued the event
        /// </para>
        /// <para>
        /// 'Correlation-Context' is comma separated list of string key value pairs representing optional context for the operation.
        /// </para>
        /// 
        /// If there is no tracing context in the event, this method returns <see cref="Activity"/> without parent.
        /// 
        /// Returned <see cref="Activity"/> needs to be started before it can be used (see example below)
        /// </remarks>
        /// <example>
        /// <code>
        /// async Task ProcessAsync(EventData eventData)
        /// {
        ///    var activity = eventData.ExtractActivity();
        ///    activity.Start();
        ///    Logger.LogInformation($"Event received, Id = {Activity.Current.Id}")
        ///    try 
        ///    {
        ///       // process event
        ///    }
        ///    catch (Exception ex)
        ///    {
        ///         Logger.LogError($"Exception {ex}, Id = {Activity.Current.Id}")
        ///    }
        ///    finally 
        ///    {
        ///         activity.Stop();
        ///         // Activity is stopped, we no longer have it in Activity.Current
        ///         Logger.LogInformation($"Event processed, Id = {activity.Id}, Duration = {activity.Duration}")
        ///    }
        /// }
        /// </code>
        /// 
        /// Note that every log is stamped with <see cref="Activity.Current"/>.Id, that could be used within 
        /// any nested method call (sync or async) - <see cref="Activity.Current"/> is an ambient context that flows with async method calls.
        /// 
        /// </example>

        public static Activity ExtractActivity(this EventData eventData, string activityName = null)
        {
            Guard.ArgumentNotNull(nameof(eventData), eventData);

            if (activityName == null)
            {
                activityName = EventHubsDiagnosticSource.ProcessActivityName;
            }

            var activity = new Activity(activityName);

            if (TryExtractId(eventData, out string id))
            {
                activity.SetParentId(id);

                if (eventData.TryExtractContext(out IList<KeyValuePair<string, string>> ctx))
                {
                    foreach (var kvp in ctx)
                    {
                        activity.AddBaggage(kvp.Key, kvp.Value);
                    }
                }
            }

            return activity;
        }

        internal static bool TryExtractId(this EventData eventData, out string id)
        {
            id = null;
            if (eventData.Properties.TryGetValue(EventHubsDiagnosticSource.ActivityIdPropertyName,
                out object requestId))
            {
                var tmp = requestId as string;
                if (tmp != null && tmp.Trim().Length > 0)
                {
                    id = tmp;
                    return true;
                }
            }

            return false;
        }

        internal static bool TryExtractContext(this EventData eventData, out IList<KeyValuePair<string, string>> context)
        {
            context = null;
            try
            {
                if (eventData.Properties.TryGetValue(EventHubsDiagnosticSource.CorrelationContextPropertyName,
                    out object ctxObj))
                {
                    string ctxStr = ctxObj as string;
                    if (string.IsNullOrEmpty(ctxStr))
                    {
                        return false;
                    }

                    var ctxList = ctxStr.Split(',');
                    if (ctxList.Length == 0)
                    {
                        return false;
                    }

                    context = new List<KeyValuePair<string, string>>();
                    foreach (string item in ctxList)
                    {
                        var kvp = item.Split('=');
                        if (kvp.Length == 2)
                        {
                            context.Add(new KeyValuePair<string, string>(kvp[0], kvp[1]));
                        }
                    }

                    return true;
                }
            }
            catch (Exception)
            {
                // ignored, if context is invalid, there is nothing we can do:
                // invalid context was created by producer, but if we throw here, it will break message processing on consumer
                // and consumer does not control which context it receives
            }
            return false;
        }
    }
}
