// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Serialization;

namespace Azure.Core.Tests.PatchModels
{
    /// <summary>
    /// This model illustrates a patch model with properties that are nested models.
    /// </summary>
    public partial class ParentPatchModel
    {
        /// <summary>
        /// Public constructor.
        /// </summary>
        public ParentPatchModel()
        {
        }

        /// <summary>
        /// Serialization constructor.
        /// </summary>
        internal ParentPatchModel(string id, ChildPatchModel child)
        {
            _id = new Changed<string>(id);
            _child = new Changed<ChildPatchModel>(child);
        }

        private Changed<string> _id;
        /// <summary>
        /// Optional string property corresponding to JSON """{"id": "abc"}""".
        /// </summary>
        public string Id
        {
            get => _id;
            set
            {
                _id.Value = value;
            }
        }

        private Changed<ChildPatchModel> _child;
        /// <summary>
        /// Optional ChildPatchModel property corresponding to JSON """{"child": {"a":"aa", "b": "bb"}}""".
        /// </summary>
        public ChildPatchModel Child
        {
            get
            {
                if (_child.Value == null && !_child.HasChanged)
                {
                    _child = new Changed<ChildPatchModel>(new ChildPatchModel());
                }

                return _child;
            }
            set
            {
                _child.Value = value;
            }
        }
    }
}
