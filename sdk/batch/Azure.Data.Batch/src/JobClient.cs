// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.Data.Batch.Models;

namespace Azure.Data.Batch
{
    public partial class JobClient : BaseClient
    {
        public virtual Response<Job> GetJob(string jobId)
        {
            return HandleGet(jobId, GetJob, Job.DeserializeJob);
        }

        public virtual async System.Threading.Tasks.Task<Response<Job>> GetJobAsync(string jobId)
        {
            return await HandleGetAsync(jobId, GetJobAsync, Job.DeserializeJob).ConfigureAwait(false);
        }

        private static Response<Job> GetResponse(Response response)
        {
            JsonDocument json = JsonDocument.Parse(response.Content);
            Job job = Job.DeserializeJob(json.RootElement);
            return Response.FromValue(job, response);
        }

        public virtual Response<JobHeaders> AddJob(Job job)
        {
            return HandleAdd<JobHeaders>(job, Add);
        }

        public virtual async System.Threading.Tasks.Task<Response<JobHeaders>> AddJobAsync(Job job)
        {
            return await HandleAddAsync<JobHeaders>(job, AddAsync).ConfigureAwait(false);
        }

        public virtual Response<JobHeaders> UpdateJob(Job job)
        {
            return HandleUpdate<JobHeaders>(job.Id, job, Update);
        }

        public virtual async System.Threading.Tasks.Task<Response<JobHeaders>> UpdateJobAsync(Job job)
        {
            return await HandleUpdateAsync<JobHeaders>(job.Id, job, UpdateAsync).ConfigureAwait(false);
        }

        public virtual Response<JobHeaders> PatchJob(string jobId, JobUpdate updateContents)
        {
            return HandlePatch<JobHeaders>(jobId, updateContents, Patch);
        }

        public virtual async System.Threading.Tasks.Task<Response<JobHeaders>> PatchJobAsync(string jobId, JobUpdate updateContents)
        {
            return await HandlePatchAsync<JobHeaders>(jobId, updateContents, PatchAsync).ConfigureAwait(false);
        }

        public virtual Response<JobHeaders> DeleteJob(string jobId)
        {
            return HandleDelete<JobHeaders>(jobId, Delete);
        }

        public virtual async System.Threading.Tasks.Task<Response<JobHeaders>> DeleteJobAsync(string jobId)
        {
            return await HandleDeleteAsync<JobHeaders>(jobId, DeleteAsync).ConfigureAwait(false);
        }
    }
}
