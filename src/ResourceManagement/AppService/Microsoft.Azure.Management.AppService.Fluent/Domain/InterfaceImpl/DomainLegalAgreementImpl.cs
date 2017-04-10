// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    internal sealed partial class DomainLegalAgreementImpl 
    {
        /// <summary>
        /// Gets url where a copy of the agreement details is hosted.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IDomainLegalAgreement.Url
        {
            get
            {
                return this.Url();
            }
        }

        /// <summary>
        /// Gets unique identifier for the agreement.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IDomainLegalAgreement.AgreementKey
        {
            get
            {
                return this.AgreementKey();
            }
        }

        /// <summary>
        /// Gets agreement details.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IDomainLegalAgreement.Content
        {
            get
            {
                return this.Content();
            }
        }

        /// <summary>
        /// Gets agreement title.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IDomainLegalAgreement.Title
        {
            get
            {
                return this.Title();
            }
        }
    }
}