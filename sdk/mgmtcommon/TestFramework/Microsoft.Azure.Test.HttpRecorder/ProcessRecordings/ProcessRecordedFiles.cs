using Microsoft.Azure.Test.HttpRecorder.ProcessRecordings.Processors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Test.HttpRecorder.ProcessRecordings
{
    public class ProcessRecordedFiles
    {
        public string BackupFilePath { get; set; }

        public string OriginalFilePath { get; private set; }
        List<IRecordingProcessor> ProcessorList { get; }

        public RecordEntryPack OriginalRecordedPack { get; }

        public RecordEntryPack ProcessedPack { get; internal set; }

        public ProcessRecordedFiles()
        {
            ProcessorList = new List<IRecordingProcessor>();
        }

        public ProcessRecordedFiles(string recordedFilePath): this()
        {
            if(File.Exists(recordedFilePath))
            {
                OriginalRecordedPack = RecordEntryPack.Deserialize(recordedFilePath);
                OriginalFilePath = recordedFilePath;
                BackupFilePath = string.Concat(Path.Combine(Path.GetDirectoryName(recordedFilePath), Path.GetFileNameWithoutExtension(recordedFilePath)), ".pijson");
            }
        }

        public void CompactLroPolling()
        {
            CompactLroEntries compactLro = new CompactLroEntries();
            compactLro.Process(OriginalRecordedPack);
            ProcessedPack = compactLro.ProcessedEntryPack;
            ProcessedPack.Variables = OriginalRecordedPack.Variables;
            ProcessedPack.Names = OriginalRecordedPack.Names;
        }

        public void SerializeCompactData(string filePath = "")
        {
            if(string.IsNullOrEmpty(filePath))
            {
                ProcessedPack.Serialize(OriginalFilePath);
            }
            else
            {
                ProcessedPack.Serialize(filePath);
            }

            OriginalRecordedPack.Serialize(BackupFilePath);
        }
    }
}
