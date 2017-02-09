// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Microsoft.Azure.Test.HttpRecorder
{
    public class RecordEntryPack
    {
        public List<RecordEntry> Entries { get; set; }
        public Dictionary<string, Queue<string>> Names { get; set; }
        public Dictionary<string, string> Variables { get; set; }

        public RecordEntryPack()
        {
            Entries = new List<RecordEntry>();
        }

        public static RecordEntryPack Deserialize(string path)
        {
            return Utilities.DeserializeJson<RecordEntryPack>(path);
        }

        public void Serialize(string path)
        {
            Utilities.SerializeJson(this, path);
        }
    }
}
