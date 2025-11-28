// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub;

/// <summary>
/// Can be key-based credential, identity-based connection, or null (A connection string without access key provided to Web PubSub trigger)
/// </summary>
internal abstract class WebPubSubServiceCredential
{
    public abstract bool CanValidateSignature { get; }
}

internal class KeyCredential(string accessKey) : WebPubSubServiceCredential
{
    public override bool CanValidateSignature => !string.IsNullOrEmpty(AccessKey);
    public string AccessKey { get; } = accessKey;
}

internal class IdentityCredential(TokenCredential tokenCredential) : WebPubSubServiceCredential
{
    public override bool CanValidateSignature => false;

    public TokenCredential TokenCredential { get; } = tokenCredential;
}
