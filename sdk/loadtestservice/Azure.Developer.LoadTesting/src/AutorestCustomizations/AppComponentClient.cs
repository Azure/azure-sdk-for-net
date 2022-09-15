// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Developer.LoadTesting
{
    [CodeGenSuppress("AppComponentClient", typeof(string), typeof(TokenCredential))]
    [CodeGenSuppress("AppComponentClient", typeof(string), typeof(TokenCredential), typeof(AzureLoadTestingClientOptions))]
    public partial class AppComponentClient
    {
    }
}
