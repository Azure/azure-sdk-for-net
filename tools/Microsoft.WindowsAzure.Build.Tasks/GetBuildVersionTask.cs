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

using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System;

namespace Microsoft.WindowsAzure.Build.Tasks
{
    /// <summary>
    /// A Microsoft Build task that is used for generated a build string to use
    /// for Microsoft Azure SDK open source builds.
    /// </summary>
    public class GetBuildVersionTask : Task
    {
        /// <summary>
        /// Gets or sets a string representing the versioned date string to use
        /// for a build.
        /// </summary>
        [Output]
        public string Date { get; set; }

        /// <summary>
        /// Generate a string representing a build number for the current
        /// Microsoft Azure open source build.
        /// </summary>
        /// <returns>Returns true. Hopefully.</returns>
        public override bool Execute()
        {
            try
            {
                // Rooting at 2013 for Microsoft Azure Libraries
                const int rootYear = 2013;

                DateTime now = DateTime.Now;
                Date = (now.Year - rootYear + 1).ToString() + now.ToString("MMdd");

                return true;
            }
            catch (Exception ex)
            {
                Log.LogErrorFromException(ex);
                return false;
            }
        }
    }
}
