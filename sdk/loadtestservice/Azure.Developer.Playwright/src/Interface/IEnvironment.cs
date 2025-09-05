// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Developer.Playwright.Interface
{
    internal interface IEnvironment
    {
        void Exit(int exitCode);
        string? GetEnvironmentVariable(string variable);
        void SetEnvironmentVariable(string variable, string? value);
    }
}
