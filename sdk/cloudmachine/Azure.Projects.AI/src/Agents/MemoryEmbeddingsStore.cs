// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System;
using OpenAI.Embeddings;

namespace Azure.Projects.AI;

internal class MemoryEmbeddingsStore : EmbeddingsStore
{
    private readonly List<VectorbaseEntry> _entries = [];

    internal MemoryEmbeddingsStore(EmbeddingClient client)
        : base(client)
    {
    }

    public override IEnumerable<VectorbaseEntry> Find(ReadOnlyMemory<float> vector, FindOptions options)
    {
        lock (_entries)
        {
            var distances = new List<(float Distance, int Index)>(_entries.Count);
            for (int index = 0; index < _entries.Count; index++)
            {
                VectorbaseEntry entry = _entries[index];
                ReadOnlyMemory<float> dbVector = entry.Vector;
                float distance = 1.0f - CosineSimilarity(dbVector.Span, vector.Span);
                distances.Add((distance, index));
            }
            distances.Sort(((float D1, int I1) v1, (float D2, int I2) v2) => v1.D1.CompareTo(v2.D2));

            List<VectorbaseEntry> results = new(options.MaxEntries);
            int top = Math.Min(options.MaxEntries, distances.Count);
            for (int i = 0; i < top; i++)
            {
                float distance = distances[i].Distance;
                if (distance > options.Threshold)
                    break;
                int index = distances[i].Index;
                results.Add(_entries[index]);
            }
            return results;
        }
    }
    public override int Add(VectorbaseEntry entry)
    {
        lock (_entries)
        {
            int id = _entries.Count;
            VectorbaseEntry newEntry = new(entry.Vector, entry.Data, id);
            _entries.Add(newEntry);
            return id;
        }
    }

    public override void Add(IReadOnlyList<VectorbaseEntry> entries)
    {
        foreach (VectorbaseEntry entry in entries)
        {
            Add(entry);
        }
    }
}
