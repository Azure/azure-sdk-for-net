// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Linq;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public partial class NetworkToNetworkInterconnectPatch
    {
        /// <summary> Common properties for Layer2Configuration. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future version. Use Layer2Settings instead.")]
        public Layer2Configuration Layer2Configuration
        {
            get => throw new NotSupportedException("This property is obsolete and will be removed in a future version. Use Layer2Settings instead.");
            set => throw new NotSupportedException("This property is obsolete and will be removed in a future version. Use Layer2Settings instead.");
        }

        /// <summary> Common properties for Layer3Configuration. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future version. Use OptionBLayer3Settings instead.")]
        public OptionBLayer3Configuration OptionBLayer3Configuration
        {
            get => throw new NotSupportedException("This property is obsolete and will be removed in a future version. Use OptionBLayer3Settings instead.");
            set => throw new NotSupportedException("This property is obsolete and will be removed in a future version. Use OptionBLayer3Settings instead.");
        }

        /// <summary> NPB Static Route Configuration properties. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future version. Use NpbStaticRouteSettings instead.")]
        public NpbStaticRouteConfiguration NpbStaticRouteConfiguration
        {
            get => throw new NotSupportedException("This property is obsolete and will be removed in a future version. Use NpbStaticRouteSettings instead.");
            set => throw new NotSupportedException("This property is obsolete and will be removed in a future version. Use NpbStaticRouteSettings instead.");
        }

        /// <summary> Import Route Policy information. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future version. Use ImportRoutePolicySettings instead.")]
        public ImportRoutePolicyInformation ImportRoutePolicy
        {
            get => throw new NotSupportedException("This property is obsolete and will be removed in a future version. Use ImportRoutePolicySettings instead.");
            set => throw new NotSupportedException("This property is obsolete and will be removed in a future version. Use ImportRoutePolicySettings instead.");
        }

        /// <summary> Export Route Policy information. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future version. Use ExportRoutePolicySettings instead.")]
        public ExportRoutePolicyInformation ExportRoutePolicy
        {
            get => throw new NotSupportedException("This property is obsolete and will be removed in a future version. Use ExportRoutePolicySettings instead.");
            set => throw new NotSupportedException("This property is obsolete and will be removed in a future version. Use ExportRoutePolicySettings instead.");
        }
    }
}
