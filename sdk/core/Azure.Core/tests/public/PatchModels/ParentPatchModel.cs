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
        private readonly MergePatchChanges _changes;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public ParentPatchModel()
        {
            _changes = new MergePatchChanges(2);
        }

        /// <summary>
        /// Serialization constructor.
        /// </summary>
        internal ParentPatchModel(string id, ChildPatchModel child)
        {
            _changes = new MergePatchChanges(2);

            _id = id;
            _child = child;
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

        private ChildPatchModel _child;
        private static int ChildProperty => 1;
        /// <summary>
        /// Optional ChildPatchModel property corresponding to JSON """{"child": {"a":"aa", "b": "bb"}}""".
        /// </summary>
        public ChildPatchModel Child
        {
            get
            {
                if (_child == null && !_changes.HasChanged(ChildProperty))
                {
                    _child = new ChildPatchModel();
                }

                return _child;
            }
            set
            {
                _changes.SetChanged(ChildProperty);
                _child = value;
            }
        }
    }
}
