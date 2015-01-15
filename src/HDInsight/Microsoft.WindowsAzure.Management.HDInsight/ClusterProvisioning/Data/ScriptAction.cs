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

    /// <summary>
    /// Script action for an HDInsight cluster.
    /// </summary>
    public class ScriptAction : ConfigAction
    {
        /// <summary>
        /// Gets the Uri.
        /// </summary>
        public Uri Uri { get; private set; }

        /// <summary>
        /// Gets the parameters.
        /// </summary>
        public string Parameters { get; private set; }

        /// <summary>
        /// Initializes a new instance of the ScriptAction class.
        /// </summary>
        /// <param name="name">Name for this script action.</param>
        /// <param name="clusterRoleCollection">Cluster Roles affected in this script action.</param>
        /// <param name="uri">Uri for this script action.</param>
        /// <param name="parameters">Parameters for this script action.</param>
        public ScriptAction(string name, IEnumerable<ClusterNodeType> clusterRoleCollection, Uri uri, string parameters)
            : base(name, clusterRoleCollection)
        {
            if (uri == null)
            {
                throw new ArgumentNullException("uri", "The uri for a config action can't be null.");
            }

            this.Uri = uri;
            this.Parameters = parameters;
        }

        /// <summary>
        /// Overrides this method for class comparison purpose.
        /// </summary>
        /// <returns>The hashcode of this class.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode() * this.Uri.GetHashCode();
        }

        /// <summary>
        /// Compares two ScriptActions for equality.
        /// </summary>
        /// <param name="obj">Object to compare to.</param>
        /// <returns>Whether two objects are equal.</returns>
        public override bool Equals(object obj)
        {
            ScriptAction p = obj as ScriptAction;

            // If parameter cannot be cast to ScriptAction return false:
            if (p == null)
            {
                return false;
            }

            // Return true if the fields match.
            return p.Uri == this.Uri && p.Parameters == this.Parameters && base.Equals(p);
        }
    }
}