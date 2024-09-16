// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;

namespace System.ClientModel;

#pragma warning disable CS1591 // public XML comments
/// <summary>
/// Represents a collection of values returned from a cloud service operation.
/// The collection values may be returned by one or more service responses.
/// </summary>
public abstract class CollectionResult<T> : CollectionResult, IEnumerable<T>
{
    protected internal CollectionResult()
    {
    }

    /// <inheritdoc/>
    public IEnumerator<T> GetEnumerator()
    {
        foreach (ClientResult page in GetRawPages())
        {
            foreach (T value in GetValuesFromPage(page))
            {
                yield return value;
            }
        }
    }

    /// <summary>
    /// Get a collection of the values from a page response.
    /// </summary>
    /// <param name="page"></param>
    /// <returns></returns>
    protected abstract IEnumerable<T> GetValuesFromPage(ClientResult page);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
#pragma warning restore CS1591 // public XML comments
