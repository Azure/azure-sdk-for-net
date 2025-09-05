// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// A disposable utility class for temporarily modifying environment variables during testing.
/// This class ensures that environment variables are safely modified for the duration of a test
/// and automatically restored to their original values when disposed.
/// </summary>
public class TestEnvVar : DisposableConfig
{
    /// <summary>
    /// Static semaphore used to ensure that only one <see cref="TestEnvVar"/> instance
    /// can modify environment variables at a time, preventing race conditions in tests.
    /// </summary>
    private static SemaphoreSlim _lock = new(1, 1);

    /// <summary>
    /// Initializes a new instance of the <see cref="TestEnvVar"/> class to modify a single environment variable.
    /// </summary>
    /// <param name="name">The name of the environment variable to modify.</param>
    /// <param name="value">The value to set for the environment variable.</param>
    public TestEnvVar(string name, string value) : base(name, value, _lock) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="TestEnvVar"/> class to modify multiple environment variables.
    /// </summary>
    /// <param name="values">A dictionary containing the environment variable names and their values.</param>
    public TestEnvVar(Dictionary<string, string> values) : base(values, _lock) { }

    /// <summary>
    /// Sets a single environment variable value and stores its original value for later restoration.
    /// Clears any existing environment variables that were previously set by this instance.
    /// </summary>
    /// <param name="name">The name of the environment variable to set.</param>
    /// <param name="value">The value to assign to the environment variable.</param>
    internal override void SetValue(string name, string value)
    {
        OriginalValues[name] = Environment.GetEnvironmentVariable(name) ?? string.Empty;

        CleanExistingEnvironmentVariables();

        Environment.SetEnvironmentVariable(name, value as string);
    }

    /// <summary>
    /// Sets multiple environment variable values and stores their original values for later restoration.
    /// Clears any existing environment variables that were previously set by this instance.
    /// </summary>
    /// <param name="values">A dictionary containing the environment variable names and their values.</param>
    internal override void SetValues(Dictionary<string, string> values)
    {
        foreach (var kvp in values)
        {
            OriginalValues[kvp.Key] = Environment.GetEnvironmentVariable(kvp.Key) ?? string.Empty;
        }

        CleanExistingEnvironmentVariables();

        foreach (var kvp in values)
        {
            Environment.SetEnvironmentVariable(kvp.Key, kvp.Value as string);
        }
    }

    /// <summary>
    /// Initializes any additional state required by this class.
    /// Currently, this implementation doesn't require any initialization.
    /// </summary>
    internal override void InitValues()
    { }

    /// <summary>
    /// Clears all existing environment variables that have been stored in the OriginalValues dictionary.
    /// This ensures that tests only see the environment variables they explicitly set, preventing
    /// interference from previously set variables.
    /// </summary>
    private void CleanExistingEnvironmentVariables()
    {
        foreach (var kvp in OriginalValues)
        {
            Environment.SetEnvironmentVariable(kvp.Key, null);
        }
    }

    /// <summary>
    /// Restores all environment variables to their original values that were stored before modification.
    /// This method is called during disposal to ensure the system environment is properly restored.
    /// </summary>
    internal override void Cleanup()
    {
        foreach (var kvp in OriginalValues)
        {
            Environment.SetEnvironmentVariable(kvp.Key, kvp.Value as string);
        }
    }
}
