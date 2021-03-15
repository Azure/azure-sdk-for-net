// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    internal interface IClientContext
    {
        internal AzureResourceManagerClientOptions ClientOptions { get; set; }

        internal TokenCredential Credential { get; set; }

        internal Uri BaseUri { get; set; }
    }
}
