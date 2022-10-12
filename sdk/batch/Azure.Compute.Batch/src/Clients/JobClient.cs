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

        [ForwardsClientCalls(true)]
        public virtual Response<Job> Get(string jobId, GetOptions options = null)
        {
            return HandleGet(jobId, options, jobRest.GetJob, Job.DeserializeJob);
        }

        [ForwardsClientCalls(true)]
        public virtual async System.Threading.Tasks.Task<Response<Job>> GetAsync(string jobId, GetOptions options = null)
        {
            return await HandleGetAsync(jobId, options, jobRest.GetJobAsync, Job.DeserializeJob).ConfigureAwait(false);
        }

        [ForwardsClientCalls(true)]
        public virtual Response Add(Job job)
        {
            return HandleAdd(job, jobRest.Add);
        }

        [ForwardsClientCalls(true)]
        public virtual async System.Threading.Tasks.Task<Response> AddAsync(Job job)
        {
            return await HandleAddAsync(job, jobRest.AddAsync).ConfigureAwait(false);
        }

        [ForwardsClientCalls(true)]
        public virtual Response Update(Job job)
        {
            return HandleUpdate(job.Id, job, jobRest.Update);
        }

        [ForwardsClientCalls(true)]
        public virtual async System.Threading.Tasks.Task<Response> UpdateAsync(Job job)
        {
            return await HandleUpdateAsync(job.Id, job, jobRest.UpdateAsync).ConfigureAwait(false);
        }

        [ForwardsClientCalls(true)]
        public virtual Response Patch(string jobId, JobUpdate updateContents)
        {
            return HandlePatch(jobId, updateContents, jobRest.Patch);
        }

        [ForwardsClientCalls(true)]
        public virtual async System.Threading.Tasks.Task<Response> PatchAsync(string jobId, JobUpdate updateContents)
        {
            return await HandlePatchAsync(jobId, updateContents, jobRest.PatchAsync).ConfigureAwait(false);
        }

        [ForwardsClientCalls(true)]
        public virtual Response Delete(string jobId, BaseOptions options = null)
        {
            return HandleDelete(jobId, options, jobRest.Delete);
        }

        [ForwardsClientCalls(true)]
        public virtual async System.Threading.Tasks.Task<Response> DeleteAsync(string jobId, BaseOptions options = null)
        {
            return await HandleDeleteAsync(jobId, options, jobRest.DeleteAsync).ConfigureAwait(false);
        }

        [ForwardsClientCalls(true)]
        public virtual Pageable<Job> List(ListOptions options = null)
        {
            return HandleList(options, jobRest.GetJobs, Job.DeserializeJob);
        }
    }
}
