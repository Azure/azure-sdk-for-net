// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.CosmosDB.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.CosmosDB
{
    // Preserve tag helpers shipped in the GA API. New resources with incompatible PUT body and
    // resource data types do not generate these methods.
    public partial class CosmosDBSqlContainerResource
    {
        /// <summary> Add a tag to the current resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual async Task<Response<CosmosDBSqlContainerResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using DiagnosticScope scope = _sqlResourcesClientDiagnostics.CreateScope("CosmosDBSqlContainerResource.AddTag");
            scope.Start();
            try
            {
                if (await CanUseTagResourceAsync(cancellationToken).ConfigureAwait(false))
                {
                    Response<TagResource> originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                    originalTags.Value.Data.TagValues[key] = value;
                    await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken).ConfigureAwait(false);
                    RequestContext context = new RequestContext
                    {
                        CancellationToken = cancellationToken
                    };
                    HttpMessage message = _sqlResourcesRestClient.CreateGetSqlContainerRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
                    Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    Response<CosmosDBSqlContainerData> response = Response.FromValue(CosmosDBSqlContainerData.FromResponse(result), result);
                    return Response.FromValue(new CosmosDBSqlContainerResource(Client, response.Value), response.GetRawResponse());
                }
                else
                {
                    CosmosDBSqlContainerData current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    current.Tags[key] = value;
                    ArmOperation<CosmosDBSqlContainerResource> result = await UpdateAsync(WaitUntil.Completed, current, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(result.Value, result.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Add a tag to the current resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual Response<CosmosDBSqlContainerResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using DiagnosticScope scope = _sqlResourcesClientDiagnostics.CreateScope("CosmosDBSqlContainerResource.AddTag");
            scope.Start();
            try
            {
                if (CanUseTagResource(cancellationToken))
                {
                    Response<TagResource> originalTags = GetTagResource().Get(cancellationToken);
                    originalTags.Value.Data.TagValues[key] = value;
                    GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken);
                    RequestContext context = new RequestContext
                    {
                        CancellationToken = cancellationToken
                    };
                    HttpMessage message = _sqlResourcesRestClient.CreateGetSqlContainerRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
                    Response result = Pipeline.ProcessMessage(message, context);
                    Response<CosmosDBSqlContainerData> response = Response.FromValue(CosmosDBSqlContainerData.FromResponse(result), result);
                    return Response.FromValue(new CosmosDBSqlContainerResource(Client, response.Value), response.GetRawResponse());
                }
                else
                {
                    CosmosDBSqlContainerData current = Get(cancellationToken: cancellationToken).Value.Data;
                    current.Tags[key] = value;
                    ArmOperation<CosmosDBSqlContainerResource> result = Update(WaitUntil.Completed, current, cancellationToken: cancellationToken);
                    return Response.FromValue(result.Value, result.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Replace the tags on the resource with the given set. </summary>
        /// <param name="tags"> The tags to set on the resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual async Task<Response<CosmosDBSqlContainerResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using DiagnosticScope scope = _sqlResourcesClientDiagnostics.CreateScope("CosmosDBSqlContainerResource.SetTags");
            scope.Start();
            try
            {
                if (await CanUseTagResourceAsync(cancellationToken).ConfigureAwait(false))
                {
                    await GetTagResource().DeleteAsync(WaitUntil.Completed, cancellationToken).ConfigureAwait(false);
                    Response<TagResource> originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                    originalTags.Value.Data.TagValues.ReplaceWith(tags);
                    await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken).ConfigureAwait(false);
                    RequestContext context = new RequestContext
                    {
                        CancellationToken = cancellationToken
                    };
                    HttpMessage message = _sqlResourcesRestClient.CreateGetSqlContainerRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
                    Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    Response<CosmosDBSqlContainerData> response = Response.FromValue(CosmosDBSqlContainerData.FromResponse(result), result);
                    return Response.FromValue(new CosmosDBSqlContainerResource(Client, response.Value), response.GetRawResponse());
                }
                else
                {
                    CosmosDBSqlContainerData current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    current.Tags.ReplaceWith(tags);
                    ArmOperation<CosmosDBSqlContainerResource> result = await UpdateAsync(WaitUntil.Completed, current, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(result.Value, result.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Replace the tags on the resource with the given set. </summary>
        /// <param name="tags"> The tags to set on the resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual Response<CosmosDBSqlContainerResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using DiagnosticScope scope = _sqlResourcesClientDiagnostics.CreateScope("CosmosDBSqlContainerResource.SetTags");
            scope.Start();
            try
            {
                if (CanUseTagResource(cancellationToken))
                {
                    GetTagResource().Delete(WaitUntil.Completed, cancellationToken);
                    Response<TagResource> originalTags = GetTagResource().Get(cancellationToken);
                    originalTags.Value.Data.TagValues.ReplaceWith(tags);
                    GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken);
                    RequestContext context = new RequestContext
                    {
                        CancellationToken = cancellationToken
                    };
                    HttpMessage message = _sqlResourcesRestClient.CreateGetSqlContainerRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
                    Response result = Pipeline.ProcessMessage(message, context);
                    Response<CosmosDBSqlContainerData> response = Response.FromValue(CosmosDBSqlContainerData.FromResponse(result), result);
                    return Response.FromValue(new CosmosDBSqlContainerResource(Client, response.Value), response.GetRawResponse());
                }
                else
                {
                    CosmosDBSqlContainerData current = Get(cancellationToken: cancellationToken).Value.Data;
                    current.Tags.ReplaceWith(tags);
                    ArmOperation<CosmosDBSqlContainerResource> result = Update(WaitUntil.Completed, current, cancellationToken: cancellationToken);
                    return Response.FromValue(result.Value, result.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Removes a tag by key from the resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual async Task<Response<CosmosDBSqlContainerResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using DiagnosticScope scope = _sqlResourcesClientDiagnostics.CreateScope("CosmosDBSqlContainerResource.RemoveTag");
            scope.Start();
            try
            {
                if (await CanUseTagResourceAsync(cancellationToken).ConfigureAwait(false))
                {
                    Response<TagResource> originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                    originalTags.Value.Data.TagValues.Remove(key);
                    await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken).ConfigureAwait(false);
                    RequestContext context = new RequestContext
                    {
                        CancellationToken = cancellationToken
                    };
                    HttpMessage message = _sqlResourcesRestClient.CreateGetSqlContainerRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
                    Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    Response<CosmosDBSqlContainerData> response = Response.FromValue(CosmosDBSqlContainerData.FromResponse(result), result);
                    return Response.FromValue(new CosmosDBSqlContainerResource(Client, response.Value), response.GetRawResponse());
                }
                else
                {
                    CosmosDBSqlContainerData current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    current.Tags.Remove(key);
                    ArmOperation<CosmosDBSqlContainerResource> result = await UpdateAsync(WaitUntil.Completed, current, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(result.Value, result.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Removes a tag by key from the resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual Response<CosmosDBSqlContainerResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using DiagnosticScope scope = _sqlResourcesClientDiagnostics.CreateScope("CosmosDBSqlContainerResource.RemoveTag");
            scope.Start();
            try
            {
                if (CanUseTagResource(cancellationToken))
                {
                    Response<TagResource> originalTags = GetTagResource().Get(cancellationToken);
                    originalTags.Value.Data.TagValues.Remove(key);
                    GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken);
                    RequestContext context = new RequestContext
                    {
                        CancellationToken = cancellationToken
                    };
                    HttpMessage message = _sqlResourcesRestClient.CreateGetSqlContainerRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
                    Response result = Pipeline.ProcessMessage(message, context);
                    Response<CosmosDBSqlContainerData> response = Response.FromValue(CosmosDBSqlContainerData.FromResponse(result), result);
                    return Response.FromValue(new CosmosDBSqlContainerResource(Client, response.Value), response.GetRawResponse());
                }
                else
                {
                    CosmosDBSqlContainerData current = Get(cancellationToken: cancellationToken).Value.Data;
                    current.Tags.Remove(key);
                    ArmOperation<CosmosDBSqlContainerResource> result = Update(WaitUntil.Completed, current, cancellationToken: cancellationToken);
                    return Response.FromValue(result.Value, result.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
