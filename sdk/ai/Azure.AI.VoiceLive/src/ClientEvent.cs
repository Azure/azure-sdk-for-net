// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;

namespace Azure.AI.VoiceLive
{
    public partial class ClientEvent
    {
        internal BinaryData ToBinaryData()
        {
            var ms = new MemoryStream();

            var rq = ToRequestContent();

            rq.WriteTo(ms, default);
            ms.Position = 0;
            return BinaryData.FromStream(ms);
        }
    }
}
