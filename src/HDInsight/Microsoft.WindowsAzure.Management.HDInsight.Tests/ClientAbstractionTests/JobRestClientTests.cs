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
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Hadoop.Client;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.DynamicXml.Writer;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;
    using Microsoft.WindowsAzure.Management.HDInsight.JobSubmission.RestClient;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities;


    [TestClass]
    public class JobRestClientTests : IntegrationTestBase
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
        // [TestCategory("CheckIn")]
        [TestCategory("Manual")]
        [TestCategory("RestClient")]
        public async Task ListJobsUsingRestClient()
        {
            string endPoint = @"https://managementnext.rdfetest.dnsdemo4.com:443";
            string cloudNamespace = @"hdinsight-wfoley";
            // string cloudNamespace = @"hdinsight";
            var creds = GetCredentials("hadoop");
            var x509 = new X509Certificate2(creds.Certificate);
            var conCreds = new HDInsightCertificateCredential(creds.SubscriptionId, x509, new Uri(endPoint), cloudNamespace);
            var client = ServiceLocator.Instance.Locate<IHDInsightJobSubmissionRestClientFactory>().Create(conCreds, GetAbstractionContext(), false);
            var result = await client.ListJobs("wfoley-tortuga-07", "East US");
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [TestCategory("Integration")]
        // [TestCategory("CheckIn")]
        [TestCategory("Manual")]
        [TestCategory("RestClient")]
        public async Task ListAJobUsingRestClient()
        {
            string endPoint = @"https://managementnext.rdfetest.dnsdemo4.com:443";
            string cloudNamespace = @"hdinsight-wfoley";
            // string cloudNamespace = @"hdinsight";
            var creds = GetCredentials("hadoop");
            var id = "job_201306130113_0009";
            var x509 = new X509Certificate2(creds.Certificate);
            var conCreds = new HDInsightCertificateCredential(creds.SubscriptionId, x509, new Uri(endPoint), cloudNamespace);
            var client = ServiceLocator.Instance.Locate<IHDInsightJobSubmissionRestClientFactory>().Create(conCreds, GetAbstractionContext(), false);
            var result = await client.GetJobDetail("wfoley-tortuga-07", "East US", id);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [TestCategory("Integration")]
        // [TestCategory("CheckIn")]
        [TestCategory("Manual")]
        [TestCategory("RestClient")]
        public async Task CreateAJobUsingRestClient()
        {
            dynamic builder = DynaXmlBuilder.Create();
            builder.xmlns("http://schemas.datacontract.org/2004/07/Microsoft.ClusterServices.RDFEProvider.ResourceExtensions.JobSubmission.Models")
                   .xmlns.i("http://www.w3.org/2001/XMLSchema-instance")
                   .xmlns.a("http://schemas.microsoft.com/2003/10/Serialization/Arrays")
                   .ClientJobRequest
                   .b
                     .ApplicationName("pi")
                     .Arguments
                     .b
                        .xmlns.a.@string(16)
                        .xmlns.a.@string(10000)
                     .d
                     .JarFile(Constants.WabsProtocolSchemeName + "jarfiles@wfoleyeastus.blob.core.windows.net/hadoop-examples.jar")
                     .JobName("TestJob")
                     .JobType("MapReduce")
                     .OutputStorageLocation("wfoleyeastus")
                     .Parameters
                     .Query
                     .b
                       .at.xmlns.i.nil("true")
                     .d
                     .Resources
                   .d
                   .End();
            string payLoad;
            using (var stream = new MemoryStream())
            using (var reader = new StreamReader(stream))
            {
                builder.Save(stream);
                stream.Position = 0;
                payLoad = reader.ReadToEnd();
            }
            Assert.IsNotNull(payLoad);

            string endPoint = @"https://managementnext.rdfetest.dnsdemo4.com";
            string dnsName = "wfoley-tortuga-07";
            string cloudNamespace = @"hdinsight-wfoley";
            var creds = GetCredentials("hadoop");
            var subId = creds.SubscriptionId;
            var x509 = new X509Certificate2(creds.Certificate);

            //dnsName = "Test-TestJobSubmit-20130624171952-f7e88";
            //subId = new Guid("0fec600d-7e0c-4282-ad96-9b515db0471b");
            //cloudNamespace = "hdinsight-current";
            //endPoint = @"https://umapi.rdfetest.dnsdemo4.com/";

            var conCreds = new HDInsightCertificateCredential(subId, x509, new Uri(endPoint), cloudNamespace);
            var client = ServiceLocator.Instance.Locate<IHDInsightJobSubmissionRestClientFactory>().Create(conCreds, GetAbstractionContext(), false);
            var result = await client.CreateJob(dnsName, "East US", payLoad);
            Assert.IsNotNull(result);
        }

    }
}
