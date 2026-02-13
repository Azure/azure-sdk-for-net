// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace Azure.GeneratorAgent;

/// <summary>
/// Validates Azure SDK project paths, structure, and user inputs.
/// </summary>
public sealed class ValidationService
{
    private readonly ILogger<ValidationService> _logger;

    // Pre-compiled regex for path validation (performance optimization)
    private static readonly Regex InvalidPathCharsRegex = new(
        @"[<>:""|?*]",
        RegexOptions.Compiled | RegexOptions.CultureInvariant,
        TimeSpan.FromMilliseconds(100));

    // Common dangerous path patterns (faster than regex for simple checks)
    private static readonly string[] DangerousPathPatterns = { "..", "~" };

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationService"/> class.
    /// </summary>
    /// <param name="logger">Logger instance.</param>
    public ValidationService(ILogger<ValidationService> logger)
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

    /// <summary>
    /// Validates that tsp-location.yaml exists in the SDK directory.
    /// </summary>
    /// <param name="tspLocationPath">Path to the tsp-location.yaml file.</param>
    /// <exception cref="FileNotFoundException">Thrown when tsp-location.yaml is not found.</exception>
    public void ValidateTspLocationFile(string tspLocationPath)
    {
        if (!File.Exists(tspLocationPath))
        {
            _logger.LogError("tsp-location.yaml not found at path: {FilePath}", tspLocationPath);
            throw new FileNotFoundException($"tsp-location.yaml not found at path: {tspLocationPath}");
        }

        _logger.LogDebug("tsp-location.yaml found at: {FilePath}", tspLocationPath);
    }

    /// <summary>
    /// Validates repository path parameter.
    /// </summary>
    /// <param name="path">Repository path.</param>
    /// <exception cref="ArgumentException">Thrown when path is invalid.</exception>
    public void ValidateRepositoryPath(string? path)
    {
        if (string.IsNullOrEmpty(path))
        {
            return;
        }

        foreach (var dangerousPattern in DangerousPathPatterns)
        {
            if (path.Contains(dangerousPattern, StringComparison.Ordinal))
            {
                throw new ArgumentException($"Path traversal pattern '{dangerousPattern}' detected in repository path", nameof(path));
            }
        }

        if (Path.IsPathRooted(path))
        {
            throw new ArgumentException("Absolute paths are not allowed", nameof(path));
        }

        if (path.Length > 500)
        {
            throw new ArgumentException("Repository path exceeds maximum length", nameof(path));
        }

        if (InvalidPathCharsRegex.IsMatch(path))
        {
            throw new ArgumentException("Repository path contains invalid characters", nameof(path));
        }

        _logger.LogDebug("Repository path validated: {Path}", path);
    }
}
