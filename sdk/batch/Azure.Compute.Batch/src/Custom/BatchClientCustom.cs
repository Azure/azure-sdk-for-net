// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core.Pipeline;
using Azure.Core;
using Azure.Compute.Batch.Custom;

namespace Azure.Compute.Batch
{
    public partial class BatchClient
    {
        private readonly AzureNamedKeyCredential _namedKeyCredential;

        /// <summary> Initializes a new instance of BatchClient. </summary>
        /// <param name="endpoint"> Batch account endpoint (for example: https://batchaccount.eastus2.batch.azure.com). </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
        public BatchClient(Uri endpoint, AzureNamedKeyCredential credential) : this(endpoint, credential, new BatchClientOptions())
        {
        }

        /// <summary> Initializes a new instance of BatchClient. </summary>
        /// <param name="endpoint"> Batch account endpoint (for example: https://batchaccount.eastus2.batch.azure.com). </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
        public BatchClient(Uri endpoint, AzureNamedKeyCredential credential, BatchClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new BatchClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _namedKeyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new BatchNamedKeyCredentialPolicy(credential) }, new ResponseClassifier());
        }
    }
}
