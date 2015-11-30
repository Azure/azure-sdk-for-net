// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight.Tests.ClientAbstractionTests
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.RestClient;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Retries;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.Logging;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities;

    [TestClass]
    public class SyncTests : IntegrationTestBase
    {
        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        private class ThrowMockRestClientFactory : IHDInsightManagementRestClientFactory
        {
            private class ThrowMockRestClient : IHDInsightManagementRestClient
            {
                public void Dispose()
                {
                }

                public Task<IHttpResponseMessageAbstraction> ListCloudServices()
                {
                    throw new NotImplementedException("Mock Throw Exception");
                }

                public Task<IHttpResponseMessageAbstraction> CreateContainer(string dnsName, string location, string clusterPayload, int version=2)
                {
                    throw new NotImplementedException("Mock Throw Exception");
                }

                public Task<IHttpResponseMessageAbstraction> DeleteContainer(string dnsName, string location)
                {
                    throw new NotImplementedException("Mock Throw Exception");
                }

                public Task<IHttpResponseMessageAbstraction> EnableDisableUserChangeRequest(string dnsName, string location, UserChangeRequestUserType requestType, string payload)
                {
                    throw new NotImplementedException();
                }

                public Task<IHttpResponseMessageAbstraction> EnableDisableUserChangeRequest(string dnsName, string location, string payload)
                {
                    throw new NotImplementedException("Mock Throw Exception");
                }

                public Task<IHttpResponseMessageAbstraction> GetOperationStatus(string dnsName, string location, Guid operationId)
                {
                    throw new NotImplementedException();
                }

                public ILogger Logger { get; private set; }
            }

            public IHDInsightManagementRestClient Create(IHDInsightSubscriptionCredentials credentials, IAbstractionContext context, bool ignoreSslErrors)
            {
                return new ThrowMockRestClient();
            }
        }

        [TestMethod]
        [TestCategory("Defect")]
        [TestCategory(TestRunMode.CheckIn)]
        public void WhenIGetAnExceptionFromTheSyncLayer_ItIsNotAnAggregateException()
        {
            var manager = ServiceLocator.Instance.Locate<IServiceLocationIndividualTestManager>();
            manager.Override<IHDInsightManagementRestClientFactory>(new ThrowMockRestClientFactory());
            var factory = ServiceLocator.Instance.Locate<IHDInsightClientFactory>();
            try
            {
                var syncClient = factory.Create(new HDInsightCertificateCredential(Guid.Empty, null));
                syncClient.ListClusters();
                Assert.Fail("This test expected an exception but failed to receive the exception.");
            }
            catch (Exception ex)
            {
                Assert.IsNotInstanceOfType(ex, typeof(AggregateException));
                Assert.IsInstanceOfType(ex, typeof(NotImplementedException));
                Assert.AreEqual("Mock Throw Exception", ex.Message);
            }
        }
    }
}
