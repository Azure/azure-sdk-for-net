// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.AI.Projects;

internal partial class InternalOpenAICollectionResultOptions
{
    public string ParentResourceId { get; set; }
    public int? Limit { get; set; }
    public string Order { get; set; }
    public string AfterId { get; set; }
    public string BeforeId { get; set; }
    public List<string> Filters { get; } = [];
    public List<string> Includes { get; } = [];

    public InternalOpenAICollectionResultOptions(int? limit = null, string order = null, string after = null, string before = null, IEnumerable<string> filters = null, IEnumerable<string> includes = null)
    {
        Limit = limit;
        Order = order;
        AfterId = after;
        BeforeId = before;
        Filters ??= [];
        foreach (string maybeFilter in filters ?? [])
        {
            if (!string.IsNullOrEmpty(maybeFilter))
            {
                Filters.Add(maybeFilter);
            }
        }
        Includes ??= [];
        foreach (string maybeInclude in includes ?? [])
        {
            if (!string.IsNullOrEmpty(maybeInclude))
            {
                Includes.Add(maybeInclude);
            }
        }
    }

    public InternalOpenAICollectionResultOptions GetCloneForPage<T>(InternalOpenAIPaginatedListResultOfT<T> page)
    {
        InternalOpenAICollectionResultOptions clonedOptions = (InternalOpenAICollectionResultOptions)MemberwiseClone();
        clonedOptions.Filters.AddRange(Filters);
        clonedOptions.Includes.AddRange(Includes);

        clonedOptions.AfterId = page.LastId;
        clonedOptions.BeforeId = page.FirstId;

        return clonedOptions;
    }
}
