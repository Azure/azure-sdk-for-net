// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Tests
{
    [ClientTestFixture(ConfigurationClientOptions.ServiceVersion.V2026_05_01_Preview)]
    public class FeatureFlagLiveTests : RecordedTestBase<AppConfigurationTestEnvironment>
    {
        private readonly ConfigurationClientOptions.ServiceVersion _serviceVersion;

        public FeatureFlagLiveTests(bool isAsync, ConfigurationClientOptions.ServiceVersion serviceVersion) : base(isAsync)
        {
            _serviceVersion = serviceVersion;
        }

        private string GenerateName(string prefix = "ff-")
            => prefix + (Mode == RecordedTestMode.Playback ? Guid.NewGuid().ToString("N") : Recording.GenerateId());

        private FeatureFlagClient GetClient(bool skipInstrumentation = false)
        {
            FeatureFlagClientOptions clientOptions = new FeatureFlagClientOptions(
                Enum.Parse<FeatureFlagClientOptions.ServiceVersion>(_serviceVersion.ToString()));
            FeatureFlagClientOptions options = InstrumentClientOptions(clientOptions);
            // Set audience AFTER InstrumentClientOptions, as it might reset the options
            options.Audience = TestEnvironment.GetAudience();
            FeatureFlagClient client = new FeatureFlagClient(new System.Uri(TestEnvironment.Endpoint), TestEnvironment.Credential, options);
            // Conditional paging relies on the concrete pageable type, which client instrumentation
            // wraps; such tests opt out of instrumentation and provide explicit sync/async variants.
            return skipInstrumentation ? client : InstrumentClient(client);
        }

        private async Task<FeatureFlagClient> GetClientOrSkipIfApiVersionUnsupportedAsync(bool skipInstrumentation = false)
        {
            if (Mode != RecordedTestMode.Live)
            {
                Assert.Ignore("Feature flag preview tests run in Live mode only.");
            }

            FeatureFlagClient service = GetClient(skipInstrumentation);

            try
            {
                // A missing key should return 404 when the API version is supported.
                await service.GetFeatureFlagAsync(GenerateName("ff-probe-"));
            }
            catch (RequestFailedException ex) when (IsUnsupportedApiVersion(ex))
            {
                Assert.Ignore($"Feature flag tests require API version {ConfigurationClientOptions.ServiceVersion.V2026_05_01_Preview}.");
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                // Expected probe response when the API version is supported.
            }

            return service;
        }

        private static bool IsUnsupportedApiVersion(RequestFailedException ex)
            => ex.Status == 400 && ex.Message.IndexOf("Unsupported API version", StringComparison.OrdinalIgnoreCase) >= 0;

        private static async Task SafeDeleteAsync(FeatureFlagClient service, string name, string label = null)
        {
            try
            {
                await service.DeleteFeatureFlagAsync(name, label);
            }
            catch (RequestFailedException)
            {
                // Best-effort cleanup; ignore failures.
            }
        }

        [RecordedTest]
        public async Task CanAddFeatureFlag()
        {
            FeatureFlagClient service = await GetClientOrSkipIfApiVersionUnsupportedAsync();
            string name = GenerateName();

            try
            {
                Response<FeatureFlag> response = await service.AddFeatureFlagAsync(name, enabled: true);

                Assert.That(response.Value, Is.Not.Null);
                Assert.That(response.Value.Name, Is.EqualTo(name));
                Assert.That(response.Value.Enabled, Is.EqualTo(true));
                Assert.That(response.Value.Etag, Is.Not.Null.And.Not.Empty);
            }
            finally
            {
                await SafeDeleteAsync(service, name);
            }
        }

        [RecordedTest]
        public async Task CanAddFeatureFlagWithFullBody()
        {
            FeatureFlagClient service = await GetClientOrSkipIfApiVersionUnsupportedAsync();
            string name = GenerateName();

            try
            {
                FeatureFlag flag = new FeatureFlag
                {
                    Enabled = true,
                    Description = "test description"
                };

                Response<FeatureFlag> response = await service.AddFeatureFlagAsync(name, flag);

                Assert.That(response.Value.Name, Is.EqualTo(name));
                Assert.That(response.Value.Enabled, Is.EqualTo(true));
                Assert.That(response.Value.Description, Is.EqualTo("test description"));
            }
            finally
            {
                await SafeDeleteAsync(service, name);
            }
        }

        [RecordedTest]
        public async Task AddFeatureFlagThrowsWhenAlreadyExists()
        {
            FeatureFlagClient service = await GetClientOrSkipIfApiVersionUnsupportedAsync();
            string name = GenerateName();

            try
            {
                await service.AddFeatureFlagAsync(name, enabled: true);

                RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(
                    async () => await service.AddFeatureFlagAsync(name, enabled: true));

                Assert.That(ex.Status, Is.EqualTo(412));
            }
            finally
            {
                await SafeDeleteAsync(service, name);
            }
        }

        [RecordedTest]
        public async Task AddFeatureFlagWithNullNameThrows()
        {
            FeatureFlagClient service = await GetClientOrSkipIfApiVersionUnsupportedAsync();

            Assert.ThrowsAsync<System.ArgumentNullException>(
                async () => await service.AddFeatureFlagAsync(null, enabled: true));
            Assert.ThrowsAsync<System.ArgumentException>(
                async () => await service.AddFeatureFlagAsync(string.Empty, enabled: true));
        }

        [RecordedTest]
        public async Task CanGetFeatureFlag()
        {
            FeatureFlagClient service = await GetClientOrSkipIfApiVersionUnsupportedAsync();
            string name = GenerateName();

            try
            {
                await service.AddFeatureFlagAsync(name, enabled: true);

                Response<FeatureFlag> response = await service.GetFeatureFlagAsync(name);

                Assert.That(response.Value.Name, Is.EqualTo(name));
                Assert.That(response.Value.Enabled, Is.EqualTo(true));
            }
            finally
            {
                await SafeDeleteAsync(service, name);
            }
        }

        [RecordedTest]
        public async Task GetFeatureFlagThrowsWhenNotFound()
        {
            FeatureFlagClient service = await GetClientOrSkipIfApiVersionUnsupportedAsync();
            string name = GenerateName("ff-missing-");

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(
                async () => await service.GetFeatureFlagAsync(name));

            Assert.That(ex.Status, Is.EqualTo(404));
        }

        [RecordedTest]
        public async Task SetFeatureFlagCreatesWhenMissing()
        {
            FeatureFlagClient service = await GetClientOrSkipIfApiVersionUnsupportedAsync();
            string name = GenerateName();

            try
            {
                Response<FeatureFlag> response = await service.SetFeatureFlagAsync(name, enabled: false);

                Assert.That(response.Value.Name, Is.EqualTo(name));
                Assert.That(response.Value.Enabled, Is.EqualTo(false));
            }
            finally
            {
                await SafeDeleteAsync(service, name);
            }
        }

        [RecordedTest]
        public async Task SetFeatureFlagOverwritesExisting()
        {
            FeatureFlagClient service = await GetClientOrSkipIfApiVersionUnsupportedAsync();
            string name = GenerateName();

            try
            {
                await service.AddFeatureFlagAsync(name, enabled: false);

                Response<FeatureFlag> response = await service.SetFeatureFlagAsync(name, enabled: true);

                Assert.That(response.Value.Name, Is.EqualTo(name));
                Assert.That(response.Value.Enabled, Is.EqualTo(true));
            }
            finally
            {
                await SafeDeleteAsync(service, name);
            }
        }

        [RecordedTest]
        public async Task SetFeatureFlagWithOnlyIfUnchangedSucceedsWhenEtagMatches()
        {
            FeatureFlagClient service = await GetClientOrSkipIfApiVersionUnsupportedAsync();
            string name = GenerateName();

            try
            {
                Response<FeatureFlag> added = await service.AddFeatureFlagAsync(name, enabled: false);

                FeatureFlag updated = new FeatureFlag
                {
                    Enabled = true,
                    Description = "updated"
                };
                // Copy etag from the added flag onto the new body so onlyIfUnchanged can be evaluated.
                FeatureFlag withEtag = CloneWithEtag(updated, added.Value.Etag);

                Response<FeatureFlag> response = await service.SetFeatureFlagAsync(name, withEtag, label: null, onlyIfUnchanged: true);

                Assert.That(response.Value.Enabled, Is.EqualTo(true));
                Assert.That(response.Value.Description, Is.EqualTo("updated"));
            }
            finally
            {
                await SafeDeleteAsync(service, name);
            }
        }

        [RecordedTest]
        public async Task SetFeatureFlagWithOnlyIfUnchangedThrowsWhenEtagStale()
        {
            FeatureFlagClient service = await GetClientOrSkipIfApiVersionUnsupportedAsync();
            string name = GenerateName();

            try
            {
                Response<FeatureFlag> added = await service.AddFeatureFlagAsync(name, enabled: false);
                // Bump the server-side etag.
                await service.SetFeatureFlagAsync(name, enabled: true);

                FeatureFlag stale = CloneWithEtag(new FeatureFlag { Enabled = false }, added.Value.Etag);

                RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(
                    async () => await service.SetFeatureFlagAsync(name, stale, label: null, onlyIfUnchanged: true));

                Assert.That(ex.Status, Is.EqualTo(412));
            }
            finally
            {
                await SafeDeleteAsync(service, name);
            }
        }

        [RecordedTest]
        public async Task CanDeleteFeatureFlag()
        {
            FeatureFlagClient service = await GetClientOrSkipIfApiVersionUnsupportedAsync();
            string name = GenerateName();

            await service.AddFeatureFlagAsync(name, enabled: true);

            Response response = await service.DeleteFeatureFlagAsync(name);
            Assert.That(response.Status, Is.EqualTo(200));

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(
                async () => await service.GetFeatureFlagAsync(name));
            Assert.That(ex.Status, Is.EqualTo(404));
        }

        [RecordedTest]
        public async Task DeleteFeatureFlagWhenMissingReturns204()
        {
            FeatureFlagClient service = await GetClientOrSkipIfApiVersionUnsupportedAsync();
            string name = GenerateName("ff-del-missing-");

            Response response = await service.DeleteFeatureFlagAsync(name);

            Assert.That(response.Status, Is.EqualTo(204));
        }

        [RecordedTest]
        public async Task LabelDistinguishesFeatureFlags()
        {
            FeatureFlagClient service = await GetClientOrSkipIfApiVersionUnsupportedAsync();
            string name = GenerateName();
            const string label = "prod";

            try
            {
                Response<FeatureFlag> withLabel = await service.AddFeatureFlagAsync(name, enabled: true, label);
                Response<FeatureFlag> noLabel = await service.AddFeatureFlagAsync(name, enabled: false);

                Assert.That(withLabel.Value.Label, Is.EqualTo(label));
                Assert.That(noLabel.Value.Label, Is.Null.Or.Empty);
                Assert.That(withLabel.Value.Enabled, Is.EqualTo(true));
                Assert.That(noLabel.Value.Enabled, Is.EqualTo(false));

                Response<FeatureFlag> getWithLabel = await service.GetFeatureFlagAsync(name, label);
                Response<FeatureFlag> getNoLabel = await service.GetFeatureFlagAsync(name);

                Assert.That(getWithLabel.Value.Enabled, Is.EqualTo(true));
                Assert.That(getNoLabel.Value.Enabled, Is.EqualTo(false));
            }
            finally
            {
                await SafeDeleteAsync(service, name, label);
                await SafeDeleteAsync(service, name);
            }
        }

        [RecordedTest]
        public async Task GetFeatureFlagIfChangedReturnsNotModifiedWhenEtagMatches()
        {
            FeatureFlagClient service = await GetClientOrSkipIfApiVersionUnsupportedAsync();
            string name = GenerateName();

            try
            {
                Response<FeatureFlag> added = await service.AddFeatureFlagAsync(name, enabled: true);

                Response<FeatureFlag> response = await service.GetFeatureFlagAsync(added.Value, onlyIfChanged: true);

                Assert.That(response.GetRawResponse().Status, Is.EqualTo(304));
            }
            finally
            {
                await SafeDeleteAsync(service, name);
            }
        }

        [RecordedTest]
        public async Task GetFeatureFlagIfChangedReturnsFlagWhenEtagStale()
        {
            FeatureFlagClient service = await GetClientOrSkipIfApiVersionUnsupportedAsync();
            string name = GenerateName();

            try
            {
                Response<FeatureFlag> added = await service.AddFeatureFlagAsync(name, enabled: true);
                // Bump the server-side etag so the client's copy is stale.
                await service.SetFeatureFlagAsync(name, enabled: false);

                Response<FeatureFlag> response = await service.GetFeatureFlagAsync(added.Value, onlyIfChanged: true);

                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value.Enabled, Is.EqualTo(false));
            }
            finally
            {
                await SafeDeleteAsync(service, name);
            }
        }

        [RecordedTest]
        public async Task GetFeatureFlagWithAcceptDateTimeReturnsFlag()
        {
            FeatureFlagClient service = await GetClientOrSkipIfApiVersionUnsupportedAsync();
            string name = GenerateName();

            try
            {
                Response<FeatureFlag> added = await service.AddFeatureFlagAsync(name, enabled: true);

                Response<FeatureFlag> response = await service.GetFeatureFlagAsync(added.Value, DateTimeOffset.UtcNow);

                Assert.That(response.Value.Name, Is.EqualTo(name));
                Assert.That(response.Value.Enabled, Is.EqualTo(true));
            }
            finally
            {
                await SafeDeleteAsync(service, name);
            }
        }

        [RecordedTest]
        public async Task DeleteFeatureFlagWithOnlyIfUnchangedSucceedsWhenEtagMatches()
        {
            FeatureFlagClient service = await GetClientOrSkipIfApiVersionUnsupportedAsync();
            string name = GenerateName();

            Response<FeatureFlag> added = await service.AddFeatureFlagAsync(name, enabled: true);

            Response response = await service.DeleteFeatureFlagAsync(added.Value, onlyIfUnchanged: true);
            Assert.That(response.Status, Is.EqualTo(200));

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(
                async () => await service.GetFeatureFlagAsync(name));
            Assert.That(ex.Status, Is.EqualTo(404));
        }

        [RecordedTest]
        public async Task DeleteFeatureFlagWithOnlyIfUnchangedThrowsWhenEtagStale()
        {
            FeatureFlagClient service = await GetClientOrSkipIfApiVersionUnsupportedAsync();
            string name = GenerateName();

            try
            {
                Response<FeatureFlag> added = await service.AddFeatureFlagAsync(name, enabled: true);
                // Bump the server-side etag so the client's copy is stale.
                await service.SetFeatureFlagAsync(name, enabled: false);

                RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(
                    async () => await service.DeleteFeatureFlagAsync(added.Value, onlyIfUnchanged: true));

                Assert.That(ex.Status, Is.EqualTo(412));
            }
            finally
            {
                await SafeDeleteAsync(service, name);
            }
        }

        [RecordedTest]
        [AsyncOnly]
        public async Task GetFeatureFlagsIfChangedReturnsNotModifiedPages()
        {
            FeatureFlagClient service = await GetClientOrSkipIfApiVersionUnsupportedAsync(skipInstrumentation: true);
            string label = GenerateName("ff-page-");
            string name1 = GenerateName();
            string name2 = GenerateName();

            try
            {
                await service.AddFeatureFlagAsync(name1, enabled: true, label);
                await service.AddFeatureFlagAsync(name2, enabled: false, label);

                FeatureFlagSelector selector = new FeatureFlagSelector { LabelFilter = label };

                var matchConditionsList = new List<MatchConditions>();
                int flagsReturned = 0;
                await foreach (Page<FeatureFlag> page in service.GetFeatureFlagsAsync(selector).AsPages())
                {
                    Response response = page.GetRawResponse();
                    matchConditionsList.Add(new MatchConditions { IfNoneMatch = response.Headers.ETag });
                    flagsReturned += page.Values.Count;
                }

                Assert.That(flagsReturned, Is.EqualTo(2));

                int pagesCount = 0;
                await foreach (Page<FeatureFlag> page in service.GetFeatureFlagsAsync(selector).AsPages(matchConditionsList))
                {
                    Response response = page.GetRawResponse();

                    Assert.That(response.Status, Is.EqualTo(304));
                    Assert.That(page.Values, Is.Empty);

                    pagesCount++;
                }

                Assert.That(pagesCount, Is.EqualTo(matchConditionsList.Count));
            }
            finally
            {
                await SafeDeleteAsync(service, name1, label);
                await SafeDeleteAsync(service, name2, label);
            }
        }

        [RecordedTest]
        [SyncOnly]
        public async Task GetFeatureFlagsIfChangedReturnsNotModifiedPagesSync()
        {
            FeatureFlagClient service = await GetClientOrSkipIfApiVersionUnsupportedAsync(skipInstrumentation: true);
            string label = GenerateName("ff-page-");
            string name1 = GenerateName();
            string name2 = GenerateName();

            try
            {
                await service.AddFeatureFlagAsync(name1, enabled: true, label);
                await service.AddFeatureFlagAsync(name2, enabled: false, label);

                FeatureFlagSelector selector = new FeatureFlagSelector { LabelFilter = label };

                var matchConditionsList = new List<MatchConditions>();
                int flagsReturned = 0;
                foreach (Page<FeatureFlag> page in service.GetFeatureFlags(selector).AsPages())
                {
                    Response response = page.GetRawResponse();
                    matchConditionsList.Add(new MatchConditions { IfNoneMatch = response.Headers.ETag });
                    flagsReturned += page.Values.Count;
                }

                Assert.That(flagsReturned, Is.EqualTo(2));

                int pagesCount = 0;
                foreach (Page<FeatureFlag> page in service.GetFeatureFlags(selector).AsPages(matchConditionsList))
                {
                    Response response = page.GetRawResponse();

                    Assert.That(response.Status, Is.EqualTo(304));
                    Assert.That(page.Values, Is.Empty);

                    pagesCount++;
                }

                Assert.That(pagesCount, Is.EqualTo(matchConditionsList.Count));
            }
            finally
            {
                await SafeDeleteAsync(service, name1, label);
                await SafeDeleteAsync(service, name2, label);
            }
        }

        // FeatureFlag.Etag is an init-time-only property, so we round-trip through the model factory
        // to obtain a flag instance whose Etag matches the server's value.
        private static FeatureFlag CloneWithEtag(FeatureFlag source, ETag? etag)
        {
            return ConfigurationModelFactory.FeatureFlag(
                name: source.Name,
                enabled: source.Enabled,
                label: source.Label,
                description: source.Description,
                conditions: source.Conditions,
                variants: source.Variants,
                allocation: source.Allocation,
                telemetry: source.Telemetry,
                tags: source.Tags,
                lastModified: source.LastModified,
                etag: etag);
        }
    }
}
