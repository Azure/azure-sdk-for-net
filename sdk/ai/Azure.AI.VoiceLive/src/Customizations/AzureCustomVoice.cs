﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Data;
using System.IO;
using System.Text.Json;

namespace Azure.AI.VoiceLive
{
    public partial class AzureCustomVoice
    {
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        internal override BinaryData ToBinaryData() => this.PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions.Json);
    }
}
