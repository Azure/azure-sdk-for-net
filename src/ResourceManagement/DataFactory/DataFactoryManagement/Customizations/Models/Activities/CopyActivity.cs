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
    /// Copy activity.
    /// </summary>
    [AdfTypeName("Copy")]
    public class CopyActivity : ActivityTypeProperties
    {
        /// <summary>
        /// Copy activity source.
        /// </summary>
        [AdfRequired]
        public CopySource Source { get; set; }

        /// <summary>
        /// Copy activity sink.
        /// </summary>
        [AdfRequired]
        public CopySink Sink { get; set; }

        /// <summary>
        /// Copy activity translator. If not specified, tabular translator is used.
        /// </summary>
        public CopyTranslator Translator { get; set; }

        public CopyActivity()
        {
        }

        public CopyActivity(CopySource source, CopySink sink, CopyTranslator translator = null)
            : this()
        {
            Ensure.IsNotNull(source, "source");
            Ensure.IsNotNull(sink, "sink");

            this.Source = source;
            this.Sink = sink;
            this.Translator = translator;
        }
    }
}
