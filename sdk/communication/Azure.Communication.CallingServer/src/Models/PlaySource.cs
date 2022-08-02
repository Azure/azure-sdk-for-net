// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Communication.CallingServer
{
    /// <summary> The PlaySource. </summary>
    public abstract class PlaySource
    {
        /// <summary> Defines the identifier to be used for caching related media. </summary>
        public string PlaySourceId { get; set; }
    }
}
