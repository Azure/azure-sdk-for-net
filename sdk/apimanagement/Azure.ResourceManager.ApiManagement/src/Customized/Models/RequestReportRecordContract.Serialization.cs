// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ApiManagement.Models
{
    [CodeGenSuppress("DeserializeRequestReportRecordContract", typeof(JsonElement), typeof(ModelReaderWriterOptions))]
    public partial class RequestReportRecordContract
    {
        internal static RequestReportRecordContract DeserializeRequestReportRecordContract(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string apiId = default;
            string operationId = default;
            string productId = default;
            string userId = default;
            RequestMethod? method = default;
            Uri uri = default;
            IPAddress ipAddress = default;
            string backendResponseCode = default;
            int? responseCode = default;
            int? responseSize = default;
            DateTimeOffset? timestamp = default;
            string cache = default;
            double? apiTime = default;
            double? serviceTime = default;
            string apiRegion = default;
            ResourceIdentifier subscriptionResourceId = default;
            string requestId = default;
            int? requestSize = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (JsonProperty prop in element.EnumerateObject())
            {
                if (prop.NameEquals("apiId"u8))
                {
                    apiId = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("operationId"u8))
                {
                    operationId = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("productId"u8))
                {
                    productId = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("userId"u8))
                {
                    userId = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("method"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                    {
                        method = RequestMethod.Parse(prop.Value.GetString());
                    }
                    continue;
                }
                if (prop.NameEquals("url"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                    {
                        uri = string.IsNullOrEmpty(prop.Value.GetString()) ? null : new Uri(prop.Value.GetString(), UriKind.RelativeOrAbsolute);
                    }
                    continue;
                }
                if (prop.NameEquals("ipAddress"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                    {
                        ipAddress = IPAddress.Parse(prop.Value.GetString());
                    }
                    continue;
                }
                if (prop.NameEquals("backendResponseCode"u8))
                {
                    backendResponseCode = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("responseCode"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                    {
                        responseCode = prop.Value.GetInt32();
                    }
                    continue;
                }
                if (prop.NameEquals("responseSize"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                    {
                        responseSize = prop.Value.GetInt32();
                    }
                    continue;
                }
                if (prop.NameEquals("timestamp"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                    {
                        timestamp = prop.Value.GetDateTimeOffset("O");
                    }
                    continue;
                }
                if (prop.NameEquals("cache"u8))
                {
                    cache = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("apiTime"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                    {
                        apiTime = prop.Value.GetDouble();
                    }
                    continue;
                }
                if (prop.NameEquals("serviceTime"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                    {
                        serviceTime = prop.Value.GetDouble();
                    }
                    continue;
                }
                if (prop.NameEquals("apiRegion"u8))
                {
                    apiRegion = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("subscriptionId"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                    {
                        subscriptionResourceId = new ResourceIdentifier(prop.Value.GetString());
                    }
                    continue;
                }
                if (prop.NameEquals("requestId"u8))
                {
                    requestId = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("requestSize"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                    {
                        requestSize = prop.Value.GetInt32();
                    }
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new RequestReportRecordContract(apiId, operationId, productId, userId, method, uri, ipAddress, backendResponseCode, responseCode, responseSize, timestamp, cache, apiTime, serviceTime, apiRegion, subscriptionResourceId, requestId, requestSize, additionalBinaryDataProperties);
        }
    }
}
