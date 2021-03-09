// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azure.Iot.ModelsRepository.Tests
{
    public class GetModelsIntegrationTests : ModelsRepositoryRecordedTestBase
    {
        public GetModelsIntegrationTests(bool isAsync) : base(isAsync)
        {
        }

        [TestCase(ModelsRepositoryTestBase.ClientType.Local)]
        [TestCase(ModelsRepositoryTestBase.ClientType.Remote)]
        public void GetModelsWithWrongCasingThrowsException(ModelsRepositoryTestBase.ClientType clientType)
        {
            const string dtmi = "dtmi:com:example:thermostat;1";

            ModelsRepositoryClient client = GetClient(clientType);
            string expectedExMsg =
                string.Format(StandardStrings.GenericGetModelsError, "dtmi:com:example:thermostat;1") +
                " " +
                string.Format(StandardStrings.IncorrectDtmiCasing, "dtmi:com:example:thermostat;1", "dtmi:com:example:Thermostat;1");

            Func<Task> act = async () => await client.GetModelsAsync(dtmi);
            act.Should().Throw<RequestFailedException>().WithMessage(expectedExMsg);
        }

        [TestCase("dtmi:com:example:Thermostat:1")]
        [TestCase("dtmi:com:example::Thermostat;1")]
        [TestCase("com:example:Thermostat;1")]
        public void GetModelsInvalidDtmiFormatThrowsException(string dtmi)
        {
            ModelsRepositoryClient client = GetClient(ModelsRepositoryTestBase.ClientType.Local);
            string expectedExMsg = $"{string.Format(StandardStrings.GenericGetModelsError, dtmi)} {string.Format(StandardStrings.InvalidDtmiFormat, dtmi)}";

            Func<Task> act = async () => await client.GetModelsAsync(dtmi);
            act.Should().Throw<ArgumentException>().WithMessage(expectedExMsg);
        }

        [TestCase(ModelsRepositoryTestBase.ClientType.Local)]
        [TestCase(ModelsRepositoryTestBase.ClientType.Remote)]
        public void GetModelsForNonExistentDtmiFileThrowsException(ModelsRepositoryTestBase.ClientType clientType)
        {
            const string dtmi = "dtmi:com:example:thermojax;999";

            ModelsRepositoryClient client = GetClient(clientType);

            Func<Task> act = async () => await client.GetModelsAsync(dtmi);
            act.Should().Throw<RequestFailedException>();
        }

        public void GetModelsInvalidDtmiDepsThrowsException()
        {
            const string dtmi = "dtmi:com:example:invalidmodel;1";
            const string invalidDep = "dtmi:azure:fakeDeviceManagement:FakeDeviceInformation;2";

            ModelsRepositoryClient client = GetClient(ModelsRepositoryTestBase.ClientType.Local);
            Func<Task> act = async () => await client.GetModelsAsync(dtmi);
            act.Should().Throw<RequestFailedException>().WithMessage($"Unable to resolve \"{invalidDep}\"");
        }

        [TestCase(ModelsRepositoryTestBase.ClientType.Local)]
        [TestCase(ModelsRepositoryTestBase.ClientType.Remote)]
        public async Task GetModelsSingleDtmiNoDeps(ModelsRepositoryTestBase.ClientType clientType)
        {
            const string dtmi = "dtmi:com:example:Thermostat;1";

            ModelsRepositoryClient client = GetClient(clientType);
            IDictionary<string, string> result = await client.GetModelsAsync(dtmi);
            result.Keys.Count.Should().Be(1);
            result.Should().ContainKey(dtmi);
            ModelsRepositoryTestBase.ParseRootDtmiFromJson(result[dtmi]).Should().Be(dtmi);
        }

        [TestCase(ModelsRepositoryTestBase.ClientType.Local)]
        [TestCase(ModelsRepositoryTestBase.ClientType.Remote)]
        public async Task GetModelsMultipleDtmisNoDeps(ModelsRepositoryTestBase.ClientType clientType)
        {
            const string dtmi1 = "dtmi:com:example:Thermostat;1";
            const string dtmi2 = "dtmi:azure:DeviceManagement:DeviceInformation;1";

            ModelsRepositoryClient client = GetClient(clientType);
            IDictionary<string, string> result = await client.GetModelsAsync(new string[] { dtmi1, dtmi2 });
            result.Keys.Count.Should().Be(2);
            result.Should().ContainKey(dtmi1);
            result.Should().ContainKey(dtmi2);
            ModelsRepositoryTestBase.ParseRootDtmiFromJson(result[dtmi1]).Should().Be(dtmi1);
            ModelsRepositoryTestBase.ParseRootDtmiFromJson(result[dtmi2]).Should().Be(dtmi2);
        }

        [TestCase(ModelsRepositoryTestBase.ClientType.Local)]
        [TestCase(ModelsRepositoryTestBase.ClientType.Remote)]
        public async Task GetModelsSingleDtmiWithDeps(ModelsRepositoryTestBase.ClientType clientType)
        {
            const string dtmi = "dtmi:com:example:TemperatureController;1";
            const string expectedDeps = "dtmi:com:example:Thermostat;1,dtmi:azure:DeviceManagement:DeviceInformation;1";

            ModelsRepositoryClient client = GetClient(clientType);
            IDictionary<string, string> result = await client.GetModelsAsync(dtmi);
            var expectedDtmis = $"{dtmi},{expectedDeps}".Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            result.Keys.Count.Should().Be(expectedDtmis.Length);

            foreach (var id in expectedDtmis)
            {
                result.Should().ContainKey(id);
                ModelsRepositoryTestBase.ParseRootDtmiFromJson(result[id]).Should().Be(id);
            }
        }

        public async Task GetModelsMultipleDtmisWithDeps()
        {
            const string dtmi1 = "dtmi:com:example:Phone;2";
            const string dtmi2 = "dtmi:com:example:TemperatureController;1";
            const string expectedDeps = "dtmi:com:example:Thermostat;1," +
                  "dtmi:azure:DeviceManagement:DeviceInformation;1," +
                  "dtmi:azure:DeviceManagement:DeviceInformation;2," +
                  "dtmi:com:example:Camera;3";

            ModelsRepositoryClient client = GetClient(ModelsRepositoryTestBase.ClientType.Local);
            IDictionary<string, string> result = await client.GetModelsAsync(new[] { dtmi1, dtmi2 });
            var expectedDtmis = $"{dtmi1},{dtmi2},{expectedDeps}".Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            result.Keys.Count.Should().Be(expectedDtmis.Length);

            foreach (var id in expectedDtmis)
            {
                result.Should().ContainKey(id);
                ModelsRepositoryTestBase.ParseRootDtmiFromJson(result[id]).Should().Be(id);
            }
        }

        public async Task GetModelsMultipleDtmisWithDepsFromExtends()
        {
            const string dtmi1 = "dtmi:com:example:TemperatureController;1";
            const string dtmi2 = "dtmi:com:example:ConferenceRoom;1";
            const string expectedDeps = "dtmi:com:example:Thermostat;1,dtmi:azure:DeviceManagement:DeviceInformation;1,dtmi:com:example:Room;1";
            ModelsRepositoryClient client = GetClient(ModelsRepositoryTestBase.ClientType.Local);
            IDictionary<string, string> result = await client.GetModelsAsync(new[] { dtmi1, dtmi2 });
            var expectedDtmis = $"{dtmi1},{dtmi2},{expectedDeps}".Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            result.Keys.Count.Should().Be(expectedDtmis.Length);

            foreach (var id in expectedDtmis)
            {
                result.Should().ContainKey(id);
                ModelsRepositoryTestBase.ParseRootDtmiFromJson(result[id]).Should().Be(id);
            }
        }

        public async Task GetModelsMultipleDtmisWithDepsFromExtendsVariant()
        {
            const string dtmi1 = "dtmi:com:example:TemperatureController;1";
            const string dtmi2 = "dtmi:com:example:ColdStorage;1";
            const string expectedDeps = "dtmi:com:example:Thermostat;1," +
                  "dtmi:azure:DeviceManagement:DeviceInformation;1," +
                  "dtmi:com:example:Room;1," +
                  "dtmi:com:example:Freezer;1";

            ModelsRepositoryClient client = GetClient(ModelsRepositoryTestBase.ClientType.Local);
            IDictionary<string, string> result = await client.GetModelsAsync(new[] { dtmi1, dtmi2 });
            var expectedDtmis = $"{dtmi1},{dtmi2},{expectedDeps}".Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            result.Keys.Count.Should().Be(expectedDtmis.Length);

            foreach (var id in expectedDtmis)
            {
                result.Should().ContainKey(id);
                ModelsRepositoryTestBase.ParseRootDtmiFromJson(result[id]).Should().Be(id);
            }
        }

        public async Task GetModelsSingleDtmiWithDepsFromExtendsInline()
        {
            const string dtmi = "dtmi:com:example:base;1";
            ModelsRepositoryClient client = GetClient(ModelsRepositoryTestBase.ClientType.Local);
            IDictionary<string, string> result = await client.GetModelsAsync(dtmi);

            result.Keys.Count.Should().Be(1);
            result.Should().ContainKey(dtmi);
            ModelsRepositoryTestBase.ParseRootDtmiFromJson(result[dtmi]).Should().Be(dtmi);
        }

        public async Task GetModelsSingleDtmiWithDepsFromExtendsInlineVariant()
        {
            const string dtmi = "dtmi:com:example:base;2";
            const string expected = "dtmi:com:example:Freezer;1," +
                  "dtmi:com:example:Thermostat;1";

            ModelsRepositoryClient client = GetClient(ModelsRepositoryTestBase.ClientType.Local);
            IDictionary<string, string> result = await client.GetModelsAsync(dtmi);
            var expectedDtmis = $"{dtmi},{expected}".Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            result.Keys.Count.Should().Be(expectedDtmis.Length);

            foreach (var id in expectedDtmis)
            {
                result.Should().ContainKey(id);
                ModelsRepositoryTestBase.ParseRootDtmiFromJson(result[id]).Should().Be(id);
            }
        }

        public async Task GetModelsEnsuresNoDupes()
        {
            const string dtmiDupe1 = "dtmi:azure:DeviceManagement:DeviceInformation;1";
            const string dtmiDupe2 = "dtmi:azure:DeviceManagement:DeviceInformation;1";

            ModelsRepositoryClient client = GetClient(ModelsRepositoryTestBase.ClientType.Local);
            IDictionary<string, string> result = await client.GetModelsAsync(new[] { dtmiDupe1, dtmiDupe2 });

            result.Keys.Count.Should().Be(1);
            ModelsRepositoryTestBase.ParseRootDtmiFromJson(result[dtmiDupe1]).Should().Be(dtmiDupe1);
        }

        [TestCase(ModelsRepositoryTestBase.ClientType.Local)]
        [TestCase(ModelsRepositoryTestBase.ClientType.Remote)]
        public async Task GetModelsSingleDtmiWithDepsDisableDependencyResolution(ModelsRepositoryTestBase.ClientType clientType)
        {
            const string dtmi = "dtmi:com:example:Thermostat;1";

            ModelsRepositoryClientOptions options = new ModelsRepositoryClientOptions(dependencyResolution: ModelDependencyResolution.Disabled);
            ModelsRepositoryClient client = GetClient(clientType, options);

            IDictionary<string, string> result = await client.GetModelsAsync(dtmi);

            result.Keys.Count.Should().Be(1);
            result.Should().ContainKey(dtmi);
            ModelsRepositoryTestBase.ParseRootDtmiFromJson(result[dtmi]).Should().Be(dtmi);
        }

        [TestCase(ModelsRepositoryTestBase.ClientType.Local)]
        [TestCase(ModelsRepositoryTestBase.ClientType.Remote)]
        public async Task GetModelsSingleDtmiWithDepsResolutionOptionOverrideAsDisabled(ModelsRepositoryTestBase.ClientType clientType)
        {
            const string dtmi = "dtmi:com:example:TemperatureController;1";

            ModelsRepositoryClient client = GetClient(clientType);

            // We would expect 3 models without the resolution option override.
            IDictionary<string, string> result = await client.GetModelsAsync(dtmi, dependencyResolution: ModelDependencyResolution.Disabled);
            var expectedDtmis = $"{dtmi}".Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            result.Keys.Count.Should().Be(expectedDtmis.Length);

            foreach (var id in expectedDtmis)
            {
                result.Should().ContainKey(id);
                ModelsRepositoryTestBase.ParseRootDtmiFromJson(result[id]).Should().Be(id);
            }
        }

        [TestCase(ModelsRepositoryTestBase.ClientType.Local)]
        [TestCase(ModelsRepositoryTestBase.ClientType.Remote)]
        public async Task GetModelsSingleDtmiWithDepsResolutionOptionOverrideAsEnabled(ModelsRepositoryTestBase.ClientType clientType)
        {
            const string dtmi = "dtmi:com:example:TemperatureController;1";
            const string expectedDeps = "dtmi:com:example:Thermostat;1,dtmi:azure:DeviceManagement:DeviceInformation;1";

            ModelsRepositoryClient client = GetClient(
                clientType, new ModelsRepositoryClientOptions(dependencyResolution: ModelDependencyResolution.Disabled));

            // We would expect 1 model without the resolution option override.
            IDictionary<string, string> result = await client.GetModelsAsync(dtmi, dependencyResolution: ModelDependencyResolution.Enabled);
            var expectedDtmis = $"{dtmi},{expectedDeps}".Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            result.Keys.Count.Should().Be(expectedDtmis.Length);

            foreach (var id in expectedDtmis)
            {
                result.Should().ContainKey(id);
                ModelsRepositoryTestBase.ParseRootDtmiFromJson(result[id]).Should().Be(id);
            }
        }

        [TestCase(ModelsRepositoryTestBase.ClientType.Local)]
        public async Task GetModelsSingleDtmiWithDepsResolutionOptionOverrideAsTryFromExpanded(ModelsRepositoryTestBase.ClientType clientType)
        {
            const string dtmi = "dtmi:com:example:DanglingExpanded;1";
            const string expectedDeps = "dtmi:com:example:Thermostat;1,dtmi:azure:DeviceManagement:DeviceInformation;1";

            ModelsRepositoryClient client = GetClient(
                clientType, new ModelsRepositoryClientOptions(dependencyResolution: ModelDependencyResolution.Disabled));

            // We would expect 1 model without the resolution option override.
            IDictionary<string, string> result = await client.GetModelsAsync(dtmi, dependencyResolution: ModelDependencyResolution.TryFromExpanded);
            var expectedDtmis = $"{dtmi},{expectedDeps}".Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            result.Keys.Count.Should().Be(expectedDtmis.Length);

            foreach (var id in expectedDtmis)
            {
                result.Should().ContainKey(id);
                ModelsRepositoryTestBase.ParseRootDtmiFromJson(result[id]).Should().Be(id);
            }
        }

        [TestCase(ModelsRepositoryTestBase.ClientType.Local)]
        [TestCase(ModelsRepositoryTestBase.ClientType.Remote)]
        public async Task GetModelsSingleDtmiTryFromExpanded(ModelsRepositoryTestBase.ClientType clientType)
        {
            const string dtmi = "dtmi:com:example:TemperatureController;1";
            const string expectedDeps = "dtmi:com:example:Thermostat;1,dtmi:azure:DeviceManagement:DeviceInformation;1";

            var expectedDtmis = $"{dtmi},{expectedDeps}".Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            ModelsRepositoryClientOptions options = new ModelsRepositoryClientOptions(dependencyResolution: ModelDependencyResolution.TryFromExpanded);
            ModelsRepositoryClient client = GetClient(clientType, options);

            IDictionary<string, string> result = await client.GetModelsAsync(dtmi);

            result.Keys.Count.Should().Be(expectedDtmis.Length);

            foreach (var id in expectedDtmis)
            {
                result.Should().ContainKey(id);
                ModelsRepositoryTestBase.ParseRootDtmiFromJson(result[id]).Should().Be(id);
            }
        }

        public async Task GetModelsMultipleDtmisTryFromExpandedPartial()
        {
            const string dtmisExpanded = "dtmi:com:example:TemperatureController;1," +  // Expanded available.
                  "dtmi:com:example:Thermostat;1," +
                  "dtmi:azure:DeviceManagement:DeviceInformation;1";

            const string dtmisNonExpanded = "dtmi:com:example:ColdStorage;1," + // Model uses extends[], No Expanded available.
                  "dtmi:com:example:Room;1," +
                  "dtmi:com:example:Freezer;1";

            string[] expandedDtmis = dtmisExpanded.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            string[] nonExpandedDtmis = dtmisNonExpanded.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            string[] totalDtmis = expandedDtmis.Concat(nonExpandedDtmis).ToArray();

            ModelsRepositoryClientOptions options = new ModelsRepositoryClientOptions(dependencyResolution: ModelDependencyResolution.TryFromExpanded);
            ModelsRepositoryClient client = GetClient(ModelsRepositoryTestBase.ClientType.Local, options);

            // Multi-resolve dtmi:com:example:TemperatureController;1 + dtmi:com:example:ColdStorage;1
            IDictionary<string, string> result = await client.GetModelsAsync(new[] { expandedDtmis[0], nonExpandedDtmis[0] });

            result.Keys.Count.Should().Be(totalDtmis.Length);
            foreach (string id in totalDtmis)
            {
                result.Should().ContainKey(id);
                ModelsRepositoryTestBase.ParseRootDtmiFromJson(result[id]).Should().Be(id);
            }
        }
    }
}
