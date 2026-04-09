// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.AlertsManagement.Models
{
    // Workaround for generator bug: same multi-level discriminated hierarchy issue as
    // PrometheusEnrichmentItem. The generated constructor for PrometheusInstantQuery passes
    // AlertsManagementStatus where the PrometheusEnrichmentItem base expects Type. This custom
    // constructor correctly passes arguments to the PrometheusEnrichmentItem base class.
    // See: https://github.com/Azure/azure-sdk-for-net/issues/57452
    [CodeGenSuppress("PrometheusInstantQuery", typeof(string), typeof(string), typeof(AlertsManagementStatus), typeof(string), typeof(IEnumerable<string>), typeof(string), typeof(string), typeof(string))]
    public partial class PrometheusInstantQuery
    {
        internal PrometheusInstantQuery(string title, string description, AlertsManagementStatus status, string linkToApi, IEnumerable<string> datasources, string grafanaExplorePath, string query, string time)
            : base(title, description, status, AlertsManagementType.PrometheusInstantQuery, linkToApi, datasources, grafanaExplorePath, query)
        {
            Time = time;
        }
    }
}
