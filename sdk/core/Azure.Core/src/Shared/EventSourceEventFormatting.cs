// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.Tracing;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Azure.Core.Shared
{
    internal static class EventSourceEventFormatting
    {
        public static string Format(EventWrittenEventArgs eventData)
        {
            var payloadArray = eventData.Payload.ToArray();

            ProcessPayloadArray(payloadArray);

            if (eventData.Message != null)
            {
                return string.Format(CultureInfo.InvariantCulture, eventData.Message, payloadArray);
            }

            var stringBuilder = new StringBuilder();
            stringBuilder.Append(eventData.EventName);

            for (int i = 0; i < eventData.PayloadNames.Count; i++)
            {
                stringBuilder.AppendLine();
                stringBuilder.Append(eventData.PayloadNames[i]).Append(" = ").Append(payloadArray[i]);
            }

            return stringBuilder.ToString();
        }

        private static void ProcessPayloadArray(object[] payloadArray)
        {
            for (int i = 0; i < payloadArray.Length; i++)
            {
                payloadArray[i] = FormatValue(payloadArray[i]);
            }
        }

        private static object FormatValue(object o)
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
