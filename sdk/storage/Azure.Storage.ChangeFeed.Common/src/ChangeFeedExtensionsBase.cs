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
    internal static class ChangeFeedExtensionsBase
    {
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
                hour: timeValue / 100,
                minute: timeValue % 100,
                second: 0,
                offset: TimeSpan.Zero);
        }

        internal static DateTimeOffset? RoundDownToNearestInterval(this DateTimeOffset? dateTimeOffset, TimeSpan interval)
        {
            if (dateTimeOffset == null) return null;
            long ticks = dateTimeOffset.Value.UtcTicks;
            long intervalTicks = interval.Ticks;
            return new DateTimeOffset(ticks - (ticks % intervalTicks), TimeSpan.Zero);
        }

        internal static DateTimeOffset? RoundUpToNearestInterval(this DateTimeOffset? dateTimeOffset, TimeSpan interval)
        {
            if (dateTimeOffset == null) return null;
            long ticks = dateTimeOffset.Value.UtcTicks;
            long intervalTicks = interval.Ticks;
            long remainder = ticks % intervalTicks;
            if (remainder == 0) return dateTimeOffset;
            return new DateTimeOffset(ticks + (intervalTicks - remainder), TimeSpan.Zero);
        }

        internal static DateTimeOffset? RoundDownToNearestYear(this DateTimeOffset? dateTimeOffset)
        {
            if (dateTimeOffset == null) return null;
            return new DateTimeOffset(dateTimeOffset.Value.ToUniversalTime().Year, 1, 1, 0, 0, 0, TimeSpan.Zero);
        }

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

        internal static DateTimeOffset MinDateTime(DateTimeOffset lastConsumable, DateTimeOffset? endDate)
        {
            if (endDate.HasValue && endDate.Value < lastConsumable) return endDate.Value;
            return lastConsumable;
        }
    }
}
