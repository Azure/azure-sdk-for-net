// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Microsoft.AspNetCore.Hosting.Server;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Data.Extensions.MySqlConnector.Tests
{
    public class MySqlConnectorTestEnvironment : TestEnvironment
    {
        private string FQDN => GetVariable("MYSQL_FQDN");
        private string Database => GetVariable("MYSQL_DATABASE");
        private string User => GetVariable("MYSQL_SERVER_ADMIN").Substring(0, 32);

        public string ConnectionString
        {
            get
            {
                MySqlConnectionStringBuilder connectionStringBuilder = new MySqlConnectionStringBuilder
                {
                    Server = FQDN,
                    UserID = User,
                    Database = Database,
                    Port = 3306,
                    SslMode = MySqlSslMode.Required,
                    AllowPublicKeyRetrieval = true,
                    ConnectionTimeout = 30
                };
                return connectionStringBuilder.ConnectionString;
            }
        }
    }
}
