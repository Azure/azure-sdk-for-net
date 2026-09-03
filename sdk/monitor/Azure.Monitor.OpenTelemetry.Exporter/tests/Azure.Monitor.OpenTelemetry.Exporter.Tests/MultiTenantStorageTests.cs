// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;

using Azure.Core.Pipeline;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.MultiTenant;

using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class MultiTenantStorageTests : IDisposable
    {
        private const string EastUs = "https://eastus-1.in.applicationinsights.azure.com/";
        private const string WestUs = "https://westus-2.in.applicationinsights.azure.com/";

        private readonly string _rootDirectory = Path.Combine(Path.GetTempPath(), $"mt-storage-{Guid.NewGuid():N}");

        [Fact]
        public void EachEndpointGetsItsOwnPartition()
        {
            using var storage = CreateStorage();

            var eastUs = storage.TryGet(EastUs);
            var westUs = storage.TryGet(WestUs);

            Assert.NotNull(eastUs);
            Assert.NotNull(westUs);
            Assert.NotEqual(eastUs!.Directory, westUs!.Directory);
            Assert.StartsWith(_rootDirectory, eastUs.Directory, StringComparison.Ordinal);
            Assert.StartsWith(_rootDirectory, westUs.Directory, StringComparison.Ordinal);
        }

        [Fact]
        public void TheSameEndpointReusesItsPartition()
        {
            using var storage = CreateStorage();

            Assert.Same(storage.TryGet(EastUs), storage.TryGet(EastUs));
        }

        /// <summary>
        /// The directory has to be derivable from the endpoint alone, because that is all a later
        /// process has to work out where a leftover blob should be posted.
        /// </summary>
        [Fact]
        public void PartitionDirectoryIsDerivedFromTheEndpoint()
        {
            using var storage = CreateStorage();

            var expected = Path.Combine(_rootDirectory, HashHelper.GetSHA256Hash(EastUs));

            Assert.Equal(expected, storage.TryGet(EastUs)!.Directory);
        }

        /// <summary>
        /// Each partition owns a directory, a drain timer, and a blob provider, so the count is
        /// capped rather than following the caller's endpoint count.
        /// </summary>
        [Fact]
        public void PartitionsAreBounded()
        {
            using var storage = CreateStorage();

            for (int i = 0; i < MultiTenantStorage.MaxEndpointPartitions; i++)
            {
                Assert.NotNull(storage.TryGet($"https://region-{i}.in.applicationinsights.azure.com/"));
            }

            Assert.Null(storage.TryGet("https://one-too-many.in.applicationinsights.azure.com/"));

            // An endpoint already holding a partition keeps working past the bound.
            Assert.NotNull(storage.TryGet("https://region-0.in.applicationinsights.azure.com/"));
        }

        [Fact]
        public void DisposeTearsDownEveryPartition()
        {
            var storage = CreateStorage();

            storage.TryGet(EastUs);
            storage.TryGet(WestUs);
            Assert.Equal(2, storage.Partitions.Count());

            storage.Dispose();

            Assert.Empty(storage.Partitions);
            Assert.Null(storage.TryGet(EastUs));
        }

        public void Dispose()
        {
            try
            {
                if (Directory.Exists(_rootDirectory))
                {
                    Directory.Delete(_rootDirectory, recursive: true);
                }
            }
            catch (IOException)
            {
                // A drain timer may still hold a handle; the temp directory ages out either way.
            }

            GC.SuppressFinalize(this);
        }

        private MultiTenantStorage CreateStorage()
        {
            var options = new AzureMonitorExporterOptions();
            var restClient = new ApplicationInsightsRestClient(new ClientDiagnostics(options), HttpPipelineBuilder.Build(options), EastUs);
            var connectionVars = new ConnectionVars("ikey", EastUs, EastUs, aadAudience: null);

            return new MultiTenantStorage(restClient, connectionVars, isAadEnabled: false, _rootDirectory, maxSizeBytes: 1024 * 1024, networkSdkStatsManager: null);
        }
    }
}
