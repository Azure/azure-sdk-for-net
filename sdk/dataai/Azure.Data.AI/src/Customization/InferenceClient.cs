// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Data.AI
{
#pragma warning disable SCME0002
    // The generated settings-based constructor assumes token authentication and casts
    // InferenceClientSettings.CredentialProvider to TokenCredential. This service also
    // supports API-key authentication, where the key lives in Credential.Key and no
    // token provider is present, so the generated cast yields null and the bearer policy
    // throws before a request is ever sent. The replacement below picks the policy that
    // matches the configured credential.
    [CodeGenSuppress("InferenceClient", typeof(InferenceClientSettings))]
    public partial class InferenceClient
    {
        /// <summary> Initializes a new instance of InferenceClient from a <see cref="InferenceClientSettings"/>. </summary>
        /// <param name="settings"> The settings for InferenceClient. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="settings"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="settings"/> does not carry a usable credential. </exception>
        [Experimental("SCME0002")]
        public InferenceClient(InferenceClientSettings settings)
            : this(CreateAuthenticationPolicy(settings), settings?.Endpoint, settings?.Options)
        {
        }

        [Experimental("SCME0002")]
        private static HttpPipelinePolicy CreateAuthenticationPolicy(InferenceClientSettings settings)
        {
            Argument.AssertNotNull(settings, nameof(settings));

            if (settings.CredentialProvider is TokenCredential tokenCredential)
            {
                return new BearerTokenAuthenticationPolicy(tokenCredential, AuthorizationScopes);
            }

            string key = settings.Credential?.Key;
            if (!string.IsNullOrEmpty(key))
            {
                return new AzureKeyCredentialPolicy(new AzureKeyCredential(key), AuthorizationHeader);
            }

            throw new ArgumentException(
                $"The supplied {nameof(InferenceClientSettings)} does not contain a usable credential. Set either "
                + $"{nameof(InferenceClientSettings.Credential)}.{nameof(CredentialSettings.TokenProvider)} for Microsoft Entra ID "
                + $"authentication or {nameof(InferenceClientSettings.Credential)}.{nameof(CredentialSettings.Key)} for API key authentication.",
                nameof(settings));
        }
    }
#pragma warning restore SCME0002
}
