// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Language.QuestionAnswering.Authoring
{
    /// <summary>
    /// Hand-authored extensions for <see cref="QuestionAnsweringAuthoringClientOptions"/>.
    /// </summary>
    public partial class QuestionAnsweringAuthoringClientOptions
    {
        /// <summary>
        /// Gets or sets the audience to use for authenticating with Azure Active Directory when using a <see cref="Azure.Core.TokenCredential"/>.
        /// </summary>
        /// <value>If <c>null</c>, <see cref="QuestionAnsweringAuthoringAudience.AzurePublicCloud"/> will be used.</value>
        public QuestionAnsweringAuthoringAudience? Audience { get; set; }
    }
}
