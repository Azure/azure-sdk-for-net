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

﻿namespace Microsoft.Azure.Batch
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Tools for managing multiple collections of behaviors.
    /// </summary>
    internal class BehaviorManager
    {
        internal BehaviorManager(
            IEnumerable<BatchClientBehavior> baseBehaviors,
            IEnumerable<BatchClientBehavior> perCallBehaviors,
            DetailLevel detailLevel = null)
        {
            this.BaseBehaviors = new List<BatchClientBehavior>();

            if (null != baseBehaviors)
            {
                this.BaseBehaviors.AddRange(baseBehaviors);
            }

            this.PerCallBehaviors = new List<BatchClientBehavior>();

            if (null != perCallBehaviors)
            {
                this.PerCallBehaviors.AddRange(perCallBehaviors);
            }

            if (detailLevel != null)
            {
                this.AppendDetailLevel(detailLevel);
            }
        }

        private BehaviorManager(BehaviorManager other)
        {
            this.BaseBehaviors = new List<BatchClientBehavior>(other.BaseBehaviors);
            this.PerCallBehaviors = new List<BatchClientBehavior>(other.PerCallBehaviors);
        }

        internal List<BatchClientBehavior> BaseBehaviors { get; set; }
        internal List<BatchClientBehavior> PerCallBehaviors { get; set; }

        /// <summary>
        /// Returns a new list of behaviors that is the concatination of the base + per-call.
        /// </summary>
        internal List<BatchClientBehavior> MasterListOfBehaviors
        {
            get
            {
                List<BatchClientBehavior> ml = new List<BatchClientBehavior>(this.BaseBehaviors);

                ml.AddRange(this.PerCallBehaviors);

                return ml;
            }
        }

        /* On "impl" inheritance
         * 
         * Impls like GetNodeFileAsyncImpl cannot/must-not honor inheritance by propagating behaviors
         * from the manager or outter class... the new child objects get their base from 
         * BehaviorMangaer.BaseBehaviors.
         * 
         * When we add features like DetailLevel.. they must not taint the base
         * collection... or children will get them.
         * 
         * By corallary, such features should probably not taint the PerCallBeahviors either.
         * We need an "Inbetween" collection.
         * 
         * There is a bug on Detaillevel order-of-execution and this work should be part of that bug.
         * 
        */
        internal BehaviorManager CreateBehaviorManagerWithDetailLevel(DetailLevel detailLevel)
        {
            //Copy "this"
            BehaviorManager result = new BehaviorManager(this);

            result.AppendDetailLevel(detailLevel);
            return result;
        }

        /// <summary>
        /// Gets an ordered list of behaviors of the specific type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        internal List<T> GetBehaviors<T>() where T : BatchClientBehavior
        {
            List<T> result = new List<T>();
            //Find all behaviors of type T and get the (in order)
            foreach (BatchClientBehavior behavior in this.MasterListOfBehaviors)
            {
                T typedBehavior = behavior as T;
                if (typedBehavior != null)
                {
                    result.Add(typedBehavior);
                }
            }

            return result;
        }

        private void AppendDetailLevel(DetailLevel detailLevel)
        {
            if ((null != detailLevel) && (detailLevel is ODATADetailLevel))
            {
                ODATADetailLevelIntercept intercept = new ODATADetailLevelIntercept(detailLevel as ODATADetailLevel);

                this.PerCallBehaviors.Add(intercept);
            }
        }
    }
}
