// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
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
        private Uri endpoint;
        private readonly string apiVersion;
        private readonly ClientDiagnostics _clientDiagnostics;
        private ResponseClassifier _classifier200;

        /// <summary> Initializes a new instance of PetStoreClient for mocking. </summary>
        protected PetStoreClient()
        {
        }

        private ResponseClassifier Classifier200 => _classifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });

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

            Pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { authPolicy }, null);
            this.endpoint = endpoint;
            apiVersion = options.Version;
        }

        /// <summary> Get a pet by its Id. </summary>
        /// <param name="id"> Id of pet to return. </param>
        /// <param name="context"> The request context. </param>
        public virtual async Task<Response> GetPetAsync(string id, RequestContext context = null)
        {
            using var scope = _clientDiagnostics.CreateScope("PetStoreClient.GetPet");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetPetRequest(id, context);
                return await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a pet by its Id. </summary>
        /// <param name="id"> Id of pet to return. </param>
        /// <param name="context"> The request context. </param>
        public virtual Response GetPet(string id, RequestContext context = null)
        {
            using var scope = _clientDiagnostics.CreateScope("PetStoreClient.GetPet");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetPetRequest(id, context);
                return Pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a pet by its Id. </summary>
        /// <param name="id"> Id of pet to return. </param>
        /// <param name="context"> The request context. </param>
        public virtual async Task<Response> CreatePetAsync(string id, RequestContent content, RequestContext context = null)
        {
            using var scope = _clientDiagnostics.CreateScope("PetStoreClient.GetPet");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetPetRequest(id, context);
                return await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a pet by its Id. </summary>
        /// <param name="id"> Id of pet to return. </param>
        /// <param name="context"> The request context. </param>
        public virtual Response CreatePet(string id, RequestContent content, RequestContext context = null)
        {
            using var scope = _clientDiagnostics.CreateScope("PetStoreClient.GetPet");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetPetRequest(id, context);
                return Pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create Request for <see cref="GetPet"/> and <see cref="GetPetAsync"/> operations. </summary>
        /// <param name="id"> Id of pet to return. </param>
        /// <param name="context"> The request context. </param>
        private HttpMessage CreateGetPetRequest(string id, RequestContext context = null)
        {
            var message = Pipeline.CreateMessage(context, Classifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/pets/", false);
            uri.AppendPath(id, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json, text/json");
            return message;
        }
    }
}
