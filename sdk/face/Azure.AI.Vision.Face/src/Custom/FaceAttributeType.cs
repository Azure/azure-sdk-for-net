// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.Vision.Face
{
    /// <summary> Available options for detect face with attribute. </summary>
    public readonly partial struct FaceAttributeType : IEquatable<FaceAttributeType>
    {
        /// <summary> Available attributes for detection01 model. </summary>
        public struct Detection01 {
            /// <summary> 3-D roll/yaw/pitch angles for face direction. </summary>
            public static FaceAttributeType HeadPose { get; } = FaceAttributeType.HeadPose;
            /// <summary> Glasses type. Values include 'NoGlasses', 'ReadingGlasses', 'Sunglasses', 'SwimmingGoggles'. </summary>
            public static FaceAttributeType Glasses { get; } = FaceAttributeType.Glasses;
            /// <summary> Whether each facial area is occluded, including forehead, eyes and mouth. </summary>
            public static FaceAttributeType Occlusion { get; } = FaceAttributeType.Occlusion;
            /// <summary> Accessories around face, including 'headwear', 'glasses' and 'mask'. Empty array means no accessories detected. Note this is after a face is detected. Large mask could result in no face to be detected. </summary>
            public static FaceAttributeType Accessories { get; } = FaceAttributeType.Accessories;
            /// <summary> Face is blurry or not. Level returns 'Low', 'Medium' or 'High'. Value returns a number between [0,1], the larger the blurrier. </summary>
            public static FaceAttributeType Blur { get; } = FaceAttributeType.Blur;
            /// <summary> Face exposure level. Level returns 'GoodExposure', 'OverExposure' or 'UnderExposure'. </summary>
            public static FaceAttributeType Exposure { get; } = FaceAttributeType.Exposure;
            /// <summary> Noise level of face pixels. Level returns 'Low', 'Medium' and 'High'. Value returns a number between [0,1], the larger the noisier. </summary>
            public static FaceAttributeType Noise { get; } = FaceAttributeType.Noise;
        }

        /// <summary> Available attributes for detection03 model. </summary>
        public struct Detection03 {
            /// <summary> 3-D roll/yaw/pitch angles for face direction. </summary>
            public static FaceAttributeType HeadPose { get; } = FaceAttributeType.HeadPose;
            /// <summary> Whether each face is wearing a mask. Mask type returns 'noMask', 'faceMask', 'otherMaskOrOcclusion', or 'uncertain'. Value returns a boolean 'noseAndMouthCovered' indicating whether nose and mouth are covered. </summary>
            public static FaceAttributeType Mask { get; } = FaceAttributeType.Mask;
            /// <summary> Face is blurry or not. Level returns 'Low', 'Medium' or 'High'. Value returns a number between [0,1], the larger the blurrier. </summary>
            public static FaceAttributeType Blur { get; } = FaceAttributeType.Blur;
        }

        /// <summary> Available attributes for recognition03 model. </summary>
        public struct Recognition03 {
            /// <summary> The overall image quality regarding whether the image being used in the detection is of sufficient quality to attempt face recognition on. The value is an informal rating of low, medium, or high. Only 'high' quality images are recommended for person enrollment and quality at or above 'medium' is recommended for identification scenarios. The attribute is only available when using any combinations of detection models detection_01 or detection_03, and recognition models recognition_03 or recognition_04. </summary>
            public static FaceAttributeType QualityForRecognition { get; } = FaceAttributeType.QualityForRecognition;
        }

        /// <summary> Available attributes for recognition04 model. </summary>
        public struct Recognition04 {
            /// <summary> The overall image quality regarding whether the image being used in the detection is of sufficient quality to attempt face recognition on. The value is an informal rating of low, medium, or high. Only 'high' quality images are recommended for person enrollment and quality at or above 'medium' is recommended for identification scenarios. The attribute is only available when using any combinations of detection models detection_01 or detection_03, and recognition models recognition_03 or recognition_04. </summary>
            public static FaceAttributeType QualityForRecognition { get; } = FaceAttributeType.QualityForRecognition;
        }
    }
}
