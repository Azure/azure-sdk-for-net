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
    /// Methods and properties that are inherited from the instantiating parent object.
    /// </summary>
    public interface IInheritedBehaviors
    {
        /// <summary>
        /// This collection is initially populated by instantiation or by copying from the instantiating parent object (inheritance).
        /// In this model, the collections are independent but the members are shared references.
        /// Members of this collection alter or customize various behaviors of Azure Batch Service client objects.
        /// These behaviors are generally inherited by any child class instances.  
        /// Modifications are applied in the order of the collection.
        /// The last write wins.
        /// </summary>
        IList<BatchClientBehavior> CustomBehaviors { get; set; }
    }

    internal class InheritUtil
    {
        internal static void InheritClientBehaviorsAndSetPublicProperty(IInheritedBehaviors inheritingObject, IEnumerable<BatchClientBehavior> baseBehaviors)
        {
            // implement inheritance of behaviors
            List<BatchClientBehavior> customBehaviors = new List<BatchClientBehavior>();

            // if there were any behaviors, pre-populate the collection (ie: inherit)
            if (null != baseBehaviors)
            {
                customBehaviors.AddRange(baseBehaviors);
            }

            // set the public property
            inheritingObject.CustomBehaviors = customBehaviors;
        }
    }
}
