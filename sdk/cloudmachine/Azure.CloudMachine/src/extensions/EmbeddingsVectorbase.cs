﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System;
using OpenAI.Embeddings;

namespace Azure.CloudMachine.OpenAI;

/// <summary>
/// The vectorbase for storing embeddings.
/// </summary>
public class EmbeddingsVectorbase
{
    private readonly EmbeddingClient _client;
    private readonly VectorbaseStore _store;
    private readonly List<string> _todo = new List<string>();
    private readonly int _chuckSize;

    /// <summary>
    /// Initializes a new instance of the <see cref="EmbeddingsVectorbase"/> class.
    /// </summary>
    /// <param name="client"></param>
    /// <param name="store"></param>
    /// <param name="factChunkSize"></param>
    public EmbeddingsVectorbase(EmbeddingClient client, VectorbaseStore store = default, int factChunkSize = 1000)
    {
        _client = client;
        _store = store ?? new MemoryVectorbaseStore();
        _chuckSize = factChunkSize;
    }

    /// <summary>
    /// Adds an entry to the vectorbase.
    /// </summary>
    /// <param name="text"></param>
    public void Add(string text)
    {
        lock (_todo)
        {
            ChunkFactAndAddToTodo(text, _chuckSize);
        }
    }

    /// <summary>
    /// Adds an entry to the vectorbase. The media type must be "text/plain".
    /// </summary>
    /// <param name="data"></param>
    /// <exception cref="InvalidOperationException"></exception>
    public void Add(BinaryData data)
    {
        if (data.MediaType != "text/plain") throw new InvalidOperationException("Only text/plain media type is supported.");
        Add(data.ToString());
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

    private void ChunkFactAndAddToTodo(string text, int chunkSize)
    {
        if (chunkSize <= 100)
        {
            _todo.Add(text);
            return;
        }

        int overlapSize = (int)(chunkSize * 0.15);
        int stepSize = chunkSize - overlapSize;
        ReadOnlySpan<char> textSpan = text.AsSpan();

        for (int i = 0; i < text.Length; i += stepSize)
        {
            while (i > 0 && !char.IsWhiteSpace(textSpan[i]))
            {
                i--;
            }
            if (i + chunkSize > text.Length)
            {
                _todo.Add(textSpan.Slice(i).ToString());
            }
            else
            {
                int end = i + chunkSize;
                if (end > text.Length)
                {
                    _todo.Add(textSpan.Slice(i).ToString());
                }
                else
                {
                    while (end < text.Length && !char.IsWhiteSpace(textSpan[end]))
                    {
                        end++;
                    }
                    _todo.Add(textSpan.Slice(i, end - i).ToString());
                }
            }
        }
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
    public float Threshold { get; set; } = 0.29f;
}
