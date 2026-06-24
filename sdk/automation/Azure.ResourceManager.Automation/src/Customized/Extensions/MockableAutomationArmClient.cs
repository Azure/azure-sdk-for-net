// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Automation;

namespace Azure.ResourceManager.Automation.Mocking
{
    /// <summary> A class to add extension methods to ArmClient. </summary>
    public partial class MockableAutomationArmClient
    {
        /// <summary>
        /// Gets an object representing a <see cref="DscCompilationJobResource"/> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="DscCompilationJobResource.CreateResourceIdentifier" /> to create a <see cref="DscCompilationJobResource"/> <see cref="ResourceIdentifier"/> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="DscCompilationJobResource"/> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(DscCompilationJobCompatibilityHelpers.ObsoleteMessage)]
        public virtual DscCompilationJobResource GetDscCompilationJobResource(ResourceIdentifier id)
        {
            throw DscCompilationJobCompatibilityHelpers.CreateException();
        }
    }
}
