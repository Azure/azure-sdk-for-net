// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Resources
{
    /// <summary>
    /// A Class representing a ManagementLock along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="ManagementLockResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetManagementLockResource method.
    /// Otherwise you can get one from its parent resource <see cref="ArmResource" /> using the GetManagementLock method.
    /// </summary>
    public partial class ManagementLockResource : ArmResource, IOperationSource<ManagementLockResource>
    {
        internal ManagementLockResource(ArmClient client): base(client)
        {
        }

        ManagementLockResource IOperationSource<ManagementLockResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = ManagementLockData.DeserializeManagementLockData(document.RootElement);
            return new ManagementLockResource(Client, data);
        }

        async ValueTask<ManagementLockResource> IOperationSource<ManagementLockResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = ManagementLockData.DeserializeManagementLockData(document.RootElement);
            return new ManagementLockResource(Client, data);
        }
    }
}
