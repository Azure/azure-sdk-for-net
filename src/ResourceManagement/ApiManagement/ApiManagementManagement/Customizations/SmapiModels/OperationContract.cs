//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
namespace Microsoft.Azure.Management.ApiManagement.SmapiModels
{
    using System.Text.RegularExpressions;

    public partial class OperationContract
    {
        private static readonly Regex OperationIdPathRegex = new Regex(@"/apis/(?<aid>.+)/operations/(?<oid>.+)");

        public string ApiId
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(OperationIdPath))
                {
                    var match = OperationIdPathRegex.Match(OperationIdPath);
                    if (match.Success)
                    {
                        var aidGroup = match.Groups["aid"];
                        if (aidGroup != null && aidGroup.Success)
                        {
                            return aidGroup.Value;
                        }
                    }
                }

                return OperationIdPath;
            }
        }

        public string OperationId
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(OperationIdPath))
                {
                    var match = OperationIdPathRegex.Match(OperationIdPath);
                    if (match.Success)
                    {
                        var oidGroup = match.Groups["oid"];
                        if (oidGroup != null && oidGroup.Success)
                        {
                            return oidGroup.Value;
                        }
                    }
                }

                return OperationIdPath;
            }
        }
    }
}