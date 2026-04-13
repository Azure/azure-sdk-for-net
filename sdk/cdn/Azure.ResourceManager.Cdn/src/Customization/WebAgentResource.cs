// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Cdn.Models;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Cdn
{
    // Customization: This file contains custom implementations of tag operation helper methods for WebAgentResource (currently commented out).
    // Reason: The generator's Update operation returns a non-generic ArmOperation (no FinalResult in the LRO response header),
    // but the generated tag helpers (AddTag/SetTags/RemoveTag) try to access result.Value, causing a runtime error.
    // These tag helpers are re-implemented to re-fetch the resource after the Update completes to obtain the latest data.
    // Note: These methods are currently commented out, possibly because the generator has fixed this issue or the customization is temporarily unneeded.

    // Generator bug: Update returns non-generic ArmOperation (no FinalResult in LRO header),
    // but the generated tag helpers try to access result.Value which doesn't exist.
    // Re-implement tag helpers to re-fetch the resource after update completes.
    // [CodeGenSuppress("AddTagAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    // [CodeGenSuppress("AddTag", typeof(string), typeof(string), typeof(CancellationToken))]
    // [CodeGenSuppress("SetTagsAsync", typeof(IDictionary<string, string>), typeof(CancellationToken))]
    // [CodeGenSuppress("SetTags", typeof(IDictionary<string, string>), typeof(CancellationToken))]
    // [CodeGenSuppress("RemoveTagAsync", typeof(string), typeof(CancellationToken))]
    // [CodeGenSuppress("RemoveTag", typeof(string), typeof(CancellationToken))]
    // public partial class WebAgentResource
    // {
    //     /// <summary> Add a tag to the current resource. </summary>
    //     /// <param name="key"> The key for the tag. </param>
    //     /// <param name="value"> The value for the tag. </param>
    //     /// <param name="cancellationToken"> The cancellation token to use. </param>
    //     /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
    //     public virtual async Task<Response<WebAgentResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
    //     {
    //         Argument.AssertNotNull(key, nameof(key));
    //         Argument.AssertNotNull(value, nameof(value));

    //         using DiagnosticScope scope = _webAgentsClientDiagnostics.CreateScope("WebAgentResource.AddTag");
    //         scope.Start();
    //         try
    //         {
    //             if (await CanUseTagResourceAsync(cancellationToken).ConfigureAwait(false))
    //             {
    //                 Response<TagResource> originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
    //                 originalTags.Value.Data.TagValues[key] = value;
    //                 await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken).ConfigureAwait(false);
    //                 RequestContext context = new RequestContext { CancellationToken = cancellationToken };
    //                 HttpMessage message = _webAgentsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
    //                 Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
    //                 Response<WebAgentData> response = Response.FromValue(WebAgentData.FromResponse(result), result);
    //                 return Response.FromValue(new WebAgentResource(Client, response.Value), response.GetRawResponse());
    //             }
    //             else
    //             {
    //                 WebAgentData current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
    //                 WebAgentPatch patch = new WebAgentPatch();
    //                 foreach (KeyValuePair<string, string> tag in current.Tags)
    //                 {
    //                     patch.Tags.Add(tag);
    //                 }
    //                 patch.Tags[key] = value;
    //                 await UpdateAsync(WaitUntil.Completed, patch, cancellationToken: cancellationToken).ConfigureAwait(false);
    //                 var updated = await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
    //                 return updated;
    //             }
    //         }
    //         catch (Exception e)
    //         {
    //             scope.Failed(e);
    //             throw;
    //         }
    //     }

    //     /// <summary> Add a tag to the current resource. </summary>
    //     /// <param name="key"> The key for the tag. </param>
    //     /// <param name="value"> The value for the tag. </param>
    //     /// <param name="cancellationToken"> The cancellation token to use. </param>
    //     /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
    //     public virtual Response<WebAgentResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
    //     {
    //         Argument.AssertNotNull(key, nameof(key));
    //         Argument.AssertNotNull(value, nameof(value));

    //         using DiagnosticScope scope = _webAgentsClientDiagnostics.CreateScope("WebAgentResource.AddTag");
    //         scope.Start();
    //         try
    //         {
    //             if (CanUseTagResource(cancellationToken))
    //             {
    //                 Response<TagResource> originalTags = GetTagResource().Get(cancellationToken);
    //                 originalTags.Value.Data.TagValues[key] = value;
    //                 GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken);
    //                 RequestContext context = new RequestContext { CancellationToken = cancellationToken };
    //                 HttpMessage message = _webAgentsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
    //                 Response result = Pipeline.ProcessMessage(message, context);
    //                 Response<WebAgentData> response = Response.FromValue(WebAgentData.FromResponse(result), result);
    //                 return Response.FromValue(new WebAgentResource(Client, response.Value), response.GetRawResponse());
    //             }
    //             else
    //             {
    //                 WebAgentData current = Get(cancellationToken: cancellationToken).Value.Data;
    //                 WebAgentPatch patch = new WebAgentPatch();
    //                 foreach (KeyValuePair<string, string> tag in current.Tags)
    //                 {
    //                     patch.Tags.Add(tag);
    //                 }
    //                 patch.Tags[key] = value;
    //                 Update(WaitUntil.Completed, patch, cancellationToken: cancellationToken);
    //                 return Get(cancellationToken: cancellationToken);
    //             }
    //         }
    //         catch (Exception e)
    //         {
    //             scope.Failed(e);
    //             throw;
    //         }
    //     }

    //     /// <summary> Replace the tags on the resource with the given set. </summary>
    //     /// <param name="tags"> The tags to set on the resource. </param>
    //     /// <param name="cancellationToken"> The cancellation token to use. </param>
    //     /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
    //     public virtual async Task<Response<WebAgentResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
    //     {
    //         Argument.AssertNotNull(tags, nameof(tags));

    //         using DiagnosticScope scope = _webAgentsClientDiagnostics.CreateScope("WebAgentResource.SetTags");
    //         scope.Start();
    //         try
    //         {
    //             if (await CanUseTagResourceAsync(cancellationToken).ConfigureAwait(false))
    //             {
    //                 await GetTagResource().DeleteAsync(WaitUntil.Completed, cancellationToken).ConfigureAwait(false);
    //                 Response<TagResource> originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
    //                 originalTags.Value.Data.TagValues.ReplaceWith(tags);
    //                 await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken).ConfigureAwait(false);
    //                 RequestContext context = new RequestContext { CancellationToken = cancellationToken };
    //                 HttpMessage message = _webAgentsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
    //                 Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
    //                 Response<WebAgentData> response = Response.FromValue(WebAgentData.FromResponse(result), result);
    //                 return Response.FromValue(new WebAgentResource(Client, response.Value), response.GetRawResponse());
    //             }
    //             else
    //             {
    //                 WebAgentData current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
    //                 WebAgentPatch patch = new WebAgentPatch();
    //                 patch.Tags.ReplaceWith(tags);
    //                 await UpdateAsync(WaitUntil.Completed, patch, cancellationToken: cancellationToken).ConfigureAwait(false);
    //                 var updated = await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
    //                 return updated;
    //             }
    //         }
    //         catch (Exception e)
    //         {
    //             scope.Failed(e);
    //             throw;
    //         }
    //     }

    //     /// <summary> Replace the tags on the resource with the given set. </summary>
    //     /// <param name="tags"> The tags to set on the resource. </param>
    //     /// <param name="cancellationToken"> The cancellation token to use. </param>
    //     /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
    //     public virtual Response<WebAgentResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
    //     {
    //         Argument.AssertNotNull(tags, nameof(tags));

    //         using DiagnosticScope scope = _webAgentsClientDiagnostics.CreateScope("WebAgentResource.SetTags");
    //         scope.Start();
    //         try
    //         {
    //             if (CanUseTagResource(cancellationToken))
    //             {
    //                 GetTagResource().Delete(WaitUntil.Completed, cancellationToken);
    //                 Response<TagResource> originalTags = GetTagResource().Get(cancellationToken);
    //                 originalTags.Value.Data.TagValues.ReplaceWith(tags);
    //                 GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken);
    //                 RequestContext context = new RequestContext { CancellationToken = cancellationToken };
    //                 HttpMessage message = _webAgentsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
    //                 Response result = Pipeline.ProcessMessage(message, context);
    //                 Response<WebAgentData> response = Response.FromValue(WebAgentData.FromResponse(result), result);
    //                 return Response.FromValue(new WebAgentResource(Client, response.Value), response.GetRawResponse());
    //             }
    //             else
    //             {
    //                 WebAgentData current = Get(cancellationToken: cancellationToken).Value.Data;
    //                 WebAgentPatch patch = new WebAgentPatch();
    //                 patch.Tags.ReplaceWith(tags);
    //                 Update(WaitUntil.Completed, patch, cancellationToken: cancellationToken);
    //                 return Get(cancellationToken: cancellationToken);
    //             }
    //         }
    //         catch (Exception e)
    //         {
    //             scope.Failed(e);
    //             throw;
    //         }
    //     }

    //     /// <summary> Removes a tag by key from the resource. </summary>
    //     /// <param name="key"> The key for the tag. </param>
    //     /// <param name="cancellationToken"> The cancellation token to use. </param>
    //     /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
    //     public virtual async Task<Response<WebAgentResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
    //     {
    //         Argument.AssertNotNull(key, nameof(key));

    //         using DiagnosticScope scope = _webAgentsClientDiagnostics.CreateScope("WebAgentResource.RemoveTag");
    //         scope.Start();
    //         try
    //         {
    //             if (await CanUseTagResourceAsync(cancellationToken).ConfigureAwait(false))
    //             {
    //                 Response<TagResource> originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
    //                 originalTags.Value.Data.TagValues.Remove(key);
    //                 await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken).ConfigureAwait(false);
    //                 RequestContext context = new RequestContext { CancellationToken = cancellationToken };
    //                 HttpMessage message = _webAgentsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
    //                 Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
    //                 Response<WebAgentData> response = Response.FromValue(WebAgentData.FromResponse(result), result);
    //                 return Response.FromValue(new WebAgentResource(Client, response.Value), response.GetRawResponse());
    //             }
    //             else
    //             {
    //                 WebAgentData current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
    //                 WebAgentPatch patch = new WebAgentPatch();
    //                 foreach (KeyValuePair<string, string> tag in current.Tags)
    //                 {
    //                     patch.Tags.Add(tag);
    //                 }
    //                 patch.Tags.Remove(key);
    //                 await UpdateAsync(WaitUntil.Completed, patch, cancellationToken: cancellationToken).ConfigureAwait(false);
    //                 var updated = await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
    //                 return updated;
    //             }
    //         }
    //         catch (Exception e)
    //         {
    //             scope.Failed(e);
    //             throw;
    //         }
    //     }

    //     /// <summary> Removes a tag by key from the resource. </summary>
    //     /// <param name="key"> The key for the tag. </param>
    //     /// <param name="cancellationToken"> The cancellation token to use. </param>
    //     /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
    //     public virtual Response<WebAgentResource> RemoveTag(string key, CancellationToken cancellationToken = default)
    //     {
    //         Argument.AssertNotNull(key, nameof(key));

    //         using DiagnosticScope scope = _webAgentsClientDiagnostics.CreateScope("WebAgentResource.RemoveTag");
    //         scope.Start();
    //         try
    //         {
    //             if (CanUseTagResource(cancellationToken))
    //             {
    //                 Response<TagResource> originalTags = GetTagResource().Get(cancellationToken);
    //                 originalTags.Value.Data.TagValues.Remove(key);
    //                 GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken);
    //                 RequestContext context = new RequestContext { CancellationToken = cancellationToken };
    //                 HttpMessage message = _webAgentsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
    //                 Response result = Pipeline.ProcessMessage(message, context);
    //                 Response<WebAgentData> response = Response.FromValue(WebAgentData.FromResponse(result), result);
    //                 return Response.FromValue(new WebAgentResource(Client, response.Value), response.GetRawResponse());
    //             }
    //             else
    //             {
    //                 WebAgentData current = Get(cancellationToken: cancellationToken).Value.Data;
    //                 WebAgentPatch patch = new WebAgentPatch();
    //                 foreach (KeyValuePair<string, string> tag in current.Tags)
    //                 {
    //                     patch.Tags.Add(tag);
    //                 }
    //                 patch.Tags.Remove(key);
    //                 Update(WaitUntil.Completed, patch, cancellationToken: cancellationToken);
    //                 return Get(cancellationToken: cancellationToken);
    //             }
    //         }
    //         catch (Exception e)
    //         {
    //             scope.Failed(e);
    //             throw;
    //         }
    //     }
    // }
}
