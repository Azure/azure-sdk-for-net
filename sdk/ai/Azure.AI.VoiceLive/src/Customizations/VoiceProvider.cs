// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.VoiceLive
{
    /// <summary>
    /// Base interface for the different voice types supported by the VoiceLive service
    /// </summary>
    public abstract class VoiceProvider
    {
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        internal abstract BinaryData ToBinaryData();
    }
}
