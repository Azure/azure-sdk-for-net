// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenModel("JobExceptionTrigger")]
#pragma warning disable CA1825 // Avoid zero-length array allocations
    [CodeGenSuppress("JobExceptionTrigger")]
#pragma warning restore CA1825 // Avoid zero-length array allocations
    [JsonConverter(typeof(PolymorphicWriteOnlyJsonConverter<JobExceptionTrigger>))]
    public abstract partial class JobExceptionTrigger
    {
        /// <summary> The type discriminator describing a sub-type of ExceptionTrigger. </summary>
        protected string Kind { get; set; }
    }
}
