// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Data;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenModel("ExceptionAction")]
    [JsonConverter(typeof(PolymorphicWriteOnlyJsonConverter<ExceptionAction>))]
    public abstract partial class ExceptionAction
    {
    }
}
