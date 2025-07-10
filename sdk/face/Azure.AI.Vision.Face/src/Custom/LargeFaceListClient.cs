// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.Vision.Face
{
    /// <summary> The LargeFaceList sub-client. </summary>
    public partial class LargeFaceListClient
    {
        /// <summary> Initializes a new instance of LargeFaceListClient for mocking. </summary>
        protected LargeFaceListClient()
        {
        }

        /// <summary> Initializes a new instance of LargeFaceListClient. </summary>
        /// <param name="endpoint">
        /// Supported Cognitive Services endpoints (protocol and hostname, for example:
        /// https://{resource-name}.cognitiveservices.azure.com).
        /// </param>
        /// <param name="largeFaceListId"> Valid character is letter in lower case or digit or '-' or '_', maximum length is 64. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public LargeFaceListClient(Uri endpoint, AzureKeyCredential credential, string largeFaceListId) : this(endpoint, credential, largeFaceListId, new FaceAdministrationClientOptions())
        {
        }

        /// <summary> Initializes a new instance of LargeFaceListClient. </summary>
        /// <param name="endpoint">
        /// Supported Cognitive Services endpoints (protocol and hostname, for example:
        /// https://{resource-name}.cognitiveservices.azure.com).
        /// </param>
        /// <param name="largeFaceListId"> Valid character is letter in lower case or digit or '-' or '_', maximum length is 64. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public LargeFaceListClient(Uri endpoint, TokenCredential credential, string largeFaceListId) : this(endpoint, credential, largeFaceListId, new FaceAdministrationClientOptions())
        {
        }

        /// <summary> Initializes a new instance of LargeFaceListClient. </summary>
        /// <param name="endpoint">
        /// Supported Cognitive Services endpoints (protocol and hostname, for example:
        /// https://{resource-name}.cognitiveservices.azure.com).
        /// </param>
        /// <param name="largeFaceListId"> Valid character is letter in lower case or digit or '-' or '_', maximum length is 64. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public LargeFaceListClient(Uri endpoint, AzureKeyCredential credential, string largeFaceListId, FaceAdministrationClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new FaceAdministrationClientOptions();
            // Implementation will be completed when generator supports it properly
        }

        /// <summary> Initializes a new instance of LargeFaceListClient. </summary>
        /// <param name="endpoint">
        /// Supported Cognitive Services endpoints (protocol and hostname, for example:
        /// https://{resource-name}.cognitiveservices.azure.com).
        /// </param>
        /// <param name="largeFaceListId"> Valid character is letter in lower case or digit or '-' or '_', maximum length is 64. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public LargeFaceListClient(Uri endpoint, TokenCredential credential, string largeFaceListId, FaceAdministrationClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new FaceAdministrationClientOptions();
            // Implementation will be completed when generator supports it properly
        }
    }
}