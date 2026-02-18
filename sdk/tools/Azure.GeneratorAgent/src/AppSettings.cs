// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Configuration;

namespace Azure.GeneratorAgent;

/// <summary>
/// Configuration settings for the application.
/// </summary>
public class AppSettings
{
    private readonly IConfiguration _configuration;

    /// <summary>
    /// Initializes a new instance of the <see cref="AppSettings"/> class.
    /// </summary>
    /// <param name="configuration">The configuration instance.</param>
    public AppSettings(IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);

        _configuration = configuration;
    }

    /// <summary>
    /// Gets the Copilot model to use.
    /// </summary>
    public string Model => _configuration["Copilot:Model"] ?? "claude-sonnet-4-20241022";

    /// <summary>
    /// Gets the log level for Copilot operations.
    /// </summary>
    public string LogLevel => _configuration["Copilot:LogLevel"] ?? "warning";

    /// <summary>
    /// Gets the default timeout for Copilot operations.
    /// </summary>
    public TimeSpan DefaultTimeout
    {
        get
        {
            var minutes = int.Parse(_configuration["Copilot:DefaultTimeoutMinutes"] ?? "2");
            return TimeSpan.FromMinutes(minutes);
        }
    }

    /// <summary>
    /// Gets the GitHub API base URL.
    /// </summary>
    public string GitHubApiUrl => _configuration["GitHub:ApiUrl"] ?? "https://api.github.com";
}