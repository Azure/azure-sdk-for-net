// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;

namespace Azure.AI.VoiceLive
{
    public partial class AzureStandardVoice : VoiceBase
    {
        internal override BinaryData ToBinaryData()
        {
            var ms = new MemoryStream();

            var rq = ToRequestContent();

            rq.WriteTo(ms, default);
            ms.Position = 0;
            return BinaryData.FromStream(ms);
        }
    }
}
