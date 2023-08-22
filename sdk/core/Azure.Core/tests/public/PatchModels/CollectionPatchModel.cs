// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core.Serialization;

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
        internal CollectionPatchModel(string id, MergePatchDictionary<string> values)
        {
            _id = new Changed<string>(id);
            _variables = values;
        }

        private Changed<string> _id;
        /// <summary>
        /// Optional string property corresponding to JSON """{"id": "abc"}""".
        /// </summary>
        public string Id
        {
            get => _id;
            set => _id.Value = value;
        }

        private MergePatchDictionary<string> _variables;
        /// <summary> Environment variables which are defined as a set of &lt;name,value&gt; pairs. </summary>
        public IDictionary<string, string> Variables
        {
            get
            {
                _variables ??= new MergePatchDictionary<string>();
                return _variables;
            }
        }
    }
}
