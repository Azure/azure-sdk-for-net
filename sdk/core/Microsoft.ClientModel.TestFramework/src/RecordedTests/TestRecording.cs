// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ClientModel.Primitives;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.ClientModel.TestFramework.TestProxy;
using System.ClientModel;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// Represents a test recording session.
/// </summary>
public class TestRecording : IAsyncDisposable
{
    private const string RandomSeedVariableKey = "RandomSeed";
    private readonly TestProxyProcess _proxy;
    //private TestRandom? _random;
    private TestFramework.TestProxy.StartInformation? _startInformation;
    private SortedDictionary<string, string> _variables = new();

    private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    // cspell: disable-next-line
    private const string charsLower = "abcdefghijklmnopqrstuvwxyz0123456789";
    private const string Sanitized = "Sanitized";
    internal const string DateTimeOffsetNowVariableKey = "DateTimeOffsetNow";

    private TestRecording(TestFramework.TestProxy.StartInformation startInformation, RecordedTestMode mode, TestProxyProcess process)
    {
        _startInformation = startInformation;
        TestMode = mode;
        _proxy = process;
    }

    /// <summary>
    /// Stores key-value pairs that need to be consistent between recording and playback.
    /// </summary>
    public SortedDictionary<string, string> Variables => _variables;

    /// <summary>
    /// Gets the current test mode (Live, Record, Playback).
    /// </summary>
    public RecordedTestMode TestMode { get; }

    /// <summary>
    /// Gets the unique identifier for the current recording session.
    /// </summary>
    public string? RecordingId { get; }

    /// <summary>
    /// Gets the current local date and time to provide consistent time values across
    /// test modes.
    /// </summary>
    public DateTimeOffset Now { get; }

    /// <summary>
    /// Gets the current date and time in Coordinated Universal Time (UTC) to provide
    /// consistent time values across test modes.
    /// </summary>
    public DateTimeOffset UtcNow { get; }

    /// <summary>
    /// Tracks whether HTTP requests were made during the test recording session.
    /// </summary>
    public bool HasRequests { get; internal set; }

    /// <summary>
    /// Gets a value indicating whether the test recording has been created successfully.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static async Task<TestRecording> CreateAsync(TestProxyProcess proxy, RecordedTestMode mode, TestFramework.TestProxy.StartInformation startInformation, TestRecordingOptions? options = default)
    {
        TestRecording recording = new(startInformation, mode, proxy);
        await recording.InitializeProxySettingsAsync(options).ConfigureAwait(false);
        return recording;
    }

    internal async Task InitializeProxySettingsAsync(TestRecordingOptions? options)
    {
        await Task.Yield();
        throw new NotImplementedException();
    }

    private async Task ApplySanitizersAsync()
    {
        await Task.Yield();
        throw new NotImplementedException();
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public HttpClientPipelineTransport CreateTransport()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public string GenerateId()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public string GenerateAlphaNumericId()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public string GenerateAssetName()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public string GetVariable()
    {
        throw new NotImplementedException();
    }

    private void ValidateVariables()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public void SetVariable()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public DisableRecordingScope DisableRecording()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public DisableRecordingScope DisableRequestBodyRecording()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="save"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async ValueTask DisposeAsync(bool save)
    {
        await Task.Yield();
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public async ValueTask DisposeAsync()
    {
        await DisposeAsync(true).ConfigureAwait(false);
    }

    /// <summary>
    /// TODO.
    /// </summary>
    public struct DisableRecordingScope : IDisposable
    {
        private readonly TestRecording _testRecording;

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="testRecording"></param>
        /// <param name="entryRecordModel"></param>
        public DisableRecordingScope(TestRecording testRecording, EntryRecordModel entryRecordModel)
        {
            _testRecording = testRecording;
            //_testRecording._disableRecording.Value = entryRecordModel;
            throw new NotImplementedException();
        }

        /// <summary>
        /// TODO.
        /// </summary>
        public void Dispose()
        {
            //_testRecording._disableRecording.Value = EntryRecordModel.Record;
            throw new NotImplementedException();
        }
    }
}