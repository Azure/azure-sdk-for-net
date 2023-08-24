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
        private readonly MergePatchChanges _changes;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public SimplePatchModel()
        {
            // Size = the number of properties to track
            _changes = new MergePatchChanges(3);
        }

        /// <summary>
        /// Serialization constructor.
        /// </summary>
        /// <param name="element"></param>
        internal SimplePatchModel(string name, int count, DateTimeOffset updatedOn)
        {
            _changes = new MergePatchChanges(3);

            _name = name;
            _count = count;
            _updatedOn = updatedOn;
        }

        private string _name;
        private static int NameProperty => 0;
        /// <summary>
        /// Optional string property corresponding to JSON """{"name": "abc"}""".
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                _changes.Change(NameProperty);
                _name = value;
            }
        }

        private int _count;
        private static int CountProperty => 1;
        /// <summary>
        /// Optional int property corresponding to JSON """{"count": 1}""".
        /// </summary>
        public int Count
        {
            get => _count;
            set
            {
                _changes.Change(CountProperty);
                _count = value;
            }
        }

        private DateTimeOffset _updatedOn;
        private static int UpdatedOnProperty => 2;
        /// <summary>
        /// Optional DateTimeOffset property corresponding to JSON """{"updatedOn": "2020-06-25T17:44:37.6830000Z"}""".
        /// </summary>
        public DateTimeOffset UpdatedOn
        {
            get => _updatedOn;
            set
            {
                _changes.Change(UpdatedOnProperty);
                _updatedOn = value;
            }
        }
    }
}
