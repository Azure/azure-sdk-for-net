// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Containers.Apps.Sandbox
{
#pragma warning disable SCME0002 // Preserve the generated experimental settings constructor.
    [CodeGenSuppress("SandboxGroupClient", typeof(Uri), typeof(string), typeof(string), typeof(string), typeof(TokenCredential), typeof(SandboxGroupClientOptions))]
    [CodeGenSuppress("SandboxGroupClient", typeof(SandboxGroupClientSettings))]
    [CodeGenSuppress("GetSandboxesClient")]
    public partial class SandboxGroupClient
    {
        private readonly TokenCredential _webSocketCredential;
        internal static readonly string[] WebSocketAuthorizationScopes = AuthorizationScopes;

        /// <summary> Initializes a sandbox group client with a credential and options. </summary>
        public SandboxGroupClient(Uri endpoint, string subscriptionId, string resourceGroupName, string sandboxGroupName, TokenCredential credential, SandboxGroupClientOptions options)
            : this(new BearerTokenAuthenticationPolicy(credential ?? throw new ArgumentNullException(nameof(credential)), AuthorizationScopes),
                  endpoint, subscriptionId, resourceGroupName, sandboxGroupName, options)
        {
            _webSocketCredential = credential;
        }

        /// <summary> Initializes a sandbox group client from settings. </summary>
        [Experimental("SCME0002")]
        public SandboxGroupClient(SandboxGroupClientSettings settings)
            : this(settings?.Endpoint, settings?.SubscriptionId, settings?.ResourceGroupName,
                  settings?.SandboxGroupName, settings?.CredentialProvider as TokenCredential, settings?.Options)
        {
        }

        /// <summary> Gets the subclient for sandbox operations. </summary>
        public virtual SandboxesClient GetSandboxesClient()
        {
            return Volatile.Read(ref _cachedSandboxesClient) ?? Interlocked.CompareExchange(
                ref _cachedSandboxesClient,
                new SandboxesClient(ClientDiagnostics, Pipeline, _endpoint, _apiVersion, _subscriptionId, _resourceGroupName, _sandboxGroupName, _webSocketCredential),
                null) ?? _cachedSandboxesClient;
        }
    #pragma warning restore SCME0002
    }
}
