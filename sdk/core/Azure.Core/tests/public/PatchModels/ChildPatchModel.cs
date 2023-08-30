// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Tests.PatchModels
{
    /// <summary>
    /// This model illustrates a nested child model in a parent model.
    /// </summary>
    public partial class ChildPatchModel
    {
        private BitVector64 _changed;

        /// <summary>
        /// Serialization constructor.
        /// </summary>
        internal ChildPatchModel()
        {
        }

        /// <summary> Deserialization constructor. </summary>
        internal ChildPatchModel(string a, string b)
        {
            _a = a;
            _b = b;
        }

        public bool HasChanges => _changed.IsNonzero();

        private string _a;
        private const int AProperty = 0;
        /// <summary>
        /// Optional string property corresponding to JSON """{"a": "aaa"}""".
        /// </summary>
        public string A
        {
            get => _a;
            set
            {
                _changed[AProperty] = true;
                _a = value;
            }
        }

        private string _b;
        private const int BProperty = 1;
        /// <summary>
        /// Optional string property corresponding to JSON """{"b": "bbb"}""".
        /// </summary>
        public string B
        {
            get => _b;
            set
            {
                _changed[BProperty] = true;
                _b = value;
            }
        }
    }
}
