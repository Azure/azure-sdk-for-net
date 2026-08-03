// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager.SecurityCenter.Models;

namespace Azure.ResourceManager.SecurityCenter
{
    // Generated code only emits operations whose resource scope and request path still exist in TypeSpec; this previous GA method used an old operation path, scope, or overload that no longer maps to a generated request. Keep a hidden ApiCompat shim and fail the unsupported operation explicitly.
    public partial class SecurityAssessmentResource
    {
        /// <summary> Get a security assessment on your scanned resource. </summary>
        public virtual Task<Response<SecurityAssessmentResource>> GetAsync(SecurityAssessmentODataExpand? expand = default, CancellationToken cancellationToken = default)
            => new SecurityAssessmentCollection(Client, Id.Parent).GetAsync(Id.Name, expand, cancellationToken);

        /// <summary> Get a security assessment on your scanned resource. </summary>
        public virtual Response<SecurityAssessmentResource> Get(SecurityAssessmentODataExpand? expand = default, CancellationToken cancellationToken = default)
            => new SecurityAssessmentCollection(Client, Id.Parent).Get(Id.Name, expand, cancellationToken);

        /// <summary> Update a SecurityAssessment. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<SecurityAssessmentResource>> UpdateAsync(WaitUntil waitUntil, SecurityAssessmentCreateOrUpdateContent assessment, CancellationToken cancellationToken = default)
            => throw new System.NotSupportedException("This API is no longer supported by the service. No direct replacement is available.");

        /// <summary> Update a SecurityAssessment. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<SecurityAssessmentResource> Update(WaitUntil waitUntil, SecurityAssessmentCreateOrUpdateContent assessment, CancellationToken cancellationToken = default)
            => throw new System.NotSupportedException("This API is no longer supported by the service. No direct replacement is available.");
    }
}
