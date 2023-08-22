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
        internal CollectionPatchModel(string id, MergePatchDictionary<string> variables, MergePatchDictionary<ChildPatchModel> children)
        {
            _id = new MergePatchValue<string>(id);
            _variables = variables;
            _children = children;
        }

        private MergePatchValue<string> _id;
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
                _variables ??= new MergePatchDictionary<string>((w, s) => w.WriteStringValue(s));
                return _variables;
            }
        }

        private MergePatchDictionary<ChildPatchModel> _children;
        /// <summary>  </summary>
        public IDictionary<string, ChildPatchModel> Children
        {
            get
            {
                _children ??= new MergePatchDictionary<ChildPatchModel>((w, m) => m.SerializePatch(w));
                return _children;
            }
        }
    }
}
