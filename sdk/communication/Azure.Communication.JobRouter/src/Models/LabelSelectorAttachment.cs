// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Data;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Communication.JobRouter.Models
{
    [CodeGenModel("LabelSelectorAttachment")]
    [JsonConverter(typeof(PolymorphicWriteOnlyJsonConverter<LabelSelectorAttachment>))]
    public abstract partial class LabelSelectorAttachment
    {
    }
}
