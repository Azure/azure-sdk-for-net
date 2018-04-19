// -----------------------------------------------------------------------
// <copyright file="CropArea.cs" company="Microsoft">
//  Copyright (c) Microsoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Azure.CognitiveServices.Search.VisualSearch.TestModels
{
    using Newtonsoft.Json;

    public partial class CropArea
    {
        /// <summary>
        /// Initializes a new instance of the CropArea class.
        /// </summary>
        public CropArea()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the CropArea class.
        /// </summary>
        /// <param name="top">The top coordinate of the region to be cropped. 
        /// The coordinate is a fractional value of the original image's height 
        /// and is measured from the top, left corner of the image. Specify the 
        /// coordinate as a value from 0.0 through 1.0.</param>
        /// <param name="bottom">The bottom coordinate of the region to be cropped. 
        /// The coordinate is a fractional value of the original image's height 
        /// and is measured from the top, left corner of the image. Specify the 
        /// coordinate as a value from 0.0 through 1.0.</param>
        /// <param name="left">The left coordinate of the region to be cropped. 
        /// The coordinate is a fractional value of the original image's height 
        /// and is measured from the top, left corner of the image. Specify the 
        /// coordinate as a value from 0.0 through 1.0.</param>
        /// <param name="right">The right coordinate of the region to be cropped. 
        /// The coordinate is a fractional value of the original image's height 
        /// and is measured from the top, left corner of the image. Specify the 
        /// coordinate as a value from 0.0 through 1.0.</param>
        public CropArea(float top = default(float), float bottom = default(float), float left = default(float), float right = default(float))
        {
            Top = top;
            Bottom = bottom;
            Left = left;
            Right = right;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets top coordinate of the region to be cropped.
        /// </summary>
        [JsonProperty(PropertyName = "top")]
        public float Top { get; private set; }

        /// <summary>
        /// Gets bottom coordinate of the region to be cropped.
        /// </summary>
        [JsonProperty(PropertyName = "bottom")]
        public float Bottom { get; private set; }

        /// <summary>
        /// Gets left coordinate of the region to be cropped.
        /// </summary>
        [JsonProperty(PropertyName = "left")]
        public float Left { get; private set; }

        /// <summary>
        /// Gets right coordinate of the region to be cropped.
        /// </summary>
        [JsonProperty(PropertyName = "right")]
        public float Right { get; private set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            //Nothing to validate
        }
    }
}
