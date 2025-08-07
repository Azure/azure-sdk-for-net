// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.IO;

namespace Azure.AI.Inference
{
    public partial class ImageEmbeddingInput
    {
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
