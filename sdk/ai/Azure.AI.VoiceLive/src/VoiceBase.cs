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
    /// Base class for the different voice types supported by the VoiceLive service
    /// </summary>
    public abstract class VoiceBase
    {
        internal abstract BinaryData ToBinaryData();
    }
}
