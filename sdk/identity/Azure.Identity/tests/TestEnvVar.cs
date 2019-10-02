// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Azure.Identity.Tests
{
    internal class TestEnvVar : IDisposable
    {
        private readonly string _origValue = null;
        private readonly string _name;

        public TestEnvVar(string name, string value)
        {
            _name = name;

            _origValue = Environment.GetEnvironmentVariable(name);

            Environment.SetEnvironmentVariable(name, value);
        }

        public void Dispose()
        {
            Environment.SetEnvironmentVariable(_name, _origValue);
        }
    }
}
