// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Logging;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework
{
    // TODO: REMOVE THIS PRAGMA AFTER Microsoft.Extensions.Telemetry SHIPS THE TagName API AS STABLE.
    // https://github.com/dotnet/extensions/issues/5825
#pragma warning disable EXTEXP0003 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
    /// <summary>
    /// This class has ILogger extensions for use in unit tests.
    /// </summary>
    public static partial class CustomEventLoggerExtensions
    {
        [LoggerMessage(level: LogLevel.Information, Message = "{key1}")]
        public static partial void WriteSimpleLog(this ILogger logger, string key1);

        [LoggerMessage(level: LogLevel.Information, Message = "{microsoft.custom_event.name}")]
        public static partial void WriteSimpleCustomEvent(this ILogger logger, [TagName("microsoft.custom_event.name")] string customEventName);

        [LoggerMessage(level: LogLevel.Information, Message = "{microsoft.custom_event.name} {key1} {key2}")]
        public static partial void WriteCustomEventWithAdditionalProperties(this ILogger logger, [TagName("microsoft.custom_event.name")] string customEventName, string key1, string key2);

        [LoggerMessage(level: LogLevel.Information, Message = "{microsoft.custom_event.name} {microsoft.client.ip}")]
        public static partial void WriteCustomEventWithClientAddress(this ILogger logger, [TagName("microsoft.custom_event.name")] string customEventName, [TagName("microsoft.client.ip")] string clientAddress);
    }
#pragma warning restore EXTEXP0003
}
