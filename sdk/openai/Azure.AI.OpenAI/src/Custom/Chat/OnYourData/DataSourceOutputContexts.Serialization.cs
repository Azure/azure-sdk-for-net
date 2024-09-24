// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.OpenAI.Chat;

internal static partial class DataSourceOutputContextFlagsExtensions
{
    public static IList<string> ToStringList(this DataSourceOutputContexts flags)
    {
        List<string> contexts = [];
        if (flags.HasFlag(DataSourceOutputContexts.Intent))
        {
            contexts.Add("intent");
        }
        if (flags.HasFlag(DataSourceOutputContexts.Citations))
        {
            contexts.Add("citations");
        }
        if (flags.HasFlag(DataSourceOutputContexts.AllRetrievedDocuments))
        {
            contexts.Add("all_retrieved_documents");
        }
        return contexts;
    }

    public static DataSourceOutputContexts? FromStringList(IList<string> strings)
    {
        if (strings is null)
        {
            return null;
        }
        DataSourceOutputContexts flags = 0;
        foreach (string s in strings)
        {
            if (s == "citations")
            {
                flags |= DataSourceOutputContexts.Citations;
            }
            else if (s == "intent")
            {
                flags |= DataSourceOutputContexts.Intent;
            }
            else if (s == "all_retrieved_documents")
            {
                flags |= DataSourceOutputContexts.AllRetrievedDocuments;
            }
        }
        return flags;
    }
}