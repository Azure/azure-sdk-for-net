// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Identity
{
    public class AccessToken
    {
        public AccessToken(string accessToken, DateTimeOffset expiresOn)
        {
            Token = accessToken;
            ExpiresOn = expiresOn;
        }

        public string Token { get; private set; }

        public DateTimeOffset ExpiresOn { get; private set; }
    }
}
