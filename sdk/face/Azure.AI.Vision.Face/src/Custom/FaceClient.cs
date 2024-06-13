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
        /// <remarks>
        /// &gt; [!IMPORTANT]
        /// &gt; To mitigate potential misuse that can subject people to stereotyping, discrimination, or unfair denial of services, we are retiring Face API attributes that predict emotion, gender, age, smile, facial hair, hair, and makeup. Read more about this decision https://azure.microsoft.com/en-us/blog/responsible-ai-investments-and-safeguards-for-facial-recognition/.
        ///
        /// *
        ///   * No image will be stored. Only the extracted face feature(s) will be stored on server. The faceId is an identifier of the face feature and will be used in "Identify", "Verify", and "Find Similar". The stored face features will expire and be deleted at the time specified by faceIdTimeToLive after the original detection call.
        ///   * Optional parameters include faceId, landmarks, and attributes. Attributes include headPose, glasses, occlusion, accessories, blur, exposure, noise, mask, and qualityForRecognition. Some of the results returned for specific attributes may not be highly accurate.
        ///   * JPEG, PNG, GIF (the first frame), and BMP format are supported. The allowed image file size is from 1KB to 6MB.
        ///   * The minimum detectable face size is 36x36 pixels in an image no larger than 1920x1080 pixels. Images with dimensions higher than 1920x1080 pixels will need a proportionally larger minimum face size.
        ///   * Up to 100 faces can be returned for an image. Faces are ranked by face rectangle size from large to small.
        ///   * For optimal results when querying "Identify", "Verify", and "Find Similar" ('returnFaceId' is true), please use faces that are: frontal, clear, and with a minimum size of 200x200 pixels (100 pixels between eyes).
        ///   * Different 'detectionModel' values can be provided. To use and compare different detection models, please refer to https://learn.microsoft.com/en-us/azure/ai-services/computer-vision/how-to/specify-detection-model
        ///     * 'detection_02': Face attributes and landmarks are disabled if you choose this detection model.
        ///     * 'detection_03': Face attributes (mask and headPose only) and landmarks are supported if you choose this detection model.
        ///   * Different 'recognitionModel' values are provided. If follow-up operations like "Verify", "Identify", "Find Similar" are needed, please specify the recognition model with 'recognitionModel' parameter. The default value for 'recognitionModel' is 'recognition_01', if latest model needed, please explicitly specify the model you need in this parameter. Once specified, the detected faceIds will be associated with the specified recognition model. More details, please refer to https://learn.microsoft.com/en-us/azure/ai-services/computer-vision/how-to/specify-recognition-model.
        /// </remarks>
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
        /// <remarks>
        /// &gt; [!IMPORTANT]
        /// &gt; To mitigate potential misuse that can subject people to stereotyping, discrimination, or unfair denial of services, we are retiring Face API attributes that predict emotion, gender, age, smile, facial hair, hair, and makeup. Read more about this decision https://azure.microsoft.com/en-us/blog/responsible-ai-investments-and-safeguards-for-facial-recognition/.
        ///
        /// *
        ///   * No image will be stored. Only the extracted face feature(s) will be stored on server. The faceId is an identifier of the face feature and will be used in "Identify", "Verify", and "Find Similar". The stored face features will expire and be deleted at the time specified by faceIdTimeToLive after the original detection call.
        ///   * Optional parameters include faceId, landmarks, and attributes. Attributes include headPose, glasses, occlusion, accessories, blur, exposure, noise, mask, and qualityForRecognition. Some of the results returned for specific attributes may not be highly accurate.
        ///   * JPEG, PNG, GIF (the first frame), and BMP format are supported. The allowed image file size is from 1KB to 6MB.
        ///   * The minimum detectable face size is 36x36 pixels in an image no larger than 1920x1080 pixels. Images with dimensions higher than 1920x1080 pixels will need a proportionally larger minimum face size.
        ///   * Up to 100 faces can be returned for an image. Faces are ranked by face rectangle size from large to small.
        ///   * For optimal results when querying "Identify", "Verify", and "Find Similar" ('returnFaceId' is true), please use faces that are: frontal, clear, and with a minimum size of 200x200 pixels (100 pixels between eyes).
        ///   * Different 'detectionModel' values can be provided. To use and compare different detection models, please refer to https://learn.microsoft.com/en-us/azure/ai-services/computer-vision/how-to/specify-detection-model
        ///     * 'detection_02': Face attributes and landmarks are disabled if you choose this detection model.
        ///     * 'detection_03': Face attributes (mask and headPose only) and landmarks are supported if you choose this detection model.
        ///   * Different 'recognitionModel' values are provided. If follow-up operations like "Verify", "Identify", "Find Similar" are needed, please specify the recognition model with 'recognitionModel' parameter. The default value for 'recognitionModel' is 'recognition_01', if latest model needed, please explicitly specify the model you need in this parameter. Once specified, the detected faceIds will be associated with the specified recognition model. More details, please refer to https://learn.microsoft.com/en-us/azure/ai-services/computer-vision/how-to/specify-recognition-model.
        /// </remarks>
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
        /// <remarks>
        /// &gt; [!IMPORTANT]
        /// &gt; To mitigate potential misuse that can subject people to stereotyping, discrimination, or unfair denial of services, we are retiring Face API attributes that predict emotion, gender, age, smile, facial hair, hair, and makeup. Read more about this decision https://azure.microsoft.com/en-us/blog/responsible-ai-investments-and-safeguards-for-facial-recognition/.
        ///
        /// *
        ///   * No image will be stored. Only the extracted face feature(s) will be stored on server. The faceId is an identifier of the face feature and will be used in "Identify", "Verify", and "Find Similar". The stored face features will expire and be deleted at the time specified by faceIdTimeToLive after the original detection call.
        ///   * Optional parameters include faceId, landmarks, and attributes. Attributes include headPose, glasses, occlusion, accessories, blur, exposure, noise, mask, and qualityForRecognition. Some of the results returned for specific attributes may not be highly accurate.
        ///   * JPEG, PNG, GIF (the first frame), and BMP format are supported. The allowed image file size is from 1KB to 6MB.
        ///   * The minimum detectable face size is 36x36 pixels in an image no larger than 1920x1080 pixels. Images with dimensions higher than 1920x1080 pixels will need a proportionally larger minimum face size.
        ///   * Up to 100 faces can be returned for an image. Faces are ranked by face rectangle size from large to small.
        ///   * For optimal results when querying "Identify", "Verify", and "Find Similar" ('returnFaceId' is true), please use faces that are: frontal, clear, and with a minimum size of 200x200 pixels (100 pixels between eyes).
        ///   * Different 'detectionModel' values can be provided. To use and compare different detection models, please refer to https://learn.microsoft.com/en-us/azure/ai-services/computer-vision/how-to/specify-detection-model
        ///     * 'detection_02': Face attributes and landmarks are disabled if you choose this detection model.
        ///     * 'detection_03': Face attributes (mask and headPose only) and landmarks are supported if you choose this detection model.
        ///   * Different 'recognitionModel' values are provided. If follow-up operations like "Verify", "Identify", "Find Similar" are needed, please specify the recognition model with 'recognitionModel' parameter. The default value for 'recognitionModel' is 'recognition_01', if latest model needed, please explicitly specify the model you need in this parameter. Once specified, the detected faceIds will be associated with the specified recognition model. More details, please refer to https://learn.microsoft.com/en-us/azure/ai-services/computer-vision/how-to/specify-recognition-model.
        /// </remarks>
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
        /// <remarks>
        /// &gt; [!IMPORTANT]
        /// &gt; To mitigate potential misuse that can subject people to stereotyping, discrimination, or unfair denial of services, we are retiring Face API attributes that predict emotion, gender, age, smile, facial hair, hair, and makeup. Read more about this decision https://azure.microsoft.com/en-us/blog/responsible-ai-investments-and-safeguards-for-facial-recognition/.
        ///
        /// *
        ///   * No image will be stored. Only the extracted face feature(s) will be stored on server. The faceId is an identifier of the face feature and will be used in "Identify", "Verify", and "Find Similar". The stored face features will expire and be deleted at the time specified by faceIdTimeToLive after the original detection call.
        ///   * Optional parameters include faceId, landmarks, and attributes. Attributes include headPose, glasses, occlusion, accessories, blur, exposure, noise, mask, and qualityForRecognition. Some of the results returned for specific attributes may not be highly accurate.
        ///   * JPEG, PNG, GIF (the first frame), and BMP format are supported. The allowed image file size is from 1KB to 6MB.
        ///   * The minimum detectable face size is 36x36 pixels in an image no larger than 1920x1080 pixels. Images with dimensions higher than 1920x1080 pixels will need a proportionally larger minimum face size.
        ///   * Up to 100 faces can be returned for an image. Faces are ranked by face rectangle size from large to small.
        ///   * For optimal results when querying "Identify", "Verify", and "Find Similar" ('returnFaceId' is true), please use faces that are: frontal, clear, and with a minimum size of 200x200 pixels (100 pixels between eyes).
        ///   * Different 'detectionModel' values can be provided. To use and compare different detection models, please refer to https://learn.microsoft.com/en-us/azure/ai-services/computer-vision/how-to/specify-detection-model
        ///     * 'detection_02': Face attributes and landmarks are disabled if you choose this detection model.
        ///     * 'detection_03': Face attributes (mask and headPose only) and landmarks are supported if you choose this detection model.
        ///   * Different 'recognitionModel' values are provided. If follow-up operations like "Verify", "Identify", "Find Similar" are needed, please specify the recognition model with 'recognitionModel' parameter. The default value for 'recognitionModel' is 'recognition_01', if latest model needed, please explicitly specify the model you need in this parameter. Once specified, the detected faceIds will be associated with the specified recognition model. More details, please refer to https://learn.microsoft.com/en-us/azure/ai-services/computer-vision/how-to/specify-recognition-model.
        /// </remarks>
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
