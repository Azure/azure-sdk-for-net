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
    [Obsolete("This API is no longer supported by the service.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct SecurityAlertNotificationState : System.IEquatable<SecurityAlertNotificationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityAlertNotificationState(string value) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public static SecurityAlertNotificationState Off { get { throw new NotSupportedException("This API is no longer supported by the service."); } }
        public static SecurityAlertNotificationState On { get { throw new NotSupportedException("This API is no longer supported by the service."); } }
        public bool Equals(SecurityAlertNotificationState other) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public override bool Equals(object obj) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public override int GetHashCode() { throw new NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator ==(SecurityAlertNotificationState left, SecurityAlertNotificationState right) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public static implicit operator SecurityAlertNotificationState(string value) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator !=(SecurityAlertNotificationState left, SecurityAlertNotificationState right) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public override string ToString() { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
