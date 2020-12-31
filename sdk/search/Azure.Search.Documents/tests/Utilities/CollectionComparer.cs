// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Tests
{
    public class CollectionComparer<T> : IEqualityComparer<ICollection<T>>
    {
        public static CollectionComparer<T> Shared { get; } = new CollectionComparer<T>();

        // TODO: Remove null or empty comparison when https://github.com/Azure/autorest.csharp/issues/521 is fixed.
        public static CollectionComparer<T> SharedNullOrEmpty { get; } = new CollectionComparer<T>(compareNullOrEmpty: true);

        public CollectionComparer(IEqualityComparer<T> elementComparer = null, bool compareNullOrEmpty = false)
        {
            ElementComparer = elementComparer ?? EqualityComparer<T>.Default;
            CompareNullOrEmpty = compareNullOrEmpty;
        }

        public IEqualityComparer<T> ElementComparer { get; }

        public bool CompareNullOrEmpty { get; }

        public bool Equals(ICollection<T> x, ICollection<T> y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }
            else if (x is null)
            {
                return CompareNullOrEmpty && y.Count == 0;
            }
            else if (y is null)
            {
                return CompareNullOrEmpty && x.Count == 0;
            }

            if (x.Count != y.Count)
            {
                return false;
            }

            IEnumerator<T> xEnum = x.GetEnumerator();
            IEnumerator<T> yEnum = y.GetEnumerator();

            while (xEnum.MoveNext() && yEnum.MoveNext())
            {
                if (!ElementComparer.Equals(xEnum.Current, yEnum.Current))
                {
                    return false;
                }
            }

            return true;
        }

        public int GetHashCode(ICollection<T> obj)
        {
            if (obj is null)
            {
                return 0;
            }

            HashCodeBuilder builder = new HashCodeBuilder();

            foreach (T element in obj)
            {
                builder.Add(element, ElementComparer);
            }

            return builder.ToHashCode();
        }
    }
}
