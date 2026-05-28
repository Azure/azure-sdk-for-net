// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Communication.CallingServer
{
    [CodeGenModel("CollectTonesResult", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class CollectTonesResult
    {
        /// <summary>
        /// The Tones colelcted.
        /// </summary>
        [CodeGenMember("Tones")]
        public IReadOnlyList<DtmfTone> Tones { get; }
    }
}
