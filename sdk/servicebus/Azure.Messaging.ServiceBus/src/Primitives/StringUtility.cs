// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Azure.Messaging.ServiceBus.Primitives
{
    internal static class StringUtility
    {
        public static string GetFormattedLockTokens(IEnumerable<Guid> lockTokens)
        {
            // ReceiveAndDelete messages have empty lock tokens, so skip them to avoid noisy logs.
            return $"[{string.Join(", ", lockTokens.Where(static token => token != Guid.Empty))}]";
        }

        public static string GetFormattedLockTokens(IReadOnlyList<ServiceBusReceivedMessage> messages)
        {
#if NET
            // Format the lock tokens directly into the resulting string to avoid allocating an intermediate
            // string per token, as this is called for every receive operation when logging is enabled.
            const string Separator = ", ";
            const int GuidLength = 36; // The length of a Guid formatted with the default "D" format specifier.

            int count = 0;

            for (int i = 0; i < messages.Count; i++)
            {
                // ReceiveAndDelete messages have empty lock tokens, so skip them to avoid noisy logs.
                if (messages[i].LockTokenGuid != Guid.Empty)
                {
                    count++;
                }
            }

            if (count == 0)
            {
                return "[]";
            }

            int length = 2 + (count * GuidLength) + ((count - 1) * Separator.Length);

            return string.Create(length, messages, static (buffer, messages) =>
            {
                buffer[0] = '[';
                int position = 1;

                for (int i = 0; i < messages.Count; i++)
                {
                    Guid lockToken = messages[i].LockTokenGuid;

                    if (lockToken == Guid.Empty)
                    {
                        continue;
                    }

                    if (position > 1)
                    {
                        Separator.AsSpan().CopyTo(buffer.Slice(position));
                        position += Separator.Length;
                    }

                    lockToken.TryFormat(buffer.Slice(position), out int written);
                    position += written;
                }

                buffer[position] = ']';
            });
#else
            return GetFormattedLockTokens(messages.Select(static message => message.LockTokenGuid));
#endif
        }

        public static string GetFormattedSequenceNumbers(IEnumerable<long> sequenceNumbers)
        {
            return $"[{string.Join(", ", sequenceNumbers)}]";
        }

        /// <summary>
        /// Formats a string+parameters using CurrentCulture.
        /// </summary>
        public static string FormatForUser(this string format, params object[] args)
        {
            return string.Format(CultureInfo.CurrentCulture, format, args);
        }
    }
}
