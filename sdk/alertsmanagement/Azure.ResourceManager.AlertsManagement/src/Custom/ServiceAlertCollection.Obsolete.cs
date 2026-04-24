// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility stub: add old Guid-parameter methods returning ServiceAlertResource.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.AlertsManagement
{
    public partial class ServiceAlertCollection
    {
        /// <summary> Gets an alert by Guid. </summary>
        /// <param name="alertId"> The alert ID. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [Obsolete("Use the string-based overload instead (pass the alert ID as a string).", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ServiceAlertResource> Get(Guid alertId, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets an alert by Guid async. </summary>
        /// <param name="alertId"> The alert ID. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [Obsolete("Use the string-based overload instead (pass the alert ID as a string).", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<ServiceAlertResource>> GetAsync(Guid alertId, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets an alert if it exists by Guid. </summary>
        /// <param name="alertId"> The alert ID. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [Obsolete("Use the string-based overload instead (pass the alert ID as a string).", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<ServiceAlertResource> GetIfExists(Guid alertId, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets an alert if it exists by Guid async. </summary>
        /// <param name="alertId"> The alert ID. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [Obsolete("Use the string-based overload instead (pass the alert ID as a string).", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<NullableResponse<ServiceAlertResource>> GetIfExistsAsync(Guid alertId, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }
    }
}
