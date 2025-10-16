// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Language.QuestionAnswering.Inference
{
    public partial class QuestionAnsweringClientOptions
    {
        internal static StringIndexType DefaultStringIndexType { get; } = StringIndexType.Utf16CodeUnit;

        /// <summary>
        /// Gets or sets the default language to use when none is specified.
        /// </summary>
        public string DefaultLanguage { get; set; } = "en";

        /// <summary>
        /// Gets or sets the Azure Active Directory audience for authentication when using token credentials.
        /// </summary>
        /// <remarks>If null, <see cref="QuestionAnsweringAudience.AzurePublicCloud"/> is used.</remarks>
        public QuestionAnsweringAudience? Audience { get; set; }
    }
}
