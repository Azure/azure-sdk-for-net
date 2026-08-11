// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.IO;

namespace Azure.AI.Inference
{
    public partial class ImageEmbeddingInput
    {
        /// <summary> Creates a new <see cref="ImageEmbeddingInput"/> from the contents of a local image file. </summary>
        /// <param name="imageFilePath"> The path of the image file to read. </param>
        /// <param name="imageFormat"> The format of the image, such as <c>png</c> or <c>jpeg</c>. </param>
        /// <param name="text"> Optional text to associate with the image when generating the embedding. </param>
        /// <returns> A new <see cref="ImageEmbeddingInput"/> containing the image encoded as a data URL. </returns>
        public static ImageEmbeddingInput Load(string imageFilePath, string imageFormat, string text = null)
        {
            byte[] imageArray = File.ReadAllBytes(imageFilePath);
            string base64ImageData = Convert.ToBase64String(imageArray);

            string imageUrl = $"data:image/{imageFormat};base64,{base64ImageData}";
            ImageEmbeddingInput imageInput = new ImageEmbeddingInput(imageUrl)
            {
                Text = text
            };

            return imageInput;
        }
    }
}
