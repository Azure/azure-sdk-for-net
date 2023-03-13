// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

//#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.AppContainers.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.AppContainers.Models
{
    /// <summary> this class here is to keep the class public and add the AppContainersSkuName attribute </summary>
    public readonly partial struct ContainerAppBillingMeterCategory : System.IEquatable<Azure.ResourceManager.AppContainers.Models.ContainerAppBillingMeterCategory>
    {
        /// <summary> SkuName for container app. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerAppBillingMeterCategory(string value) { throw null; }

        /// <summary> SkuName for container app. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Azure.ResourceManager.AppContainers.Models.ContainerAppBillingMeterCategory PremiumSkuComputeOptimized { get { throw null; } }

        /// <summary> SkuName for container app. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Azure.ResourceManager.AppContainers.Models.ContainerAppBillingMeterCategory PremiumSkuGeneralPurpose { get { throw null; } }

        /// <summary> SkuName for container app. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Azure.ResourceManager.AppContainers.Models.ContainerAppBillingMeterCategory PremiumSkuMemoryOptimized { get { throw null; } }

        /// <summary> SkuName for container app. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Equals(Azure.ResourceManager.AppContainers.Models.ContainerAppBillingMeterCategory other) { throw null; }

        /// <summary> SkuName for container app. </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }

        /// <summary> SkuName for container app. </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }

        /// <summary> SkuName for container app. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator ==(Azure.ResourceManager.AppContainers.Models.ContainerAppBillingMeterCategory left, Azure.ResourceManager.AppContainers.Models.ContainerAppBillingMeterCategory right) { throw null; }

        /// <summary> SkuName for container app. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static implicit operator Azure.ResourceManager.AppContainers.Models.ContainerAppBillingMeterCategory(string value) { throw null; }

        /// <summary> SkuName for container app. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator !=(Azure.ResourceManager.AppContainers.Models.ContainerAppBillingMeterCategory left, Azure.ResourceManager.AppContainers.Models.ContainerAppBillingMeterCategory right) { throw null; }

        /// <summary> SkuName for container app. </summary>
        public override string ToString() { throw null; }
    }
}
