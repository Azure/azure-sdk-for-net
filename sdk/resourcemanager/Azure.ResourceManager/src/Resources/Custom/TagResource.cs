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
    /// A Class representing a TagResource along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="TagResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetTagResource method.
    /// Otherwise you can get one from its parent resource <see cref="ArmResource" /> using the GetTagResource method.
    /// </summary>
    public partial class TagResource : ArmResource, IOperationSource<TagResource>
    {
        TagResource IOperationSource<TagResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = TagResourceData.DeserializeTagResourceData(document.RootElement);
            return new TagResource(Client, data);
        }

        async ValueTask<TagResource> IOperationSource<TagResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = TagResourceData.DeserializeTagResourceData(document.RootElement);
            return new TagResource(Client, data);
        }
    }
}
