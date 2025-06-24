// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// TODO.
/// </summary>
public class TestRandom : Random
{
    private readonly RecordedTestMode _mode;

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="mode"></param>
    /// <param name="seed"></param>
    public TestRandom(RecordedTestMode mode, int seed) :
        base(seed)
    {
        _mode = mode;
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="mode"></param>
    public TestRandom(RecordedTestMode mode) :
        base()
    {
        _mode = mode;
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <returns></returns>
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
