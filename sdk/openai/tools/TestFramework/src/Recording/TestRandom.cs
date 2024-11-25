// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace OpenAI.TestFramework.Recording;

/// <summary>
/// Represents an implementation of the <see cref="Random"/> class used for test recordings.
/// </summary>
public class TestRandom : Random
{
    private RecordedTestMode _mode;

    /// <summary>
    /// Initializes a new instance of the <see cref="TestRandom"/> class.
    /// </summary>
    /// <param name="mode">The recorded test mode.</param>
    /// <param name="seed">The seed value.</param>
    public TestRandom(RecordedTestMode mode, int seed) : base(seed)
    {
        _mode = mode;
    }

    /// <summary>
    /// Generates a new <see cref="Guid"/> based on the recorded test mode.
    /// </summary>
    /// <returns>A new <see cref="Guid"/>.</returns>
    public Guid NewGuid()
    {
        if (_mode == RecordedTestMode.Live)
        {
            return Guid.NewGuid();
        }

        var bytes = new byte[16];
        NextBytes(bytes);
        return new Guid(bytes);
    }
}
