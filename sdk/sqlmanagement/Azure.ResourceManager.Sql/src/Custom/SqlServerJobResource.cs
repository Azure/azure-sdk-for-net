// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Sql
{
    public partial class SqlServerJobResource
    {
        /// <summary> Backward-compatible overload that accepts <see cref="int"/> for the job version. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<Response<SqlServerJobVersionResource>> GetSqlServerJobVersionAsync(int jobVersion, CancellationToken cancellationToken = default)
            => GetSqlServerJobVersionAsync(jobVersion.ToString(CultureInfo.InvariantCulture), cancellationToken);

        /// <summary> Backward-compatible overload that accepts <see cref="int"/> for the job version. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<SqlServerJobVersionResource> GetSqlServerJobVersion(int jobVersion, CancellationToken cancellationToken = default)
            => GetSqlServerJobVersion(jobVersion.ToString(CultureInfo.InvariantCulture), cancellationToken);

        /// <summary> Backward-compatible alias for <c>Create</c>. The return type has changed in 2.0.0. </summary>
        [Obsolete("This API has been retired in version 2.0.0. Use Create instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<SqlServerJobExecutionResource>> CreateJobExecutionAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("CreateJobExecution has been retired in version 2.0.0. Use Create(WaitUntil, CancellationToken) instead and wrap the returned data manually.");
        }

        /// <summary> Backward-compatible alias for <c>Create</c>. The return type has changed in 2.0.0. </summary>
        [Obsolete("This API has been retired in version 2.0.0. Use Create instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<SqlServerJobExecutionResource> CreateJobExecution(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("CreateJobExecution has been retired in version 2.0.0. Use Create(WaitUntil, CancellationToken) instead and wrap the returned data manually.");
        }
    }
}
