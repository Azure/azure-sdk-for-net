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
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Xml;
    using Microsoft.Hadoop.Client;
    using Microsoft.Hadoop.Client.HadoopJobSubmissionRestCleint;
    using Microsoft.Hadoop.Client.WebHCatRest;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.RestClient;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Retries;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;
    using Microsoft.WindowsAzure.Management.HDInsight.InversionOfControl;
    using System.Net;
    using Microsoft.WindowsAzure.Management.HDInsight.JobSubmission.Data;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities.ServerDataObjects;
    using Microsoft.WindowsAzure.Management.HDInsight.Tests.ConnectionCredentials;
    using Microsoft.WindowsAzure.Management.HDInsight.Tests.ServerDataObjects.Rdfe;
    using Moq;

    [TestClass]
    public class RestClientTests : IntegrationTestBase
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
        [TestCategory("RestClient")]
        public void InternalValidation_HDInsightManagementRestClient_GetCloudServiceName()
        {
            IHDInsightSubscriptionCredentials credentials = IntegrationTestBase.GetValidCredentials();
            var resolver = ServiceLocator.Instance.Locate<ICloudServiceNameResolver>();
            var serviceName = resolver.GetCloudServiceName(Guid.Empty, "hdInsight", "EastUS");
            Assert.AreEqual("hdInsightCK4TO7F6PZOJJ2FHBWOSHEUVEPIUV6UVI6JRGD4KHFM4POCJVSUA-EastUS", serviceName);

            var serviceName1 = resolver.GetCloudServiceName(credentials.SubscriptionId, credentials.DeploymentNamespace, "EastUS");
            var serviceName2 = resolver.GetCloudServiceName(credentials.SubscriptionId, credentials.DeploymentNamespace, "EastUS");
            Assert.AreEqual(serviceName1, serviceName2);
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        [TestCategory("RestClient")]
        public void InternalValidation_HadoopRestClientException()
        {
            //TODO: Test serailize\deserialize

            // Validates that the exception is properly created and all the fields match what's expected
            try
            {
                throw new HttpLayerException(HttpStatusCode.Ambiguous, "Hello world");
            }
            catch (HttpLayerException exception)
            {
                Assert.AreEqual("Hello world", exception.RequestContent);
                Assert.AreEqual(HttpStatusCode.Ambiguous, exception.RequestStatusCode);
                Assert.AreEqual("Request failed with code:MultipleChoices\r\nContent:Hello world", exception.Message);
            }
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        [TestCategory("RestClient")]
        public async Task ICanPerformA_ListCloudServices_Using_RestClientAbstraction()
        {
            IHDInsightSubscriptionCredentials credentials = IntegrationTestBase.GetValidCredentials();
            var client = ServiceLocator.Instance.Locate<IHDInsightManagementRestClientFactory>().Create(credentials, GetAbstractionContext(), false);
            var result = await client.ListCloudServices();
            Assert.IsTrue(this.ContainsContainer(TestCredentials.WellKnownCluster.DnsName, result.Content));
        }

        [TestMethod]
        public void ICanSerializeAndDeserialzeCreationResults()
        {
            JobCreationResults expected = new JobCreationResults() { HttpStatusCode = HttpStatusCode.Accepted, JobId = "job123" };
            JobPayloadServerConverter ser = new JobPayloadServerConverter();
            JobPayloadConverter deser = new JobPayloadConverter();
            var payload = ser.SerializeJobCreationResults(expected);
            var actual = deser.DeserializeJobCreationResults(payload);
        }

        // dnsName, location, subscriptionId, Guid.NewGuid()
        internal const string CreateContainerGenericRequest =
@"<ClusterContainer xmlns=""http://schemas.datacontract.org/2004/07/Microsoft.ClusterServices.DataAccess.Context"" xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"">
    <ExtendedProperties i:nil=""true"" />
    <AzureStorageAccount i:nil=""true"" />
    <CNameMapping i:nil=""true"" />
    <ContainerError i:nil=""true"" />
    <ContainerState i:nil=""true"" />
    <Deployment i:nil=""true"" />
    <DeploymentAction>None</DeploymentAction>
    <DnsName>{0}</DnsName>
    <AzureStorageLocation>{1}</AzureStorageLocation>
    <SubscriptionId>{2}</SubscriptionId>
    <IncarnationID>{3}</IncarnationID>
</ClusterContainer>";

        private bool ContainsContainer(string dnsName, string payload)
        {
            string xmlContainer = string.Format("<Name>{0}</Name>", dnsName);
            return payload.Contains(xmlContainer);
        }
    }
}
