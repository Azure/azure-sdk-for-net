namespace Microsoft.WindowsAzure.Management.HDInsight.Tests.ClientAbstractionTests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading.Tasks;
    using Microsoft.Hadoop.Client;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.Framework.ServiceLocator;
    using Microsoft.WindowsAzure.Management.HDInsight.JobSubmission.Data;
    using Microsoft.WindowsAzure.Management.HDInsight.JobSubmission.PocoClient;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities;


    [TestClass]
    public class JobPocoTests : IntegrationTestBase
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
        public async Task SubmitJobWithNoArguments()
        {
            string endPoint = @"https://managementnext.rdfetest.dnsdemo4.com";
            string cloudNamespace = @"hdinsight-wfoley";
            // string cloudNamespace = @"hdinsight";
            var creds = GetCredentials("hadoop");
            var x509 = new X509Certificate2(creds.Certificate);
            var dnsName = "wfoley-tortuga-07";
            var subId = creds.SubscriptionId;
            
            dnsName = "laurenycluster2-laureny";
            subId = new Guid("0fec600d-7e0c-4282-ad96-9b515db0471b");
            cloudNamespace = "hdinsight-current";
            endPoint = @"https://umapi.rdfetest.dnsdemo4.com/";

            var createRequest = new HadoopHiveJobCreationDetails();
            createRequest.JobName = "HivePositive";
            createRequest.StatusFolder = Constants.WabsProtocolSchemeName + "laurenycluster2-laureny@laurenasv.blob.core.test-cint.azure-test.net/output/job1";
            createRequest.Query = "show tables";

            //var knowTypes = new Type[]
            //{
            //    typeof(JobRequest), 
            //    typeof(HiveJobRequest), 
            //    typeof(MapReduceJobRequest)
            //};
            //DataContractSerializer ser = new DataContractSerializer(typeof(ClientJobRequest), knowTypes);
            //using (var stream = new MemoryStream())
            //using (var reader = new StreamReader(stream))
            //{
            //    ser.WriteObject(stream, createRequest);
            //    stream.Flush();
            //    stream.Position = 0;
            //    var text = reader.ReadToEnd();
            //}

            var conCreds = new HDInsightSubscriptionCertificateCredentials(subId, x509, new Uri(endPoint), cloudNamespace);
            var client = ServiceLocator.Instance.Locate<IHDInsightJobSubmissionPocoClientFactory>().Create(conCreds);
            var result = await client.SubmitHiveJob(dnsName, "West US", createRequest);
            Assert.IsNotNull(result);
            
        }

        [TestMethod]
        [TestCategory("Integration")]
        // [TestCategory("CheckIn")]
        [TestCategory("Manual")]
        [TestCategory("RestClient")]
        public async Task ListJobsUsingPocoClient()
        {
            string endPoint = @"https://managementnext.rdfetest.dnsdemo4.com";
            string cloudNamespace = @"hdinsight-wfoley";
            // string cloudNamespace = @"hdinsight";
            var creds = GetCredentials("hadoop");
            var x509 = new X509Certificate2(creds.Certificate);
            var dnsName = "wfoley-tortuga-07";
            var subId = creds.SubscriptionId;
            //dnsName = "Test-TestJobSubmit-20130624171952-f7e88";
            //subId = new Guid("0fec600d-7e0c-4282-ad96-9b515db0471b");
            //cloudNamespace = "hdinsight-current";
            //endPoint = @"https://umapi.rdfetest.dnsdemo4.com/";

            //var createRequest = new ClientJobRequest();
            //createRequest.ClassName = "pi";
            //createRequest.JobName = "job1";
            //var args = new List<string>();
            //args.Add("16");
            //args.Add("10000");
            //createRequest.Arguments = args;
            //createRequest.StatusFolder = "/output";
            //createRequest.JobType = JobType.MapReduce;
            //var parameters = new List<JobRequestParameter>();
            //parameters.Add(new JobRequestParameter() { Key = "one", Value = "two" });
            //createRequest.Defines = parameters;
            //var resources = new List<JobRequestParameter>();
            //resources.Add(new JobRequestParameter() { Key = "1", Value = "2" });
            //createRequest.Files = resources;
            //createRequest.Query = "bar";

            //var knowTypes = new Type[]
            //{
            //    typeof(JobRequest), 
            //    typeof(HiveJobRequest), 
            //    typeof(MapReduceJobRequest)
            //};
            //DataContractSerializer ser = new DataContractSerializer(typeof(ClientJobRequest), knowTypes);
            //using (var stream = new MemoryStream())
            //using (var reader = new StreamReader(stream))
            //{
            //    ser.WriteObject(stream, createRequest);
            //    stream.Flush();
            //    stream.Position = 0;
            //    var text = reader.ReadToEnd();
            //}

            var conCreds = new HDInsightSubscriptionCertificateCredentials(subId, x509, new Uri(endPoint), cloudNamespace);
            var client = ServiceLocator.Instance.Locate<IHDInsightJobSubmissionPocoClientFactory>().Create(conCreds);
            var result = await client.ListJobs(dnsName, "East US");
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [TestCategory("Integration")]
        // [TestCategory("CheckIn")]
        [TestCategory("Manual")]
        [TestCategory("RestClient")]
        public async Task GetJobDetailUsingPocoClient()
        {
            string endPoint = @"https://managementnext.rdfetest.dnsdemo4.com:443";
            string cloudNamespace = @"hdinsight-wfoley";
            // string cloudNamespace = @"hdinsight";
            var creds = GetCredentials("hadoop");
            var x509 = new X509Certificate2(creds.Certificate);
            endPoint = @"https://";
            var dnsName = "wfoley-tortuga-07";

            var conCreds = new HDInsightSubscriptionCertificateCredentials(creds.SubscriptionId, x509, new Uri(endPoint), cloudNamespace);
            var client = ServiceLocator.Instance.Locate<IHDInsightJobSubmissionPocoClientFactory>().Create(conCreds);
            var result = await client.GetJobDetail(dnsName, "East US", "job_201306130113_0017");
            Assert.IsNotNull(result);
        }
    }
}
