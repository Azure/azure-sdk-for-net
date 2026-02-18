// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;

namespace Azure.GeneratorAgent;

/// <summary>
/// Validates Azure SDK project paths, structure, and user inputs.
/// </summary>
public sealed class ValidationService
{
    private readonly ILogger<ValidationService> _logger;

    // Pre-compiled regex for path validation
    private static readonly Regex InvalidPathCharsRegex = new(
        @"[<>:""|?*]",
        RegexOptions.Compiled | RegexOptions.CultureInvariant,
        TimeSpan.FromMilliseconds(100));

    // Common dangerous path patterns
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
    /// <exception cref="DirectoryNotFoundException">Thrown when directory is not found.</exception>
    /// <exception cref="FileNotFoundException">Thrown when required files are missing.</exception>
    public Task<string> ValidateAsync(string sdkPath, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(sdkPath))
        {
            var message = "SDK path cannot be empty";
            _logger.LogError(message);
            throw new ArgumentException(message, nameof(sdkPath));
        }

        _logger.LogDebug("Validating SDK path: {SdkPath}", sdkPath);

        try
        {
            var absolutePath = Path.GetFullPath(sdkPath);
            _logger.LogDebug("Resolved absolute path: {AbsolutePath}", absolutePath);

            var srcPath = Path.Combine(absolutePath, "src");
            if (!Directory.Exists(srcPath))
            {
                var message = $"Required 'src' directory not found in SDK path: {absolutePath}";
                _logger.LogError(message);
                throw new DirectoryNotFoundException(message);
            }

            var csprojFiles = Directory.GetFiles(srcPath, "*.csproj", SearchOption.TopDirectoryOnly);
            if (csprojFiles.Length == 0)
            {
                var message = $"No .csproj files found in src directory: {srcPath}";
                _logger.LogError(message);
                throw new FileNotFoundException(message);
            }

            _logger.LogInformation("SDK path validation successful: {Path} (found {ProjectCount} .csproj files)",
                absolutePath, csprojFiles.Length);
            return Task.FromResult(absolutePath);
        }
        catch (Exception ex) when (ex is not ArgumentException and not DirectoryNotFoundException and not FileNotFoundException)
        {
            var message = $"Unexpected error during SDK path validation: {ex.Message}";
            _logger.LogError(ex, message);
            throw new InvalidOperationException(message, ex);
        }
    }

    /// <summary>
    /// Validates that tsp-location.yaml exists in the SDK directory.
    /// </summary>
    /// <param name="tspLocationPath">Path to the tsp-location.yaml file.</param>
    /// <exception cref="ArgumentException">Thrown when path is null or empty.</exception>
    /// <exception cref="FileNotFoundException">Thrown when tsp-location.yaml is not found.</exception>
    public void ValidateTspLocationFile(string tspLocationPath)
    {
        if (string.IsNullOrEmpty(tspLocationPath))
        {
            var message = "tsp-location.yaml path cannot be empty";
            _logger.LogError(message);
            throw new ArgumentException(message, nameof(tspLocationPath));
        }

        _logger.LogDebug("Validating tsp-location.yaml file: {FilePath}", tspLocationPath);

        if (!File.Exists(tspLocationPath))
        {
            var message = $"tsp-location.yaml not found at path: {tspLocationPath}";
            _logger.LogError(message);
            throw new FileNotFoundException(message);
        }

        _logger.LogDebug("tsp-location.yaml validation successful: {FilePath}", tspLocationPath);
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
            throw new ArgumentException("Repository path cannot be null or empty");
        }

        _logger.LogDebug("Validating repository path: {Path}", path);

        try
        {
            foreach (var dangerousPattern in DangerousPathPatterns)
            {
                if (path.Contains(dangerousPattern, StringComparison.Ordinal))
                {
                    var message = $"Path traversal pattern '{dangerousPattern}' detected in repository path: {path}";
                    _logger.LogError(message);
                    throw new ArgumentException(message, nameof(path));
                }
            }

            if (Path.IsPathRooted(path))
            {
                var message = $"Absolute paths are not allowed for repository paths: {path}";
                _logger.LogError(message);
                throw new ArgumentException(message, nameof(path));
            }

            if (path.Length > 500)
            {
                var message = $"Repository path exceeds maximum length of 500 characters: {path.Length}";
                _logger.LogError(message);
                throw new ArgumentException(message, nameof(path));
            }

            _logger.LogDebug("Repository path validation successful: {Path}", path);
        }
        catch (RegexMatchTimeoutException ex)
        {
            var message = $"Timeout occurred while validating repository path: {path}";
            _logger.LogError(ex, message);
            throw new ArgumentException(message, nameof(path), ex);
        }
    }
}
