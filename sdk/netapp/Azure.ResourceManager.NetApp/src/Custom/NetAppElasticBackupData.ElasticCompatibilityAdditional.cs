// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591
#pragma warning disable SA1402

using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.NetApp.Models;

namespace Azure.ResourceManager.NetApp
{
    public partial class NetAppElasticBackupData
    {
        protected virtual ResourceData JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new NetAppElasticBackupData();
    }
}
