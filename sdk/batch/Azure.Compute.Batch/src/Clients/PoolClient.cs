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

        [ForwardsClientCalls(true)]
        public virtual Response<Pool> Get(string poolId, GetOptions options = null)
        {
            return HandleGet(poolId, options, poolRest.GetPool, Pool.DeserializePool);
        }

        [ForwardsClientCalls(true)]
        public virtual async System.Threading.Tasks.Task<Response<Pool>> GetAsync(string poolId, GetOptions options = null)
        {
            return await HandleGetAsync(poolId, options, poolRest.GetPoolAsync, Pool.DeserializePool).ConfigureAwait(false);
        }

        [ForwardsClientCalls(true)]
        public virtual Response Add(Pool pool)
        {
            return HandleAdd(pool, poolRest.Add);
        }

        [ForwardsClientCalls(true)]
        public virtual async System.Threading.Tasks.Task<Response> AddAsync(Pool pool)
        {
            return await HandleAddAsync(pool, poolRest.AddAsync).ConfigureAwait(false);
        }

        [ForwardsClientCalls(true)]
        public virtual Response Patch(string poolId, PoolUpdate updateContents)
        {
            return HandlePatch(poolId, updateContents, poolRest.Patch);
        }

        [ForwardsClientCalls(true)]
        public virtual async System.Threading.Tasks.Task<Response> PatchAsync(string poolId, PoolUpdate updateContents)
        {
            return await HandlePatchAsync(poolId, updateContents, poolRest.PatchAsync).ConfigureAwait(false);
        }

        [ForwardsClientCalls(true)]
        public virtual Response Delete(string poolId, BaseOptions options = null)
        {
            return HandleDelete(poolId, options, poolRest.Delete);
        }

        [ForwardsClientCalls(true)]
        public virtual async System.Threading.Tasks.Task<Response> DeleteAsync(string poolId, BaseOptions options = null)
        {
            return await HandleDeleteAsync(poolId, options, poolRest.DeleteAsync).ConfigureAwait(false);
        }

        [ForwardsClientCalls(true)]
        public virtual Response<bool> Exists(string poolId, BaseOptions options = null)
        {
            return HandleExists(poolId, options, poolRest.Exists);
        }

        [ForwardsClientCalls(true)]
        public virtual async System.Threading.Tasks.Task<Response<bool>> ExistsAsync(string poolId, BaseOptions options = null)
        {
            return await HandleExistsAsync(poolId, options, poolRest.ExistsAsync).ConfigureAwait(false);
        }
    }
}
