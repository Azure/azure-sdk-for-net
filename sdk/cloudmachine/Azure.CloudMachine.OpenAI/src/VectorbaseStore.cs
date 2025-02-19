// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System;

namespace Azure.Projects.OpenAI;

/// <summary>
/// The base class for a vectorbase store.
/// </summary>
public abstract class VectorbaseStore
{
    /// <summary>
    /// Finds entries in the vectorbase.
    /// </summary>
    /// <param name="vector"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public abstract IEnumerable<VectorbaseEntry> Find(ReadOnlyMemory<float> vector, FindOptions options);

    /// <summary>
    /// Adds an entry to the vectorbase.
    /// </summary>
    /// <param name="entry"></param>
    /// <returns></returns>
    public abstract int Add(VectorbaseEntry entry);

    /// <summary>
    /// Adds a list of entries to the vectorbase.
    /// </summary>
    /// <param name="entry"></param>
    public abstract void Add(IReadOnlyList<VectorbaseEntry> entry);

    /// <summary>
    /// Calculates the cosine similarity between two vectors.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public static float CosineSimilarity(ReadOnlySpan<float> x, ReadOnlySpan<float> y)
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
}

/// <summary>
/// A vectorbase entry.
/// </summary>

public readonly struct VectorbaseEntry
{
    /// <summary>
    /// Initializes a new instance of the <see cref="VectorbaseEntry"/> class.
    /// </summary>
    /// <param name="vector"></param>
    /// <param name="data"></param>
    /// <param name="id"></param>
    public VectorbaseEntry(ReadOnlyMemory<float> vector, BinaryData data, int? id = default)
    {
        Vector = vector;
        Data = data;
        Id = id;
    }

    /// <summary>
    /// Gets the data associated with the entry.
    /// </summary>
    public BinaryData Data { get; }

    /// <summary>
    /// Gets the vector associated with the entry.
    /// </summary>
    public ReadOnlyMemory<float> Vector { get; }

    /// <summary>
    /// Gets the id associated with the entry.
    /// </summary>
    public int? Id { get; }
}
