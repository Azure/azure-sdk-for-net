// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// A domain contact definition.
    /// </summary>
    public interface IDomainContact  :
        IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.Contact>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IChildResource<Microsoft.Azure.Management.AppService.Fluent.IAppServiceDomain>
    {
        /// <summary>
        /// Gets contact's middle name.
        /// </summary>
        string MiddleName { get; }

        /// <summary>
        /// Gets contact's last name.
        /// </summary>
        string LastName { get; }

        /// <summary>
        /// Gets contact's phone number.
        /// </summary>
        string Phone { get; }

        /// <summary>
        /// Gets contact's organization.
        /// </summary>
        string Organization { get; }

        /// <summary>
        /// Gets contact's fax number.
        /// </summary>
        string Fax { get; }

        /// <summary>
        /// Gets contact's email address.
        /// </summary>
        string Email { get; }

        /// <summary>
        /// Gets contact's first name.
        /// </summary>
        string FirstName { get; }

        /// <summary>
        /// Gets contact's job title.
        /// </summary>
        string JobTitle { get; }

        /// <summary>
        /// Gets contact's mailing address.
        /// </summary>
        Models.Address AddressMailing { get; }
    }
}