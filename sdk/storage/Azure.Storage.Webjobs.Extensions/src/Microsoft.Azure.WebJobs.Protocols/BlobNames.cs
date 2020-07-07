// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;

#if PUBLICPROTOCOL
namespace Microsoft.Azure.WebJobs.Protocols
#else
namespace Microsoft.Azure.WebJobs.Host.Protocols
#endif
{
    /// <summary>Provides blob names in the protocol.</summary>
#if PUBLICPROTOCOL
    public static class BlobNames
#else
    internal static class BlobNames
#endif
    {
        /// <summary>
        /// Generates a blob name based on the current date/time that has no naming collision issue
        /// </summary>
        /// <returns>A blob name</returns>
        public static string GetConflictFreeDateTimeBasedBlobName()
        {
            return GetConflictFreeDateTimeBasedBlobName(DateTime.UtcNow);
        }

        /// <summary>
        /// Generates a blob name based on a specified date/time that has no naming collision issue
        /// </summary>
        /// <param name="timestamp">The timestamp from which the name is generated.</param>
        /// <returns>A blob name</returns>
        public static string GetConflictFreeDateTimeBasedBlobName(DateTimeOffset timestamp)
        {
            return String.Format(
                CultureInfo.InvariantCulture, "{0}_{1:N}",
                CreateDateBasedBlobName(timestamp),
                Guid.NewGuid());
        }

        /// <summary>
        /// Creates a blob name based on a specified date/time
        /// </summary>
        /// <param name="timestamp">The timestamp from which the name is generated.</param>
        /// <returns>A blob name</returns>
        public static string CreateDateBasedBlobName(DateTimeOffset timestamp)
        {
            // DateTimeOffset.MaxValue.Ticks.ToString().Length = 19
            // Subtract from DateTimeOffset.MaxValue.Ticks to have newer times sort at the top.
            return String.Format(
                CultureInfo.InvariantCulture, "{0:D19}",
                DateTimeOffset.MaxValue.Ticks - timestamp.Ticks);
        }
    }
}
