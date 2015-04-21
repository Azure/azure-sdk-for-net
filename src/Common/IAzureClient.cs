// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net.Http;

namespace Microsoft.Azure
{
    public interface IAzureClient
    {
        SubscriptionCloudCredentials Credentials { get; }
        HttpClient HttpClient { get; }
    }
}
