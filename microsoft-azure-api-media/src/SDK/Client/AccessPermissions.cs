// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    /// <summary>
    /// Specifies the permissions that an <see cref="IAccessPolicy"/> may grant.
    /// </summary>
    /// <remarks>This is a flags enum.</remarks>
    [Flags]
    public enum AccessPermissions
    {
        /// <summary>
        /// Specifies no AccessPermissions
        /// </summary>
        /// <remarks>This is the default value.</remarks>
        None = 0,
        /// <summary>
        /// Specifies reading content should be allowed.
        /// </summary>
        Read = 1,
        /// <summary>
        /// Specifies the writing of content should be allowed.
        /// </summary>
        Write = 2,
        /// <summary>
        /// Specifies deletes should be allowed.
        /// </summary>
        Delete = 4,
        /// <summary>
        /// Specifies listing of children should be allowed.
        /// </summary>
        List = 8,
    }
}
