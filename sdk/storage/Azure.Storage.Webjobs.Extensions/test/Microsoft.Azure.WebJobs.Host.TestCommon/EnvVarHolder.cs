// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.WebJobs.Host;
using System;

namespace Microsoft.Azure.WebJobs
{
    // Test helper for setting & resetting an env variable. 
    public class EnvVarHolder
    {
        public static IDisposable Set(string name, string value)
        {
            string prevStorage = Environment.GetEnvironmentVariable(name);

            Environment.SetEnvironmentVariable(name, value);
            return new Holder
            {
                _name = name,
                _value = prevStorage
            };
        }


        public class Holder : IDisposable
        {
            public string _name;
            public string _value;

            public void Dispose()
            {
                Environment.SetEnvironmentVariable(_name, _value);
            }
        }
    }
}