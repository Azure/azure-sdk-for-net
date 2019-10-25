// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Identity
{
    internal readonly struct ExtendedAccessToken
    {
        public ExtendedAccessToken(AccessToken accessToken)
        {
            AccessToken = accessToken;
            Exception = null;
        }

        public ExtendedAccessToken(Exception exception)
        {
            AccessToken = default;
            Exception = exception;
        }

        public AccessToken AccessToken { get; }

        public Exception Exception { get; }

        public AccessToken GetTokenOrThrow()
        {
            if (Exception != null)
            {
                throw Exception;
            }

            return AccessToken;
        }
    }
}
