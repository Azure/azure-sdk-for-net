// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Identity
{
    public class AuthenticationResponse
    {
        public AuthenticationResponse(string accessToken, DateTimeOffset expiresOn)
        {
            AccessToken = accessToken;
            ExpiresOn = expiresOn;
        }

        public string AccessToken { get; private set; }

        public DateTimeOffset ExpiresOn { get; private set; }
    }
}
