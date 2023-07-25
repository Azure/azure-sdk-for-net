// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.SignalR;
using Microsoft.Azure.SignalR.Management;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal class SignatureValidationOptionsSetup : IConfigureOptions<SignatureValidationOptions>
    {
        private static readonly char[] PropertySeparator = { ';' };
        private static readonly char[] KeyValueSeparator = { '=' };
        private const string AccessKeyProperty = "AccessKey";

        private readonly Action<ServiceManagerOptions> _configureServiceManagerOptions;

        public SignatureValidationOptionsSetup(Action<ServiceManagerOptions> configureServiceManagerOptions)
        {
            _configureServiceManagerOptions = configureServiceManagerOptions;
        }

        /// <remarks>
        /// We can't get the <see cref="ServiceManagerOptions"/> from <see cref="ServiceManager"/>, therefore we have to reuse the configuration action to build the options again.
        /// </remarks>
        public void Configure(SignatureValidationOptions options)
        {
            var serviceManagerOptions = new ServiceManagerOptions();
            _configureServiceManagerOptions(serviceManagerOptions);
            IEnumerable<ServiceEndpoint> endpoints = serviceManagerOptions.ServiceEndpoints ?? Array.Empty<ServiceEndpoint>();
            if (serviceManagerOptions.ConnectionString != null)
            {
                endpoints = endpoints.Append(new ServiceEndpoint(serviceManagerOptions.ConnectionString));
            }
            foreach (var endpoint in endpoints)
            {
                if (endpoint.ConnectionString != null && TryGetAccessKey(endpoint.ConnectionString, out var accessKey))
                {
                    options.AccessKeys.Add(accessKey);
                }
                else
                {
                    // Once there is one connection string without access key, the validation is not required. Currently we don't have mechanism to validate identity-based connection.
                    options.RequireValidation = false;
                    // Validation isn't required therefore no need to continue to get the access keys.
                    return;
                }
            }
        }

        private static bool TryGetAccessKey(string connectionString, out string accesskey)
        {
            foreach (var property in connectionString.Split(PropertySeparator, StringSplitOptions.RemoveEmptyEntries))
            {
                var kvp = property.Split(KeyValueSeparator, 2);
                if (kvp.Length != 2)
                {
                    continue;
                }
                if (kvp[0].Trim().Equals(AccessKeyProperty, StringComparison.OrdinalIgnoreCase))
                {
                    accesskey = kvp[1].Trim();
                    return true;
                }
            }
            accesskey = null;
            return false;
        }
    }
}
