// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azure.Iot.ModelsRepository.Tests
{
    public class ResolveIntegrationTests
    {
        [TestCase("dtmi:com:example:thermostat;1", TestHelpers.ClientType.Local)]
        [TestCase("dtmi:com:example:thermostat;1", TestHelpers.ClientType.Remote)]
        public void ResolveWithWrongCasingThrowsException(string dtmi, TestHelpers.ClientType clientType)
        {
            ResolverClient client = TestHelpers.GetTestClient(clientType);
            string expectedExMsg =
                string.Format(ServiceStrings.GenericResolverError, "dtmi:com:example:thermostat;1") +
                " " +
                string.Format(ServiceStrings.IncorrectDtmiCasing, "dtmi:com:example:thermostat;1", "dtmi:com:example:Thermostat;1");

            ResolverException re = Assert.ThrowsAsync<ResolverException>(async () => await client.ResolveAsync(dtmi));
            Assert.AreEqual(re.Message, expectedExMsg);
        }

        [TestCase("dtmi:com:example:Thermostat:1")]
        [TestCase("dtmi:com:example::Thermostat;1")]
        [TestCase("com:example:Thermostat;1")]
        public void ResolveInvalidDtmiFormatThrowsException(string dtmi)
        {
            ResolverClient client = TestHelpers.GetTestClient(TestHelpers.ClientType.Local);
            string expectedExMsg = $"{string.Format(ServiceStrings.GenericResolverError, dtmi)} {string.Format(ServiceStrings.InvalidDtmiFormat, dtmi)}";
            ResolverException re = Assert.ThrowsAsync<ResolverException>(async () => await client.ResolveAsync(dtmi));
            Assert.AreEqual(re.Message, expectedExMsg);
        }

        [TestCase("dtmi:com:example:thermojax;999", TestHelpers.ClientType.Local)]
        [TestCase("dtmi:com:example:thermojax;999", TestHelpers.ClientType.Remote)]
        public void ResolveNoneExistentDtmiFileThrowsException(string dtmi, TestHelpers.ClientType clientType)
        {
            ResolverClient client = TestHelpers.GetTestClient(clientType);
            ResolverException re = Assert.ThrowsAsync<ResolverException>(async () => await client.ResolveAsync(dtmi));
            Assert.True(re.Message.StartsWith($"Unable to resolve \"{dtmi}\""));
        }

        [TestCase("dtmi:com:example:invalidmodel;1", "dtmi:azure:fakeDeviceManagement:FakeDeviceInformation;2")]
        public void ResolveInvalidDtmiDepsThrowsException(string dtmi, string invalidDep)
        {
            ResolverClient client = TestHelpers.GetTestClient(TestHelpers.ClientType.Local);
            ResolverException resolverException = Assert.ThrowsAsync<ResolverException>(async () => await client.ResolveAsync(dtmi));
            Assert.True(resolverException.Message.StartsWith($"Unable to resolve \"{invalidDep}\""));
        }

        [TestCase("dtmi:com:example:Thermostat;1", TestHelpers.ClientType.Local)]
        [TestCase("dtmi:com:example:Thermostat;1", TestHelpers.ClientType.Remote)]
        public async Task ResolveSingleModelNoDeps(string dtmi, TestHelpers.ClientType clientType)
        {
            ResolverClient client = TestHelpers.GetTestClient(clientType);
            IDictionary<string, string> result = await client.ResolveAsync(dtmi);
            Assert.True(result.Keys.Count == 1);
            Assert.True(result.ContainsKey(dtmi));
            Assert.True(TestHelpers.ParseRootDtmiFromJson(result[dtmi]) == dtmi);
        }

        [TestCase("dtmi:com:example:Thermostat;1", "dtmi:azure:DeviceManagement:DeviceInformation;1", TestHelpers.ClientType.Local)]
        [TestCase("dtmi:com:example:Thermostat;1", "dtmi:azure:DeviceManagement:DeviceInformation;1", TestHelpers.ClientType.Remote)]
        public async Task ResolveMultipleModelsNoDeps(string dtmi1, string dtmi2, TestHelpers.ClientType clientType)
        {
            ResolverClient client = TestHelpers.GetTestClient(clientType);
            IDictionary<string, string> result = await client.ResolveAsync(new string[] { dtmi1, dtmi2 });
            Assert.True(result.Keys.Count == 2);
            Assert.True(result.ContainsKey(dtmi1));
            Assert.True(result.ContainsKey(dtmi2));
            Assert.True(TestHelpers.ParseRootDtmiFromJson(result[dtmi1]) == dtmi1);
            Assert.True(TestHelpers.ParseRootDtmiFromJson(result[dtmi2]) == dtmi2);
        }

        [TestCase(
            "dtmi:com:example:TemperatureController;1",
            "dtmi:com:example:Thermostat;1,dtmi:azure:DeviceManagement:DeviceInformation;1",
            TestHelpers.ClientType.Local
        )]
        [TestCase(
            "dtmi:com:example:TemperatureController;1",
            "dtmi:com:example:Thermostat;1,dtmi:azure:DeviceManagement:DeviceInformation;1",
            TestHelpers.ClientType.Remote
        )]
        public async Task ResolveSingleModelWithDeps(string dtmi, string expectedDeps, TestHelpers.ClientType clientType)
        {
            ResolverClient client = TestHelpers.GetTestClient(clientType);
            IDictionary<string, string> result = await client.ResolveAsync(dtmi);
            var expectedDtmis = $"{dtmi},{expectedDeps}".Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            Assert.True(result.Keys.Count == expectedDtmis.Length);
            foreach (var id in expectedDtmis)
            {
                Assert.True(result.ContainsKey(id));
                Assert.True(TestHelpers.ParseRootDtmiFromJson(result[id]) == id);
            }

            // TODO: Evaluate using Azure.Core.TestFramework in future iteration.

            /*
             // Verifying log entries for a Process(...) run
            _logger.ValidateLog($"{ServiceStringss.ClientInitWithFetcher(localClient.RepositoryUri.Scheme)}", LogLevel.Trace, Times.Once());

            _logger.ValidateLog($"{ServiceStringss.ProcessingDtmi("dtmi:com:example:TemperatureController;1")}", LogLevel.Trace, Times.Once());
            _logger.ValidateLog($"{ServiceStringss.FetchingContent(DtmiConventions.DtmiToQualifiedPath(expectedDtmis[0], localClient.RepositoryUri.AbsolutePath))}", LogLevel.Trace, Times.Once());

            _logger.ValidateLog($"{ServiceStringss.DiscoveredDependencies(new List<string>() { "dtmi:com:example:Thermostat;1", "dtmi:azure:DeviceManagement:DeviceInformation;1" })}", LogLevel.Trace, Times.Once());

            _logger.ValidateLog($"{ServiceStringss.ProcessingDtmi("dtmi:com:example:Thermostat;1")}", LogLevel.Trace, Times.Once());
            _logger.ValidateLog($"{ServiceStringss.FetchingContent(DtmiConventions.DtmiToQualifiedPath(expectedDtmis[1], localClient.RepositoryUri.AbsolutePath))}", LogLevel.Trace, Times.Once());

            _logger.ValidateLog($"{ServiceStringss.ProcessingDtmi("dtmi:azure:DeviceManagement:DeviceInformation;1")}", LogLevel.Trace, Times.Once());
            _logger.ValidateLog($"{ServiceStringss.FetchingContent(DtmiConventions.DtmiToQualifiedPath(expectedDtmis[2], localClient.RepositoryUri.AbsolutePath))}", LogLevel.Trace, Times.Once());
            */
        }

        [TestCase("dtmi:com:example:Phone;2",
                  "dtmi:com:example:TemperatureController;1",
                  "dtmi:com:example:Thermostat;1," +
                  "dtmi:azure:DeviceManagement:DeviceInformation;1," +
                  "dtmi:azure:DeviceManagement:DeviceInformation;2," +
                  "dtmi:com:example:Camera;3")]
        public async Task ResolveMultipleModelsWithDeps(string dtmi1, string dtmi2, string expectedDeps)
        {
            ResolverClient client = TestHelpers.GetTestClient(TestHelpers.ClientType.Local);
            IDictionary<string, string> result = await client.ResolveAsync(new[] { dtmi1, dtmi2 });
            var expectedDtmis = $"{dtmi1},{dtmi2},{expectedDeps}".Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            Assert.True(result.Keys.Count == expectedDtmis.Length);
            foreach (var id in expectedDtmis)
            {
                Assert.True(result.ContainsKey(id));
                Assert.True(TestHelpers.ParseRootDtmiFromJson(result[id]) == id);
            }
        }

        [TestCase("dtmi:com:example:TemperatureController;1",
                  "dtmi:com:example:ConferenceRoom;1", // Model uses extends
                  "dtmi:com:example:Thermostat;1,dtmi:azure:DeviceManagement:DeviceInformation;1,dtmi:com:example:Room;1")]
        public async Task ResolveMultipleModelsWithDepsFromExtends(string dtmi1, string dtmi2, string expectedDeps)
        {
            ResolverClient client = TestHelpers.GetTestClient(TestHelpers.ClientType.Local);
            IDictionary<string, string> result = await client.ResolveAsync(new[] { dtmi1, dtmi2 });
            var expectedDtmis = $"{dtmi1},{dtmi2},{expectedDeps}".Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            Assert.True(result.Keys.Count == expectedDtmis.Length);
            foreach (var id in expectedDtmis)
            {
                Assert.True(result.ContainsKey(id));
                Assert.True(TestHelpers.ParseRootDtmiFromJson(result[id]) == id);
            }
        }

        [TestCase("dtmi:com:example:TemperatureController;1",
                  "dtmi:com:example:ColdStorage;1", // Model uses extends[]
                  "dtmi:com:example:Thermostat;1," +
                  "dtmi:azure:DeviceManagement:DeviceInformation;1," +
                  "dtmi:com:example:Room;1," +
                  "dtmi:com:example:Freezer;1")]
        public async Task ResolveMultipleModelsWithDepsFromExtendsVariant(string dtmi1, string dtmi2, string expectedDeps)
        {
            ResolverClient client = TestHelpers.GetTestClient(TestHelpers.ClientType.Local);
            IDictionary<string, string> result = await client.ResolveAsync(new[] { dtmi1, dtmi2 });
            var expectedDtmis = $"{dtmi1},{dtmi2},{expectedDeps}".Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            Assert.True(result.Keys.Count == expectedDtmis.Length);
            foreach (var id in expectedDtmis)
            {
                Assert.True(result.ContainsKey(id));
                Assert.True(TestHelpers.ParseRootDtmiFromJson(result[id]) == id);
            }
        }

        [TestCase("dtmi:com:example:base;1")]
        public async Task ResolveSingleModelWithDepsFromExtendsInline(string dtmi)
        {
            ResolverClient client = TestHelpers.GetTestClient(TestHelpers.ClientType.Local);
            IDictionary<string, string> result = await client.ResolveAsync(dtmi);

            Assert.True(result.Keys.Count == 1);
            Assert.True(result.ContainsKey(dtmi));
            Assert.True(TestHelpers.ParseRootDtmiFromJson(result[dtmi]) == dtmi);
        }

        [TestCase("dtmi:com:example:base;2",
                  "dtmi:com:example:Freezer;1," +
                  "dtmi:com:example:Thermostat;1")]
        public async Task ResolveSingleModelWithDepsFromExtendsInlineVariant(string dtmi, string expected)
        {
            ResolverClient client = TestHelpers.GetTestClient(TestHelpers.ClientType.Local);
            IDictionary<string, string> result = await client.ResolveAsync(dtmi);
            var expectedDtmis = $"{dtmi},{expected}".Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            Assert.True(result.Keys.Count == expectedDtmis.Length);
            foreach (var id in expectedDtmis)
            {
                Assert.True(result.ContainsKey(id));
                Assert.True(TestHelpers.ParseRootDtmiFromJson(result[id]) == id);
            }
        }

        [TestCase("dtmi:azure:DeviceManagement:DeviceInformation;1", "dtmi:azure:DeviceManagement:DeviceInformation;1")]
        public async Task ResolveEnsuresNoDupes(string dtmiDupe1, string dtmiDupe2)
        {
            ResolverClient client = TestHelpers.GetTestClient(TestHelpers.ClientType.Local);
            IDictionary<string, string> result = await client.ResolveAsync(new[] { dtmiDupe1, dtmiDupe2 });
            Assert.True(result.Keys.Count == 1);
            Assert.True(TestHelpers.ParseRootDtmiFromJson(result[dtmiDupe1]) == dtmiDupe1);
        }

        [TestCase("dtmi:com:example:Thermostat;1", TestHelpers.ClientType.Local)]
        [TestCase("dtmi:com:example:Thermostat;1", TestHelpers.ClientType.Remote)]
        public async Task ResolveSingleModelWithDepsDisableDependencyResolution(string dtmi, TestHelpers.ClientType clientType)
        {
            ResolverClientOptions options = new ResolverClientOptions(resolutionOption: DependencyResolutionOption.Disabled);
            ResolverClient client = TestHelpers.GetTestClient(clientType, options);

            IDictionary<string, string> result = await client.ResolveAsync(dtmi);

            Assert.True(result.Keys.Count == 1);
            Assert.True(result.ContainsKey(dtmi));
            Assert.True(TestHelpers.ParseRootDtmiFromJson(result[dtmi]) == dtmi);
        }

        [TestCase(
            "dtmi:com:example:TemperatureController;1", // .expanded.json available locally.
            "dtmi:com:example:Thermostat;1,dtmi:azure:DeviceManagement:DeviceInformation;1",
            TestHelpers.ClientType.Local)]
        [TestCase(
            "dtmi:com:example:TemperatureController;1", // .expanded.json available remotely.
            "dtmi:com:example:Thermostat;1,dtmi:azure:DeviceManagement:DeviceInformation;1",
            TestHelpers.ClientType.Remote)]
        public async Task ResolveSingleModelTryFromExpanded(string dtmi, string expectedDeps, TestHelpers.ClientType clientType)
        {
            var expectedDtmis = $"{dtmi},{expectedDeps}".Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            ResolverClientOptions options = new ResolverClientOptions(resolutionOption: DependencyResolutionOption.TryFromExpanded);
            ResolverClient client = TestHelpers.GetTestClient(clientType, options);

            IDictionary<string, string> result = await client.ResolveAsync(dtmi);

            Assert.True(result.Keys.Count == expectedDtmis.Length);
            foreach (var id in expectedDtmis)
            {
                Assert.True(result.ContainsKey(id));
                Assert.True(TestHelpers.ParseRootDtmiFromJson(result[id]) == id);
            }

            // TODO: Evaluate using Azure.Core.TestFramework in future iteration.

            /*
            string expectedPath = DtmiConventions.DtmiToQualifiedPath(
                dtmi,
                repoType == "local" ? client.RepositoryUri.AbsolutePath : client.RepositoryUri.AbsoluteUri,
                fromExpanded: true);
            _logger.ValidateLog(ServiceStringss.FetchingContent(expectedPath), LogLevel.Trace, Times.Once());
            */
        }

        [TestCase("dtmi:com:example:TemperatureController;1," +  // Expanded available.
                  "dtmi:com:example:Thermostat;1," +
                  "dtmi:azure:DeviceManagement:DeviceInformation;1",
                  "dtmi:com:example:ColdStorage;1," + // Model uses extends[], No Expanded available.
                  "dtmi:com:example:Room;1," +
                  "dtmi:com:example:Freezer;1")]
        public async Task ResolveMultipleModelsTryFromExpandedPartial(string dtmisExpanded, string dtmisNonExpanded)
        {
            string[] expandedDtmis = dtmisExpanded.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            string[] nonExpandedDtmis = dtmisNonExpanded.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            string[] totalDtmis = expandedDtmis.Concat(nonExpandedDtmis).ToArray();

            ResolverClientOptions options = new ResolverClientOptions(resolutionOption: DependencyResolutionOption.TryFromExpanded);
            ResolverClient client = TestHelpers.GetTestClient(TestHelpers.ClientType.Local, options);

            // Multi-resolve dtmi:com:example:TemperatureController;1 + dtmi:com:example:ColdStorage;1
            IDictionary<string, string> result = await client.ResolveAsync(new[] { expandedDtmis[0], nonExpandedDtmis[0] });

            Assert.True(result.Keys.Count == totalDtmis.Length);
            foreach (string id in totalDtmis)
            {
                Assert.True(result.ContainsKey(id));
                Assert.True(TestHelpers.ParseRootDtmiFromJson(result[id]) == id);
            }

            // TODO: Evaluate using Azure.Core.TestFramework in future iteration.

            /*
            string expandedModelPath = DtmiConventions.DtmiToQualifiedPath(expandedDtmis[0], localClient.RepositoryUri.AbsolutePath, fromExpanded: true);
            _logger.ValidateLog(ServiceStrings.FetchingContent(expandedModelPath), LogLevel.Trace, Times.Once());

            foreach (string dtmi in nonExpandedDtmis)
            {
                string expectedPath = DtmiConventions.DtmiToQualifiedPath(dtmi, localClient.RepositoryUri.AbsolutePath, fromExpanded: true);
                _logger.ValidateLog(ServiceStrings.FetchingContent(expectedPath), LogLevel.Trace, Times.Once());
                _logger.ValidateLog(ServiceStrings.ErrorAccessLocalRepositoryModel(expectedPath), LogLevel.Warning, Times.Once());
            }
            */
        }
    }
}
