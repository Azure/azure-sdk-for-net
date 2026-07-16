// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Automation
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.Automation. </summary>
    public static partial class AutomationExtensions
    {
        /// <summary>
        /// Gets an object representing a <see cref="DscCompilationJobResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="DscCompilationJobResource.CreateResourceIdentifier" /> to create a <see cref="DscCompilationJobResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="Mocking.MockableAutomationArmClient.GetDscCompilationJobResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="DscCompilationJobResource"/> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public static DscCompilationJobResource GetDscCompilationJobResource(this ArmClient client, ResourceIdentifier id)
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }
    }
}
