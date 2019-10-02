// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System;

namespace Azure.Data.AppConfiguration.Tests
{
    public static class TestEnvironment
    {
        public static string GetClientConnectionString()
        {
            var connectionString = Environment.GetEnvironmentVariable("APPCONFIGURATION_CONNECTION_STRING");
            Assert.NotNull(connectionString, "Set APPCONFIGURATION_CONNECTION_STRING environment variable to the connection string");
            return connectionString;
        }
    }
}
