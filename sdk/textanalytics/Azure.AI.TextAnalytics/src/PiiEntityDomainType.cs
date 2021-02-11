// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The different domains of PII entities that users can filter requests by.
    /// </summary>
    public enum PiiEntityDomainType
    {
        /// <summary>
        /// Protected Health Information entities.
        /// For more information see <a href="https://aka.ms/tanerpii"/>.
        /// </summary>
        ProtectedHealthInformation
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name should match first type name", Justification = "Small extensions, good to keep here.")]
    internal static class PiiEntityDomainTypeExtensions
    {
        internal static string GetString(this PiiEntityDomainType type)
        {
            return type switch
            {
                PiiEntityDomainType.ProtectedHealthInformation => "phi",
                _ => null,
            };
        }
    }
}
