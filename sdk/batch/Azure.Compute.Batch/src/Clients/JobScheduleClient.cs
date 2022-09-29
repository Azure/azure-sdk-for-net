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

        public virtual Response Add(JobSchedule jobSchedule)
        {
            return HandleAdd(jobSchedule, jobScheduleRest.Add);
        }

        public virtual async System.Threading.Tasks.Task<Response> AddAsync(JobSchedule jobSchedule)
        {
            return await HandleAddAsync(jobSchedule, jobScheduleRest.AddAsync).ConfigureAwait(false);
        }

        public virtual Response Update(JobSchedule jobSchedule)
        {
            return HandleUpdate(jobSchedule.Id, jobSchedule, jobScheduleRest.Update);
        }

        public virtual async System.Threading.Tasks.Task<Response> UpdateAsync(JobSchedule jobSchedule)
        {
            return await HandleUpdateAsync(jobSchedule.Id, jobSchedule, jobScheduleRest.UpdateAsync).ConfigureAwait(false);
        }

        public virtual Response Patch(string jobScheduleId, JobScheduleUpdate updateContents)
        {
            return HandlePatch(jobScheduleId, updateContents, jobScheduleRest.Patch);
        }

        public virtual async System.Threading.Tasks.Task<Response> PatchAsync(string jobScheduleId, JobScheduleUpdate updateContents)
        {
            return await HandlePatchAsync(jobScheduleId, updateContents, jobScheduleRest.PatchAsync).ConfigureAwait(false);
        }

        public virtual Response Delete(string jobScheduleId)
        {
            return HandleDelete(jobScheduleId, jobScheduleRest.Delete);
        }

        public virtual async System.Threading.Tasks.Task<Response> DeleteAsync(string jobScheduleId)
        {
            return await HandleDeleteAsync(jobScheduleId, jobScheduleRest.DeleteAsync).ConfigureAwait(false);
        }
    }
}
