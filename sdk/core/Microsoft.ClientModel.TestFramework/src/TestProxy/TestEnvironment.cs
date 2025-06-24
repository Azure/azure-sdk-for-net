// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Threading;
using NUnit.Framework;
using System.ClientModel.Primitives;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System.Collections.Concurrent;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
///   Represents the ambient environment in which the test suite is
///   being run.
/// </summary>
public abstract class TestEnvironment
{
    private static readonly Dictionary<Type, Task> s_environmentStateCache = new();
    private readonly Type _type;
    private static readonly HashSet<Type> s_bootstrappingAttemptedTypes = new();
    private static readonly object s_syncLock = new();

    /// <summary>
    /// TODO.
    /// </summary>ID
    public abstract RecordedTestMode? Mode { get; set; }

    /// <summary>
    /// TODO.
    /// </summary>
    public abstract TestRecording TestRecording { get; set; }

    /// <summary>
    /// TODO.
    /// </summary>
    public abstract AuthenticationToken Credential { get; set; }

    /// <summary>
    /// TODO.
    /// </summary>
    public abstract Dictionary<string, string> EnvironmentFileValues { get; protected set; }

    /// <summary>
    /// TODO
    /// </summary>
    protected TestEnvironment()
    {
        _type = GetType();
#if NET5_0_OR_GREATER // TODO
        if (OperatingSystem.IsWindows())
        {
            ParseWindowsEnvironmentFile();
        }
#endif
    }

    /// <summary>
    /// Waits until environment becomes ready to use. See <see cref="WaitForEnvironmentCoreAsync"/> to define sampling scenario.
    /// </summary>
    /// <returns>A task.</returns>
    public async ValueTask WaitForEnvironmentAsync()
    {
        Task? task;
        lock (s_environmentStateCache)
        {
            if (!s_environmentStateCache.TryGetValue(_type, out task))
            {
                task = WaitForEnvironmentCoreAsync();
                s_environmentStateCache[_type] = task;
            }
        }
        await task.ConfigureAwait(false);
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    protected abstract Task WaitForEnvironmentCoreAsync();

    /// <summary>
    /// TODO.
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
#if NET5_0_OR_GREATER
    [SupportedOSPlatform("Windows")]
#endif
    protected void ParseWindowsEnvironmentFile()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    protected string GetRecordedOptionalVariable(string name)
    {
        return GetRecordedOptionalVariable(name, _ => { });
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    protected string GetRecordedOptionalVariable(string name, Action<RecordedVariableOptions> options)
    {
        if (Mode == RecordedTestMode.Playback)
        {
            //return GetRecordedValue(name);
        }

        string value = string.Empty;  // TODO -GetOptionalVariable(name);

        if (Mode is null or RecordedTestMode.Live)
        {
            return value;
        }

        if (TestRecording == null)
        {
            throw new InvalidOperationException("Recorded value should not be set outside the test method invocation");
        }

        // If the value was populated, sanitize before recording it.

        string sanitizedValue = value;

        if (!string.IsNullOrEmpty(value))
        {
            var optionsInstance = new RecordedVariableOptions();
            options?.Invoke(optionsInstance);
            sanitizedValue = optionsInstance.Apply(sanitizedValue);
        }

        TestRecording?.SetVariable(name, sanitizedValue);
        return value;
    }

    /// <summary>
    /// Returns and records an environment variable value when running live or recorded value during playback.
    /// Throws when variable is not found.
    /// </summary>
    protected string GetRecordedVariable(string name)
    {
        return GetRecordedVariable(name, null);
    }

    /// <summary>
    /// Returns and records an environment variable value when running live or recorded value during playback.
    /// Throws when variable is not found.
    /// </summary>
    protected string GetRecordedVariable(string name, Action<RecordedVariableOptions>? options)
    {
        // TODO
        //var value = GetRecordedOptionalVariable(name, options);
        //if (value == null)
        //{
        //    BootStrapTestResources();
        //    value = GetRecordedOptionalVariable(name, options);
        //}
        //EnsureValue(name, value);
        //return value;
        return string.Empty;
    }
}