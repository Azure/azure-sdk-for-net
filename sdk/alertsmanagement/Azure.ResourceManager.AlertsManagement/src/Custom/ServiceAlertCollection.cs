// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure.ResourceManager.AlertsManagement.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.AlertsManagement
{
    // Backward compatibility: the old SDK (AutoRest-based, v1.1.1) exposed a convenience overload
    // ServiceAlertCollection.GetAll(ServiceAlertCollectionGetAllOptions) that wraps 17 individual
    // query parameters into a single options object. The new TypeSpec generator only produces the
    // individual-parameter overload. The [CodeGenType("AlertCollection")] maps the generated
    // AlertCollection (from TypeSpec "Alert" resource renamed via @@clientName to "ServiceAlert")
    // to ServiceAlertCollection to match the old SDK class name.
    [CodeGenType("AlertCollection")]
    public partial class ServiceAlertCollection
    {
        /// <summary>
        /// List all existing alerts, where the results can be filtered on the basis of multiple parameters (e.g. time range). The results can then be sorted on the basis specific fields, with the default being lastModifiedDateTime.
        /// </summary>
        /// <param name="options">The options to configure the alert query.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ServiceAlertResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ServiceAlertResource> GetAllAsync(ServiceAlertCollectionGetAllOptions options, CancellationToken cancellationToken = default)
        {
            options ??= new ServiceAlertCollectionGetAllOptions();
            return GetAllAsync(options.TargetResource, options.TargetResourceType, options.TargetResourceGroup, options.MonitorService, options.MonitorCondition, options.Severity, options.AlertState, options.AlertRule, options.SmartGroupId, options.IncludeContext, options.IncludeEgressConfig, options.PageCount, options.SortBy, options.SortOrder, options.Select, options.TimeRange, options.CustomTimeRange, cancellationToken);
        }

        /// <summary>
        /// List all existing alerts, where the results can be filtered on the basis of multiple parameters (e.g. time range). The results can then be sorted on the basis specific fields, with the default being lastModifiedDateTime.
        /// </summary>
        /// <param name="options">The options to configure the alert query.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ServiceAlertResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ServiceAlertResource> GetAll(ServiceAlertCollectionGetAllOptions options, CancellationToken cancellationToken = default)
        {
            options ??= new ServiceAlertCollectionGetAllOptions();
            return GetAll(options.TargetResource, options.TargetResourceType, options.TargetResourceGroup, options.MonitorService, options.MonitorCondition, options.Severity, options.AlertState, options.AlertRule, options.SmartGroupId, options.IncludeContext, options.IncludeEgressConfig, options.PageCount, options.SortBy, options.SortOrder, options.Select, options.TimeRange, options.CustomTimeRange, cancellationToken);
        }
    }
}
