using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Batch.Protocol.Models
{
    internal interface IProtocolNodeFile
    {
        string ClientRequestId { get; set; }
        
        string RequestId { get; set; }

        string ETag { get; set; }
        
        DateTime? LastModified { get; set; }
        
        DateTime? OcpCreationTime { get; set; }
        
        bool? OcpBatchFileIsdirectory { get; set; }
        
        string OcpBatchFileUrl { get; set; }

        string OcpBatchFileMode { get; set; }

        string ContentType { get; set; }
        
        long? ContentLength { get; set; }
    }

    public partial class FileGetNodeFilePropertiesFromTaskHeaders : IProtocolNodeFile { }

    public partial class FileGetFromTaskHeaders : IProtocolNodeFile { } 

    public partial class FileGetFromComputeNodeHeaders : IProtocolNodeFile { }

    public partial class FileGetNodeFilePropertiesFromComputeNodeHeaders : IProtocolNodeFile { }
}
