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
    [Obsolete("This type is obsolete and will be removed in a future release.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct AppContainersSkuName : System.IEquatable<Azure.ResourceManager.AppContainers.Models.AppContainersSkuName>
    {
        /// <summary> SkuName for container app. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AppContainersSkuName(string value) { throw null; }

        /// <summary> SkuName for container app. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator ==(Azure.ResourceManager.AppContainers.Models.AppContainersSkuName left, Azure.ResourceManager.AppContainers.Models.AppContainersSkuName right) { throw null; }

        /// <summary> SkuName for container app. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static implicit operator Azure.ResourceManager.AppContainers.Models.AppContainersSkuName(string value) { throw null; }

        /// <summary> SkuName for container app. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator !=(Azure.ResourceManager.AppContainers.Models.AppContainersSkuName left, Azure.ResourceManager.AppContainers.Models.AppContainersSkuName right) { throw null; }

        /// <summary> SkuName for container app. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Azure.ResourceManager.AppContainers.Models.AppContainersSkuName Consumption { get { throw null; } }

        /// <summary> SkuName for container app. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Azure.ResourceManager.AppContainers.Models.AppContainersSkuName Premium { get { throw null; } }

        /// <summary> SkuName for container app. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Equals(Azure.ResourceManager.AppContainers.Models.AppContainersSkuName other) { throw null; }

        /// <summary> SkuName for container app. </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }

        /// <summary> SkuName for container app. </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }

        /// <summary> SkuName for container app. </summary>
        public override string ToString() { throw null; }
    }
}
