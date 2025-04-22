// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.Agents.Persistent;

/*
 * CUSTOM CODE DESCRIPTION:
 *
 * This custom type facilitates common use of list types, which don't trivially emit from TypeSpec into an idiomatic
 * form.
 */

/// <summary>
/// Represents a pageable list of data items with item ID cursors representing the start and end of the current page.
/// </summary>
/// <remarks>
/// <see cref="FirstId"/> and <see cref="LastId"/> can be used as inputs into methods that list items to retrieve
/// additional items before or after the current page's view.
/// </remarks>
/// <typeparam name="T"> The type of the data instances contained in the list. </typeparam>
public partial class PageableList<T> : IEnumerable<T>
{
    /// <summary> The requested list of items. </summary>
    public IReadOnlyList<T> Data { get; }
    /// <summary> The first ID represented in this list. </summary>
    public string FirstId { get; }
    /// <summary> The last ID represented in this list. </summary>
    public string LastId { get; }
    /// <summary> A value indicating whether there are additional values available not captured in this list. </summary>
    public bool HasMore { get; }

    internal PageableList(
        IReadOnlyList<T> data,
        string firstId,
        string lastId,
        bool hasMore)
    {
        Data = data;
        FirstId = firstId;
        LastId = lastId;
        HasMore = hasMore;
    }

    internal static PageableList<PersistentAgent> Create(InternalOpenAIPageableListOfAgent internalList)
        => new(internalList.Data, internalList.FirstId, internalList.LastId, internalList.HasMore);
    internal static PageableList<ThreadMessage> Create(InternalOpenAIPageableListOfThreadMessage internalList)
                => new(internalList.Data, internalList.FirstId, internalList.LastId, internalList.HasMore);
    internal static PageableList<RunStep> Create(InternalOpenAIPageableListOfRunStep internalList)
        => new(internalList.Data, internalList.FirstId, internalList.LastId, internalList.HasMore);
    internal static PageableList<ThreadRun> Create(InternalOpenAIPageableListOfThreadRun internalList)
        => new(internalList.Data, internalList.FirstId, internalList.LastId, internalList.HasMore);
    internal static PageableList<PersistentAgentThread> Create(OpenAIPageableListOfAgentThread internalList)
        => new(internalList.Data, internalList.FirstId, internalList.LastId, internalList.HasMore);

    /*
    * CUSTOM CODE DESCRIPTION:
    *
    * These additions to the custom PageableList type aren't necessary for the dimension of code generation customization
    * but do facilitate easier "list-like" use of the type.
    */

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

/*
 * CUSTOM CODE DESCRIPTION:
 *
 * Included here for concision, these perform renames of the rerouted types for clarity.
 */

[CodeGenType("OpenAIPageableListOfAgent")]
internal partial class InternalOpenAIPageableListOfAgent { }
internal readonly partial struct OpenAIPageableListOfAgentObject { }
//[CodeGenType("OpenAIPageableListOfAgentFile")]
//internal partial class InternalOpenAIPageableListOfAgentFile { }
internal readonly partial struct OpenAIPageableListOfAgentFileObject { }
[CodeGenType("OpenAIPageableListOfThreadMessage")]
internal partial class InternalOpenAIPageableListOfThreadMessage { }
internal readonly partial struct OpenAIPageableListOfThreadMessageObject { }
//internal readonly partial struct OpenAIPageableListOfMessageFileObject { }
[CodeGenType("OpenAIPageableListOfRunStep")]
internal partial class InternalOpenAIPageableListOfRunStep { }
internal readonly partial struct OpenAIPageableListOfRunStepObject { }
[CodeGenType("OpenAIPageableListOfThreadRun")]
internal partial class InternalOpenAIPageableListOfThreadRun { }
internal readonly partial struct OpenAIPageableListOfThreadRunObject { }
