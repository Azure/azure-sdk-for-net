// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.ApiManagement;

[CodeGenSerialization(nameof(TermsOfServiceUri), DeserializationValueHook = nameof(DeserializetermsOfServiceUrlValue))]
public partial class ApiData : IUtf8JsonSerializable, IJsonModel<ApiData>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void DeserializetermsOfServiceUrlValue(JsonProperty property0, ref Uri termsOfServiceUrl)
    {
        if (property0.Value.ValueKind == JsonValueKind.Null)
            return;
        var str = property0.Value.GetString();
        if (!string.IsNullOrEmpty(str))
        {
            if (Uri.TryCreate(str, UriKind.Absolute, out _))
            {
                termsOfServiceUrl = new Uri(str);
            }
        }
    }
}

[CodeGenSerialization(nameof(ServiceUri), DeserializationValueHook = nameof(DeserializeServiceUriValue))]
public partial class ApiData : IUtf8JsonSerializable, IJsonModel<ApiData>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void DeserializeServiceUriValue(JsonProperty property0, ref Uri serviceUrl)
    {
        if (property0.Value.ValueKind == JsonValueKind.Null)
            return;
        var str = property0.Value.GetString();
        if (!string.IsNullOrEmpty(str))
        {
            if (Uri.TryCreate(str, UriKind.Absolute, out _))
            {
                serviceUrl = new Uri(str);
            }
        }
    }
}
