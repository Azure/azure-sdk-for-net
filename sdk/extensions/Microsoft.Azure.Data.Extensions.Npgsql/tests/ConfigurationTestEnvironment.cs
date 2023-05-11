// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Data.Extensions.Npgsql.Tests
{
    public class ConfigurationTestEnvironment : TestEnvironment
    {
        public string ConnectionString => GetVariable("POSTGRESQL_CONNECTION_STRING");
    }
}
