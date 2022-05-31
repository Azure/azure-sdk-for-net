// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Identity.Client;

namespace Azure.Identity
{
    internal interface IMsalPublicClientInitializerOptions
    {
        Action<PublicClientApplicationBuilder> BeforeBuildClient { get; }
    }
}
