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
    /// <summary> The LargeFaceList sub-client. </summary>
    [CodeGenClient("LargeFaceListClientImpl")]
    public partial class LargeFaceListClient
    {
        /// <summary> Initializes a new instance of FaceClient. </summary>
        /// <param name="endpoint">
        /// Supported Cognitive Services endpoints (protocol and hostname, for example:
        /// https://{resource-name}.cognitiveservices.azure.com).
        /// </param>
        /// <param name="largeFaceListId"> Valid character is letter in lower case or digit or '-' or '_', maximum length is 64. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public LargeFaceListClient(Uri endpoint, AzureKeyCredential credential, string largeFaceListId) : this(endpoint, credential, largeFaceListId, new AzureAIVisionFaceClientOptions())
        {
        }

        /// <summary> Initializes a new instance of FaceClient. </summary>
        /// <param name="endpoint">
        /// <param name="largeFaceListId"> Valid character is letter in lower case or digit or '-' or '_', maximum length is 64. </param>
        /// Supported Cognitive Services endpoints (protocol and hostname, for example:
        /// https://{resource-name}.cognitiveservices.azure.com).
        /// </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public LargeFaceListClient(Uri endpoint, TokenCredential credential, string largeFaceListId) : this(endpoint, credential, largeFaceListId, new AzureAIVisionFaceClientOptions())
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
        public LargeFaceListClient(Uri endpoint, AzureKeyCredential credential, string largeFaceListId, AzureAIVisionFaceClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new AzureAIVisionFaceClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
            _largeFaceListId = largeFaceListId;
        }

        /// <summary> Initializes a new instance of FaceClient. </summary>
        /// <param name="endpoint">
        /// Supported Cognitive Services endpoints (protocol and hostname, for example:
        /// https://{resource-name}.cognitiveservices.azure.com).
        /// </param>
        /// <param name="largeFaceListId"> Valid character is letter in lower case or digit or '-' or '_', maximum length is 64. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public LargeFaceListClient(Uri endpoint, TokenCredential credential, string largeFaceListId, AzureAIVisionFaceClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new AzureAIVisionFaceClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _tokenCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes) }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
            _largeFaceListId = largeFaceListId;
        }

        /// <summary> Add a face to a specified Large Face List, up to 1,000,000 faces. </summary>
        /// <param name="uri"> URL of input image. </param>
        /// <param name="targetFace"> A face rectangle to specify the target face to be added to a person, in the format of 'targetFace=left,top,width,height'. </param>
        /// <param name="detectionModel"> The 'detectionModel' associated with the detected faceIds. Supported 'detectionModel' values include 'detection_01', 'detection_02' and 'detection_03'. The default value is 'detection_01'. </param>
        /// <param name="userData"> User-provided data attached to the face. The size limit is 1K. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="uri"/> is null. </exception>
        /// <remarks> Please refer to https://learn.microsoft.com/rest/api/face/face-list-operations/add-large-face-list-face-from-url for more details. </remarks>
        [ForwardsClientCalls]
        public virtual Task<Response<AddFaceResult>> AddFaceAsync(Uri uri, IEnumerable<int> targetFace = null, FaceDetectionModel? detectionModel = null, string userData = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(uri, nameof(uri));

            return AddFaceFromUrlImplAsync(uri, targetFace, detectionModel, userData, cancellationToken);
        }

        /// <summary> Add a face to a specified Large Face List, up to 1,000,000 faces. </summary>
        /// <param name="uri"> URL of input image. </param>
        /// <param name="targetFace"> A face rectangle to specify the target face to be added to a person, in the format of 'targetFace=left,top,width,height'. </param>
        /// <param name="detectionModel"> The 'detectionModel' associated with the detected faceIds. Supported 'detectionModel' values include 'detection_01', 'detection_02' and 'detection_03'. The default value is 'detection_01'. </param>
        /// <param name="userData"> User-provided data attached to the face. The size limit is 1K. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="uri"/> is null. </exception>
        /// <remarks> Please refer to https://learn.microsoft.com/rest/api/face/face-list-operations/add-large-face-list-face-from-url for more details. </remarks>
        [ForwardsClientCalls]
        public virtual Response<AddFaceResult> AddFace(Uri uri, IEnumerable<int> targetFace = null, FaceDetectionModel? detectionModel = null, string userData = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(uri, nameof(uri));

            return AddFaceFromUrlImpl(uri, targetFace, detectionModel, userData, cancellationToken);
        }

        /// <summary> Add a face to a specified Large Face List, up to 1,000,000 faces. </summary>
        /// <param name="imageContent"> The image to be analyzed. </param>
        /// <param name="targetFace"> A face rectangle to specify the target face to be added to a person, in the format of 'targetFace=left,top,width,height'. </param>
        /// <param name="detectionModel"> The 'detectionModel' associated with the detected faceIds. Supported 'detectionModel' values include 'detection_01', 'detection_02' and 'detection_03'. The default value is 'detection_01'. </param>
        /// <param name="userData"> User-provided data attached to the face. The size limit is 1K. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="imageContent"/> is null. </exception>
        /// <remarks> Please refer to https://learn.microsoft.com/rest/api/face/face-list-operations/add-large-face-list-face for more details. </remarks>
        [ForwardsClientCalls]
        public virtual Task<Response<AddFaceResult>> AddFaceAsync(BinaryData imageContent, IEnumerable<int> targetFace = null, FaceDetectionModel? detectionModel = null, string userData = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(imageContent, nameof(imageContent));

            return AddFaceImplAsync(imageContent, targetFace, detectionModel, userData, cancellationToken);
        }

        /// <summary> Add a face to a specified Large Face List, up to 1,000,000 faces. </summary>
        /// <param name="imageContent"> The image to be analyzed. </param>
        /// <param name="targetFace"> A face rectangle to specify the target face to be added to a person, in the format of 'targetFace=left,top,width,height'. </param>
        /// <param name="detectionModel"> The 'detectionModel' associated with the detected faceIds. Supported 'detectionModel' values include 'detection_01', 'detection_02' and 'detection_03'. The default value is 'detection_01'. </param>
        /// <param name="userData"> User-provided data attached to the face. The size limit is 1K. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="imageContent"/> is null. </exception>
        /// <remarks> Please refer to https://learn.microsoft.com/rest/api/face/face-list-operations/add-large-face-list-face for more details. </remarks>
        [ForwardsClientCalls]
        public virtual Response<AddFaceResult> AddFace(BinaryData imageContent, IEnumerable<int> targetFace = null, FaceDetectionModel? detectionModel = null, string userData = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(imageContent, nameof(imageContent));

            return AddFaceImpl(imageContent, targetFace, detectionModel, userData, cancellationToken);
        }

        /// <summary>
        /// [Protocol Method] Add a face to a specified Large Face List, up to 1,000,000 faces.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="AddFaceAsync(BinaryData,IEnumerable{int},FaceDetectionModel?,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="targetFace"> A face rectangle to specify the target face to be added to a person, in the format of 'targetFace=left,top,width,height'. </param>
        /// <param name="detectionModel"> The 'detectionModel' associated with the detected faceIds. Supported 'detectionModel' values include 'detection_01', 'detection_02' and 'detection_03'. The default value is 'detection_01'. Allowed values: "detection_01" | "detection_02" | "detection_03". </param>
        /// <param name="userData"> User-provided data attached to the face. The size limit is 1K. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        [ForwardsClientCalls]
        public virtual Task<Response> AddFaceAsync(RequestContent content, IEnumerable<int> targetFace = null, string detectionModel = null, string userData = null, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            return AddFaceImplAsync(content, targetFace, detectionModel, userData, context);
        }

        /// <summary>
        /// [Protocol Method] Add a face to a specified Large Face List, up to 1,000,000 faces.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="AddFace(BinaryData,IEnumerable{int},FaceDetectionModel?,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="targetFace"> A face rectangle to specify the target face to be added to a person, in the format of 'targetFace=left,top,width,height'. </param>
        /// <param name="detectionModel"> The 'detectionModel' associated with the detected faceIds. Supported 'detectionModel' values include 'detection_01', 'detection_02' and 'detection_03'. The default value is 'detection_01'. Allowed values: "detection_01" | "detection_02" | "detection_03". </param>
        /// <param name="userData"> User-provided data attached to the face. The size limit is 1K. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        [ForwardsClientCalls]
        public virtual Response AddFace(RequestContent content, IEnumerable<int> targetFace = null, string detectionModel = null, string userData = null, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            return AddFaceImpl(content, targetFace, detectionModel, userData, context);
        }
    }
}