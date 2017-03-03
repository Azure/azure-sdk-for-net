// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Batch
{
    /// <summary>
    /// Tools and utilities for the Azure Batch Service.
    /// </summary>
    public class Utilities : IInheritedBehaviors
    {
#region constructors
    
        private Utilities()
        {
        }
        
        internal Utilities(BatchClient parentBatchClient, IEnumerable<BatchClientBehavior> baseBehaviors)
        {
            this.ParentBatchClient = parentBatchClient;

            // inherit the base behaviors
            InheritUtil.InheritClientBehaviorsAndSetPublicProperty(this, baseBehaviors);
        }

#endregion constructors

#region IInheritedBehaviors

        /// <summary>
        /// Gets or sets a list of behaviors that modify or customize requests to the Batch service
        /// made via this <see cref="Utilities"/>.
        /// </summary>
        /// <remarks>
        /// <para>These behaviors are inherited by child objects.</para>
        /// <para>Modifications are applied in the order of the collection. The last write wins.</para>
        /// </remarks>
        public IList<BatchClientBehavior> CustomBehaviors { get; set; }

#endregion IInheritedBehaviors

#region Utilities

        /// <summary>
        /// Creates an TaskStateMonitor.
        /// </summary>
        /// <returns>A <see cref="TaskStateMonitor"/> instance.</returns>
        public TaskStateMonitor CreateTaskStateMonitor()
        {
            TaskStateMonitor tsm = new TaskStateMonitor(this, this.CustomBehaviors);

            return tsm;
        }
        
#endregion Utilities

#region internal/private

        internal BatchClient ParentBatchClient { get; set; }

#endregion internal/private

    }
}
