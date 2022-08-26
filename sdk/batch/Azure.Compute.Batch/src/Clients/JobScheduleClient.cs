// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.Compute.Batch.Models;

namespace Azure.Compute.Batch
{
    public class JobScheduleClient : SubClient
    {
        private JobScheduleRest jobScheduleRest;

        protected JobScheduleClient() { }

        internal JobScheduleClient(BatchServiceClient serviceClient)
        {
            jobScheduleRest = serviceClient.batchRest.GetJobScheduleRestClient(serviceClient.BatchUrl.AbsoluteUri);
        }

        public virtual Response<JobSchedule> Get(string jobScheduleId, GetOptions options = null)
        {
            return HandleGet(jobScheduleId, options, jobScheduleRest.GetJobSchedule, JobSchedule.DeserializeJobSchedule);
        }

        public virtual async System.Threading.Tasks.Task<Response<JobSchedule>> GetAsync(string jobScheduleId, GetOptions options = null)
        {
            return await HandleGetAsync(jobScheduleId, options, jobScheduleRest.GetJobScheduleAsync, JobSchedule.DeserializeJobSchedule).ConfigureAwait(false);
        }

        public virtual Response<JobScheduleHeaders> Add(JobSchedule jobSchedule)
        {
            return HandleAdd<JobScheduleHeaders>(jobSchedule, jobScheduleRest.Add);
        }

        public virtual async System.Threading.Tasks.Task<Response<JobScheduleHeaders>> AddAsync(JobSchedule jobSchedule)
        {
            return await HandleAddAsync<JobScheduleHeaders>(jobSchedule, jobScheduleRest.AddAsync).ConfigureAwait(false);
        }

        public virtual Response<JobScheduleHeaders> Update(JobSchedule jobSchedule)
        {
            return HandleUpdate<JobScheduleHeaders>(jobSchedule.Id, jobSchedule, jobScheduleRest.Update);
        }

        public virtual async System.Threading.Tasks.Task<Response<JobScheduleHeaders>> UpdateAsync(JobSchedule jobSchedule)
        {
            return await HandleUpdateAsync<JobScheduleHeaders>(jobSchedule.Id, jobSchedule, jobScheduleRest.UpdateAsync).ConfigureAwait(false);
        }

        public virtual Response<JobScheduleHeaders> Patch(string jobScheduleId, JobScheduleUpdate updateContents)
        {
            return HandlePatch<JobScheduleHeaders>(jobScheduleId, updateContents, jobScheduleRest.Patch);
        }

        public virtual async System.Threading.Tasks.Task<Response<JobScheduleHeaders>> PatchAsync(string jobScheduleId, JobScheduleUpdate updateContents)
        {
            return await HandlePatchAsync<JobScheduleHeaders>(jobScheduleId, updateContents, jobScheduleRest.PatchAsync).ConfigureAwait(false);
        }

        public virtual Response<JobScheduleHeaders> Delete(string jobScheduleId)
        {
            return HandleDelete<JobScheduleHeaders>(jobScheduleId, jobScheduleRest.Delete);
        }

        public virtual async System.Threading.Tasks.Task<Response<JobScheduleHeaders>> DeleteAsync(string jobScheduleId)
        {
            return await HandleDeleteAsync<JobScheduleHeaders>(jobScheduleId, jobScheduleRest.DeleteAsync).ConfigureAwait(false);
        }
    }
}
