using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Azure.Identity.Tests
{
    internal class TestEnvVar : IDisposable
    {
        private string _origValue = null;
        private string _name;

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
