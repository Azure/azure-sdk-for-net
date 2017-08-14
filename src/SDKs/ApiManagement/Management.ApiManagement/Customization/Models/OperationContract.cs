// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.ApiManagement.Models
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Subscription details.
    /// </summary>
    public partial class OperationContract
    {
        private static readonly Regex OperationIdPathRegex = new Regex(@"/subscriptions/(?<subName>.+)/resourceGroups/(?<rgName>.+)/providers/Microsoft.ApiManagement/service/(?<serviceName>.+)/apis/(?<aid>.+)/operations/(?<oid>.+)");

        public string ApiIdentifier
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(this.Id))
                {
                    var match = OperationIdPathRegex.Match(this.Id);
                    if (match.Success)
                    {
                        var aidGroup = match.Groups["aid"];
                        if (aidGroup != null && aidGroup.Success)
                        {
                            return aidGroup.Value;
                        }
                    }
                }

                return this.Id;
            }
        }
    }
}
