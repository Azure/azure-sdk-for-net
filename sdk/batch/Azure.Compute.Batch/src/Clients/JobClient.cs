// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;
using Azure.Compute.Batch.Models;

namespace Azure.Compute.Batch
{
    public class JobClient : SubClient
    {
        private JobRest jobRest;

        protected JobClient() { }

        internal JobClient(BatchServiceClient serviceClient)
        {
            jobRest = serviceClient.batchRest.GetJobRestClient(serviceClient.BatchUrl.AbsoluteUri);
        }

        [ForwardsClientCalls]
        public virtual Response<Job> Get(string jobId, GetOptions options = null)
        {
            return HandleGet(jobId, options, jobRest.GetJob, Job.DeserializeJob);
        }

        [ForwardsClientCalls]
        public virtual async System.Threading.Tasks.Task<Response<Job>> GetAsync(string jobId, GetOptions options = null)
        {
            return await HandleGetAsync(jobId, options, jobRest.GetJobAsync, Job.DeserializeJob).ConfigureAwait(false);
        }

        [ForwardsClientCalls]
        public virtual Response<JobHeaders> Add(Job job)
        {
            return HandleAdd<JobHeaders>(job, jobRest.Add);
        }

        [ForwardsClientCalls]
        public virtual async System.Threading.Tasks.Task<Response<JobHeaders>> AddAsync(Job job)
        {
            return await HandleAddAsync<JobHeaders>(job, jobRest.AddAsync).ConfigureAwait(false);
        }

        [ForwardsClientCalls]
        public virtual Response<JobHeaders> Update(Job job)
        {
            return HandleUpdate<JobHeaders>(job.Id, job, jobRest.Update);
        }

        [ForwardsClientCalls]
        public virtual async System.Threading.Tasks.Task<Response<JobHeaders>> UpdateAsync(Job job)
        {
            return await HandleUpdateAsync<JobHeaders>(job.Id, job, jobRest.UpdateAsync).ConfigureAwait(false);
        }

        [ForwardsClientCalls]
        public virtual Response<JobHeaders> Patch(string jobId, JobUpdate updateContents)
        {
            return HandlePatch<JobHeaders>(jobId, updateContents, jobRest.Patch);
        }

        [ForwardsClientCalls]
        public virtual async System.Threading.Tasks.Task<Response<JobHeaders>> PatchAsync(string jobId, JobUpdate updateContents)
        {
            return await HandlePatchAsync<JobHeaders>(jobId, updateContents, jobRest.PatchAsync).ConfigureAwait(false);
        }

        [ForwardsClientCalls]
        public virtual Response<JobHeaders> Delete(string jobId)
        {
            return HandleDelete<JobHeaders>(jobId, jobRest.Delete);
        }

        [ForwardsClientCalls]
        public virtual async System.Threading.Tasks.Task<Response<JobHeaders>> DeleteAsync(string jobId)
        {
            return await HandleDeleteAsync<JobHeaders>(jobId, jobRest.DeleteAsync).ConfigureAwait(false);
        }

        [ForwardsClientCalls]
        public virtual Pageable<Job> List(ListOptions options = null)
        {
            return HandleList(options, jobRest.GetJobs, Job.DeserializeJob);
        }
    }
}
