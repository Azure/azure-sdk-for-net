// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Mocking
{
    public partial class MockablePostgreSqlFlexibleServersArmClient : ArmResource
    {
        /// <summary>
        /// Gets an object representing a <see cref="PostgreSqlFlexibleServerActiveDirectoryAdministratorResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="PostgreSqlFlexibleServerActiveDirectoryAdministratorResource.CreateResourceIdentifier" /> to create a <see cref="PostgreSqlFlexibleServerActiveDirectoryAdministratorResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="PostgreSqlFlexibleServerActiveDirectoryAdministratorResource"/> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated. Please use the new 'GetPostgreSqlFlexibleServerMicrosoftEntraAdministratorResource' instead.")]
        public virtual PostgreSqlFlexibleServerActiveDirectoryAdministratorResource GetPostgreSqlFlexibleServerActiveDirectoryAdministratorResource(ResourceIdentifier id)
        {
            throw new NotSupportedException("PostgreSqlFlexibleServerActiveDirectoryAdministratorResource is not supported any more. Please use the new 'GetPostgreSqlFlexibleServerMicrosoftEntraAdministratorResource' instead.");
        }
    }
}
