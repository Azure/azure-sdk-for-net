// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Azure;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests
{
    public class TestPageable<T> : Pageable<T>
    {
        private IEnumerable<T> enumerable;

        public TestPageable(IEnumerable<T> enumerable)
        {
            this.enumerable = enumerable;
        }

        public override IEnumerable<Page<T>> AsPages(string continuationToken = null, int? pageSizeHint = null)
        {
            var items = enumerable.ToList();

            if (items.Count == 0)
            {
                yield return Page<T>.FromValues(new List<T>(), null, null);
                yield break;
            }

            List<List<T>> pages = ChunkBy(items, pageSizeHint ?? 1000);

            int start = 0;
            if (continuationToken != null)
            {
                start = int.Parse(continuationToken, CultureInfo.InvariantCulture);
            }

            for (int i = start; i < pages.Count; i++)
            {
                string token = null;
                if (i < pages.Count - 1)
                {
                    token = (i + 1).ToString(CultureInfo.InvariantCulture);
                }
                yield return Page<T>.FromValues(pages[i], token, null);
            }
        }

        private static List<List<T2>> ChunkBy<T2>(List<T2> source, int chunkSize)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
    }
}
