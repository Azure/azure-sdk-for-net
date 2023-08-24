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
        private readonly MergePatchChanges _changes;

        /// <summary>
        /// Serialization constructor.
        /// </summary>
        internal ChildPatchModel()
        {
            _changes = new MergePatchChanges(2);
        }

        /// <summary> Deserialization constructor. </summary>
        internal ChildPatchModel(string a, string b)
        {
            _changes = new MergePatchChanges(2);

            _a = a;
            _b = b;
        }

        public bool HasChanges => _changes.HasChanged(AProperty) || _changes.HasChanged(BProperty);

        private string _a;
        private static int AProperty => 0;
        /// <summary>
        /// Optional string property corresponding to JSON """{"a": "aaa"}""".
        /// </summary>
        public string A
        {
            get => _a;
            set
            {
                _changes.SetChanged(AProperty);
                _a = value;
            }
        }

        private string _b;
        private static int BProperty => 1;
        /// <summary>
        /// Optional string property corresponding to JSON """{"b": "bbb"}""".
        /// </summary>
        public string B
        {
            get => _b;
            set
            {
                _changes.SetChanged(BProperty);
                _b = value;
            }
        }
    }
}
