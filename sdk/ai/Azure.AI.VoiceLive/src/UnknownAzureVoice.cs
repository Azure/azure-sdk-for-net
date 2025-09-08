// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;

namespace Azure.AI.VoiceLive
{
    internal partial class UnknownAzureVoice
    {
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        internal override BinaryData ToBinaryData() => this.PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions.Json);
    }
}
