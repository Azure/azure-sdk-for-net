// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Management.Cdn.Fluent.Models;

namespace Microsoft.Azure.Management.Cdn.Fluent
{
    /// <summary>
    /// The com.microsoft.azure.management.cdn.CdnProfile.validateEndpointCustomDomain(String, String) action result.
    /// </summary>
	///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNkbi5DdXN0b21Eb21haW5WYWxpZGF0aW9uUmVzdWx0
    public class CustomDomainValidationResult 
    {
        private ValidateCustomDomainOutputInner inner;
        /// <summary>
        /// Get the customDomainValidated value.
        /// </summary>
        /// <return>The customDomainValidated value.</return>
        ///GENMHASH:DCDCCF331123C9FA7F59C3DA26E523BE:7CFE91E5DFC0E30107C37504735BE658
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
        ///GENMHASH:5D3E8FC383AE40AAD3262C598E63D4A1:BE83F39AD4B1EBEEF700E7A538565BBC
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
        ///GENMHASH:13205F709CF5952E9BEB6E9ACB37F499:BC4B1282CA708DC220050F834F17A184
        public  CustomDomainValidationResult(ValidateCustomDomainOutputInner inner)
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