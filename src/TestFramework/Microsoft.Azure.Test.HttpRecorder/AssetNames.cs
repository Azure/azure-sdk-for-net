// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Azure.Test.HttpRecorder
{
    /// <summary>
    /// This data structure is used to record the asset names (like website name, etc..) 
    /// used when doing the record mode. Stored names will be used in the playback mode
    /// to mock the exact behavior of the original test.
    /// </summary>
    [SuppressMessage("Microsoft.Usage", "CA2237:MarkISerializableTypesWithSerializable")]
    public class AssetNames : IEnumerable<KeyValuePair<string, Queue<string>>>
    {
        public Dictionary<string, Queue<string>> Names { get; private set; }

        public AssetNames()
        {
            Names = new Dictionary<string, Queue<string>>();
        }

        /// <summary>
        /// Initialize collection
        /// </summary>
        /// <param name="assetNames"></param>
        public AssetNames(Dictionary<string, Queue<string>> assetNames)
        {
            Names = new Dictionary<string, Queue<string>>(assetNames);
        }

        public void Enqueue(string testName, string assetName)
        {
            if (!Names.ContainsKey(testName))
            {
                Names[testName] = new Queue<string>();
            }
            Names[testName].Enqueue(assetName);
        }

        public void Enqueue(string testName, string[] names)
        {
            if (!Names.ContainsKey(testName))
            {
                Names[testName] = new Queue<string>();
            }

            names.ForEach(a => Names[testName].Enqueue(a));
        }

        public void EnqueueRange(Dictionary<string, string[]> names)
        {
            if (names != null)
            {
                foreach (KeyValuePair<string, string[]> item in names)
                {
                    Enqueue(item.Key, item.Value);
                }
            }
        }

        public Queue<string> this[string testName]
        {
            get { return Names[testName]; }
            set { Names[testName] = value; }
        }

        public bool ContainsKey(string testName)
        {
            return Names.ContainsKey(testName);
        }

        public IEnumerator<KeyValuePair<string, Queue<string>>> GetEnumerator()
        {
            return Names.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Names.GetEnumerator();
        }
    }
}
