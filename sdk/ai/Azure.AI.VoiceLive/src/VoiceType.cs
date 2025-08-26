// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.AI.VoiceLive
{
    /// <summary>
    /// Base interface for the different voice types supported by the VoiceLive service
    /// </summary>
    public abstract class VoiceType
    {
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        internal abstract BinaryData ToBinaryData();
    }
}
