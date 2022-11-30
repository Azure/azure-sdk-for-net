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
        /// <summary> Initializes a new instance of RouterRule. </summary>
        internal RouterRule()
        {
        }

        /// <summary> The type discriminator describing a sub-type of Rule. </summary>
        public string Kind { get; set; }
    }
}
