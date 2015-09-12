//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System.Collections.Generic;

namespace Microsoft.Azure.Management.DataFactories.Models
{
    /// <summary>
    /// .NET activity.
    /// </summary>
    public class DotNetActivity : ActivityTypeProperties
    {
        /// <summary>
        /// Assembly name.
        /// </summary>
        [AdfRequired]
        public string AssemblyName { get; set; }

        /// <summary>
        /// Entry point.
        /// </summary>
        [AdfRequired]
        public string EntryPoint { get; set; }

        /// <summary>
        /// Package linked service. 
        /// </summary>
        public string PackageLinkedService { get; set; }

        /// <summary>
        /// Package file.
        /// </summary>
        [AdfRequired]
        public string PackageFile { get; set; }

        /// <summary>
        /// User defined property bag. There is no restriction on the keys or values
        /// that can be used. The user specified .NET activity has the full responsibility
        /// to consume and interpret the content defined.
        /// </summary>
        public IDictionary<string, string> ExtendedProperties { get; set; }

        public DotNetActivity()
        {
        }

        public DotNetActivity(
            string assemblyName, 
            string entryPoint, 
            string packageFile,
            string packageLinkedService = null)
            : this()
        {
            Ensure.IsNotNullOrEmpty(assemblyName, "assemblyName");
            Ensure.IsNotNullOrEmpty(entryPoint, "entryPoint");
            Ensure.IsNotNullOrEmpty(packageFile, "packageFile");

            this.AssemblyName = assemblyName;
            this.EntryPoint = entryPoint;
            this.PackageFile = packageFile;
            this.PackageLinkedService = packageLinkedService;
        }
    }
}
