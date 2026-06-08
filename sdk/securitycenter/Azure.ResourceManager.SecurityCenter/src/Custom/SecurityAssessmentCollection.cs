// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager.SecurityCenter.Models;

namespace Azure.ResourceManager.SecurityCenter
{
    public partial class SecurityAssessmentCollection
    {
        /// <summary> Create a security assessment on your resource. </summary>
        public virtual Task<ArmOperation<SecurityAssessmentResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string assessmentName, SecurityAssessmentCreateOrUpdateContent assessment, CancellationToken cancellationToken = default)
            => CreateOrUpdateAsync(waitUntil, assessmentName, (SecurityAssessmentGenerated)assessment, cancellationToken);

        /// <summary> Create a security assessment on your resource. </summary>
        public virtual ArmOperation<SecurityAssessmentResource> CreateOrUpdate(WaitUntil waitUntil, string assessmentName, SecurityAssessmentCreateOrUpdateContent assessment, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, assessmentName, (SecurityAssessmentGenerated)assessment, cancellationToken);

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
