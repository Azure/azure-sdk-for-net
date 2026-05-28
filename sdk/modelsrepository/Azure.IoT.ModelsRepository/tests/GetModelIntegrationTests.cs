// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using FluentAssertions;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using System.Text.Json;

namespace Azure.IoT.ModelsRepository.Tests
{
    public class GetModelIntegrationTests : ModelsRepositoryRecordedTestBase
    {
        public GetModelIntegrationTests(bool isAsync) : base(isAsync)
        {
        }

        [TestCase(ModelsRepositoryTestBase.ClientType.Local, false)]
        [TestCase(ModelsRepositoryTestBase.ClientType.Remote, false)]
        public void GetModelWrongDtmiCasingThrowsException(ModelsRepositoryTestBase.ClientType clientType, bool hasMetadata)
        {
            const string dtmi = "dtmi:com:example:thermostat;1";

            ModelsRepositoryClient client = GetClient(clientType, false);
            string expectedExMsg =
                string.Format(StandardStrings.GenericGetModelsError, "dtmi:com:example:thermostat;1") +
                " " +
                string.Format(StandardStrings.IncorrectDtmi, "dtmi:com:example:thermostat;1", "dtmi:com:example:Thermostat;1");

            Func<Task> act = async () => await client.GetModelAsync(dtmi);
            act.Should().Throw<RequestFailedException>().WithMessage(expectedExMsg);
        }

        [TestCase("dtmi:com:example:Thermostat:1")]
        [TestCase("dtmi:com:example::Thermostat;1")]
        [TestCase("com:example:Thermostat;1")]
        public void GetModelInvalidDtmiFormatThrowsException(string dtmi)
        {
            ModelsRepositoryClient client = GetClient(ModelsRepositoryTestBase.ClientType.Local);
            string expectedExMsg = $"{string.Format(StandardStrings.GenericGetModelsError, dtmi)} {string.Format(StandardStrings.InvalidDtmiFormat, dtmi)}";

            Func<Task> act = async () => await client.GetModelAsync(dtmi);
            act.Should().Throw<ArgumentException>().WithMessage(expectedExMsg);
        }

        [TestCase(ModelsRepositoryTestBase.ClientType.Local)]
        [TestCase(ModelsRepositoryTestBase.ClientType.Remote)]
        public void GetModelNonExistentDtmiFileThrowsException(ModelsRepositoryTestBase.ClientType clientType)
        {
            const string dtmi = "dtmi:com:example:thermojax;999";

            ModelsRepositoryClient client = GetClient(clientType);

            Func<Task> act = async () => await client.GetModelAsync(dtmi);
            act.Should().Throw<RequestFailedException>();
        }

        [Test]
        public void GetModelInvalidFileContentFormatThrowsException()
        {
            const string dtmi = "dtmi:com:example:invalidformat;1";

            ModelsRepositoryClient client = GetClient(ModelsRepositoryTestBase.ClientType.Local);
            Func<Task> act = async () => await client.GetModelAsync(dtmi);
            act.Should().Throw<JsonException>();
        }

        [Test]
        public void GetModelInvalidDtmiDependencyThrowsException()
        {
            const string dtmi = "dtmi:com:example:invalidmodel;1";
            const string invalidDep = "dtmi:azure:fakeDeviceManagement:FakeDeviceInformation;2";
            string invalidDepPath = DtmiConventions.GetModelUri(invalidDep, new Uri(ModelsRepositoryTestBase.TestLocalModelsRepository)).LocalPath;
            string expectedExMsg = $"{string.Format(StandardStrings.GenericGetModelsError, invalidDep)} {string.Format(StandardStrings.ErrorFetchingModelContent, invalidDepPath)}";

            ModelsRepositoryClient client = GetClient(ModelsRepositoryTestBase.ClientType.Local);
            Func<Task> act = async () => await client.GetModelAsync(dtmi);
            act.Should().Throw<RequestFailedException>().WithMessage(expectedExMsg);
        }

