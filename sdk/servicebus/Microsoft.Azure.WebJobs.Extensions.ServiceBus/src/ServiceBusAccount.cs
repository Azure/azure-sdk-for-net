// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;
using Microsoft.Azure.WebJobs.Logging;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Azure.WebJobs.ServiceBus
{
    internal class ServiceBusAccount
    {
        private readonly ServiceBusOptions _options;
        private readonly IConnectionProvider _connectionProvider;
        private readonly IConfiguration _configuration;
        private string _connectionString;

        public ServiceBusAccount(ServiceBusOptions options, IConfiguration configuration, IConnectionProvider connectionProvider = null)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _configuration = configuration;
            _connectionProvider = connectionProvider;
        }

        internal ServiceBusAccount()
        {
        }

        public virtual string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    _connectionString = _options.ConnectionString;
                    if (_connectionProvider != null && !string.IsNullOrEmpty(_connectionProvider.Connection))
                    {
                        _connectionString = _configuration.GetWebJobsConnectionString(_connectionProvider.Connection);
                    }

                    if (string.IsNullOrEmpty(_connectionString))
                    {
                        throw new InvalidOperationException(
                            string.Format(CultureInfo.InvariantCulture, "Microsoft Azure WebJobs SDK ServiceBus connection string '{0}' is missing or empty.",
                            Sanitizer.Sanitize(_connectionProvider.Connection) ?? Constants.DefaultConnectionSettingStringName));
                    }
                }

                return _connectionString;
            }
        }
    }
}
