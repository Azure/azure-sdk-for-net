// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Serialization;

namespace Azure.Core.Tests.PatchModels
{
    /// <summary>
    /// This model illustrates a nested child model in a parent model.
    /// </summary>
    public partial class ChildPatchModel
    {
        private readonly ChangeListElement _changes;

        internal ChildPatchModel(ChangeListElement changes)
        {
            _changes = changes;
        }

        /// <summary>
        /// Serialization constructor.
        /// </summary>
        internal ChildPatchModel()
        {
            // TODO: Make it so it throws if this is called and _changes is later accessed.
        }

        /// <summary> Deserialization constructor. </summary>
        internal ChildPatchModel(ChangeListElement changes, string a, string b)
        {
            _a = a;
            _b = b;

            // Connect the child's changes to the parent's changes.
            _changes = changes;
        }

        private string _a;
        /// <summary>
        /// Optional string property corresponding to JSON """{"a": "aaa"}""".
        /// </summary>
        public string A
        {
            get => _a;
            set
            {
                _a = value;
                _changes.Set("a", value);
            }
        }

        private string _b;
        /// <summary>
        /// Optional string property corresponding to JSON """{"b": "bbb"}""".
        /// </summary>
        public string B
        {
            get => _b;
            set
            {
                _b = value;
                _changes.Set("b", value);
            }
        }
    }
}
