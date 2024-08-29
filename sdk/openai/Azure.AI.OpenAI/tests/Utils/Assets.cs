// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;

namespace Azure.AI.OpenAI.Tests
{
    public class Assets
    {
        public Assets()
        {
            HelloWorld = new()
            {
                Type = AssetType.Audio,
                Language = "en",
                Description = "Hello world",
                Name = "hello_world.m4a",
                RelativePath = GetPath("hello_world.m4a"),
                MimeType = "audio/m4a"
            };
            WhisperFrenchDescription = new()
            {
                Type = AssetType.Audio,
                Language = "fr",
                Description = "Whisper description in French",
                Name = "french.wav",
                RelativePath = GetPath("french.wav"),
                MimeType = "audio/wave"
            };
            DogAndCat = new()
            {
                Type = AssetType.Image,
                Language = null,
                Description = "A picture of a cat next to a dog",
                Name = "variation_sample_image.jpg",
                RelativePath = GetPath("variation_sample_image.png"),
                MimeType = "image/png",
                Url = new Uri("https://cdn.openai.com/API/images/guides/image_variation_original.webp")
            };
            FineTuning = new()
            {
                Type = AssetType.Text,
                Language = "en",
                Description = "Fine tuning data for Open AI to generate a JSON object based on sports headlines",
                Name = "fine_tuning.jsonl",
                RelativePath = GetPath("fine_tuning.jsonl"),
                MimeType = "text/plain"
            };
        }

        public virtual AssetInfo HelloWorld { get; }
        public virtual AssetInfo WhisperFrenchDescription { get; }
        public virtual AssetInfo DogAndCat { get; }
        public virtual AssetInfo FineTuning { get; }

        protected virtual string GetPath(string assetName)
        {
            return Path.Combine("Assets", assetName);
        }
    }

    public enum AssetType
    {
        Text,
        Audio,
        Image,
        Raw
    }

    public class AssetInfo
    {
        required public AssetType Type { get; init; }
        required public string Name { get; init; }
        required public string RelativePath { get; init; }
        required public string MimeType { get; init; }
        public string? Language { get; init; }
        public string? Description { get; init; }
        public Uri? Url { get; init; }
    }
}
