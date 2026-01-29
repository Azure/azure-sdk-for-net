// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub;

#nullable enable

/// <summary>
/// Access information to Web PubSub service.
/// </summary>
internal class WebPubSubServiceAccess(Uri serviceEndpoint, WebPubSubServiceCredential credential)
{
    public Uri ServiceEndpoint { get; } = serviceEndpoint;
    public WebPubSubServiceCredential Credential { get; } = credential;
}