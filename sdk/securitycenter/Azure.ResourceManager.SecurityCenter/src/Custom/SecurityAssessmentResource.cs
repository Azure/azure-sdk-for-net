// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager.SecurityCenter.Models;

namespace Azure.ResourceManager.SecurityCenter
{
    // The latest TypeSpec removed this legacy resource or operation path, so the generator cannot emit the previous GA management-plane method; keep a hidden shim for ApiCompat and throw because the service path is no longer supported.
    public partial class SecurityAssessmentResource
    {
        /// <summary> Get a security assessment on your scanned resource. </summary>
        public virtual Task<Response<SecurityAssessmentResource>> GetAsync(SecurityAssessmentODataExpand? expand = default, CancellationToken cancellationToken = default)
            => GetAsync(expand.HasValue ? new ExpandEnum(expand.Value.ToString()) : null, cancellationToken);

        /// <summary> Get a security assessment on your scanned resource. </summary>
        public virtual Response<SecurityAssessmentResource> Get(SecurityAssessmentODataExpand? expand = default, CancellationToken cancellationToken = default)
            => Get(expand.HasValue ? new ExpandEnum(expand.Value.ToString()) : null, cancellationToken);

        /// <summary> Update a SecurityAssessment. </summary>
        public virtual Task<ArmOperation<SecurityAssessmentResource>> UpdateAsync(WaitUntil waitUntil, SecurityAssessmentCreateOrUpdateContent assessment, CancellationToken cancellationToken = default)
            => throw new System.NotSupportedException("This API is no longer supported by the service.");

        /// <summary> Update a SecurityAssessment. </summary>
        public virtual ArmOperation<SecurityAssessmentResource> Update(WaitUntil waitUntil, SecurityAssessmentCreateOrUpdateContent assessment, CancellationToken cancellationToken = default)
            => throw new System.NotSupportedException("This API is no longer supported by the service.");
    }
}
