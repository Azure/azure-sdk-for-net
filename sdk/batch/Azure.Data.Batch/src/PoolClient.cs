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
    public partial class PoolClient : BaseClient
    {
        public virtual Response<Pool> GetPool(string poolId)
        {
            return HandleGet(poolId, GetPool, Pool.DeserializePool);
        }

        public virtual async System.Threading.Tasks.Task<Response<Pool>> GetPoolAsync(string poolId)
        {
            return await HandleGetAsync(poolId, GetPoolAsync, Pool.DeserializePool).ConfigureAwait(false);
        }

        private static Response<Pool> GetResponse(Response response)
        {
            JsonDocument json = JsonDocument.Parse(response.Content);
            Pool pool = Pool.DeserializePool(json.RootElement);
            return Response.FromValue(pool, response);
        }

        public virtual Response<PoolHeaders> AddPool(Pool pool)
        {
            return HandleAdd<PoolHeaders>(pool, Add);
        }

        public virtual async System.Threading.Tasks.Task<Response<PoolHeaders>> AddPoolAsync(Pool pool)
        {
            return await HandleAddAsync<PoolHeaders>(pool, AddAsync).ConfigureAwait(false);
        }

        public virtual Response<PoolHeaders> PatchPool(string poolId, PoolUpdate updateContents)
        {
            return HandlePatch<PoolHeaders>(poolId, updateContents, Patch);
        }

        public virtual async System.Threading.Tasks.Task<Response<PoolHeaders>> PatchPoolAsync(string poolId, PoolUpdate updateContents)
        {
            return await HandlePatchAsync<PoolHeaders>(poolId, updateContents, PatchAsync).ConfigureAwait(false);
        }

        public virtual Response<PoolHeaders> DeletePool(string poolId)
        {
            return HandleDelete<PoolHeaders>(poolId, Delete);
        }

        public virtual async System.Threading.Tasks.Task<Response<PoolHeaders>> DeletePoolAsync(string poolId)
        {
            return await HandleDeleteAsync<PoolHeaders>(poolId, DeleteAsync).ConfigureAwait(false);
        }
    }
}
