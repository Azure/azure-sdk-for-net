// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CA1822 // Compatibility instance members intentionally preserve previous signatures.
#pragma warning disable CS1591 // Hidden obsolete compatibility shims do not need public docs.

using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.SecurityCenter;
using Azure.ResourceManager.SecurityCenter.Mocking;
using Azure.ResourceManager.SecurityCenter.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter
{
    // Current TypeSpec generates SecurityConnectorApplicationData for the resource. The GA SDK
    // exposed the older SecurityApplicationData shape and update overloads, so these hidden
    // unsupported members are retained only for ApiCompat.
    [CodeGenSuppress("Data")]
    public partial class SecurityConnectorApplicationResource
    {
        public virtual SecurityApplicationData Data { get { throw new NotSupportedException("This API is no longer supported by the service."); } }

        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<SecurityConnectorApplicationResource> Update(WaitUntil waitUntil, SecurityApplicationData data, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<SecurityConnectorApplicationResource>> UpdateAsync(WaitUntil waitUntil, SecurityApplicationData data, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
