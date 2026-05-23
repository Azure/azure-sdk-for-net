// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager;
using Azure.ResourceManager.Monitor.Slis.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Monitor.Slis.Tests
{
    public class SliCrudLiveTests : SlisManagementTestBase
    {
        private string _serviceGroupName;
        private string _sliName;
        private string _amwResourceId;
        private string _managedIdentityResourceId;
        private string _sourceAmwResourceId;
        private string _sourceManagedIdentityResourceId;

        public SliCrudLiveTests(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void TestSetup()
        {
            _serviceGroupName = TestEnvironment.ServiceGroupName;
            _sliName = Recording.GenerateAssetName("netsli");
            _amwResourceId = TestEnvironment.AmwResourceId;
            _managedIdentityResourceId = TestEnvironment.ManagedIdentityResourceId;
            _sourceAmwResourceId = TestEnvironment.SourceAmwResourceId;
            _sourceManagedIdentityResourceId = TestEnvironment.SourceManagedIdentityResourceId;
        }

        [Test]
        [RecordedTest]
        public async Task SliCrudLifecycle()
        {
            ResourceIdentifier serviceGroupId = new($"/providers/Microsoft.Management/serviceGroups/{_serviceGroupName}");
            MonitorSliCollection sliCollection = Client.GetMonitorSlis(serviceGroupId);

            var sliData = CreateSliResourceData();
            ArmOperation<MonitorSliResource> createOperation = await sliCollection.CreateOrUpdateAsync(WaitUntil.Completed, _sliName, sliData).ConfigureAwait(false);
            MonitorSliResource createdSli = createOperation.Value;
            Assert.That(createdSli, Is.Not.Null);
            Assert.That(createdSli.Data.Name, Is.EqualTo(_sliName));

            Response<MonitorSliResource> getResponse = await sliCollection.GetAsync(_sliName).ConfigureAwait(false);
            Assert.That(getResponse, Is.Not.Null);
            Assert.That(getResponse.Value.Data.Properties, Is.Not.Null);
            Assert.That(getResponse.Value.Data.Properties.Category, Is.EqualTo(SliCategory.Latency));

            await createdSli.DeleteAsync(WaitUntil.Completed).ConfigureAwait(false);

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await sliCollection.GetAsync(_sliName).ConfigureAwait(false);
            });
            Assert.That(ex.Status, Is.EqualTo(404));
        }

        private MonitorSliData CreateSliResourceData()
        {
            return new MonitorSliData
            {
                Properties = new MonitorSliProperties(
                    description: "Live test SLI - measures latency of test API",
                    category: SliCategory.Latency,
                    evaluationType: SliEvaluationType.WindowBased,
                    destinationAmwAccounts: new[]
                    {
                        new SliAmwAccount(new ResourceIdentifier(_amwResourceId), new ResourceIdentifier(_managedIdentityResourceId))
                    },
                    baseline: new SliBaseline(99, 30, SliEvaluationCalculationType.CalendarDays),
                    isAlertEnabled: true,
                    sliProperties: new SliProperties
                    {
                        WindowUptimeCriteria = new WindowUptimeCriteria(95, WindowUptimeCriteriaComparator.GreaterThanOrEqual),
                        Signals = new SliSignal(
                            new[]
                            {
                                new SliSignalSource(
                                    signalSourceId: "A",
                                    sourceAmwAccountManagedIdentity: new ResourceIdentifier(_sourceManagedIdentityResourceId),
                                    sourceAmwAccountResourceId: new ResourceIdentifier(_sourceAmwResourceId),
                                    metricNamespace: "TestMetrics",
                                    metricName: "TestLatency",
                                    filters: new[]
                                    {
                                        new SliCondition(SliConditionOperator.Equal, "TestApi")
                                        {
                                            DimensionName = "ApiName"
                                        }
                                    },
                                    spatialAggregation: new SliSpatialAggregation(SliSpatialAggregationType.Average, new[] { "Region" }),
                                    temporalAggregation: new SliTemporalAggregation(SliTemporalAggregationType.Average)
                                    {
                                        WindowSizeMinutes = 5
                                    })
                            },
                            signalFormula: "A")
                    })
            };
        }
    }
}
