// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Identity.Tests
{
    /// <summary>
    /// Helper class to temporarily set environment variables and restore them on disposal.
    /// </summary>
    internal class TestEnvVar : IDisposable
    {
        private readonly Dictionary<string, string> _originalValues = new Dictionary<string, string>();

        public TestEnvVar(string name, string value)
        {
            SetVariable(name, value);
        }

        public TestEnvVar(Dictionary<string, string> variables)
        {
            foreach (var kvp in variables)
            {
                SetVariable(kvp.Key, kvp.Value);
            }
        }

        private void SetVariable(string name, string value)
        {
            _originalValues[name] = Environment.GetEnvironmentVariable(name);
            Environment.SetEnvironmentVariable(name, value);
        }

        public void Dispose()
        {
            foreach (var kvp in _originalValues)
            {
                Environment.SetEnvironmentVariable(kvp.Key, kvp.Value);
            }
        }
    }
}
