// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public class FormPageCollection : ReadOnlyCollection<FormPage>
    {
        /// <summary>
        /// </summary>
        /// <param name="list"></param>
        internal FormPageCollection(IList<FormPage> list) : base(list)
        {
        }
    }
}
