// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Identity
{
    internal interface IAuthRequestBuilder
    {
        Request CreateRequest(string[] scopes);
    }
}
