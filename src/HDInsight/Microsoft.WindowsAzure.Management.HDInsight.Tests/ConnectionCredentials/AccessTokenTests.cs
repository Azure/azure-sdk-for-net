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
namespace Microsoft.WindowsAzure.Management.HDInsight.Tests.Configuration
{
    using System;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading.Tasks;
    using Microsoft.Hadoop.Client;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.Configuration;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities;

    [TestClass]
    public class AccessTokenTests : IntegrationTestBase
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

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        public void TestWithNullCredentials()
        {
            IHDInsightSubscriptionCredentials credentials = null;
            Exception error = null;
            try
            {
                IHttpClientAbstraction invalidAbstraction =
                    ServiceLocator.Instance.Locate<IHDInsightHttpClientAbstractionFactory>().Create(credentials, false);
                Assert.Fail("No Http client should be created with null credentials");
            }
            catch (NotSupportedException e)
            {
                error = e;
            }
            Assert.IsNotNull(error);
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        public void TestWithInvalidCredentialType()
        {
            IHDInsightSubscriptionCredentials credentials = new TestInvalidCredentials()
            {
                DeploymentNamespace = "hdinsight",
                Endpoint = new Uri("http://notrdfe.com/"),
                SubscriptionId = Guid.NewGuid()
            };
            Exception error = null;
            try
            {
                IHttpClientAbstraction invalidAbstraction =
                    ServiceLocator.Instance.Locate<IHDInsightHttpClientAbstractionFactory>().Create(credentials, false);
                Assert.Fail("No Http client should be created with unsupported credential types");
            }
            catch (NotSupportedException e)
            {
                error = e;
            }
            Assert.IsNotNull(error);
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        public void TestWithValidCredentials()
        {
            string accessToken = "somestring";
            IHDInsightSubscriptionCredentials credentials = new HDInsightAccessTokenCredential()
            {
                AccessToken = accessToken,
                DeploymentNamespace = "hdinsight",
                Endpoint = new Uri("http://notrdfe.com/"),
                SubscriptionId = Guid.NewGuid()
            };
            Exception error = null;
            try
            {
                IHttpClientAbstraction validAbstraction =
                    ServiceLocator.Instance.Locate<IHDInsightHttpClientAbstractionFactory>().Create(credentials, false);
                Assert.IsTrue(validAbstraction.RequestHeaders.ContainsKey("Authorization"));
                Assert.AreEqual(validAbstraction.RequestHeaders["Authorization"], "Bearer " + accessToken);
            }
            catch (NotSupportedException e)
            {
                error = e;
            }
            Assert.IsNull(error);
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        public void ListClustersWithAccessToken()
        {
            string accessToken = "eyiIsIng1dCI6Ik5HVEZ2ZEstZnl0aEV1THdqcHdBSk9NOW4tQSJ9.eyJhdWQiOiJodHRwczovL21hbmFnZW1lbnQuY29yZS53aW5kb3dzLm5ldC8iLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC83MmY5ODhiZi04NmYxLTQxYWYtOTFhYi0yZDdjZDAxMWRiNDcvIiwiaWF0IjoxMzg0ODAyNzY5LCJuYmYiOjEzODQ4MDI3NjksImV4cCI6MTM4NDgwNjM2OSwidmVyIjoiMS4wIiwidGlkIjoiNzJmOTg4YmYtODZmMS00MWFmLTkxYWItMmQ3Y2QwMTFkYjQ3Iiwib2lkIjoiMzMxMDNiMzEtZTNlNS00NzAxLTk1YmYtOGNjZTA1MTY3MzdjIiwidXBuIjoicGhhbmlyYWpAbWljcm9zb2Z0LmNvbSIsInVuaXF1ZV9uYW1lIjoicGhhbmlyYWpAbWljcm9zb2Z0LmNvbSIsInN1YiI6ImtMYVVCODA2TmxYMjdJSnhka2NtR0FBSUNpSk94T3lVSVZCeVhQMlNIbnciLCJwdWlkIjoiMTAwMzAwMDA4MDFCQ0IxNSIsImZhbWlseV9uYW1lIjoiWWF5YXZhcmFtIE5hcmFzaW1oYSIsImdpdmVuX25hbWUiOiJQaGFuaSBSYWoiLCJhcHBpZCI6IjE5NTBhMjU4LTIyN2ItNGUzMS1hOWNmLTcxNzQ5NTk0NWZjMiIsImFwcGlkYWNyIjoiMCIsInNjcCI6InVzZXJfaW1wZXJzb25hdGlvbiIsImFjciI6IjEifQ.UejKWEUhF35F7NqhfFg73zoXclmrWhCTowpc78TICFOvMzFQYzR8bpBc-NtGOpwcFDN2yIp1eJhPV_QL_gl2Y4HXIl-_ziw_g9KhYeZXTxnhvpS9zquefzTiIoZL4eo-nm6cBkxvHqaeq6P9mkgp6Y3xd9Py1YRkkwKndnoynzWPKHipO0pL_vEpJgMLHzDLkPq2RbFg4ANp35vfxQpPhC0YrbjWYiwsyrsrjYHN9rIkfqyhePcEaLH-jNdZFzL5yJHo3JiDD6CvbeiFpY4_S1y9PEFHSwbXSAmgKBzr9SzBTR0Pm54FMVvsHsYyTdpMS9Pmdzzd9qr3FyXsUrXTaQ";
            IHDInsightSubscriptionCredentials credentials = new HDInsightAccessTokenCredential()
            {
                AccessToken = accessToken,
                DeploymentNamespace = "hdinsight",
                SubscriptionId = IntegrationTestBase.TestCredentials.SubscriptionId
            };
            Exception error = null;
            try
            {
                var client = HDInsightClient.Connect(credentials);
                var myClusters = client.ListClusters();
            }
            catch (NotSupportedException e)
            {
                error = e;
            }
            Assert.IsNull(error);
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        public void TestWithCertificateCredentials()
        {
            IHDInsightSubscriptionCredentials credentials = new HDInsightCertificateCredential()
            {
                Certificate = new X509Certificate2(IntegrationTestBase.TestCredentials.Certificate),
                DeploymentNamespace = "hdinsight",
                Endpoint = new Uri("http://notrdfe.com/"),
                SubscriptionId = Guid.NewGuid()
            };
            Exception error = null;
            try
            {
                //Should not have token header set when using a certificate
                IHttpClientAbstraction validAbstraction =
                    ServiceLocator.Instance.Locate<IHDInsightHttpClientAbstractionFactory>().Create(credentials, false);
                Assert.IsFalse(validAbstraction.RequestHeaders.ContainsKey("Authorization"));
            }
            catch (NotSupportedException e)
            {
                error = e;
            }
            Assert.IsNull(error);
        }
    }

    internal class TestInvalidCredentials : IHDInsightSubscriptionCredentials
    {
        /// <inheritdoc />
        public Uri Endpoint { get; set; }

        /// <inheritdoc />
        public string DeploymentNamespace { get; set; }

        /// <inheritdoc />
        public Guid SubscriptionId { get; set; }
    }
}
