// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using OpenAI.Embeddings;

namespace Azure.CloudMachine.OpenAI;

/// <summary>
/// Represents a knowledgebase of facts represented by embeddings that can be used to find relevant facts based on a given text.
/// </summary>
public class EmbeddingKnowledgebase
{
    private EmbeddingClient _client;
    private List<string> _factsToProcess = new List<string>();

    private List<ReadOnlyMemory<float>> _vectors = new List<ReadOnlyMemory<float>>();
    private List<string> _facts = new List<string>();

    internal EmbeddingKnowledgebase(EmbeddingClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Add a fact to the knowledgebase.
    /// </summary>
    /// <param name="fact">The fact to add.</param>
    public void Add(string fact)
    {
        ChunkAndAddToFactsToProcess(fact, 1000);
        ProcessUnprocessedFacts();
    }

    internal List<Fact> FindRelevantFacts(string text, float threshold = 0.29f, int top = 3)
    {
        if (_factsToProcess.Count > 0)
            ProcessUnprocessedFacts();

        ReadOnlySpan<float> textVector = ProcessFact(text).Span;

        var results = new List<Fact>();
        var distances = new List<(float Distance, int Index)>();
        for (int index = 0; index < _vectors.Count; index++)
        {
            ReadOnlyMemory<float> dbVector = _vectors[index];
            float distance = 1.0f - CosineSimilarity(dbVector.Span, textVector);
            distances.Add((distance, index));
        }
        distances.Sort(((float D1, int I1) v1, (float D2, int I2) v2) => v1.D1.CompareTo(v2.D2));

        top = Math.Min(top, distances.Count);
        for (int i = 0; i < top; i++)
        {
            var distance = distances[i].Distance;
            if (distance > threshold)
                break;
            var index = distances[i].Index;
            results.Add(new Fact(_facts[index], index));
        }
        return results;
    }

    private static float CosineSimilarity(ReadOnlySpan<float> x, ReadOnlySpan<float> y)
    {
        float dot = 0, xSumSquared = 0, ySumSquared = 0;

        for (int i = 0; i < x.Length; i++)
        {
            dot += x[i] * y[i];
            xSumSquared += x[i] * x[i];
            ySumSquared += y[i] * y[i];
        }
        return dot / (MathF.Sqrt(xSumSquared) * MathF.Sqrt(ySumSquared));
    }

    private void ProcessUnprocessedFacts()
    {
        if (_factsToProcess.Count == 0)
        {
            return;
        }
        var embeddings = _client.GenerateEmbeddings(_factsToProcess);

        foreach (var embedding in embeddings.Value)
        {
            _vectors.Add(embedding.ToFloats());
            _facts.Add(_factsToProcess[embedding.Index]);
        }

        _factsToProcess.Clear();
    }

    private ReadOnlyMemory<float> ProcessFact(string fact)
    {
        var embedding = _client.GenerateEmbedding(fact);

        return embedding.Value.ToFloats();
    }

    internal void ChunkAndAddToFactsToProcess(string text, int chunkSize)
    {
        if (chunkSize <= 0)
        {
            throw new ArgumentException("Chunk size must be greater than zero.", nameof(chunkSize));
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
                _factsToProcess.Add(textSpan.Slice(i).ToString());
            }
            else
            {
                int end = i + chunkSize;
                if (end > text.Length)
                {
                    _factsToProcess.Add(textSpan.Slice(i).ToString());
                }
                else
                {
                    while (end < text.Length && !char.IsWhiteSpace(textSpan[end]))
                    {
                        end++;
                    }
                    _factsToProcess.Add(textSpan.Slice(i, end - i).ToString());
                }
            }
        }
    }
    internal struct Fact
    {
        public Fact(string text, int id)
        {
            Text = text;
            Id = id;
        }

        public string Text { get; set; }
        public int Id { get; set; }
    }
}
