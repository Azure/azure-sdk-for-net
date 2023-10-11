// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.Pipeline;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.Messages
{
    /// <summary>
    /// The Azure Communication Services Message Template client.
    /// </summary>
    public class MessageTemplateClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly TemplateV2RestClient _templateV2RestClient;
        private readonly StreamRestClient _streamRestClient;

        #region public constructors

        /// <summary>
        /// Initializes a new instance of <see cref="MessageTemplateClient"/>
        /// </summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        public MessageTemplateClient(string connectionString)
            : this(
                ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                new CommunicationMessagesClientOptions())
        {
        }

        /// <summary> Initializes a new instance of <see cref="MessageTemplateClient"/>.</summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        /// <param name="options">Client options exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public MessageTemplateClient(string connectionString, CommunicationMessagesClientOptions options)
            : this(
                ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                options ?? new CommunicationMessagesClientOptions())
        {
        }

        /// <summary> Initializes a new instance of <see cref="MessageTemplateClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="keyCredential">The <see cref="AzureKeyCredential"/> used to authenticate requests.</param>
        /// <param name="options">Client options exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public MessageTemplateClient(Uri endpoint, AzureKeyCredential keyCredential, CommunicationMessagesClientOptions options = default)
             : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(keyCredential, nameof(keyCredential)),
                options ?? new CommunicationMessagesClientOptions())
        {
        }

        #endregion

        #region private constructors
        private MessageTemplateClient(ConnectionString connectionString, CommunicationMessagesClientOptions options)
           : this(new Uri(connectionString.GetRequired("endpoint")), options.BuildHttpPipeline(connectionString), options)
        { }

        private MessageTemplateClient(string endpoint, TokenCredential tokenCredential, CommunicationMessagesClientOptions options)
            : this(new Uri(endpoint), options.BuildHttpPipeline(tokenCredential), options)
        { }

        private MessageTemplateClient(string endpoint, AzureKeyCredential keyCredential, CommunicationMessagesClientOptions options)
            : this(new Uri(endpoint), options.BuildHttpPipeline(keyCredential), options)
        { }

        private MessageTemplateClient(Uri endpoint, HttpPipeline httpPipeline, CommunicationMessagesClientOptions options)
        {
            _clientDiagnostics = new ClientDiagnostics(options);
            _templateV2RestClient = new TemplateV2RestClient(_clientDiagnostics, httpPipeline, endpoint, options.ApiVersion);
            _streamRestClient = new StreamRestClient(_clientDiagnostics, httpPipeline, endpoint, options.ApiVersion);
        }

        #endregion

        /// <summary>Initializes a new instance of <see cref="MessageTemplateClient"/> for mocking.</summary>
        protected MessageTemplateClient()
        {
            _clientDiagnostics = null!;
            _templateV2RestClient = null!;
            _streamRestClient = null!;
        }

        #region List Templates Operations
        /// <summary> List all templates for given ACS channel asynchronously. </summary>
        /// <param name="channelRegistrationId"> The registration ID of the channel. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual AsyncPageable<MessageTemplateItem> GetTemplatesAsync(string channelRegistrationId, CancellationToken cancellationToken = default)
        {
            _ = channelRegistrationId ?? throw new ArgumentNullException(nameof(channelRegistrationId));

            async Task<Page<MessageTemplateItem>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MessageTemplateClient)}.{nameof(GetTemplates)}");
                scope.Start();

                try
                {
                    Response<ListTemplatesResponse> response = await _templateV2RestClient.ListAsync(new Guid(channelRegistrationId), pageSizeHint, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(x => new MessageTemplateItem(x)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<MessageTemplateItem>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MessageTemplateClient)}.{nameof(GetTemplates)}");
                scope.Start();

                try
                {
                    Response<ListTemplatesResponse> response = await _templateV2RestClient.ListNextPageAsync(nextLink, new Guid(channelRegistrationId), pageSizeHint, cancellationToken).ConfigureAwait(false);
                    if (response.Value.Value == null || response.Value.Value.Count == 0)
                    {
                        return Page.FromValues(new List<MessageTemplateItem>(), null, response.GetRawResponse());
                    }
                    return Page.FromValues(response.Value.Value.Select(x => new MessageTemplateItem(x)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> List all templates for given ACS channel. </summary>
        /// <param name="channelRegistrationId"> The registration ID of the channel. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<MessageTemplateItem> GetTemplates(string channelRegistrationId, CancellationToken cancellationToken = default)
        {
            _ = channelRegistrationId ?? throw new ArgumentNullException(nameof(channelRegistrationId));

            Page<MessageTemplateItem> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MessageTemplateClient)}.{nameof(GetTemplates)}");
                scope.Start();

                try
                {
                    Response<ListTemplatesResponse> response = _templateV2RestClient.List(new Guid(channelRegistrationId), pageSizeHint, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(x=> new MessageTemplateItem(x)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<MessageTemplateItem> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MessageTemplateClient)}.{nameof(GetTemplates)}");
                scope.Start();

                try
                {
                    Response<ListTemplatesResponse> response = _templateV2RestClient.ListNextPage(nextLink, new Guid(channelRegistrationId), pageSizeHint, cancellationToken);
                    if (response.Value.Value == null || response.Value.Value.Count == 0)
                    {
                        return Page.FromValues(new List<MessageTemplateItem>(), null, response.GetRawResponse());
                    }
                    return Page.FromValues(response.Value.Value.Select(x => new MessageTemplateItem(x)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
        #endregion

        private static HttpPipeline CreatePipelineFromOptions(ConnectionString connectionString, CommunicationMessagesClientOptions options)
        {
            return options.BuildHttpPipeline(connectionString);
        }
    }
}
