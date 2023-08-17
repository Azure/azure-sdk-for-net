// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Json;

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
        /// <param name="element"></param>
        internal ParentPatchModel(string id, ChildPatchModel child)
        {
            _id = id;
            _child = child;
        }

        private string _id;
        private bool _idPatchFlag;
        /// <summary>
        /// Optional string property corresponding to JSON """{"id": "abc"}""".
        /// </summary>
        public string Id
        {
            get => _id;
            set
            {
                _id = value;
                _idPatchFlag = true;
            }
        }

        private ChildPatchModel _child;
        private bool _childPatchFlag;
        /// <summary>
        /// Optional ChildPatchModel property corresponding to JSON """{"child": {"a":"aa", "b": "bb"}}""".
        /// </summary>
        public ChildPatchModel Child
        {
            get => _child;
            set
            {
                _child = value;
                _childPatchFlag = true;
            }
        }
    }
}
