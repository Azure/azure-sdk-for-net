// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub;

internal class WebPubSubServiceAccessOptions
{
    public WebPubSubServiceAccess? WebPubSubAccess { get; set; }
    public string? Hub { get; set; }
}
