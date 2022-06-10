// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenModel("ExceptionTrigger")]
    [JsonConverter(typeof(PolymorphicWriteOnlyJsonConverter<JobExceptionTrigger>))]
    public abstract partial class JobExceptionTrigger
    {
    }
}
