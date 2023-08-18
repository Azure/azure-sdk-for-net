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
        private readonly ChangeList _rootChanges = new();
        private readonly ChangeListElement _changes;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public ParentPatchModel()
        {
            _changes = _rootChanges.RootElement;
        }

        /// <summary>
        /// Serialization constructor.
        /// </summary>
        /// <param name="element"></param>
        internal ParentPatchModel(string id, ChildPatchModel child)
        {
            _id = id;
            _child = child;

            _changes = _rootChanges.RootElement;
        }

        private string _id;
        /// <summary>
        /// Optional string property corresponding to JSON """{"id": "abc"}""".
        /// </summary>
        public string Id
        {
            get => _id;
            set
            {
                _id = value;
                _changes.Set("id", value);
            }
        }

        private ChildPatchModel _child;
        /// <summary>
        /// Optional ChildPatchModel property corresponding to JSON """{"child": {"a":"aa", "b": "bb"}}""".
        /// </summary>
        public ChildPatchModel Child
        {
            get
            {
                _child ??= new ChildPatchModel("child", _changes);
                return _child;
            }
            set
            {
                _child = value;
                _child.RegisterWithParent("child", _changes);
                _changes.Set("child", value);
            }
        }
    }
}
