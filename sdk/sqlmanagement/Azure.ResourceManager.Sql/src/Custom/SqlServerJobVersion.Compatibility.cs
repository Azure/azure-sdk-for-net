// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;

#pragma warning disable CS1591
#pragma warning disable SA1402
namespace Azure.ResourceManager.Sql
{
    public partial class SqlServerJobResource
    {
        [ForwardsClientCalls]
        public virtual Response<SqlServerJobVersionResource> GetSqlServerJobVersion(int jobVersion, CancellationToken cancellationToken = default)
            => GetSqlServerJobVersions().Get(jobVersion, cancellationToken);

        [ForwardsClientCalls]
        public virtual Task<Response<SqlServerJobVersionResource>> GetSqlServerJobVersionAsync(int jobVersion, CancellationToken cancellationToken = default)
            => GetSqlServerJobVersions().GetAsync(jobVersion, cancellationToken);
    }

    public partial class SqlServerJobVersionCollection
    {
        [ForwardsClientCalls]
        public virtual Response<bool> Exists(int jobVersion, CancellationToken cancellationToken = default)
            => Exists(jobVersion.ToString(CultureInfo.InvariantCulture), cancellationToken);

        [ForwardsClientCalls]
        public virtual Task<Response<bool>> ExistsAsync(int jobVersion, CancellationToken cancellationToken = default)
            => ExistsAsync(jobVersion.ToString(CultureInfo.InvariantCulture), cancellationToken);

        [ForwardsClientCalls]
        public virtual Response<SqlServerJobVersionResource> Get(int jobVersion, CancellationToken cancellationToken = default)
            => Get(jobVersion.ToString(CultureInfo.InvariantCulture), cancellationToken);

        [ForwardsClientCalls]
        public virtual Task<Response<SqlServerJobVersionResource>> GetAsync(int jobVersion, CancellationToken cancellationToken = default)
            => GetAsync(jobVersion.ToString(CultureInfo.InvariantCulture), cancellationToken);

        [ForwardsClientCalls]
        public virtual NullableResponse<SqlServerJobVersionResource> GetIfExists(int jobVersion, CancellationToken cancellationToken = default)
            => GetIfExists(jobVersion.ToString(CultureInfo.InvariantCulture), cancellationToken);

        [ForwardsClientCalls]
        public virtual Task<NullableResponse<SqlServerJobVersionResource>> GetIfExistsAsync(int jobVersion, CancellationToken cancellationToken = default)
            => GetIfExistsAsync(jobVersion.ToString(CultureInfo.InvariantCulture), cancellationToken);
    }

    public partial class SqlServerJobVersionResource
    {
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string jobAgentName, string jobName, int jobVersion)
            => CreateResourceIdentifier(subscriptionId, resourceGroupName, serverName, jobAgentName, jobName, jobVersion.ToString(CultureInfo.InvariantCulture));
    }
}
