// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenAI.Embeddings;
using System.Collections.Generic;
using System;

namespace OpenAI.Embeddings;

/// <summary>
/// The vectorbase for storing embeddings.
/// </summary>
public class EmbeddingsVectorbase
{
    private readonly EmbeddingClient _client;
    private readonly VectorbaseStore _store;

    private readonly List<string> _todo = new List<string>();

    /// <summary>
    /// Initializes a new instance of the <see cref="EmbeddingsVectorbase"/> class.
    /// </summary>
    /// <param name="client"></param>
    /// <param name="store"></param>
    public EmbeddingsVectorbase(EmbeddingClient client, VectorbaseStore store = default)
    {
        _client = client;
        _store = store ?? new MemoryVectorbaseStore();
    }

    /// <summary>
    /// Adds an entry to the vectorbase.
    /// </summary>
    /// <param name="text"></param>
    public void Add(string text)
    {
        lock (_todo)
        {
            _todo.Add(text);
        }
    }

    /// <summary>
    /// Finds entries in the vectorbase.
    /// </summary>
    /// <param name="text"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public IEnumerable<VectorbaseEntry> Find(string text, FindOptions options = default)
    {
        options ??= new FindOptions();
        if (_todo.Count > 0)
            ProcessToDo();
        ReadOnlyMemory<float> textVector = GetEmbedding(text);
        IEnumerable<VectorbaseEntry> nearest = _store.Find(textVector, options);
        return nearest;
    }

    private void ProcessToDo()
    {
        lock (_todo)
        {
            var embeddings = _client.GenerateEmbeddings(_todo);

            foreach (var embedding in embeddings.Value)
            {
                ReadOnlyMemory<float> vector = embedding.ToFloats();
                string item = _todo[(int)embedding.Index];
                _store.Add(new VectorbaseEntry(vector, BinaryData.FromString(item)));
            }
            _todo.Clear();
        }
    }

    private ReadOnlyMemory<float> GetEmbedding(string fact)
    {
        var embedding = _client.GenerateEmbedding(fact);
        return embedding.Value.ToFloats();
    }
}

/// <summary>
/// The options for finding entries in the vectorbase.
/// </summary>
public class FindOptions
{
    /// <summary>
    /// The maximum number of entries to return.
    /// </summary>
    public int MaxEntries { get; set; } = 3;

    /// <summary>
    /// The threshold for the cosine similarity.
    /// </summary>
    public float Threshold { get; set; } = 0.25f;
}
