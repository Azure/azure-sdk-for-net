using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Batch.Protocol.Models
{
    internal interface IProtocolNodeFile
    {
        Guid? ClientRequestId { get; set; }

        Guid? RequestId { get; set; }

        string ETag { get; set; }

        DateTime? LastModified { get; set; }

        DateTime? OcpCreationTime { get; set; }

        bool? OcpBatchFileIsdirectory { get; set; }

        string OcpBatchFileUrl { get; set; }

        string OcpBatchFileMode { get; set; }

        string ContentType { get; set; }

        long? ContentLength { get; set; }
    }

    public partial class FileGetPropertiesFromTaskHeaders : IProtocolNodeFile { }

    public partial class FileGetFromTaskHeaders : IProtocolNodeFile { }

    public partial class FileGetFromComputeNodeHeaders : IProtocolNodeFile { }

    public partial class FileGetPropertiesFromComputeNodeHeaders : IProtocolNodeFile { }
}
