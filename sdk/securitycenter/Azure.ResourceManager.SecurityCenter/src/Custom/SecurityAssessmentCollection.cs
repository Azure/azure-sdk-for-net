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
    public partial class SecurityAssessmentCollection
    {
        /// <summary> Create a security assessment on your resource. </summary>
        public virtual Task<ArmOperation<SecurityAssessmentResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string assessmentName, SecurityAssessmentCreateOrUpdateContent assessment, CancellationToken cancellationToken = default)
            => throw new System.NotSupportedException("This API is no longer supported by the service.");

        /// <summary> Create a security assessment on your resource. </summary>
        public virtual ArmOperation<SecurityAssessmentResource> CreateOrUpdate(WaitUntil waitUntil, string assessmentName, SecurityAssessmentCreateOrUpdateContent assessment, CancellationToken cancellationToken = default)
            => throw new System.NotSupportedException("This API is no longer supported by the service.");

        /// <summary> Get a security assessment on your scanned resource. </summary>
        public virtual Task<Response<SecurityAssessmentResource>> GetAsync(string assessmentName, SecurityAssessmentODataExpand? expand = default, CancellationToken cancellationToken = default)
            => GetAsync(assessmentName, expand.HasValue ? new ExpandEnum(expand.Value.ToString()) : null, cancellationToken);

        /// <summary> Get a security assessment on your scanned resource. </summary>
        public virtual Response<SecurityAssessmentResource> Get(string assessmentName, SecurityAssessmentODataExpand? expand = default, CancellationToken cancellationToken = default)
            => Get(assessmentName, expand.HasValue ? new ExpandEnum(expand.Value.ToString()) : null, cancellationToken);

        /// <summary> Check if a security assessment exists. </summary>
        public virtual Task<Response<bool>> ExistsAsync(string assessmentName, SecurityAssessmentODataExpand? expand = default, CancellationToken cancellationToken = default)
            => ExistsAsync(assessmentName, expand.HasValue ? new ExpandEnum(expand.Value.ToString()) : null, cancellationToken);

        /// <summary> Check if a security assessment exists. </summary>
        public virtual Response<bool> Exists(string assessmentName, SecurityAssessmentODataExpand? expand = default, CancellationToken cancellationToken = default)
            => Exists(assessmentName, expand.HasValue ? new ExpandEnum(expand.Value.ToString()) : null, cancellationToken);
    }
}
