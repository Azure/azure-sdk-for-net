// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using Azure.AI.OpenAI.Tests.Utils;
using Azure.AI.OpenAI.Tests.Utils.Config;
using Azure.Core.TestFramework;

namespace Azure.AI.OpenAI.Tests;

internal class TestConfig
{
    private const string AZURE_OPENAI_ENV_KEY_PREFIX = "AZURE_OPENAI";
    private const string DEFAULT_CONFIG_NAME = "default";

    private readonly bool _isPlayback;
    private readonly IConfiguration _defaultEnvConfig;
    private readonly IReadOnlyDictionary<string, JsonConfig> _jsonConfig;
    private readonly IReadOnlyDictionary<string, JsonConfig>? _playbackConfig;

    public virtual string AssetsSubFolder => "Assets";
    public virtual string AssetsJson => "test_config.json";

    public TestConfig(RecordedTestMode? mode)
    {
        _jsonConfig = new[]
            {
                AssetsJson,
                Path.Combine(AssetsSubFolder, AssetsJson),
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".Azure", AssetsSubFolder, AssetsJson),
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".Azure", AssetsSubFolder, AssetsJson),
            }
            .Select(f => ReadJsonConfig(f))
            .FirstOrDefault(c => c != null)
            ?? new Dictionary<string, JsonConfig>();

        _defaultEnvConfig = new EnvironmentValuesConfig(AZURE_OPENAI_ENV_KEY_PREFIX);

        _isPlayback = mode == RecordedTestMode.Playback;
        if (_isPlayback)
        {
            string playbackConfigJson = Path.Combine(AssetsSubFolder, "playback_" + AssetsJson);
            _playbackConfig = ReadJsonConfig(playbackConfigJson);
            if (_playbackConfig == null)
            {
                throw new InvalidOperationException($"The playback config file was not found: {playbackConfigJson}");
            }
        }
    }

    public virtual IConfiguration? GetConfig<TClient>()
        => GetConfig(ToKey<TClient>());

    public virtual IConfiguration? GetConfig(string name)
    {
        // In order to populate each property of the Config object, the search order is as follows:
        // 1. Getting the specific config for the name in the JSON config file
        // 2. Getting the value from the default config
        // 3. Getting the value from the AZURE_OPENAI_<NAME>_<PROEPRTYNAME> environment variable
        // 4. Getting the value from the AZURE_OPENAI_<PROEPRTYNAME> environment variable
        // 5. (Only in playback mode) Getting the specific config for the name in the playback JSON config file
        // It will fall through each one if the value is null

        return new FlattenedConfig(
            _jsonConfig.GetValueOrDefault(name),
            _jsonConfig.GetValueOrDefault(DEFAULT_CONFIG_NAME),
            new EnvironmentValuesConfig(AZURE_OPENAI_ENV_KEY_PREFIX, name),
            _defaultEnvConfig,
            _isPlayback ? _playbackConfig?.GetValueOrDefault(name) : null,
            _isPlayback ? _playbackConfig?.GetValueOrDefault(DEFAULT_CONFIG_NAME) : null);
    }

    protected static string ToKey<TClient>()
    {
        string fullName = typeof(TClient).Name;
        int stopAt = fullName.LastIndexOf("Client");
        stopAt = stopAt == -1 ? fullName.Length : stopAt;

        StringBuilder builder = new(fullName.Length);
        bool prevWasUpper = true;

        for (int i = 0; i < stopAt; i++)
        {
            char c = fullName[i];
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
                return JsonSerializer.Deserialize<Dictionary<string, JsonConfig>>(json, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                    PropertyNamingPolicy = JsonHelpers.SnakeCaseLower,
                    DictionaryKeyPolicy = JsonHelpers.SnakeCaseLower
                });
            }
        }
        catch (Exception)
        {
        }

        return null;
    }
}
