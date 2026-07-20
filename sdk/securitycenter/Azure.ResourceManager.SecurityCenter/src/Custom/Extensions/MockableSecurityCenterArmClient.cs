// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.SecurityCenter.Models;

namespace Azure.ResourceManager.SecurityCenter.Mocking
{
    public partial class MockableSecurityCenterArmClient
    {
        /// <summary> Get a security assessment on your scanned resource. </summary>
        /// <remarks>
        /// Compatibility overload for the GA API shape, which exposed a direct get method on the mockable extension client.
        /// The generated TypeSpec API exposes the operation through the scoped SecurityAssessment collection.
        /// </remarks>
        public virtual Response<SecurityAssessmentResource> GetSecurityAssessment(ResourceIdentifier scope, string assessmentName, SecurityAssessmentODataExpand? expand = default, CancellationToken cancellationToken = default)
            => GetSecurityAssessments(scope).Get(assessmentName, expand, cancellationToken);

        /// <summary> Get a security assessment on your scanned resource. </summary>
        /// <remarks>
        /// Compatibility overload for the GA API shape, which exposed a direct get method on the mockable extension client.
        /// The generated TypeSpec API exposes the operation through the scoped SecurityAssessment collection.
        /// </remarks>
        public virtual Task<Response<SecurityAssessmentResource>> GetSecurityAssessmentAsync(ResourceIdentifier scope, string assessmentName, SecurityAssessmentODataExpand? expand = default, CancellationToken cancellationToken = default)
            => GetSecurityAssessments(scope).GetAsync(assessmentName, expand, cancellationToken);
    }
}
