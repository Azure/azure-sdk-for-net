// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;

namespace Azure.Projects.Core;

/// <summary>
/// A collection of <see cref="AzureProjectFeature"/> instances that supports safe enumeration during modification.
/// </summary>
public class FeatureCollection : IEnumerable<AzureProjectFeature>
{
    private AzureProjectFeature[] _features = new AzureProjectFeature[4];
    private Dictionary<string, int> _featureIndex = new(StringComparer.OrdinalIgnoreCase);
    private int _count;

    internal FeatureCollection() { }

    /// <summary>
    /// Returns all features of the specified type.
    /// </summary>
    /// <typeparam name="T">The feature type to find.</typeparam>
    /// <returns>An enumerable of matching features.</returns>
    public IEnumerable<T> FindAll<T>() where T : AzureProjectFeature
    {
        for (int i = 0; i < _count; i++)
        {
            if (_features[i] is T item)
            {
                yield return item;
            }
        }
    }

    /// <summary>
    /// Attempts to find the first feature of the specified type.
    /// </summary>
    /// <typeparam name="T">The feature type to find.</typeparam>
    /// <param name="feature">When this method returns, contains the first matching feature, or <see langword="null"/> if none was found.</param>
    /// <returns><see langword="true"/> if a matching feature was found; otherwise, <see langword="false"/>.</returns>
    public bool TryGet<T>(out T? feature) where T : AzureProjectFeature
    {
        string name = typeof(T).FullName!;
        return TryGet(name, out feature);
    }

    /// <summary>
    /// Attempts to find a feature of the specified type with the given identifier.
    /// </summary>
    /// <typeparam name="T">The feature type to find.</typeparam>
    /// <param name="id">The identifier to match.</param>
    /// <param name="feature">When this method returns, contains the matching feature, or <see langword="null"/> if none was found.</param>
    /// <returns><see langword="true"/> if a matching feature was found; otherwise, <see langword="false"/>.</returns>
    public bool TryGet<T>(string id, out T? feature) where T : AzureProjectFeature
    {
        for (int i = 0; i < _count; i++)
        {
            var item = _features[i];
            if (item.Id == id && item is T typed)
            {
                feature = typed;
                return true;
            }
        }
        feature = default;
        return false;
    }

    /// <summary>
    /// Appends a feature to this collection.
    /// </summary>
    /// <param name="feature">The feature to append.</param>
    public void Append(AzureProjectFeature feature)
    {
        if (_count == _features.Length)
        {
            Resize();
        }
        _features[_count++] = feature;

        void Resize()
        {
            var newItems = new AzureProjectFeature[_features.Length * 2];
            Array.Copy(_features, newItems, _features.Length);
            _features = newItems;
        }
    }

    /// <summary>
    /// Returns an enumerator that iterates through the features in this collection.
    /// </summary>
    /// <returns>An enumerator of <see cref="AzureProjectFeature"/> instances.</returns>
    public IEnumerator<AzureProjectFeature> GetEnumerator()
    {
        for (int i = 0; i < _count; i++)
        {
            yield return _features[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    /// <summary>
    /// Creates a unique Bicep identifier by appending a numeric suffix when collisions occur.
    /// </summary>
    /// <param name="baseIdentifier">The base identifier to make unique.</param>
    /// <returns>A unique Bicep identifier string.</returns>
    public string CreateUniqueBicepIdentifier(string baseIdentifier)
    {
        lock (_featureIndex)
        {
            if (_featureIndex.TryGetValue(baseIdentifier, out int index))
            {
                _featureIndex[baseIdentifier] = index + 1;
                return $"{baseIdentifier}{index}";
            }
            else
            {
                _featureIndex[baseIdentifier] = 2;
                return baseIdentifier;
            }
        }
    }
}
