// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace OpenAI.TestFramework.Recording;

public class TestRandom : Random
{
    private RecordedTestMode _mode;

    public TestRandom(RecordedTestMode mode, int seed) : base(seed)
    {
        _mode = mode;
    }

    public Guid GetGuid()
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
