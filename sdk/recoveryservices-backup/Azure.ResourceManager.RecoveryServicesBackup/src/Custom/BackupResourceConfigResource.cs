// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Resources;

// NOTE: The following customization is intentionally retained for backward compatibility.
// This is a singleton resource which was not correctly generated as such, so we have to fix Update, AddTag, SetTags, and RemoveTag methods to make it backward compatible.
namespace Azure.ResourceManager.RecoveryServicesBackup
{
    public partial class BackupResourceConfigResource : ArmResource
    {
        /// <summary>
        /// Updates vault storage model type.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupstorageconfig/vaultstorageconfig</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BackupResourceStorageConfigsNonCRR_Update</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="BackupResourceConfigResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="data"> Vault storage config request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<BackupResourceConfigResource>> UpdateAsync(BackupResourceConfigData data, CancellationToken cancellationToken = default)
        {
            var result = await CreateOrUpdateAsync(WaitUntil.Completed, data, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(result.Value, result.GetRawResponse());
        }

        /// <summary>
        /// Updates vault storage model type.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupstorageconfig/vaultstorageconfig</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BackupResourceStorageConfigsNonCRR_Update</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="BackupResourceConfigResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="data"> Vault storage config request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<BackupResourceConfigResource> Update(BackupResourceConfigData data, CancellationToken cancellationToken = default)
        {
            var result = CreateOrUpdate(WaitUntil.Completed, data, cancellationToken);
            return Response.FromValue(result.Value, result.GetRawResponse());
        }

        /// <summary>
        /// Updates vault storage model type.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupstorageconfig/vaultstorageconfig. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> BackupResourceStorageConfigsNonCRR_Update. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="BackupResourceConfigResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> Vault storage config request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<BackupResourceConfigResource>> UpdateAsync(WaitUntil waitUntil, BackupResourceConfigData data, CancellationToken cancellationToken = default)
            => await CreateOrUpdateAsync(waitUntil, data, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Updates vault storage model type.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupstorageconfig/vaultstorageconfig. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> BackupResourceStorageConfigsNonCRR_Update. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-01-01-preview. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="BackupResourceConfigResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> Vault storage config request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<BackupResourceConfigResource> Update(WaitUntil waitUntil, BackupResourceConfigData data, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, data, cancellationToken);

        /// <summary> Add a tag to the current resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual async Task<Response<BackupResourceConfigResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using DiagnosticScope scope = _backupResourceStorageConfigsNonCRRClientDiagnostics.CreateScope("BackupResourceConfigResource.AddTag");
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
                    HttpMessage message = _backupResourceStorageConfigsNonCRRRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, context);
                    Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    Response<BackupResourceConfigData> response = Response.FromValue(BackupResourceConfigData.FromResponse(result), result);
                    return Response.FromValue(new BackupResourceConfigResource(Client, response.Value), response.GetRawResponse());
                }
                else
                {
                    BackupResourceConfigData current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    BackupResourceConfigData patch = new BackupResourceConfigData();
                    foreach (KeyValuePair<string, string> tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags[key] = value;
                    return await UpdateAsync(patch, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        public virtual Response<BackupResourceConfigResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using DiagnosticScope scope = _backupResourceStorageConfigsNonCRRClientDiagnostics.CreateScope("BackupResourceConfigResource.AddTag");
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
                    HttpMessage message = _backupResourceStorageConfigsNonCRRRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, context);
                    Response result = Pipeline.ProcessMessage(message, context);
                    Response<BackupResourceConfigData> response = Response.FromValue(BackupResourceConfigData.FromResponse(result), result);
                    return Response.FromValue(new BackupResourceConfigResource(Client, response.Value), response.GetRawResponse());
                }
                else
                {
                    BackupResourceConfigData current = Get(cancellationToken: cancellationToken).Value.Data;
                    BackupResourceConfigData patch = new BackupResourceConfigData();
                    foreach (KeyValuePair<string, string> tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags[key] = value;
                    var result = Update(patch, cancellationToken: cancellationToken);
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
        public virtual async Task<Response<BackupResourceConfigResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using DiagnosticScope scope = _backupResourceStorageConfigsNonCRRClientDiagnostics.CreateScope("BackupResourceConfigResource.SetTags");
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
                    HttpMessage message = _backupResourceStorageConfigsNonCRRRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, context);
                    Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    Response<BackupResourceConfigData> response = Response.FromValue(BackupResourceConfigData.FromResponse(result), result);
                    return Response.FromValue(new BackupResourceConfigResource(Client, response.Value), response.GetRawResponse());
                }
                else
                {
                    BackupResourceConfigData current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    BackupResourceConfigData patch = new BackupResourceConfigData();
                    patch.Tags.ReplaceWith(tags);
                    return await UpdateAsync(patch, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        public virtual Response<BackupResourceConfigResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using DiagnosticScope scope = _backupResourceStorageConfigsNonCRRClientDiagnostics.CreateScope("BackupResourceConfigResource.SetTags");
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
                    HttpMessage message = _backupResourceStorageConfigsNonCRRRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, context);
                    Response result = Pipeline.ProcessMessage(message, context);
                    Response<BackupResourceConfigData> response = Response.FromValue(BackupResourceConfigData.FromResponse(result), result);
                    return Response.FromValue(new BackupResourceConfigResource(Client, response.Value), response.GetRawResponse());
                }
                else
                {
                    BackupResourceConfigData current = Get(cancellationToken: cancellationToken).Value.Data;
                    BackupResourceConfigData patch = new BackupResourceConfigData();
                    patch.Tags.ReplaceWith(tags);
                    return Update(patch, cancellationToken: cancellationToken);
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
        public virtual async Task<Response<BackupResourceConfigResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using DiagnosticScope scope = _backupResourceStorageConfigsNonCRRClientDiagnostics.CreateScope("BackupResourceConfigResource.RemoveTag");
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
                    HttpMessage message = _backupResourceStorageConfigsNonCRRRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, context);
                    Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    Response<BackupResourceConfigData> response = Response.FromValue(BackupResourceConfigData.FromResponse(result), result);
                    return Response.FromValue(new BackupResourceConfigResource(Client, response.Value), response.GetRawResponse());
                }
                else
                {
                    BackupResourceConfigData current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    BackupResourceConfigData patch = new BackupResourceConfigData();
                    foreach (KeyValuePair<string, string> tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags.Remove(key);
                    return await UpdateAsync(patch, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        public virtual Response<BackupResourceConfigResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using DiagnosticScope scope = _backupResourceStorageConfigsNonCRRClientDiagnostics.CreateScope("BackupResourceConfigResource.RemoveTag");
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
                    HttpMessage message = _backupResourceStorageConfigsNonCRRRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, context);
                    Response result = Pipeline.ProcessMessage(message, context);
                    Response<BackupResourceConfigData> response = Response.FromValue(BackupResourceConfigData.FromResponse(result), result);
                    return Response.FromValue(new BackupResourceConfigResource(Client, response.Value), response.GetRawResponse());
                }
                else
                {
                    BackupResourceConfigData current = Get(cancellationToken: cancellationToken).Value.Data;
                    BackupResourceConfigData patch = new BackupResourceConfigData();
                    foreach (KeyValuePair<string, string> tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags.Remove(key);
                    return Update(patch, cancellationToken: cancellationToken);
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
