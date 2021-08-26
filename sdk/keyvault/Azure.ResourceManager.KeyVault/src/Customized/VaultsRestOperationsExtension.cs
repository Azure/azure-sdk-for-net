// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.KeyVault.Models;

namespace Azure.ResourceManager.KeyVault
{
    internal partial class VaultsRestOperations
    {
        internal HttpMessage CreateUpdateAccessPolicyRequest(string resourceGroupName, string vaultName, string operationKind, VaultAccessPolicyProperties properties)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.KeyVault/vaults/", false);
            uri.AppendPath(vaultName, true);
            uri.AppendPath("/accessPolicies/", false);
            uri.AppendPath(operationKind, true);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var model = new VaultAccessPolicyParameters(properties);
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(model);
            request.Content = content;
            return message;
        }

        /// <summary> Update access policies in a key vault in the specified subscription. </summary>
        /// <param name="resourceGroupName"> The name of the Resource Group to which the vault belongs. </param>
        /// <param name="vaultName"> Name of the vault. </param>
        /// <param name="properties"> Properties of the access policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/>, <paramref name="vaultName"/>, or <paramref name="properties"/> is null. </exception>
        public async Task<Response<VaultAccessPolicyParameters>> AddAccessPolicyAsync(string resourceGroupName, string vaultName, VaultAccessPolicyProperties properties, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (vaultName == null)
            {
                throw new ArgumentNullException(nameof(vaultName));
            }
            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            using var message = CreateUpdateAccessPolicyRequest(resourceGroupName, vaultName, "add", properties);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    {
                        VaultAccessPolicyParameters value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = VaultAccessPolicyParameters.DeserializeVaultAccessPolicyParameters(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Update access policies in a key vault in the specified subscription. </summary>
        /// <param name="resourceGroupName"> The name of the Resource Group to which the vault belongs. </param>
        /// <param name="vaultName"> Name of the vault. </param>
        /// <param name="properties"> Properties of the access policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/>, <paramref name="vaultName"/>, or <paramref name="properties"/> is null. </exception>
        public Response<VaultAccessPolicyParameters> AddAccessPolicy(string resourceGroupName, string vaultName, VaultAccessPolicyProperties properties, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (vaultName == null)
            {
                throw new ArgumentNullException(nameof(vaultName));
            }
            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            using var message = CreateUpdateAccessPolicyRequest(resourceGroupName, vaultName, "add", properties);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    {
                        VaultAccessPolicyParameters value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = VaultAccessPolicyParameters.DeserializeVaultAccessPolicyParameters(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        /// <summary> Update access policies in a key vault in the specified subscription. </summary>
        /// <param name="resourceGroupName"> The name of the Resource Group to which the vault belongs. </param>
        /// <param name="vaultName"> Name of the vault. </param>
        /// <param name="properties"> Properties of the access policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/>, <paramref name="vaultName"/>, or <paramref name="properties"/> is null. </exception>
        public async Task<Response<VaultAccessPolicyParameters>> ReplaceAccessPolicyAsync(string resourceGroupName, string vaultName, VaultAccessPolicyProperties properties, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (vaultName == null)
            {
                throw new ArgumentNullException(nameof(vaultName));
            }
            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            using var message = CreateUpdateAccessPolicyRequest(resourceGroupName, vaultName, "replace", properties);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    {
                        VaultAccessPolicyParameters value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = VaultAccessPolicyParameters.DeserializeVaultAccessPolicyParameters(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Update access policies in a key vault in the specified subscription. </summary>
        /// <param name="resourceGroupName"> The name of the Resource Group to which the vault belongs. </param>
        /// <param name="vaultName"> Name of the vault. </param>
        /// <param name="properties"> Properties of the access policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/>, <paramref name="vaultName"/>, or <paramref name="properties"/> is null. </exception>
        public Response<VaultAccessPolicyParameters> ReplaceAccessPolicy(string resourceGroupName, string vaultName, VaultAccessPolicyProperties properties, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (vaultName == null)
            {
                throw new ArgumentNullException(nameof(vaultName));
            }
            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            using var message = CreateUpdateAccessPolicyRequest(resourceGroupName, vaultName, "replace", properties);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    {
                        VaultAccessPolicyParameters value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = VaultAccessPolicyParameters.DeserializeVaultAccessPolicyParameters(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        /// <summary> Update access policies in a key vault in the specified subscription. </summary>
        /// <param name="resourceGroupName"> The name of the Resource Group to which the vault belongs. </param>
        /// <param name="vaultName"> Name of the vault. </param>
        /// <param name="properties"> Properties of the access policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/>, <paramref name="vaultName"/>, or <paramref name="properties"/> is null. </exception>
        public async Task<Response<VaultAccessPolicyParameters>> RemoveAccessPolicyAsync(string resourceGroupName, string vaultName, VaultAccessPolicyProperties properties, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (vaultName == null)
            {
                throw new ArgumentNullException(nameof(vaultName));
            }
            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            using var message = CreateUpdateAccessPolicyRequest(resourceGroupName, vaultName, "remove", properties);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    {
                        VaultAccessPolicyParameters value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = VaultAccessPolicyParameters.DeserializeVaultAccessPolicyParameters(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Update access policies in a key vault in the specified subscription. </summary>
        /// <param name="resourceGroupName"> The name of the Resource Group to which the vault belongs. </param>
        /// <param name="vaultName"> Name of the vault. </param>
        /// <param name="properties"> Properties of the access policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/>, <paramref name="vaultName"/>, or <paramref name="properties"/> is null. </exception>
        public Response<VaultAccessPolicyParameters> RemoveAccessPolicy(string resourceGroupName, string vaultName, VaultAccessPolicyProperties properties, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (vaultName == null)
            {
                throw new ArgumentNullException(nameof(vaultName));
            }
            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            using var message = CreateUpdateAccessPolicyRequest(resourceGroupName, vaultName, "remove", properties);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    {
                        VaultAccessPolicyParameters value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = VaultAccessPolicyParameters.DeserializeVaultAccessPolicyParameters(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }
    }
}
