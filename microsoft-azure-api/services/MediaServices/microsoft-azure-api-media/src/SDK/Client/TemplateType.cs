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

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    /// <summary>
    /// Describes the types of job templates based on the accessiblity level.
    /// </summary>
    public enum TemplateType
    {
        /// <summary>
        /// Templates that can be used by everyone.
        /// </summary>
        SystemLevel,

        /// <summary>
        /// Templates that can only be used by the account that created the template.
        /// </summary>
        AccountLevel
    }
}
