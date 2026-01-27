// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.IO;

namespace Azure.AI.Speech.Transcription.Tests
{
    /// <summary>
    /// Configuration provider for tests that reads from environment variables or .env file.
    /// </summary>
    public static class TestConfiguration
    {
        private static bool _initialized;

        /// <summary>
        /// Gets the endpoint URI for the Speech Transcription service.
        /// </summary>
        public static Uri Endpoint
        {
            get
            {
                EnsureInitialized();
                string endpoint = Environment.GetEnvironmentVariable("TRANSCRIPTION_ENDPOINT")
                    ?? throw new InvalidOperationException(
                        "TRANSCRIPTION_ENDPOINT environment variable is not set. " +
                        "Please set it in your environment or create a .env file in the tests folder.");
                return new Uri(endpoint);
            }
        }

        /// <summary>
        /// Gets the API key credential for authentication.
        /// </summary>
        public static ApiKeyCredential Credential
        {
            get
            {
                EnsureInitialized();
                string apiKey = Environment.GetEnvironmentVariable("TRANSCRIPTION_API_KEY")
                    ?? throw new InvalidOperationException(
                        "TRANSCRIPTION_API_KEY environment variable is not set. " +
                        "Please set it in your environment or create a .env file in the tests folder.");
                return new ApiKeyCredential(apiKey);
            }
        }

        /// <summary>
        /// Gets the path to the sample audio file for testing.
        /// </summary>
        public static string SampleAudioFilePath
        {
            get
            {
                EnsureInitialized();
                string path = Environment.GetEnvironmentVariable("TRANSCRIPTION_SAMPLE_AUDIO_PATH");
                if (string.IsNullOrEmpty(path))
                {
                    // Try multiple possible locations for the sample audio file
                    string[] possiblePaths = new[]
                    {
                        // Repo structure: artifacts/bin/Tests/Debug/net8.0 -> sdk/transcription/.../samples/assets
                        Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "..", "sdk", "transcription", "Azure.AI.Speech.Transcription", "samples", "assets", "sample-audio.wav")),
                        // Simple relative from project root
                        Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "..", "..", "sdk", "transcription", "Azure.AI.Speech.Transcription", "samples", "assets", "sample-audio.wav")),
                        // From current directory
                        Path.Combine(Directory.GetCurrentDirectory(), "samples", "assets", "sample-audio.wav"),
                    };

                    foreach (string possiblePath in possiblePaths)
                    {
                        if (File.Exists(possiblePath))
                        {
                            path = possiblePath;
                            break;
                        }
                    }

