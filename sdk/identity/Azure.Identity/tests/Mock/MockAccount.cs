// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Identity.Client;

namespace Azure.Identity.Tests.Mock
{
    public class MockAccount : IAccount
    {
        public MockAccount(string username, string homeId = null)
        {
            homeId ??= Guid.NewGuid().ToString();
            Username = username;
            HomeAccountId = new AccountId(homeId);
        }

        public string Username { get; set; }

        public string Environment { get; set; }

        public AccountId HomeAccountId { get; set; }
    }
}
