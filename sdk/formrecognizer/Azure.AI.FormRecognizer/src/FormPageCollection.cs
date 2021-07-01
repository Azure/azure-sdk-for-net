// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// A read-only collection of <see cref="FormPage"/> objects.
    /// </summary>
    public class FormPageCollection : ReadOnlyCollection<FormPage>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormPageCollection"/> class.
        /// This class is a read-only wrapper around the specified list.
        /// </summary>
        /// <param name="list">The list to wrap.</param>
        /// <exception cref="ArgumentNullException"><paramref name="list"/> is null.</exception>
        internal FormPageCollection(IList<FormPage> list)
            : base(list)
        {
        }
    }
}
