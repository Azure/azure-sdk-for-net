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
#pragma warning disable SA1649 // File name should match first type name
    public class RecognizedFormCollection<T> : ReadOnlyCollection<T> // TODO: Question: Should this be RecognizedForm<T> instead?
#pragma warning restore SA1649 // File name should match first type name
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecognizedFormCollection"/> class.
        /// This class is a read-only wrapper around the specified list.
        /// </summary>
        /// <param name="list">The list to wrap.</param>
        /// <returns>A new <see cref="RecognizedFormCollection"/> instance for mocking.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="list"/> is null.</exception>
        internal RecognizedFormCollection(IList<T> list)
            : base(list)
        {
        }
    }
}
