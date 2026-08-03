// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Provisioning;

namespace Azure.Provisioning.CognitiveServices
{
    public partial class RaiPolicyContentFilter
    {
        /// <summary> Gets or sets the Enabled. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future release. Use IsEnabled instead.")]
        public BicepValue<bool> Enabled
        {
            get => IsEnabled;
            set => IsEnabled = value;
        }

        /// <summary> Gets or sets the Blocking. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future release. Use IsBlocking instead.")]
        public BicepValue<bool> Blocking
        {
            get => IsBlocking;
            set => IsBlocking = value;
        }
    }
}
