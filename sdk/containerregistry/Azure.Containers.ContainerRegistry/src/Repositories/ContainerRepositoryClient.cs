// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Containers.ContainerRegistry
{
    /// <summary> The repository service client. </summary>
    public partial class ContainerRepositoryClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ContainerRegistryRepositoryRestClient _restClient;

        private readonly string _repository;

        /// <summary>
        /// </summary>
        public virtual Uri Endpoint { get; }

        /// <summary>
        /// <param name="endpoint"></param>
        /// <param name="repository"> Name of the image (including the namespace). </param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// </summary>
        public ContainerRepositoryClient(Uri endpoint, string repository, string username, string password) : this(endpoint, repository, username, password, new ContainerRegistryClientOptions())
        {
        }

        /// <summary>
        /// <param name="endpoint"></param>
        /// <param name="repository"> Name of the image (including the namespace). </param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="options"></param>
        /// </summary>
        public ContainerRepositoryClient(Uri endpoint, string repository, string username, string password, ContainerRegistryClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(repository, nameof(repository));
            Argument.AssertNotNull(username, nameof(username));
            Argument.AssertNotNull(password, nameof(password));
            Argument.AssertNotNull(options, nameof(options));

            _pipeline = HttpPipelineBuilder.Build(options, new BasicAuthenticationPolicy(username, password));

            _clientDiagnostics = new ClientDiagnostics(options);

            Endpoint = endpoint;
            _repository = repository;

            _restClient = new ContainerRegistryRepositoryRestClient(_clientDiagnostics, _pipeline, Endpoint.AbsoluteUri);
        }

        /// <summary> Initializes a new instance of RepositoryClient for mocking. </summary>
        protected ContainerRepositoryClient()
        {
        }

        /// <summary> Get repository properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<RepositoryProperties>> GetPropertiesAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepositoryClient)}.{nameof(GetProperties)}");
            scope.Start();
            try
            {
                return await _restClient.GetPropertiesAsync(_repository, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get repository properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<RepositoryProperties> GetProperties(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepositoryClient)}.{nameof(GetProperties)}");
            scope.Start();
            try
            {
                return _restClient.GetProperties(_repository, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Update the attribute identified by `name` where `reference` is the name of the repository. </summary>
        /// <param name="value"> Repository attribute value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> SetPropertiesAsync(ContentProperties value, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepositoryClient)}.{nameof(SetProperties)}");
            scope.Start();
            try
            {
                return await _restClient.SetPropertiesAsync(_repository, value, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>Update the repository properties.</summary>
        /// <param name="value"> Repository properties to set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response SetProperties(ContentProperties value, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepositoryClient)}.{nameof(SetProperties)}");
            scope.Start();
            try
            {
                return _restClient.SetProperties(_repository, value, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get tag properties by tag. </summary>
        /// <param name="tag"> Tag name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<TagProperties>> GetTagPropertiesAsync(string tag, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepositoryClient)}.{nameof(GetTagProperties)}");
            scope.Start();
            try
            {
                return await _restClient.GetTagPropertiesAsync(_repository, tag, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get tag attributes by tag. </summary>
        /// <param name="tag"> Tag name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<TagProperties> GetTagProperties(string tag, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepositoryClient)}.{nameof(GetTagProperties)}");
            scope.Start();
            try
            {
                return _restClient.GetTagProperties(_repository, tag, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Update tag attributes. </summary>
        /// <param name="tag"> Tag name. </param>
        /// <param name="value"> Tag property value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> SetTagPropertiesAsync(string tag, ContentProperties value, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepositoryClient)}.{nameof(SetTagProperties)}");
            scope.Start();
            try
            {
                return await _restClient.UpdateTagAttributesAsync(_repository, tag, value, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Update tag attributes. </summary>
        /// <param name="tag"> Tag name. </param>
        /// <param name="value"> Tag property value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response SetTagProperties(string tag, ContentProperties value, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepositoryClient)}.{nameof(SetTagProperties)}");
            scope.Start();
            try
            {
                return _restClient.UpdateTagAttributes(_repository, tag, value, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
