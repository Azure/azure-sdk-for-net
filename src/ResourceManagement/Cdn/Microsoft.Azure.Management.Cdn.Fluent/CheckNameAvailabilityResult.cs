// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Management.Cdn.Fluent.Models;

namespace Microsoft.Azure.Management.Cdn.Fluent
{
    /// <summary>
    /// Result of the custom domain validation.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNkbi5DaGVja05hbWVBdmFpbGFiaWxpdHlSZXN1bHQ=
    public class CheckNameAvailabilityResult 
    {
        private CheckNameAvailabilityOutputInner inner;
        /// <summary>
        /// Get the reason value.
        /// </summary>
        /// <return>The reason value.</return>

        ///GENMHASH:5D3E8FC383AE40AAD3262C598E63D4A1:BE83F39AD4B1EBEEF700E7A538565BBC
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

        ///GENMHASH:E75FA496943895CE09994FE393A6DEBF:B8DDB4AB3E2E846B3FEEEE35153D2599
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
        ///GENMHASH:E71ACFFD67FE0B74DBA80A4283F03C63:BC4B1282CA708DC220050F834F17A184
        public CheckNameAvailabilityResult(CheckNameAvailabilityOutputInner inner)
        {
            this.inner = inner;
        }

        /// <summary>
        /// Get the message value.
        /// </summary>
        /// <return>The message value.</return>

        ///GENMHASH:E703019D95A4EEA3549CBD7305C71A96:F1468984A8145CAD5144260CCBB8C51C
        public string Message
        {
            get
            {
                return this.inner.Message;
            }
        }
    }
}
