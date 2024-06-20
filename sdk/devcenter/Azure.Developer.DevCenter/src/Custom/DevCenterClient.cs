// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Developer.DevCenter
{
    public partial class DevCenterClient
    {
        private readonly DevCenterClientOptions _options;

        /// <summary> Initializes a new instance of DevCenterClient. </summary>
        /// <param name="endpoint"> The DevCenter-specific URI to operate on. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public DevCenterClient(Uri endpoint, TokenCredential credential, DevCenterClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            _options = options ?? new DevCenterClientOptions();

            ClientDiagnostics = new ClientDiagnostics(_options, true);
            _tokenCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(_options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes) }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = _options.Version;
        }

        /// <summary> Initializes a new instance of DevBoxesClient from DevCenterClient </summary>
        public virtual DevBoxesClient GetDevBoxesClient() => new DevBoxesClient(_endpoint, _tokenCredential, _options);

        /// <summary> Initializes a new instance of DeploymentEnvironmentsClient from DevCenterClient </summary>
        public virtual DeploymentEnvironmentsClient GetDeploymentEnvironmentsClient() => new DeploymentEnvironmentsClient(_endpoint, _tokenCredential, _options);
    }
}
