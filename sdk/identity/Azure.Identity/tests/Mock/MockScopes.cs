// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Identity.Tests.Mock
{
    internal class MockScopes
    {
        private readonly string[] _scopes;

        private MockScopes(string[] scopes)
        {
            _scopes = scopes;
        }

        public static MockScopes Default = new MockScopes(new string[] { "https://default.mock.auth.scope/.default" });

        public static MockScopes Alternate = new MockScopes(new string[] { "https://alternate.mock.auth.scope/.default" });
        public static MockScopes Alternate2 = new MockScopes(new string[] { "https://alternate2.mock.auth.scope/.default" });

        public override string ToString()
        {
            return ToString(_scopes);
        }

        public static string ToString(string[] scopes)
        {
            return string.Join("+", scopes);
        }

        public static implicit operator string[](MockScopes scopes)
        {
            return scopes._scopes;
        }
    }
}
