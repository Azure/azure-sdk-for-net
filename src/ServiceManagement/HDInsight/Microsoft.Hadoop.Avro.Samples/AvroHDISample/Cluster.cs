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

//
// This example illustrates some programming techniques related to interaction with Microsoft Azure HDInsight service.
// It also illustrate the usage of Microsoft Avro Library
// To run this sample you need to have an active Azure Subscription together with provisioned HDInsight cluster
// You also need to edit App.config file and insert the required Azure Subscription information before building the sample
// (or you can edit AvroHDISample.exe.config after the build)
//
// AvroHDISample.cs contains the major classes and methods required for the sample.
//
// This file (Cluster.cs) contains all classes that work directly with Microsoft Azure HDInsight clusters
//
// Stock.cs contains a definition of Stock class which is used to represent the sample data.
// Stock.cs is auto-generated from JSON schema using Microsoft Avro Library Code Generation utility
//

namespace Microsoft.Hadoop.Avro.Sample
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading;
    using Microsoft.Hadoop.Client;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;

    /// <summary>
    /// Encapsulates all cluster-related operations.
    /// </summary>
    internal sealed class Cluster
    {
        /// <summary>
        /// Azure Blob folder name to store the serialized data
        /// The same folder is referred to Hive external table
        /// </summary>
        private const string RootDirectory = "AA";

        /// <summary>
        /// HDinsight client
        /// </summary>
        private IHDInsightClient client;

        /// <summary>
        /// HDInsiht cluster
        /// </summary>
        private ClusterDetails cluster;

        /// <summary>
        /// HDIsnight Cluster Job
        /// </summary>
        private IJobSubmissionClient job;

        /// <summary>
        /// Azure Blob storage container
        /// </summary>
        private CloudBlobContainer container;

        /// <summary>
        /// Connects to HDInsight cluster.
        /// </summary>
        /// <param name="certificate">The certificate.</param>
        /// <param name="subscription">The subscription.</param>
        /// <param name="clusterName">Name of the cluster.</param>
        /// <param name="storageAccountName">Name of the storage account.</param>
        /// <param name="storageAccountKey">The storage account key.</param>
        public void Connect(string certificate, string subscription, string clusterName, string storageAccountName, string storageAccountKey)
        {
            // Obtain the certificate
            var store = new X509Store();
            store.Open(OpenFlags.ReadOnly);
            var cert = store.Certificates.Cast<X509Certificate2>().FirstOrDefault(item => string.Compare(item.Thumbprint, certificate, CultureInfo.InvariantCulture, CompareOptions.IgnoreCase) == 0);
            if (cert == null)
            {
                AvroHdiSample.ReportError("Error: Counld not find the certificate on this machine!");
            }

            // Connect to the cluster using the certificate and the subscription
            try
            {
                this.client = HDInsightClient.Connect(new HDInsightCertificateCredential(new Guid(subscription), cert));
            }
            catch (Exception e)
            {
                AvroHdiSample.ReportError("Error while connecting to HDInsight service\n" + e);
            }

            this.cluster = this.client.GetCluster(clusterName);
            if (this.cluster == null)
            {
                AvroHdiSample.ReportError("Error while connecting to cluster: " + clusterName);
            }

            // Create a job client
            this.job = JobSubmissionClientFactory.Connect(
                        new JobSubmissionCertificateCredential(new Guid(subscription), cert, clusterName));

            // Create an Azure storage client
            // We will use this client to upload files to Azure storage account
            // which is used by HDInsight cluster.
            var storageAccount = CloudStorageAccount.Parse(
                    "DefaultEndpointsProtocol=https;AccountName=" + storageAccountName + ";AccountKey=" + storageAccountKey);
            var blobClient = storageAccount.CreateCloudBlobClient();
            this.container = blobClient.GetContainerReference(this.cluster.DefaultStorageAccount.Container);
        }

        /// <summary>
        /// Creates Hive table called Stocks
        /// </summary>
        public void CreateStocksTable()
        {
            const string QueryFileName = "hql/create.hql";

            // Prepare the query file
            using (var stream = new MemoryStream())
            {
                using (var streamWriter = new StreamWriter(stream))
                {
                    streamWriter.Write(
                        "CREATE EXTERNAL TABLE Stocks "
                        + "ROW FORMAT SERDE 'org.apache.hadoop.hive.serde2.avro.AvroSerDe' " + "STORED AS "
                        + "INPUTFORMAT 'org.apache.hadoop.hive.ql.io.avro.AvroContainerInputFormat' "
                        + "OUTPUTFORMAT 'org.apache.hadoop.hive.ql.io.avro.AvroContainerOutputFormat' " + "LOCATION '/"
                        + RootDirectory + "/data' TBLPROPERTIES ('avro.schema.literal'='" + Stock.Schema + "');");
                    streamWriter.Flush();
                    stream.Seek(0, SeekOrigin.Begin);
                    this.Upload(QueryFileName, stream);
                }
            }

            // Execute Hive query
            this.Query(
                new HiveJobCreateParameters
                {
                    File = "/" + RootDirectory + "/" + QueryFileName,
                    JobName = "TableCreationQuery",
                    RunAsFileJob = true
                });
        }

        /// <summary>
        /// Cleans up the cluster.
        /// </summary>
        public void CleanUp()
        {
            // Delete files and folder from Azure blob
            this.DeleteDirectory(this.container.GetDirectoryReference(RootDirectory));
            
            // Remove Hive table
            this.Query(new HiveJobCreateParameters { Query = "DROP TABLE Stocks;" });
        }

        /// <summary>
        /// Uploads Avro file to cluster.
        /// </summary>
        /// <param name="fileName">The file name.</param>
        /// <param name="data">The file content.</param>
        public void UploadAvro(string fileName, Stream data)
        {
            this.Upload("data/" + fileName, data);
        }

        /// <summary>
        /// Performs HQL query and returns the query results.
        /// </summary>
        /// <param name="jobParams">The query parameters.</param>
        /// <returns>The query result.</returns>
        public string Query(HiveJobCreateParameters jobParams)
        {
            // Assign status folder
            jobParams.StatusFolder = RootDirectory + "/status";

            JobCreationResults jobDetails = null;

            try
            {
                // Create Hive job
                jobDetails = this.job.CreateHiveJob(jobParams);
            }
            catch (Exception e)
            {
                AvroHdiSample.ReportError("Error while creating a Hive job\n" + e);
            }

            JobDetails jobInProgress = null;

            try
            {
                // Get job status
                jobInProgress = this.job.GetJob(jobDetails.JobId);
            }
            catch (Exception e)
            {
                AvroHdiSample.ReportError("Error while getting Hive job status\n" + e);
            }


            // If job is not finished then sleep until the next client polling interval
            while (jobInProgress.StatusCode != JobStatusCode.Completed
                   && jobInProgress.StatusCode != JobStatusCode.Failed)
            {
                try
                {
                    // Get job status
                    jobInProgress = this.job.GetJob(jobDetails.JobId);
                }
                catch (Exception e)
                {
                    AvroHdiSample.ReportError("Error while getting Hive job status\n" + e);
                }

                Thread.Sleep(this.client.PollingInterval);
            }

            try
            {
                // Job is finished; get its output stream, read it, and return the value
                return new StreamReader(this.job.GetJobOutput(jobDetails.JobId)).ReadToEnd();
            }
            catch (Exception e)
            {
                AvroHdiSample.ReportError("Error while reading Hibe job result\n" + e);
            }

            return string.Empty;
        }

        /// <summary>
        /// Uploads the specified path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="stream">The stream.</param>
        private void Upload(string path, Stream stream)
        {
            CloudBlockBlob blockBlob = null;

            try
            {
                // Create a block Blob for the file
                blockBlob = this.container.GetBlockBlobReference(RootDirectory + "/" + path);
            }
            catch (Exception e)
            {
                AvroHdiSample.ReportError("Error while getting a block reference from the cluster\n" + e);
            }

            // Rewind the stream
            stream.Seek(0, SeekOrigin.Begin);

            try
            {
                // Upload the stream content to designated block Blob
                blockBlob.UploadFromStream(stream);
            }
            catch (Exception e)
            {
                AvroHdiSample.ReportError("Error while uploading data to cluster\n" + e);
            }
        }

        /// <summary>
        /// Deletes a directory in Azure Blob
        /// </summary>
        /// <param name="directory">The directory.</param>
        private void DeleteDirectory(CloudBlobDirectory directory)
        {
            try
            {
                foreach (var item in directory.ListBlobs())
                {
                    var blockBlob = item as CloudBlockBlob;
                    if (blockBlob != null)
                    {
                        blockBlob.DeleteIfExists();
                    }
                    else
                    {
                        var dir = item as CloudBlobDirectory;
                        if (dir != null)
                        {
                            this.DeleteDirectory(dir);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                AvroHdiSample.ReportError("Error while cleaning the cluster\n" + e);
            }
        }
    }
}