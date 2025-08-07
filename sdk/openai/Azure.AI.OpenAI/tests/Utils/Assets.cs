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
            HelloWorldMp3 = new()
            {
                Type = AssetType.Audio,
                Language = "en",
                Description = "Hello world",
                Name = "audio_hello_world.mp3",
                RelativePath = GetPath("audio_hello_world.mp3"),
                MimeType = "audio/mp3"
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
            ScreenshotWithSaveButton = new()
            {
                Type = AssetType.Image,
                Language = null,
                Description = "A screenshot with a prominent 'Save' button to click",
                Name = "images_screenshot_with_save_1024_768.png",
                RelativePath = GetPath("images_screenshot_with_save_1024_768.png"),
                MimeType = "image/png",
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
            AudioWhatsTheWeatherPcm16 = new()
            {
                Type = AssetType.Audio,
                Language = "en",
                Description = "Fine tuning data for Open AI to generate a JSON object based on sports headlines",
                Name = "whats_the_weather_pcm16_24khz_mono.wav",
                RelativePath = GetPath("whats_the_weather_pcm16_24khz_mono.wav"),
                MimeType = "audio/wav"
            };
        }

        public virtual AssetInfo HelloWorld { get; }
        public virtual AssetInfo HelloWorldMp3 { get; }
        public virtual AssetInfo WhisperFrenchDescription { get; }
        public virtual AssetInfo DogAndCat { get; }
        public virtual AssetInfo ScreenshotWithSaveButton { get; }
        public virtual AssetInfo FineTuning { get; }
        public virtual AssetInfo AudioWhatsTheWeatherPcm16 { get; }

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
