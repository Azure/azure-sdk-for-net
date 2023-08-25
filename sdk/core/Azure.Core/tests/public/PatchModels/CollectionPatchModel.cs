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
        private readonly MergePatchChanges _changes;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public CollectionPatchModel()
        {
            // Size is 1 b/c we don't need to track changes to read-only values.
            _changes = new MergePatchChanges(1);
        }

        /// <summary>
        /// Serialization constructor.
        /// </summary>
        internal CollectionPatchModel(string id, MergePatchDictionary<string> variables, MergePatchDictionary<ChildPatchModel> children)
        {
            _changes = new MergePatchChanges(1);

            _id = id;
            _variables = variables;
            _children = children;
        }

        private string _id;
        private static int IdProperty => 0;
        /// <summary>
        /// Optional string property corresponding to JSON """{"id": "abc"}""".
        /// </summary>
        public string Id
        {
            get => _id;
            set
            {
                _changes.SetChanged(IdProperty);
                _id = value;
            }
        }

        private MergePatchDictionary<string> _variables;
        /// <summary> Environment variables which are defined as a set of &lt;name,value&gt; pairs. </summary>
        public IDictionary<string, string> Variables
        {
            get
            {
                _variables ??= MergePatchDictionary<string>.GetStringDictionary();
                return _variables;
            }
        }

        private MergePatchDictionary<ChildPatchModel> _children;
        /// <summary>  </summary>
        public IDictionary<string, ChildPatchModel> Children
        {
            get
            {
                _children ??=
                    new MergePatchDictionary<ChildPatchModel>(
                        ChildPatchModel.Deserialize,
                        (w, m) => m.SerializePatch(w),
                        c => c.HasChanges);
                return _children;
            }
        }
    }
}
