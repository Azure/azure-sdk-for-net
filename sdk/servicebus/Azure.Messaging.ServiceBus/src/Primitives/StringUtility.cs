// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Azure.Messaging.ServiceBus.Primitives
{
    internal static class StringUtility
    {
        public static string GetFormattedLockTokens(IEnumerable<Guid> lockTokens)
        {
            var lockTokenBuilder = new StringBuilder();
            foreach (var lockToken in lockTokens)
            {
                lockTokenBuilder.AppendFormat(CultureInfo.InvariantCulture, "<LockToken>{0}</LockToken>", lockToken.ToString());
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
    }
}
