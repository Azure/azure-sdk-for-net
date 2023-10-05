// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.SecurityCenter.Models;

namespace Azure.ResourceManager.SecurityCenter
{
    internal partial class SubscriptionGovernanceRulesRestOperations
    {
        private readonly TelemetryDetails _userAgent;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> Initializes a new instance of SubscriptionGovernanceRulesRestOperations. </summary>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="applicationId"> The application id to use for user agent. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pipeline"/> or <paramref name="apiVersion"/> is null. </exception>
        public SubscriptionGovernanceRulesRestOperations(HttpPipeline pipeline, string applicationId, Uri endpoint = null, string apiVersion = default)
        {
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("https://management.azure.com");
            _apiVersion = apiVersion ?? "2022-01-01-preview";
            _userAgent = new TelemetryDetails(GetType().Assembly, applicationId);
        }

        internal HttpMessage CreateGetRequest(string subscriptionId, string ruleId)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/providers/Microsoft.Security/governanceRules/", false);
            uri.AppendPath(ruleId, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Get a specific governanceRule for the requested scope by ruleId. </summary>
        /// <param name="subscriptionId"> Azure subscription ID. </param>
        /// <param name="ruleId"> The security GovernanceRule key - unique key for the standard GovernanceRule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/> or <paramref name="ruleId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> or <paramref name="ruleId"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<GovernanceRuleData>> GetAsync(string subscriptionId, string ruleId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(ruleId, nameof(ruleId));

            using var message = CreateGetRequest(subscriptionId, ruleId);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        GovernanceRuleData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = GovernanceRuleData.DeserializeGovernanceRuleData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((GovernanceRuleData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get a specific governanceRule for the requested scope by ruleId. </summary>
        /// <param name="subscriptionId"> Azure subscription ID. </param>
        /// <param name="ruleId"> The security GovernanceRule key - unique key for the standard GovernanceRule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/> or <paramref name="ruleId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> or <paramref name="ruleId"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<GovernanceRuleData> Get(string subscriptionId, string ruleId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(ruleId, nameof(ruleId));

            using var message = CreateGetRequest(subscriptionId, ruleId);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        GovernanceRuleData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = GovernanceRuleData.DeserializeGovernanceRuleData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((GovernanceRuleData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateCreateOrUpdateRequest(string subscriptionId, string ruleId, GovernanceRuleData data)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/providers/Microsoft.Security/governanceRules/", false);
            uri.AppendPath(ruleId, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(data);
            request.Content = content;
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Creates or update a security GovernanceRule on the given subscription. </summary>
        /// <param name="subscriptionId"> Azure subscription ID. </param>
        /// <param name="ruleId"> The security GovernanceRule key - unique key for the standard GovernanceRule. </param>
        /// <param name="data"> GovernanceRule over a subscription scope. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="ruleId"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> or <paramref name="ruleId"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<GovernanceRuleData>> CreateOrUpdateAsync(string subscriptionId, string ruleId, GovernanceRuleData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(ruleId, nameof(ruleId));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateOrUpdateRequest(subscriptionId, ruleId, data);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    {
                        GovernanceRuleData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = GovernanceRuleData.DeserializeGovernanceRuleData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Creates or update a security GovernanceRule on the given subscription. </summary>
        /// <param name="subscriptionId"> Azure subscription ID. </param>
        /// <param name="ruleId"> The security GovernanceRule key - unique key for the standard GovernanceRule. </param>
        /// <param name="data"> GovernanceRule over a subscription scope. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="ruleId"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> or <paramref name="ruleId"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<GovernanceRuleData> CreateOrUpdate(string subscriptionId, string ruleId, GovernanceRuleData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(ruleId, nameof(ruleId));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateOrUpdateRequest(subscriptionId, ruleId, data);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    {
                        GovernanceRuleData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = GovernanceRuleData.DeserializeGovernanceRuleData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDeleteRequest(string subscriptionId, string ruleId)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/providers/Microsoft.Security/governanceRules/", false);
            uri.AppendPath(ruleId, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Delete a GovernanceRule over a given scope. </summary>
        /// <param name="subscriptionId"> Azure subscription ID. </param>
        /// <param name="ruleId"> The security GovernanceRule key - unique key for the standard GovernanceRule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/> or <paramref name="ruleId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> or <paramref name="ruleId"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response> DeleteAsync(string subscriptionId, string ruleId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(ruleId, nameof(ruleId));

            using var message = CreateDeleteRequest(subscriptionId, ruleId);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Delete a GovernanceRule over a given scope. </summary>
        /// <param name="subscriptionId"> Azure subscription ID. </param>
        /// <param name="ruleId"> The security GovernanceRule key - unique key for the standard GovernanceRule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/> or <paramref name="ruleId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> or <paramref name="ruleId"/> is an empty string, and was expected to be non-empty. </exception>
        public Response Delete(string subscriptionId, string ruleId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(ruleId, nameof(ruleId));

            using var message = CreateDeleteRequest(subscriptionId, ruleId);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateRuleIdExecuteSingleSubscriptionRequest(string subscriptionId, string ruleId, ExecuteGovernanceRuleParams executeGovernanceRuleParams)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/providers/Microsoft.Security/governanceRules/", false);
            uri.AppendPath(ruleId, true);
            uri.AppendPath("/execute", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (executeGovernanceRuleParams != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(executeGovernanceRuleParams);
                request.Content = content;
            }
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Execute a security GovernanceRule on the given subscription. </summary>
        /// <param name="subscriptionId"> Azure subscription ID. </param>
        /// <param name="ruleId"> The security GovernanceRule key - unique key for the standard GovernanceRule. </param>
        /// <param name="executeGovernanceRuleParams"> GovernanceRule over a subscription scope. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/> or <paramref name="ruleId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> or <paramref name="ruleId"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response> RuleIdExecuteSingleSubscriptionAsync(string subscriptionId, string ruleId, ExecuteGovernanceRuleParams executeGovernanceRuleParams = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(ruleId, nameof(ruleId));

            using var message = CreateRuleIdExecuteSingleSubscriptionRequest(subscriptionId, ruleId, executeGovernanceRuleParams);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Execute a security GovernanceRule on the given subscription. </summary>
        /// <param name="subscriptionId"> Azure subscription ID. </param>
        /// <param name="ruleId"> The security GovernanceRule key - unique key for the standard GovernanceRule. </param>
        /// <param name="executeGovernanceRuleParams"> GovernanceRule over a subscription scope. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/> or <paramref name="ruleId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> or <paramref name="ruleId"/> is an empty string, and was expected to be non-empty. </exception>
        public Response RuleIdExecuteSingleSubscription(string subscriptionId, string ruleId, ExecuteGovernanceRuleParams executeGovernanceRuleParams = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(ruleId, nameof(ruleId));

            using var message = CreateRuleIdExecuteSingleSubscriptionRequest(subscriptionId, ruleId, executeGovernanceRuleParams);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateRuleIdExecuteSingleSecurityConnectorRequest(string subscriptionId, string resourceGroupName, string securityConnectorName, string ruleId, ExecuteGovernanceRuleParams executeGovernanceRuleParams)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Security/securityConnectors/", false);
            uri.AppendPath(securityConnectorName, true);
            uri.AppendPath("/providers/Microsoft.Security/governanceRules/", false);
            uri.AppendPath(ruleId, true);
            uri.AppendPath("/execute", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (executeGovernanceRuleParams != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(executeGovernanceRuleParams);
                request.Content = content;
            }
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Execute a security GovernanceRule on the given security connector. </summary>
        /// <param name="subscriptionId"> Azure subscription ID. </param>
        /// <param name="resourceGroupName"> The name of the resource group within the user&apos;s subscription. The name is case insensitive. </param>
        /// <param name="securityConnectorName"> The security connector name. </param>
        /// <param name="ruleId"> The security GovernanceRule key - unique key for the standard GovernanceRule. </param>
        /// <param name="executeGovernanceRuleParams"> GovernanceRule over a subscription scope. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="securityConnectorName"/> or <paramref name="ruleId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="securityConnectorName"/> or <paramref name="ruleId"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response> RuleIdExecuteSingleSecurityConnectorAsync(string subscriptionId, string resourceGroupName, string securityConnectorName, string ruleId, ExecuteGovernanceRuleParams executeGovernanceRuleParams = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(securityConnectorName, nameof(securityConnectorName));
            Argument.AssertNotNullOrEmpty(ruleId, nameof(ruleId));

            using var message = CreateRuleIdExecuteSingleSecurityConnectorRequest(subscriptionId, resourceGroupName, securityConnectorName, ruleId, executeGovernanceRuleParams);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Execute a security GovernanceRule on the given security connector. </summary>
        /// <param name="subscriptionId"> Azure subscription ID. </param>
        /// <param name="resourceGroupName"> The name of the resource group within the user&apos;s subscription. The name is case insensitive. </param>
        /// <param name="securityConnectorName"> The security connector name. </param>
        /// <param name="ruleId"> The security GovernanceRule key - unique key for the standard GovernanceRule. </param>
        /// <param name="executeGovernanceRuleParams"> GovernanceRule over a subscription scope. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="securityConnectorName"/> or <paramref name="ruleId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="securityConnectorName"/> or <paramref name="ruleId"/> is an empty string, and was expected to be non-empty. </exception>
        public Response RuleIdExecuteSingleSecurityConnector(string subscriptionId, string resourceGroupName, string securityConnectorName, string ruleId, ExecuteGovernanceRuleParams executeGovernanceRuleParams = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(securityConnectorName, nameof(securityConnectorName));
            Argument.AssertNotNullOrEmpty(ruleId, nameof(ruleId));

            using var message = CreateRuleIdExecuteSingleSecurityConnectorRequest(subscriptionId, resourceGroupName, securityConnectorName, ruleId, executeGovernanceRuleParams);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
