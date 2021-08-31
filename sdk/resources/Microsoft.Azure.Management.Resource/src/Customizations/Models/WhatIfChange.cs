namespace Microsoft.Azure.Management.ResourceManager.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Information about a single resource change predicted by What-If
    /// operation.
    /// </summary>
    public partial class WhatIfChange
    {
        /// <summary>
        /// Initializes a new instance of the WhatIfChange class.
        /// </summary>
        /// <param name="resourceId">Resource ID</param>
        /// <param name="changeType">Type of change that will be made to the
        /// resource when the deployment is executed. Possible values include:
        /// 'Create', 'Delete', 'Ignore', 'Deploy', 'NoChange', 'Modify',
        /// 'Unsupported'</param>
        /// resource is unsupported by What-If.</param>
        /// <param name="before">The snapshot of the resource before the
        /// deployment is executed.</param>
        /// <param name="after">The predicted snapshot of the resource after
        /// the deployment is executed.</param>
        /// <param name="delta">The predicted changes to resource
        /// properties.</param>
        public WhatIfChange(string resourceId, ChangeType changeType, object before = default(object), object after = default(object), IList<WhatIfPropertyChange> delta = default(IList<WhatIfPropertyChange>))
            : this(resourceId, changeType, default(string), before, after, delta)
        {
        }
    }
}
