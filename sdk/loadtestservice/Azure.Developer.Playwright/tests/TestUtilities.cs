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
