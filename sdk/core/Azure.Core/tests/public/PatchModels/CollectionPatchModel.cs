// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Core.Tests.PatchModels
{
    /// <summary>
    /// This model illustrates collection properties on Patch models.
    /// </summary>
    public partial class CollectionPatchModel
    {
        /// <summary>
        /// Public constructor.
        /// </summary>
        public CollectionPatchModel()
        {
        }

        /// <summary>
        /// Serialization constructor.
        /// </summary>
        /// <param name="element"></param>
        internal CollectionPatchModel(string id, IDictionary<string, string> values)
        {
        }

        private string _id;
        /// <summary>
        /// Optional string property corresponding to JSON """{"id": "abc"}""".
        /// </summary>
        public string Id
        {
            get => _id;
            set => _id = value;
        }

        private Dictionary<string, string> _variables;
        /// <summary> Environment variables which are defined as a set of &lt;name,value&gt; pairs. </summary>
        public IDictionary<string, string> Variables
        {
            get => _variables;
        }
    }
}
