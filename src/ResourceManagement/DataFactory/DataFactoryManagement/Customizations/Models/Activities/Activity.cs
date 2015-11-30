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
using Microsoft.Azure.Management.DataFactories.Common.Models;

namespace Microsoft.Azure.Management.DataFactories.Models
{
    /// <summary>
    /// A pipeline activity.
    /// </summary>
    public class Activity : AdfResourceProperties<ActivityTypeProperties, GenericActivity>
    {
        /// <summary>
        /// Activity name.
        /// </summary>
        [AdfRequired]
        public string Name { get; set; }

        /// <summary>
        /// Activity description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Name of the linked service where the Activity runs. 
        /// </summary>
        public string LinkedServiceName { get; set; }

        /// <summary>
        /// Activity policy.
        /// </summary>
        public ActivityPolicy Policy { get; set; }

        /// <summary>
        /// Activity inputs.
        /// </summary>
        public IList<ActivityInput> Inputs { get; set; }

        /// <summary>
        /// Activity outputs.
        /// </summary>
        public IList<ActivityOutput> Outputs { get; set; }

        /// <summary>
        /// Optional. Scheduler of the activity.
        /// </summary>
        public Scheduler Scheduler { get; set;  }

        public Activity()
        {
            this.Initialize();
        }

        public Activity(ActivityTypeProperties typeProperties)
            : base(typeProperties)
        {
            this.Initialize();
        }

        public Activity(GenericActivity typeProperties, string typeName)
            : base(typeProperties, typeName)
        {
            this.Initialize();
        }

        internal Activity(ActivityTypeProperties typeProperties, string typeName = null)
            : base(typeProperties, typeName)
        {
            this.Initialize();
        }

        private void Initialize()
        {
            this.Inputs = new List<ActivityInput>();
            this.Outputs = new List<ActivityOutput>();
        }
    }
}
