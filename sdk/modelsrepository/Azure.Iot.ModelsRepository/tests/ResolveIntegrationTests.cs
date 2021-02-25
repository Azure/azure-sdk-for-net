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
    public class ResolveIntegrationTests : ModelsRepositoryRecordedTestBase
    {
        public ResolveIntegrationTests(bool isAsync) : base(isAsync)
        {
        }

        [TestCase(ModelsRepositoryTestBase.ClientType.Local)]
        [TestCase(ModelsRepositoryTestBase.ClientType.Remote)]
        public void ResolveWithWrongCasingThrowsException(ModelsRepositoryTestBase.ClientType clientType)
        {
            const string dtmi = "dtmi:com:example:thermostat;1";

            ModelsRepositoryClient client = GetClient(clientType);
            string expectedExMsg =
                string.Format(StandardStrings.GenericResolverError, "dtmi:com:example:thermostat;1") +
                " " +
                string.Format(StandardStrings.IncorrectDtmiCasing, "dtmi:com:example:thermostat;1", "dtmi:com:example:Thermostat;1");

            Func<Task> act = async () => await client.ResolveAsync(dtmi);
            act.Should().Throw<RequestFailedException>().WithMessage(expectedExMsg);
        }

        [TestCase("dtmi:com:example:Thermostat:1")]
        [TestCase("dtmi:com:example::Thermostat;1")]
        [TestCase("com:example:Thermostat;1")]
        public void ResolveInvalidDtmiFormatThrowsException(string dtmi)
        {
            ModelsRepositoryClient client = GetClient(ModelsRepositoryTestBase.ClientType.Local);
            string expectedExMsg = $"{string.Format(StandardStrings.GenericResolverError, dtmi)} {string.Format(StandardStrings.InvalidDtmiFormat, dtmi)}";

            Func<Task> act = async () => await client.ResolveAsync(dtmi);
            act.Should().Throw<RequestFailedException>().WithMessage(expectedExMsg);
        }

        [TestCase(ModelsRepositoryTestBase.ClientType.Local)]
        [TestCase(ModelsRepositoryTestBase.ClientType.Remote)]
        public void ResolveNoneExistentDtmiFileThrowsException(ModelsRepositoryTestBase.ClientType clientType)
        {
            const string dtmi = "dtmi:com:example:thermojax;999";

            ModelsRepositoryClient client = GetClient(clientType);

            Func<Task> act = async () => await client.ResolveAsync(dtmi);
            act.Should().Throw<RequestFailedException>();
        }

        public void ResolveInvalidDtmiDepsThrowsException()
        {
            const string dtmi = "dtmi:com:example:invalidmodel;1";
            const string invalidDep = "dtmi:azure:fakeDeviceManagement:FakeDeviceInformation;2";

            ModelsRepositoryClient client = GetClient(ModelsRepositoryTestBase.ClientType.Local);
            Func<Task> act = async () => await client.ResolveAsync(dtmi);
            act.Should().Throw<RequestFailedException>().WithMessage($"Unable to resolve \"{invalidDep}\"");
        }

        [TestCase(ModelsRepositoryTestBase.ClientType.Local)]
        [TestCase(ModelsRepositoryTestBase.ClientType.Remote)]
        public async Task ResolveSingleModelNoDeps(ModelsRepositoryTestBase.ClientType clientType)
        {
            const string dtmi = "dtmi:com:example:Thermostat;1";

            ModelsRepositoryClient client = GetClient(clientType);
            IDictionary<string, string> result = await client.ResolveAsync(dtmi);
            result.Keys.Count.Should().Be(1);
            result.Should().ContainKey(dtmi);
            ModelsRepositoryTestBase.ParseRootDtmiFromJson(result[dtmi]).Should().Be(dtmi);
        }

        [TestCase(ModelsRepositoryTestBase.ClientType.Local)]
        [TestCase(ModelsRepositoryTestBase.ClientType.Remote)]
        public async Task ResolveMultipleModelsNoDeps(ModelsRepositoryTestBase.ClientType clientType)
        {
            const string dtmi1 = "dtmi:com:example:Thermostat;1";
            const string dtmi2 = "dtmi:azure:DeviceManagement:DeviceInformation;1";

            ModelsRepositoryClient client = GetClient(clientType);
            IDictionary<string, string> result = await client.ResolveAsync(new string[] { dtmi1, dtmi2 });
            result.Keys.Count.Should().Be(2);
            result.Should().ContainKey(dtmi1);
            result.Should().ContainKey(dtmi2);
            ModelsRepositoryTestBase.ParseRootDtmiFromJson(result[dtmi1]).Should().Be(dtmi1);
            ModelsRepositoryTestBase.ParseRootDtmiFromJson(result[dtmi2]).Should().Be(dtmi2);
        }

        [TestCase(ModelsRepositoryTestBase.ClientType.Local)]
        [TestCase(ModelsRepositoryTestBase.ClientType.Remote)]
        public async Task ResolveSingleModelWithDeps(ModelsRepositoryTestBase.ClientType clientType)
        {
            const string dtmi = "dtmi:com:example:TemperatureController;1";
            const string expectedDeps = "dtmi:com:example:Thermostat;1,dtmi:azure:DeviceManagement:DeviceInformation;1";

            ModelsRepositoryClient client = GetClient(clientType);
            IDictionary<string, string> result = await client.ResolveAsync(dtmi);
            var expectedDtmis = $"{dtmi},{expectedDeps}".Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            result.Keys.Count.Should().Be(expectedDtmis.Length);

            foreach (var id in expectedDtmis)
            {
                result.Should().ContainKey(id);
                ModelsRepositoryTestBase.ParseRootDtmiFromJson(result[id]).Should().Be(id);
            }
        }

        public async Task ResolveMultipleModelsWithDeps()
        {
            const string dtmi1 = "dtmi:com:example:Phone;2";
            const string dtmi2 = "dtmi:com:example:TemperatureController;1";
            const string expectedDeps = "dtmi:com:example:Thermostat;1," +
                  "dtmi:azure:DeviceManagement:DeviceInformation;1," +
                  "dtmi:azure:DeviceManagement:DeviceInformation;2," +
                  "dtmi:com:example:Camera;3";

            ModelsRepositoryClient client = GetClient(ModelsRepositoryTestBase.ClientType.Local);
            IDictionary<string, string> result = await client.ResolveAsync(new[] { dtmi1, dtmi2 });
            var expectedDtmis = $"{dtmi1},{dtmi2},{expectedDeps}".Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            result.Keys.Count.Should().Be(expectedDtmis.Length);

            foreach (var id in expectedDtmis)
            {
                result.Should().ContainKey(id);
                ModelsRepositoryTestBase.ParseRootDtmiFromJson(result[id]).Should().Be(id);
            }
        }

        public async Task ResolveMultipleModelsWithDepsFromExtends()
        {
            const string dtmi1 = "dtmi:com:example:TemperatureController;1";
            const string dtmi2 = "dtmi:com:example:ConferenceRoom;1";
            const string expectedDeps = "dtmi:com:example:Thermostat;1,dtmi:azure:DeviceManagement:DeviceInformation;1,dtmi:com:example:Room;1";
            ModelsRepositoryClient client = GetClient(ModelsRepositoryTestBase.ClientType.Local);
            IDictionary<string, string> result = await client.ResolveAsync(new[] { dtmi1, dtmi2 });
            var expectedDtmis = $"{dtmi1},{dtmi2},{expectedDeps}".Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            result.Keys.Count.Should().Be(expectedDtmis.Length);

            foreach (var id in expectedDtmis)
            {
                result.Should().ContainKey(id);
                ModelsRepositoryTestBase.ParseRootDtmiFromJson(result[id]).Should().Be(id);
            }
        }

        public async Task ResolveMultipleModelsWithDepsFromExtendsVariant()
        {
            const string dtmi1 = "dtmi:com:example:TemperatureController;1";
            const string dtmi2 = "dtmi:com:example:ColdStorage;1";
            const string expectedDeps = "dtmi:com:example:Thermostat;1," +
                  "dtmi:azure:DeviceManagement:DeviceInformation;1," +
                  "dtmi:com:example:Room;1," +
                  "dtmi:com:example:Freezer;1";

            ModelsRepositoryClient client = GetClient(ModelsRepositoryTestBase.ClientType.Local);
            IDictionary<string, string> result = await client.ResolveAsync(new[] { dtmi1, dtmi2 });
            var expectedDtmis = $"{dtmi1},{dtmi2},{expectedDeps}".Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            result.Keys.Count.Should().Be(expectedDtmis.Length);

            foreach (var id in expectedDtmis)
            {
                result.Should().ContainKey(id);
                ModelsRepositoryTestBase.ParseRootDtmiFromJson(result[id]).Should().Be(id);
            }
        }

        public async Task ResolveSingleModelWithDepsFromExtendsInline()
        {
            const string dtmi = "dtmi:com:example:base;1";
            ModelsRepositoryClient client = GetClient(ModelsRepositoryTestBase.ClientType.Local);
            IDictionary<string, string> result = await client.ResolveAsync(dtmi);

            result.Keys.Count.Should().Be(1);
            result.Should().ContainKey(dtmi);
            ModelsRepositoryTestBase.ParseRootDtmiFromJson(result[dtmi]).Should().Be(dtmi);
        }

        public async Task ResolveSingleModelWithDepsFromExtendsInlineVariant()
        {
            const string dtmi = "dtmi:com:example:base;2";
            const string expected = "dtmi:com:example:Freezer;1," +
                  "dtmi:com:example:Thermostat;1";

            ModelsRepositoryClient client = GetClient(ModelsRepositoryTestBase.ClientType.Local);
            IDictionary<string, string> result = await client.ResolveAsync(dtmi);
            var expectedDtmis = $"{dtmi},{expected}".Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            result.Keys.Count.Should().Be(expectedDtmis.Length);

            foreach (var id in expectedDtmis)
            {
                result.Should().ContainKey(id);
                ModelsRepositoryTestBase.ParseRootDtmiFromJson(result[id]).Should().Be(id);
            }
        }

        public async Task ResolveEnsuresNoDupes()
        {
            const string dtmiDupe1 = "dtmi:azure:DeviceManagement:DeviceInformation;1";
            const string dtmiDupe2 = "dtmi:azure:DeviceManagement:DeviceInformation;1";

            ModelsRepositoryClient client = GetClient(ModelsRepositoryTestBase.ClientType.Local);
            IDictionary<string, string> result = await client.ResolveAsync(new[] { dtmiDupe1, dtmiDupe2 });

            result.Keys.Count.Should().Be(1);
            ModelsRepositoryTestBase.ParseRootDtmiFromJson(result[dtmiDupe1]).Should().Be(dtmiDupe1);
        }

        [TestCase(ModelsRepositoryTestBase.ClientType.Local)]
        [TestCase(ModelsRepositoryTestBase.ClientType.Remote)]
        public async Task ResolveSingleModelWithDepsDisableDependencyResolution(ModelsRepositoryTestBase.ClientType clientType)
        {
            const string dtmi = "dtmi:com:example:Thermostat;1";

            ModelsRepositoryClientOptions options = new ModelsRepositoryClientOptions(resolutionOption: DependencyResolutionOption.Disabled);
            ModelsRepositoryClient client = GetClient(clientType, options);

            IDictionary<string, string> result = await client.ResolveAsync(dtmi);

            result.Keys.Count.Should().Be(1);
            result.Should().ContainKey(dtmi);
            ModelsRepositoryTestBase.ParseRootDtmiFromJson(result[dtmi]).Should().Be(dtmi);
        }

        [TestCase(ModelsRepositoryTestBase.ClientType.Local)]
        [TestCase(ModelsRepositoryTestBase.ClientType.Remote)]
        public async Task ResolveSingleModelTryFromExpanded(ModelsRepositoryTestBase.ClientType clientType)
        {
            const string dtmi = "dtmi:com:example:TemperatureController;1";
            const string expectedDeps = "dtmi:com:example:Thermostat;1,dtmi:azure:DeviceManagement:DeviceInformation;1";

            var expectedDtmis = $"{dtmi},{expectedDeps}".Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            ModelsRepositoryClientOptions options = new ModelsRepositoryClientOptions(resolutionOption: DependencyResolutionOption.TryFromExpanded);
            ModelsRepositoryClient client = GetClient(clientType, options);

            IDictionary<string, string> result = await client.ResolveAsync(dtmi);

            result.Keys.Count.Should().Be(expectedDtmis.Length);

            foreach (var id in expectedDtmis)
            {
                result.Should().ContainKey(id);
                ModelsRepositoryTestBase.ParseRootDtmiFromJson(result[id]).Should().Be(id);
            }
        }

        public async Task ResolveMultipleModelsTryFromExpandedPartial()
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

            ModelsRepositoryClientOptions options = new ModelsRepositoryClientOptions(resolutionOption: DependencyResolutionOption.TryFromExpanded);
            ModelsRepositoryClient client = GetClient(ModelsRepositoryTestBase.ClientType.Local, options);

            // Multi-resolve dtmi:com:example:TemperatureController;1 + dtmi:com:example:ColdStorage;1
            IDictionary<string, string> result = await client.ResolveAsync(new[] { expandedDtmis[0], nonExpandedDtmis[0] });

            result.Keys.Count.Should().Be(totalDtmis.Length);
            foreach (string id in totalDtmis)
            {
                result.Should().ContainKey(id);
                ModelsRepositoryTestBase.ParseRootDtmiFromJson(result[id]).Should().Be(id);
            }
        }
    }
}
