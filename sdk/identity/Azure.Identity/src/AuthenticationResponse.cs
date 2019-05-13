// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Identity
{
    public class AuthenticationResponse
    {
        private Dictionary<string, string> _response;

        internal AuthenticationResponse(Dictionary<string, string> response)
        {
            _response = response;

            if (TryGetValue("access_token", out string token))
            {
                AccessToken = token;
            }

            if (TryGetValue("expires_in", out string expiresInStr) && long.TryParse(expiresInStr, out long expiresIn))
            {
                ExpiresOn = DateTime.UtcNow + TimeSpan.FromSeconds(expiresIn);
            }
        }

        public AuthenticationResponse(string accessToken, DateTimeOffset expiresOn)
        {
            AccessToken = accessToken;
            ExpiresOn = expiresOn;
        }

        internal bool TryGetValue(string key, out string value)
        {
            value = null;

            return _response != null ? _response.TryGetValue(key, out value) : false;
        }

        public string AccessToken { get; private set; }

        public DateTimeOffset ExpiresOn { get; private set; }

    }
}
