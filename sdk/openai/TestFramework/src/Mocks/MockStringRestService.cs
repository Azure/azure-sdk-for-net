// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;

namespace OpenAI.TestFramework.Mocks
{
    public class MockStringRestService(ushort port = 0) : MockRestService<string>("data", port)
    {
        private ConcurrentDictionary<string, string> _data = new();

        public override IEnumerable<Entry> GetAll()
            => _data.Select(kvp => new Entry(kvp.Key, kvp.Value));

        public override bool TryAdd(string id, string? data, out Entry? entry)
        {
            entry = null;

            if (_data.TryAdd(id, data!))
            {
                entry = new(id, data!);
                return true;
            }

            return false;
        }

        public override bool TryDelete(string id)
            => _data.TryRemove(id, out _);

        public override bool TryGet(string id, out Entry? entry)
        {
            if (_data.TryGetValue(id, out string? value))
            {
                entry = new(id, value);
                return true;
            }

            entry = null;
            return false;
        }

        public override bool TryUpdate(string id, string? data, out Entry? entry)
        {
            _data[id] = data!;
            entry = new(id, data!);
            return true;
        }

        public override void Reset() => _data.Clear();
    }
}
