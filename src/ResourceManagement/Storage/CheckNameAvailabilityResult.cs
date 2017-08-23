// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Microsoft.Azure.Management.Storage.Fluent.Models;

    /// <summary>
    /// The  com.microsoft.azure.management.storage.StorageAccounts.checkNameAvailability action result.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnN0b3JhZ2UuQ2hlY2tOYW1lQXZhaWxhYmlsaXR5UmVzdWx0
    public class CheckNameAvailabilityResult
    {
        private readonly CheckNameAvailabilityResultInner inner;

        /// <summary>
        /// Creates an instance of the check name availability result object.
        /// </summary>
        /// <param name="inner">The inner object.</param>
        ///GENMHASH:FB9080CE19E6D0BBB260F491A92C9EFF:BC4B1282CA708DC220050F834F17A184
        internal CheckNameAvailabilityResult(CheckNameAvailabilityResultInner inner)
        {
            this.inner = inner;
        }

        /// <return>
        /// A boolean value that indicates whether the name is available for
        /// you to use. If true, the name is available. If false, the name has
        /// already been taken or invalid and cannot be used.
        /// </return>
        ///GENMHASH:ECE9AA3B22E6D72ED037B235766E650D:4F919944D8D2F904C2402C730D63DA07
        [Obsolete("Please use IsAvailable instead")]
        public bool? IsAvailalbe
        {
            get
            {
                return IsAvailable;
            }
        }

        /// <return>
        /// A boolean value that indicates whether the name is available for
        /// you to use. If true, the name is available. If false, the name has
        /// already been taken or invalid and cannot be used.
        /// </return>
        ///GENMHASH:ECE9AA3B22E6D72ED037B235766E650D:4F919944D8D2F904C2402C730D63DA07
        public bool? IsAvailable
        {
            get
            {
                return inner.NameAvailable;
            }
        }

        /// <return>
        /// The reason that a storage account name could not be used. The
        /// Reason element is only returned if NameAvailable is false. Possible
        /// values include: 'AccountNameInvalid', 'AlreadyExists'.
        /// </return>
        ///GENMHASH:5D3E8FC383AE40AAD3262C598E63D4A1:BD5DB7E717551C6018CC88BC94827E00
        public Reason? Reason
        {
            get
            {
                return inner.Reason;
            }
        }

        /// <return>An error message explaining the Reason value in more detail.</return>
        ///GENMHASH:E703019D95A4EEA3549CBD7305C71A96:340D0580E29C483CD3A1D98F49B79FD7
        public string Message
        {
            get
            {
                return inner.Message;
            }
        }
    }
}