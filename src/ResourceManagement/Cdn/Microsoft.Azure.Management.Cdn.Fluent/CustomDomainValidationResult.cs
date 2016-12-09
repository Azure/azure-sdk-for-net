// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Management.Cdn.Fluent.Models;

namespace Microsoft.Azure.Management.Cdn.Fluent
{
    /// <summary>
    /// The com.microsoft.azure.management.cdn.CdnProfile.validateEndpointCustomDomain(String, String) action result.
    /// </summary>
    public class CustomDomainValidationResult 
    {
        private ValidateCustomDomainOutputInner inner;
        /// <summary>
        /// Get the customDomainValidated value.
        /// </summary>
        /// <return>The customDomainValidated value.</return>
        public bool CustomDomainValidated
        {
            get
            {
                return (this.inner.CustomDomainValidated.HasValue) ? 
                    this.inner.CustomDomainValidated.Value : false;
            }
        }

        /// <summary>
        /// Get the reason value.
        /// </summary>
        /// <return>The reason value.</return>
        public string Reason
        {
            get
            {
                return this.inner.Reason;
            }
        }

        /// <summary>
        /// Construct CustomDomainValidationResult object from server response object.
        /// </summary>
        /// <param name="inner">Server response for CustomDomainValidation request.</param>
        public CustomDomainValidationResult(ValidateCustomDomainOutputInner inner)
        {
            this.inner = inner;
        }

        /// <summary>
        /// Get the message value.
        /// </summary>
        /// <return>The message value.</return>
        public string Message
        {
            get
            {
                return this.inner.Message;
            }
        }
    }
}