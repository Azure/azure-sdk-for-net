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
        private readonly ChangeList _rootChanges;
        private ChangeListElement _changes => _rootChanges.RootElement;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public ParentPatchModel()
        {
            _rootChanges = new ChangeList();
        }

        /// <summary>
        /// Serialization constructor.
        /// </summary>
        /// <param name="element"></param>
        internal ParentPatchModel(ChangeList changes, string id, ChildPatchModel child)
        {
            _id = id;
            _child = child;

            _rootChanges = changes;
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
                _child ??= new ChildPatchModel( _changes.GetElement("child"));
                return _child;
            }
            set
            {
                _child = value;
                _changes.Set("child", value);

                // Note, we don't have to connect the child's changelist
                // to the parent's changelist, because if we overwrite the child
                // we will need to write the whole thing out anyway, and we
                // don't have to worry about tracking changes in that case.
            }
        }
    }
}
