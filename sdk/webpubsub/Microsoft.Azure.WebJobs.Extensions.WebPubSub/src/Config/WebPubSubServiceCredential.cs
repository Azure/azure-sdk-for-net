// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub;

#nullable enable

/// <summary>
/// Can be key-based credential or identity-based credential.
/// </summary>
internal abstract class WebPubSubServiceCredential
{
}

internal class KeyCredential(string? accessKey) : WebPubSubServiceCredential
{
    public string? AccessKey { get; } = accessKey;
}

internal class IdentityCredential(TokenCredential tokenCredential) : WebPubSubServiceCredential
{
    public TokenCredential TokenCredential { get; } = tokenCredential;
}
