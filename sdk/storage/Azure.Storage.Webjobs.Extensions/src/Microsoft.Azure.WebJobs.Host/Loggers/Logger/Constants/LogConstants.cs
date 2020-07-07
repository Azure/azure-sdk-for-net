// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


namespace Microsoft.Azure.WebJobs.Logging
{
    /// <summary>
    /// Keys used by the <see cref="ILogger"/> infrastructure.
    /// </summary>
    public static class LogConstants
    {
        /// <summary>
        /// Gets the name of the key used to store the full name of the function.
        /// </summary>
        public const string FullNameKey = "FullName";

        /// <summary>
        /// Gets the name of the key used to store the name of the function.
        /// </summary>
        public const string NameKey = "Name";

        /// <summary>
        /// Gets the name of the key used to store the number of invocations.
        /// </summary>
        public const string CountKey = "Count";

        /// <summary>
        /// Gets the name of the key used to store the success count.
        /// </summary>
        public const string SuccessesKey = "Successes";

        /// <summary>
        /// Gets the name of the key used to store the failure count.
        /// </summary>
        public const string FailuresKey = "Failures";

        /// <summary>
        /// Gets the name of the key used to store the success rate.
        /// </summary>
        public const string SuccessRateKey = "SuccessRate";

        /// <summary>
        /// Gets the name of the key used to store the average duration in milliseconds.
        /// </summary>
        public const string AverageDurationKey = "AvgDurationMs";

        /// <summary>
        /// Gets the name of the key used to store the maximum duration in milliseconds.
        /// </summary>
        public const string MaxDurationKey = "MaxDurationMs";

        /// <summary>
        /// Gets the name of the key used to store the minimum duration in milliseconds.
        /// </summary>
        public const string MinDurationKey = "MinDurationMs";

        /// <summary>
        /// Gets the name of the key used to store the timestamp.
        /// </summary>
        public const string TimestampKey = "Timestamp";

        /// <summary>
        /// Gets the name of the key used to store the function invocation id.
        /// </summary>
        public const string InvocationIdKey = "InvocationId";

        /// <summary>
        /// Gets the name of the key used to store the trigger reason.
        /// </summary>
        public const string TriggerReasonKey = "TriggerReason";

        /// <summary>
        /// Gets the name of the key used to store the start time.
        /// </summary>
        public const string StartTimeKey = "StartTime";

        /// <summary>
        /// Gets the name of the key used to store the end time.
        /// </summary>
        public const string EndTimeKey = "EndTime";

        /// <summary>
        /// Gets the name of the key used to store the duration of the function invocation.
        /// </summary>
        public const string DurationKey = "Duration";

        /// <summary>
        /// Gets the name of the key used to store whether the function succeeded.
        /// </summary>
        public const string SucceededKey = "Succeeded";

        /// <summary>
        /// Gets the name of the key used to store the formatted message.
        /// </summary>
        public const string FormattedMessageKey = "FormattedMessage";

        /// <summary>
        /// Gets the name of the key used to store the category of the log message.
        /// </summary>
        public const string CategoryNameKey = "Category";

        /// <summary>
        /// Gets the prefix for custom properties.
        /// </summary>
        public const string CustomPropertyPrefix = "prop__";

        /// <summary>
        /// Gets the prefix for parameters.
        /// </summary>
        public const string ParameterPrefix = "param__";

        /// <summary>
        /// Gets the name of the key used to store the original format of the log message.
        /// </summary>
        public const string OriginalFormatKey = "{OriginalFormat}";

        /// <summary>
        /// Gets the name of the key used to store the <see cref="LogLevel"/> of the log message.
        /// </summary>
        public const string LogLevelKey = "LogLevel";

        /// <summary>
        /// Gets the name of the key used to store the EventId of the log message.
        /// </summary>
        public const string EventIdKey = "EventId";

        /// <summary>
        /// Gets the function start event name.
        /// </summary>
        public const string FunctionStartEvent = "FunctionStart";

        /// <summary>
        /// Gets the event id for a metric event.
        /// </summary>
        public const int MetricEventId = 1;

        /// <summary>
        /// Gets the name of the key used to store a metric sum.
        /// </summary>
        public const string MetricValueKey = "Value";

        /// <summary>
        /// Gets the name of the key used to store function execution time in the ApplicationInsights RequestTelemetry properties.
        /// </summary>
        public const string FunctionExecutionTimeKey = "FunctionExecutionTimeMs";

        /// <summary>
        /// Gets the name of the key used to store HTTP request method
        /// </summary>
        public const string HttpMethodKey = "HttpMethod";

        /// <summary>
        /// Gets the name of the key used to store HTTP request path
        /// </summary>
        public const string HttpPathKey = "HttpPath";

        /// <summary>
        ///  Get the name of the key to store the current process id.
        /// </summary>
        public const string ProcessIdKey = "ProcessId";

        /// <summary>
        /// Get the name of the key to store the time when queue message
        /// was enqueued in <see cref="System.Diagnostics.Activity"/> tags.
        /// </summary>
        public const string MessageEnqueuedTimeKey = "EnqueuedTime";

        /// <summary>
        /// Get the name of the key to store the endpoint in trigger details
        /// that represents endpoint or FQDN of the service (Storage account, EventHub,
        /// or any other Azure or non-Azure service).
        /// </summary>
        public const string TriggerDetailsEndpointKey = "Endpoint";

        /// <summary>
        /// Get the name of the key to store the entity or path in trigger details
        /// that represents name of the entity (EventHub entity, Azure Blob container or
        /// Storage queue name).
        /// </summary>
        public const string TriggerDetailsEntityNameKey = "Entity";
    }
}
