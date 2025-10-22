// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Developer.Playwright.Interface;

namespace Azure.Developer.Playwright.Implementation
{
    internal class EnvironmentHandler : IEnvironment
    {
        public void Exit(int exitCode)
        {
            Environment.Exit(exitCode);
        }

        public string? GetEnvironmentVariable(string variable)
        {
            return Environment.GetEnvironmentVariable(variable);
        }

        public void SetEnvironmentVariable(string variable, string? value)
        {
            Environment.SetEnvironmentVariable(variable, value);
        }
    }
}
