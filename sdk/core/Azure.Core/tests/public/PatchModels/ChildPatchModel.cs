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
        /// <summary>
        /// Serialization constructor.
        /// </summary>
        internal ChildPatchModel()
        {
        }

        /// <summary> Deserialization constructor. </summary>
        internal ChildPatchModel(string a, string b)
        {
            _a = new MergePatchValue<string>(a);
            _b = new MergePatchValue<string>(b);
        }

        // TODO: Should this be an interface, or no?
        public bool HasChanges => _a.HasChanged || _b.HasChanged;

        private MergePatchValue<string> _a;
        /// <summary>
        /// Optional string property corresponding to JSON """{"a": "aaa"}""".
        /// </summary>
        public string A
        {
            get => _a;
            set => _a.Value = value;
        }

        private MergePatchValue<string> _b;
        /// <summary>
        /// Optional string property corresponding to JSON """{"b": "bbb"}""".
        /// </summary>
        public string B
        {
            get => _b;
            set => _b.Value = value;
        }
    }
}
