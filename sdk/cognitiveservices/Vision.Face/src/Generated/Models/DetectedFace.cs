// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.CognitiveServices.Vision.Face.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Detected Face object.
    /// </summary>
    public partial class DetectedFace
    {
        /// <summary>
        /// Initializes a new instance of the DetectedFace class.
        /// </summary>
        public DetectedFace()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the DetectedFace class.
        /// </summary>
        /// <param name="recognitionModel">Possible values include:
        /// 'recognition_01', 'recognition_02', 'recognition_03',
        /// 'recognition_04'</param>
        public DetectedFace(FaceRectangle faceRectangle, System.Guid? faceId = default(System.Guid?), string recognitionModel = default(string), FaceLandmarks faceLandmarks = default(FaceLandmarks), FaceAttributes faceAttributes = default(FaceAttributes))
        {
            FaceId = faceId;
            RecognitionModel = recognitionModel;
            FaceRectangle = faceRectangle;
            FaceLandmarks = faceLandmarks;
            FaceAttributes = faceAttributes;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "faceId")]
        public System.Guid? FaceId { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'recognition_01',
        /// 'recognition_02', 'recognition_03', 'recognition_04'
        /// </summary>
        [JsonProperty(PropertyName = "recognitionModel")]
        public string RecognitionModel { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "faceRectangle")]
        public FaceRectangle FaceRectangle { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "faceLandmarks")]
        public FaceLandmarks FaceLandmarks { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "faceAttributes")]
        public FaceAttributes FaceAttributes { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (FaceRectangle == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "FaceRectangle");
            }
            if (FaceRectangle != null)
            {
                FaceRectangle.Validate();
            }
            if (FaceLandmarks != null)
            {
                FaceLandmarks.Validate();
            }
        }
    }
}
