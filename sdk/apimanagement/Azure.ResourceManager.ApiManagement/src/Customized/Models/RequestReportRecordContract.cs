// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Net;
using System.Text.Json;
using System.ClientModel.Primitives;
using Azure.Core;
using System.Runtime.CompilerServices;

namespace Azure.ResourceManager.ApiManagement.Models
{
    /// <summary> Request Report data. </summary>
    public partial class RequestReportRecordContract
    {
        /// <summary> The HTTP status code received by the gateway as a result of forwarding this request to the backend. </summary>
        [CodeGenMemberSerializationHooks(DeserializationValueHook = nameof(DeserializeBackendResponseCodeValue))]
        public string BackendResponseCode { get; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeBackendResponseCodeValue(JsonProperty property, ref Optional<string> backendResponseCode) // the type here is string since name is required
        {
            // this is the logic we would like to have for the value deserialization
            backendResponseCode = property.Value.GetInt32().ToString();
        }
    }
}
