// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure.ResourceManager.Maintenance.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Maintenance
{
    // Suppress duplicate Get/Update/Delete methods generated for multiple scopes
    // (ConfigurationAssignmentOperationGroup, ForResourceGroup, ForSubscriptions)
    // that all map to the same ConfigurationAssignmentResource class with identical signatures
    [CodeGenSuppress("GetAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("Get", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("UpdateAsync", typeof(string), typeof(MaintenanceConfigurationAssignmentData), typeof(CancellationToken))]
    [CodeGenSuppress("Update", typeof(string), typeof(MaintenanceConfigurationAssignmentData), typeof(CancellationToken))]
    [CodeGenSuppress("DeleteAsync", typeof(WaitUntil), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("Delete", typeof(WaitUntil), typeof(string), typeof(CancellationToken))]
    public partial class ConfigurationAssignmentResource
    {
    }
}
