// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    internal class DefaultClientOptions: ClientOptions
    {
        // Implementation Note: this constructor must call the base class constructor with the signature.
        //
        // internal ClientOptions(ClientOptions? clientOptions, DiagnosticsOptions? diagnostics, RetryOptions? retry)
        //
        // Calling the default constructor would result in a stack overflow as this constructor is called from a static initializer.
        public DefaultClientOptions(): base(null, null, null)
        {
        }
    }
}
