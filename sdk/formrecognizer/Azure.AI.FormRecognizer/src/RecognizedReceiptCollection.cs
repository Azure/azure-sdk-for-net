// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public class RecognizedReceiptCollection : ReadOnlyCollection<RecognizedReceipt>
    {
        /// <summary>
        /// </summary>
        /// <param name="list"></param>
        internal RecognizedReceiptCollection(IList<RecognizedReceipt> list) : base(list)
        {
        }
    }
}
