using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Test.HttpRecorder.ProcessRecordings.Processors
{
    public class CompactLroEntries: IRecordingProcessor
    {
        Queue<RecordEntry> EntryPackCloneQueue;
        Stack<RecordEntry> lroStack;

        RecordEntryPack _processedEntryPack;

        public CompactLroEntries()
        {
            EntryPackCloneQueue = new Queue<RecordEntry>();
            lroStack = new Stack<RecordEntry>();
        }

        public string ProcessorName { get => "CompactLroEntries"; protected set => ProcessorName = value; }

        public RecordEntryPack ProcessedEntryPack
        {
            get
            {
                if(_processedEntryPack == null)
                {
                    _processedEntryPack = new RecordEntryPack();
                }

                return _processedEntryPack;
            }
        }

        public void Process(RecordEntryPack recordEntryPack)
        {
            foreach(RecordEntry rec in recordEntryPack.Entries)
            {
                if(IsLroEntry(rec))
                {
                    lroStack.Push(rec);
                }
                else
                {
                    if(lroStack.Any<RecordEntry>())
                    {
                        UpdateCloneQueueFromStack();
                    }

                    EntryPackCloneQueue.Enqueue(rec);
                }
            }


            if(lroStack.Any<RecordEntry>())
            {
                UpdateCloneQueueFromStack();
            }

            if(EntryPackCloneQueue.Any<RecordEntry>())
            {
               ProcessedEntryPack.Entries =  EntryPackCloneQueue.ToList<RecordEntry>();
            }
        }


        private void UpdateCloneQueueFromStack()
        {
            int takeLastCount = 2;
            if (lroStack.Any<RecordEntry>())
            {
                Stack<RecordEntry> tempStack = new Stack<RecordEntry>();
                int popCount = 1;

                while (lroStack.Count > 0)
                {
                    if (popCount <= takeLastCount)
                    {
                        tempStack.Push(lroStack.Pop());
                        popCount++;
                    }
                    else
                    {
                        lroStack.Clear();
                        break;
                    }
                }

                while(tempStack.Count > 0)
                {
                    EntryPackCloneQueue.Enqueue(tempStack.Pop());
                }
            }
        }


        internal bool IsLroEntry(RecordEntry re)
        {
            return re.RequestHeaders.ContainsKey("RecordPlaybackPerfImpact");
        }
    }

    public interface IRecordingProcessor
    {
        string ProcessorName { get; }

        void Process(RecordEntryPack recordEntryPack);

        RecordEntryPack ProcessedEntryPack { get; }
    }
}