        [TestCase(ModelsRepositoryTestBase.ClientType.Local, true)]
        [TestCase(ModelsRepositoryTestBase.ClientType.Local, false)]
        [TestCase(ModelsRepositoryTestBase.ClientType.Remote, true)]
        [TestCase(ModelsRepositoryTestBase.ClientType.Remote, false)]
        public async Task GetModelNoDependencies(ModelsRepositoryTestBase.ClientType clientType, bool hasMetadata)
        {
            const string dtmi1 = "dtmi:com:example:Thermostat;1";
            const string dtmi2 = "dtmi:azure:DeviceManagement:DeviceInformation;1";
            string[] dtmis = new[] { dtmi1, dtmi2 };

            ModelsRepositoryClient client = GetClient(clientType, hasMetadata);

            // Multiple GetModel() execution with the same instance.
            foreach (var dtmi in dtmis)
            {
                ModelResult result = await client.GetModelAsync(dtmi);
                result.Content.Count.Should().Be(1);
                result.Content.ContainsKey(dtmi).Should().BeTrue();
                ModelsRepositoryTestBase.ParseRootDtmiFromJson(result.Content[dtmi]).Should().Be(dtmi);
            }
        }

        [TestCase(ModelsRepositoryTestBase.ClientType.Local, true)]
        [TestCase(ModelsRepositoryTestBase.ClientType.Local, false)]
        public async Task GetModelNoDependenciesWithMinorVersion(ModelsRepositoryTestBase.ClientType clientType, bool hasMetadata)
        {
            const string dtmi1 = "dtmi:com:example:Boiler";
            const string dtmi2 = "dtmi:com:example:Thermostat;1.2";
            string[] dtmis = new[] { dtmi1, dtmi2 };

            ModelsRepositoryClient client = GetClient(clientType, hasMetadata);

            // Multiple GetModel() execution with the same instance.
            foreach (var dtmi in dtmis)
            {
                ModelResult result = await client.GetModelAsync(dtmi);
                result.Content.Count.Should().Be(1);
                result.Content.ContainsKey(dtmi).Should().BeTrue();
                ModelsRepositoryTestBase.ParseRootDtmiFromJson(result.Content[dtmi]).Should().Be(dtmi);
            }
        }

        [TestCase(ModelsRepositoryTestBase.ClientType.Local, true)]
        [TestCase(ModelsRepositoryTestBase.ClientType.Local, false)]
        [TestCase(ModelsRepositoryTestBase.ClientType.Remote, true)]
        [TestCase(ModelsRepositoryTestBase.ClientType.Remote, false)]
        public async Task GetModelDependenciesComponents(ModelsRepositoryTestBase.ClientType clientType, bool hasMetadata)
        {
            const string dtmi = "dtmi:com:example:TemperatureController;1";
            const string expectedDeps = "dtmi:com:example:Thermostat;1,dtmi:azure:DeviceManagement:DeviceInformation;1";

            ModelsRepositoryClient client = GetClient(clientType, hasMetadata);
            ModelResult result = await client.GetModelAsync(dtmi);
            var expectedDtmis = $"{dtmi},{expectedDeps}".Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            result.Content.Count.Should().Be(expectedDtmis.Length);

            foreach (var id in expectedDtmis)
            {
                result.Content.ContainsKey(id).Should().BeTrue();
                ModelsRepositoryTestBase.ParseRootDtmiFromJson(result.Content[id]).Should().Be(id);
            }
        }

        [Test]
        public async Task GetModelDependenciesComponentsInline()
        {
            const string dtmi = "dtmi:com:example:Phone;2";
            const string expectedDeps = "dtmi:com:example:Camera;3,dtmi:azure:DeviceManagement:DeviceInformation;1," +
                "dtmi:azure:DeviceManagement:DeviceInformation;2";

            ModelsRepositoryClient client = GetClient(ModelsRepositoryTestBase.ClientType.Local);
            ModelResult result = await client.GetModelAsync(dtmi);
            var expectedDtmis = $"{dtmi},{expectedDeps}".Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            result.Content.Count.Should().Be(expectedDtmis.Length);

            foreach (var id in expectedDtmis)
            {
                result.Content.ContainsKey(id).Should().BeTrue();
                ModelsRepositoryTestBase.ParseRootDtmiFromJson(result.Content[id]).Should().Be(id);
            }
        }

        [Test]
        public async Task GetModelDependenciesExtendsSingleRef()
        {
            const string dtmi = "dtmi:com:example:ConferenceRoom;1";
            const string expectedDeps = "dtmi:com:example:Room;1";
            ModelsRepositoryClient client = GetClient(ModelsRepositoryTestBase.ClientType.Local);
            ModelResult result = await client.GetModelAsync(dtmi);
            var expectedDtmis = $"{dtmi},{expectedDeps}".Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            result.Content.Count.Should().Be(expectedDtmis.Length);

            foreach (var id in expectedDtmis)
            {
                result.Content.ContainsKey(id).Should().BeTrue();
                ModelsRepositoryTestBase.ParseRootDtmiFromJson(result.Content[id]).Should().Be(id);
            }
        }

