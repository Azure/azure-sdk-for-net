// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core.Pipeline;

namespace Azure.Storage.Files.DataLake
{
    internal partial class DataLakeClient
    {
        /// <summary> Initializes a new instance of DataLakeClient. </summary>
        /// <param name="authenticationPolicy"> The authentication policy to use for pipeline creation. </param>
        /// <param name="endpoint"> Service endpoint. </param>
        /// <param name="options"> The options for configuring the client. </param>
        internal DataLakeClient(HttpPipelinePolicy authenticationPolicy, Uri endpoint, DataLakeClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));

            options ??= new DataLakeClientOptions();

            _endpoint = endpoint;
            if (authenticationPolicy != null)
            {
                Pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { authenticationPolicy });
            }
            else
            {
                Pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>());
            }
            _version = options.Version.ToVersionString();
            ClientDiagnostics = new ClientDiagnostics(options, true);
        }
    }
}
