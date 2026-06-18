// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Sql
{
    public partial class SqlServerJobVersionCollection
    {
        /// <summary> Backward-compatible overload that accepts <see cref="int"/> for the job version. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<SqlServerJobVersionResource>> GetAsync(int jobVersion, CancellationToken cancellationToken = default)
            => GetAsync(jobVersion.ToString(CultureInfo.InvariantCulture), cancellationToken);

        /// <summary> Backward-compatible overload that accepts <see cref="int"/> for the job version. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<SqlServerJobVersionResource> Get(int jobVersion, CancellationToken cancellationToken = default)
            => Get(jobVersion.ToString(CultureInfo.InvariantCulture), cancellationToken);

        /// <summary> Backward-compatible overload that accepts <see cref="int"/> for the job version. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<bool>> ExistsAsync(int jobVersion, CancellationToken cancellationToken = default)
            => ExistsAsync(jobVersion.ToString(CultureInfo.InvariantCulture), cancellationToken);

        /// <summary> Backward-compatible overload that accepts <see cref="int"/> for the job version. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(int jobVersion, CancellationToken cancellationToken = default)
            => Exists(jobVersion.ToString(CultureInfo.InvariantCulture), cancellationToken);

        /// <summary> Backward-compatible overload that accepts <see cref="int"/> for the job version. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<NullableResponse<SqlServerJobVersionResource>> GetIfExistsAsync(int jobVersion, CancellationToken cancellationToken = default)
            => GetIfExistsAsync(jobVersion.ToString(CultureInfo.InvariantCulture), cancellationToken);

        /// <summary> Backward-compatible overload that accepts <see cref="int"/> for the job version. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<SqlServerJobVersionResource> GetIfExists(int jobVersion, CancellationToken cancellationToken = default)
            => GetIfExists(jobVersion.ToString(CultureInfo.InvariantCulture), cancellationToken);
    }
}
