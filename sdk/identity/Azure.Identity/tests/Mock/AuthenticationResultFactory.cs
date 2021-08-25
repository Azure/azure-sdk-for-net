// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Identity.Client;
using NUnit.Framework;

namespace Azure.Identity.Tests.Mock
{
    public class AuthenticationResultFactory
    {
        public static AuthenticationResult Create(string accessToken = default, bool? isExtendedLifeTimeToken = default, string uniqueId = default, DateTimeOffset? expiresOn = default, DateTimeOffset? extendedExpiresOn = default, string tenantId = default, IAccount account = default, string idToken = default, IEnumerable<string> scopes = default, Guid? correlationId = default)
        {
            accessToken ??= Guid.NewGuid().ToString();

            isExtendedLifeTimeToken ??= false;

            uniqueId ??= Guid.NewGuid().ToString();

            expiresOn ??= DateTime.UtcNow.AddMinutes(5);

            extendedExpiresOn ??= DateTime.UtcNow.AddMinutes(10);

            tenantId ??= Guid.NewGuid().ToString();

            account ??= new MockAccount("mockuser@mockdomain.com");

            idToken ??= Guid.NewGuid().ToString();

            scopes ??= (string[])MockScopes.Default;

            correlationId ??= Guid.NewGuid();

            return new AuthenticationResult(accessToken, isExtendedLifeTimeToken.Value, uniqueId, expiresOn.Value, extendedExpiresOn.Value, tenantId, account, idToken, scopes, correlationId.Value, (AuthenticationResultMetadata)null);
        }
    }
}
