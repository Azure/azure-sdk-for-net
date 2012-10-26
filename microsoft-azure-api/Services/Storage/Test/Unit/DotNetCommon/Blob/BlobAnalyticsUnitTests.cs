// -----------------------------------------------------------------------------------------
// <copyright file="BlobAnalyticsUnitTests.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;

namespace Microsoft.WindowsAzure.Storage.Blob
{
    [TestClass]
    public class BlobAnalyticsUnitTests : TestBase
    {
        #region Locals + Ctors
        public BlobAnalyticsUnitTests()
        {
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        private static ServiceProperties startProperties = null;
        #endregion

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            CloudBlobClient client = GenerateCloudBlobClient();
            startProperties = client.GetServiceProperties();
        }

        // Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            CloudBlobClient client = GenerateCloudBlobClient();
            client.SetServiceProperties(startProperties);
        }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        #region Analytics RoundTrip

        #region Sync

        [TestMethod]
        [Description("Test Analytics Round Trip Sync")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobTestAnalyticsRoundTripSync()
        {
            CloudBlobClient client = GenerateCloudBlobClient();

            ServiceProperties props = new ServiceProperties();

            props.Logging.LoggingOperations = LoggingOperations.Read | LoggingOperations.Write;
            props.Logging.RetentionDays = 5;
            props.Logging.Version = "1.0";

            props.Metrics.MetricsLevel = MetricsLevel.Service;
            props.Metrics.RetentionDays = 6;
            props.Metrics.Version = "1.0";

            client.SetServiceProperties(props);

            // Wait for analytics server to update
            Thread.Sleep(60 * 1000);
            AssertServicePropertiesAreEqual(props, client.GetServiceProperties());
        }

        #endregion

        #region APM

        [TestMethod]
        [Description("Test Analytics Round Trip APM")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobTestAnalyticsRoundTripAPM()
        {
            CloudBlobClient client = GenerateCloudBlobClient();

            ServiceProperties props = new ServiceProperties();

            props.Logging.LoggingOperations = LoggingOperations.Read | LoggingOperations.Write;
            props.Logging.RetentionDays = 5;
            props.Logging.Version = "1.0";

            props.Metrics.MetricsLevel = MetricsLevel.Service;
            props.Metrics.RetentionDays = 6;
            props.Metrics.Version = "1.0";

            using (ManualResetEvent evt = new ManualResetEvent(false))
            {
                IAsyncResult result = null;
                client.BeginSetServiceProperties(props, (res) =>
                {
                    result = res;
                    evt.Set();
                }, null);
                evt.WaitOne();

                client.EndSetServiceProperties(result);
            }

            // Wait for analytics server to update
            Thread.Sleep(60 * 1000);

            ServiceProperties retrievedProps = null;
            using (ManualResetEvent evt = new ManualResetEvent(false))
            {
                IAsyncResult result = null;
                client.BeginGetServiceProperties((res) =>
                {
                    result = res;
                    evt.Set();
                }, null);
                evt.WaitOne();

                retrievedProps = client.EndGetServiceProperties(result);
            }

            AssertServicePropertiesAreEqual(props, retrievedProps);
        }

        #endregion

        #endregion

        #region Analytics Permutations

        [TestMethod]
        [Description("Test Analytics Disable Service Properties")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobTestAnalyticsDisable()
        {
            CloudBlobClient client = GenerateCloudBlobClient();

            ServiceProperties props = new ServiceProperties();

            props.Logging.LoggingOperations = LoggingOperations.None;
            props.Logging.RetentionDays = null;
            props.Logging.Version = "1.0";

            props.Metrics.MetricsLevel = MetricsLevel.None;
            props.Metrics.RetentionDays = null;
            props.Metrics.Version = "1.0";

            client.SetServiceProperties(props);

            // Wait for analytics server to update
            Thread.Sleep(60 * 1000);
            AssertServicePropertiesAreEqual(props, client.GetServiceProperties());
        }

        [TestMethod]
        [Description("Test Analytics Default Service Version")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobTestAnalyticsDefaultServiceVersion()
        {
            CloudBlobClient client = GenerateCloudBlobClient();

            ServiceProperties props = client.GetServiceProperties();
            props.DefaultServiceVersion = "2009-09-19";          
            client.SetServiceProperties(props);

            // Wait for analytics server to update
            Thread.Sleep(60 * 1000);
            AssertServicePropertiesAreEqual(props, client.GetServiceProperties());

            props.DefaultServiceVersion = "2011-08-18";
            client.SetServiceProperties(props);

            // Wait for analytics server to update
            Thread.Sleep(60 * 1000);
            AssertServicePropertiesAreEqual(props, client.GetServiceProperties());

            props.DefaultServiceVersion = "2012-02-12";
            client.SetServiceProperties(props);

            // Wait for analytics server to update
            Thread.Sleep(60 * 1000);
            AssertServicePropertiesAreEqual(props, client.GetServiceProperties());
            
            props.DefaultServiceVersion = null;
            client.SetServiceProperties(props);

            // Wait for analytics server to update
            Thread.Sleep(60 * 1000);
            AssertServicePropertiesAreEqual(props, client.GetServiceProperties());
        }

        [TestMethod]
        [Description("Test Analytics Logging Operations")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobTestAnalyticsLoggingOperations()
        {
            CloudBlobClient client = GenerateCloudBlobClient();

            ServiceProperties props = client.GetServiceProperties();

            // None
            props.Logging.LoggingOperations = LoggingOperations.None;
            props.Logging.RetentionDays = null;
            props.Logging.Version = "1.0";

            client.SetServiceProperties(props);

            // Wait for analytics server to update
            Thread.Sleep(60 * 1000);
            AssertServicePropertiesAreEqual(props, client.GetServiceProperties());

            // None
            props.Logging.LoggingOperations = LoggingOperations.All;
            client.SetServiceProperties(props);

            // Wait for analytics server to update
            Thread.Sleep(60 * 1000);
            AssertServicePropertiesAreEqual(props, client.GetServiceProperties());
        }

        [TestMethod]
        [Description("Test Analytics Metrics Level")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobTestAnalyticsMetricsLevel()
        {
            CloudBlobClient client = GenerateCloudBlobClient();

            ServiceProperties props = client.GetServiceProperties();

            // None
            props.Metrics.MetricsLevel = MetricsLevel.None;
            props.Metrics.RetentionDays = null;
            props.Metrics.Version = "1.0";
            client.SetServiceProperties(props);

            // Wait for analytics server to update
            Thread.Sleep(60 * 1000);
            AssertServicePropertiesAreEqual(props, client.GetServiceProperties());

            // Service
            props.Metrics.MetricsLevel = MetricsLevel.Service;
            client.SetServiceProperties(props);

            // Wait for analytics server to update
            Thread.Sleep(60 * 1000);
            AssertServicePropertiesAreEqual(props, client.GetServiceProperties());

            // ServiceAndAPI
            props.Metrics.MetricsLevel = MetricsLevel.ServiceAndApi;
            client.SetServiceProperties(props);

            // Wait for analytics server to update
            Thread.Sleep(60 * 1000);
            AssertServicePropertiesAreEqual(props, client.GetServiceProperties());
        }

        [TestMethod]
        [Description("Test Analytics Retention Policies")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobTestAnalyticsRetentionPolicies()
        {
            CloudBlobClient client = GenerateCloudBlobClient();

            ServiceProperties props = client.GetServiceProperties();

            // Set retention policy null with metrics disabled.
            props.Metrics.RetentionDays = null;
            props.Metrics.MetricsLevel = MetricsLevel.None;
            client.SetServiceProperties(props);

            // Wait for analytics server to update
            Thread.Sleep(60 * 1000);
            AssertServicePropertiesAreEqual(props, client.GetServiceProperties());

            // Set retention policy not null with metrics disabled.
            props.Metrics.RetentionDays = 1;
            props.Metrics.MetricsLevel = MetricsLevel.Service;
            client.SetServiceProperties(props);

            // Wait for analytics server to update
            Thread.Sleep(60 * 1000);
            AssertServicePropertiesAreEqual(props, client.GetServiceProperties());

            // Set retention policy not null with metrics enabled.
            props.Metrics.MetricsLevel = MetricsLevel.ServiceAndApi;
            props.Metrics.RetentionDays = 2;
            client.SetServiceProperties(props);

            // Wait for analytics server to update
            Thread.Sleep(60 * 1000);
            AssertServicePropertiesAreEqual(props, client.GetServiceProperties());

            // Set retention policy null with logging disabled.
            props.Logging.RetentionDays = null;
            props.Logging.LoggingOperations = LoggingOperations.None;
            client.SetServiceProperties(props);

            // Wait for analytics server to update
            Thread.Sleep(60 * 1000);
            AssertServicePropertiesAreEqual(props, client.GetServiceProperties());

            // Set retention policy not null with logging disabled.
            props.Logging.RetentionDays = 3;
            props.Logging.LoggingOperations = LoggingOperations.None;
            client.SetServiceProperties(props);

            // Wait for analytics server to update
            Thread.Sleep(60 * 1000);
            AssertServicePropertiesAreEqual(props, client.GetServiceProperties());

            // Set retention policy null with logging enabled.
            props.Logging.RetentionDays = null;
            props.Logging.LoggingOperations = LoggingOperations.All;
            client.SetServiceProperties(props);

            // Wait for analytics server to update
            Thread.Sleep(60 * 1000);
            AssertServicePropertiesAreEqual(props, client.GetServiceProperties());

            // Set retention policy not null with logging enabled.
            props.Logging.RetentionDays = 4;
            props.Logging.LoggingOperations = LoggingOperations.All;
            client.SetServiceProperties(props);

            // Wait for analytics server to update
            Thread.Sleep(60 * 1000);
            AssertServicePropertiesAreEqual(props, client.GetServiceProperties());
        }
        #endregion

        #region Test Helpers

        private void AssertServicePropertiesAreEqual(ServiceProperties propsA, ServiceProperties propsB)
        {
            Assert.AreEqual(propsA.Logging.LoggingOperations, propsB.Logging.LoggingOperations);
            Assert.AreEqual(propsA.Logging.RetentionDays, propsB.Logging.RetentionDays);
            Assert.AreEqual(propsA.Logging.Version, propsB.Logging.Version);

            Assert.AreEqual(propsA.Metrics.MetricsLevel, propsB.Metrics.MetricsLevel);
            Assert.AreEqual(propsA.Metrics.RetentionDays, propsB.Metrics.RetentionDays);
            Assert.AreEqual(propsA.Metrics.Version, propsB.Metrics.Version);

            Assert.AreEqual(propsA.DefaultServiceVersion, propsB.DefaultServiceVersion);
        }

        #endregion
    }
}
