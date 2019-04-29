// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.Credentials;

namespace Azure.Core.Identity
{
    internal class AuthenticationResponse
    {
        private Dictionary<string, string> _response;

        public AuthenticationResponse(Dictionary<string, string> response)
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

        public bool TryGetValue(string key, out string value)
        {
            return _response.TryGetValue(key, out value);
        }

        public string AccessToken { get; private set; }

        public DateTimeOffset ExpiresOn { get; private set; }

        public bool NeedsRefresh => (DateTime.UtcNow + TimeSpan.FromMinutes(2)) >= ExpiresOn;
    }
}
