// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
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
    //
    // The obsolete Guid-parameter Get/GetAsync/GetIfExists/GetIfExistsAsync overloads below are
    // BC stubs for the v1.1.1 surface that accepted alertId as Guid. The new TypeSpec generator
    // emits only the string-based overloads; callers should pass alertId.ToString().
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
