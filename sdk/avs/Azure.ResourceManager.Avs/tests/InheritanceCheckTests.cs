// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.TestFramework
{
    /// <summary>
    /// Partial class extension for AVS SDK inheritance check tests.
    /// </summary>
    public partial class InheritanceCheckTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InheritanceCheckTests"/> class.
        /// </summary>
        public InheritanceCheckTests()
        {
            // ImpactedMaintenanceResource is a model class in the Models namespace,
            // not an ARM resource. It ends with "Resource" but doesn't inherit from ArmResource
            ExceptionList = new[] { "ImpactedMaintenanceResource" };
        }
    }
}
