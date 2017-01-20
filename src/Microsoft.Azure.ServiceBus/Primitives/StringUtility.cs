// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;

    static class StringUtility
    {
        public static string GetRandomString()
        {
            return Guid.NewGuid().ToString().Substring(0, 6);
        }

        public static string GetFormattedLockTokens(IEnumerable<Guid> lockTokens)
        {
            StringBuilder lockTokenBuilder = new StringBuilder();
            foreach (Guid lockToken in lockTokens)
            {
                lockTokenBuilder.AppendFormat(CultureInfo.InvariantCulture, "<LockToken>{0}</LockToken>", lockToken);
            }

            return lockTokenBuilder.ToString();
        }

        public static string GetFormattedSequenceNumbers(IEnumerable<long> sequenceNumbers)
        {
            StringBuilder sequenceNumberBuilder = new StringBuilder();
            foreach (long sequenceNumber in sequenceNumbers)
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