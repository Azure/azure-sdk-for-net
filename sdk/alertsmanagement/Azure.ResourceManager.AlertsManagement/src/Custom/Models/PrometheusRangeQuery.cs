// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

using EnrichmentType = Azure.ResourceManager.AlertsManagement.Models.Type;

namespace Azure.ResourceManager.AlertsManagement.Models
{
    // Workaround for generator bug: same multi-level discriminated hierarchy issue as
    // PrometheusEnrichmentItem. The generated constructor for PrometheusRangeQuery passes
    // AlertsManagementStatus where the PrometheusEnrichmentItem base expects Type. This custom
    // constructor correctly passes arguments to the PrometheusEnrichmentItem base class.
    // See: https://github.com/Azure/azure-sdk-for-net/issues/57452
    [CodeGenSuppress("PrometheusRangeQuery", typeof(string), typeof(string), typeof(AlertsManagementStatus), typeof(string), typeof(IEnumerable<string>), typeof(string), typeof(string), typeof(DateTimeOffset), typeof(DateTimeOffset), typeof(string))]
    public partial class PrometheusRangeQuery
    {
        internal PrometheusRangeQuery(string title, string description, AlertsManagementStatus status, string linkToApi, IEnumerable<string> datasources, string grafanaExplorePath, string query, DateTimeOffset start, DateTimeOffset end, string step)
            : base(title, description, status, EnrichmentType.PrometheusRangeQuery, linkToApi, datasources, grafanaExplorePath, query)
        {
            Start = start;
            End = end;
            Step = step;
        }
    }
}
