// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections;
using System.Collections.Generic;

namespace Azure.AI.OpenAI.Assistants;

/*
 * CUSTOM CODE DESCRIPTION:
 *
 * These additions to the custom PageableList type aren't necessary for the dimension of code generation customization
 * but do facilitate easier "list-like" use of the type.
 */

public partial class PageableList<T> : IEnumerable<T>
{
    /// <summary>
    /// Gets the data item at the specified index.
    /// </summary>
    /// <param name="index"> The index of the data item to retrieve. </param>
    /// <returns> The indexed data item. </returns>
    public T this[int index] => Data[index];

    /// <inheritdoc/>
    public IEnumerator<T> GetEnumerator()
    {
        return Data.GetEnumerator();
    }

    /// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)Data).GetEnumerator();
    }
}
