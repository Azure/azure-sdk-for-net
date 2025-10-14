// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.Support.Models;

namespace Azure.ResourceManager.Support
{
    public partial class ProblemClassificationData
    {
        /// <summary> Localized name of problem classification. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string DisplayName => LocalDisplayName;

        /// <summary> This property indicates whether secondary consent is present for problem classification. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<SecondaryConsentEnabled> SecondaryConsentEnabled => (IReadOnlyList<SecondaryConsentEnabled>)LocalSecondaryConsentEnabled;
    }
}
