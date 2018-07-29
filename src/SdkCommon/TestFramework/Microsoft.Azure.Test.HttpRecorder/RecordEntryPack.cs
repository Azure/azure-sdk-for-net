// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Test.HttpRecorder
{
    public class RecordEntryPack
    {
        [JsonIgnore]
        public List<RequestResponseInfo> RRInfoRecordEntry { get; set; }

        public List<RecordEntry> Entries { get; set; }
        public Dictionary<string, Queue<string>> Names { get; set; }
        public Dictionary<string, string> Variables { get; set; }

        public RecordEntryPack()
        {
            Entries = new List<RecordEntry>();
            RRInfoRecordEntry = new List<RequestResponseInfo>();
        }

        public static RecordEntryPack Deserialize(string path)
        {
            return RecorderUtilities.DeserializeJson<RecordEntryPack>(path);
        }

        public RecordEntryPack Deserialize(string path, bool extractMetaData)
        {
            RecordEntryPack rePack = Deserialize(path);

            if (rePack != null && extractMetaData)
            {
                RRInfoRecordEntry.AddRange(rePack.Entries.Select<RecordEntry, RequestResponseInfo>((re) => new RequestResponseInfo(re)));
            }

            return rePack;
        }

        public void Serialize(string path)
        {
            RecorderUtilities.SerializeJson(this, path);
        }
    }
}
