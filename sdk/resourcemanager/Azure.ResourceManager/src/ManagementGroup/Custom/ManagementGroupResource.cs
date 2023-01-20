// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.ManagementGroups.Models;

[assembly:CodeGenSuppressType("SearchOptions")]
[assembly:CodeGenSuppressType("EntityViewOptions")]
[assembly:CodeGenSuppressType("TenantExtensions")] // Moved code to Custom/Tenant
[assembly:CodeGenSuppressType("AzureAsyncOperationResults")]
[assembly:CodeGenSuppressType("ErrorResponse")]
[assembly:CodeGenSuppressType("ErrorDetails")] // No target and additionalInfo properties, therefore it's not replaced by common type
[assembly:CodeGenSuppressType("ManagementGroupUpdateOperation")]
[assembly:CodeGenSuppressType("ManagementGroupOperationSource")]
namespace Azure.ResourceManager.ManagementGroups
{
    /// <summary> A Class representing a ManagementGroup along with the instance operations that can be performed on it. </summary>
    public partial class ManagementGroupResource : IOperationSource<ManagementGroupResource>
    {
        internal ManagementGroupResource(ArmClient client): base(client)
        {
        }

        ManagementGroupResource IOperationSource<ManagementGroupResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = ManagementGroupData.DeserializeManagementGroupData(document.RootElement);
            return new ManagementGroupResource(Client, data);
        }

        async ValueTask<ManagementGroupResource> IOperationSource<ManagementGroupResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = ManagementGroupData.DeserializeManagementGroupData(document.RootElement);
            return new ManagementGroupResource(Client, data);
        }
    }
}
