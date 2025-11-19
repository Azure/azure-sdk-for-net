// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Developer.LoadTesting
{
    [CodeGenSuppress("GetTestRunsAsync", typeof(string), typeof(string), typeof(string), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(string), typeof(int?), typeof(RequestContext))]
    [CodeGenSuppress("GetTestRuns", typeof(string), typeof(string), typeof(string), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(string), typeof(int?), typeof(RequestContext))]
    [CodeGenSuppress("GetTestRunsAsync", typeof(string), typeof(string), typeof(string), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(string), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetTestRuns", typeof(string), typeof(string), typeof(string), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(string), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetTestProfileRuns", typeof(int?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(RequestContext))]
    [CodeGenSuppress("GetTestProfileRunsAsync", typeof(int?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(RequestContext))]
    [CodeGenSuppress("GetTestProfileRuns", typeof(int?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(CancellationToken))]
    [CodeGenSuppress("GetTestProfileRunsAsync", typeof(int?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(CancellationToken))]
    public partial class LoadTestRunClient
    {
        /// <summary> Initializes a new instance of LoadTestRunClient. </summary>
        /// <param name="endpoint"></param>
        /// <param name="credential"> A credential used to authenticate to the service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="endpoint"/> is an empty string, and was expected to be non-empty. </exception>
        public LoadTestRunClient(Uri endpoint, TokenCredential credential) : this(endpoint, credential, new LoadTestingClientOptions())
        {
        }

        /// <summary> Initializes a new instance of LoadTestRunClient. </summary>
        /// <param name="endpoint"></param>
        /// <param name="credential"> A credential used to authenticate to the service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="endpoint"/> is an empty string, and was expected to be non-empty. </exception>
        public LoadTestRunClient(Uri endpoint, TokenCredential credential, LoadTestingClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new LoadTestingClientOptions();

            _endpoint = new Uri($"https://{endpoint}");
            _tokenCredential = credential;
            Pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes) });
            _apiVersion = options.Version;
            ClientDiagnostics = new ClientDiagnostics(options, true);
        }
    }
}
