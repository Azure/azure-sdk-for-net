// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Configuration;

namespace Azure.AI.ContentUnderstanding.Samples
{
    /// <summary>
    /// Helper class for Azure AI Content Understanding samples.
    /// Provides configuration loading and utility functions.
    /// </summary>
    public static class SampleHelper
    {
        /// <summary>
        /// Configuration class for Content Understanding samples.
        /// </summary>
        public class SampleConfiguration
        {
            public string? Endpoint { get; set; }
            public string? Key { get; set; }
        }

        /// <summary>
        /// Loads configuration from appsettings.json and environment variables using the standard .NET configuration system.
        /// Configuration is loaded in the following order (later sources override earlier ones):
        /// 1. appsettings.json in the samples/ parent directory (shared across all samples)
        /// 2. appsettings.json in the current sample directory (sample-specific overrides)
        /// 3. Environment variables (highest priority)
        /// </summary>
        /// <returns>Configuration object with Endpoint and Key</returns>
        public static SampleConfiguration LoadConfiguration()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var samplesDirectory = Directory.GetParent(currentDirectory)?.FullName;

            // Build configuration using the standard .NET configuration system
            var configBuilder = new ConfigurationBuilder();

            // Add shared appsettings.json from samples/ directory (if it exists)
            if (!string.IsNullOrEmpty(samplesDirectory))
            {
                var sharedConfigPath = Path.Combine(samplesDirectory, "appsettings.json");
                configBuilder.AddJsonFile(sharedConfigPath, optional: true, reloadOnChange: false);
            }

            // Add sample-specific appsettings.json (overrides shared settings)
            configBuilder
                .SetBasePath(currentDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);

            // Add environment variables (highest priority)
            configBuilder.AddEnvironmentVariables();

            IConfiguration configuration = configBuilder.Build();

            var config = new SampleConfiguration();

            // Try to get from configuration section first (appsettings.json format)
            var cuSection = configuration.GetSection("AzureContentUnderstanding");
            config.Endpoint = cuSection["Endpoint"];
            config.Key = cuSection["Key"];

            // Environment variables override (using the standard naming convention)
            // The AddEnvironmentVariables() above automatically reads these with higher priority
            string? envEndpoint = configuration["AZURE_CONTENT_UNDERSTANDING_ENDPOINT"];
            if (!string.IsNullOrEmpty(envEndpoint))
            {
                config.Endpoint = envEndpoint;
            }

            string? envKey = configuration["AZURE_CONTENT_UNDERSTANDING_KEY"];
            if (!string.IsNullOrEmpty(envKey))
            {
                config.Key = envKey;
            }

            return config;
        }

        /// <summary>
        /// Saves an object as JSON to a file with timestamp.
        /// </summary>
        /// <param name="data">The object to save</param>
        /// <param name="filenamePrefix">Prefix for the output filename</param>
        /// <param name="outputDir">Output directory (default: "output")</param>
        /// <returns>Path to the saved file</returns>
        public static string SaveJsonToFile(object data, string filenamePrefix = "result", string outputDir = "output")
        {
            Directory.CreateDirectory(outputDir);

            string timestamp = DateTime.UtcNow.ToString("yyyyMMdd_HHmmss");
            string filename = $"{filenamePrefix}_{timestamp}.json";
            string filePath = Path.Combine(outputDir, filename);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            string jsonString = JsonSerializer.Serialize(data, options);
            File.WriteAllText(filePath, jsonString);

            Console.WriteLine($"💾 Result saved to: {filePath}");
            return filePath;
        }
    }
}


