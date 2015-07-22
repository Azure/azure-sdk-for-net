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

namespace Microsoft.Hadoop.Avro.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Hadoop.Avro.Container;
    using Microsoft.Hadoop.Client;
    using Microsoft.Hadoop.Client.Storage;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.JobSubmission;
    using Microsoft.WindowsAzure.Management.HDInsight.Tests.Scenario;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities;

    [TestClass]
    public sealed class IntegrationWithHiveTests : IntegrationTestBase
    {
        private static IJobSubmissionClient jobSubmissionClient;
        private IntegrationWithHiveDataProvider dataProvider;
        private WabStorageAccountConfiguration storageAccount;
        private IStorageAbstraction storageClient;

        private static readonly Lazy<ClusterDetails> Cluster = new Lazy<ClusterDetails>(
            () =>
            {
                var credentials = GetValidCredentials();
                var client = HDInsightClient.Connect(new HDInsightCertificateCredential(credentials.SubscriptionId, credentials.Certificate));
                var randomCluster = GetRandomCluster();
                randomCluster.UserName = TestCredentials.AzureUserName;
                randomCluster.Password = TestCredentials.AzurePassword;
                return client.CreateCluster(randomCluster);
            });

        public IntegrationWithHiveTests()
        {
            this.dataProvider = null;
        }

        [ClassInitialize]
        public static void SuiteInitialize(TestContext context)
        {
            TestRunSetup();
        }

        [ClassCleanup]
        public static void SuiteCleanup()
        {
            TestRunCleanup();
        }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            base.ApplyIndividualTestMockingOnly();
            this.storageAccount = GetWellKnownStorageAccounts().First();
            this.storageClient =
                new WabStorageAbstraction(
                    new WindowsAzureStorageAccountCredentials
                    {
                        Key = this.storageAccount.Key,
                        Name = this.storageAccount.Name,
                        ContainerName = this.storageAccount.Container
                    });
            jobSubmissionClient =
                new HDInsightHadoopClient(
                    new JobSubmissionCertificateCredential(
                        Cluster.Value.SubscriptionId,
                        GetValidCredentials().Certificate,
                        Cluster.Value.Name));
            this.CleanupCluster();
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        private void RoundtripAvroDataToHive()
        {
            this.UploadFiles();

            string testDirectory = string.Format(
                "{0}{1}@{2}/{3}",
                Constants.WabsProtocolSchemeName,
                this.storageAccount.Container,
                this.storageAccount.Name,
                AvroIntegrationWithHiveConfigurations.TestRootDirectory);

            RunHiveJob(new HiveJobCreateParameters { File = testDirectory + "/query.hql", JobName = "CreateLargeClassTable" });

            JobCreationResults result =
                RunHiveJob(
                    new HiveJobCreateParameters
                    {
                        Query = "SELECT BoolMember, DateTimeMember, DecimalMember, DoubleMember, EnumMember, FloatMember, base64(GuidMember), IntArrayMember, IntListMember, IntMapMember, IntMember, LongMember, SByteArrayMember, StringMember FROM " + AvroIntegrationWithHiveConfigurations.HiveTableName,
                        JobName = "QueryLargeClassTable",
                        StatusFolder = "/" + AvroIntegrationWithHiveConfigurations.QueryResultFolder
                    });
            Stream stream = jobSubmissionClient.GetJobOutput(result.JobId);
            this.dataProvider.CompareToQueryResult(new StreamReader(stream).ReadToEnd());

            RunHiveJob(new HiveJobCreateParameters { File = testDirectory + "/extraquery.hql", JobName = "CreateExtraLargeClassTable" });
            RunHiveJob(
                new HiveJobCreateParameters
                {
                    Query =
                        "INSERT INTO TABLE " + AvroIntegrationWithHiveConfigurations.HiveExtraTableName + " SELECT * FROM " +
                        AvroIntegrationWithHiveConfigurations.HiveTableName + ";"
                });

            Task<Stream> task = this.storageClient.Read(new Uri(testDirectory + "/extradata/000000_0"));
            task.Wait();
            Stream streamResult = task.Result;

            this.dataProvider.CompareToAvroFile(streamResult);
        }

        private static JobCreationResults RunHiveJob(HiveJobCreateParameters job)
        {
            JobCreationResults jobDetails = jobSubmissionClient.CreateHiveJob(job);
            JobDetails jobInProgress = jobSubmissionClient.GetJob(jobDetails.JobId);
            while (jobInProgress.StatusCode != JobStatusCode.Completed && jobInProgress.StatusCode != JobStatusCode.Failed)
            {
                jobInProgress = jobSubmissionClient.GetJob(jobInProgress.JobId);
                Thread.Sleep(TimeSpan.FromMilliseconds(IHadoopClientExtensions.GetPollingInterval()));
            }
            Assert.IsNull(jobDetails.ErrorCode, "Should not fail hive jobDetails submission");
            Assert.IsNotNull(jobDetails.JobId, "Should have a non-null jobDetails id");
            return jobDetails;
        }

        public void UploadFiles()
        {
            string testDirectory = string.Format(
                "{0}{1}@{2}/{3}",
                Constants.WabsProtocolSchemeName,
                this.storageAccount.Container,
                this.storageAccount.Name,
                AvroIntegrationWithHiveConfigurations.TestRootDirectory);

            using (var memoryStream = new MemoryStream())
            {
                this.dataProvider.WriteAvroFile(memoryStream);
                memoryStream.Flush();
                memoryStream.Seek(0, SeekOrigin.Begin);
                this.storageClient.Write(new Uri(testDirectory + "/dataProvider/largeclass.avro"), memoryStream);
            }

            string queryFileContent = "CREATE EXTERNAL TABLE " + AvroIntegrationWithHiveConfigurations.HiveTableName +
                                      " ROW FORMAT SERDE 'org.apache.hadoop.hive.serde2.avro.AvroSerDe' STORED AS INPUTFORMAT 'org.apache.hadoop.hive.ql.io.avro.AvroContainerInputFormat' OUTPUTFORMAT 'org.apache.hadoop.hive.ql.io.avro.AvroContainerOutputFormat' LOCATION '" +
                                      testDirectory + "/dataProvider" + "' TBLPROPERTIES ('avro.schema.literal'='" +
                                      this.dataProvider.GetSchema().ToString().Replace("\\", string.Empty) + "');";
            using (var memoryStream = new MemoryStream())
            {
                using (var streamWriter = new StreamWriter(memoryStream))
                {
                    streamWriter.Write(queryFileContent);
                    streamWriter.Flush();
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    this.storageClient.Write(new Uri(testDirectory + "/query.hql"), memoryStream);
                }
            }

            queryFileContent = "CREATE EXTERNAL TABLE " + AvroIntegrationWithHiveConfigurations.HiveExtraTableName +
                               " ROW FORMAT SERDE 'org.apache.hadoop.hive.serde2.avro.AvroSerDe' STORED AS INPUTFORMAT 'org.apache.hadoop.hive.ql.io.avro.AvroContainerInputFormat' OUTPUTFORMAT 'org.apache.hadoop.hive.ql.io.avro.AvroContainerOutputFormat' LOCATION '" +
                               testDirectory + "/extradata" + "' TBLPROPERTIES ('avro.schema.literal'='" +
                               this.dataProvider.GetSchema().ToString().Replace("\\", string.Empty) + "');";
            using (var memoryStream = new MemoryStream())
            {
                using (var streamWriter = new StreamWriter(memoryStream))
                {
                    streamWriter.Write(queryFileContent);
                    streamWriter.Flush();
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    this.storageClient.Write(new Uri(testDirectory + "/extraquery.hql"), memoryStream);
                }
            }

            string s = string.Format(
                CultureInfo.InvariantCulture,
                "{0}{1}@{2}/{3}",
                Constants.WabsProtocolSchemeName,
                this.storageAccount.Container,
                this.storageAccount.Name,
                AvroIntegrationWithHiveConfigurations.QueryResultFolder);

            Task<IEnumerable<Uri>> listTask = this.storageClient.List(new Uri(s), true);
            listTask.Wait();
            IEnumerable<Uri> fileStreamBefore = listTask.Result;
        }

        public void CleanupCluster()
        {
            RunHiveJob(
                new HiveJobCreateParameters
                {
                    Query = "DROP TABLE " + AvroIntegrationWithHiveConfigurations.HiveTableName,
                    JobName = "RemoveLargeClassTable"
                });

            RunHiveJob(
                new HiveJobCreateParameters
                {
                    Query = "DROP TABLE " + AvroIntegrationWithHiveConfigurations.HiveExtraTableName,
                    JobName = "RemoveExtraLargeClassTable"
                });

            IEnumerable<Uri> pathsToDelete =
                new[]
                {
                    string.Format(
                        "{0}{1}@{2}/{3}",
                        Constants.WabsProtocolSchemeName,
                        this.storageAccount.Container,
                        this.storageAccount.Name,
                        AvroIntegrationWithHiveConfigurations.TestRootDirectory),
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "{0}{1}@{2}/{3}",
                        Constants.WabsProtocolSchemeName,
                        this.storageAccount.Container,
                        this.storageAccount.Name,
                        AvroIntegrationWithHiveConfigurations.QueryResultFolder)
                }.Select(s => new Uri(s));

            foreach (Uri filePath in pathsToDelete)
            {
                Task<IEnumerable<Uri>> listFilesTask = this.storageClient.List(filePath, true);
                listFilesTask.Wait();
                IEnumerable<Uri> filesList = listFilesTask.Result;
                if (filesList.Any())
                {
                    this.storageClient.Delete(filePath);
                }
                Task<IEnumerable<Uri>> listFilesAfterDeletionTask = this.storageClient.List(filePath, true);
                listFilesAfterDeletionTask.Wait();
                IEnumerable<Uri> filesListAfterDeletion = listFilesAfterDeletionTask.Result;
                Assert.AreEqual(filesListAfterDeletion.Count(), 0);
            }
        }
    }
}
