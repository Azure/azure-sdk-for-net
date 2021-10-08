// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azure.IoT.ModelsRepository.Tests
{
    public class GetModelsIntegrationTests : ModelsRepositoryRecordedTestBase
    {
        public GetModelsIntegrationTests(bool isAsync) : base(isAsync)
        {
        }

        [TestCase(ModelsRepositoryTestBase.ClientType.Local, false)]
        [TestCase(ModelsRepositoryTestBase.ClientType.Remote, false)]
        public void GetModelsWithWrongCasingThrowsException(ModelsRepositoryTestBase.ClientType clientType, bool hasMetadata)
        {
            const string dtmi = "dtmi:com:example:thermostat;1";

            ModelsRepositoryClient client = GetClient(clientType, false);
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

        [TestCase(ModelsRepositoryTestBase.ClientType.Local, true)]
        [TestCase(ModelsRepositoryTestBase.ClientType.Local, false)]
        [TestCase(ModelsRepositoryTestBase.ClientType.Remote, true)]
        [TestCase(ModelsRepositoryTestBase.ClientType.Remote, false)]
        public async Task GetModelsSingleDtmiNoDeps(ModelsRepositoryTestBase.ClientType clientType, bool hasMetadata)
        {
            const string dtmi = "dtmi:com:example:Thermostat;1";

            ModelsRepositoryClient client = GetClient(clientType, hasMetadata);
            IDictionary<string, string> result = await client.GetModelsAsync(dtmi);
            result.Keys.Count.Should().Be(1);
            result.Should().ContainKey(dtmi);
            ModelsRepositoryTestBase.ParseRootDtmiFromJson(result[dtmi]).Should().Be(dtmi);
        }

        [TestCase(ModelsRepositoryTestBase.ClientType.Local, true)]
        [TestCase(ModelsRepositoryTestBase.ClientType.Local, false)]
        [TestCase(ModelsRepositoryTestBase.ClientType.Remote, true)]
        [TestCase(ModelsRepositoryTestBase.ClientType.Remote, false)]
        public async Task GetModelsMultipleDtmisNoDeps(ModelsRepositoryTestBase.ClientType clientType, bool hasMetadata)
        {
            const string dtmi1 = "dtmi:com:example:Thermostat;1";
            const string dtmi2 = "dtmi:azure:DeviceManagement:DeviceInformation;1";

            ModelsRepositoryClient client = GetClient(clientType, hasMetadata);
            IDictionary<string, string> result = await client.GetModelsAsync(new string[] { dtmi1, dtmi2 });
            result.Keys.Count.Should().Be(2);
            result.Should().ContainKey(dtmi1);
            result.Should().ContainKey(dtmi2);
            ModelsRepositoryTestBase.ParseRootDtmiFromJson(result[dtmi1]).Should().Be(dtmi1);
            ModelsRepositoryTestBase.ParseRootDtmiFromJson(result[dtmi2]).Should().Be(dtmi2);
        }

        [TestCase(ModelsRepositoryTestBase.ClientType.Local, true)]
        [TestCase(ModelsRepositoryTestBase.ClientType.Local, false)]
        [TestCase(ModelsRepositoryTestBase.ClientType.Remote, true)]
        [TestCase(ModelsRepositoryTestBase.ClientType.Remote, false)]
        public async Task GetModelsSingleDtmiWithDeps(ModelsRepositoryTestBase.ClientType clientType, bool hasMetadata)
        {
            const string dtmi = "dtmi:com:example:TemperatureController;1";
            const string expectedDeps = "dtmi:com:example:Thermostat;1,dtmi:azure:DeviceManagement:DeviceInformation;1";

            ModelsRepositoryClient client = GetClient(clientType, hasMetadata);
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

        [TestCase(ModelsRepositoryTestBase.ClientType.Local)]
        [TestCase(ModelsRepositoryTestBase.ClientType.Remote)]
        public async Task GetModelsMultipleDtmisEnsuresNoDupes(ModelsRepositoryTestBase.ClientType clientType)
        {
            const string dtmiDupe1 = "dtmi:azure:DeviceManagement:DeviceInformation;1";
            const string dtmiDupe2 = "dtmi:azure:DeviceManagement:DeviceInformation;1";

            ModelsRepositoryClient client = GetClient(clientType);
            IDictionary<string, string> result = await client.GetModelsAsync(new[] { dtmiDupe1, dtmiDupe2 });

            result.Keys.Count.Should().Be(1);
            ModelsRepositoryTestBase.ParseRootDtmiFromJson(result[dtmiDupe1]).Should().Be(dtmiDupe1);
        }

        [TestCase(ModelsRepositoryTestBase.ClientType.Local)]
        [TestCase(ModelsRepositoryTestBase.ClientType.Remote)]
        public async Task GetModelsSingleDtmiWithDepsDisabledDependencyResolution(ModelsRepositoryTestBase.ClientType clientType)
        {
            const string dtmi = "dtmi:com:example:TemperatureController;1";
            ModelsRepositoryClient client = GetClient(clientType);

            IDictionary<string, string> result = await client.GetModelsAsync(dtmi, ModelDependencyResolution.Disabled);

            result.Keys.Count.Should().Be(1);
            result.Should().ContainKey(dtmi);
            ModelsRepositoryTestBase.ParseRootDtmiFromJson(result[dtmi]).Should().Be(dtmi);
        }

        public async Task GetModelsSingleDtmiWithDepsUseMetadataEnsureTryFromExpanded()
        {
            const string dtmi = "dtmi:com:example:DanglingExpanded;1";
            const string expectedDeps = "dtmi:com:example:Thermostat;1,dtmi:azure:DeviceManagement:DeviceInformation;1";

            ModelsRepositoryClient client = GetClient(ModelsRepositoryTestBase.ClientType.Local, true);

            IDictionary<string, string> result = await client.GetModelsAsync(dtmi, ModelDependencyResolution.Enabled);
            var expectedDtmis = $"{dtmi},{expectedDeps}".Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            result.Keys.Count.Should().Be(expectedDtmis.Length);

            foreach (var id in expectedDtmis)
            {
                result.Should().ContainKey(id);
                ModelsRepositoryTestBase.ParseRootDtmiFromJson(result[id]).Should().Be(id);
            }
        }

        [TestCase(ModelsRepositoryTestBase.ClientType.Local, true)]
        [TestCase(ModelsRepositoryTestBase.ClientType.Local, false)]
        public async Task GetModelsMultipleDtmisWithDepsPartialTryFromExpanded(ModelsRepositoryTestBase.ClientType clientType, bool hasMetadata)
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

            ModelsRepositoryClientOptions options = new ModelsRepositoryClientOptions();
            ModelsRepositoryClient client = GetClient(ModelsRepositoryTestBase.ClientType.Local, hasMetadata, options);

            // Multi-resolve dtmi:com:example:TemperatureController;1 + dtmi:com:example:ColdStorage;1
            IDictionary<string, string> result = await client.GetModelsAsync(new[] { expandedDtmis[0], nonExpandedDtmis[0] });

            result.Keys.Count.Should().Be(totalDtmis.Length);
            foreach (string id in totalDtmis)
            {
                result.Should().ContainKey(id);
                ModelsRepositoryTestBase.ParseRootDtmiFromJson(result[id]).Should().Be(id);
            }
        }

        [TestCase(ModelsRepositoryTestBase.ClientType.Remote, ModelsRepositoryTestBase.TimeSpanAlias.TimeSpanZero, true)]
        [TestCase(ModelsRepositoryTestBase.ClientType.Remote, ModelsRepositoryTestBase.TimeSpanAlias.TimeSpanZero, false)]
        [TestCase(ModelsRepositoryTestBase.ClientType.Local, ModelsRepositoryTestBase.TimeSpanAlias.TimeSpanZero, true)]
        [TestCase(ModelsRepositoryTestBase.ClientType.Local, ModelsRepositoryTestBase.TimeSpanAlias.TimeSpanZero, false)]
        public async Task MultipleGetModelsSingleDtmiWithDepsCustomMetadataExpiry(
            ModelsRepositoryTestBase.ClientType clientType,
            ModelsRepositoryTestBase.TimeSpanAlias timeSpanAlias,
            bool hasMetadata)
        {
            TimeSpan targetTimeSpan = ModelsRepositoryTestBase.ConvertAliasToTimeSpan(timeSpanAlias);
            const string rootDtmi = "dtmi:com:example:TemperatureController;1";
            const string expectedDeps = "dtmi:com:example:Thermostat;1,dtmi:azure:DeviceManagement:DeviceInformation;1";

            var options = new ModelsRepositoryClientOptions();
            options.Metadata.Expiration = targetTimeSpan;
            ModelsRepositoryClient client = GetClient(clientType, hasMetadata: hasMetadata, options);
            var expectedDtmis = $"{rootDtmi},{expectedDeps}".Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < 2; i++)
            {
                IDictionary<string, string> resultWithDeps = await client.GetModelsAsync(rootDtmi);

                resultWithDeps.Keys.Count.Should().Be(expectedDtmis.Length);

                foreach (var id in expectedDtmis)
                {
                    resultWithDeps.Should().ContainKey(id);
                    ModelsRepositoryTestBase.ParseRootDtmiFromJson(resultWithDeps[id]).Should().Be(id);
                }

                IDictionary<string, string> resultNoDeps = await client.GetModelsAsync(rootDtmi, ModelDependencyResolution.Disabled);
                resultNoDeps.Keys.Count.Should().Be(1);
                resultNoDeps.Should().ContainKey(rootDtmi);
                ModelsRepositoryTestBase.ParseRootDtmiFromJson(resultNoDeps[rootDtmi]).Should().Be(rootDtmi);
            }
        }
    }
}
