// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;

namespace Azure.Core.TestFramework
{
    public class TestEnvVar : DisposableConfig
    {
        private static SemaphoreSlim _lock = new(1, 1);
        public TestEnvVar(string name, string value) : base(name, value, _lock) { }
        public TestEnvVar(Dictionary<string, string> values) : base(values, _lock) { }

        internal override void SetValue(string name, string value)
        {
            _originalValues[name] = Environment.GetEnvironmentVariable(name);

            CleanExistingEnvironmentVariables();

            Environment.SetEnvironmentVariable(name, value as string);
        }

        internal override void SetValues(Dictionary<string, string> values)
        {
            foreach (var kvp in values)
            {
                _originalValues[kvp.Key] = Environment.GetEnvironmentVariable(kvp.Key);
            }

            CleanExistingEnvironmentVariables();

            foreach (var kvp in values)
            {
                Environment.SetEnvironmentVariable(kvp.Key, kvp.Value as string);
            }
        }

        internal override void InitValues()
        { }

        // clear the existing values so that the test needs only set up the values relevant to it.
        private void CleanExistingEnvironmentVariables()
        {
            foreach (var kvp in _originalValues)
            {
                Environment.SetEnvironmentVariable(kvp.Key, null);
            }
        }

        internal override void Cleanup()
        {
            foreach (var kvp in _originalValues)
            {
                Environment.SetEnvironmentVariable(kvp.Key, kvp.Value as string);
            }
        }
    }
}
