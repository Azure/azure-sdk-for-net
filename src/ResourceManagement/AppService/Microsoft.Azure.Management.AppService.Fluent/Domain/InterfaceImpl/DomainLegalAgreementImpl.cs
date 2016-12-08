// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Appservice.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    internal sealed partial class DomainLegalAgreementImpl 
    {
        string Microsoft.Azure.Management.Appservice.Fluent.IDomainLegalAgreement.Url
        {
            get
            {
                return this.Url();
            }
        }

        string Microsoft.Azure.Management.Appservice.Fluent.IDomainLegalAgreement.AgreementKey
        {
            get
            {
                return this.AgreementKey();
            }
        }

        string Microsoft.Azure.Management.Appservice.Fluent.IDomainLegalAgreement.Content
        {
            get
            {
                return this.Content();
            }
        }

        string Microsoft.Azure.Management.Appservice.Fluent.IDomainLegalAgreement.Title
        {
            get
            {
                return this.Title();
            }
        }
    }
}