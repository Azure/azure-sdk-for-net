// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Appservice.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of an Azure domain legal agreement.
    /// </summary>
    public interface IDomainLegalAgreement  :
        IWrapper<Microsoft.Azure.Management.AppService.Fluent.Models.TldLegalAgreementInner>
    {
        string Content { get; }

        string Title { get; }

        string AgreementKey { get; }

        string Url { get; }
    }
}