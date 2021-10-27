// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Core.Experimental.Tests
{
    /// <summary> The PetStore service client. </summary>
    public partial class PetStoreClient
    {
        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline { get; }
        private readonly string[] AuthorizationScopes = { "https://example.azurepetshop.com/.default" };
        private readonly TokenCredential _tokenCredential;
        private Uri _endpoint;
        private readonly string apiVersion;
        private readonly ClientDiagnostics _clientDiagnostics;
        private ResponseClassifier _classifier200;

        /// <summary> Initializes a new instance of PetStoreClient for mocking. </summary>
        protected PetStoreClient()
        {
        }

        private ResponseClassifier Classifier200
        {
            get
            {
                if (_classifier200 == null)
                {
                    _classifier200 = new ResponseClassifier200();
                }
                return _classifier200;
            }
        }

        /// <summary> Initializes a new instance of PetStoreClient. </summary>
        /// <param name="endpoint"> The workspace development endpoint, for example https://myworkspace.dev.azuresynapse.net. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public PetStoreClient(Uri endpoint, TokenCredential credential, PetStoreClientOptions options = null)
        {
            if (endpoint == null)
            {
                throw new ArgumentNullException(nameof(endpoint));
            }
            if (credential == null)
            {
                throw new ArgumentNullException(nameof(credential));
            }

            options ??= new PetStoreClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _tokenCredential = credential;
            var authPolicy = new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes);

            // TODO: When we move the IsError functionality into Core, we'll move the addition of ResponsePropertiesPolicy to the pipeline into HttpPipelineBuilder.
            Pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { new LowLevelCallbackPolicy() }, new HttpPipelinePolicy[] { authPolicy, new ResponsePropertiesPolicy(options) }, new ResponseClassifier());
            _endpoint = endpoint;
            apiVersion = options.Version;
        }

        /// <summary> Get a pet by its Id. </summary>
        /// <param name="id"> Id of pet to return. </param>
        /// <param name="context"> The request options. </param>
#pragma warning disable AZC0002
        public virtual async Task<Response> GetPetAsync(string id, RequestContext context = null)
#pragma warning restore AZC0002
        {
            using HttpMessage message = CreateGetPetRequest(id, context);
            using var scope = _clientDiagnostics.CreateScope("PetStoreClient.GetPet");
            scope.Start();
            try
            {
                await Pipeline.SendAsync(message, context?.CancellationToken ?? default).ConfigureAwait(false);
                var errorOptions = context?.ErrorOptions ?? ErrorOptions.Default;

                if (errorOptions == ErrorOptions.NoThrow)
                {
                    return message.Response;
                }
                else
                {
                    if (!message.ResponseClassifier.IsErrorResponse(message))
                    {
                        return message.Response;
                    }
                    else
                    {
                        throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                    }
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a pet by its Id. </summary>
        /// <param name="id"> Id of pet to return. </param>
        /// <param name="options"> The request options. </param>
#pragma warning disable AZC0002
        public virtual Response GetPet(string id, RequestContext context = null)
#pragma warning restore AZC0002
        {
            using HttpMessage message = CreateGetPetRequest(id, context);
            using var scope = _clientDiagnostics.CreateScope("PetStoreClient.GetPet");
            scope.Start();
            try
            {
                Pipeline.Send(message, context?.CancellationToken ?? default);
                var errorOptions = context?.ErrorOptions ?? ErrorOptions.Default;

                if (errorOptions == ErrorOptions.NoThrow)
                {
                    return message.Response;
                }
                else
                {
                    // This will change to message.Response.IsError in a later PR
                    if (!message.ResponseClassifier.IsErrorResponse(message))
                    {
                        return message.Response;
                    }
                    else
                    {
                        throw _clientDiagnostics.CreateRequestFailedException(message.Response);
                    }
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create Request for <see cref="GetPet"/> and <see cref="GetPetAsync"/> operations. </summary>
        /// <param name="id"> Id of pet to return. </param>
        /// <param name="options"> The request options. </param>
        private HttpMessage CreateGetPetRequest(string id, RequestContext context = null)
        {
            var message = Pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/pets/", false);
            uri.AppendPath(id, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json, text/json");
            message.ResponseClassifier = Classifier200;
            return message;
        }

#pragma warning disable AZC0002
        public virtual AsyncPageable<BinaryData> GetPetsAsync(RequestOptions options)
#pragma warning restore AZC0002
        {
            return PageableHelpers.CreateAsyncPageable(CreateEnumerableAsync, _clientDiagnostics, "PetStoreClient.GetPets");
            async IAsyncEnumerable<Page<BinaryData>> CreateEnumerableAsync(string nextLink, int? pageSizeHint, [EnumeratorCancellation] CancellationToken cancellationToken = default)
            {
                do
                {
                    var message = string.IsNullOrEmpty(nextLink)
                        ? CreateGetPetsRequest()
                        : CreateGetPetsNextPageRequest(nextLink);
                    var page = await LowLevelPageableHelpers.ProcessMessageAsync(Pipeline, message, _clientDiagnostics, options, "value", "nextLink", cancellationToken).ConfigureAwait(false);
                    nextLink = page.ContinuationToken;
                    yield return page;
                } while (!string.IsNullOrEmpty(nextLink));
            }
        }

#pragma warning disable AZC0002
        public virtual Pageable<BinaryData> GetPets(RequestOptions options)
#pragma warning restore AZC0002
        {
            return PageableHelpers.CreatePageable(CreateEnumerable, _clientDiagnostics, "PetStoreClient.GetPets");
            IEnumerable<Page<BinaryData>> CreateEnumerable(string nextLink, int? pageSizeHint)
            {
                do
                {
                    var message = string.IsNullOrEmpty(nextLink)
                        ? CreateGetPetsRequest()
                        : CreateGetPetsNextPageRequest(nextLink);
                    var page = LowLevelPageableHelpers.ProcessMessage(Pipeline, message, _clientDiagnostics, options, "value", "nextLink");
                    nextLink = page.ContinuationToken;
                    yield return page;
                } while (!string.IsNullOrEmpty(nextLink));
            }
        }

        internal HttpMessage CreateGetPetRequest(long id)
        {
            var message = Pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/pets/", false);
            uri.AppendPath(id, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json, text/json");
            message.ResponseClassifier = ResponseClassifier200.Instance;
            return message;
        }

        internal HttpMessage CreateGetPetsRequest()
        {
            var message = Pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/pets", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json, text/json");
            message.ResponseClassifier = ResponseClassifier200.Instance;
            return message;
        }

        internal HttpMessage CreateGetPetsNextPageRequest(string nextLink)
        {
            var message = Pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json, text/json");
            message.ResponseClassifier = ResponseClassifier200.Instance;
            return message;
        }

        private sealed class ResponseClassifier200 : ResponseClassifier
        {
            private static ResponseClassifier _instance;
            public static ResponseClassifier Instance => _instance ??= new ResponseClassifier200();
            public override bool IsErrorResponse(HttpMessage message)
            {
                return message.Response.Status switch
                {
                    200 => false,
                    _ => true
                };
            }
        }
    }
}
