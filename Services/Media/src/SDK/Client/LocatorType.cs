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
    /// Specifies the available types locator
    /// </summary>
    public enum LocatorType
    {
        /// <summary>
        /// Specifies no locator type.
        /// </summary>
        /// <remarks>This is the default enumeration value. No valid locator will have this type.</remarks>
        None = 0,

        /// <summary>
        /// Specifies a locator type which contains a Shared Access Signature Url.
        /// </summary>
        Sas = 1,

        /// <summary>
        /// Specifies a locator type which refers to an Origin streaming endpoint.
        /// </summary>
        Origin = 2,

        /// <summary>
        /// Specifies a locator type which uses the Windows Azure CDN to stream.
        /// </summary>
        WindowsAzureCdn = 3,
    }
}
