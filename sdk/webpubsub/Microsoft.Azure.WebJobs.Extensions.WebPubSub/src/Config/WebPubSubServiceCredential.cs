// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub;

#nullable enable

/// <summary>
/// Can be key-based credential or identity-based connection.
/// </summary>
internal abstract class WebPubSubServiceCredential
{
    public abstract bool CanValidateSignature { get; }
}

internal class KeyCredential(string? accessKey) : WebPubSubServiceCredential
{
    public override bool CanValidateSignature => !string.IsNullOrEmpty(AccessKey);
    // The AccessKey is null when a connection string without access key is provided, that is, users have disabled the access key authentication. This connection string is only used for upstream origin validation.
    public string? AccessKey { get; } = accessKey;
}

internal class IdentityCredential(TokenCredential tokenCredential) : WebPubSubServiceCredential
{
    public override bool CanValidateSignature => false;

    public TokenCredential TokenCredential { get; } = tokenCredential;
}
