// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public class RecognizedFormCollection : ReadOnlyCollection<RecognizedForm>
    {
        /// <summary>
        /// </summary>
        /// <param name="list"></param>
        internal RecognizedFormCollection(IList<RecognizedForm> list) : base(list)
        {
        }
    }
}
