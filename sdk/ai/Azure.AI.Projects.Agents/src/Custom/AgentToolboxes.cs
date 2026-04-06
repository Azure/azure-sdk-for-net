// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Diagnostics.CodeAnalysis;
using System.Threading;

namespace Azure.AI.Projects.Agents;

[Experimental("AAIP001")]
[CodeGenType("Toolboxes")]
public partial class AgentToolboxes
{
    /// <summary> List all versions of a toolbox. </summary>
    /// <param name="toolboxName"> The name of the toolbox to list versions for. </param>
    /// <param name="limit">
    /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the
    /// default is 20.
    /// </param>
    /// <param name="order">
    /// Sort order by the `created_at` timestamp of the objects. `asc` for ascending order and`desc`
    /// for descending order.
    /// </param>
    /// <param name="after">
    /// A cursor for use in pagination. `after` is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
    /// subsequent call can include after=obj_foo in order to fetch the next page of the list.
    /// </param>
    /// <param name="before">
    /// A cursor for use in pagination. `before` is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
    /// subsequent call can include before=obj_foo in order to fetch the previous page of the list.
    /// </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="toolboxName"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="toolboxName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual CollectionResult<ToolboxVersion> GetToolboxes(string toolboxName, int? limit = default, AgentListOrder? order = default, string after = default, string before = default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(toolboxName, nameof(toolboxName));
        return new InternalOpenAICollectionResultOfT<ToolboxVersion>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetToolboxVersionsRequest(
                    localCollectionOptions.Filters.Count > 0 ? localCollectionOptions.Filters[0] : null,
                    localCollectionOptions.Limit,
                    localCollectionOptions.Order,
                    localCollectionOptions.AfterId,
                    localCollectionOptions.BeforeId,
                    localRequestOptions),
            dataItemDeserializer: (e, o) => CustomSerializationHelpers.DeserializeProjectOpenAIType<ToolboxVersion>(e, o),
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before, filters: [toolboxName]),
            cancellationToken.ToRequestOptions());
    }

    /// <summary> List all versions of a toolbox. </summary>
    /// <param name="toolboxName"> The name of the toolbox to list versions for. </param>
    /// <param name="limit">
    /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the
    /// default is 20.
    /// </param>
    /// <param name="order">
    /// Sort order by the `created_at` timestamp of the objects. `asc` for ascending order and`desc`
    /// for descending order.
    /// </param>
    /// <param name="after">
    /// A cursor for use in pagination. `after` is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
    /// subsequent call can include after=obj_foo in order to fetch the next page of the list.
    /// </param>
    /// <param name="before">
    /// A cursor for use in pagination. `before` is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
    /// subsequent call can include before=obj_foo in order to fetch the previous page of the list.
    /// </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="toolboxName"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="toolboxName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual AsyncCollectionResult<ToolboxVersion> GetToolboxVersionsAsync(string toolboxName, int? limit = default, AgentListOrder? order = default, string after = default, string before = default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(toolboxName, nameof(toolboxName));
        return new InternalOpenAIAsyncCollectionResultOfT<ToolboxVersion>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetToolboxVersionsRequest(
                    localCollectionOptions.Filters.Count > 0 ? localCollectionOptions.Filters[0] : null,
                    localCollectionOptions.Limit,
                    localCollectionOptions.Order,
                    localCollectionOptions.AfterId,
                    localCollectionOptions.BeforeId,
                    localRequestOptions),
            dataItemDeserializer: (e, o) => CustomSerializationHelpers.DeserializeProjectOpenAIType<ToolboxVersion>(e, o),
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before, filters: [toolboxName]),
            cancellationToken.ToRequestOptions());
    }
}
