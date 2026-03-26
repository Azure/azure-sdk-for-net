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

namespace Azure.Storage.Files.Shares.ChangeFeed.Tests
{
    [ClientTestFixture(
        BlobClientOptions.ServiceVersion.V2026_02_06,
        BlobClientOptions.ServiceVersion.V2026_04_06,
        BlobClientOptions.ServiceVersion.V2026_06_06,
        StorageVersionExtensions.LatestVersion,
        StorageVersionExtensions.MaxVersion,
    RecordingServiceVersion = StorageVersionExtensions.MaxVersion,
    LiveServiceVersions = new object[] { StorageVersionExtensions.LatestVersion })]
    public class ShareChangeFeedTestBase : StorageTestBase<StorageTestEnvironment>
    {
        protected readonly BlobClientOptions.ServiceVersion _serviceVersion;

        public ShareChangeFeedTestBase(bool async, BlobClientOptions.ServiceVersion serviceVersion, RecordedTestMode? mode = null)
            : base(async, mode)
        {
            _serviceVersion = serviceVersion;
        }

        public BlobClientOptions GetOptions()
        {
            var options = new BlobClientOptions(_serviceVersion)
            {
                Diagnostics = { IsLoggingEnabled = true },
                Retry =
                {
                    Mode = RetryMode.Exponential,
                    MaxRetries = Constants.MaxReliabilityRetries,
                    Delay = TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback ? 0.01 : 1),
                    MaxDelay = TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback ? 0.1 : 60)
                },
            };
            if (Mode != RecordedTestMode.Live)
            {
                options.AddPolicy(new RecordedClientRequestIdPolicy(Recording), HttpPipelinePosition.PerCall);
            }

            return InstrumentClientOptions(options);
        }

        /// <summary>
        /// Returns a page of mock year paths for test setup.
        /// </summary>
        public static Page<BlobHierarchyItem> GetYearPathFunc(string continuation, int? pageSizeHint)
            => new BlobHierarchyItemPage(new List<BlobHierarchyItem>
            {
                BlobsModelFactory.BlobHierarchyItem("idx/segments/1601/", null),
                BlobsModelFactory.BlobHierarchyItem("idx/segments/2023/", null),
                BlobsModelFactory.BlobHierarchyItem("idx/segments/2024/", null),
            });

        public static Task<Page<BlobHierarchyItem>> GetYearPathFuncAsync(string continuation, int? pageSizeHint)
            => Task.FromResult(GetYearPathFunc(continuation, pageSizeHint));

        /// <summary>
        /// Returns a page of mock 15-minute segment paths for a year.
        /// </summary>
        public static Page<BlobHierarchyItem> GetSegmentsInYearFunc(string continuation, int? pageSizeHint)
            => new BlobHierarchyItemPage(new List<BlobHierarchyItem>
            {
                BlobsModelFactory.BlobHierarchyItem(
                    null,
                    BlobsModelFactory.BlobItem("idx/segments/2024/01/15/0800/meta.json", false, null)),
                BlobsModelFactory.BlobHierarchyItem(
                    null,
                    BlobsModelFactory.BlobItem("idx/segments/2024/01/15/0815/meta.json", false, null)),
                BlobsModelFactory.BlobHierarchyItem(
                    null,
                    BlobsModelFactory.BlobItem("idx/segments/2024/01/15/0830/meta.json", false, null)),
                BlobsModelFactory.BlobHierarchyItem(
                    null,
                    BlobsModelFactory.BlobItem("idx/segments/2024/01/15/0845/meta.json", false, null)),
                BlobsModelFactory.BlobHierarchyItem(
                    null,
                    BlobsModelFactory.BlobItem("idx/segments/2024/01/15/0900/meta.json", false, null)),
            });

        public static Task<Page<BlobHierarchyItem>> GetSegmentsInYearFuncAsync(string continuation, int? pageSizeHint)
            => Task.FromResult(GetSegmentsInYearFunc(continuation, pageSizeHint));

        public class BlobHierarchyItemPage : Page<BlobHierarchyItem>
        {
            private readonly List<BlobHierarchyItem> _items;

            public BlobHierarchyItemPage(List<BlobHierarchyItem> items)
            {
                _items = items;
            }

            public override IReadOnlyList<BlobHierarchyItem> Values => _items;
            public override string ContinuationToken => null;
            public override Response GetRawResponse() => throw new NotImplementedException();
        }
    }
}
