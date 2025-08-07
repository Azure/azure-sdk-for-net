// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using Azure.AI.OpenAI.Tests.Utils.Config;
using OpenAI.TestFramework;
using OpenAI.TestFramework.Utils;

namespace Azure.AI.OpenAI.Tests;

internal class TestConfig
{
    private const string AZURE_OPENAI_ENV_KEY_PREFIX = "AZURE_OPENAI";

    private readonly Func<RecordedTestMode> _getRecordedMode;
    private SortedDictionary<string, SanitizedJsonConfig> _recordedConfig;
    private readonly IReadOnlyDictionary<string, JsonConfig> _liveConfig;
    private readonly IReadOnlyDictionary<string, JsonConfig> _playbackConfig;

    public virtual string AssetsSubFolder => "Assets";
    public virtual string AssetsJson => "test_config.json";
    public virtual string PlaybackAssetsJson => $"playback_{AssetsJson}";

    protected bool IsPlayback => _getRecordedMode() == RecordedTestMode.Playback;

    // When in playback mode, we always use the playback configuration. This ensures that we run in the same way in CI/CD
    // as we do locally.
    protected IReadOnlyDictionary<string, JsonConfig> CurrentConfig => IsPlayback ? _playbackConfig : _liveConfig;

    public TestConfig(Func<RecordedTestMode> getRecordedMode)
    {
        _getRecordedMode = getRecordedMode ?? throw new ArgumentNullException(nameof(getRecordedMode));
        _recordedConfig = new(new DefaultFirstStringComparer());

        // Load the previous playback configuration and use that to initialize the recorded config
        string playbackConfigJson = Path.Combine(AssetsSubFolder, PlaybackAssetsJson);
        _playbackConfig = ReadJsonConfig(playbackConfigJson)!;
        if (_playbackConfig == null)
        {
            throw new InvalidOperationException($"The playback config file was not found: {playbackConfigJson}");
        }

        foreach (var kvp in _playbackConfig)
        {
            _recordedConfig.Add(kvp.Key, new SanitizedJsonConfig(kvp.Value));
        }

        // Try to load the configuration to use against the real service (e.g. recording or live mode)
        _liveConfig = new[]
            {
                AssetsJson,
                Path.Combine(AssetsSubFolder, AssetsJson),
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".azure", AssetsSubFolder, AssetsJson),
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".azure", AssetsSubFolder, AssetsJson),
            }
            .Select(f => ReadJsonConfig(f))
            .FirstOrDefault(c => c != null)
            ?? new Dictionary<string, JsonConfig>();
    }

    public virtual IConfiguration? GetConfig<TClient>()
        => GetConfig(ToKey<TClient>());

    public virtual IConfiguration? GetConfig(string name)
    {
        // In order to populate each property of the Config object, the search order is as follows:
        // 1. Getting the specific config for the name in the JSON config file
        // 2. Getting the value from the default config
        // 3. (Not in playback) Getting the value from the AZURE_OPENAI_<NAME>_<PROPERTY_NAME> environment variable
        // 4. (Not in playback) Getting the value from the AZURE_OPENAI_<PROPERTY_NAME> environment variable
        // It will fall through each one if the value is null

        return new FlattenedConfig(
            [
                new NamedConfig(CurrentConfig.GetValueOrDefault(name), name),
                new NamedConfig(CurrentConfig.GetValueOrDefault(JsonConfig.DEFAULT_CONFIG_NAME), null),
                IsPlayback ? null : new EnvironmentValuesConfig(AZURE_OPENAI_ENV_KEY_PREFIX, name),
                IsPlayback ? null : new EnvironmentValuesConfig(AZURE_OPENAI_ENV_KEY_PREFIX)
            ], _recordedConfig);
    }

    public virtual void SavePlaybackConfig()
    {
        try
        {
            string? sourceDirectoryPath = typeof(TestConfig).Assembly
                .GetCustomAttributes<AssemblyMetadataAttribute>()
                .FirstOrDefault(attrib => attrib.Key == "TestProjectSourceBasePath")
                ?.Value;

            if (sourceDirectoryPath != null)
            {
                string playbackConfigJson = Path.Combine(sourceDirectoryPath, AssetsSubFolder, PlaybackAssetsJson);

                string oldJson = string.Empty;
                if (File.Exists(playbackConfigJson))
                {
                    oldJson = File.ReadAllText(playbackConfigJson);
                }

                string newJson = JsonSerializer.Serialize(_recordedConfig, JsonConfig.JSON_OPTIONS);

                // Visual Studio's hot reload feature can get upset if you are debugging the code and the playback config
                // file changes, so we only save it if it is different
                if (oldJson != newJson)
                {
                    File.WriteAllText(playbackConfigJson, newJson, Encoding.UTF8);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Failed to save the playback configuration file. Details: " + ex);
        }
    }

    protected static string ToKey<TClient>()
    {
        string fullName = typeof(TClient).Name;
        fullName = Regex.Replace(fullName, "^(OpenAI)?(.*?)(Client)?$", "$2");

        StringBuilder builder = new(fullName.Length);
        bool prevWasUpper = true;

        foreach (char c in fullName)
        {
            if (char.IsUpper(c))
            {
                if (prevWasUpper)
                {
                    builder.Append(char.ToLowerInvariant(c));
                }
                else
                {
                    builder.Append('_');
                    builder.Append(char.ToLowerInvariant(c));
                }

                prevWasUpper = true;
            }
            else
            {
                builder.Append(c);
                prevWasUpper = false;
            }
        }

        return builder.ToString();
    }

    protected static IReadOnlyDictionary<string, JsonConfig>? ReadJsonConfig(string fullPath)
    {
        try
        {
            if (File.Exists(fullPath))
            {
                string json = File.ReadAllText(fullPath);
                return JsonSerializer.Deserialize<Dictionary<string, JsonConfig>>(json, JsonConfig.JSON_OPTIONS);
            }
        }
        catch (Exception)
        {
        }

        return null;
    }

    private class DefaultFirstStringComparer : IComparer<string>
    {
        public int Compare(string? x, string? y)
        {
            if (ReferenceEquals(x, y))
            {
                return 0;
            }
            else if (x == null)
            {
                return -1;
            }
            else if (y == null)
            {
                return 1;
            }
            else if (x == JsonConfig.DEFAULT_CONFIG_NAME && y != JsonConfig.DEFAULT_CONFIG_NAME)
            {
                return -1;
            }
            else if (x != JsonConfig.DEFAULT_CONFIG_NAME && y == JsonConfig.DEFAULT_CONFIG_NAME)
            {
                return 1;
            }

            return string.Compare(x, y, StringComparison.Ordinal);
        }
    }
}
