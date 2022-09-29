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
    public class PoolClient : SubClient
    {
        private PoolRest poolRest;

        protected PoolClient() { }

        internal PoolClient(BatchServiceClient serviceClient)
        {
            poolRest = serviceClient.batchRest.GetPoolRestClient(serviceClient.BatchUrl.AbsoluteUri);
        }

        public virtual Response<Pool> Get(string poolId, GetOptions options = null)
        {
            return HandleGet(poolId, options, poolRest.GetPool, Pool.DeserializePool);
        }

        public virtual async System.Threading.Tasks.Task<Response<Pool>> GetAsync(string poolId, GetOptions options = null)
        {
            return await HandleGetAsync(poolId, options, poolRest.GetPoolAsync, Pool.DeserializePool).ConfigureAwait(false);
        }

        public virtual Response Add(Pool pool)
        {
            return HandleAdd(pool, poolRest.Add);
        }

        public virtual async System.Threading.Tasks.Task<Response> AddAsync(Pool pool)
        {
            return await HandleAddAsync(pool, poolRest.AddAsync).ConfigureAwait(false);
        }

        public virtual Response Patch(string poolId, PoolUpdate updateContents)
        {
            return HandlePatch(poolId, updateContents, poolRest.Patch);
        }

        public virtual async System.Threading.Tasks.Task<Response> PatchAsync(string poolId, PoolUpdate updateContents)
        {
            return await HandlePatchAsync(poolId, updateContents, poolRest.PatchAsync).ConfigureAwait(false);
        }

        public virtual Response Delete(string poolId)
        {
            return HandleDelete(poolId, poolRest.Delete);
        }

        public virtual async System.Threading.Tasks.Task<Response> DeleteAsync(string poolId)
        {
            return await HandleDeleteAsync(poolId, poolRest.DeleteAsync).ConfigureAwait(false);
        }
    }
}
