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
