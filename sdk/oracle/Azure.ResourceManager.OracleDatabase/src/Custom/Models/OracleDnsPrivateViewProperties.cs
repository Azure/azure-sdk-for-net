// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.ComponentModel;

namespace Azure.ResourceManager.OracleDatabase.Models
{
    public partial class OracleDnsPrivateViewProperties
    {
        /// <summary> Initializes a new instance of <see cref="OracleDnsPrivateViewProperties"/>. </summary>
        /// <param name="ocid"> The OCID of the view. </param>
        /// <param name="isProtected"> A Boolean flag indicating whether or not parts of the resource are unable to be explicitly managed. </param>
        /// <param name="self"> The canonical absolute URL of the resource. </param>
        /// <param name="createdOn"> views timeCreated. </param>
        /// <param name="updatedOn"> views timeCreated. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public OracleDnsPrivateViewProperties(ResourceIdentifier ocid, bool isProtected, string self, DateTimeOffset createdOn, DateTimeOffset updatedOn) : this(ocid, default, isProtected, default, self, createdOn, updatedOn)
        {
        }

        /// <summary> The OCID of the view. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier Ocid { get => new ResourceIdentifier(DnsPrivateViewOcid); }
        /// <summary> Views lifecycleState. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DnsPrivateViewsLifecycleState? LifecycleState { get; }
    }
}
