// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.AlertsManagement.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.AlertsManagement
{
    // Backward compatibility: the old SDK (AutoRest-based, v1.1.1) exposed
    // GetServiceAlerts(SubscriptionResource) and GetServiceAlertMetadata(TenantResource).
    // The new TypeSpec generator places GetServiceAlerts on ArmClient (scope-based) and renames
    // GetServiceAlertMetadata to MetaData on TenantResource. These extension methods re-introduce
    // the old method signatures, marked [EditorBrowsable(Never)] to hide from IntelliSense while
    // keeping binary/source compatibility.
    public static partial class AlertsManagementExtensions
    {
        /// <summary> Gets a collection of ServiceAlertCollection in the SubscriptionResource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ServiceAlertCollection GetServiceAlerts(this SubscriptionResource subscriptionResource)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableAlertsManagementSubscriptionResource(subscriptionResource).GetServiceAlerts();
        }

        /// <summary> Get alerts metadata. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<ServiceAlertMetadata>> GetServiceAlertMetadataAsync(this TenantResource tenantResource, RetrievedInformationIdentifier identifier, CancellationToken cancellationToken = default)
        {
            return await GetMockableAlertsManagementTenantResource(tenantResource).GetServiceAlertMetadataAsync(identifier, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Get alerts metadata. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<ServiceAlertMetadata> GetServiceAlertMetadata(this TenantResource tenantResource, RetrievedInformationIdentifier identifier, CancellationToken cancellationToken = default)
        {
            return GetMockableAlertsManagementTenantResource(tenantResource).GetServiceAlertMetadata(identifier, cancellationToken);
        }
    }
}
