// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Appservice.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// A domain contact definition.
    /// </summary>
    public interface IDomainContact  :
        IWrapper<Microsoft.Azure.Management.AppService.Fluent.Models.Contact>,
        IChildResource<Microsoft.Azure.Management.Appservice.Fluent.IAppServiceDomain>
    {
        string MiddleName { get; }

        string LastName { get; }

        string Phone { get; }

        string Organization { get; }

        string Fax { get; }

        string Email { get; }

        string FirstName { get; }

        string JobTitle { get; }

        Microsoft.Azure.Management.AppService.Fluent.Models.Address AddressMailing { get; }
    }
}