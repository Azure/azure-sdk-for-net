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

namespace Azure.Storage.Blobs.ChangeFeed.Tests
{
    [ClientTestFixture(
        BlobClientOptions.ServiceVersion.V2020_06_12,
        BlobClientOptions.ServiceVersion.V2020_08_04,
        BlobClientOptions.ServiceVersion.V2020_10_02,
        BlobClientOptions.ServiceVersion.V2020_12_06,
        BlobClientOptions.ServiceVersion.V2021_02_12,
        BlobClientOptions.ServiceVersion.V2021_04_10,
        BlobClientOptions.ServiceVersion.V2021_06_08,
        BlobClientOptions.ServiceVersion.V2021_08_06,
        BlobClientOptions.ServiceVersion.V2021_10_04,
        BlobClientOptions.ServiceVersion.V2021_12_02,
        BlobClientOptions.ServiceVersion.V2022_11_02,
        BlobClientOptions.ServiceVersion.V2023_01_03,
        BlobClientOptions.ServiceVersion.V2023_05_03,
        BlobClientOptions.ServiceVersion.V2023_08_03,
        BlobClientOptions.ServiceVersion.V2023_11_03,
        BlobClientOptions.ServiceVersion.V2024_02_04,
        BlobClientOptions.ServiceVersion.V2024_05_04,
        BlobClientOptions.ServiceVersion.V2024_08_04,
        BlobClientOptions.ServiceVersion.V2024_11_04,
        BlobClientOptions.ServiceVersion.V2025_01_05,
        BlobClientOptions.ServiceVersion.V2025_05_05,
        BlobClientOptions.ServiceVersion.V2025_07_05,
        BlobClientOptions.ServiceVersion.V2025_11_05,
        StorageVersionExtensions.LatestVersion,
        StorageVersionExtensions.MaxVersion,
    RecordingServiceVersion = StorageVersionExtensions.MaxVersion,
    LiveServiceVersions = new object[] { StorageVersionExtensions.LatestVersion })]
    public class ChangeFeedTestBase : StorageTestBase<StorageTestEnvironment>
    {
        protected readonly BlobClientOptions.ServiceVersion _serviceVersion;

        public ChangeFeedTestBase(bool async, BlobClientOptions.ServiceVersion serviceVersion, RecordedTestMode? mode = null)
            : base(async, mode)
        {
            _serviceVersion = serviceVersion;
        }

        public string GetNewContainerName() => $"test-container-{Recording.Random.NewGuid()}";
        public string GetNewBlobName() => $"test-blob-{Recording.Random.NewGuid()}";

        public BlobServiceClient GetServiceClient_SharedKey()
            => InstrumentClient(
                new BlobServiceClient(
                    new Uri(TestConfigDefault.BlobServiceEndpoint),
                    new StorageSharedKeyCredential(
                        TestConfigDefault.AccountName,
                        TestConfigDefault.AccountKey),
                    GetOptions()));

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

        public async Task<DisposingContainer> GetTestContainerAsync(
            BlobServiceClient service = default,
            string containerName = default,
            IDictionary<string, string> metadata = default,
            PublicAccessType? publicAccessType = default,
            bool premium = default)
        {
            containerName ??= GetNewContainerName();
            service ??= GetServiceClient_SharedKey();

            if (publicAccessType == default)
            {
                publicAccessType = PublicAccessType.None;
            }

            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(containerName));
            await container.CreateAsync(metadata: metadata, publicAccessType: publicAccessType.Value);
            return new DisposingContainer(container);
        }

        public class DisposingContainer : IAsyncDisposable
        {
            public BlobContainerClient Container;

            public DisposingContainer(BlobContainerClient client)
            {
                Container = client;
            }

            public async ValueTask DisposeAsync()
            {
                if (Container != null)
                {
                    try
                    {
                        await Container.DeleteAsync();
                        Container = null;
                    }
                    catch
                    {
                        // swallow the exception to avoid hiding another test failure
                    }
                }
            }
        }

        public static Task<Page<BlobHierarchyItem>> GetYearsPathFuncAsync(string continuation, int? pageSizeHint)
            => Task.FromResult(GetYearPathFunc(continuation, pageSizeHint));

        public static Page<BlobHierarchyItem> GetYearPathFunc(
            string continuation,
            int? pageSizeHint)
            => new BlobHierarchyItemPage(new List<BlobHierarchyItem>
            {
                BlobsModelFactory.BlobHierarchyItem("idx/segments/1601/", null),
                BlobsModelFactory.BlobHierarchyItem("idx/segments/2019/", null),
                BlobsModelFactory.BlobHierarchyItem("idx/segments/2020/", null),
                BlobsModelFactory.BlobHierarchyItem("idx/segments/2022/", null),
                BlobsModelFactory.BlobHierarchyItem("idx/segments/2023/", null),
            });

        public static Task<Page<BlobHierarchyItem>> GetSegmentsInYearFuncAsync(
            string continuation,
            int? pageSizeHint)
            => Task.FromResult(GetSegmentsInYearFunc(continuation, pageSizeHint));

        public static Page<BlobHierarchyItem> GetSegmentsInYearFunc(
            string continuation,
            int? pageSizeHint)
            => new BlobHierarchyItemPage(new List<BlobHierarchyItem>
            {
                BlobsModelFactory.BlobHierarchyItem(
                    null,
                    BlobsModelFactory.BlobItem("idx/segments/2020/01/16/2300/meta.json", false, null)),
                BlobsModelFactory.BlobHierarchyItem(
                    null,
                    BlobsModelFactory.BlobItem("idx/segments/2020/03/02/2300/meta.json", false, null)),
                BlobsModelFactory.BlobHierarchyItem(
                    null,
                    BlobsModelFactory.BlobItem("idx/segments/2020/03/03/0000/meta.json", false, null)),
                BlobsModelFactory.BlobHierarchyItem(
                    null,
                    BlobsModelFactory.BlobItem("idx/segments/2020/03/03/1800/meta.json", false, null)),
                BlobsModelFactory.BlobHierarchyItem(
                    null,
                    BlobsModelFactory.BlobItem("idx/segments/2020/03/03/2000/meta.json", false, null)),
                BlobsModelFactory.BlobHierarchyItem(
                    null,
                    BlobsModelFactory.BlobItem("idx/segments/2020/03/03/2200/meta.json", false, null)),
                BlobsModelFactory.BlobHierarchyItem(
                    null,
                    BlobsModelFactory.BlobItem("idx/segments/2020/03/05/1700/meta.json", false, null)),
            });

        public class BlobHierarchyItemPage : Page<BlobHierarchyItem>
        {
            private List<BlobHierarchyItem> _items;

            public BlobHierarchyItemPage(List<BlobHierarchyItem> items)
            {
                _items = items;
            }

            public override IReadOnlyList<BlobHierarchyItem> Values => _items;

            public override string ContinuationToken => null;

            public override Response GetRawResponse()
            {
                throw new NotImplementedException();
            }
        }
    }
}
