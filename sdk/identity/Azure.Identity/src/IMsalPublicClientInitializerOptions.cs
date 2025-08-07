// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Identity.Client;

namespace Azure.Identity
{
    [Friend("Azure.Identity.Broker")]
    internal interface IMsalPublicClientInitializerOptions
    {
        Action<PublicClientApplicationBuilder> BeforeBuildClient { get; }

        bool UseDefaultBrokerAccount { get; set; }
    }

    [Friend("Azure.Identity.Broker")]
    internal interface IMsalSettablePublicClientInitializerOptions
    {
        Action<PublicClientApplicationBuilder> BeforeBuildClient { get; set; }

        bool UseDefaultBrokerAccount { get; set; }
    }
}
