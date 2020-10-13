// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// A read-only collection of <see cref="FormPage"/> objects.
    /// </summary>
    public class FormPageCollection : ReadOnlyCollection<FormPage>
    {
        /// <inheritdoc/>
        internal FormPageCollection(IList<FormPage> list) : base(list)
        {
        }
    }
}
