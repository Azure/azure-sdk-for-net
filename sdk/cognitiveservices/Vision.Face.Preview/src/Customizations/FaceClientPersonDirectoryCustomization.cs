using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.CognitiveServices.Vision.Face
{
    public partial class FaceClient
    {
        partial void CustomInitialize()
        {
            PersonDirectoryExtensions.asyncOperationAction = this.Snapshot.GetOperationStatusAsync;
            //PersonDirectoryExtensions.asyncOperationAction = (Guid operationId, CancellationToken cancellationToken) => SnapshotOperationsExtensions.GetOperationStatusAsync(this.Snapshot, operationId, cancellationToken);
        }
    }
}
