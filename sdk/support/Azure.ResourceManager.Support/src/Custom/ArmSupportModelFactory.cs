// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Support.Models
{
    public static partial class ArmSupportModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.SecondaryConsentEnabled"/>. </summary>
        /// <param name="description"> User consent description. </param>
        /// <param name="secondaryConsentEnabledType"> The Azure service for which secondary consent is needed for case creation. </param>
        /// <returns> A new <see cref="Models.SecondaryConsentEnabled"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SecondaryConsentEnabled SecondaryConsentEnabled(string description, string secondaryConsentEnabledType)
        {
            return new SecondaryConsentEnabled(description, secondaryConsentEnabledType, serializedAdditionalRawData: null);
        }
    }
}
