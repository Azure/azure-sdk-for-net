﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.MachineLearning.WebServices.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Management.MachineLearning.WebServices
{
    /// <summary>
    /// This class was added as a temporary fix for the AutoRest generated client code, which does not handle
    /// the request id for async operations properly. Basically, if an async operation fails during execution,
    /// the AutoRest library will resturn an exception with the request id of the latest GET call that was
    /// polling for the async operation status. This is not desired, as all logs for the execution of the 
    /// operation and stored under the request id of the initial PUT/PATCH/DELETE call that initiated the 
    /// operation.
    /// 
    /// Here, we capture that request id after the initial async call, and return it with the final operation
    /// result or any CloudException thrown during execution.
    /// </summary>
    internal partial class WebServicesOperations
    {
        /// <summary>
        /// Create a new Azure ML web service or update an existing one.
        /// </summary>
        /// <param name='createOrUpdatePayload'>
        /// The payload to create or update the Azure ML web service.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Name of the resource group.
        /// </param>
        /// <param name='webServiceName'>
        /// The Azure ML web service name which you want to reach.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<AzureOperationResponse<WebService>> CreateOrUpdateWebServiceWithProperRequestIdAsync(WebService createOrUpdatePayload, string resourceGroupName, string webServiceName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            AzureOperationResponse<WebService> _response = await this.BeginCreateOrUpdateWithHttpMessagesAsync(
                resourceGroupName, webServiceName, createOrUpdatePayload, null, cancellationToken);
            try
            {
                AzureOperationResponse<WebService> operationResult = await this.Client.GetPutOrPatchOperationResultAsync(_response, customHeaders, cancellationToken);
                operationResult.RequestId = _response.RequestId;
                return operationResult;
            }
            catch (CloudException cloudEx)
            {
                cloudEx.RequestId = _response.RequestId;
                throw;
            }
        }
        
        /// <summary>
        /// Patch an existing Azure ML web service resource.
        /// </summary>
        /// <param name='patchPayload'>
        /// The payload to patch the Azure ML web service with.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Name of the resource group.
        /// </param>
        /// <param name='webServiceName'>
        /// The Azure ML web service name which you want to reach.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<AzureOperationResponse<WebService>> PatchWebServiceWithProperRequestIdAsync(WebService patchPayload, string resourceGroupName, string webServiceName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            AzureOperationResponse<WebService> _response = await BeginPatchWithHttpMessagesAsync(
                resourceGroupName, webServiceName, patchPayload, customHeaders, cancellationToken);
            try
            {
                AzureOperationResponse<WebService> operationResult = await this.Client.GetPutOrPatchOperationResultAsync(_response, customHeaders, cancellationToken);
                operationResult.RequestId = _response.RequestId;
                return operationResult;
            }
            catch (CloudException cloudEx)
            {
                cloudEx.RequestId = _response.RequestId;
                throw;
            }
        }

        /// <summary>
        /// Remove an existing Azure ML web service.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Name of the resource group.
        /// </param>
        /// <param name='webServiceName'>
        /// The Azure ML web service name which you want to reach.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<AzureOperationResponse> RemoveWebServiceWitProperRequestIdAsync(string resourceGroupName, string webServiceName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            AzureOperationResponse _response = await BeginRemoveWithHttpMessagesAsync(
                resourceGroupName, webServiceName, customHeaders, cancellationToken);
            try
            {
                AzureOperationResponse operationResult = await this.Client.GetPostOrDeleteOperationResultAsync(_response, customHeaders, cancellationToken);
                operationResult.RequestId = _response.RequestId;
                return operationResult;
            }
            catch (CloudException cloudEx)
            {
                cloudEx.RequestId = _response.RequestId;
                throw;
            }
        }

        /// <summary>
        /// Create web service properties for a specific region.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Name of the resource group.
        /// </param>
        /// <param name='webServiceName'>
        /// The Azure ML web service name which you want to reach.
        /// </param>
        /// <param name='region'>
        /// The new region of Azure ML web service properties 
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<AsyncOperationStatus> CreateRegionalPropertiesWithProperRequestIdAsync(string resourceGroupName, string webServiceName, string region, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var _response = await BeginCreateRegionalPropertiesWithHttpMessagesAsync(
                resourceGroupName, webServiceName, region, customHeaders, cancellationToken);
            try
            {
                var operationResult = await this.Client.GetPostOrDeleteOperationResultAsync(_response, customHeaders, cancellationToken);
                operationResult.RequestId = _response.RequestId;
                return operationResult.Body;
            }
            catch (CloudException cloudEx)
            {
                cloudEx.RequestId = _response.RequestId;
                throw;
            }
        }
    }
}
