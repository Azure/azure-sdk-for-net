// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.ChangeFeed.Common
{
    /// <summary>
    /// Shared extension and utility methods for change feed segment path parsing and time rounding.
    /// </summary>
    internal static class ChangeFeedExtensionsBase
    {
        /// <summary>
        /// Parses a segment blob path into a <see cref="DateTimeOffset"/>.
        /// The path is expected to contain at least year/month/day/HHmm components separated by '/'.
        /// </summary>
        /// <param name="segmentPath">A segment blob path such as "idx/segments/2020/03/25/0200/meta.json".</param>
        /// <returns>The parsed <see cref="DateTimeOffset"/> in UTC, or null if <paramref name="segmentPath"/> is null.</returns>
        internal static DateTimeOffset? ToDateTimeOffset(string segmentPath)
        {
            if (segmentPath == null)
                return default;

            string[] splitPath = segmentPath.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            if (splitPath.Length < 3)
                throw new ArgumentException($"{nameof(segmentPath)} is not a valid segment path.");

            int timeValue = splitPath.Length >= 6
                ? int.Parse(splitPath[5], CultureInfo.InvariantCulture)
                : 0;

            return new DateTimeOffset(
                year: int.Parse(splitPath[2], CultureInfo.InvariantCulture),
                month: splitPath.Length >= 4 ? int.Parse(splitPath[3], CultureInfo.InvariantCulture) : 1,
                day: splitPath.Length >= 5 ? int.Parse(splitPath[4], CultureInfo.InvariantCulture) : 1,
                hour: timeValue / 100,    // HHmm encoded: integer division extracts the hour component
                minute: timeValue % 100,  // HHmm encoded: modulo extracts the minute component
                second: 0,
                offset: TimeSpan.Zero);
        }

        /// <summary>
        /// Rounds a <see cref="DateTimeOffset"/> down to the nearest multiple of the given interval.
        /// </summary>
        /// <param name="dateTimeOffset">The value to round down.</param>
        /// <param name="interval">The interval to align to.</param>
        /// <returns>The rounded value, or null if <paramref name="dateTimeOffset"/> is null.</returns>
        internal static DateTimeOffset? RoundDownToNearestInterval(this DateTimeOffset? dateTimeOffset, TimeSpan interval)
        {
            if (dateTimeOffset == null) return null;
            long ticks = dateTimeOffset.Value.UtcTicks;
            long intervalTicks = interval.Ticks;
            // Subtract the remainder to snap down to the nearest interval boundary in tick space.
            return new DateTimeOffset(ticks - (ticks % intervalTicks), TimeSpan.Zero);
        }

        /// <summary>
        /// Rounds a <see cref="DateTimeOffset"/> up to the nearest multiple of the given interval.
        /// If the value already falls on an interval boundary, it is returned unchanged.
        /// </summary>
        /// <param name="dateTimeOffset">The value to round up.</param>
        /// <param name="interval">The interval to align to.</param>
        /// <returns>The rounded value, or null if <paramref name="dateTimeOffset"/> is null.</returns>
        internal static DateTimeOffset? RoundUpToNearestInterval(this DateTimeOffset? dateTimeOffset, TimeSpan interval)
        {
            if (dateTimeOffset == null) return null;
            long ticks = dateTimeOffset.Value.UtcTicks;
            long intervalTicks = interval.Ticks;
            long remainder = ticks % intervalTicks;
            if (remainder == 0) return dateTimeOffset;
            return new DateTimeOffset(ticks + (intervalTicks - remainder), TimeSpan.Zero);
        }

        /// <summary>
        /// Rounds a <see cref="DateTimeOffset"/> down to January 1 of its year in UTC.
        /// </summary>
        internal static DateTimeOffset? RoundDownToNearestYear(this DateTimeOffset? dateTimeOffset)
        {
            if (dateTimeOffset == null) return null;
            return new DateTimeOffset(dateTimeOffset.Value.ToUniversalTime().Year, 1, 1, 0, 0, 0, TimeSpan.Zero);
        }

        /// <summary>
        /// Lists all segment blob paths within a given year folder that fall within the specified time window.
        /// </summary>
        /// <param name="containerClient">The change feed container client.</param>
        /// <param name="yearPath">Blob prefix for the year (e.g. "idx/segments/2020/").</param>
        /// <param name="startTime">Optional inclusive lower bound.</param>
        /// <param name="endTime">Optional inclusive upper bound.</param>
        /// <param name="async">Whether to use async APIs.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A queue of segment paths ordered chronologically.</returns>
        internal static async Task<Queue<string>> GetSegmentsInYearInternal(
            BlobContainerClient containerClient, string yearPath, DateTimeOffset? startTime, DateTimeOffset? endTime, bool async, CancellationToken cancellationToken)
        {
            List<string> list = new List<string>();
            GetBlobsByHierarchyOptions options = new GetBlobsByHierarchyOptions { Prefix = yearPath };

            if (async)
            {
                await foreach (BlobHierarchyItem item in containerClient.GetBlobsByHierarchyAsync(options: options, cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    if (item.IsPrefix) continue;
                    DateTimeOffset segmentDateTime = ToDateTimeOffset(item.Blob.Name).Value;
                    if (startTime.HasValue && segmentDateTime < startTime || endTime.HasValue && segmentDateTime > endTime) continue;
                    list.Add(item.Blob.Name);
                }
            }
            else
            {
                foreach (BlobHierarchyItem item in containerClient.GetBlobsByHierarchy(options: options, cancellationToken: cancellationToken))
                {
                    if (item.IsPrefix) continue;
                    DateTimeOffset segmentDateTime = ToDateTimeOffset(item.Blob.Name).Value;
                    if (startTime.HasValue && segmentDateTime < startTime || endTime.HasValue && segmentDateTime > endTime) continue;
                    list.Add(item.Blob.Name);
                }
            }
            return new Queue<string>(list);
        }

        /// <summary>
        /// Returns the earlier of <paramref name="lastConsumable"/> and <paramref name="endDate"/>.
        /// </summary>
        internal static DateTimeOffset MinDateTime(DateTimeOffset lastConsumable, DateTimeOffset? endDate)
        {
            if (endDate.HasValue && endDate.Value < lastConsumable) return endDate.Value;
            return lastConsumable;
        }
    }
}
