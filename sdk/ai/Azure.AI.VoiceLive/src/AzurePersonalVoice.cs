// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.VoiceLive
{
    public partial class AzurePersonalVoice
    {
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        internal override BinaryData ToBinaryData() => this.PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions.Json);
    }
}
