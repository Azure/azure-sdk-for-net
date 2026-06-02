// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.ComputeBulkActions.Mocking;

namespace Azure.ResourceManager.ComputeBulkActions
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.ComputeBulkActions. </summary>
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetBulkActionResource", typeof(ArmClient), typeof(ResourceIdentifier))]
    public static partial class ComputeBulkActionsExtensions
    {
        /// <summary>
        /// Gets an object representing a <see cref="BulkActionResource"/> along with the instance operations that can be performed on it but with no data.
        /// </summary>
        /// <remarks>
        /// <list type="table">
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableComputeBulkActionsArmClient.GetBulkActionResource(ResourceIdentifier)"/> instead. </description>
        /// </item>
        /// </list>
        /// </remarks>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="BulkActionResource"/> object. </returns>
        public static BulkActionResource GetBulkActionResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableComputeBulkActionsArmClient(client).GetBulkActionResource(id);
        }
    }
}
