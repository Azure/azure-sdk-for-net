// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of an Azure domain legal agreement.
    /// </summary>
    public interface IDomainLegalAgreement  :
        IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.TldLegalAgreement>
    {
        /// <summary>
        /// Gets agreement details.
        /// </summary>
        string Content { get; }

        /// <summary>
        /// Gets agreement title.
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Gets unique identifier for the agreement.
        /// </summary>
        string AgreementKey { get; }

        /// <summary>
        /// Gets url where a copy of the agreement details is hosted.
        /// </summary>
        string Url { get; }
    }
}