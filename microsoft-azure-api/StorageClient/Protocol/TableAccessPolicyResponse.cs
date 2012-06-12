//-----------------------------------------------------------------------
// <copyright file="TableAccessPolicyResponse.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// <summary>
//    Contains code for the TableAccessPolicyResponse class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    using System;
    using System.IO;
    using System.Xml.Linq;

    /// <summary>
    /// Parses the response XML from an operation to set the access policy for a table.
    /// </summary>
    internal class TableAccessPolicyResponse : AccessPolicyResponseBase<SharedAccessTablePolicy>
    {
        /// <summary>
        /// Initializes a new instance of the TableAccessPolicyResponse class.
        /// </summary>
        /// <param name="stream">The stream to be parsed.</param>
        internal TableAccessPolicyResponse(Stream stream)
            : base(stream)
        {
        }

        /// <summary>
        /// Parses the current element.
        /// </summary>
        /// <param name="accessPolicyElement">The shared access policy element to parse.</param>
        /// <returns>The shared access policy.</returns>
        protected override SharedAccessTablePolicy ParseElement(XElement accessPolicyElement)
        {
            SharedAccessTablePolicy accessPolicy = new SharedAccessTablePolicy();
            string sharedAccessStartTimeString = (string)accessPolicyElement.Element(Constants.Start);
            if (!string.IsNullOrEmpty(sharedAccessStartTimeString))
            {
                accessPolicy.SharedAccessStartTime = Uri.UnescapeDataString(sharedAccessStartTimeString).ToUTCTime();
            }

            string sharedAccessExpiryTimeString = (string)accessPolicyElement.Element(Constants.Expiry);
            if (!string.IsNullOrEmpty(sharedAccessExpiryTimeString))
            {
                accessPolicy.SharedAccessExpiryTime = Uri.UnescapeDataString(sharedAccessExpiryTimeString).ToUTCTime();
            }

            string permissionsString = (string)accessPolicyElement.Element(Constants.Permission);
            if (!string.IsNullOrEmpty(permissionsString))
            {
                accessPolicy.Permissions = SharedAccessTablePolicy.PermissionsFromString(permissionsString);
            }

            return accessPolicy;
        }
    }
}
