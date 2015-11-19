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
namespace Microsoft.WindowsAzure.Management.HDInsight.JobSubmission.PocoClient
{
    using System.Threading.Tasks;
    using Microsoft.Hadoop.Client;
    using Microsoft.Hadoop.Client.HadoopJobSubmissionPocoClient.RemoteHadoop;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;
    using Microsoft.WindowsAzure.Management.HDInsight;

    /// <summary>
    /// The PocoClient for submitting jobs to an HDInsight server.
    /// </summary>
    internal class HDInsightJobSubmissionPocoClient : IHDInsightJobSubmissionPocoClient
    {
        private readonly BasicAuthCredential remoteCreds;
        private IAbstractionContext context;
        private readonly bool ignoreSslErrors;
        private readonly string userAgentString;

        internal HDInsightJobSubmissionPocoClient(BasicAuthCredential credentials, IAbstractionContext context, bool ignoreSslErrors, string userAgentString)
        {
            this.remoteCreds = credentials;
            this.context = context;
            this.ignoreSslErrors = ignoreSslErrors;
            this.userAgentString = userAgentString ?? string.Empty;
        }

        /// <inheritdoc />
        public async Task<JobCreationResults> SubmitHiveJob(HiveJobCreateParameters details)
        {
            var remoteClient = ServiceLocator.Instance.Locate<IRemoteHadoopJobSubmissionPocoClientFactory>().Create(this.remoteCreds, this.context, this.ignoreSslErrors, this.GetUserAgentString());
            return await remoteClient.SubmitHiveJob(details);
        }

        /// <inheritdoc />
        public async Task<JobCreationResults> SubmitMapReduceJob(MapReduceJobCreateParameters details)
        {
            var remoteClient = ServiceLocator.Instance.Locate<IRemoteHadoopJobSubmissionPocoClientFactory>().Create(this.remoteCreds, this.context, this.ignoreSslErrors, this.GetUserAgentString());
            return await remoteClient.SubmitMapReduceJob(details);
        }

        public string GetUserAgentString()
        {
            return this.userAgentString;
        }

        /// <inheritdoc />
        public async Task<JobList> ListJobs()
        {
            var remoteClient = ServiceLocator.Instance.Locate<IRemoteHadoopJobSubmissionPocoClientFactory>().Create(this.remoteCreds, this.context, this.ignoreSslErrors, this.GetUserAgentString());
            return await remoteClient.ListJobs();
        }

        /// <inheritdoc />
        public async Task<JobDetails> GetJob(string jobId)
        {
            var remoteClient = ServiceLocator.Instance.Locate<IRemoteHadoopJobSubmissionPocoClientFactory>().Create(this.remoteCreds, this.context, this.ignoreSslErrors, this.GetUserAgentString());
            return await remoteClient.GetJob(jobId);
        }

        /// <inheritdoc />
        public async Task<JobCreationResults> SubmitPigJob(PigJobCreateParameters pigJobCreateParameters)
        {
            var remoteClient = ServiceLocator.Instance.Locate<IRemoteHadoopJobSubmissionPocoClientFactory>().Create(this.remoteCreds, this.context, this.ignoreSslErrors, this.GetUserAgentString());
            return await remoteClient.SubmitPigJob(pigJobCreateParameters);
        }

        /// <inheritdoc />
        public async Task<JobCreationResults> SubmitSqoopJob(SqoopJobCreateParameters sqoopJobCreateParameters)
        {
            var remoteClient = ServiceLocator.Instance.Locate<IRemoteHadoopJobSubmissionPocoClientFactory>().Create(this.remoteCreds, this.context, this.ignoreSslErrors, this.GetUserAgentString());
            return await remoteClient.SubmitSqoopJob(sqoopJobCreateParameters);
        }

        /// <inheritdoc />
        public async Task<JobCreationResults> SubmitStreamingJob(StreamingMapReduceJobCreateParameters pigJobCreateParameters)
        {
            var remoteClient = ServiceLocator.Instance.Locate<IRemoteHadoopJobSubmissionPocoClientFactory>().Create(this.remoteCreds, this.context, this.ignoreSslErrors, this.GetUserAgentString());
            return await remoteClient.SubmitStreamingJob(pigJobCreateParameters);
        }

        /// <inheritdoc />
        public async Task<JobDetails> StopJob(string jobId)
        {
            var remoteClient = ServiceLocator.Instance.Locate<IRemoteHadoopJobSubmissionPocoClientFactory>().Create(this.remoteCreds, this.context, this.ignoreSslErrors, this.GetUserAgentString());
            return await remoteClient.StopJob(jobId);
        }
    }
}
