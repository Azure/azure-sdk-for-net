// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.TextAnalytics.Legacy
{
    /// <summary>
    /// The different domains of PII entities that users can filter requests by.
    /// </summary>
    internal enum PiiEntityDomain
    {
        /// <summary>
        /// Don't apply any domain filter. This is the default value.
        /// </summary>
        None,
        /// <summary>
        /// Protected Health Information entities.
        /// For more information see <see href="https://aka.ms/tanerpii"/>.
        /// </summary>
        ProtectedHealthInformation
    }

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name should match first type name", Justification = "Small extensions, good to keep here.")]
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
