// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Files.DataLake.Models;

namespace Azure.Storage.Files.DataLake
{
    // CUSTOM:
    // Add convenience method for SetAccessControlRecursive.
    internal partial class PathRestClient
    {
        public virtual Response<SetAccessControlRecursiveResponse> SetAccessControlRecursive(
            string mode,
            string continuation = default,
            bool? forceFlag = default,
            int? maxRecords = default,
            string acl = default,
            int? timeout = default,
            CancellationToken cancellationToken = default)
        {
            Response result = SetAccessControlRecursive(mode, continuation, forceFlag, maxRecords, acl, timeout, cancellationToken.ToRequestContext());
            return Response.FromValue((SetAccessControlRecursiveResponse)result, result);
        }

        public virtual async Task<Response<SetAccessControlRecursiveResponse>> SetAccessControlRecursiveAsync(
            string mode,
            string continuation = default,
            bool? forceFlag = default,
            int? maxRecords = default,
            string acl = default,
            int? timeout = default,
            CancellationToken cancellationToken = default)
        {
            Response result = await SetAccessControlRecursiveAsync(mode, continuation, forceFlag, maxRecords, acl, timeout, cancellationToken.ToRequestContext()).ConfigureAwait(false);
            return Response.FromValue((SetAccessControlRecursiveResponse)result, result);
        }
    }
}
