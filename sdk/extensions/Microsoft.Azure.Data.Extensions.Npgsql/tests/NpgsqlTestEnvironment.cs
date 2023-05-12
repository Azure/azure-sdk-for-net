// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Microsoft.AspNetCore.Hosting.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Data.Extensions.Npgsql.Tests
{
    public class NpgsqlTestEnvironment : TestEnvironment
    {
        private string FQDN=> GetVariable("POSTGRES_FQDN");
        private string Database => GetVariable("POSTGRES_DATABASE");

        private string User => GetVariable("POSTGRES_SERVER_ADMIN");

        public string ConnectionString => $"Server={FQDN};Database={Database};Port=5432;User Id={User};Ssl Mode=Require;";
    }
}
