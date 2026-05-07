// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery.Models
{
    // Back-compat: AutoRest baseline exposed a public ctor taking the nested Properties
    // wrapper. The MTG generator flattens the single-property wrapper and emits only a
    // parameterless public ctor plus an internal ctor. Restore the public ctor that
    // accepts the Properties wrapper by forwarding to the internal ctor.
    public partial class TestFailoverCleanupContent
    {
        /// <summary> Initializes a new instance of <see cref="TestFailoverCleanupContent"/>. </summary>
        /// <param name="properties"> Test failover cleanup input properties. </param>
        public TestFailoverCleanupContent(TestFailoverCleanupProperties properties) : this(properties, additionalBinaryDataProperties: null)
        {
        }
    }
}
