// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The different domains of PII entities that users can filter requests by.
    /// </summary>
    public enum PiiEntityDomain
    {
        /// <summary>
        /// Don't apply any domain filter. This is the default value.
        /// </summary>
        None,
        /// <summary>
        /// Protected Health Information entities.
        /// For more information, see <see href="https://aka.ms/azsdk/language/pii"/>.
        /// </summary>
        ProtectedHealthInformation
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name should match first type name", Justification = "Small extensions, good to keep here.")]
    internal static class PiiEntityDomainExtensions
    {
        internal static string GetString(this PiiEntityDomain type)
        {
            return type switch
            {
                PiiEntityDomain.None => null,
                PiiEntityDomain.ProtectedHealthInformation => "phi",
                _ => null,
            };
        }
    }
}
