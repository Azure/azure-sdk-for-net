// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Test.Shared;

namespace Azure.Storage.ChangeFeed.Common.Tests
{
    /// <summary>
    /// Base class for ChangeFeed.Common tests. Uses <see cref="BlobClientOptions.ServiceVersion"/>
    /// for the <see cref="ClientTestFixture"/> since the common code reads from blob storage.
    /// </summary>
    [ClientTestFixture(
        BlobClientOptions.ServiceVersion.V2026_02_06,
        BlobClientOptions.ServiceVersion.V2026_06_06,
        StorageVersionExtensions.LatestVersion,
        StorageVersionExtensions.MaxVersion,
    RecordingServiceVersion = StorageVersionExtensions.MaxVersion,
    LiveServiceVersions = new object[] { StorageVersionExtensions.LatestVersion })]
    public class ChangeFeedCommonTestBase : StorageTestBase<StorageTestEnvironment>
    {
        protected readonly BlobClientOptions.ServiceVersion _serviceVersion;

        public ChangeFeedCommonTestBase(bool async, BlobClientOptions.ServiceVersion serviceVersion, RecordedTestMode? mode = null)
            : base(async, mode)
        {
            _serviceVersion = serviceVersion;
        }

        /// <summary>
        /// A minimal test event type used to test the generic common classes
        /// without depending on any service-specific event model.
        /// </summary>
        public class TestEvent
        {
            public string Reason { get; set; }
            public string Id { get; set; }
            public long Cvnt { get; set; }

            public TestEvent(Dictionary<string, object> record)
            {
                Reason = record.TryGetValue("Reason", out object r) ? (string)r : null;
                Id = record.TryGetValue("Id", out object id) ? (string)id : null;
                Cvnt = record.TryGetValue("Cvnt", out object c) && c is long cv ? cv : 0;
            }

            public TestEvent() { }
        }

        /// <summary>
        /// Creates a <see cref="ChangeFeedConfiguration{TestEvent}"/> with standard test values.
        /// Uses 15-minute windows and a test container prefix.
        /// </summary>
        internal static ChangeFeedConfiguration<TestEvent> CreateTestConfig()
            => new ChangeFeedConfiguration<TestEvent>
            {
                TimeWindowInterval = TimeSpan.FromMinutes(15),
                ContainerPrefix = "$fileschangefeed-testguid/",
                EventParser = dict => new TestEvent(dict),
                DefaultPageSize = 5000,
                ChunkBlockDownloadSize = 4 * Constants.MB,
                InitializationSegment = "1601",
                SegmentPrefix = "idx/segments/",
                MetaSegmentsPath = "meta/segments.json",
            };

        /// <summary>
        /// Returns a page of mock year-level prefix paths for test setup.
        /// </summary>
        public static Page<BlobHierarchyItem> GetYearPathFunc(string continuation, int? pageSizeHint)
            => new BlobHierarchyItemPage(new List<BlobHierarchyItem>
            {
                BlobsModelFactory.BlobHierarchyItem("idx/segments/1601/", null),
                BlobsModelFactory.BlobHierarchyItem("idx/segments/2024/", null),
            });

        public static Task<Page<BlobHierarchyItem>> GetYearPathFuncAsync(string continuation, int? pageSizeHint)
            => Task.FromResult(GetYearPathFunc(continuation, pageSizeHint));

        /// <summary>
        /// Returns a page of mock 15-minute segment paths within a year.
        /// </summary>
        public static Page<BlobHierarchyItem> GetSegmentsInYearFunc(string continuation, int? pageSizeHint)
            => new BlobHierarchyItemPage(new List<BlobHierarchyItem>
            {
                BlobsModelFactory.BlobHierarchyItem(null,
                    BlobsModelFactory.BlobItem("idx/segments/2024/01/15/0800/meta.json", false, null)),
                BlobsModelFactory.BlobHierarchyItem(null,
                    BlobsModelFactory.BlobItem("idx/segments/2024/01/15/0815/meta.json", false, null)),
                BlobsModelFactory.BlobHierarchyItem(null,
                    BlobsModelFactory.BlobItem("idx/segments/2024/01/15/0830/meta.json", false, null)),
            });

        public static Task<Page<BlobHierarchyItem>> GetSegmentsInYearFuncAsync(string continuation, int? pageSizeHint)
            => Task.FromResult(GetSegmentsInYearFunc(continuation, pageSizeHint));

        /// <summary>
        /// Minimal <see cref="Page{T}"/> implementation for mock pageable responses.
        /// </summary>
        public class BlobHierarchyItemPage : Page<BlobHierarchyItem>
        {
            private readonly List<BlobHierarchyItem> _items;
            public BlobHierarchyItemPage(List<BlobHierarchyItem> items) { _items = items; }
            public override IReadOnlyList<BlobHierarchyItem> Values => _items;
            public override string ContinuationToken => null;
            public override Response GetRawResponse() => throw new NotImplementedException();
        }
    }
}
