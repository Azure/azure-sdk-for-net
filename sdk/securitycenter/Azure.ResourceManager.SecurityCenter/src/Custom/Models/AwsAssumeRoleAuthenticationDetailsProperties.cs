// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Compatibility customization: preserves Azure.ResourceManager.SecurityCenter 1.1.0 public API shape during the MPG migration.
    /// <summary>
    /// Provides a compatibility shim for the AwsAssumeRoleAuthenticationDetailsProperties class.
    /// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class AwsAssumeRoleAuthenticationDetailsProperties : AuthenticationDetailsProperties
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AwsAssumeRoleAuthenticationDetailsProperties"/> type for compatibility with the previous public API surface.
        /// </summary>
        /// <param name="awsAssumeRoleArn">The value preserved for API compatibility.</param>
        /// <param name="awsExternalId">The value preserved for API compatibility.</param>
        public AwsAssumeRoleAuthenticationDetailsProperties(string awsAssumeRoleArn, System.Guid awsExternalId) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        /// <summary>
        /// Gets or sets the AwsAssumeRoleArn value preserved from the previous public API surface.
        /// </summary>
        public string AwsAssumeRoleArn { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets or sets the AwsExternalId value preserved from the previous public API surface.
        /// </summary>
        public System.Guid AwsExternalId { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets or sets the AccountId value preserved from the previous public API surface.
        /// </summary>
        public string AccountId { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets or sets the RoleArn value preserved from the previous public API surface.
        /// </summary>
        public string RoleArn { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }
}
