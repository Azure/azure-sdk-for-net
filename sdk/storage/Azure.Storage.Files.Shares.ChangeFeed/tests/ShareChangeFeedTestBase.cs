// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Files.Shares;
using Azure.Storage.Test.Shared;

namespace Azure.Storage.Files.Shares.ChangeFeed.Tests
{
    /// <summary>
    /// Base class for Share Change Feed tests, providing shared mock data and helper methods
    /// for building <see cref="BlobClientOptions"/> and simulating year/segment blob hierarchies.
    /// </summary>
    [ClientTestFixture(
        ShareClientOptions.ServiceVersion.V2026_02_06,
        ShareClientOptions.ServiceVersion.V2026_04_06,
        ShareClientOptions.ServiceVersion.V2026_06_06,
        StorageVersionExtensions.LatestVersion,
        StorageVersionExtensions.MaxVersion,
    RecordingServiceVersion = StorageVersionExtensions.MaxVersion,
    LiveServiceVersions = new object[] { StorageVersionExtensions.LatestVersion })]
    public class ShareChangeFeedTestBase : StorageTestBase<StorageTestEnvironment>
    {
        protected readonly ShareClientOptions.ServiceVersion _serviceVersion;

        /// <summary>
        /// Initializes the test base with async mode, service version, and optional recorded test mode.
        /// </summary>
        public ShareChangeFeedTestBase(bool async, ShareClientOptions.ServiceVersion serviceVersion, RecordedTestMode? mode = null)
            : base(async, mode)
        {
            _serviceVersion = serviceVersion;
        }

        /// <summary>
        /// Creates instrumented <see cref="ShareClientOptions"/> configured with retry policy and recording support.
        /// </summary>
        public ShareClientOptions GetOptions()
        {
            ShareClientOptions options = new ShareClientOptions(_serviceVersion)
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
        /// Creates an instrumented <see cref="ShareServiceClient"/> using shared key authentication.
        /// </summary>
        public ShareServiceClient GetShareServiceClient_SharedKey()
            => InstrumentClient(
                new ShareServiceClient(
                    new Uri(TestConfigDefault.FileServiceEndpoint),
                    new StorageSharedKeyCredential(
                        TestConfigDefault.AccountName,
                        TestConfigDefault.AccountKey),
                    GetOptions()));

        /// <summary>
        /// Creates an instrumented <see cref="BlobServiceClient"/> using shared key authentication.
        /// </summary>
        public BlobServiceClient GetBlobServiceClient_SharedKey()
            => InstrumentClient(
                new BlobServiceClient(
                    new Uri(TestConfigDefault.BlobServiceEndpoint),
                    new StorageSharedKeyCredential(
                        TestConfigDefault.AccountName,
                        TestConfigDefault.AccountKey)));

        /// <summary>
        /// Returns a page of mock year-level prefix paths (e.g., "idx/segments/2024/") for test setup.
        /// </summary>
        public static Page<BlobHierarchyItem> GetYearPathFunc(string continuation, int? pageSizeHint)
            => new BlobHierarchyItemPage(new List<BlobHierarchyItem>
            {
                BlobsModelFactory.BlobHierarchyItem("idx/segments/1601/", null),
                BlobsModelFactory.BlobHierarchyItem("idx/segments/2023/", null),
                BlobsModelFactory.BlobHierarchyItem("idx/segments/2024/", null),
            });

        /// <summary>
        /// Async wrapper for <see cref="GetYearPathFunc"/>.
        /// </summary>
        public static Task<Page<BlobHierarchyItem>> GetYearPathFuncAsync(string continuation, int? pageSizeHint)
            => Task.FromResult(GetYearPathFunc(continuation, pageSizeHint));

        /// <summary>
        /// Returns a page of mock segment paths within a single year, representing 15-minute time windows.
        /// </summary>
        public static Page<BlobHierarchyItem> GetSegmentsInYearFunc(string continuation, int? pageSizeHint)
            => new BlobHierarchyItemPage(new List<BlobHierarchyItem>
            {
                // Each segment path uses HHmm format representing 15-minute windows: 08:00, 08:15, 08:30, 08:45, 09:00
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

        /// <summary>
        /// Async wrapper for <see cref="GetSegmentsInYearFunc"/>.
        /// </summary>
        public static Task<Page<BlobHierarchyItem>> GetSegmentsInYearFuncAsync(string continuation, int? pageSizeHint)
            => Task.FromResult(GetSegmentsInYearFunc(continuation, pageSizeHint));

        /// <summary>
        /// Minimal <see cref="Page{T}"/> implementation that wraps a list of <see cref="BlobHierarchyItem"/>
        /// for use in mock pageable responses. Always returns a null continuation token (single page).
        /// </summary>
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
