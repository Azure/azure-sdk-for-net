// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.IO;
using Azure.Identity;
using OpenAI.Images;

namespace Azure.AI.OpenAI.Samples;

public partial class AzureOpenAISamples
{
    public void BasicImageGeneration()
    {
        #region Snippet:BasicImageGeneration
        AzureOpenAIClient azureClient = new(
            new Uri("https://your-azure-openai-resource.com"),
            new DefaultAzureCredential());
        ImageClient imageClient = azureClient.GetImageClient("my-dalle-deployment");

        // Generate a single image from a text prompt
        string prompt = "A serene mountain landscape at sunset with a crystal-clear lake reflecting the sky";
        
        GeneratedImage image = imageClient.GenerateImage(prompt);
        
        Console.WriteLine($"Generated image URL: {image.ImageUri}");
        Console.WriteLine($"Revised prompt: {image.RevisedPrompt}");
        #endregion
    }

    public void ImageGenerationWithOptions()
    {
        AzureOpenAIClient azureClient = new(
            new Uri("https://your-azure-openai-resource.com"),
            new DefaultAzureCredential());
        ImageClient imageClient = azureClient.GetImageClient("my-dalle-deployment");

        #region Snippet:ImageGenerationWithOptions
        string prompt = "A futuristic cityscape with flying cars and neon lights, cyberpunk style, high detail";

        // Configure image generation with specific options
        ImageGenerationOptions options = new()
        {
            Quality = GeneratedImageQuality.Standard,
            Size = GeneratedImageSize.W1024xH1024,
            Style = GeneratedImageStyle.Vivid,
            ResponseFormat = GeneratedImageFormat.Uri,
        };

        GeneratedImage image = imageClient.GenerateImage(prompt, options);
        
        Console.WriteLine($"High-quality image generated: {image.ImageUri}");
        Console.WriteLine($"Revised prompt: {image.RevisedPrompt}");
        Console.WriteLine($"Size: {options.Size}");
        Console.WriteLine($"Quality: {options.Quality}");
        #endregion
    }

    public void MultipleImageGeneration()
    {
        AzureOpenAIClient azureClient = new(
            new Uri("https://your-azure-openai-resource.com"),
            new DefaultAzureCredential());
        ImageClient imageClient = azureClient.GetImageClient("my-dalle-deployment");

        #region Snippet:MultipleImageGeneration
        string prompt = "A cozy coffee shop interior with warm lighting, wooden furniture, and plants";

        // Generate multiple variations of the same concept
        ImageGenerationOptions options = new()
        {
            Size = GeneratedImageSize.W1024xH1024,
            Quality = GeneratedImageQuality.Standard,
        };

        GeneratedImage image1 = imageClient.GenerateImage(prompt, options);
        GeneratedImage image2 = imageClient.GenerateImage(prompt, options);
        GeneratedImage image3 = imageClient.GenerateImage(prompt, options);
        
        Console.WriteLine($"Generated 3 image variations:");
        Console.WriteLine($"Image 1: {image1.ImageUri}");
        Console.WriteLine($"Image 2: {image2.ImageUri}");
        Console.WriteLine($"Image 3: {image3.ImageUri}");
        
        // All images use the same base prompt
        Console.WriteLine($"Base prompt used: {prompt}");
        #endregion
    }

    public void ImageGenerationWithBase64()
    {
        AzureOpenAIClient azureClient = new(
            new Uri("https://your-azure-openai-resource.com"),
            new DefaultAzureCredential());
        ImageClient imageClient = azureClient.GetImageClient("my-dalle-deployment");

        #region Snippet:ImageGenerationWithBase64
        string prompt = "A professional headshot photo of a business person in a modern office setting";

        // Generate image as base64 data instead of URL
        ImageGenerationOptions options = new()
        {
            Size = GeneratedImageSize.W1024xH1024,
            Quality = GeneratedImageQuality.Standard,
            ResponseFormat = GeneratedImageFormat.Bytes, // Return as bytes
        };

        GeneratedImage image = imageClient.GenerateImage(prompt, options);
        
        // Save bytes directly to file
        byte[] imageBytes = image.ImageBytes.ToArray();
        string filename = $"generated_headshot_{DateTime.Now:yyyyMMdd_HHmmss}.png";
        File.WriteAllBytes(filename, imageBytes);
        
        Console.WriteLine($"Image saved locally as: {filename}");
        Console.WriteLine($"Image size: {imageBytes.Length} bytes");
        #endregion
    }

