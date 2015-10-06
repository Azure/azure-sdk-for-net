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
namespace Microsoft.WindowsAzure.Management.HDInsight.TestUtilities.RestSimulator
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Hadoop.Client;
    using Microsoft.Hadoop.Client.HadoopJobSubmissionPocoClient;
    using Microsoft.Hadoop.Client.Storage;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;
    using Microsoft.WindowsAzure.Management.HDInsight.Logging;

    internal class HadoopJobSubmissionPocoSimulatorClient : IHadoopJobSubmissionPocoClient
    {
        internal const string JobSuccesful = "jobDetails succeeded";
        internal const string JobFailed = "jobDetails failed";
        internal BasicAuthCredential credentials;
        private readonly HDInsightManagementRestSimulatorClient.SimulatorClusterContainer cluster;
        internal IAbstractionContext context;
        private string userAgentString = null;

        public HadoopJobSubmissionPocoSimulatorClient(BasicAuthCredential connectionCredentials, IAbstractionContext context, string userAgentString)
        {
            this.credentials = connectionCredentials;
            var server = connectionCredentials.Server.Host.Split('.')[0];
            this.cluster = HDInsightManagementRestSimulatorClient.GetCloudServiceInternal(server);
            this.context = context;
            this.userAgentString = userAgentString;
            this.InitializeSimulator();
        }

        private void InitializeSimulator()
        {
            var piJob =
                this.SubmitMapReduceJob(
                    new MapReduceJobCreateParameters()
                    {
                        ClassName = "pi",
                        JarFile = Constants.WabsProtocolSchemeName + "containerName@hostname/jarfileName",
                        JobName = "pi estimation jobDetails",
                        StatusFolder = "/pioutput"
                    }).WaitForResult();

            var hiveJob =
                this.SubmitHiveJob(
                    new HiveJobCreateParameters() { JobName = "show tables jobDetails", Query = "show tables", StatusFolder = "/hiveoutput" })
                    .WaitForResult();

            var pigJob =
                this.SubmitPigJob(
                    new PigJobCreateParameters() { Query = "show tables", StatusFolder = "/pigoutput" })
                    .WaitForResult();

            this.WriteJobOutput("/pioutput", JobSuccesful);
            this.WriteJobOutput("/hiveoutput", "hivesampletable");
            this.WriteJobOutput("/pigoutput", JobSuccesful);

            this.WriteJobError("/pioutput", JobSuccesful);
            this.WriteJobError("/hiveoutput", JobSuccesful);
            this.WriteJobError("/pigoutput", JobSuccesful);

            this.WriteJobLogSummary("/pioutput", piJob.JobId);
            this.WriteJobLogSummary("/hiveoutput", hiveJob.JobId);
            this.WriteJobLogSummary("/pigoutput", pigJob.JobId);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Needed for tests.")]
        private Stream GetStream(string content)
        {
            var stream = new MemoryStream();
            var bytes = Encoding.UTF8.GetBytes(content);
            stream.Write(bytes, 0, bytes.Length);
            stream.Seek(0, SeekOrigin.Begin);
            return stream;
        }

        private Uri GetStatusPath(string rootPath, string fileName)
        {
            if (!rootPath.StartsWith("/"))
            {
                rootPath = "user/" + this.credentials.UserName + "/" + rootPath;
            }

            var storageAccount = this.cluster.Cluster.DefaultStorageAccount;
            return new Uri(string.Format(CultureInfo.InvariantCulture, "{0}{1}@{2}/{3}/{4}", Constants.WabsProtocolSchemeName, storageAccount.Container, storageAccount.Name, rootPath.TrimStart('/'), fileName.TrimStart('/')));
        }

        public string GetUserAgentString()
        {
            return userAgentString;
        }

        public Task<JobList> ListJobs()
        {
            this.LogMessage("Listing jobs");
            var jobDetailList = new JobList();
            var changedJobs = new List<JobDetails>();
            lock (this.cluster.JobQueue)
            {
                foreach (var jobHistoryItem in this.cluster.JobQueue.Values)
                {
                    var changedJob = this.ChangeJobState(jobHistoryItem);
                    jobDetailList.Jobs.Add(changedJob);
                    changedJobs.Add(changedJob);
                }

                foreach (var changedJob in changedJobs)
                {
                    this.cluster.JobQueue[changedJob.JobId] = changedJob;
                }
            }

            return Task.FromResult(jobDetailList);
        }

        public Task<JobDetails> GetJob(string jobId)
        {
            this.LogMessage("Getting jobDetails '{0}'.", jobId);
            lock (this.cluster.JobQueue)
            {
                if (this.cluster.JobQueue.ContainsKey(jobId))
                {
                    var jobHistory = this.ListJobs().WaitForResult();
                    var jobHistoryItem = jobHistory.Jobs.FirstOrDefault(job => job.JobId == jobId);
                    if (jobHistoryItem != null)
                    {
                        if (jobHistoryItem.Name.IsNotNull() && jobHistoryItem.Name.IndexOf("timeout", StringComparison.OrdinalIgnoreCase) > -1)
                        {
                            Thread.Sleep(50);
                        }
                        return Task.FromResult(jobHistoryItem);
                    }
                }

            }

            return Task.FromResult<JobDetails>(null);
        }

        public Task<JobCreationResults> SubmitMapReduceJob(MapReduceJobCreateParameters mapReduceJob)
        {
            if (mapReduceJob.JobName == "1456577")
            {
                throw new HttpLayerException(HttpStatusCode.BadRequest, "{ \"error\": \"File /example/files/WordCount.jar does not exist.\"}");
            }

            mapReduceJob.JarFile.ArgumentNotNullOrEmpty("JarFile");
            mapReduceJob.ClassName.ArgumentNotNullOrEmpty("ClassName");
            return Task.FromResult(this.CreateJobSuccessResult(mapReduceJob, mapReduceJob.JobName));
        }

        public Task<JobCreationResults> SubmitHiveJob(HiveJobCreateParameters hiveJob)
        {
            if (hiveJob.Query.IsNullOrEmpty())
            {
                hiveJob.File.ArgumentNotNullOrEmpty("File");
                if (hiveJob.File.Contains("://") && !hiveJob.File.StartsWith(Constants.WabsProtocol, StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException("Invalid file protocol : " + hiveJob.File);
                }
            }

            var retval = this.CreateJobSuccessResult(new JobDetails()
            {
                Name = hiveJob.JobName,
                Query = hiveJob.Query,
                StatusDirectory = hiveJob.StatusFolder
            },
            hiveJob.JobName);
            return Task.FromResult(retval);
        }

        public Task<JobCreationResults> SubmitPigJob(PigJobCreateParameters pigJobCreateParameters)
        {
            if (pigJobCreateParameters == null)
            {
                throw new ArgumentNullException("pigJobCreateParameters");
            }

            var retval = this.CreateJobSuccessResult(new JobDetails()
            {
                Query = pigJobCreateParameters.Query,
                StatusDirectory = pigJobCreateParameters.StatusFolder
            },
            string.Empty);
            return Task.FromResult(retval);
        }

        public Task<JobCreationResults> SubmitSqoopJob(SqoopJobCreateParameters sqoopJobCreateParameters)
        {
            if (sqoopJobCreateParameters == null)
            {
                throw new ArgumentNullException("sqoopJobCreateParameters");
            }

            var retval = this.CreateJobSuccessResult(new JobDetails()
            {
                Query = sqoopJobCreateParameters.Command,
                StatusDirectory = sqoopJobCreateParameters.StatusFolder
            },
            string.Empty);
            return Task.FromResult(retval);
        }

        public Task<JobCreationResults> SubmitStreamingJob(StreamingMapReduceJobCreateParameters streamingMapReduceJobCreateParameters)
        {
            if (streamingMapReduceJobCreateParameters == null)
            {
                throw new ArgumentNullException("streamingMapReduceJobCreateParameters");
            }

            return Task.FromResult(this.CreateJobSuccessResult(streamingMapReduceJobCreateParameters, streamingMapReduceJobCreateParameters.JobName));
        }

        public async Task<JobDetails> StopJob(string jobId)
        {
            var jobToStop = await this.GetJob(jobId);
            lock (this.cluster.JobDeletionQueue)
            {
                this.cluster.JobDeletionQueue.Add(jobId, DateTime.Now.AddSeconds(0.5));
            }

            return jobToStop;
        }

        private JobDetails ChangeJobState(JobDetails jobDetailsHistoryItem)
        {
            if (jobDetailsHistoryItem.StatusCode == JobStatusCode.Unknown)
            {
                jobDetailsHistoryItem.StatusCode = JobStatusCode.Initializing;
            }
            else
            {
                switch (jobDetailsHistoryItem.StatusCode)
                {
                    case JobStatusCode.Initializing:
                        jobDetailsHistoryItem.StatusCode = JobStatusCode.Running;
                        jobDetailsHistoryItem.PercentComplete = "map 5% reduce 0%";
                        break;
                    case JobStatusCode.Running:
                        jobDetailsHistoryItem.StatusCode = JobStatusCode.Completed;
                        jobDetailsHistoryItem.PercentComplete = "map 100% reduce 100%";
                        jobDetailsHistoryItem.ExitCode = 0;
                        if ((jobDetailsHistoryItem.Name.IsNotNullOrEmpty() && string.Equals(jobDetailsHistoryItem.Name, "show tables", StringComparison.OrdinalIgnoreCase)) ||
                            string.Equals(jobDetailsHistoryItem.Query, "show tables", StringComparison.OrdinalIgnoreCase))
                        {
                            this.WriteJobOutput(jobDetailsHistoryItem.StatusDirectory, "hivesampletable");
                            this.WriteJobError(jobDetailsHistoryItem.StatusDirectory, JobSuccesful);
                        }
                        else if (jobDetailsHistoryItem.Name.IsNotNullOrEmpty() && string.Equals(jobDetailsHistoryItem.Name, "pi estimation job", StringComparison.OrdinalIgnoreCase))
                        {
                            this.WriteJobOutput(jobDetailsHistoryItem.StatusDirectory, "3.142");
                            this.WriteJobError(jobDetailsHistoryItem.StatusDirectory, JobSuccesful);
                        }
                        else
                        {
                            this.WriteJobOutput(jobDetailsHistoryItem.StatusDirectory, JobSuccesful);
                            this.WriteJobError(jobDetailsHistoryItem.StatusDirectory, JobSuccesful);
                        }

                        this.WriteJobLogSummary(jobDetailsHistoryItem.StatusDirectory, jobDetailsHistoryItem.JobId);
                        break;
                }
            }

            var jobDeletionTime = this.cluster.JobDeletionQueue.FirstOrDefault(deletedJob => deletedJob.Key == jobDetailsHistoryItem.JobId);
            if (jobDeletionTime.Value != DateTime.MinValue && jobDeletionTime.Value != DateTime.MaxValue && jobDeletionTime.Value <= DateTime.Now)
            {
                jobDetailsHistoryItem.StatusCode = JobStatusCode.Canceled;
            }
            else
            {
                if (this.ShouldFail(jobDetailsHistoryItem))
                {
                    if (jobDetailsHistoryItem.StatusCode == JobStatusCode.Running)
                    {
                        jobDetailsHistoryItem.StatusCode = JobStatusCode.Failed;
                        jobDetailsHistoryItem.ExitCode = 4000;
                        this.WriteJobOutput(jobDetailsHistoryItem.StatusDirectory, JobFailed);
                        this.WriteJobError(jobDetailsHistoryItem.StatusDirectory, JobFailed);
                    }
                }
                else if (jobDetailsHistoryItem.Name.IsNotNullOrEmpty() && jobDetailsHistoryItem.Name.Contains("Unknown"))
                {
                    if (jobDetailsHistoryItem.StatusCode == JobStatusCode.Running)
                    {
                        jobDetailsHistoryItem.StatusCode = JobStatusCode.Unknown;
                    }
                }
            }

            return jobDetailsHistoryItem;
        }

        private bool ShouldFail(JobDetails jobDetailsHistoryItem)
        {
            if (jobDetailsHistoryItem.Name.IsNotNullOrEmpty() && jobDetailsHistoryItem.Name.Contains("Fail"))
            {
                return true;
            }

            return jobDetailsHistoryItem.Query.IsNotNullOrEmpty() && jobDetailsHistoryItem.Query.Contains("Fail");
        }

        private void WriteJobLogSummary(string statusDirectory, string jobId)
        {
            this.WriteJobResultFile(statusDirectory, jobId, "logs/list.txt");
            this.WriteJobResultFile(statusDirectory, JobSuccesful, "logs/attempt_" + jobId);
        }

        private void WriteJobOutput(string statusDirectory, string stdoutContent)
        {
            this.WriteJobResultFile(statusDirectory, stdoutContent, "stdout");
        }

        private void WriteJobError(string statusDirectory, string stdErrContent)
        {
            this.WriteJobResultFile(statusDirectory, stdErrContent, "stderr");
        }

        private void WriteJobResultFile(string statusDirectory, string content, string fileName)
        {
            if (!string.IsNullOrEmpty(statusDirectory))
            {
                var storageCreds = new WindowsAzureStorageAccountCredentials()
                {
                    Name = Constants.WabsProtocolSchemeName + this.cluster.Cluster.DefaultStorageAccount.Name,
                    Key = this.cluster.Cluster.DefaultStorageAccount.Key
                };
                var storageHandler = ServiceLocator.Instance.Locate<IWabStorageAbstractionFactory>().Create(storageCreds);
                storageHandler.Write(this.GetStatusPath(statusDirectory, fileName), this.GetStream(content));
            }
        }

        private JobCreationResults CreateJobSuccessResult(JobCreateParameters details, string jobName)
        {
            return this.CreateJobSuccessResult(new JobDetails() { StatusDirectory = details.StatusFolder }, jobName);
        }

        private JobCreationResults CreateJobSuccessResult(JobDetails jobDetailsHistoryEntry, string jobName)
        {
            if (this.cluster.IsNull())
            {
                throw new InvalidOperationException("The cluster could not be found.");
            }
            if (this.credentials.UserName != this.cluster.Cluster.HttpUserName && this.credentials.Password != this.cluster.Cluster.HttpPassword)
            {
                throw new UnauthorizedAccessException("The supplied credential do not have access to the server.");
            }
            lock (this.cluster.JobQueue)
            {
                this.LogMessage("Starting jobDetails '{0}'.", jobName);
                var jobCreationResults = new JobCreationResults()
                {
                    JobId = "job_" + Guid.NewGuid().ToString(),
                    HttpStatusCode = HttpStatusCode.OK
                };

                jobDetailsHistoryEntry.Name = jobName;
                jobDetailsHistoryEntry.JobId = jobCreationResults.JobId;
                jobDetailsHistoryEntry.PercentComplete = "map 0% reduce 0%";
                this.cluster.JobQueue.Add(jobDetailsHistoryEntry.JobId, jobDetailsHistoryEntry);

                return jobCreationResults;
            }
        }

        private void LogMessage(string content, params string[] args)
        {
            string message = content;
            if (args.Any())
            {
                message = string.Format(CultureInfo.InvariantCulture, content, args);
            }

            ServiceLocator.Instance.Locate<ILogger>().LogMessage(message);
            if (this.context.Logger != null)
            {
                this.context.Logger.LogMessage(message, Severity.Informational, Verbosity.Diagnostic);
            }
        }
    }
}
