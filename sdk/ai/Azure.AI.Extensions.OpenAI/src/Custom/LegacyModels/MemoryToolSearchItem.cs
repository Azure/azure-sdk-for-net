// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.Extensions.OpenAI
{
    /// <summary> A retrieved memory item from memory search. This is a legacy model, it is provided for back compatibility only. </summary>
    public partial class MemoryToolSearchItem
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        /// <summary> Initializes a new instance of <see cref="MemoryToolSearchItem"/>. </summary>
        /// <param name="memoryItem"> Retrieved memory item. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="memoryItem"/> is null. </exception>
        public MemoryToolSearchItem(MemoryOutputItem memoryItem)
        {
            Argument.AssertNotNull(memoryItem, nameof(memoryItem));

            MemoryItem = memoryItem;
        }

        /// <summary> Initializes a new instance of <see cref="MemoryToolSearchItem"/>. </summary>
        /// <param name="memoryItem"> Retrieved memory item. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        internal MemoryToolSearchItem(MemoryOutputItem memoryItem, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            MemoryItem = memoryItem;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> Retrieved memory item. </summary>
        public MemoryOutputItem MemoryItem { get; set; }
    }
}
