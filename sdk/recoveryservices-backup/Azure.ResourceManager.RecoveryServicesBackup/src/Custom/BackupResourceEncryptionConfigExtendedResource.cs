// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.RecoveryServicesBackup.Models;
using Azure.ResourceManager.Resources;

// NOTE: The following customization is intentionally retained for backward compatibility.
// This is a singleton resource which was not correctly generated as such, so we have to fix Update, AddTag, SetTags, and RemoveTag methods to make it backward compatible.
namespace Azure.ResourceManager.RecoveryServicesBackup
{
    /// <summary>
    /// A class representing a BackupResourceEncryptionConfigExtended along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="BackupResourceEncryptionConfigExtendedResource"/> from an instance of <see cref="ArmClient"/> using the GetResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource"/> using the GetBackupResourceEncryptionConfigExtended method.
    /// </summary>
    public partial class BackupResourceEncryptionConfigExtendedResource : ArmResource
    {
        /// <summary>
        /// Updates Vault encryption config.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupEncryptionConfigs/backupResourceEncryptionConfig</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BackupResourceEncryptionConfigs_Update</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-02-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="BackupResourceEncryptionConfigExtendedResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> Vault encryption input config request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual async Task<ArmOperation> UpdateAsync(WaitUntil waitUntil, BackupResourceEncryptionConfigExtendedCreateOrUpdateContent content, CancellationToken cancellationToken = default)
            => await CreateOrUpdateAsync(waitUntil, content, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Updates Vault encryption config.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupEncryptionConfigs/backupResourceEncryptionConfig</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BackupResourceEncryptionConfigs_Update</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-02-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="BackupResourceEncryptionConfigExtendedResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> Vault encryption input config request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual ArmOperation Update(WaitUntil waitUntil, BackupResourceEncryptionConfigExtendedCreateOrUpdateContent content, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, content, cancellationToken);

        /// <summary> Add a tag to the current resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual async Task<Response<BackupResourceEncryptionConfigExtendedResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using DiagnosticScope scope = _backupResourceEncryptionConfigsClientDiagnostics.CreateScope("BackupResourceEncryptionConfigExtendedResource.AddTag");
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
                    HttpMessage message = _backupResourceEncryptionConfigsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, context);
                    Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    Response<BackupResourceEncryptionConfigExtendedData> response = Response.FromValue(BackupResourceEncryptionConfigExtendedData.FromResponse(result), result);
                    return Response.FromValue(new BackupResourceEncryptionConfigExtendedResource(Client, response.Value), response.GetRawResponse());
                }
                else
                {
                    BackupResourceEncryptionConfigExtendedData current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    current.Tags[key] = value;
                    ArmOperation result = await this.UpdateAsync(WaitUntil.Completed, ToContent(current), cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(new BackupResourceEncryptionConfigExtendedResource(Client, current), result.GetRawResponse());
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
        public virtual Response<BackupResourceEncryptionConfigExtendedResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using DiagnosticScope scope = _backupResourceEncryptionConfigsClientDiagnostics.CreateScope("BackupResourceEncryptionConfigExtendedResource.AddTag");
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
                    HttpMessage message = _backupResourceEncryptionConfigsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, context);
                    Response result = Pipeline.ProcessMessage(message, context);
                    Response<BackupResourceEncryptionConfigExtendedData> response = Response.FromValue(BackupResourceEncryptionConfigExtendedData.FromResponse(result), result);
                    return Response.FromValue(new BackupResourceEncryptionConfigExtendedResource(Client, response.Value), response.GetRawResponse());
                }
                else
                {
                    BackupResourceEncryptionConfigExtendedData current = Get(cancellationToken: cancellationToken).Value.Data;
                    current.Tags[key] = value;
                    ArmOperation result = this.Update(WaitUntil.Completed, ToContent(current), cancellationToken: cancellationToken);
                    return Response.FromValue(new BackupResourceEncryptionConfigExtendedResource(Client, current), result.GetRawResponse());
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
        public virtual async Task<Response<BackupResourceEncryptionConfigExtendedResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using DiagnosticScope scope = _backupResourceEncryptionConfigsClientDiagnostics.CreateScope("BackupResourceEncryptionConfigExtendedResource.SetTags");
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
                    HttpMessage message = _backupResourceEncryptionConfigsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, context);
                    Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    Response<BackupResourceEncryptionConfigExtendedData> response = Response.FromValue(BackupResourceEncryptionConfigExtendedData.FromResponse(result), result);
                    return Response.FromValue(new BackupResourceEncryptionConfigExtendedResource(Client, response.Value), response.GetRawResponse());
                }
                else
                {
                    BackupResourceEncryptionConfigExtendedData current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    current.Tags.ReplaceWith(tags);
                    ArmOperation result = await this.UpdateAsync(WaitUntil.Completed, ToContent(current), cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(new BackupResourceEncryptionConfigExtendedResource(Client, current), result.GetRawResponse());
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
        public virtual Response<BackupResourceEncryptionConfigExtendedResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using DiagnosticScope scope = _backupResourceEncryptionConfigsClientDiagnostics.CreateScope("BackupResourceEncryptionConfigExtendedResource.SetTags");
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
                    HttpMessage message = _backupResourceEncryptionConfigsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, context);
                    Response result = Pipeline.ProcessMessage(message, context);
                    Response<BackupResourceEncryptionConfigExtendedData> response = Response.FromValue(BackupResourceEncryptionConfigExtendedData.FromResponse(result), result);
                    return Response.FromValue(new BackupResourceEncryptionConfigExtendedResource(Client, response.Value), response.GetRawResponse());
                }
                else
                {
                    BackupResourceEncryptionConfigExtendedData current = Get(cancellationToken: cancellationToken).Value.Data;
                    current.Tags.ReplaceWith(tags);
                    ArmOperation result = this.Update(WaitUntil.Completed, ToContent(current), cancellationToken: cancellationToken);
                    return Response.FromValue(new BackupResourceEncryptionConfigExtendedResource(Client, current), result.GetRawResponse());
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
        public virtual async Task<Response<BackupResourceEncryptionConfigExtendedResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using DiagnosticScope scope = _backupResourceEncryptionConfigsClientDiagnostics.CreateScope("BackupResourceEncryptionConfigExtendedResource.RemoveTag");
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
                    HttpMessage message = _backupResourceEncryptionConfigsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, context);
                    Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    Response<BackupResourceEncryptionConfigExtendedData> response = Response.FromValue(BackupResourceEncryptionConfigExtendedData.FromResponse(result), result);
                    return Response.FromValue(new BackupResourceEncryptionConfigExtendedResource(Client, response.Value), response.GetRawResponse());
                }
                else
                {
                    BackupResourceEncryptionConfigExtendedData current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    current.Tags.Remove(key);
                    ArmOperation result = await this.UpdateAsync(WaitUntil.Completed, ToContent(current), cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(new BackupResourceEncryptionConfigExtendedResource(Client, current), result.GetRawResponse());
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
        public virtual Response<BackupResourceEncryptionConfigExtendedResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using DiagnosticScope scope = _backupResourceEncryptionConfigsClientDiagnostics.CreateScope("BackupResourceEncryptionConfigExtendedResource.RemoveTag");
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
                    HttpMessage message = _backupResourceEncryptionConfigsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, context);
                    Response result = Pipeline.ProcessMessage(message, context);
                    Response<BackupResourceEncryptionConfigExtendedData> response = Response.FromValue(BackupResourceEncryptionConfigExtendedData.FromResponse(result), result);
                    return Response.FromValue(new BackupResourceEncryptionConfigExtendedResource(Client, response.Value), response.GetRawResponse());
                }
                else
                {
                    BackupResourceEncryptionConfigExtendedData current = Get(cancellationToken: cancellationToken).Value.Data;
                    current.Tags.Remove(key);
                    ArmOperation result = this.Update(WaitUntil.Completed, ToContent(current), cancellationToken: cancellationToken);
                    return Response.FromValue(new BackupResourceEncryptionConfigExtendedResource(Client, current), result.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal BackupResourceEncryptionConfigExtendedCreateOrUpdateContent ToContent(BackupResourceEncryptionConfigExtendedData data)
        {
            return new BackupResourceEncryptionConfigExtendedCreateOrUpdateContent(data.Id, data.Name, data.ResourceType, data.SystemData, null, data.Location, data.Properties, data.Tags, data.ETag);
        }
    }
}
