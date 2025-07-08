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
    private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    // cspell: disable-next-line
    private const string charsLower = "abcdefghijklmnopqrstuvwxyz0123456789";
    private const string Sanitized = "Sanitized";
    private SortedDictionary<string, string> _variables = new();
    internal const string DateTimeOffsetNowVariableKey = "DateTimeOffsetNow";

    private TestRecording()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// TODO.
    /// </summary>
    public SortedDictionary<string, string> Variables => _variables;

    /// <summary>
    /// TODO.
    /// </summary>
    public RecordedTestMode Mode { get; }

    /// <summary>
    /// TODO.
    /// </summary>
    public TestRandom Random { get; }

    /// <summary>
    /// TODO.
    /// </summary>
    public string RecordingId { get; private set; }

    /// <summary>
    /// TODO.
    /// </summary>
    public DateTimeOffset Now { get; }

    /// <summary>
    /// TODO.
    /// </summary>
    public DateTimeOffset UtcNow { get; }

    /// <summary>
    /// TODO.
    /// </summary>
    public bool HasRequests { get; internal set; }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static async Task<TestRecording> CreateAsync()
    {
        await Task.Yield();
        throw new NotImplementedException();
    }

    internal async Task InitializeProxySettingsAsync()
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