// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.CommandLine;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Azure.AI.VoiceLive.TestDataGenerator.Generators;
using Azure.AI.VoiceLive.TestDataGenerator.Models;

namespace Azure.AI.VoiceLive.TestDataGenerator
{
    /// <summary>
    /// Main program for generating test collateral for VoiceLive SDK tests.
    /// This tool generates audio files and other test data needed for integration testing.
    /// </summary>
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            // Set up command line options
            var rootCommand = new RootCommand("Azure VoiceLive Test Data Generator");

            var outputOption = new Option<string>(
                new[] { "--output", "-o" },
                getDefaultValue: () => Path.Combine(Directory.GetCurrentDirectory(), "TestAudio"),
                description: "Output directory for generated test files");

            var configOption = new Option<string>(
                new[] { "--config", "-c" },
                getDefaultValue: () => "appsettings.json",
                description: "Configuration file path");

            var categoryOption = new Option<TestDataCategory>(
                new[] { "--category", "-cat" },
                getDefaultValue: () => TestDataCategory.All,
                description: "Category of test data to generate");

            var verboseOption = new Option<bool>(
                new[] { "--verbose", "-v" },
                getDefaultValue: () => false,
                description: "Enable verbose logging");

            var dryRunOption = new Option<bool>(
                new[] { "--dry-run", "-d" },
                getDefaultValue: () => false,
                description: "Show what would be generated without creating files");

            rootCommand.AddOption(outputOption);
            rootCommand.AddOption(configOption);
            rootCommand.AddOption(categoryOption);
            rootCommand.AddOption(verboseOption);
            rootCommand.AddOption(dryRunOption);

            rootCommand.SetHandler(async (string output, string config, TestDataCategory category, bool verbose, bool dryRun) =>
            {
                await GenerateTestData(output, config, category, verbose, dryRun);
            }, outputOption, configOption, categoryOption, verboseOption, dryRunOption);

            return await rootCommand.InvokeAsync(args);
        }

        static async Task GenerateTestData(
            string outputPath,
            string configPath,
            TestDataCategory category,
            bool verbose,
            bool dryRun)
        {
            // Set up configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(configPath, optional: false)
                .AddEnvironmentVariables("VOICELIVE_TEST_")
                .AddUserSecrets<Program>(optional: true)
                .Build();

            // Set up logging
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddConsole()
                    .SetMinimumLevel(verbose ? LogLevel.Debug : LogLevel.Information);
            });

            var logger = loggerFactory.CreateLogger<Program>();

            logger.LogInformation("Azure VoiceLive Test Data Generator");
            logger.LogInformation($"Output directory: {outputPath}");
            logger.LogInformation($"Category: {category}");
            logger.LogInformation($"Dry run: {dryRun}");

            try
            {
                // Load test phrases
                var phrasesPath = Path.Combine(Directory.GetCurrentDirectory(), "test-phrases.json");
                var testPhrases = TestPhraseLoader.LoadPhrases(phrasesPath);

                // Create generators
                var speechConfig = configuration.GetSection("AzureSpeech").Get<AzureSpeechConfig>();
                if (speechConfig == null)
                {
                    throw new InvalidOperationException("Azure Speech configuration not found. Please check appsettings.json");
                }

                var generators = new ITestDataGenerator[]
                {
                    new SpeechAudioGenerator(speechConfig, logger),
                    new ToneGenerator(logger),
                    new NoiseGenerator(logger),
                    new FormatConverter(logger)
                };

                // Create output directory structure
                if (!dryRun)
                {
                    CreateDirectoryStructure(outputPath, logger);
                }

                // Generate data based on category
                foreach (var generator in generators)
                {
                    if (ShouldGenerateCategory(generator.Category, category))
                    {
                        logger.LogInformation($"Generating {generator.Category} test data...");

                        if (dryRun)
                        {
                            generator.PreviewGeneration(outputPath, testPhrases);
                        }
                        else
                        {
                            await generator.GenerateAsync(outputPath, testPhrases);
                        }
                    }
                }

                // Generate metadata file
                if (!dryRun)
                {
                    await GenerateMetadataFile(outputPath, testPhrases, logger);
                }

                logger.LogInformation("Test data generation completed successfully!");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error generating test data");
                throw;
            }
        }

        static void CreateDirectoryStructure(string basePath, ILogger logger)
        {
            var directories = new[]
            {
                "Basic",
                "Questions",
                "Commands",
                "WithIssues",
                "Formats",
                "Languages",
                "LongForm",
                "Tones",
                "Noise",
                "Mixed"
            };

            foreach (var dir in directories)
            {
                var path = Path.Combine(basePath, dir);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                    logger.LogDebug($"Created directory: {path}");
                }
            }
        }

        static bool ShouldGenerateCategory(TestDataCategory generatorCategory, TestDataCategory requestedCategory)
        {
            if (requestedCategory == TestDataCategory.All)
                return true;

            return (generatorCategory & requestedCategory) != 0;
        }

        static async Task GenerateMetadataFile(string outputPath, TestPhrases phrases, ILogger logger)
        {
            var metadata = new TestDataMetadata
            {
                GeneratedAt = DateTime.UtcNow,
                Version = "1.0.0",
                TotalFiles = Directory.GetFiles(outputPath, "*.*", SearchOption.AllDirectories).Length,
                Categories = Directory.GetDirectories(outputPath).Select(d => Path.GetFileName(d)).ToList(),
                PhraseCount = phrases.GetAllPhrases().Count()
            };

            var json = System.Text.Json.JsonSerializer.Serialize(metadata, new System.Text.Json.JsonSerializerOptions
            {
                WriteIndented = true
            });

            var metadataPath = Path.Combine(outputPath, "metadata.json");
            await File.WriteAllTextAsync(metadataPath, json);
            logger.LogInformation($"Generated metadata file: {metadataPath}");
        }
    }
}
