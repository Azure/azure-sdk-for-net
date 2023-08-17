// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Tests.PatchModels
{
    /// <summary>
    /// This model illustrates a nested child model in a parent model.
    /// </summary>
    public partial class ChildPatchModel
    {
        internal bool HasChanges => _aPatchFlag || _bPatchFlag;

        /// <summary> Serialization constructor. </summary>
        internal ChildPatchModel(string a, string b)
        {
            _a = a;
            _b = b;
        }

        private string _a;
        private bool _aPatchFlag;
        /// <summary>
        /// Optional string property corresponding to JSON """{"a": "aaa"}""".
        /// </summary>
        public string A
        {
            get => _a;
            set
            {
                _a = value;
                _aPatchFlag = true;
            }
        }

        private string _b;
        private bool _bPatchFlag;
        /// <summary>
        /// Optional string property corresponding to JSON """{"b": "bbb"}""".
        /// </summary>
        public string B
        {
            get => _b;
            set
            {
                _b = value;
                _bPatchFlag = true;
            }
        }
    }
}
