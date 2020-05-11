// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// A read-only collection of <see cref="RecognizedForm"/> objects.
    /// </summary>
    public class RecognizedFormCollection : ReadOnlyCollection<RecognizedForm>
    {
        /// <inheritdoc/>
        internal RecognizedFormCollection(IList<RecognizedForm> list) : base(list)
        {
        }
    }
}
