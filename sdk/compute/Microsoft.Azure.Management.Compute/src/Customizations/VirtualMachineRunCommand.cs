using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Compute.Models
{
    public partial class VirtualMachineRunCommand : Resource
    {
        public VirtualMachineRunCommand(string location, string id, string name, string type, IDictionary<string, string> tags, VirtualMachineRunCommandScriptSource source, IList<RunCommandInputParameter> parameters, IList<RunCommandInputParameter> protectedParameters, bool? asyncExecution, string runAsUser, string runAsPassword, int? timeoutInSeconds, string outputBlobUri, string errorBlobUri,string provisioningState, VirtualMachineRunCommandInstanceView instanceView)
            : base(location, id, name, type, tags)
        {
            Source = source;
            Parameters = parameters;
            ProtectedParameters = protectedParameters;
            AsyncExecution = asyncExecution;
            RunAsUser = runAsUser;
            RunAsPassword = runAsPassword;
            TimeoutInSeconds = timeoutInSeconds;
            OutputBlobUri = outputBlobUri;
            ErrorBlobUri = errorBlobUri;
            ProvisioningState = provisioningState;
            InstanceView = instanceView;
            CustomInit();
        }
    }
}