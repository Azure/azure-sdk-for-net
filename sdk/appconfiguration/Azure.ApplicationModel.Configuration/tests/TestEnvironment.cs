// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using NUnit.Framework;
using System;

namespace Azure.ApplicationModel.Configuration.Tests
{
    public static class TestEnvironment
    {
        public static string GetClientConnectionString()
        {
            var connectionString = Environment.GetEnvironmentVariable("APP_CONFIG_CONNECTION");
            Assert.NotNull(connectionString, "Set APP_CONFIG_CONNECTION environment variable to the connection string");
            return connectionString;
        }
    }
}
