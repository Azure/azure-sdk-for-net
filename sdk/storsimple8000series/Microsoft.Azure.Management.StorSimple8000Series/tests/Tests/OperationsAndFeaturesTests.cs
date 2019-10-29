using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Management.StorSimple8000Series;
using Microsoft.Azure.Management.StorSimple8000Series.Models;
using Microsoft.Rest.Azure.OData;

namespace StorSimple8000Series.Tests
{
    public class OperationsAndFeaturesTests : StorSimpleTestBase
    {
        public OperationsAndFeaturesTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        [Fact]
        public void TestOperationsAPI()
        {
            try
            {
                //operations allowed
                var operations = GetOperations();
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        [Fact]
        public void TestFeaturesAPI()
        {
            try
            {
                //features for StorSimple Manager
                var featuresForResource = GetFeatures();

                //features for device
                var devices = Helpers.CheckAndGetConfiguredDevices(this, requiredCount: 1);
                var deviceName = devices.First().Name;
                var featuresForDevice = GetFeatures(deviceName);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        private IPage<AvailableProviderOperation> GetOperations()
        {
            var operations = this.Client.Operations.List();

            Assert.True(operations != null, "List call for Operations was not successful.");

            return operations;
        }

        private IEnumerable<Feature> GetFeatures(string deviceName = null)
        {
            var oDataQuery = string.IsNullOrEmpty(deviceName) ? null : GetODataQueryForFeatures(deviceName);
            var features = this.Client.Managers.ListFeatureSupportStatus(this.ResourceGroupName, this.ManagerName, oDataQuery);

            Assert.True(features != null && features.Count() != 0, "Features call was not successful.");

            return features;
        }

        private ODataQuery<FeatureFilter> GetODataQueryForFeatures(string deviceName)
        {
            var device = this.Client.Devices.Get(deviceName.GetDoubleEncoded(), this.ResourceGroupName, this.ManagerName);

            Expression<Func<FeatureFilter, bool>> filter =
                f => (f.DeviceId == device.Id);

            ODataQuery<FeatureFilter> odataQuery = new ODataQuery<FeatureFilter>(filter);

            return odataQuery;
        }
    }
}

