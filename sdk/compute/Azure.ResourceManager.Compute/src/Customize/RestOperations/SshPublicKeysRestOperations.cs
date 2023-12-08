// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Compute.Models;

namespace Azure.ResourceManager.Compute
{
    internal partial class SshPublicKeysRestOperations
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public async Task<Response<SshPublicKeyGenerateKeyPairResult>> GenerateKeyPairAsync(string subscriptionId, string resourceGroupName, string sshPublicKeyName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(sshPublicKeyName, nameof(sshPublicKeyName));

            using var message = CreateGenerateKeyPairRequest(subscriptionId, resourceGroupName, sshPublicKeyName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SshPublicKeyGenerateKeyPairResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = SshPublicKeyGenerateKeyPairResult.DeserializeSshPublicKeyGenerateKeyPairResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Response<SshPublicKeyGenerateKeyPairResult> GenerateKeyPair(string subscriptionId, string resourceGroupName, string sshPublicKeyName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(sshPublicKeyName, nameof(sshPublicKeyName));

            using var message = CreateGenerateKeyPairRequest(subscriptionId, resourceGroupName, sshPublicKeyName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SshPublicKeyGenerateKeyPairResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = SshPublicKeyGenerateKeyPairResult.DeserializeSshPublicKeyGenerateKeyPairResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGenerateKeyPairRequest(string subscriptionId, string resourceGroupName, string sshPublicKeyName)
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
            uri.AppendPath("/providers/Microsoft.Compute/sshPublicKeys/", false);
            uri.AppendPath(sshPublicKeyName, true);
            uri.AppendPath("/generateKeyPair", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }
    }
}
