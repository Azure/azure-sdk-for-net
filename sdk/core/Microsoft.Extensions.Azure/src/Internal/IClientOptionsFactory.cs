// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Microsoft.Extensions.Azure
{
    internal interface IClientOptionsFactory
    {
        object CreateOptions(string name);
    }
}