// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Vision.Face
{
    // Data plane generated sub-client.
    /// <summary> The FaceList sub-client. </summary>
    [CodeGenClient("FaceListClientImpl")]
    public partial class FaceListClient
    {
        /// <summary> Initializes a new instance of FaceClient. </summary>
        /// <param name="endpoint">
        /// Supported Cognitive Services endpoints (protocol and hostname, for example:
        /// https://{resource-name}.cognitiveservices.azure.com).
        /// </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public FaceListClient(Uri endpoint, AzureKeyCredential credential) : this(endpoint, credential, new AzureAIVisionFaceClientOptions())
        {
        }

        /// <summary> Initializes a new instance of FaceClient. </summary>
        /// <param name="endpoint">
        /// Supported Cognitive Services endpoints (protocol and hostname, for example:
        /// https://{resource-name}.cognitiveservices.azure.com).
        /// </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public FaceListClient(Uri endpoint, TokenCredential credential) : this(endpoint, credential, new AzureAIVisionFaceClientOptions())
        {
        }

        /// <summary> Initializes a new instance of FaceListClient. </summary>
        /// <param name="endpoint">
        /// Supported Cognitive Services endpoints (protocol and hostname, for example:
        /// https://{resource-name}.cognitiveservices.azure.com).
        /// </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public FaceListClient(Uri endpoint, AzureKeyCredential credential, AzureAIVisionFaceClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new AzureAIVisionFaceClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <summary> Initializes a new instance of FaceClient. </summary>
        /// <param name="endpoint">
        /// Supported Cognitive Services endpoints (protocol and hostname, for example:
        /// https://{resource-name}.cognitiveservices.azure.com).
        /// </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public FaceListClient(Uri endpoint, TokenCredential credential, AzureAIVisionFaceClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new AzureAIVisionFaceClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _tokenCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes) }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <summary> Add a face to a specified Face List, up to 1,000 faces. </summary>
        /// <param name="faceListId"> Valid character is letter in lower case or digit or '-' or '_', maximum length is 64. </param>
        /// <param name="uri"> URL of input image. </param>
        /// <param name="targetFace"> A face rectangle to specify the target face to be added to a person, in the format of 'targetFace=left,top,width,height'. </param>
        /// <param name="detectionModel"> The 'detectionModel' associated with the detected faceIds. Supported 'detectionModel' values include 'detection_01', 'detection_02' and 'detection_03'. The default value is 'detection_01'. </param>
        /// <param name="userData"> User-provided data attached to the face. The size limit is 1K. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="faceListId"/> or <paramref name="uri"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="faceListId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <remarks> Please refer to https://learn.microsoft.com/rest/api/face/face-list-operations/add-face-list-face-from-url for more details. </remarks>
        [ForwardsClientCalls]
        public virtual Task<Response<AddFaceResult>> AddFaceAsync(string faceListId, Uri uri, IEnumerable<int> targetFace = null, FaceDetectionModel? detectionModel = null, string userData = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(faceListId, nameof(faceListId));
            Argument.AssertNotNull(uri, nameof(uri));

            return AddFaceFromUrlImplAsync(faceListId, uri, targetFace, detectionModel, userData, cancellationToken);
        }

        /// <summary> Add a face to a specified Face List, up to 1,000 faces. </summary>
        /// <param name="faceListId"> Valid character is letter in lower case or digit or '-' or '_', maximum length is 64. </param>
        /// <param name="uri"> URL of input image. </param>
        /// <param name="targetFace"> A face rectangle to specify the target face to be added to a person, in the format of 'targetFace=left,top,width,height'. </param>
        /// <param name="detectionModel"> The 'detectionModel' associated with the detected faceIds. Supported 'detectionModel' values include 'detection_01', 'detection_02' and 'detection_03'. The default value is 'detection_01'. </param>
        /// <param name="userData"> User-provided data attached to the face. The size limit is 1K. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="faceListId"/> or <paramref name="uri"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="faceListId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <remarks> Please refer to https://learn.microsoft.com/rest/api/face/face-list-operations/add-face-list-face-from-url for more details. </remarks>
        [ForwardsClientCalls]
        public virtual Response<AddFaceResult> AddFace(string faceListId, Uri uri, IEnumerable<int> targetFace = null, FaceDetectionModel? detectionModel = null, string userData = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(faceListId, nameof(faceListId));
            Argument.AssertNotNull(uri, nameof(uri));

            return AddFaceFromUrlImpl(faceListId, uri, targetFace, detectionModel, userData, cancellationToken);
        }

        /// <summary> Add a face to a specified Face List, up to 1,000 faces. </summary>
        /// <param name="faceListId"> Valid character is letter in lower case or digit or '-' or '_', maximum length is 64. </param>
        /// <param name="imageContent"> The image to be analyzed. </param>
        /// <param name="targetFace"> A face rectangle to specify the target face to be added to a person, in the format of 'targetFace=left,top,width,height'. </param>
        /// <param name="detectionModel"> The 'detectionModel' associated with the detected faceIds. Supported 'detectionModel' values include 'detection_01', 'detection_02' and 'detection_03'. The default value is 'detection_01'. </param>
        /// <param name="userData"> User-provided data attached to the face. The size limit is 1K. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="faceListId"/> or <paramref name="imageContent"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="faceListId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <remarks> Please refer to https://learn.microsoft.com/rest/api/face/face-list-operations/add-face-list-face for more details. </remarks>
        [ForwardsClientCalls]
        public virtual Task<Response<AddFaceResult>> AddFaceAsync(string faceListId, BinaryData imageContent, IEnumerable<int> targetFace = null, FaceDetectionModel? detectionModel = null, string userData = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(faceListId, nameof(faceListId));
            Argument.AssertNotNull(imageContent, nameof(imageContent));

            return AddFaceImplAsync(faceListId, imageContent, targetFace, detectionModel, userData, cancellationToken);
        }

        /// <summary> Add a face to a specified Face List, up to 1,000 faces. </summary>
        /// <param name="faceListId"> Valid character is letter in lower case or digit or '-' or '_', maximum length is 64. </param>
        /// <param name="imageContent"> The image to be analyzed. </param>
        /// <param name="targetFace"> A face rectangle to specify the target face to be added to a person, in the format of 'targetFace=left,top,width,height'. </param>
        /// <param name="detectionModel"> The 'detectionModel' associated with the detected faceIds. Supported 'detectionModel' values include 'detection_01', 'detection_02' and 'detection_03'. The default value is 'detection_01'. </param>
        /// <param name="userData"> User-provided data attached to the face. The size limit is 1K. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="faceListId"/> or <paramref name="imageContent"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="faceListId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <remarks> Please refer to https://learn.microsoft.com/rest/api/face/face-list-operations/add-face-list-face for more details. </remarks>
        [ForwardsClientCalls]
        public virtual Response<AddFaceResult> AddFace(string faceListId, BinaryData imageContent, IEnumerable<int> targetFace = null, FaceDetectionModel? detectionModel = null, string userData = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(faceListId, nameof(faceListId));
            Argument.AssertNotNull(imageContent, nameof(imageContent));

            return AddFace(faceListId, imageContent, targetFace, detectionModel, userData, cancellationToken);
        }

        /// <summary>
        /// [Protocol Method] Add a face to a specified Face List, up to 1,000 faces.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="AddFaceAsync(string,BinaryData,IEnumerable{int},FaceDetectionModel?,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="faceListId"> Valid character is letter in lower case or digit or '-' or '_', maximum length is 64. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="targetFace"> A face rectangle to specify the target face to be added to a person, in the format of 'targetFace=left,top,width,height'. </param>
        /// <param name="detectionModel"> The 'detectionModel' associated with the detected faceIds. Supported 'detectionModel' values include 'detection_01', 'detection_02' and 'detection_03'. The default value is 'detection_01'. Allowed values: "detection_01" | "detection_02" | "detection_03". </param>
        /// <param name="userData"> User-provided data attached to the face. The size limit is 1K. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="faceListId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="faceListId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        [ForwardsClientCalls]
        public virtual Task<Response> AddFaceAsync(string faceListId, RequestContent content, IEnumerable<int> targetFace = null, string detectionModel = null, string userData = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(faceListId, nameof(faceListId));
            Argument.AssertNotNull(content, nameof(content));

            return AddFaceAsync(faceListId, content, targetFace, detectionModel, userData, context);
        }

        /// <summary>
        /// [Protocol Method] Add a face to a specified Face List, up to 1,000 faces.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="AddFace(string,BinaryData,IEnumerable{int},FaceDetectionModel?,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="faceListId"> Valid character is letter in lower case or digit or '-' or '_', maximum length is 64. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="targetFace"> A face rectangle to specify the target face to be added to a person, in the format of 'targetFace=left,top,width,height'. </param>
        /// <param name="detectionModel"> The 'detectionModel' associated with the detected faceIds. Supported 'detectionModel' values include 'detection_01', 'detection_02' and 'detection_03'. The default value is 'detection_01'. Allowed values: "detection_01" | "detection_02" | "detection_03". </param>
        /// <param name="userData"> User-provided data attached to the face. The size limit is 1K. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="faceListId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="faceListId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        [ForwardsClientCalls]
        public virtual Response AddFace(string faceListId, RequestContent content, IEnumerable<int> targetFace = null, string detectionModel = null, string userData = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(faceListId, nameof(faceListId));
            Argument.AssertNotNull(content, nameof(content));

            return AddFace(faceListId, content, targetFace, detectionModel, userData, context);
        }
    }
}