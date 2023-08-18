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
        private ChangeListElement _changes;

        internal ChildPatchModel(string path, ChangeListElement changes)
        {
            _changes = changes.GetElement(path);
        }

        /// <summary>
        /// Serialization constructor.
        /// </summary>
        internal ChildPatchModel()
        {
            // TODO: Make it so it throws if this is called and changes is later accessed.
        }

        /// <summary> Serialization constructor. </summary>
        internal ChildPatchModel(string a, string b)
        {
            _a = a;
            _b = b;

            // TODO: Make it so it throws if this is called and _changes is later accessed.
        }

        internal void RegisterWithParent(string path, ChangeListElement changes)
        {
            _changes = changes.GetElement(path);

            // TODO: add freezing mechanism to make sure this isn't called multiple times?

            // TODO:
            // Note: we could simplify this a lot if we just pass around the root changelist
            // and tell a nested model what its parent path prefix is.
            // The parent doesn't need to maintain a registration.
            // It does have the implication that a model can only be rooted with one
            // change list at a time, not shared between instances.
            // Although, honestly, if something is set, it doesn't need to track
            // its changes anymore, because the entire thing will be written out when
            // any changes happen to it, since it is a wholesale replacement.
            // Set of an "object" is a fairly atomic thing.
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
