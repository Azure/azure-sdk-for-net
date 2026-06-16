// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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

        private string GenerateName(string prefix = "ff-") => prefix + Recording.GenerateId();

        private ConfigurationClient GetClient()
        {
            ConfigurationClientOptions options = InstrumentClientOptions(new ConfigurationClientOptions(_serviceVersion));
            return InstrumentClient(new ConfigurationClient(new System.Uri(TestEnvironment.Endpoint), TestEnvironment.Credential, options));
        }

        private static async Task SafeDeleteAsync(ConfigurationClient service, string name, string label = null)
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
            ConfigurationClient service = GetClient();
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
            ConfigurationClient service = GetClient();
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
            ConfigurationClient service = GetClient();
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
            ConfigurationClient service = GetClient();

            Assert.ThrowsAsync<System.ArgumentNullException>(
                async () => await service.AddFeatureFlagAsync(null, enabled: true));
            Assert.ThrowsAsync<System.ArgumentException>(
                async () => await service.AddFeatureFlagAsync(string.Empty, enabled: true));
        }

        [RecordedTest]
        public async Task CanGetFeatureFlag()
        {
            ConfigurationClient service = GetClient();
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
            ConfigurationClient service = GetClient();
            string name = GenerateName("ff-missing-");

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(
                async () => await service.GetFeatureFlagAsync(name));

            Assert.That(ex.Status, Is.EqualTo(404));
        }

        [RecordedTest]
        public async Task SetFeatureFlagCreatesWhenMissing()
        {
            ConfigurationClient service = GetClient();
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
            ConfigurationClient service = GetClient();
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
            ConfigurationClient service = GetClient();
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
            ConfigurationClient service = GetClient();
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
            ConfigurationClient service = GetClient();
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
            ConfigurationClient service = GetClient();
            string name = GenerateName("ff-del-missing-");

            Response response = await service.DeleteFeatureFlagAsync(name);

            Assert.That(response.Status, Is.EqualTo(204));
        }

        [RecordedTest]
        public async Task LabelDistinguishesFeatureFlags()
        {
            ConfigurationClient service = GetClient();
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

        // FeatureFlag.Etag is an init-time-only property, so we round-trip through the model factory
        // to obtain a flag instance whose Etag matches the server's value.
        private static FeatureFlag CloneWithEtag(FeatureFlag source, string etag)
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
