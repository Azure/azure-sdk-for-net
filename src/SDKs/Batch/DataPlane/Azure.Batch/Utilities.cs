// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
