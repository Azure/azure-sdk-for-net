// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.Vision.Face
{
    /// <summary> Response body for find similar face operation. </summary>
    public partial class FaceFindSimilarResult
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="FaceFindSimilarResult"/>. </summary>
        /// <param name="confidence"> Confidence value of the candidate. The higher confidence, the more similar. Range between [0,1]. </param>
        internal FaceFindSimilarResult(float confidence)
        {
            Confidence = confidence;
        }

        /// <summary> Initializes a new instance of <see cref="FaceFindSimilarResult"/>. </summary>
        /// <param name="confidence"> Confidence value of the candidate. The higher confidence, the more similar. Range between [0,1]. </param>
        /// <param name="faceId"> faceId of candidate face when find by faceIds. faceId is created by "Detect" and will expire 24 hours after the detection call. </param>
        /// <param name="persistedFaceId"> persistedFaceId of candidate face when find by faceListId or largeFaceListId. persistedFaceId in face list/large face list is persisted and will not expire. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal FaceFindSimilarResult(float confidence, Guid? faceId, Guid? persistedFaceId, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Confidence = confidence;
            FaceId = faceId;
            PersistedFaceId = persistedFaceId;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="FaceFindSimilarResult"/> for deserialization. </summary>
        internal FaceFindSimilarResult()
        {
        }

        /// <summary> Confidence value of the candidate. The higher confidence, the more similar. Range between [0,1]. </summary>
        public float Confidence { get; }
        /// <summary> faceId of candidate face when find by faceIds. faceId is created by "Detect" and will expire 24 hours after the detection call. </summary>
        public Guid? FaceId { get; }
        /// <summary> persistedFaceId of candidate face when find by faceListId or largeFaceListId. persistedFaceId in face list/large face list is persisted and will not expire. </summary>
        public Guid? PersistedFaceId { get; }
    }
}
