// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.OpenAI.Assistants;

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
public partial class PageableList<T>
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

    internal static PageableList<Assistant> Create(InternalOpenAIPageableListOfAssistant internalList)
        => new(internalList.Data, internalList.FirstId, internalList.LastId, internalList.HasMore);
    internal static PageableList<AssistantFile> Create(InternalOpenAIPageableListOfAssistantFile internalList)
        => new(internalList.Data, internalList.FirstId, internalList.LastId, internalList.HasMore);
    internal static PageableList<ThreadMessage> Create(InternalOpenAIPageableListOfThreadMessage internalList)
                => new(internalList.Data, internalList.FirstId, internalList.LastId, internalList.HasMore);
    internal static PageableList<MessageFile> Create(InternalOpenAIPageableListOfMessageFile internalList)
        => new(internalList.Data, internalList.FirstId, internalList.LastId, internalList.HasMore);
    internal static PageableList<RunStep> Create(InternalOpenAIPageableListOfRunStep internalList)
        => new(internalList.Data, internalList.FirstId, internalList.LastId, internalList.HasMore);
    internal static PageableList<ThreadRun> Create(InternalOpenAIPageableListOfThreadRun internalList)
        => new(internalList.Data, internalList.FirstId, internalList.LastId, internalList.HasMore);
}

/*
 * CUSTOM CODE DESCRIPTION:
 *
 * Included here for concision, these perform renames of the rerouted types for clarity.
 */

[CodeGenType("OpenAIPageableListOfAssistant")]
internal partial class InternalOpenAIPageableListOfAssistant { }
[CodeGenType("OpenAIPageableListOfAssistantFile")]
internal partial class InternalOpenAIPageableListOfAssistantFile { }
[CodeGenType("OpenAIPageableListOfThreadMessage")]
internal partial class InternalOpenAIPageableListOfThreadMessage { }
[CodeGenType("OpenAIPageableListOfMessageFile")]
internal partial class InternalOpenAIPageableListOfMessageFile { }
[CodeGenType("OpenAIPageableListOfRunStep")]
internal partial class InternalOpenAIPageableListOfRunStep { }
[CodeGenType("OpenAIPageableListOfThreadRun")]
internal partial class InternalOpenAIPageableListOfThreadRun { }
