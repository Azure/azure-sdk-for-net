// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Tests.PatchModels
{
    /// <summary>
    /// This model illustrates a patch model with properties that are nested models.
    /// </summary>
    public partial class ParentPatchModel
    {
        private BitVector64 _changed;

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
            _id = id;
            _child = child;
        }

        private string _id;
        private const int IdProperty = 0;
        /// <summary>
        /// Optional string property corresponding to JSON """{"id": "abc"}""".
        /// </summary>
        public string Id
        {
            get => _id;
            set
            {
                _changed[IdProperty] = true;
                _id = value;
            }
        }

        private ChildPatchModel _child;
        private const int ChildProperty = 1;
        /// <summary>
        /// Optional ChildPatchModel property corresponding to JSON """{"child": {"a":"aa", "b": "bb"}}""".
        /// </summary>
        public ChildPatchModel Child
        {
            get
            {
                if (_child == null && !_changed[ChildProperty])
                {
                    _child = new ChildPatchModel();
                }

                return _child;
            }
            set
            {
                _changed[ChildProperty] = true;
                _child = value;
            }
        }
    }
}
