// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Net;

namespace Azure.ResourceManager.NetApp.Models
{
    // FINDING (2026-05): The original comment claimed "Spec change can't fix this — TypeSpec
    // has no way to project the wire-format string into a CLR System.Net.IPAddress on the
    // client side". That is INCORRECT. The Azure C# generator already maps the
    // `Azure.Core.ipV4Address` / `Azure.Core.ipV6Address` scalars to `System.Net.IPAddress`
    // with full JSON serialization support — see KnownAzureTypes.cs (`_idToTypes` /
    // `_typeToSerializationExpression`) and AzureTypeFactory.CreateFrameworkType (the same
    // pattern as `Azure.Core.azureLocation` → `AzureLocation` and `Azure.Core.eTag` → `ETag`).
    //
    // Updating Volume.tsp to type `clientIp` as `Azure.Core.ipV4Address` (or projecting via
    // `@@alternateType` in client.tsp) would let the generator emit `IPAddress` natively
    // and let us delete this entire file.
    //
    // TODO: tracked by https://github.com/Azure/azure-sdk-for-net/issues/58989 — once the
    // spec is updated and the SDK is regenerated, delete this shim file and refresh the
    // API listings.
    public partial class NetAppVolumeBreakFileLocksContent
    {
        /// <summary> The client IP address (legacy alias for <see cref="ClientIp"/> typed as <see cref="IPAddress"/>). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IPAddress ClientIP
        {
            get => string.IsNullOrEmpty(ClientIp) ? null : IPAddress.Parse(ClientIp);
            set => ClientIp = value?.ToString();
        }
    }
}
