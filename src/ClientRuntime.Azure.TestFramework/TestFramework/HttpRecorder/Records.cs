// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Microsoft.Rest.ClientRuntime.Azure.TestFramework.HttpRecorder
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
                            Utilities.DecodeBase64AsUri(key), 
                            GetCallingMethodName()));
                }
            }
            set { sessionRecords[key] = value; }
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

        private string GetCallingMethodName()
        {
            StackTrace st = new StackTrace();
            int depth = 3;
            StackFrame sf = st.GetFrame(depth);
            string methodName = string.Empty;
            bool foundSendAsync = false;
            while (sf != null)
            {
                depth++;
                sf = st.GetFrame(depth);
                if (sf != null)
                {
                    methodName = sf.GetMethod().Name;
                }
                if (methodName == "SendAsync")
                {
                    foundSendAsync = true;
                }
                if (foundSendAsync && 
                    methodName != "MoveNext" &&
                    methodName != "SendAsync" &&
                    methodName != "Start")
                {
                    break;
                }
            }

            return methodName;
        }
    }
}
