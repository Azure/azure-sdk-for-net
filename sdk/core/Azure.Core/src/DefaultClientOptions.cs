// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    internal class DefaultClientOptions: ClientOptions
    {
        public DefaultClientOptions(): base(null, null, null)
        {
        }
    }
}
