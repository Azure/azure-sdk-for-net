// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// Represents the mode of a recorded test.
/// </summary>
public enum RecordedTestMode
{
    /// <summary>
    /// Live mode.
    /// </summary>
    Live,
    /// <summary>
    /// Record mode.
    /// </summary>
    Record,
    /// <summary>
    /// Playback mode.
    /// </summary>
    Playback
}
