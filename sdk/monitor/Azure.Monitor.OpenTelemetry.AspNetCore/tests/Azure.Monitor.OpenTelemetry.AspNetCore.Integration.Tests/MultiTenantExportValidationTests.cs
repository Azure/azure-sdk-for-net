// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Azure.Core.TestFramework;
using Azure.Monitor.Query.Logs.Models;
using NUnit.Framework;

#if NET
using static Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests.MultiTenantTelemetry;

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests
{
    public class MultiTenantExportValidationTests
    {
        [TestCase(false, false, RecordedTestMode.Playback, false)]
        [TestCase(false, false, RecordedTestMode.Live, false)]
        [TestCase(true, true, RecordedTestMode.Live, false)]
        [TestCase(true, true, RecordedTestMode.Live, true)]
        public void AcceptsIsolatedExecution(bool fixture, bool run, RecordedTestMode mode, bool enabled)
        {
            Assert.DoesNotThrow(() => BaseLiveTest.ValidateExecutionMode(fixture, run, mode, enabled));
        }

        [TestCase(false, true, RecordedTestMode.Live, false)]
        [TestCase(false, false, RecordedTestMode.Live, true)]
        [TestCase(true, false, RecordedTestMode.Live, false)]
        [TestCase(true, true, RecordedTestMode.Playback, false)]
        [TestCase(true, true, RecordedTestMode.Record, false)]
        public void RejectsMixedOrNonLiveExecution(bool fixture, bool run, RecordedTestMode mode, bool enabled)
        {
            Assert.Throws<InvalidOperationException>(() => BaseLiveTest.ValidateExecutionMode(fixture, run, mode, enabled));
        }

        [Test]
        public void AcceptsThreeResourcesAcrossTwoEndpoints()
        {
            var resources = MultiTenantResource.Parse(Configuration());
            Assert.That(resources.Count, Is.EqualTo(3));
            Assert.That(resources.Select(resource => resource.Endpoint).Distinct().Count(), Is.EqualTo(2));
        }

        [TestCase(2, "westus2", "https://westus2.example.com/", false)]
        [TestCase(3, "eastus2", "https://westus2.example.com/", false)]
        [TestCase(3, "westus2", "https://eastus2.example.com/", false)]
        [TestCase(3, "westus2", "https://westus2.example.com/", true)]
        public void RejectsInsufficientTopology(int count, string region, string endpoint, bool duplicateResource)
        {
            Assert.Throws<AssertionException>(() => MultiTenantResource.Parse(Configuration(count, region, endpoint, duplicateResource)));
        }

        [Test]
        public void RejectsDifferentEndpointsForFirstTwoTenants()
        {
            Assert.Throws<AssertionException>(() => MultiTenantResource.Parse(Configuration(secondEndpoint: "https://other.example.com/")));
        }

        [Test]
        public void RejectsRepeatedInstrumentationKeys()
        {
            Assert.Throws<AssertionException>(() => MultiTenantResource.Parse(Configuration(duplicateKey: true)));
        }

        [Test]
        public void RejectsInsecureIngestionEndpoint()
        {
            Assert.Throws<AssertionException>(() => MultiTenantResource.Parse(Configuration(endpoint: "http://westus2.example.com/")));
        }

        [Test]
        public void MalformedConfigurationDoesNotExposeItsContents()
        {
            const string sensitiveValue = "not-a-real-secret";
            var exception = Assert.Throws<InvalidOperationException>(() => MultiTenantResource.Parse(sensitiveValue));
            Assert.That(exception!.ToString(), Does.Not.Contain(sensitiveValue));
        }

        [Test]
        public void AcceptsDuplicateDeliveriesWithoutCountingThemTwice()
        {
            var record = Telemetry();
            var expected = new Dictionary<string, Record> { [record.RecordId] = record };
            Assert.That(ValidateQuery(expected, new[] { record, record }, LogsQueryResultStatus.Success), Is.EquivalentTo(expected.Keys));
        }

        [Test]
        public void IncompleteAndEmptyQueriesDoNotEstablishCompletion()
        {
            var record = Telemetry();
            var other = Telemetry(recordId: "other");
            var expected = new Dictionary<string, Record> { [record.RecordId] = record, [other.RecordId] = other };
            var seen = ValidateQuery(expected, new[] { record }, LogsQueryResultStatus.Success);
            Assert.That(seen.SetEquals(expected.Keys), Is.False);
            Assert.That(expected.Keys.Except(seen), Is.EquivalentTo(new[] { other.RecordId }));
            Assert.That(ValidateQuery(expected, Array.Empty<Record>(), LogsQueryResultStatus.Success), Is.Empty);
        }

        [Test]
        public void RejectsPartialQueryEvenWhenAllExpectedRecordsArrive()
        {
            var record = Telemetry();
            var expected = new Dictionary<string, Record> { [record.RecordId] = record };
            Assert.Throws<AssertionException>(() => ValidateQuery(expected, new[] { record }, LogsQueryResultStatus.PartialFailure));
        }

        [TestCase("unexpected", "workspace", "resource", "AppRequests", "trace", "parent")]
        [TestCase("record", "wrong-workspace", "resource", "AppRequests", "trace", "parent")]
        [TestCase("record", "workspace", "wrong-resource", "AppRequests", "trace", "parent")]
        [TestCase("record", "workspace", "resource", "AppTraces", "trace", "parent")]
        [TestCase("record", "workspace", "resource", "AppRequests", "wrong-trace", "parent")]
        [TestCase("record", "workspace", "resource", "AppRequests", "trace", "wrong-parent")]
        public void RejectsWrongDestinationSignalOrCorrelation(string recordId, string workspace, string resource, string table, string operationId, string parentId)
        {
            var record = Telemetry();
            var expected = new Dictionary<string, Record> { [record.RecordId] = record };
            var observed = new Record(recordId, workspace, resource, table, operationId, parentId);
            Assert.Throws<AssertionException>(() => ValidateQuery(expected, new[] { observed }, LogsQueryResultStatus.Success));
        }

        private static Record Telemetry(string recordId = "record") => new(recordId, "workspace", "resource", "AppRequests", "trace", "parent");

        private static string Configuration(int count = 3, string region = "westus2", string endpoint = "https://westus2.example.com/",
            bool duplicateResource = false, string secondEndpoint = "https://eastus2.example.com/", bool duplicateKey = false)
        {
            return JsonSerializer.Serialize(Enumerable.Range(0, count).Select(index => new
            {
                connectionString = $"InstrumentationKey={(duplicateKey ? Guid.Empty : Guid.NewGuid())};IngestionEndpoint={(index == 2 ? endpoint : index == 1 ? secondEndpoint : "https://eastus2.example.com/")}",
                workspaceId = Guid.NewGuid().ToString(),
                resourceId = $"/subscriptions/test/resourceGroups/test/providers/Microsoft.Insights/components/tenant-{(duplicateResource ? 0 : index)}",
                region = index == 2 ? region : "eastus2"
            }));
        }
    }
}
#endif