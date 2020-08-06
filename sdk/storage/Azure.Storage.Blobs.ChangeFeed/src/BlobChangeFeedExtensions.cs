// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs.ChangeFeed
{
    /// <summary>
    /// BlobChangeFeedExtensions.
    /// </summary>
    public static class BlobChangeFeedExtensions
    {
        /// <summary>
        /// GetChangeFeedClient.
        /// </summary>
        /// <param name="serviceClient"></param>
        /// <returns><see cref="BlobChangeFeedClient"/>.</returns>
        public static BlobChangeFeedClient GetChangeFeedClient(this BlobServiceClient serviceClient)
        {
            return new BlobChangeFeedClient(serviceClient);
        }

        /// <summary>
        /// Builds a DateTimeOffset from a segment path.
        /// </summary>
        internal static DateTimeOffset? ToDateTimeOffset(string segmentPath)
        {
            if (segmentPath == null)
            {
                return default;
            }
            string[] splitPath = segmentPath.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            if (splitPath.Length < 3)
            {
                throw new ArgumentException($"{nameof(segmentPath)} is not a valid segment path.");
            }

            return new DateTimeOffset(
                year: int.Parse(splitPath[2], CultureInfo.InvariantCulture),
                month: splitPath.Length >= 4
                    ? int.Parse(splitPath[3], CultureInfo.InvariantCulture)
                    : 1,
                day: splitPath.Length >= 5
                    ? int.Parse(splitPath[4], CultureInfo.InvariantCulture)
                    : 1,
                hour: splitPath.Length >= 6
                    ? int.Parse(splitPath[5], CultureInfo.InvariantCulture) / 100
                    : 0,
                minute: 0,
                second: 0,
                offset: TimeSpan.Zero);
        }

        /// <summary>
        /// Rounds a DateTimeOffset down to the nearest hour.
        /// </summary>
        internal static DateTimeOffset? RoundDownToNearestHour(this DateTimeOffset? dateTimeOffset)
        {
            if (dateTimeOffset == null)
            {
                return null;
            }

            return new DateTimeOffset(
                year: dateTimeOffset.Value.Year,
                month: dateTimeOffset.Value.Month,
                day: dateTimeOffset.Value.Day,
                hour: dateTimeOffset.Value.Hour,
                minute: 0,
                second: 0,
                offset: dateTimeOffset.Value.Offset);
        }

        /// <summary>
        /// Rounds a DateTimeOffset up to the nearest hour.
        /// </summary>
        internal static DateTimeOffset? RoundUpToNearestHour(this DateTimeOffset? dateTimeOffset)
        {
            if (dateTimeOffset == null)
            {
                return null;
            }

            if (dateTimeOffset.Value.Minute == 0 && dateTimeOffset.Value.Second == 0 && dateTimeOffset.Value.Millisecond == 0)
            {
                return dateTimeOffset;
            }

            DateTimeOffset? newDateTimeOffest = dateTimeOffset.RoundDownToNearestHour();

            return newDateTimeOffest.Value.AddHours(1);
        }

        internal static DateTimeOffset? RoundDownToNearestYear(this DateTimeOffset? dateTimeOffset)
        {
            if (dateTimeOffset == null)
            {
                return null;
            }

            return new DateTimeOffset(
                year: dateTimeOffset.Value.ToUniversalTime().Year,
                month: 1,
                day: 1,
                hour: 0,
                minute: 0,
                second: 0,
                offset: TimeSpan.Zero);
        }

        internal static async Task<Queue<string>> GetSegmentsInYearInternal(
            BlobContainerClient containerClient,
            string yearPath,
            DateTimeOffset? startTime,
            DateTimeOffset? endTime,
            bool async,
            CancellationToken cancellationToken)
        {
            List<string> list = new List<string>();

            if (async)
            {
                await foreach (BlobHierarchyItem blobHierarchyItem in containerClient.GetBlobsByHierarchyAsync(
                    prefix: yearPath,
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false))
                {
                    if (blobHierarchyItem.IsPrefix)
                        continue;

                    DateTimeOffset segmentDateTime = ToDateTimeOffset(blobHierarchyItem.Blob.Name).Value;
                    if (startTime.HasValue && segmentDateTime < startTime
                        || endTime.HasValue && segmentDateTime > endTime)
                        continue;

                    list.Add(blobHierarchyItem.Blob.Name);
                }
            }
            else
            {
                foreach (BlobHierarchyItem blobHierarchyItem in containerClient.GetBlobsByHierarchy(
                    prefix: yearPath,
                    cancellationToken: cancellationToken))
                {
                    if (blobHierarchyItem.IsPrefix)
                        continue;

                    DateTimeOffset segmentDateTime = ToDateTimeOffset(blobHierarchyItem.Blob.Name).Value;
                    if (startTime.HasValue && segmentDateTime < startTime
                        || endTime.HasValue && segmentDateTime > endTime)
                        continue;

                    list.Add(blobHierarchyItem.Blob.Name);
                }
            }

            return new Queue<string>(list);
        }

        internal static DateTimeOffset MinDateTime(DateTimeOffset lastConsumable, DateTimeOffset? endDate)
        {
            if (endDate.HasValue && endDate.Value < lastConsumable)
            {
                return endDate.Value;
            }

            return lastConsumable;
        }

        internal static string ComputeMD5(string input)
        {
#pragma warning disable CA5351 // Do Not Use Broken Cryptographic Algorithms
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
#pragma warning restore CA5351 // Do Not Use Broken Cryptographic Algorithms
            {
                byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2", CultureInfo.InvariantCulture));
                }
                return sb.ToString();
            }
        }
    }
}
