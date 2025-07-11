// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.Vision.Face
{
    // Data plane generated sub-client.
    /// <summary> The LargePersonGroup sub-client. </summary>
    [CodeGenType("LargePersonGroupClientImpl")]
    public partial class LargePersonGroupClient
    {
        /// <summary> Initializes a new instance of LargePersonGroupClient for mocking. </summary>
        protected LargePersonGroupClient()
        {
        }
        /// <summary> Initializes a new instance of LargePersonGroupClient. </summary>
        /// <param name="endpoint">
        /// Supported Cognitive Services endpoints (protocol and hostname, for example:
        /// https://{resource-name}.cognitiveservices.azure.com).
        /// </param>
        /// <param name="largePersonGroupId"> ID of the container. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public LargePersonGroupClient(Uri endpoint, AzureKeyCredential credential, string largePersonGroupId) : this(endpoint, credential, largePersonGroupId, new FaceAdministrationClientOptions())
        {
        }

        /// <summary> Initializes a new instance of LargePersonGroupClient. </summary>
        /// <param name="endpoint">
        /// Supported Cognitive Services endpoints (protocol and hostname, for example:
        /// https://{resource-name}.cognitiveservices.azure.com).
        /// </param>
        /// <param name="largePersonGroupId"> ID of the container. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public LargePersonGroupClient(Uri endpoint, TokenCredential credential, string largePersonGroupId) : this(endpoint, credential, largePersonGroupId, new FaceAdministrationClientOptions())
        {
        }

        /// <summary> Initializes a new instance of LargePersonGroupClient. </summary>
        /// <param name="endpoint">
        /// Supported Cognitive Services endpoints (protocol and hostname, for example:
        /// https://{resource-name}.cognitiveservices.azure.com).
        /// </param>
        /// <param name="largePersonGroupId"> ID of the container. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public LargePersonGroupClient(Uri endpoint, AzureKeyCredential credential, string largePersonGroupId, FaceAdministrationClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new FaceAdministrationClientOptions();
            // Implementation will be provided by the generator via CodeGenType
        }

        /// <summary> Initializes a new instance of LargePersonGroupClient. </summary>
        /// <param name="endpoint">
        /// Supported Cognitive Services endpoints (protocol and hostname, for example:
        /// https://{resource-name}.cognitiveservices.azure.com).
        /// </param>
        /// <param name="largePersonGroupId"> ID of the container. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public LargePersonGroupClient(Uri endpoint, TokenCredential credential, string largePersonGroupId, FaceAdministrationClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new FaceAdministrationClientOptions();
            // Implementation will be provided by the generator via CodeGenType
        }
    }
}