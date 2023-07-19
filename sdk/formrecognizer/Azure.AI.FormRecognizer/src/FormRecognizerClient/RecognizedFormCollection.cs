// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// A read-only collection of <see cref="RecognizedForm"/> objects.
    /// </summary>
    public class RecognizedFormCollection : ReadOnlyCollection<RecognizedForm>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecognizedFormCollection"/> class.
        /// This class is a read-only wrapper around the specified list.
        /// </summary>
        /// <param name="list">The list to wrap.</param>
        /// <returns>A new <see cref="RecognizedFormCollection"/> instance for mocking.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="list"/> is null.</exception>
        internal RecognizedFormCollection(IList<RecognizedForm> list)
            : base(list)
        {
        }
    }
}
