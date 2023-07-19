// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    internal enum CredentialKind
    {
        None,
        ConnectionString,
        AzureKeyCredential,
        TokenCredential,
    }
}
