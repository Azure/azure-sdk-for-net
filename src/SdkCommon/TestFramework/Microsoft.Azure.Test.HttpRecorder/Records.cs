// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Microsoft.Azure.Test.HttpRecorder
{
    [SuppressMessage("Microsoft.Usage", "CA2237:MarkISerializableTypesWithSerializable")]
    public class Records
    {
        private Dictionary<string, Queue<RecordEntry>> sessionRecords;

        private IRecordMatcher matcher;

        public Records(IRecordMatcher matcher)
            : this(new Dictionary<string, Queue<RecordEntry>>(), matcher) { }

        public Records(Dictionary<string, Queue<RecordEntry>> records, IRecordMatcher matcher)
        {
            this.sessionRecords = new Dictionary<string, Queue<RecordEntry>>(records);
            this.matcher = matcher;
        }

        public void Enqueue(RecordEntry record)
        {
            string recordKey = matcher.GetMatchingKey(record);
            if (!sessionRecords.ContainsKey(recordKey))
            {
                sessionRecords[recordKey] = new Queue<RecordEntry>();
            }
            sessionRecords[recordKey].Enqueue(record);
        }

        public Queue<RecordEntry> this[string key]
        {
            get
            {
                if (sessionRecords.ContainsKey(key))
                {
                    return sessionRecords[key];
                }
                else
                {
                    throw new KeyNotFoundException(
                        string.Format("Unable to find a matching HTTP request for URL '{0}'. Calling method {1}().", 
                            RecorderUtilities.DecodeBase64AsUri(key), 
                            GetCallingMethodName()));
                }
            }
            set { sessionRecords[key] = value; }
        }

        private string GetCallingMethodName([System.Runtime.CompilerServices.CallerMemberName]
            string methodName="Getting_CallingMethodName_Failed_Your_Test_Will_Fail")
        {
            return methodName;
        }

        public IEnumerable<RecordEntry> GetAllEntities()
        {
            foreach (var queues in sessionRecords.Values)
            {
                while (queues.Count > 0)
                {
                    yield return queues.Dequeue();
                }
            }
        }

        public int Count
        {
            get { return sessionRecords.Values.Select(q => q.Count).Sum(); }
        }

        public void EnqueueRange(List<RecordEntry> records)
        {
            foreach (RecordEntry recordEntry in records)
            {
                Enqueue(recordEntry);
            }
        }
    }
}
