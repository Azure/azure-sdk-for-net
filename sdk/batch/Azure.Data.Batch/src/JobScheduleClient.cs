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
    public partial class JobScheduleClient : BaseClient
    {
        public virtual Response<JobSchedule> GetJobSchedule(string jobScheduleId)
        {
            return HandleGet(jobScheduleId, GetJobSchedule, JobSchedule.DeserializeJobSchedule);
        }

        public virtual async System.Threading.Tasks.Task<Response<JobSchedule>> GetJobScheduleAsync(string jobScheduleId)
        {
            return await HandleGetAsync(jobScheduleId, GetJobScheduleAsync, JobSchedule.DeserializeJobSchedule).ConfigureAwait(false);
        }

        private static Response<JobSchedule> GetResponse(Response response)
        {
            JsonDocument json = JsonDocument.Parse(response.Content);
            JobSchedule jobSchedule = JobSchedule.DeserializeJobSchedule(json.RootElement);
            return Response.FromValue(jobSchedule, response);
        }

        public virtual Response<JobScheduleHeaders> AddJobSchedule(JobSchedule jobSchedule)
        {
            return HandleAdd<JobScheduleHeaders>(jobSchedule, Add);
        }

        public virtual async System.Threading.Tasks.Task<Response<JobScheduleHeaders>> AddJobScheduleAsync(JobSchedule jobSchedule)
        {
            return await HandleAddAsync<JobScheduleHeaders>(jobSchedule, AddAsync).ConfigureAwait(false);
        }

        public virtual Response<JobScheduleHeaders> UpdateJobSchedule(JobSchedule jobSchedule)
        {
            return HandleUpdate<JobScheduleHeaders>(jobSchedule.Id, jobSchedule, Update);
        }

        public virtual async System.Threading.Tasks.Task<Response<JobScheduleHeaders>> UpdateJobScheduleAsync(JobSchedule jobSchedule)
        {
            return await HandleUpdateAsync<JobScheduleHeaders>(jobSchedule.Id, jobSchedule, UpdateAsync).ConfigureAwait(false);
        }

        public virtual Response<JobScheduleHeaders> PatchJobSchedule(string jobScheduleId, JobScheduleUpdate updateContents)
        {
            return HandlePatch<JobScheduleHeaders>(jobScheduleId, updateContents, Patch);
        }

        public virtual async System.Threading.Tasks.Task<Response<JobScheduleHeaders>> PatchJobScheduleAsync(string jobScheduleId, JobScheduleUpdate updateContents)
        {
            return await HandlePatchAsync<JobScheduleHeaders>(jobScheduleId, updateContents, PatchAsync).ConfigureAwait(false);
        }

        public virtual Response<JobScheduleHeaders> DeleteJobSchedule(string jobScheduleId)
        {
            return HandleDelete<JobScheduleHeaders>(jobScheduleId, Delete);
        }

        public virtual async System.Threading.Tasks.Task<Response<JobScheduleHeaders>> DeleteJobScheduleAsync(string jobScheduleId)
        {
            return await HandleDeleteAsync<JobScheduleHeaders>(jobScheduleId, DeleteAsync).ConfigureAwait(false);
        }
    }
}
