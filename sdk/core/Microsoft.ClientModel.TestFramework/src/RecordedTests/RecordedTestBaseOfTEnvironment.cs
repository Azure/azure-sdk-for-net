// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// Base class for recorded tests that use a specific test environment type.
/// </summary>
/// <typeparam name="TEnvironment">The type of test environment to use.</typeparam>
#pragma warning disable SA1649 // File name should match first type name
public abstract class RecordedTestBase<TEnvironment> : RecordedTestBase where TEnvironment : TestEnvironment, new()
#pragma warning restore SA1649 // File name should match first type name
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RecordedTestBase{TEnvironment}"/> class.
    /// </summary>
    /// <param name="isAsync">Whether to use asynchronous test execution.</param>
    /// <param name="mode">The recording mode to use, or null to use the global default.</param>
    protected RecordedTestBase(bool isAsync, RecordedTestMode? mode = null) : base(isAsync, mode)
    {
        TestEnvironment = new TEnvironment();
        TestEnvironment.Mode = Mode;
    }

    /// <summary>
    /// Starts test recording and configures the test environment with the recording session.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    /// <exception cref="InvalidOperationException">Thrown when recording fails to start.</exception>
    public override async Task StartTestRecordingAsync()
    {
        // Set the TestEnvironment Mode here so that any Mode changes in RecordedTestBase are picked up here also.
        TestEnvironment.Mode = Mode;

        await base.StartTestRecordingAsync().ConfigureAwait(false);
        if (Recording == null)
        {
            throw new InvalidOperationException("Start test recording failed.");
        }
        TestEnvironment.SetRecording(Recording);
    }

    /// <summary>
    /// Gets the test environment instance configured for this test.
    /// </summary>
    public TEnvironment TestEnvironment { get; }

    /// <summary>
    /// Waits for the test environment to become ready before running tests.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    [OneTimeSetUp]
    public async ValueTask WaitForEnvironment()
    {
        await TestEnvironment.WaitForEnvironmentAsync().ConfigureAwait(false);
    }
}
