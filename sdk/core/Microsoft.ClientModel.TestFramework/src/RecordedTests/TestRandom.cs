// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// A deterministic random number generator designed for use in recorded tests.
/// This class extends <see cref="Random"/> to provide predictable behavior during
/// test playback while maintaining randomness during live test execution.
/// </summary>
/// <remarks>
/// When running in <see cref="RecordedTestMode.Live"/> mode, this class behaves
/// like a standard random number generator. In other modes (Record/Playback),
/// it uses a seeded random number generator to ensure deterministic behavior
/// across test runs.
/// </remarks>
public class TestRandom : Random
{
    private readonly RecordedTestMode _mode;

    /// <summary>
    /// Initializes a new instance of the <see cref="TestRandom"/> class with the specified
    /// test mode and seed value.
    /// </summary>
    /// <param name="mode">The recorded test mode that determines the random behavior.</param>
    /// <param name="seed">The seed value used to initialize the random number generator.
    /// This ensures deterministic behavior in Record and Playback modes.</param>
    public TestRandom(RecordedTestMode mode, int seed) :
        base(seed)
    {
        _mode = mode;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TestRandom"/> class with the specified
    /// test mode and a system-generated seed.
    /// </summary>
    /// <param name="mode">The recorded test mode that determines the random behavior.</param>
    public TestRandom(RecordedTestMode mode) :
        base()
    {
        _mode = mode;
    }

    /// <summary>
    /// Generates a new <see cref="Guid"/> value with behavior that depends on the test mode.
    /// </summary>
    /// <returns>
    /// A new <see cref="Guid"/> value. In <see cref="RecordedTestMode.Live"/> mode,
    /// returns a truly random GUID. In other modes, returns a deterministic GUID
    /// generated from the seeded random number generator.
    /// </returns>
    public Guid NewGuid()
    {
        if (_mode == RecordedTestMode.Live)
        {
            return Guid.NewGuid();
        }
        else
        {
            var bytes = new byte[16];
            NextBytes(bytes);
            return new Guid(bytes);
        }
    }
}
