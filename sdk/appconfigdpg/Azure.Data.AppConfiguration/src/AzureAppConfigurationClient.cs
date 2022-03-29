// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Data.AppConfiguration
{
    public partial class AzureAppConfigurationClient
    {
        /// <summary>
        /// </summary>
        /// <param name="connectionString"></param>
        public AzureAppConfigurationClient(string connectionString) : this(connectionString, new AzureAppConfigurationClientOptions())
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="options"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public AzureAppConfigurationClient(string connectionString, AzureAppConfigurationClientOptions options)
        {
            if (connectionString == null)
                throw new ArgumentNullException(nameof(connectionString));
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            Uri endpoint;
            ParseConnectionString(connectionString, out endpoint, out var credential, out var secret);
            _endpoint = endpoint.AbsoluteUri;
            _apiVersion = options.Version;

            var syncTokenPolicy = new SyncTokenPolicy();
            _pipeline = CreatePipeline(options, new AuthenticationPolicy(credential, secret), syncTokenPolicy);

            ClientDiagnostics = new ClientDiagnostics(options);
        }

        private static HttpPipeline CreatePipeline(AzureAppConfigurationClientOptions options, HttpPipelinePolicy authenticationPolicy, HttpPipelinePolicy syncTokenPolicy)
        {
            return HttpPipelineBuilder.Build(options,
                Array.Empty<HttpPipelinePolicy>(),
                new HttpPipelinePolicy[] { authenticationPolicy, syncTokenPolicy },
                new ResponseClassifier());
        }

        private static void ParseConnectionString(string connectionString, out Uri uri, out string credential, out byte[] secret)
        {
            Debug.Assert(connectionString != null); // callers check this

            var parsed = ConnectionString.Parse(connectionString);

            uri = new Uri(parsed.GetRequired("Endpoint"));
            credential = parsed.GetRequired("Id");
            try
            {
                secret = Convert.FromBase64String(parsed.GetRequired("Secret"));
            }
            catch (FormatException)
            {
                throw new InvalidOperationException("Specified Secret value isn't a valid base64 string");
            }
        }
    }
}
