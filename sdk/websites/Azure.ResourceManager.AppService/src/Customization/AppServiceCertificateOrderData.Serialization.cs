// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.AppService.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.AppService
{
    /// <summary>
    /// A class representing the AppServiceCertificateOrder data model.
    /// A AppServiceCertificateOrderData definition.
    /// Fix the responsed error type "certificateOrders" to "Microsoft.CertificateRegistration/certificateOrders"
    /// Issue:https://github.com/Azure/azure-sdk-for-net/issues/45177
    /// </summary>
    [CodeGenSerialization(nameof(ResourceType), DeserializationValueHook = nameof(DeserializeTypeValue))]
    public partial class AppServiceCertificateOrderData : TrackedResourceData
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeTypeValue(JsonProperty property, ref ResourceType type)
        {
            var propVal = property.Value.GetString();
            type = propVal == "certificateOrders" ? new ResourceType("Microsoft.CertificateRegistration/certificateOrders") : new ResourceType(propVal);
        }
    }
}
