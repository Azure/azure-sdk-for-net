// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Models;
    using System.Collections.Generic;
    using System;
    using Newtonsoft.Json.Linq;
    using ResourceManager.Fluent.Core;

    /// <summary>
    /// The implementation for DiskVolumeEncryptionStatus for Linux virtual machine.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uTGludXhEaXNrVm9sdW1lRW5jcnlwdGlvbk1vbml0b3JJbXBs
    internal partial class LinuxDiskVolumeEncryptionMonitorImpl  :
        IDiskVolumeEncryptionMonitor
    {
        private string rgName;
        private string vmName;
        private IComputeManager computeManager;
        private VirtualMachineExtensionInner encryptionExtension;
        /// <summary>
        /// Creates LinuxDiskVolumeEncryptionMonitorImpl.
        /// </summary>
        /// <param name="virtualMachineId">Resource id of Linux virtual machine to retrieve encryption status from.</param>
        /// <param name="computeManager">Compute manager.</param>
        ///GENMHASH:A42CB27228CC0FEEF184DFCCC4F8DCB2:0C2BFB2332C823A9307222D73EFBAF83
        internal  LinuxDiskVolumeEncryptionMonitorImpl(string virtualMachineId, IComputeManager computeManager)
        {
            this.rgName = ResourceUtils.GroupFromResourceId(virtualMachineId);
            this.vmName = ResourceUtils.NameFromResourceId(virtualMachineId);
            this.computeManager = computeManager;
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:FF7924BFEF46CE7F250D6F5B1A727744
        public IDiskVolumeEncryptionMonitor Refresh()
        {
            return ResourceManager.Fluent.Core.Extensions.Synchronize(() => RefreshAsync());
        }

        /// <return>The instance view status collection associated with the encryption extension.</return>
        ///GENMHASH:DF6D090576A3266E52582EE3F48781B1:FE003BD6635A94757D4D94620D2271C0
        private IList<Models.InstanceViewStatus> InstanceViewStatuses()
        {
            if (!HasEncryptionExtension()) {
                return new List<InstanceViewStatus>();
            }
            VirtualMachineExtensionInstanceView instanceView = this.encryptionExtension.InstanceView;
            if (instanceView == null
            || instanceView.Statuses == null) {
                return new List<InstanceViewStatus>();
            }
            return instanceView.Statuses;
        }

        /// <summary>
        /// Retrieve the extension with latest state. If the extension could not be found then
        /// an empty observable will be returned.
        /// </summary>
        /// <param name="extension">The extension name.</param>
        /// <return>An observable that emits the retrieved extension.</return>
        ///GENMHASH:8B810B2C467EB2B9F131F38236BA630F:FA32EDB4C3CE589CF08191999C2005C5
        private async Task<Models.VirtualMachineExtensionInner> RetrieveExtensionWithInstanceViewAsync(VirtualMachineExtensionInner extension, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.computeManager
                    .Inner
                    .VirtualMachineExtensions
                    .GetAsync(rgName, vmName, extension.Name, "instanceView", cancellationToken);
        }

        ///GENMHASH:CFF730CD005B7D5386D59ADCF7C33D0C:80F0D0455B27E848B9196C7D1768B4DB
        public EncryptionStatus DataDiskStatus()
        {
            if (!HasEncryptionExtension()) {
                return EncryptionStatus.NotEncrypted;
            }
            string subStatusJson = InstanceViewFirstSubStatus();
            if (subStatusJson == null) {
                return EncryptionStatus.Unknown;
            }
            if (subStatusJson == null)
            {
                return EncryptionStatus.Unknown;
            }
            JObject jObject = JObject.Parse(subStatusJson);
            if (jObject["data"] == null)
            {
                return EncryptionStatus.Unknown;
            }
            return EncryptionStatus.Parse((string)jObject["data"]);
        }

        /// <return>
        /// The first sub-status from instance view sub-status collection associated with the
        /// encryption extension.
        /// </return>
        ///GENMHASH:41E2F45F0E1CC7217B8CEF67918CFBD9:327967FA4D7F005F7016223268CC352F
        private string InstanceViewFirstSubStatus()
        {
            if (!HasEncryptionExtension()) {
                return null;
            }
            VirtualMachineExtensionInstanceView instanceView = this.encryptionExtension.InstanceView;
            if (instanceView == null
                || instanceView.Substatuses == null) {
                return null;
            }
            IList<InstanceViewStatus> instanceViewSubStatuses = instanceView.Substatuses;
            if (instanceViewSubStatuses.Count == 0) {
                return null;
            }
            return instanceViewSubStatuses[0].Message;
        }

        ///GENMHASH:1BAF4F1B601F89251ABCFE6CC4867026:14DA61D401D0341BDBDB99994BA6DA1F
        public OperatingSystemTypes OSType()
        {
            return OperatingSystemTypes.Linux;
        }

        ///GENMHASH:D1037603B1F11C451DD830F07021E503:1E738399F355D89FDD840DEFB7CAE473
        public EncryptionStatus OSDiskStatus()
        {
            if (!HasEncryptionExtension()) {
                return EncryptionStatus.NotEncrypted;
            }
            if (!HasEncryptionExtension())
            {
                return EncryptionStatus.NotEncrypted;
            }
            string subStatusJson = InstanceViewFirstSubStatus();
            if (subStatusJson == null)
            {
                return EncryptionStatus.Unknown;
            }
            JObject jObject = JObject.Parse(subStatusJson);
            if (jObject["os"] == null)
            {
                return EncryptionStatus.Unknown;
            }
            return EncryptionStatus.Parse((string)jObject["os"]);
        }

        ///GENMHASH:5A2D79502EDA81E37A36694062AEDC65:1983032392C8C2C0E86D7F672D2737DF
        public async Task<Microsoft.Azure.Management.Compute.Fluent.IDiskVolumeEncryptionMonitor> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // Refreshes the cached encryption extension installed in the Linux virtual machine.
            VirtualMachineExtensionInner virtualMachineExtensionInner = await RetrieveEncryptExtensionWithInstanceViewAsync(cancellationToken);
            if (virtualMachineExtensionInner != null)
            {
                this.encryptionExtension = virtualMachineExtensionInner;
            }
            return this;
        }

        /// <summary>
        /// Retrieves the latest state of encryption extension in the virtual machine.
        /// </summary>
        /// <return>The retrieved extension.</return>
        ///GENMHASH:0D7229D8D998BA64BC9507355D492994:3CAE38CC4AFCD502C95C2524E812168D
        private async Task<Models.VirtualMachineExtensionInner> RetrieveEncryptExtensionWithInstanceViewAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (encryptionExtension != null) {
                // If there is already a cached extension simply retrieve it again with instance view.
                //
                return await RetrieveExtensionWithInstanceViewAsync(encryptionExtension, cancellationToken);
            } else {
                // Extension is not cached already so retrieve name from the virtual machine and
                // then get the extension with instance view.
                //
                return await RetrieveEncryptExtensionWithInstanceViewFromVMAsync(cancellationToken);
            }
        }

        /// <summary>
        /// Retrieve the encryption extension from the virtual machine and then retrieve it again with instance view expanded.
        /// If the virtual machine does not exists then an error observable will be returned, if the extension could not be
        /// located then an empty observable will be returned.
        /// </summary>
        /// <return>The retrieved extension.</return>
        ///GENMHASH:F5645D5F0FF252C17769B3B4778AD204:9A94E8179A8202B9101EC72C66DB254C
        private async Task<Models.VirtualMachineExtensionInner> RetrieveEncryptExtensionWithInstanceViewFromVMAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            VirtualMachineInner virtualMachine = await this.computeManager
                .Inner
                .VirtualMachines
                .GetAsync(rgName, vmName, cancellationToken: cancellationToken);
                
            if (virtualMachine == null)
            {
                new Exception($"VM with name '{vmName}' not found (resource group '{rgName}')");
            }
            if (virtualMachine.Resources != null)
            {
                foreach (var extension in virtualMachine.Resources)
                {
                    if (extension.Publisher.Equals("Microsoft.Azure.Security", StringComparison.OrdinalIgnoreCase)
                        && extension.VirtualMachineExtensionType.Equals("AzureDiskEncryptionForLinux", StringComparison.OrdinalIgnoreCase))
                    {
                        return await RetrieveExtensionWithInstanceViewAsync(extension, cancellationToken);
                    }
                }
            }
            return await Task.FromResult<Models.VirtualMachineExtensionInner>(null);
        }

        ///GENMHASH:6BC2D312A9C6A52A192D8C5304AB76C7:8D5351CEBDDEA6C608931050B58B3338
        public string ProgressMessage()
        {
            if (!HasEncryptionExtension()) {
                return null;
            }
            IList<InstanceViewStatus> statuses = InstanceViewStatuses();
            if (statuses.Count == 0) {
                return null;
            }
            return statuses[0].Message;
        }

        ///GENMHASH:71BDA0CA4CE6BBBC011C764A218FEA88:5B97ED6BFAA87368F39F4CEFC342885A
        private bool HasEncryptionExtension()
        {
            return this.encryptionExtension != null;
        }
    }
}