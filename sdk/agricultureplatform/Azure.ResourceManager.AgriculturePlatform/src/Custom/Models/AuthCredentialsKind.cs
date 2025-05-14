// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.AgriculturePlatform.Models
{
    /// <summary> Types of different kind of Data connector auth credentials supported. </summary>
    public readonly partial struct AuthCredentialsKind
    {
        private const string OAuthClientCredentialsValue = "OAuthClientCredentials"; //[SuppressMessage("Microsoft.Security", "CS001:SecretInline", Justification = "This is not actual credential, just name as string")]
        private const string ApiKeyAuthCredentialsValue = "ApiKeyAuthCredentials"; //[SuppressMessage("Microsoft.Security", "CS001:SecretInline", Justification = "This is not actual credential, just name as string")]
    }
}
