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

namespace Microsoft.Azure.Management.DataFactories.Models
{
    /// <summary>
    /// Compilation mode for a U-SQL activity.
    /// </summary>
    public static class USqlCompilationMode
    {
        /// <summary>
        /// Only perform semantic checks and necessary sanity checks.
        /// </summary>
        public const string Semantic = "Semantic";

        /// <summary>
        /// Perform the full compilation, including syntax check, optimization, code-gen, etc.
        /// </summary>
        public const string Full = "Full";

        /// <summary>
        /// Perform the full compilation, with TargetType setting to SingleBox.
        /// </summary>
        public const string SingleBox = "SingleBox";
    }
}