    public void CreativeImageWorkflow()
    {
        AzureOpenAIClient azureClient = new(
            new Uri("https://your-azure-openai-resource.com"),
            new DefaultAzureCredential());
        ImageClient imageClient = azureClient.GetImageClient("my-dalle-deployment");

        #region Snippet:CreativeImageWorkflow
        // Creative workflow: Generate marketing materials for a fictional product
        string[] prompts = {
            "A sleek smartphone on a minimalist white background, product photography style",
            "The same smartphone being used by a young professional in a modern office",
            "A dramatic artistic shot of the smartphone with colorful lighting effects"
        };

        string[] contexts = { "product", "lifestyle", "artistic" };

        Console.WriteLine("Generating marketing image set...");
        
        for (int i = 0; i < prompts.Length; i++)
        {
            ImageGenerationOptions options = new()
            {
                Size = GeneratedImageSize.W1024xH1024,
                Quality = GeneratedImageQuality.Standard,
                Style = i == 2 ? GeneratedImageStyle.Vivid : GeneratedImageStyle.Natural,
                ResponseFormat = GeneratedImageFormat.Bytes,
            };

            GeneratedImage image = imageClient.GenerateImage(prompts[i], options);
            
            // Save each image with descriptive naming
            byte[] imageBytes = image.ImageBytes.ToArray();
            string filename = $"marketing_{contexts[i]}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
            File.WriteAllBytes(filename, imageBytes);
            
            Console.WriteLine($"Generated {contexts[i]} image: {filename}");
            Console.WriteLine($"  Revised prompt: {image.RevisedPrompt}");
            Console.WriteLine();
        }
        
        Console.WriteLine("Marketing image set complete! Use these images for:");
        Console.WriteLine("- Product catalog (product image)");
        Console.WriteLine("- Website hero section (lifestyle image)");
        Console.WriteLine("- Social media campaigns (artistic image)");
        #endregion
    }

    public void ImageGenerationBestPractices()
    {
        AzureOpenAIClient azureClient = new(
            new Uri("https://your-azure-openai-resource.com"),
            new DefaultAzureCredential());
        ImageClient imageClient = azureClient.GetImageClient("my-dalle-deployment");

        #region Snippet:ImageGenerationBestPractices
        // Best practices for prompt engineering and image generation
        
        // 1. Detailed and specific prompts yield better results
        string detailedPrompt = "A macro photograph of a dewdrop on a green leaf, " +
                               "shot with shallow depth of field, golden hour lighting, " +
                               "nature photography, high resolution, crisp details";

        // 2. Use appropriate quality settings for your use case
        ImageGenerationOptions qualityOptions = new()
        {
            Quality = GeneratedImageQuality.Standard, // Use Standard for most applications
            Size = GeneratedImageSize.W1024xH1024, // Standard size for most applications
            Style = GeneratedImageStyle.Natural, // Natural for realistic images
        };

        GeneratedImage professionalImage = imageClient.GenerateImage(detailedPrompt, qualityOptions);
        
        // 3. For social media or web use, standard quality may suffice
        string socialPrompt = "A cheerful illustration of people enjoying coffee together, cartoon style";
        
        ImageGenerationOptions webOptions = new()
        {
            Quality = GeneratedImageQuality.Standard, // Standard quality for web
            Size = GeneratedImageSize.W1024xH1024,
            Style = GeneratedImageStyle.Vivid, // Vivid for eye-catching social content
        };

        GeneratedImage socialImage = imageClient.GenerateImage(socialPrompt, webOptions);
        
        Console.WriteLine("Professional image (HD quality):");
        Console.WriteLine($"  URL: {professionalImage.ImageUri}");
        Console.WriteLine($"  Revised: {professionalImage.RevisedPrompt}");
        
        Console.WriteLine("\nSocial media image (Standard quality):");
        Console.WriteLine($"  URL: {socialImage.ImageUri}");
        Console.WriteLine($"  Revised: {socialImage.RevisedPrompt}");
        
        Console.WriteLine("\nTips for better image generation:");
        Console.WriteLine("- Be specific about style, lighting, and composition");
        Console.WriteLine("- Include art/photography terminology for desired aesthetic");
        Console.WriteLine("- Use HD quality for professional/print applications");
        Console.WriteLine("- Choose Vivid style for colorful, eye-catching images");
        Console.WriteLine("- Choose Natural style for realistic, photographic images");
        #endregion
    }
}