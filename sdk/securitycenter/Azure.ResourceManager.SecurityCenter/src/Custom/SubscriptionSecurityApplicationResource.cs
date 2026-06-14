// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CA1822 // Compatibility instance members intentionally preserve previous signatures.
#pragma warning disable CS1591 // Hidden compatibility shims do not need public docs.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter
{
    [CodeGenSuppress("Data")]
    public partial class SubscriptionSecurityApplicationResource : IJsonModel<SecurityApplicationData>, IPersistableModel<SecurityApplicationData>
    {
        public virtual SecurityApplicationData Data
        {
            get
            {
                if (!HasData)
                {
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                }

                return new SecurityApplicationData(_data);
            }
        }

        [ForwardsClientCalls]
        public virtual Task<ArmOperation<SubscriptionSecurityApplicationResource>> UpdateAsync(WaitUntil waitUntil, SecurityApplicationData data, CancellationToken cancellationToken = default(CancellationToken))
            => UpdateAsync(waitUntil, (SecurityConnectorApplicationData)data, cancellationToken);

        [ForwardsClientCalls]
        public virtual ArmOperation<SubscriptionSecurityApplicationResource> Update(WaitUntil waitUntil, SecurityApplicationData data, CancellationToken cancellationToken = default(CancellationToken))
            => Update(waitUntil, (SecurityConnectorApplicationData)data, cancellationToken);

        SecurityApplicationData IJsonModel<SecurityApplicationData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<SecurityApplicationData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        SecurityApplicationData IPersistableModel<SecurityApplicationData>.Create(BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<SecurityApplicationData>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        BinaryData IPersistableModel<SecurityApplicationData>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
