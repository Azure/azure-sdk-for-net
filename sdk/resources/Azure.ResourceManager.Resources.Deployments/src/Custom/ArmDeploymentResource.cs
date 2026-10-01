// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.ManagementGroups;
using Azure.ResourceManager.Resources.Deployments.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources.Deployments
{
    public partial class ArmDeploymentResource : ArmResource
    {
        // Preserve tag helpers shipped in the GA API. New resources with incompatible PUT body and
        // resource data types do not generate these methods.

        /// <summary> Add a tag to the current resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual async Task<Response<ArmDeploymentResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using DiagnosticScope scope = _armDeploymentsClientDiagnostics.CreateScope("ArmDeploymentResource.AddTag");
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
                    Core.HttpMessage message = _armDeploymentsRestClient.CreateGetAtScopeRequest(Id.Parent.ToString(), Id.Name, context);
                    Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    Response<ArmDeploymentData> response = Response.FromValue(ArmDeploymentData.FromResponse(result), result);
                    return Response.FromValue(new ArmDeploymentResource(Client, response.Value), response.GetRawResponse());
                }
                else
                {
                    ArmDeploymentData current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    current.Tags[key] = value;
                    ArmOperation<ArmDeploymentResource> result = await UpdateAsync(WaitUntil.Completed, current, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        public virtual Response<ArmDeploymentResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using DiagnosticScope scope = _armDeploymentsClientDiagnostics.CreateScope("ArmDeploymentResource.AddTag");
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
                    Core.HttpMessage message = _armDeploymentsRestClient.CreateGetAtScopeRequest(Id.Parent.ToString(), Id.Name, context);
                    Response result = Pipeline.ProcessMessage(message, context);
                    Response<ArmDeploymentData> response = Response.FromValue(ArmDeploymentData.FromResponse(result), result);
                    return Response.FromValue(new ArmDeploymentResource(Client, response.Value), response.GetRawResponse());
                }
                else
                {
                    ArmDeploymentData current = Get(cancellationToken: cancellationToken).Value.Data;
                    current.Tags[key] = value;
                    ArmOperation<ArmDeploymentResource> result = Update(WaitUntil.Completed, current, cancellationToken: cancellationToken);
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
        public virtual async Task<Response<ArmDeploymentResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using DiagnosticScope scope = _armDeploymentsClientDiagnostics.CreateScope("ArmDeploymentResource.SetTags");
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
                    Core.HttpMessage message = _armDeploymentsRestClient.CreateGetAtScopeRequest(Id.Parent.ToString(), Id.Name, context);
                    Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    Response<ArmDeploymentData> response = Response.FromValue(ArmDeploymentData.FromResponse(result), result);
                    return Response.FromValue(new ArmDeploymentResource(Client, response.Value), response.GetRawResponse());
                }
                else
                {
                    ArmDeploymentData current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    current.Tags.ReplaceWith(tags);
                    ArmOperation<ArmDeploymentResource> result = await UpdateAsync(WaitUntil.Completed, current, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        public virtual Response<ArmDeploymentResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using DiagnosticScope scope = _armDeploymentsClientDiagnostics.CreateScope("ArmDeploymentResource.SetTags");
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
                    Core.HttpMessage message = _armDeploymentsRestClient.CreateGetAtScopeRequest(Id.Parent.ToString(), Id.Name, context);
                    Response result = Pipeline.ProcessMessage(message, context);
                    Response<ArmDeploymentData> response = Response.FromValue(ArmDeploymentData.FromResponse(result), result);
                    return Response.FromValue(new ArmDeploymentResource(Client, response.Value), response.GetRawResponse());
                }
                else
                {
                    ArmDeploymentData current = Get(cancellationToken: cancellationToken).Value.Data;
                    current.Tags.ReplaceWith(tags);
                    ArmOperation<ArmDeploymentResource> result = Update(WaitUntil.Completed, current, cancellationToken: cancellationToken);
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
        public virtual async Task<Response<ArmDeploymentResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using DiagnosticScope scope = _armDeploymentsClientDiagnostics.CreateScope("ArmDeploymentResource.RemoveTag");
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
                    Core.HttpMessage message = _armDeploymentsRestClient.CreateGetAtScopeRequest(Id.Parent.ToString(), Id.Name, context);
                    Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    Response<ArmDeploymentData> response = Response.FromValue(ArmDeploymentData.FromResponse(result), result);
                    return Response.FromValue(new ArmDeploymentResource(Client, response.Value), response.GetRawResponse());
                }
                else
                {
                    ArmDeploymentData current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    current.Tags.Remove(key);
                    ArmOperation<ArmDeploymentResource> result = await UpdateAsync(WaitUntil.Completed, current, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        public virtual Response<ArmDeploymentResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using DiagnosticScope scope = _armDeploymentsClientDiagnostics.CreateScope("ArmDeploymentResource.RemoveTag");
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
                    Core.HttpMessage message = _armDeploymentsRestClient.CreateGetAtScopeRequest(Id.Parent.ToString(), Id.Name, context);
                    Response result = Pipeline.ProcessMessage(message, context);
                    Response<ArmDeploymentData> response = Response.FromValue(ArmDeploymentData.FromResponse(result), result);
                    return Response.FromValue(new ArmDeploymentResource(Client, response.Value), response.GetRawResponse());
                }
                else
                {
                    ArmDeploymentData current = Get(cancellationToken: cancellationToken).Value.Data;
                    current.Tags.Remove(key);
                    ArmOperation<ArmDeploymentResource> result = Update(WaitUntil.Completed, current, cancellationToken: cancellationToken);
                    return Response.FromValue(result.Value, result.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // This operation is only used for tags operations: AddTag, SetTags, RemoveTag.
        /// <summary>
        /// Update a ArmDeployment.
        /// </summary>
        internal virtual async Task<ArmOperation<ArmDeploymentResource>> UpdateAsync(WaitUntil waitUntil, ArmDeploymentData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));
            ArmDeploymentContent content = new ArmDeploymentContent(data.Location, new ArmDeploymentProperties(data.Properties.Mode.Value), data.Tags, null, null);
            return await UpdateAsync(waitUntil, content, cancellationToken).ConfigureAwait(false);
        }

        // This operation is only used for tags operations: AddTag, SetTags, RemoveTag.
        /// <summary>
        /// Update a ArmDeployment.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> Additional parameters supplied to the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        internal virtual ArmOperation<ArmDeploymentResource> Update(WaitUntil waitUntil, ArmDeploymentData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));
            ArmDeploymentContent content = new ArmDeploymentContent(data.Location, new ArmDeploymentProperties(data.Properties.Mode.Value), data.Tags, null, null);
            return Update(waitUntil, content, cancellationToken);
        }

        /// <summary>
        /// Returns changes that will be made by the deployment if executed at the scope of the tenant group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Resources/deployments/{deploymentName}/whatIf</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_WhatIfAtTenantScope</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ArmDeploymentResource"/></description>
        /// </item>
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/providers/Microsoft.Resources/deployments/{deploymentName}/whatIf</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_WhatIfAtManagementGroupScope</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ArmDeploymentResource"/></description>
        /// </item>
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Resources/deployments/{deploymentName}/whatIf</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_WhatIfAtSubscriptionScope</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ArmDeploymentResource"/></description>
        /// </item>
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Resources/deployments/{deploymentName}/whatIf</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_WhatIf</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ArmDeploymentResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> Parameters to validate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        // In previous versions, all What-If operations were implemented as part of ArmDeploymentResource.
        public virtual async Task<ArmOperation<WhatIfOperationResult>> WhatIfAsync(WaitUntil waitUntil, ArmDeploymentWhatIfContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = _armDeploymentsClientDiagnostics.CreateScope("ArmDeploymentResource.WhatIf");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                if (Id.Parent.ResourceType == TenantResource.ResourceType)
                {
                    Core.HttpMessage message = _armDeploymentsRestClient.CreateWhatIfAtTenantScopeRequest(Id.Name, ArmDeploymentWhatIfContent.ToRequestContent(content), context);
                    Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    ResourcesArmOperation<WhatIfOperationResult> operation = new ResourcesArmOperation<WhatIfOperationResult>(
                        new WhatIfOperationResultOperationSource(),
                        _armDeploymentsClientDiagnostics,
                        Pipeline,
                        message.Request,
                        response,
                        OperationFinalStateVia.Location);
                    if (waitUntil == WaitUntil.Completed)
                    {
                        await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                    }
                    return operation;
                }
                else if (Id.Parent.ResourceType == ManagementGroupResource.ResourceType)
                {
                    Core.HttpMessage message = _armDeploymentsRestClient.CreateWhatIfAtManagementGroupScopeRequest(Id.Parent.Name, Id.Name, ArmDeploymentWhatIfContent.ToRequestContent(content), context);
                    Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    ResourcesArmOperation<WhatIfOperationResult> operation = new ResourcesArmOperation<WhatIfOperationResult>(
                        new WhatIfOperationResultOperationSource(),
                        _armDeploymentsClientDiagnostics,
                        Pipeline,
                        message.Request,
                        response,
                        OperationFinalStateVia.Location);
                    if (waitUntil == WaitUntil.Completed)
                    {
                        await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                    }
                    return operation;
                }
                else if (Id.Parent.ResourceType == SubscriptionResource.ResourceType)
                {
                    Core.HttpMessage message = _armDeploymentsRestClient.CreateWhatIfAtSubscriptionScopeRequest(Id.SubscriptionId, Id.Name, ArmDeploymentWhatIfContent.ToRequestContent(content), context);
                    Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    ResourcesArmOperation<WhatIfOperationResult> operation = new ResourcesArmOperation<WhatIfOperationResult>(
                        new WhatIfOperationResultOperationSource(),
                        _armDeploymentsClientDiagnostics,
                        Pipeline,
                        message.Request,
                        response,
                        OperationFinalStateVia.Location);
                    if (waitUntil == WaitUntil.Completed)
                    {
                        await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                    }
                    return operation;
                }
                else if (Id.Parent.ResourceType == ResourceGroupResource.ResourceType)
                {
                    Core.HttpMessage message = _armDeploymentsRestClient.CreateWhatIfAtResourceRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, ArmDeploymentWhatIfContent.ToRequestContent(content), context);
                    Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    ResourcesArmOperation<WhatIfOperationResult> operation = new ResourcesArmOperation<WhatIfOperationResult>(
                        new WhatIfOperationResultOperationSource(),
                        _armDeploymentsClientDiagnostics,
                        Pipeline,
                        message.Request,
                        response,
                        OperationFinalStateVia.Location);
                    if (waitUntil == WaitUntil.Completed)
                    {
                        await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                    }
                    return operation;
                }
                else
                {
                    throw new InvalidOperationException($"{Id.Parent.ResourceType} is not supported here");
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Returns changes that will be made by the deployment if executed at the scope of the tenant group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Resources/deployments/{deploymentName}/whatIf</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_WhatIfAtTenantScope</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ArmDeploymentResource"/></description>
        /// </item>
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/providers/Microsoft.Resources/deployments/{deploymentName}/whatIf</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_WhatIfAtManagementGroupScope</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ArmDeploymentResource"/></description>
        /// </item>
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Resources/deployments/{deploymentName}/whatIf</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_WhatIfAtSubscriptionScope</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ArmDeploymentResource"/></description>
        /// </item>
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Resources/deployments/{deploymentName}/whatIf</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_WhatIf</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ArmDeploymentResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> Parameters to validate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        // In previous versions, all What-If operations were implemented as part of ArmDeploymentResource.
        public virtual ArmOperation<WhatIfOperationResult> WhatIf(WaitUntil waitUntil, ArmDeploymentWhatIfContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = _armDeploymentsClientDiagnostics.CreateScope("ArmDeploymentResource.WhatIf");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                if (Id.Parent.ResourceType == TenantResource.ResourceType)
                {
                    Core.HttpMessage message = _armDeploymentsRestClient.CreateWhatIfAtTenantScopeRequest(Id.Name, ArmDeploymentWhatIfContent.ToRequestContent(content), context);
                    Response response = Pipeline.ProcessMessage(message, context);
                    ResourcesArmOperation<WhatIfOperationResult> operation = new ResourcesArmOperation<WhatIfOperationResult>(
                        new WhatIfOperationResultOperationSource(),
                        _armDeploymentsClientDiagnostics,
                        Pipeline,
                        message.Request,
                        response,
                        OperationFinalStateVia.Location);
                    if (waitUntil == WaitUntil.Completed)
                    {
                        operation.WaitForCompletion(cancellationToken);
                    }
                    return operation;
                }
                else if (Id.Parent.ResourceType == ManagementGroupResource.ResourceType)
                {
                    Core.HttpMessage message = _armDeploymentsRestClient.CreateWhatIfAtManagementGroupScopeRequest(Id.Parent.Name, Id.Name, ArmDeploymentWhatIfContent.ToRequestContent(content), context);
                    Response response = Pipeline.ProcessMessage(message, context);
                    ResourcesArmOperation<WhatIfOperationResult> operation = new ResourcesArmOperation<WhatIfOperationResult>(
                        new WhatIfOperationResultOperationSource(),
                        _armDeploymentsClientDiagnostics,
                        Pipeline,
                        message.Request,
                        response,
                        OperationFinalStateVia.Location);
                    if (waitUntil == WaitUntil.Completed)
                    {
                        operation.WaitForCompletion(cancellationToken);
                    }
                    return operation;
                }
                else if (Id.Parent.ResourceType == SubscriptionResource.ResourceType)
                {
                    Core.HttpMessage message = _armDeploymentsRestClient.CreateWhatIfAtSubscriptionScopeRequest(Id.SubscriptionId, Id.Name, ArmDeploymentWhatIfContent.ToRequestContent(content), context);
                    Response response = Pipeline.ProcessMessage(message, context);
                    ResourcesArmOperation<WhatIfOperationResult> operation = new ResourcesArmOperation<WhatIfOperationResult>(
                        new WhatIfOperationResultOperationSource(),
                        _armDeploymentsClientDiagnostics,
                        Pipeline,
                        message.Request,
                        response,
                        OperationFinalStateVia.Location);
                    if (waitUntil == WaitUntil.Completed)
                    {
                        operation.WaitForCompletion(cancellationToken);
                    }
                    return operation;
                }
                else if (Id.Parent.ResourceType == ResourceGroupResource.ResourceType)
                {
                    Core.HttpMessage message = _armDeploymentsRestClient.CreateWhatIfAtResourceRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, ArmDeploymentWhatIfContent.ToRequestContent(content), context);
                    Response response = Pipeline.ProcessMessage(message, context);
                    ResourcesArmOperation<WhatIfOperationResult> operation = new ResourcesArmOperation<WhatIfOperationResult>(
                        new WhatIfOperationResultOperationSource(),
                        _armDeploymentsClientDiagnostics,
                        Pipeline,
                        message.Request,
                        response,
                        OperationFinalStateVia.Location);
                    if (waitUntil == WaitUntil.Completed)
                    {
                        operation.WaitForCompletion(cancellationToken);
                    }
                    return operation;
                }
                else
                {
                    throw new InvalidOperationException($"{Id.Parent.ResourceType} is not supported here");
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
