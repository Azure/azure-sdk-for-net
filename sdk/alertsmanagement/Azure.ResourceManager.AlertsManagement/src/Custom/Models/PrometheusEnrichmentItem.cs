// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.TypeSpec.Generator.Customizations;

using EnrichmentType = Azure.ResourceManager.AlertsManagement.Models.Type;

namespace Azure.ResourceManager.AlertsManagement.Models
{
    // Workaround for generator bug: the TypeSpec generator produces incorrect constructor base()
    // calls in multi-level discriminated type hierarchies (AlertEnrichmentItem → PrometheusEnrichmentItem
    // → PrometheusInstantQuery/PrometheusRangeQuery). The generated constructors pass
    // AlertsManagementStatus where the base expects Type (the discriminator), causing CS1503 errors.
    // This custom code suppresses the broken constructors and provides correct ones that pass the
    // discriminator value (EnrichmentType.PrometheusEnrichmentItem) to the base class.
    // See: https://github.com/Azure/azure-sdk-for-net/issues/57452
    [CodeGenSuppress("PrometheusEnrichmentItem", typeof(string), typeof(string), typeof(AlertsManagementStatus), typeof(string), typeof(IEnumerable<string>), typeof(string), typeof(string))]
    [CodeGenSuppress("PrometheusEnrichmentItem", typeof(string), typeof(string), typeof(AlertsManagementStatus), typeof(EnrichmentType), typeof(string), typeof(IEnumerable<string>), typeof(string), typeof(string))]
    public partial class PrometheusEnrichmentItem
    {
        internal PrometheusEnrichmentItem(string title, string description, AlertsManagementStatus status, string linkToApi, IEnumerable<string> datasources, string grafanaExplorePath, string query)
            : base(title, description, status, EnrichmentType.PrometheusEnrichmentItem)
        {
            LinkToApi = linkToApi;
            Datasources = datasources.ToList();
            GrafanaExplorePath = grafanaExplorePath;
            Query = query;
        }

        private protected PrometheusEnrichmentItem(string title, string description, AlertsManagementStatus status, EnrichmentType @type, string linkToApi, IEnumerable<string> datasources, string grafanaExplorePath, string query)
            : base(title, description, status, @type)
        {
            LinkToApi = linkToApi;
            Datasources = datasources.ToList();
            GrafanaExplorePath = grafanaExplorePath;
            Query = query;
        }
    }
}
