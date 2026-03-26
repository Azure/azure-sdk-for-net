// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

using EnrichmentType = Azure.ResourceManager.AlertsManagement.Models.Type;

namespace Azure.ResourceManager.AlertsManagement.Models
{
    // Workaround for generator bug: @hierarchyBuilding produces incorrect constructor base() calls
    // in multi-level discriminated hierarchies, causing CS1503 compilation errors.
    // See: https://github.com/Azure/azure-sdk-for-net/issues/57452
    [CodeGenSuppress("PrometheusInstantQuery", typeof(string), typeof(string), typeof(AlertsManagementStatus), typeof(string), typeof(IEnumerable<string>), typeof(string), typeof(string), typeof(string))]
    public partial class PrometheusInstantQuery
    {
        internal PrometheusInstantQuery(string title, string description, AlertsManagementStatus status, string linkToApi, IEnumerable<string> datasources, string grafanaExplorePath, string query, string time)
            : base(title, description, status, EnrichmentType.PrometheusInstantQuery, linkToApi, datasources, grafanaExplorePath, query)
        {
            Time = time;
        }
    }
}
