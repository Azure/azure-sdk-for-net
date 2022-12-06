// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenModel("JobExceptionTrigger")]
    [CodeGenSuppress("JobExceptionTrigger")]
    [JsonConverter(typeof(PolymorphicWriteOnlyJsonConverter<JobExceptionTrigger>))]
    public abstract partial class JobExceptionTrigger
    {
        /// <summary> The type discriminator describing a sub-type of ExceptionTrigger. </summary>
        protected string Kind { get; set; }
    }
}
