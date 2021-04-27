// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Azure.Messaging.ServiceBus.Primitives
{
    internal static class StringUtility
    {
        public static string GetFormattedLockTokens(IEnumerable<string> lockTokens)
        {
            var lockTokenBuilder = new StringBuilder();
            foreach (var lockToken in lockTokens)
            {
                lockTokenBuilder.AppendFormat(CultureInfo.InvariantCulture, "<LockToken>{0}</LockToken>", lockToken);
            }

            return lockTokenBuilder.ToString();
        }

        public static string GetFormattedSequenceNumbers(IEnumerable<long> sequenceNumbers)
        {
            var sequenceNumberBuilder = new StringBuilder();
            foreach (var sequenceNumber in sequenceNumbers)
            {
                sequenceNumberBuilder.AppendFormat(CultureInfo.InvariantCulture, "<SequenceNumber>{0}</SequenceNumber>", sequenceNumber);
            }

            return sequenceNumberBuilder.ToString();
        }

        /// <summary>
        /// Formats a string+parameters using CurrentCulture.
        /// </summary>
        public static string FormatForUser(this string format, params object[] args)
        {
            return string.Format(CultureInfo.CurrentCulture, format, args);
        }

        /// <summary>
        /// Formats a string+parameter using InvariantCulture.  This overload avoids allocating an array when there's only one replacement parameter
        /// </summary>
        public static string FormatInvariant(this string format, object arg0)
        {
            return string.Format(CultureInfo.InvariantCulture, format, arg0);
        }

        /// <summary>
        /// Formats a string+parameters using InvariantCulture.
        /// </summary>
        public static string FormatInvariant(this string format, params object[] args)
        {
            return string.Format(CultureInfo.InvariantCulture, format, args);
        }
    }
}