        [TestCase(ModelsRepositoryTestBase.ClientType.Local, true)]
        [TestCase(ModelsRepositoryTestBase.ClientType.Local, false)]
        public async Task GetModelDependenciesExtendsArrayNoExpanded(ModelsRepositoryTestBase.ClientType clientType, bool hasMetadata)
        {
            const string dtmi = "dtmi:com:example:ColdStorage;1"; // Model uses extends[], expanded form not available.
            const string expectedDeps = "dtmi:com:example:Room;1,dtmi:com:example:Freezer;1," +
                "dtmi:com:example:Thermostat;1";

            ModelsRepositoryClient client = GetClient(clientType, hasMetadata);
            ModelResult result = await client.GetModelAsync(dtmi);
            var expectedDtmis = $"{dtmi},{expectedDeps}".Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            result.Content.Count.Should().Be(expectedDtmis.Length);

            foreach (var id in expectedDtmis)
            {
                result.Content.ContainsKey(id).Should().BeTrue();
                ModelsRepositoryTestBase.ParseRootDtmiFromJson(result.Content[id]).Should().Be(id);
            }
        }

        [Test]
        public async Task GetModelNoDependenciesExtendsInline()
        {
            const string dtmi = "dtmi:com:example:base;1";
            ModelsRepositoryClient client = GetClient(ModelsRepositoryTestBase.ClientType.Local);

            ModelResult result = await client.GetModelAsync(dtmi);

            result.Content.Count.Should().Be(1);
            result.Content.ContainsKey(dtmi).Should().BeTrue();
            ModelsRepositoryTestBase.ParseRootDtmiFromJson(result.Content[dtmi]).Should().Be(dtmi);
        }

        [Test]
        public async Task GetModelDependenciesExtendsArrayMixed()
        {
            const string dtmi = "dtmi:com:example:base;2";
            const string expected = "dtmi:com:example:Freezer;1," +
                  "dtmi:com:example:Thermostat;1";

            ModelsRepositoryClient client = GetClient(ModelsRepositoryTestBase.ClientType.Local);
            ModelResult result = await client.GetModelAsync(dtmi);
            var expectedDtmis = $"{dtmi},{expected}".Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            result.Content.Count.Should().Be(expectedDtmis.Length);

            foreach (var id in expectedDtmis)
            {
                result.Content.ContainsKey(id).Should().BeTrue();
                ModelsRepositoryTestBase.ParseRootDtmiFromJson(result.Content[id]).Should().Be(id);
            }
        }

        [TestCase(ModelsRepositoryTestBase.ClientType.Local)]
        [TestCase(ModelsRepositoryTestBase.ClientType.Remote)]
        public async Task GetModelDependenciesDisabledDependencyResolution(ModelsRepositoryTestBase.ClientType clientType)
        {
            const string dtmi = "dtmi:com:example:TemperatureController;1";
            ModelsRepositoryClient client = GetClient(clientType);

            ModelResult result = await client.GetModelAsync(dtmi, ModelDependencyResolution.Disabled);

            result.Content.Count.Should().Be(1);
            result.Content.ContainsKey(dtmi).Should().BeTrue();
            ModelsRepositoryTestBase.ParseRootDtmiFromJson(result.Content[dtmi]).Should().Be(dtmi);
        }

        [Test]
        public async Task GetModelDependenciesUseMetadataEnsureTryFromExpanded()
        {
            const string dtmi = "dtmi:com:example:DanglingExpanded;1";
            const string expectedDeps = "dtmi:com:example:Thermostat;1,dtmi:azure:DeviceManagement:DeviceInformation;1";

            ModelsRepositoryClient client = GetClient(ModelsRepositoryTestBase.ClientType.Local, true);

            ModelResult result = await client.GetModelAsync(dtmi, ModelDependencyResolution.Enabled);
            var expectedDtmis = $"{dtmi},{expectedDeps}".Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            result.Content.Count.Should().Be(expectedDtmis.Length);

            foreach (var id in expectedDtmis)
            {
                result.Content.ContainsKey(id).Should().BeTrue();
                ModelsRepositoryTestBase.ParseRootDtmiFromJson(result.Content[id]).Should().Be(id);
            }
        }
    }
}
