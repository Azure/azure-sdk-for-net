// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class FunctionRouterRule : IUtf8JsonSerializable
    {
        /// <summary> Initializes a new instance of AzureFunctionRule. </summary>
        /// <param name="functionAppUri"> URL for custom azure function. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="functionAppUri"/> is null. </exception>
        public FunctionRouterRule(Uri functionAppUri)
            : this("azure-function-rule", functionAppUri, null)
        {
            Argument.AssertNotNull(functionAppUri, nameof(functionAppUri));
        }

        /// <summary> Credentials used to access Azure function rule. </summary>
        public FunctionRouterRuleCredential Credential { get; set; }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("functionUri"u8);
            writer.WriteStringValue(FunctionUri.AbsoluteUri);
            if (Optional.IsDefined(Credential))
            {
                writer.WritePropertyName("credential"u8);
                writer.WriteObjectValue(Credential);
            }
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind);
            writer.WriteEndObject();
        }
    }
}
