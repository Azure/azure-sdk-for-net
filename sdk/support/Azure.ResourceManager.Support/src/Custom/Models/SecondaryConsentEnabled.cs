// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Support.Models
{
    public partial class SecondaryConsentEnabled
    {
        /// <summary> User consent description. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Description => LocalDescription;

        /// <summary> The Azure service for which secondary consent is needed for case creation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string SecondaryConsentEnabledType => LocalSecondaryConsentEnabledType;
    }
}
