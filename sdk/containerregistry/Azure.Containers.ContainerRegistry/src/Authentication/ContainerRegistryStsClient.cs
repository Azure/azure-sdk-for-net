// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Containers.ContainerRegistry.Models;
using Azure.Core;

namespace Azure.Containers.ContainerRegistry.Authentication
{
    public class ContainerRegistryStsClient
    {
        public ContainerRegistryStsClient(Uri endpoint, TokenCredential credential) : this(endpoint, credential, new ContainerRegistryClientOptions())
        {
        }

        public ContainerRegistryStsClient(Uri endpoint, TokenCredential credential, ContainerRegistryClientOptions options)
        {
        }

        public ContainerRegistryStsClient(Uri endpoint, AzureAdminUserCredential credential) : this(endpoint, credential, new ContainerRegistryClientOptions())
        {
        }

        public ContainerRegistryStsClient(Uri endpoint, AzureAdminUserCredential credential, ContainerRegistryClientOptions options)
        {
        }

        public ContainerRegistryStsClient(Uri endpoint) : this(endpoint, new ContainerRegistryClientOptions())
        {
        }

        /// <summary>
        /// Anonymous access
        /// </summary>
        public ContainerRegistryStsClient(Uri endpoint, ContainerRegistryClientOptions options)
        {
        }

        protected ContainerRegistryStsClient()
        {
        }

        public Uri Endpoint { get; }

        /// <summary>
        /// Equivalent of `az acr login --name [acrName] --expose-token` command
        /// <param name="cancellationToken"></param>
        /// </summary>
        /// <returns></returns>
        public virtual Response<AccessToken> GetAccessToken(CancellationToken cancellationToken = default)
        {
            // TODO: fix brackets to `<>` in XML above
            // TODO: ensure we take the appropriate input parameters corresponding to az acr login command
            throw new NotImplementedException();
        }

        /// <summary>
        /// Equivalent of `az acr login --name [acrName] --expose-token` command
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Task<Response<AccessToken>> GetAccessTokenAsync(CancellationToken cancellationToken = default)
        {
            // TODO: fix brackets to `<>` in XML above
            // TODO: ensure we take the appropriate input parameters corresponding to az acr login command
            throw new NotImplementedException();
        }

        // TODO: think through whether we need an overload that takes scope - we can always add this later if a use case arises.
    }
}
