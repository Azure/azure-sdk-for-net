// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Communication.JobRouter.Models
{
    [CodeGenModel("QueueSelector")]
    [JsonConverter(typeof(PolymorphicWriteOnlyJsonConverter<QueueSelector>))]
    public abstract partial class QueueSelector
    {
    }
}
