// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Configuration;

namespace Azure.GeneratorAgent;

/// <summary>
/// Configuration settings for the application.
/// </summary>
/// <param name="configuration">The configuration instance.</param>
public class AppSettings(IConfiguration configuration)
{
    private TimeSpan? _defaultTimeout;

    /// <summary>
    /// Gets the Copilot model to use.
    /// </summary>
    public string Model { get; } = configuration["Copilot:Model"] ?? "claude-4.6-opus";

    /// <summary>
    /// Gets the log level for Copilot operations.
    /// </summary>
    public string LogLevel { get; } = configuration["Copilot:LogLevel"] ?? "warning";

    /// <summary>
    /// Gets the default timeout for Copilot operations.
    /// </summary>
    public TimeSpan DefaultTimeout
    {
        get
        {
            _defaultTimeout ??= configuration["Copilot:DefaultTimeoutMinutes"] switch
            {
                string config when int.TryParse(config, out var minutes) => TimeSpan.FromMinutes(minutes),
                _ => TimeSpan.FromMinutes(2)
            };
            return _defaultTimeout.Value;
        }
    }

    /// <summary>
    /// Gets the GitHub API base URL.
    /// </summary>
    public string GitHubApiUrl { get; } = configuration["GitHub:ApiUrl"] ?? "https://api.github.com";
}
