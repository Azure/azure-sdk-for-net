// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenModel("WorkerSelectorAttachment")]
    [JsonConverter(typeof(PolymorphicWriteOnlyJsonConverter<WorkerSelectorAttachment>))]
    public abstract partial class WorkerSelectorAttachment
    {
    }
}
