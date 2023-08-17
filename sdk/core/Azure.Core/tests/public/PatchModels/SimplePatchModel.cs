// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Tests.PatchModels
{
    /// <summary>
    /// This model illustrates optional read/write "primitive" properties.
    /// </summary>
    public partial class SimplePatchModel
    {
        /// <summary>
        /// Public constructor.
        /// </summary>
        public SimplePatchModel()
        {
        }

        /// <summary>
        /// Serialization constructor.
        /// </summary>
        /// <param name="element"></param>
        internal SimplePatchModel(string name, int? count, DateTimeOffset? updatedOn)
        {
            _name = name;
            _count = count;
            _updatedOn = updatedOn;
        }

        /// <summary>
        /// Optional string property corresponding to JSON """{"name": "abc"}""".
        /// </summary>
        private string _name;
        private bool _namePatchFlag;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                _namePatchFlag = true;
            }
        }

        /// <summary>
        /// Optional int property corresponding to JSON """{"count": 1}""".
        /// </summary>
        private int? _count;
        private bool _countPatchFlag;
        public int? Count
        {
            get => _count;
            set
            {
                _count = value;
                _countPatchFlag = true;
            }
        }

        /// <summary>
        /// Optional DateTimeOffset property corresponding to JSON """{"updatedOn": "2020-06-25T17:44:37.6830000Z"}""".
        /// </summary>
        private DateTimeOffset? _updatedOn;
        private bool _updatedOnPatchFlag;
        public DateTimeOffset? UpdatedOn
        {
            get => _updatedOn;
            set
            {
                _updatedOn = value;
                _updatedOnPatchFlag = true;
            }
        }
    }
}
