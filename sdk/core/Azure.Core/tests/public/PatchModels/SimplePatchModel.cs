// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Serialization;

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
        internal SimplePatchModel(string name, int count, DateTimeOffset updatedOn)
        {
            _name = new Changed<string>(name);
            _count = new Changed<int>(count);
            _updatedOn = new Changed<DateTimeOffset>(updatedOn);
        }

        private Changed<string> _name;
        /// <summary>
        /// Optional string property corresponding to JSON """{"name": "abc"}""".
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                _name.Value = value;
            }
        }

        private Changed<int> _count;
        /// <summary>
        /// Optional int property corresponding to JSON """{"count": 1}""".
        /// </summary>
        public int Count
        {
            get => _count;
            set
            {
                _count.Value = value;
            }
        }

        private Changed<DateTimeOffset> _updatedOn;
        /// <summary>
        /// Optional DateTimeOffset property corresponding to JSON """{"updatedOn": "2020-06-25T17:44:37.6830000Z"}""".
        /// </summary>
        public DateTimeOffset UpdatedOn
        {
            get => _updatedOn;
            set
            {
                _updatedOn.Value = value;
            }
        }
    }
}
