// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Developer.Playwright.Interface;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace Azure.Developer.Playwright.Tests;

internal class TestEnvironment : IEnvironment
{
    private readonly Dictionary<string, string?> _environmentVariables = [];

    public string? GetEnvironmentVariable(string variable)
    {
        if (_environmentVariables.TryGetValue(variable, out var value))
        {
            return value;
        }
        return null;
    }

    public void SetEnvironmentVariable(string variable, string? value)
    {
        _environmentVariables[variable] = value;
    }

    public void Exit(int exitCode)
    {
        // no-op
    }
}
internal class TestUtilities
{
    internal static string GetToken(Dictionary<string, object> claims, DateTime? expires = null)
    {
        var tokenHandler = new JsonWebTokenHandler();
        var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
        {
            Claims = claims,
            Expires = expires ?? DateTime.UtcNow.AddMinutes(10),
        });
        return token!;
    }
}

internal class PlaywrightVersion : IPlaywrightVersion
{
    public void ValidatePlaywrightVersion()
    {
        var minimumSupportedVersion = "1.50.0";
        var installedVersion = GetPlaywrightVersion();

        var minimumSupportedVersionInfo = GetVersionInfo(minimumSupportedVersion);
        var installedVersionInfo = GetVersionInfo(installedVersion);

        var isInstalledVersionGreater =
            installedVersionInfo.Major > minimumSupportedVersionInfo.Major ||
            (installedVersionInfo.Major == minimumSupportedVersionInfo.Major &&
             installedVersionInfo.Minor >= minimumSupportedVersionInfo.Minor);

        if (!isInstalledVersionGreater)
        {
            throw new Exception("The Playwright version you are using does not support playwright workspaces. Please update to Playwright version 1.50.0 or higher.");
        }
    }

    public string GetPlaywrightVersion()
    {
        return "1.52.0";
    }

    internal (int Major, int Minor) GetVersionInfo(string version)
    {
        var parts = version.Split('.');
        if (parts.Length < 2 ||
            !int.TryParse(parts[0], out var major) ||
            !int.TryParse(parts[1], out var minor))
        {
            throw new ArgumentException("Invalid version format.");
        }
        return (major, minor);
    }
}
