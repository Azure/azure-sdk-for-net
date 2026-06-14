// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0169 // Compatibility extensible enums preserve generated backing fields.
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

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The previous GA SDK generated this legacy AutoRest support type from older Security swagger.
    // Current TypeSpec either emits the updated resource/model name or no longer includes that
    // legacy schema, so this hidden obsolete shim is retained only for ApiCompat.
    [Obsolete("This API is no longer supported by the service.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct SecurityCenterConfigurationStatus : System.IEquatable<SecurityCenterConfigurationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityCenterConfigurationStatus(string value) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public static SecurityCenterConfigurationStatus Configured { get { throw new NotSupportedException("This API is no longer supported by the service."); } }
        public static SecurityCenterConfigurationStatus Failed { get { throw new NotSupportedException("This API is no longer supported by the service."); } }
        public static SecurityCenterConfigurationStatus InProgress { get { throw new NotSupportedException("This API is no longer supported by the service."); } }
        public static SecurityCenterConfigurationStatus NoStatus { get { throw new NotSupportedException("This API is no longer supported by the service."); } }
        public static SecurityCenterConfigurationStatus NotConfigured { get { throw new NotSupportedException("This API is no longer supported by the service."); } }
        public bool Equals(SecurityCenterConfigurationStatus other) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public override bool Equals(object obj) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public override int GetHashCode() { throw new NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator ==(SecurityCenterConfigurationStatus left, SecurityCenterConfigurationStatus right) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public static implicit operator SecurityCenterConfigurationStatus(string value) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator !=(SecurityCenterConfigurationStatus left, SecurityCenterConfigurationStatus right) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public override string ToString() { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
