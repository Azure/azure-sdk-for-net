// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.Language.QuestionAnswering
{
    /// <summary>
    /// Hand-authored extensions for <see cref="QuestionAnsweringClientOptions"/>.
    /// </summary>
    public partial class QuestionAnsweringClientOptions
    {
        /// <summary>
        /// Gets the method used to interpret string offsets, which is always <see cref="StringIndexType.Utf16CodeUnit"/> for .NET.
        /// </summary>
        internal static StringIndexType DefaultStringIndexType { get; } =
            StringIndexType.Utf16CodeUnit;

        /// <summary>
        /// Gets or sets the default language to use in some client methods.
        /// This is the <see href="https://tools.ietf.org/rfc/bcp/bcp47.txt">BCP-47</see> representation of a language. For example, use "en" for English, "es" for Spanish, etc.
        /// If not set, the service default, "en" for English, is used.
        /// See <see href="https://learn.microsoft.com/azure/cognitive-services/qnamaker/overview/language-support"/> for list of currently supported languages.
        /// </summary>
        public string DefaultLanguage { get; set; } = "en";

        /// <summary>
        /// Gets or sets the Audience to use for authentication with Azure Active Directory (AAD).
        /// The audience is not considered when using a shared key.
        /// </summary>
        /// <value>If <c>null</c>, <see cref="QuestionAnsweringAudience.AzurePublicCloud" /> will be assumed.</value>
        public QuestionAnsweringAudience? Audience { get; set; }
    }
}
