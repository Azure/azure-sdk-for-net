// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.BotService.Customizations;
using Microsoft.Azure.Management.BotService.Models;
using Microsoft.Azure.Management.BotService.Resources;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Management.BotService
{
    /// <summary>
    /// Abstraction that encapsulates the generated BotServicesOperations, and adds additional
    /// logic around bot creation. 
    /// </summary>
    internal class CustomBotsOperations : IBotsOperations
    {
        private readonly IBotsOperations innerBotServicesOperations;
        private readonly AzureBotServiceClient client;

        internal CustomBotsOperations(IBotsOperations inner, AzureBotServiceClient client)
        {
            this.innerBotServicesOperations = inner;
            this.client = client;
        }

        public AzureBotServiceClient Client => client;

        /// <summary>
        /// Creates a Bot Service. Bot Service is a resource group wide resource type.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group within the user's subscription.
        /// </param>
        /// <param name='resourceName'>
        /// The name of the Bot resource.
        /// </param>
        /// <param name='parameters'>
        /// The parameters to provide for the created bot.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <return>
        /// A response object containing the response body and response headers.
        /// </return>
        public async Task<AzureOperationResponse<Bot>> CreateWithHttpMessagesAsync(string resourceGroupName, string resourceName, Bot parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (parameters.Kind == Kind.Bot || parameters.Kind == Kind.Function)
            {
                throw new ArgumentException(BotServiceErrorMessages.KindShouldUseSpecificMethod, nameof(parameters.Kind));
            }

            return await innerBotServicesOperations
                .CreateWithHttpMessagesAsync(resourceGroupName, resourceName, parameters, customHeaders, cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes a Bot Service from the resource group.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group within the user's subscription.
        /// </param>
        /// <param name='resourceName'>
        /// The name of the Bot resource.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <return>
        /// A response object containing the response body and response headers.
        /// </return>
        public async Task<AzureOperationResponse> DeleteWithHttpMessagesAsync(string resourceGroupName, string resourceName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await innerBotServicesOperations
                .DeleteWithHttpMessagesAsync(resourceGroupName, resourceName, customHeaders, cancellationToken)
                .ConfigureAwait(false);
        }

        public Task<AzureOperationResponse<CheckNameAvailabilityResponseBody>> GetCheckNameAvailabilityWithHttpMessagesAsync(CheckNameAvailabilityRequestBody parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a BotService specified by the parameters.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group within the user's subscription.
        /// </param>
        /// <param name='resourceName'>
        /// The name of the Bot resource.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <return>
        /// A response object containing the response body and response headers.
        /// </return>
        public async Task<AzureOperationResponse<Bot>> GetWithHttpMessagesAsync(string resourceGroupName, string resourceName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await innerBotServicesOperations
                .GetWithHttpMessagesAsync(resourceGroupName, resourceName, customHeaders, cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Returns all the resources of a particular type belonging to a resource
        /// group
        /// </summary>
        /// <param name='nextPageLink'>
        /// The NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <returns>
        /// A response object
        /// </returns>
        public async Task<AzureOperationResponse<IPage<Bot>>> ListByResourceGroupNextWithHttpMessagesAsync(string nextPageLink, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await innerBotServicesOperations
                .ListByResourceGroupNextWithHttpMessagesAsync(nextPageLink, customHeaders, cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Returns all the resources of a particular type belonging to a resource
        /// group
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group within the user's subscription.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <return>
        /// A response object containing the response body and response headers.
        /// </return>
        public async Task<AzureOperationResponse<IPage<Bot>>> ListByResourceGroupWithHttpMessagesAsync(string resourceGroupName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await innerBotServicesOperations
                .ListByResourceGroupWithHttpMessagesAsync(resourceGroupName, customHeaders, cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<AzureOperationResponse<IPage<Bot>>> ListNextWithHttpMessagesAsync(string nextPageLink, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await innerBotServicesOperations
                .ListNextWithHttpMessagesAsync(nextPageLink, customHeaders, cancellationToken).ConfigureAwait(false);
        }

        public async Task<AzureOperationResponse<IPage<Bot>>> ListWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await innerBotServicesOperations.ListWithHttpMessagesAsync(customHeaders, cancellationToken);
        }

        /// <summary>
        /// Updates a Bot Service
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group within the user's subscription.
        /// </param>
        /// <param name='resourceName'>
        /// The name of the Bot resource.
        /// </param>
        /// <param name='location'>
        /// Specifies the location of the resource.
        /// </param>
        /// <param name='tags'>
        /// Contains resource tags defined as key/value pairs.
        /// </param>
        /// <param name='sku'>
        /// Gets or sets the SKU of the resource.
        /// </param>
        /// <param name='kind'>
        /// Required. Gets or sets the Kind of the resource. Possible values include:
        /// 'sdk', 'designer', 'bot', 'function'
        /// </param>
        /// <param name='etag'>
        /// Entity Tag
        /// </param>
        /// <param name='properties'>
        /// The set of properties specific to bot resource
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <return>
        /// A response object containing the response body and response headers.
        /// </return>
        public async Task<AzureOperationResponse<Bot>> UpdateWithHttpMessagesAsync(string resourceGroupName, string resourceName, string location = null, IDictionary<string, string> tags = null, Models.Sku sku = null, string kind = null, string etag = null, BotProperties properties = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await innerBotServicesOperations
                .UpdateWithHttpMessagesAsync(resourceGroupName, resourceName,location, tags, sku, kind, etag, properties, customHeaders, cancellationToken)
                .ConfigureAwait(false);
        }
    }
}