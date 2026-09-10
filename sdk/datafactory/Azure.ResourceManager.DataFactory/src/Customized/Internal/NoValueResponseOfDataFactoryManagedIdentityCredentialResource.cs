// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.DataFactory
{
    // Internal NullableResponse helper used by DataFactoryManagedIdentityCredentialCollection.GetIfExists
    // (see DataFactoryManagedIdentityCredentialResource for the dual-view rationale). Returned when the
    // underlying DataFactoryServiceCredentialCollection.GetIfExists yields no value so callers of the
    // specialized collection still receive the matching strongly-typed NullableResponse<...>.
    internal sealed class NoValueResponseOfDataFactoryManagedIdentityCredentialResource : NullableResponse<DataFactoryManagedIdentityCredentialResource>
    {
        private readonly Response _rawResponse;
        public NoValueResponseOfDataFactoryManagedIdentityCredentialResource(Response rawResponse) { _rawResponse = rawResponse; }
        public override bool HasValue => false;
        public override DataFactoryManagedIdentityCredentialResource Value => throw new InvalidOperationException("Response had no value.");
        public override Response GetRawResponse() => _rawResponse;
    }
}
