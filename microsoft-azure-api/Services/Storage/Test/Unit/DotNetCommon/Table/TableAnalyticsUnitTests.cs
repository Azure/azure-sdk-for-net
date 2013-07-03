// -----------------------------------------------------------------------------------------
// <copyright file="TableAnalyticsUnitTests.cs" company="Microsoft">
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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;
using System;
using System.Net;
using System.Threading;

namespace Microsoft.WindowsAzure.Storage.Table
{
    [TestClass]
    public class TableAnalyticsUnitTests : TableTestBase
    {
        #region Locals + Ctors
        public TableAnalyticsUnitTests()
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
            CloudTableClient tableClient = GenerateCloudTableClient();
            startProperties = tableClient.GetServiceProperties();
        }

        // Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            tableClient.SetServiceProperties(startProperties);
        }

        //
        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            if (TestBase.TableBufferManager != null)
            {
                TestBase.TableBufferManager.OutstandingBufferCount = 0;
            }
        }
        //
        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            if (TestBase.TableBufferManager != null)
            {
                Assert.AreEqual(0, TestBase.TableBufferManager.OutstandingBufferCount);
            }
        }
        #endregion

        #region Analytics RoundTrip

        #region Sync

        [TestMethod]
        [Description("Test Analytics Round Trip Sync")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudTableTestAnalyticsRoundTripSync()
        {
            CloudTableClient client = GenerateCloudTableClient();

            ServiceProperties props = new ServiceProperties();

            props.Logging.LoggingOperations = LoggingOperations.Read | LoggingOperations.Write;
            props.Logging.RetentionDays = 5;
            props.Logging.Version = "1.0";

            props.Metrics.MetricsLevel = MetricsLevel.Service;
            props.Metrics.RetentionDays = 6;
            props.Metrics.Version = "1.0";

            client.SetServiceProperties(props);

            AssertServicePropertiesAreEqual(props, client.GetServiceProperties());
        }

        #endregion

        #region APM

        [TestMethod]
        [Description("Test Analytics Round Trip APM")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudTableTestAnalyticsRoundTripAPM()
        {
            CloudTableClient client = GenerateCloudTableClient();

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

        #region Task

#if TASK
        [TestMethod]
        [Description("Test Analytics Round Trip Task")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudTableTestAnalyticsRoundTripTask()
        {
            CloudTableClient client = GenerateCloudTableClient();

            ServiceProperties props = new ServiceProperties();

            props.Logging.LoggingOperations = LoggingOperations.Read | LoggingOperations.Write;
            props.Logging.RetentionDays = 5;
            props.Logging.Version = "1.0";

            props.Metrics.MetricsLevel = MetricsLevel.Service;
            props.Metrics.RetentionDays = 6;
            props.Metrics.Version = "1.0";

            client.SetServicePropertiesAsync(props).Wait();

            AssertServicePropertiesAreEqual(props, client.GetServicePropertiesAsync().Result);
        }

        [TestMethod]
        [Description("Test Table GetServiceProperties and SetServiceProperties - Task")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableGetSetServicePropertiesTask()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();

            ServiceProperties serviceProperties = new ServiceProperties();
            serviceProperties.Logging.LoggingOperations = LoggingOperations.Read | LoggingOperations.Write | LoggingOperations.Delete;
            serviceProperties.Logging.RetentionDays = 8;
            serviceProperties.Logging.Version = "1.0";
            serviceProperties.Metrics.MetricsLevel = MetricsLevel.Service;
            serviceProperties.Metrics.RetentionDays = 8;
            serviceProperties.Metrics.Version = "1.0";

            tableClient.SetServicePropertiesAsync(serviceProperties).Wait();

            ServiceProperties actual = tableClient.GetServicePropertiesAsync().Result;

            AssertServicePropertiesAreEqual(serviceProperties, actual);
        }

        [TestMethod]
        [Description("Test Table GetServiceProperties and SetServiceProperties - Task")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableGetSetServicePropertiesCancellationTokenTask()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            CancellationToken cancellationToken = CancellationToken.None;

            ServiceProperties serviceProperties = new ServiceProperties();
            serviceProperties.Logging.LoggingOperations = LoggingOperations.Read | LoggingOperations.Write | LoggingOperations.Delete;
            serviceProperties.Logging.RetentionDays = 9;
            serviceProperties.Logging.Version = "1.0";
            serviceProperties.Metrics.MetricsLevel = MetricsLevel.Service;
            serviceProperties.Metrics.RetentionDays = 9;
            serviceProperties.Metrics.Version = "1.0";

            tableClient.SetServicePropertiesAsync(serviceProperties, cancellationToken).Wait();

            ServiceProperties actual = tableClient.GetServicePropertiesAsync(cancellationToken).Result;

            AssertServicePropertiesAreEqual(serviceProperties, actual);
        }

        [TestMethod]
        [Description("Test Table GetServiceProperties and SetServiceProperties - Task")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableGetSetServicePropertiesRequestOptionsOperationContextTask()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            TableRequestOptions requestOptions = new TableRequestOptions();
            OperationContext operationContext = new OperationContext();

            ServiceProperties serviceProperties = new ServiceProperties();
            serviceProperties.Logging.LoggingOperations = LoggingOperations.Read | LoggingOperations.Write | LoggingOperations.Delete;
            serviceProperties.Logging.RetentionDays = 10;
            serviceProperties.Logging.Version = "1.0";
            serviceProperties.Metrics.MetricsLevel = MetricsLevel.Service;
            serviceProperties.Metrics.RetentionDays = 10;
            serviceProperties.Metrics.Version = "1.0";

            tableClient.SetServicePropertiesAsync(serviceProperties, requestOptions, operationContext).Wait();

            ServiceProperties actual = tableClient.GetServicePropertiesAsync(requestOptions, operationContext).Result;

            AssertServicePropertiesAreEqual(serviceProperties, actual);
        }

        [TestMethod]
        [Description("Test Table GetServiceProperties and SetServiceProperties - Task")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void TableGetSetServicePropertiesRequestOptionsOperationContextCancellationTokenTask()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            TableRequestOptions requestOptions = new TableRequestOptions();
            OperationContext operationContext = new OperationContext();
            CancellationToken cancellationToken = CancellationToken.None;

            ServiceProperties serviceProperties = new ServiceProperties();
            serviceProperties.Logging.LoggingOperations = LoggingOperations.Read | LoggingOperations.Write | LoggingOperations.Delete;
            serviceProperties.Logging.RetentionDays = 11;
            serviceProperties.Logging.Version = "1.0";
            serviceProperties.Metrics.MetricsLevel = MetricsLevel.Service;
            serviceProperties.Metrics.RetentionDays = 11;
            serviceProperties.Metrics.Version = "1.0";

            tableClient.SetServicePropertiesAsync(serviceProperties, requestOptions, operationContext, cancellationToken).Wait();

            ServiceProperties actual = tableClient.GetServicePropertiesAsync(requestOptions, operationContext, cancellationToken).Result;

            AssertServicePropertiesAreEqual(serviceProperties, actual);
        }
#endif

        #endregion

        #endregion

        #region Analytics Permutations

        [TestMethod]
        [Description("Test Analytics Disable Service Properties")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudTableTestAnalyticsDisable()
        {
            CloudTableClient client = GenerateCloudTableClient();

            ServiceProperties props = new ServiceProperties();

            props.Logging.LoggingOperations = LoggingOperations.None;
            props.Logging.RetentionDays = null;
            props.Logging.Version = "1.0";

            props.Metrics.MetricsLevel = MetricsLevel.None;
            props.Metrics.RetentionDays = null;
            props.Metrics.Version = "1.0";

            client.SetServiceProperties(props);

            AssertServicePropertiesAreEqual(props, client.GetServiceProperties());
        }

        [TestMethod]
        [Description("Test Analytics Default Service VersionThrows")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudTableTestAnalyticsDefaultServiceVersionThrows()
        {
            CloudTableClient client = GenerateCloudTableClient();
            OperationContext ctx = new OperationContext();

            ServiceProperties props = new ServiceProperties();
            props.DefaultServiceVersion = "2009-09-19";

            props.Logging.LoggingOperations = LoggingOperations.None;
            props.Logging.Version = "1.0";

            props.Metrics.MetricsLevel = MetricsLevel.None;
            props.Metrics.Version = "1.0";

            try
            {
                client.SetServiceProperties(props, null, ctx);
                Assert.Fail("Should not be able to set default Service Version for non Blob Client");
            }
            catch (StorageException ex)
            {
                Assert.AreEqual(ex.Message, "The remote server returned an error: (400) Bad Request.");
                Assert.AreEqual(ex.RequestInformation.HttpStatusCode, (int)HttpStatusCode.BadRequest);
                TestHelper.AssertNAttempts(ctx, 1);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        [Description("Test Analytics Logging Operations")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudTableTestAnalyticsLoggingOperations()
        {
            CloudTableClient client = GenerateCloudTableClient();

            ServiceProperties props = client.GetServiceProperties();

            // None
            props.Logging.LoggingOperations = LoggingOperations.None;
            props.Logging.RetentionDays = null;
            props.Logging.Version = "1.0";

            client.SetServiceProperties(props);

            AssertServicePropertiesAreEqual(props, client.GetServiceProperties());

            // None
            props.Logging.LoggingOperations = LoggingOperations.All;
            client.SetServiceProperties(props);

            AssertServicePropertiesAreEqual(props, client.GetServiceProperties());
        }

        [TestMethod]
        [Description("Test Analytics Metrics Level")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudTableTestAnalyticsMetricsLevel()
        {
            CloudTableClient client = GenerateCloudTableClient();

            ServiceProperties props = client.GetServiceProperties();

            // None
            props.Metrics.MetricsLevel = MetricsLevel.None;
            props.Metrics.RetentionDays = null;
            props.Metrics.Version = "1.0";
            client.SetServiceProperties(props);

            AssertServicePropertiesAreEqual(props, client.GetServiceProperties());

            // Service
            props.Metrics.MetricsLevel = MetricsLevel.Service;
            client.SetServiceProperties(props);

            AssertServicePropertiesAreEqual(props, client.GetServiceProperties());

            // ServiceAndAPI
            props.Metrics.MetricsLevel = MetricsLevel.ServiceAndApi;
            client.SetServiceProperties(props);

            AssertServicePropertiesAreEqual(props, client.GetServiceProperties());
        }

        [TestMethod]
        [Description("Test Analytics Retention Policies")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudTableTestAnalyticsRetentionPolicies()
        {
            CloudTableClient client = GenerateCloudTableClient();

            ServiceProperties props = client.GetServiceProperties();

            // Set retention policy null with metrics disabled.
            props.Metrics.RetentionDays = null;
            props.Metrics.MetricsLevel = MetricsLevel.None;
            client.SetServiceProperties(props);

            AssertServicePropertiesAreEqual(props, client.GetServiceProperties());

            // Set retention policy not null with metrics disabled.
            props.Metrics.RetentionDays = 1;
            props.Metrics.MetricsLevel = MetricsLevel.Service;
            client.SetServiceProperties(props);

            AssertServicePropertiesAreEqual(props, client.GetServiceProperties());

            // Set retention policy not null with metrics enabled.
            props.Metrics.MetricsLevel = MetricsLevel.ServiceAndApi;
            props.Metrics.RetentionDays = 2;
            client.SetServiceProperties(props);

            AssertServicePropertiesAreEqual(props, client.GetServiceProperties());

            // Set retention policy null with logging disabled.
            props.Logging.RetentionDays = null;
            props.Logging.LoggingOperations = LoggingOperations.None;
            client.SetServiceProperties(props);

            AssertServicePropertiesAreEqual(props, client.GetServiceProperties());

            // Set retention policy not null with logging disabled.
            props.Logging.RetentionDays = 3;
            props.Logging.LoggingOperations = LoggingOperations.None;
            client.SetServiceProperties(props);

            AssertServicePropertiesAreEqual(props, client.GetServiceProperties());

            // Set retention policy null with logging enabled.
            props.Logging.RetentionDays = null;
            props.Logging.LoggingOperations = LoggingOperations.All;
            client.SetServiceProperties(props);

            AssertServicePropertiesAreEqual(props, client.GetServiceProperties());

            // Set retention policy not null with logging enabled.
            props.Logging.RetentionDays = 4;
            props.Logging.LoggingOperations = LoggingOperations.All;
            client.SetServiceProperties(props);

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
