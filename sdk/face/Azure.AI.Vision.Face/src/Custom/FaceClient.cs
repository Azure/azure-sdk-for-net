// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.AI.Vision.Face
{
    /// <summary> The Face service client. </summary>
    public partial class FaceClient
    {
        /// <summary> Detect human faces in an image, return face rectangles, and optionally with faceIds, landmarks, and attributes. </summary>
        /// <param name="url"> URL of input image. </param>
        /// <param name="detectionModel"> The 'detectionModel' associated with the detected faceIds. Supported 'detectionModel' values include 'detection_01', 'detection_02' and 'detection_03'. The default value is 'detection_01'. </param>
        /// <param name="recognitionModel"> The 'recognitionModel' associated with the detected faceIds. Supported 'recognitionModel' values include 'recognition_01', 'recognition_02', 'recognition_03' or 'recognition_04'. The default value is 'recognition_01'. 'recognition_04' is recommended since its accuracy is improved on faces wearing masks compared with 'recognition_03', and its overall accuracy is improved compared with 'recognition_01' and 'recognition_02'. </param>
        /// <param name="returnFaceId"> Return faceIds of the detected faces or not. The default value is true. </param>
        /// <param name="returnFaceAttributes"> Analyze and return the one or more specified face attributes in the comma-separated string like 'returnFaceAttributes=headPose,glasses'. Face attribute analysis has additional computational and time cost. </param>
        /// <param name="returnFaceLandmarks"> Return face landmarks of the detected faces or not. The default value is false. </param>
        /// <param name="returnRecognitionModel"> Return 'recognitionModel' or not. The default value is false. </param>
        /// <param name="faceIdTimeToLive"> The number of seconds for the face ID being cached. Supported range from 60 seconds up to 86400 seconds. The default value is 86400 (24 hours). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="url"/> is null. </exception>
        /// <remarks> Please refer to https://learn.microsoft.com/rest/api/face/face-detection-operations/detect-from-url for more details. </remarks>
        [ForwardsClientCalls]
        public virtual Task<Response<IReadOnlyList<FaceDetectionResult>>> DetectAsync(
            Uri url,
            FaceDetectionModel detectionModel,
            FaceRecognitionModel recognitionModel,
            bool returnFaceId,
            IEnumerable<FaceAttributeType> returnFaceAttributes = null,
            bool? returnFaceLandmarks = null,
            bool? returnRecognitionModel = null,
            int? faceIdTimeToLive = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(url, nameof(url));
            Argument.AssertNotNull(detectionModel, nameof(detectionModel));
            Argument.AssertNotNull(recognitionModel, nameof(recognitionModel));
            Argument.AssertNotNull(returnFaceId, nameof(returnFaceId));

            return DetectFromUrlImplAsync(url, detectionModel, recognitionModel, returnFaceId, returnFaceAttributes, returnFaceLandmarks, returnRecognitionModel, faceIdTimeToLive, cancellationToken);
        }

        /// <summary> Detect human faces in an image, return face rectangles, and optionally with faceIds, landmarks, and attributes. </summary>
        /// <param name="url"> URL of input image. </param>
        /// <param name="detectionModel"> The 'detectionModel' associated with the detected faceIds. Supported 'detectionModel' values include 'detection_01', 'detection_02' and 'detection_03'. The default value is 'detection_01'. </param>
        /// <param name="recognitionModel"> The 'recognitionModel' associated with the detected faceIds. Supported 'recognitionModel' values include 'recognition_01', 'recognition_02', 'recognition_03' or 'recognition_04'. The default value is 'recognition_01'. 'recognition_04' is recommended since its accuracy is improved on faces wearing masks compared with 'recognition_03', and its overall accuracy is improved compared with 'recognition_01' and 'recognition_02'. </param>
        /// <param name="returnFaceId"> Return faceIds of the detected faces or not. The default value is true. </param>
        /// <param name="returnFaceAttributes"> Analyze and return the one or more specified face attributes in the comma-separated string like 'returnFaceAttributes=headPose,glasses'. Face attribute analysis has additional computational and time cost. </param>
        /// <param name="returnFaceLandmarks"> Return face landmarks of the detected faces or not. The default value is false. </param>
        /// <param name="returnRecognitionModel"> Return 'recognitionModel' or not. The default value is false. </param>
        /// <param name="faceIdTimeToLive"> The number of seconds for the face ID being cached. Supported range from 60 seconds up to 86400 seconds. The default value is 86400 (24 hours). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="url"/> is null. </exception>
        /// <remarks> Please refer to https://learn.microsoft.com/rest/api/face/face-detection-operations/detect-from-url for more details. </remarks>
        [ForwardsClientCalls]
        public virtual Response<IReadOnlyList<FaceDetectionResult>> Detect(
            Uri url,
            FaceDetectionModel detectionModel,
            FaceRecognitionModel recognitionModel,
            bool returnFaceId,
            IEnumerable<FaceAttributeType> returnFaceAttributes = null,
            bool? returnFaceLandmarks = null,
            bool? returnRecognitionModel = null,
            int? faceIdTimeToLive = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(url, nameof(url));
            Argument.AssertNotNull(detectionModel, nameof(detectionModel));
            Argument.AssertNotNull(recognitionModel, nameof(recognitionModel));
            Argument.AssertNotNull(returnFaceId, nameof(returnFaceId));

            return DetectFromUrlImpl(url, detectionModel, recognitionModel, returnFaceId, returnFaceAttributes, returnFaceLandmarks, returnRecognitionModel, faceIdTimeToLive, cancellationToken);
        }

        /// <summary> Detect human faces in an image, return face rectangles, and optionally with faceIds, landmarks, and attributes. </summary>
        /// <param name="imageContent"> The input image binary. </param>
        /// <param name="detectionModel"> The 'detectionModel' associated with the detected faceIds. Supported 'detectionModel' values include 'detection_01', 'detection_02' and 'detection_03'. The default value is 'detection_01'. </param>
        /// <param name="recognitionModel"> The 'recognitionModel' associated with the detected faceIds. Supported 'recognitionModel' values include 'recognition_01', 'recognition_02', 'recognition_03' or 'recognition_04'. The default value is 'recognition_01'. 'recognition_04' is recommended since its accuracy is improved on faces wearing masks compared with 'recognition_03', and its overall accuracy is improved compared with 'recognition_01' and 'recognition_02'. </param>
        /// <param name="returnFaceId"> Return faceIds of the detected faces or not. The default value is true. </param>
        /// <param name="returnFaceAttributes"> Analyze and return the one or more specified face attributes in the comma-separated string like 'returnFaceAttributes=headPose,glasses'. Face attribute analysis has additional computational and time cost. </param>
        /// <param name="returnFaceLandmarks"> Return face landmarks of the detected faces or not. The default value is false. </param>
        /// <param name="returnRecognitionModel"> Return 'recognitionModel' or not. The default value is false. </param>
        /// <param name="faceIdTimeToLive"> The number of seconds for the face ID being cached. Supported range from 60 seconds up to 86400 seconds. The default value is 86400 (24 hours). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="imageContent"/> is null. </exception>
        /// <remarks> Please refer to https://learn.microsoft.com/rest/api/face/face-detection-operations/detect for more details. </remarks>
        [ForwardsClientCalls]
        public virtual Task<Response<IReadOnlyList<FaceDetectionResult>>> DetectAsync(
            BinaryData imageContent,
            FaceDetectionModel detectionModel,
            FaceRecognitionModel recognitionModel,
            bool returnFaceId,
            IEnumerable<FaceAttributeType> returnFaceAttributes = null,
            bool? returnFaceLandmarks = null,
            bool? returnRecognitionModel = null,
            int? faceIdTimeToLive = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(imageContent, nameof(imageContent));
            Argument.AssertNotNull(detectionModel, nameof(detectionModel));
            Argument.AssertNotNull(recognitionModel, nameof(recognitionModel));
            Argument.AssertNotNull(returnFaceId, nameof(returnFaceId));

            return DetectImplAsync(imageContent, detectionModel, recognitionModel, returnFaceId, returnFaceAttributes, returnFaceLandmarks, returnRecognitionModel, faceIdTimeToLive, cancellationToken);
        }

        /// <summary> Detect human faces in an image, return face rectangles, and optionally with faceIds, landmarks, and attributes. </summary>
        /// <param name="imageContent"> The input image binary. </param>
        /// <param name="detectionModel"> The 'detectionModel' associated with the detected faceIds. Supported 'detectionModel' values include 'detection_01', 'detection_02' and 'detection_03'. The default value is 'detection_01'. </param>
        /// <param name="recognitionModel"> The 'recognitionModel' associated with the detected faceIds. Supported 'recognitionModel' values include 'recognition_01', 'recognition_02', 'recognition_03' or 'recognition_04'. The default value is 'recognition_01'. 'recognition_04' is recommended since its accuracy is improved on faces wearing masks compared with 'recognition_03', and its overall accuracy is improved compared with 'recognition_01' and 'recognition_02'. </param>
        /// <param name="returnFaceId"> Return faceIds of the detected faces or not. The default value is true. </param>
        /// <param name="returnFaceAttributes"> Analyze and return the one or more specified face attributes in the comma-separated string like 'returnFaceAttributes=headPose,glasses'. Face attribute analysis has additional computational and time cost. </param>
        /// <param name="returnFaceLandmarks"> Return face landmarks of the detected faces or not. The default value is false. </param>
        /// <param name="returnRecognitionModel"> Return 'recognitionModel' or not. The default value is false. </param>
        /// <param name="faceIdTimeToLive"> The number of seconds for the face ID being cached. Supported range from 60 seconds up to 86400 seconds. The default value is 86400 (24 hours). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="imageContent"/> is null. </exception>
        /// <remarks> Please refer to https://learn.microsoft.com/rest/api/face/face-detection-operations/detect for more details. </remarks>
        [ForwardsClientCalls]
        public virtual Response<IReadOnlyList<FaceDetectionResult>> Detect(
            BinaryData imageContent,
            FaceDetectionModel detectionModel,
            FaceRecognitionModel recognitionModel,
            bool returnFaceId,
            IEnumerable<FaceAttributeType> returnFaceAttributes = null,
            bool? returnFaceLandmarks = null,
            bool? returnRecognitionModel = null,
            int? faceIdTimeToLive = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(imageContent, nameof(imageContent));
            Argument.AssertNotNull(detectionModel, nameof(detectionModel));
            Argument.AssertNotNull(recognitionModel, nameof(recognitionModel));
            Argument.AssertNotNull(returnFaceId, nameof(returnFaceId));

            return DetectImpl(imageContent, detectionModel, recognitionModel, returnFaceId, returnFaceAttributes, returnFaceLandmarks, returnRecognitionModel, faceIdTimeToLive, cancellationToken);
        }
    }
}
