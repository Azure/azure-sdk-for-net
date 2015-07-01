﻿//
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

namespace Microsoft.Azure.Management.DataFactories.Registration.Models
{
    /// <summary>
    /// Parameters specifying the ActivityType raw json definition for a create or
    /// update operation.
    /// </summary>
    public class ActivityTypeCreateOrUpdateWithRawJsonContentParameters
    {
        /// <summary>
        /// Required. The raw json content for a create or update ActivityType operation.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Initializes a new instance of the
        /// ActivityTypeCreateOrUpdateWithRawJsonContentParameters class.
        /// </summary>
        public ActivityTypeCreateOrUpdateWithRawJsonContentParameters()
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// ActivityTypeCreateOrUpdateWithRawJsonContentParameters class with required
        /// arguments.
        /// </summary>
        public ActivityTypeCreateOrUpdateWithRawJsonContentParameters(string content)
            : this()
        {
            Ensure.IsNotNullOrEmpty(content, "content");
            this.Content = content;
        }

        internal ActivityTypeCreateOrUpdateWithRawJsonContentParameters(
            Core.Registration.Models.ActivityTypeCreateOrUpdateWithRawJsonContentParameters internalParameters)
            : this()
        {
            Ensure.IsNotNull(internalParameters, "internalParameters");
            Ensure.IsNotNullOrEmpty(internalParameters.Content, "internalParameters.Content");

            this.Content = internalParameters.Content;
        }
    }
}
