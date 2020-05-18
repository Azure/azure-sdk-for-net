// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// A read-only collection of <see cref="RecognizedReceipt"/> objects.
    /// </summary>
    public class RecognizedReceiptCollection : ReadOnlyCollection<RecognizedReceipt>
    {
        /// <inheritdoc/>
        internal RecognizedReceiptCollection(IList<RecognizedReceipt> list) : base(list)
        {
        }
    }
}