                    // Fallback to first path for error message
                    path ??= possiblePaths[0];
                }
                return path;
            }
        }

        /// <summary>
        /// Gets the path to the sample audio file with profanity for testing.
        /// </summary>
        public static string SampleProfanityAudioFilePath
        {
            get
            {
                EnsureInitialized();
                string path = Environment.GetEnvironmentVariable("TRANSCRIPTION_SAMPLE_PROFANITY_AUDIO_PATH");
                if (string.IsNullOrEmpty(path))
                {
                    // Try multiple possible locations for the sample profanity audio file
                    string[] possiblePaths = new[]
                    {
                        // Repo structure: artifacts/bin/Tests/Debug/net8.0 -> sdk/transcription/.../samples/assets
                        Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "..", "sdk", "transcription", "Azure.AI.Speech.Transcription", "samples", "assets", "sample-profanity.wav")),
                        // Simple relative from project root
                        Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "..", "..", "sdk", "transcription", "Azure.AI.Speech.Transcription", "samples", "assets", "sample-profanity.wav")),
                        // From current directory
                        Path.Combine(Directory.GetCurrentDirectory(), "samples", "assets", "sample-profanity.wav"),
                    };

                    foreach (string possiblePath in possiblePaths)
                    {
                        if (File.Exists(possiblePath))
                        {
                            path = possiblePath;
                            break;
                        }
                    }

                    // Fallback to first path for error message
                    path ??= possiblePaths[0];
                }
                return path;
            }
        }

        /// <summary>
        /// Gets the path to the English-only sample audio file for testing.
        /// </summary>
        public static string SampleEnglishAudioFilePath
        {
            get
            {
                EnsureInitialized();
                string path = Environment.GetEnvironmentVariable("TRANSCRIPTION_SAMPLE_ENGLISH_AUDIO_PATH");
                if (string.IsNullOrEmpty(path))
                {
                    // Try multiple possible locations for the English sample audio file
                    string[] possiblePaths = new[]
                    {
                        // Repo structure: artifacts/bin/Tests/Debug/net8.0 -> sdk/transcription/.../samples/assets
                        Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "..", "sdk", "transcription", "Azure.AI.Speech.Transcription", "samples", "assets", "sample-whatstheweatherlike-en.mp3")),
                        // Simple relative from project root
                        Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "..", "..", "sdk", "transcription", "Azure.AI.Speech.Transcription", "samples", "assets", "sample-whatstheweatherlike-en.mp3")),
                        // From current directory
                        Path.Combine(Directory.GetCurrentDirectory(), "samples", "assets", "sample-whatstheweatherlike-en.mp3"),
                    };

                    foreach (string possiblePath in possiblePaths)
                    {
                        if (File.Exists(possiblePath))
                        {
                            path = possiblePath;
                            break;
                        }
                    }

                    // Fallback to first path for error message
                    path ??= possiblePaths[0];
                }
                return path;
            }
        }

        /// <summary>
        /// Gets the path to the Chinese sample audio file for testing enhanced mode translation.
        /// </summary>
        public static string SampleChineseAudioFilePath
        {
            get
            {
                EnsureInitialized();
                string path = Environment.GetEnvironmentVariable("TRANSCRIPTION_SAMPLE_CHINESE_AUDIO_PATH");
                if (string.IsNullOrEmpty(path))
                {
                    // Try multiple possible locations for the Chinese sample audio file
                    string[] possiblePaths = new[]
                    {
                        // Repo structure: artifacts/bin/Tests/Debug/net8.0 -> sdk/transcription/.../samples/assets
                        Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "..", "sdk", "transcription", "Azure.AI.Speech.Transcription", "samples", "assets", "sample-howstheweather-cn.wav")),
                        // Simple relative from project root
                        Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "..", "..", "sdk", "transcription", "Azure.AI.Speech.Transcription", "samples", "assets", "sample-howstheweather-cn.wav")),
                        // From current directory
                        Path.Combine(Directory.GetCurrentDirectory(), "samples", "assets", "sample-howstheweather-cn.wav"),
                    };

                    foreach (string possiblePath in possiblePaths)
                    {
                        if (File.Exists(possiblePath))
                        {
                            path = possiblePath;
                            break;
                        }
                    }

                    // Fallback to first path for error message
                    path ??= possiblePaths[0];
                }
                return path;
            }
        }

        /// <summary>
        /// Gets the URL for a remote audio file for testing.
        /// Returns null if not configured.
        /// </summary>
        public static string SampleAudioUrl
        {
            get
            {
                EnsureInitialized();
                return Environment.GetEnvironmentVariable("TRANSCRIPTION_SAMPLE_AUDIO_URL");
            }
        }

        /// <summary>
        /// Gets whether the remote audio URL is configured.
        /// </summary>
        public static bool HasSampleAudioUrl => !string.IsNullOrEmpty(SampleAudioUrl);

        /// <summary>
        /// Ensures the configuration is initialized by loading the .env file if present.
        /// </summary>
        private static void EnsureInitialized()
        {
            if (_initialized)
                return;

            LoadEnvFile();
            _initialized = true;
        }

        /// <summary>
        /// Loads environment variables from a .env file in the tests folder.
        /// </summary>
        private static void LoadEnvFile()
        {
            // Try multiple locations for the .env file
            string[] possiblePaths = new[]
            {
                // Current directory
                Path.Combine(Directory.GetCurrentDirectory(), ".env"),
                // Base directory (output folder)
                Path.Combine(AppContext.BaseDirectory, ".env"),
                // Standard project structure: artifacts/bin/ProjectName/Debug/net8.0 -> tests folder
                Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "..", "sdk", "transcription", "Azure.AI.Speech.Transcription", "tests", ".env")),
                // Navigate from typical bin/Debug/net8.0 structure
                Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", ".env")),
            };

            string envFilePath = null;
            foreach (string path in possiblePaths)
            {
                if (File.Exists(path))
                {
                    envFilePath = path;
                    break;
                }
            }

            if (envFilePath == null)
            {
                // No .env file found, rely on environment variables
                return;
            }

            foreach (string line in File.ReadAllLines(envFilePath))
            {
                // Skip empty lines and comments
                string trimmedLine = line.Trim();
                if (string.IsNullOrEmpty(trimmedLine) || trimmedLine.StartsWith("#"))
                    continue;

                // Parse KEY=VALUE format
                int separatorIndex = trimmedLine.IndexOf('=');
                if (separatorIndex <= 0)
                    continue;

                string key = trimmedLine.Substring(0, separatorIndex).Trim();
                string value = trimmedLine.Substring(separatorIndex + 1).Trim();

                // Remove surrounding quotes if present
                if ((value.StartsWith("\"") && value.EndsWith("\"")) ||
                    (value.StartsWith("'") && value.EndsWith("'")))
                {
                    value = value.Substring(1, value.Length - 2);
                }

                // Only set if not already set (environment takes precedence)
                if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable(key)))
                {
                    Environment.SetEnvironmentVariable(key, value);
                }
            }
        }

        /// <summary>
        /// Creates a TranscriptionClient configured for testing.
        /// </summary>
        public static TranscriptionClient CreateClient()
        {
            return new TranscriptionClient(Endpoint, Credential);
        }

        /// <summary>
        /// Creates a TranscriptionClient configured for testing with custom options.
        /// </summary>
        public static TranscriptionClient CreateClient(TranscriptionClientOptions options)
        {
            return new TranscriptionClient(Endpoint, Credential, options);
        }
    }
}
