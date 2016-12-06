// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Management.Cdn.Fluent.Models;

namespace Microsoft.Azure.Management.Cdn.Fluent
{
    /// <summary>
    /// Result of the custom domain validation.
    /// </summary>
    public partial class CheckNameAvailabilityResult 
    {
        private CheckNameAvailabilityOutputInner inner;
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
        /// Indicates whether the name is available.
        /// </summary>
        /// <return>The nameAvailable value.</return>
        public bool NameAvailable
        {
            get
            {
                return (this.inner.NameAvailable.HasValue) ?
                    this.inner.NameAvailable.Value : false;
            }
        }

        /// <summary>
        /// Construct CheckNameAvailabilityResult object from server response object.
        /// </summary>
        /// <param name="inner">Server response for CheckNameAvailability request.</param>
        public  CheckNameAvailabilityResult(CheckNameAvailabilityOutputInner inner)
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