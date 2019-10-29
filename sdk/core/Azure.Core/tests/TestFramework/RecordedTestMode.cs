// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Testing
{
    public enum RecordedTestMode
    {
        Live,
        Record,
        Playback,
        // Backcompat with Track 1
        None = Live
    }
}
