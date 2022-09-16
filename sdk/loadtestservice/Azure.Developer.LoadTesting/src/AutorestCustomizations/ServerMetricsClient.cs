// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Developer.LoadTesting
{
    [CodeGenSuppress("ServerMetricsClient", typeof(string), typeof(TokenCredential))]
    [CodeGenSuppress("ServerMetricsClient", typeof(string), typeof(TokenCredential), typeof(AzureLoadTestingClientOptions))]
    public partial class ServerMetricsClient { }
}
