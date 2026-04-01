// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.ChangeFeed.Common.Tests
{
    /// <summary>
    /// Tests that verify correct behavior when a change feed contains segments of varying lengths
    /// (e.g., a mix of 15-minute and 1-hour segments). With <see cref="ChangeFeedConfiguration{TEvent}.TimeWindowInterval"/>
    /// set to null, no rounding is applied and the raw start/end times are used to filter segments.
    /// </summary>
    public class VariableSegmentTests : ChangeFeedCommonTestBase
    {
        public VariableSegmentTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null)
        {
        }

        /// <summary>
        /// Returns a page of segments with irregular intervals: 08:00, 08:15, 08:30, 09:00, 10:00, 10:30.
        /// This simulates a change feed where the service produced 15-minute segments during a busy period
        /// and hourly segments during a quiet period.
        /// </summary>
        private static Page<BlobHierarchyItem> GetVariableSegmentsFunc(string continuation, int? pageSizeHint)
            => new BlobHierarchyItemPage(new List<BlobHierarchyItem>
            {
                BlobsModelFactory.BlobHierarchyItem(null,
                    BlobsModelFactory.BlobItem("idx/segments/2024/01/15/0800/meta.json", false, null)),
                BlobsModelFactory.BlobHierarchyItem(null,
                    BlobsModelFactory.BlobItem("idx/segments/2024/01/15/0815/meta.json", false, null)),
                BlobsModelFactory.BlobHierarchyItem(null,
                    BlobsModelFactory.BlobItem("idx/segments/2024/01/15/0830/meta.json", false, null)),
                // Gap: no 08:45 segment — jumped to hourly
                BlobsModelFactory.BlobHierarchyItem(null,
                    BlobsModelFactory.BlobItem("idx/segments/2024/01/15/0900/meta.json", false, null)),
                // Hourly segment
                BlobsModelFactory.BlobHierarchyItem(null,
                    BlobsModelFactory.BlobItem("idx/segments/2024/01/15/1000/meta.json", false, null)),
                // Back to 30-minute segments
                BlobsModelFactory.BlobHierarchyItem(null,
                    BlobsModelFactory.BlobItem("idx/segments/2024/01/15/1030/meta.json", false, null)),
            });

        private static Task<Page<BlobHierarchyItem>> GetVariableSegmentsFuncAsync(string continuation, int? pageSizeHint)
            => Task.FromResult(GetVariableSegmentsFunc(continuation, pageSizeHint));

        /// <summary>
        /// Verifies that GetSegmentsInYearInternal correctly filters variable-length segments
        /// when given an unrounded time range that falls in the middle of a segment boundary.
        /// Start = 08:20 (between 08:15 and 08:30), End = 10:00.
        /// Expected: 08:30, 09:00, 10:00 (08:00 and 08:15 are before start, 10:30 is after end).
        /// </summary>
        [Test]
        public async Task GetSegmentsInYear_VariableSegments_FiltersCorrectly()
        {
            // Arrange
            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);

            if (IsAsync)
            {
                containerClient.Setup(r => r.GetBlobsByHierarchyAsync(
                    It.IsAny<GetBlobsByHierarchyOptions>(),
                    It.IsAny<CancellationToken>()))
                    .Returns(new MockPageable(GetVariableSegmentsFuncAsync));
            }
            else
            {
                containerClient.Setup(r => r.GetBlobsByHierarchy(
                    It.IsAny<GetBlobsByHierarchyOptions>(),
                    It.IsAny<CancellationToken>()))
                    .Returns(new MockSyncPageable(GetVariableSegmentsFunc));
            }

            // Unrounded times — no 15-minute alignment
            DateTimeOffset startTime = new DateTimeOffset(2024, 1, 15, 8, 20, 0, TimeSpan.Zero);
            DateTimeOffset endTime = new DateTimeOffset(2024, 1, 15, 10, 0, 0, TimeSpan.Zero);

            // Act
            Queue<string> segments = await ChangeFeedExtensionsBase.GetSegmentsInYearInternal(
                containerClient.Object,
                "idx/segments/2024/",
                startTime,
                endTime,
                IsAsync,
                CancellationToken.None);

            // Assert - should include 08:15 (enclosing segment for 08:20), 08:30, 09:00, 10:00
            Assert.AreEqual(4, segments.Count);
            Assert.AreEqual("idx/segments/2024/01/15/0815/meta.json", segments.Dequeue());
            Assert.AreEqual("idx/segments/2024/01/15/0830/meta.json", segments.Dequeue());
            Assert.AreEqual("idx/segments/2024/01/15/0900/meta.json", segments.Dequeue());
            Assert.AreEqual("idx/segments/2024/01/15/1000/meta.json", segments.Dequeue());
        }

        /// <summary>
        /// Verifies that when start time exactly matches a segment boundary, that segment is included.
        /// </summary>
        [Test]
        public async Task GetSegmentsInYear_VariableSegments_StartOnBoundary()
        {
            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);

            if (IsAsync)
            {
                containerClient.Setup(r => r.GetBlobsByHierarchyAsync(
                    It.IsAny<GetBlobsByHierarchyOptions>(),
                    It.IsAny<CancellationToken>()))
                    .Returns(new MockPageable(GetVariableSegmentsFuncAsync));
            }
            else
            {
                containerClient.Setup(r => r.GetBlobsByHierarchy(
                    It.IsAny<GetBlobsByHierarchyOptions>(),
                    It.IsAny<CancellationToken>()))
                    .Returns(new MockSyncPageable(GetVariableSegmentsFunc));
            }

            // Start exactly on the 09:00 segment boundary
            DateTimeOffset startTime = new DateTimeOffset(2024, 1, 15, 9, 0, 0, TimeSpan.Zero);
            DateTimeOffset endTime = new DateTimeOffset(2024, 1, 15, 11, 0, 0, TimeSpan.Zero);

            Queue<string> segments = await ChangeFeedExtensionsBase.GetSegmentsInYearInternal(
                containerClient.Object, "idx/segments/2024/", startTime, endTime, IsAsync, CancellationToken.None);

            Assert.AreEqual(3, segments.Count);
            Assert.AreEqual("idx/segments/2024/01/15/0900/meta.json", segments.Dequeue());
            Assert.AreEqual("idx/segments/2024/01/15/1000/meta.json", segments.Dequeue());
            Assert.AreEqual("idx/segments/2024/01/15/1030/meta.json", segments.Dequeue());
        }

        /// <summary>
        /// Verifies that an unrounded mid-minute start time (08:22) correctly excludes
        /// segments before it (08:00, 08:15) while including segments at or after it (08:30).
        /// This confirms the factory passes raw times without rounding.
        /// </summary>
        [Test]
        public async Task UnroundedStartTime_ExcludesEarlierSegments()
        {
            Mock<BlobContainerClient> containerClient = new Mock<BlobContainerClient>(MockBehavior.Strict);

            if (IsAsync)
            {
                containerClient.Setup(r => r.GetBlobsByHierarchyAsync(
                    It.IsAny<GetBlobsByHierarchyOptions>(),
                    It.IsAny<CancellationToken>()))
                    .Returns(new MockPageable(GetVariableSegmentsFuncAsync));
            }
            else
            {
                containerClient.Setup(r => r.GetBlobsByHierarchy(
                    It.IsAny<GetBlobsByHierarchyOptions>(),
                    It.IsAny<CancellationToken>()))
                    .Returns(new MockSyncPageable(GetVariableSegmentsFunc));
            }

            // 08:22 is between the 08:15 and 08:30 segments.
            // Without rounding, 08:00 and 08:15 should be excluded; 08:30 onward included.
            DateTimeOffset startTime = new DateTimeOffset(2024, 1, 15, 8, 22, 0, TimeSpan.Zero);
            DateTimeOffset endTime = new DateTimeOffset(2024, 1, 15, 23, 59, 59, TimeSpan.Zero);

            Queue<string> segments = await ChangeFeedExtensionsBase.GetSegmentsInYearInternal(
                containerClient.Object, "idx/segments/2024/", startTime, endTime, IsAsync, CancellationToken.None);

            // 08:15 is the enclosing segment for 08:22 (last segment <= 08:22), so it's included.
            // 08:00 is before the enclosing segment, so excluded.
            Assert.AreEqual(5, segments.Count);
            Assert.AreEqual("idx/segments/2024/01/15/0815/meta.json", segments.Dequeue());
            Assert.AreEqual("idx/segments/2024/01/15/0830/meta.json", segments.Dequeue());
            Assert.AreEqual("idx/segments/2024/01/15/0900/meta.json", segments.Dequeue());
            Assert.AreEqual("idx/segments/2024/01/15/1000/meta.json", segments.Dequeue());
            Assert.AreEqual("idx/segments/2024/01/15/1030/meta.json", segments.Dequeue());
        }

        /// <summary>
        /// Mock async pageable for blob hierarchy items.
        /// </summary>
        private class MockPageable : AsyncPageable<BlobHierarchyItem>
        {
            private readonly Func<string, int?, Task<Page<BlobHierarchyItem>>> _pageFunc;

            public MockPageable(Func<string, int?, Task<Page<BlobHierarchyItem>>> pageFunc)
            {
                _pageFunc = pageFunc;
            }

            public override async IAsyncEnumerable<Page<BlobHierarchyItem>> AsPages(
                string continuationToken = null, int? pageSizeHint = null)
            {
                yield return await _pageFunc(continuationToken, pageSizeHint);
            }
        }

        /// <summary>
        /// Mock sync pageable for blob hierarchy items.
        /// </summary>
        private class MockSyncPageable : Pageable<BlobHierarchyItem>
        {
            private readonly Func<string, int?, Page<BlobHierarchyItem>> _pageFunc;

            public MockSyncPageable(Func<string, int?, Page<BlobHierarchyItem>> pageFunc)
            {
                _pageFunc = pageFunc;
            }

            public override IEnumerable<Page<BlobHierarchyItem>> AsPages(
                string continuationToken = null, int? pageSizeHint = null)
            {
                yield return _pageFunc(continuationToken, pageSizeHint);
            }
        }
    }
}
