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
        /// <summary> Initializes a new instance of ExceptionAction. </summary>
        internal ExceptionAction()
        {
        }

        /// <summary> The type discriminator describing a sub-type of ExceptionAction. </summary>
        protected string Kind { get; set; }
    }
}
