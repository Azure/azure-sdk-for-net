// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Diagnostics;
using System;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.Linq;
using System.Text;

#nullable enable

namespace Azure.Core.Shared
{
    internal static class EventSourceEventFormatting
    {
        public static string Format(EventWrittenEventArgs eventData)
        {
            var payloadArray = eventData.Payload?.ToArray() ?? Array.Empty<object?>();

            ProcessPayloadArray(payloadArray);

            if (eventData.Message != null)
            {
                try
                {
                    return string.Format(CultureInfo.InvariantCulture, eventData.Message, payloadArray);
                }
                catch (FormatException)
                {
                }
            }

            var stringBuilder = new StringBuilder();
            stringBuilder.Append(eventData.EventName);

            if (!string.IsNullOrWhiteSpace(eventData.Message))
            {
                stringBuilder.AppendLine();
                stringBuilder.Append(nameof(eventData.Message)).Append(" = ").Append(eventData.Message);
            }

            if (eventData.PayloadNames != null)
            {
                for (int i = 0; i < eventData.PayloadNames.Count; i++)
                {
                    stringBuilder.AppendLine();
                    stringBuilder.Append(eventData.PayloadNames[i]).Append(" = ").Append(payloadArray[i]);
                }
            }

            return stringBuilder.ToString();
        }

        private static void ProcessPayloadArray(object?[] payloadArray)
        {
            for (int i = 0; i < payloadArray.Length; i++)
            {
                payloadArray[i] = FormatValue(payloadArray[i]);
            }
        }

        private static object? FormatValue(object? o)
        {
            if (o is byte[] bytes)
            {
                var stringBuilder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0:X2}", b);
                }

                return stringBuilder.ToString();
            }

            return o;
        }
    }
}
