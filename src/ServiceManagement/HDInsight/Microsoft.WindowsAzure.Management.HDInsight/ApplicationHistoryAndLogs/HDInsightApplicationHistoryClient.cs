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
namespace Microsoft.WindowsAzure.Management.HDInsight
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Hadoop.Client;
    using Microsoft.Hadoop.Client.Storage;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;

    /// <summary>
    /// Represents HDInsight Application History client.
    /// </summary>
    public class HDInsightApplicationHistoryClient : IHDInsightApplicationHistoryClient
    {
        private TimeSpan timeout;
        private string customUserAgent;
        private IHadoopApplicationHistoryClient applicationHistoryClient;

        /// <summary>
        /// Initializes a new instance of the HDInsightApplicationHistoryClient class.
        /// </summary>
        /// <param name="cluster">
        /// Details about the cluster against which the client should be created.
        /// </param>
        internal HDInsightApplicationHistoryClient(ClusterDetails cluster)
            : this(cluster, TimeSpan.FromMinutes(5))
        {
        }

        /// <summary>
        /// Initializes a new instance of the HDInsightApplicationHistoryClient class.
        /// </summary>
        /// <param name="cluster">
        /// Details about the cluster against which the client should be created.
        /// </param>
        /// <param name="timeout">
        /// The timeout value to use for operations performed by this client.
        /// </param>
        internal HDInsightApplicationHistoryClient(ClusterDetails cluster, TimeSpan timeout)
            : this(cluster, timeout, string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the HDInsightApplicationHistoryClient class.
        /// </summary>
        /// <param name="cluster">
        /// Details about the cluster against which the client should be created.
        /// </param>
        /// <param name="timeout">
        /// The timeout value to use for operations performed by this client.
        /// </param>
        /// <param name="customUserAgent">
        /// A tag to help identify the client/user.
        /// </param>
        internal HDInsightApplicationHistoryClient(ClusterDetails cluster, TimeSpan timeout, string customUserAgent)
        {
            cluster.ArgumentNotNull("cluster");

            VerifyApplicationHistorySupport(cluster);

            this.Cluster = cluster;
            this.HttpCredentials = GetClusterHttpCredentials(this.Cluster);
            this.DefaultStorageCredentials = GetClusterStorageCredentials(this.Cluster);

            this.timeout = timeout;
            this.customUserAgent = customUserAgent;

            // Versioning of application history client to be handled here.
            this.applicationHistoryClient = HadoopApplicationHistoryClientFactory.Connect(this.HttpCredentials);
        }

        /// <summary>
        /// Gets the cluster.
        /// </summary>
        internal ClusterDetails Cluster { get; private set; }

        /// <summary>
        /// Gets the HTTP credentials.
        /// </summary>
        internal BasicAuthCredential HttpCredentials { get; private set; }

        /// <summary>
        /// Gets the storage credentials.
        /// </summary>
        internal WindowsAzureStorageAccountCredentials DefaultStorageCredentials { get; private set; }

        /// <inheritdoc />
        public async Task<ApplicationDetails> GetApplicationDetailsAsync(string applicationId)
        {
            applicationId.ArgumentNotNullOrEmpty("applicationId");

            return await this.applicationHistoryClient.GetApplicationDetailsAsync(applicationId);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ApplicationDetails>> ListCompletedApplicationsAsync()
        {
            return await ListCompletedApplicationsAsync(DateTime.MinValue, DateTime.UtcNow);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ApplicationDetails>> ListCompletedApplicationsAsync(DateTime submittedAfterInUtc, DateTime submittedBeforeInUtc)
        {
            return await this.applicationHistoryClient.ListCompletedApplicationsAsync(submittedAfterInUtc, submittedBeforeInUtc);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ApplicationAttemptDetails>> ListApplicationAttemptsAsync(ApplicationDetails application)
        {
            application.ArgumentNotNull("application");

            return await this.applicationHistoryClient.ListApplicationAttemptsAsync(application);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ApplicationContainerDetails>> ListApplicationContainersAsync(ApplicationAttemptDetails applicationAttempt)
        {
            applicationAttempt.ArgumentNotNull("applicationAttempt");

            return await this.applicationHistoryClient.ListApplicationContainersAsync(applicationAttempt);
        }

        /// <inheritdoc />
        public async Task DownloadApplicationLogsAsync(ApplicationDetails application, string targetDirectory)
        {
            application.ArgumentNotNull("application");
            targetDirectory.ArgumentNotNullOrEmpty("targetDirectory");

            await DownloadApplicationLogsAsync(application.ApplicationId, application.User, targetDirectory);
        }

        /// <inheritdoc />
        public async Task DownloadApplicationLogsAsync(ApplicationContainerDetails applicationContainer, string targetDirectory)
        {
            applicationContainer.ArgumentNotNull("container");
            targetDirectory.ArgumentNotNullOrEmpty("targetDirectory");

            await DownloadApplicationLogsAsync(
                applicationContainer.ParentApplicationAttempt.ParentApplication.ApplicationId, 
                applicationContainer.ParentApplicationAttempt.ParentApplication.User, 
                applicationContainer.ContainerId, 
                applicationContainer.NodeId, 
                targetDirectory);
        }

        /// <inheritdoc />
        private async Task DownloadApplicationLogsAsync(string applicationId, string applicationUser, string targetDirectory)
        {
            await DownloadApplicationLogsAsync(applicationId, applicationUser, null, null, targetDirectory);
        }

        /// <inheritdoc />
        private async Task DownloadApplicationLogsAsync(string applicationId, string applicationUser, string containerId, string nodeId, string targetDirectory)
        {
            applicationId.ArgumentNotNullOrEmpty("applicationId");
            applicationUser.ArgumentNotNullOrEmpty("applicationUser");
            targetDirectory.ArgumentNotNullOrEmpty("targetDirectory");

            if (!string.IsNullOrEmpty(containerId) && string.IsNullOrEmpty(nodeId))
            {
                throw new ArgumentException("NodeId was null or empty. If container id is specified, node id should also be specified");
            }

            if (!Directory.Exists(targetDirectory))
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "The specified directory {0} does not exist.", targetDirectory));
            }

            var jobSubmissionClient = JobSubmissionClientFactory.Connect(this.HttpCredentials, this.customUserAgent);
            var storageClient = ServiceLocator.Instance.Locate<IWabStorageAbstractionFactory>().Create(this.DefaultStorageCredentials);

            // Check existence of application logs in the default storage account
            Uri appLogContainer = new Uri(string.Format(CultureInfo.InvariantCulture, "{0}{1}@{2}/app-logs/{3}/logs/{4}", Constants.WabsProtocolSchemeName, this.DefaultStorageCredentials.ContainerName, this.DefaultStorageCredentials.Name, applicationUser, applicationId));

            var logFiles = await storageClient.List(appLogContainer, false);
            if (!logFiles.Any())
            {
                throw new InvalidOperationException(string.Format("No logs found for application id {0}, user {1}, on cluster {2} at location {3}", applicationId, applicationUser, this.Cluster.Name, appLogContainer.AbsoluteUri));
            }

            // Application logs exist!
            // Convert them to plain text by running YARN CLI
            string jobName = string.Format("yarnlogs-{0}", Guid.NewGuid());
            string statusFolderName = string.Format("/{0}", jobName);
            string optionalContainerArguments = !string.IsNullOrEmpty(containerId) ? string.Format(" -containerId {0} -nodeAddress {1}", containerId, nodeId) : string.Empty;
            
            string command = "";
            if (this.Cluster.OSType == OSType.Windows)
            {
                command = string.Format("!cmd.exe /c yarn logs -applicationId {0} -appOwner {1}{2};", applicationId, applicationUser, optionalContainerArguments);
            }
            else if (this.Cluster.OSType == OSType.Linux)
            {
                command = string.Format("!yarn logs -applicationId {0} -appOwner {1}{2};", applicationId, applicationUser, optionalContainerArguments);
            }
            else
            {
                throw new NotSupportedException(String.Format("This functionality is not supported on clusters with OS Type: {0}", this.Cluster.OSType));
            }

            string queryFileName = string.Format("/{0}.hql", jobName);

            Uri queryFileUri = new Uri(string.Format(CultureInfo.InvariantCulture, "{0}{1}@{2}{3}", Constants.WabsProtocolSchemeName, this.DefaultStorageCredentials.ContainerName, this.DefaultStorageCredentials.Name, queryFileName));

            Uri statusFolderUri = new Uri(string.Format(CultureInfo.InvariantCulture, "{0}{1}@{2}{3}", Constants.WabsProtocolSchemeName, this.DefaultStorageCredentials.ContainerName, this.DefaultStorageCredentials.Name, statusFolderName));

            try
            {
                var bytes = Encoding.UTF8.GetBytes(command);
                using (var memoryStream = new MemoryStream(bytes))
                {
                    await storageClient.Write(queryFileUri, memoryStream);
                }

                HiveJobCreateParameters hiveJobDefinition = new HiveJobCreateParameters()
                {
                    JobName = jobName,
                    StatusFolder = statusFolderName,
                    File = queryFileName
                };

                JobCreationResults jobResults = jobSubmissionClient.CreateHiveJob(hiveJobDefinition);
                WaitForJobCompletion(jobSubmissionClient, jobResults);

                Uri logContentsFileUri = new Uri(string.Format("{0}/stdout", statusFolderUri.AbsoluteUri));

                if (await storageClient.Exists(logContentsFileUri))
                {
                    // create local file in the targetdirectory.
                    var localFilePath = Path.Combine(targetDirectory, string.Format("{0}_{1}.txt", this.Cluster.Name, string.IsNullOrEmpty(containerId) ? applicationId : containerId));
                    await storageClient.DownloadToFile(logContentsFileUri, localFilePath);
                }
                else
                {
                    throw new InvalidOperationException(string.Format(
                        CultureInfo.InvariantCulture,
                        "Could not retrive logs for application id {0}, user {1} on cluster {2} at location {3}.",
                        applicationId,
                        applicationUser,
                        this.Cluster.Name,
                        appLogContainer.AbsoluteUri));
                }
            }
            finally
            {
                // Cleanup what we created
                if (storageClient.Exists(queryFileUri).WaitForResult())
                {
                    storageClient.Delete(queryFileUri);
                }

                if (storageClient.Exists(statusFolderUri).WaitForResult())
                {
                    storageClient.Delete(statusFolderUri);
                }
            }
        }

        /// <inheritdoc />
        public ApplicationDetails GetApplicationDetails(string applicationId)
        {
            return this.GetApplicationDetailsAsync(applicationId).WaitForResult(this.timeout);
        }

        /// <inheritdoc />
        public IEnumerable<ApplicationDetails> ListCompletedApplications()
        {
            return this.ListCompletedApplications(DateTime.MinValue, DateTime.UtcNow);
        }

        /// <inheritdoc />
        public IEnumerable<ApplicationDetails> ListCompletedApplications(DateTime submittedAfterInUtc, DateTime submittedBeforeInUtc)
        {
            return this.ListCompletedApplicationsAsync(submittedAfterInUtc, submittedBeforeInUtc).WaitForResult(this.timeout);
        }

        /// <inheritdoc />
        public IEnumerable<ApplicationAttemptDetails> ListApplicationAttempts(ApplicationDetails application)
        {
            return this.ListApplicationAttemptsAsync(application).WaitForResult(this.timeout);
        }

        /// <inheritdoc />
        public IEnumerable<ApplicationContainerDetails> ListApplicationContainers(ApplicationAttemptDetails applicationAttempt)
        {
            return this.ListApplicationContainersAsync(applicationAttempt).WaitForResult(this.timeout);
        }

        /// <inheritdoc />
        public void DownloadApplicationLogs(ApplicationDetails application, string targetDirectory)
        {
            this.DownloadApplicationLogs(application, targetDirectory, this.timeout);
        }

        /// <inheritdoc />
        public void DownloadApplicationLogs(ApplicationDetails application, string targetDirectory, TimeSpan timeout)
        {
            this.DownloadApplicationLogsAsync(application, targetDirectory).WaitForResult(timeout);
        }

        /// <inheritdoc />
        public void DownloadApplicationLogs(ApplicationContainerDetails applicationContainer, string targetDirectory)
        {
            this.DownloadApplicationLogs(applicationContainer, targetDirectory, this.timeout);
        }

        /// <inheritdoc />
        public void DownloadApplicationLogs(ApplicationContainerDetails applicationContainer, string targetDirectory, TimeSpan timeout)
        {
            this.DownloadApplicationLogsAsync(applicationContainer, targetDirectory).WaitForResult(timeout);
        }

        private static BasicAuthCredential GetClusterHttpCredentials(ClusterDetails cluster)
        {
            if (string.IsNullOrEmpty(cluster.ConnectionUrl))
            {
                throw new InvalidOperationException("Unable to connect to cluster as connection url is missing or empty.");
            }

            if (string.IsNullOrEmpty(cluster.HttpUserName) || string.IsNullOrEmpty(cluster.HttpPassword))
            {
                throw new InvalidOperationException("Unable to connect to cluster as cluster username and/or password are missing or empty.");
            }

            BasicAuthCredential clusterCreds = new BasicAuthCredential()
            {
                Server = new Uri(cluster.ConnectionUrl),
                UserName = cluster.HttpUserName,
                Password = cluster.HttpPassword
            };

            return clusterCreds;
        }

        private static WindowsAzureStorageAccountCredentials GetClusterStorageCredentials(ClusterDetails cluster)
        {
            if (string.IsNullOrEmpty(cluster.DefaultStorageAccount.Name))
            {
                throw new InvalidOperationException("Could not obtain default storage account for the cluster.");
            }

            if (string.IsNullOrEmpty(cluster.DefaultStorageAccount.Key))
            {
                throw new InvalidOperationException("Could not obtain credentials for default storage account of the cluster.");
            }

            if (string.IsNullOrEmpty(cluster.DefaultStorageAccount.Container))
            {
                throw new InvalidOperationException("Could not obtain information about default container of the cluster");
            }

            return new WindowsAzureStorageAccountCredentials()
            {
                Name = cluster.DefaultStorageAccount.Name,
                Key = cluster.DefaultStorageAccount.Key,
                ContainerName = cluster.DefaultStorageAccount.Container
            };
        }

        private static void VerifyApplicationHistorySupport(ClusterDetails cluster)
        {
            // Verify cluster type
            if (cluster.ClusterType != ClusterType.Hadoop)
            {
                throw new NotSupportedException(string.Format(CultureInfo.InvariantCulture, @"Cannot get application history for clusters of type '{0}'. This functionality is supported for Hadoop clusters only", cluster.ClusterType));
            }

            // Verify cluster version
            string minSupportedVersion = "3.1.1.374";
            Version clusterVersion = new Version(cluster.Version);
            if (clusterVersion.CompareTo(new Version(minSupportedVersion)) < 0)
            {
                throw new NotSupportedException(
                    string.Format(CultureInfo.InvariantCulture, 
                    "Cannot get application history for cluster with version '{0}'. This functionality is supported for clusters with versions {1} and above", 
                    cluster.Version, 
                    minSupportedVersion));
            }
        }

        private static void WaitForJobCompletion(IJobSubmissionClient client, JobCreationResults jobResults)
        {
            JobDetails jobInProgress = client.GetJob(jobResults.JobId);
            while (jobInProgress.StatusCode != JobStatusCode.Completed && jobInProgress.StatusCode != JobStatusCode.Failed)
            {
                jobInProgress = client.GetJob(jobInProgress.JobId);
                Thread.Sleep(TimeSpan.FromSeconds(10));
            }
        }
    }
}