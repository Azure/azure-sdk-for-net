// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.

namespace Microsoft.WindowsAzure.Management.HDInsight
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Config action for an HDInsight cluster.
    /// </summary>
    public abstract class ConfigAction
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the affected nodes of the config action.
        /// </summary>
        public ISet<ClusterNodeType> ClusterRoleCollection { get; private set; }

        /// <summary>
        /// Initializes a new instance of the ConfigAction class.
        /// </summary>
        /// <param name="name">Name for this script config action.</param>
        /// <param name="clusterRoleCollection">Cluster Roles affected in this script config action.</param>
        protected ConfigAction(string name, IEnumerable<ClusterNodeType> clusterRoleCollection)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name", "The name for a config action can't be null.");
            }

            if (clusterRoleCollection == null)
            {
                throw new ArgumentNullException("clusterRoleCollection", "The clusterRoleCollection for a config action can't be null.");
            }

            if (!clusterRoleCollection.Any())
            {
                throw new ArgumentException("The clusterRoleCollection for a config action can't be empty.", "clusterRoleCollection");
            }

            this.Name = name;
            this.ClusterRoleCollection = new HashSet<ClusterNodeType>(clusterRoleCollection);
        }

        /// <summary>
        /// Overrides this method for class comparison purpose.
        /// </summary>
        /// <returns>The hashcode of this class.</returns>
        public override int GetHashCode()
        {
            return this.Name.Length * this.ClusterRoleCollection.Count;
        }

        /// <summary>
        /// Compares two ConfigActions for equality.
        /// </summary>
        /// <param name="obj">Object to compare to.</param>
        /// <returns>Whether two objects are equal.</returns>
        public override bool Equals(object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            ConfigAction p = obj as ConfigAction;

            // If parameter cannot be cast to ConfigAction return false:
            if (p == null)
            {
                return false;
            }

            // Return true if the fields match.
            return p.Name.Equals(this.Name) && this.ClusterRoleCollection.SetEquals(p.ClusterRoleCollection);
        }
    }
}