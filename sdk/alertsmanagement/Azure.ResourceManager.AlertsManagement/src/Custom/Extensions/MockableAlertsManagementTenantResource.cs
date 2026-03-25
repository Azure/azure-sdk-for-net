// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.AlertsManagement.Models;

namespace Azure.ResourceManager.AlertsManagement.Mocking
{
    // Backward compatibility: old SDK had GetServiceAlertMetadata methods on TenantResource.
    public partial class MockableAlertsManagementTenantResource
    {
        /// <summary> Get alerts metadata. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ServiceAlertMetadata>> GetServiceAlertMetadataAsync(RetrievedInformationIdentifier identifier, CancellationToken cancellationToken = default)
        {
            return await MetaDataAsync(identifier, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Get alerts metadata. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ServiceAlertMetadata> GetServiceAlertMetadata(RetrievedInformationIdentifier identifier, CancellationToken cancellationToken = default)
        {
            return MetaData(identifier, cancellationToken);
        }
    }
}
