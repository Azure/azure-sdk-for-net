// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Logging;

namespace Azure.GeneratorAgent.Services;

/// <summary>
/// Validates Azure SDK project paths and structure.
/// </summary>
public sealed class SdkValidator
{
    private readonly ILogger<SdkValidator> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="SdkValidator"/> class.
    /// </summary>
    /// <param name="logger">Logger instance.</param>
    public SdkValidator(ILogger<SdkValidator> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Validates SDK path and returns the absolute path.
    /// </summary>
    /// <param name="sdkPath">Path to validate.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Absolute path to the validated SDK directory.</returns>
    /// <exception cref="ArgumentException">Thrown when validation fails.</exception>
    public Task<string> ValidateAsync(string sdkPath, CancellationToken cancellationToken = default)
    {
        _logger.LogDebug("Validating SDK path: {SdkPath}", sdkPath);

        if (string.IsNullOrWhiteSpace(sdkPath))
        {
            throw new ArgumentException("SDK path cannot be empty", nameof(sdkPath));
        }

        var absolutePath = Path.GetFullPath(sdkPath);

        if (!Directory.Exists(absolutePath))
        {
            throw new DirectoryNotFoundException($"Directory not found: {absolutePath}");
        }

        var srcPath = Path.Combine(absolutePath, "src");
        if (!Directory.Exists(srcPath))
        {
            throw new DirectoryNotFoundException($"Required 'src' directory missing: {absolutePath}");
        }

        var csprojFiles = Directory.GetFiles(srcPath, "*.csproj", SearchOption.TopDirectoryOnly);
        if (csprojFiles.Length == 0)
        {
            throw new FileNotFoundException($"No .csproj files found in: {srcPath}");
        }

        _logger.LogInformation("SDK path validated successfully: {Path}", absolutePath);
        return Task.FromResult(absolutePath);
    }
}
