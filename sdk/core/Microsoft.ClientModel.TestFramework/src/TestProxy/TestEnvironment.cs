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
using System.ClientModel;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
///   Represents the ambient environment in which the test suite is
///   being run.
/// </summary>
public abstract class TestEnvironment
{
    private static readonly Dictionary<Type, Task> s_environmentStateCache = new();
    private readonly string _prefix;
    //private AuthenticationTokenProvider? _tokenProvider;
    //private TestRecording? _recording;
    private Dictionary<string, string> _environmentFile;
    private static readonly HashSet<Type> s_bootstrappingAttemptedTypes = new();
    private static readonly object s_syncLock = new();
    //private Exception? _bootstrappingException;
    private readonly Type _type;
    private readonly string _serviceName;

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="serviceName"></param>
    /// <param name="pathsToEnvironmentFiles"></param>
    /// <exception cref="InvalidOperationException"></exception>
    protected TestEnvironment(string serviceName, string[] pathsToEnvironmentFiles)
    {
        Argument.AssertNotNullOrEmpty(serviceName, nameof(serviceName));
        if (string.IsNullOrEmpty(RepositoryRoot))
        {
            throw new InvalidOperationException("Unexpected error, project path not found.");
        }

        _serviceName = serviceName;
        _prefix = serviceName + "_";
        _type = GetType();

        _environmentFile = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        foreach (var path in pathsToEnvironmentFiles)
        {
            if (File.Exists(path))
            {
#pragma warning disable CA1416 // env files are only supported on windows
                var json = JsonDocument.Parse(ProtectedData.Unprotect(File.ReadAllBytes(path), null, DataProtectionScope.CurrentUser));
#pragma warning restore CA1416
            }
        }
    }

    static TestEnvironment()
    {
        // Traverse parent directories until we find an "artifacts" directory
        // parent of that would become a repo root for test environment resolution purposes
        var directoryInfo = new DirectoryInfo(Assembly.GetExecutingAssembly().Location);

        while (directoryInfo.Name != "artifacts")
        {
            if (directoryInfo.Parent == null)
            {
                return;
            }

            directoryInfo = directoryInfo.Parent;
        }

        RepositoryRoot = directoryInfo?.Parent?.FullName;
    }

    /// <summary>
    /// TODO.
    /// </summary>
    public string ServiceName => _serviceName;

    /// <summary>
    /// TODO.
    /// </summary>
    public static string? RepositoryRoot { get; }

    /// <summary>
    /// TODO.
    /// </summary>
    public bool LocalRun { get; set; } = true;

    /// <summary>
    /// TODO.
    /// </summary>
    public string? DevCertPath { get; set; }

    /// <summary>
    /// TODO.
    /// </summary>
    public string? DevCertPassword { get; set; }

    /// <summary>
    /// TODO.
    /// </summary>
    public RecordedTestMode? Mode { get; set; }

    /// <summary>
    /// TODO.
    /// </summary>
    public virtual AuthenticationTokenProvider TokenProvider
    {
        get
        {
            throw new NotImplementedException(); // TODO
        //    if (_tokenProvider != null)
        //    {
        //        return _tokenProvider;
        //    }

        //    if (Mode == RecordedTestMode.Playback)
        //    {
        //        throw new NotImplementedException();
        //        // TODO - create mock token
        //    }
        //    else
        //    {
        //        if (_recording == null)
        //        {
        //            throw new NotImplementedException(); // Not sure if we will need this here
        //        }
        //        throw new NotImplementedException(); // TODO
        //    }
        }
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <returns>A task.</returns>
    public async ValueTask WaitForEnvironmentAsync()
    {
        Task? task;
        lock (s_environmentStateCache)
        {
            if (!s_environmentStateCache.TryGetValue(_type, out task))
            {
                task = InitializeEnvironmentAsync();
                s_environmentStateCache[_type] = task;
            }
        }
        await task.ConfigureAwait(false);
    }

    /// <summary>
    /// Initializes the test environment asynchronously.
    /// </summary>
    /// <returns></returns>
    public abstract Task InitializeEnvironmentAsync();

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    protected string GetRecordedOptionalVariable(string name)
    {
        throw new NotImplementedException();
    }
}