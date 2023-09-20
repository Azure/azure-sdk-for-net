// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenModel("RouterRule")]
    [CodeGenSuppress("RouterRule")]
    [JsonConverter(typeof(PolymorphicWriteOnlyJsonConverter<RouterRule>))]
    public abstract partial class RouterRule
    {
    }
}
