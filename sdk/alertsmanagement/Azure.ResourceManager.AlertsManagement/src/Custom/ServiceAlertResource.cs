// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.AlertsManagement.Models;

namespace Azure.ResourceManager.AlertsManagement
{
    // Backward compatibility: old SDK had ChangeState(ServiceAlertState, string, CancellationToken).
    // New SDK uses ServiceAlertComments model. These overloads provide backward compat.
    public partial class ServiceAlertResource
    {
        /// <summary> Change the state of an alert. </summary>
        /// <param name="newState"> New state of the alert. </param>
        /// <param name="comment"> reason of change alert state. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ServiceAlertResource>> ChangeStateAsync(ServiceAlertState newState, string comment, CancellationToken cancellationToken = default)
        {
            var comments = comment != null ? new ServiceAlertComments { Comments = comment } : default(ServiceAlertComments);
            return await ChangeStateAsync(newState, comments, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Change the state of an alert. </summary>
        /// <param name="newState"> New state of the alert. </param>
        /// <param name="comment"> reason of change alert state. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ServiceAlertResource> ChangeState(ServiceAlertState newState, string comment, CancellationToken cancellationToken = default)
        {
            var comments = comment != null ? new ServiceAlertComments { Comments = comment } : default(ServiceAlertComments);
            return ChangeState(newState, comments, cancellationToken);
        }
    }
}
