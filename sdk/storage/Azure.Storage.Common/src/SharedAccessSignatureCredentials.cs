// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Azure.Storage
{
    public sealed class SharedAccessSignatureCredentials : IStorageCredentials
    {
        public SharedAccessSignatureCredentials(string sasToken) => this.SasToken = sasToken;

        public string SasToken { get; }
    }
}
