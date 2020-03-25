// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Identity.Client;

namespace Azure.Identity.Tests.Mock
{
    public class MockAccount : IAccount
    {
        public MockAccount(string username, string tenantId = null)
        {
            tenantId ??= Guid.NewGuid().ToString();
            var objectId = Guid.NewGuid().ToString();
            var identifier = objectId + "." + tenantId;
            Username = username;
            HomeAccountId = new AccountId(identifier, objectId, tenantId);
        }

        public string Username { get; set; }

        public string Environment { get; set; }

        public AccountId HomeAccountId { get; set; }
    }
}
