// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Sql.Mocking;

namespace Azure.ResourceManager.Sql
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.Sql. </summary>
    public static partial class SqlExtensions
    {
        /// <summary>
        /// Gets an object representing a <see cref="ServiceObjectiveResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ServiceObjectiveResource.CreateResourceIdentifier" /> to create a <see cref="ServiceObjectiveResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableSqlArmClient.GetServiceObjectiveResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="ServiceObjectiveResource"/> object. </returns>
        [Obsolete("This method is deprecated and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ServiceObjectiveResource GetServiceObjectiveResource(this ArmClient client, ResourceIdentifier id)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Gets an object representing a <see cref="SqlServerCommunicationLinkResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="SqlServerCommunicationLinkResource.CreateResourceIdentifier" /> to create a <see cref="SqlServerCommunicationLinkResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableSqlArmClient.GetSqlServerCommunicationLinkResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="SqlServerCommunicationLinkResource"/> object. </returns>
        [Obsolete("This method is deprecated and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SqlServerCommunicationLinkResource GetSqlServerCommunicationLinkResource(this ArmClient client, ResourceIdentifier id)
        {
            throw new NotSupportedException();
        }
    }
}
