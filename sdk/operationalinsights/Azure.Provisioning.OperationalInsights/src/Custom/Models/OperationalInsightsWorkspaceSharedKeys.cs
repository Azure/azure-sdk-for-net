// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.OperationalInsights
{
    // Preserve the previously shipped result type for GetKeys because custom actions
    // are not emitted by the TypeSpec-based provisioning generator.
    /// <summary>
    /// The shared keys for a workspace.
    /// </summary>
    public partial class OperationalInsightsWorkspaceSharedKeys : ProvisionableConstruct
    {
        private BicepValue<string>? _primarySharedKey;
        private BicepValue<string>? _secondarySharedKey;

        /// <summary>
        /// The primary shared key of a workspace.
        /// </summary>
        public BicepValue<string> PrimarySharedKey
        {
            get { Initialize(); return _primarySharedKey!; }
        }

        /// <summary>
        /// The secondary shared key of a workspace.
        /// </summary>
        public BicepValue<string> SecondarySharedKey
        {
            get { Initialize(); return _secondarySharedKey!; }
        }

        /// <summary>
        /// Creates a new OperationalInsightsWorkspaceSharedKeys.
        /// </summary>
        public OperationalInsightsWorkspaceSharedKeys()
        {
        }

        /// <summary>
        /// Define all the provisionable properties of OperationalInsightsWorkspaceSharedKeys.
        /// </summary>
        protected override void DefineProvisionableProperties()
        {
            base.DefineProvisionableProperties();
            _primarySharedKey = DefineProperty<string>("PrimarySharedKey", ["primarySharedKey"], isOutput: true, isSecure: true);
            _secondarySharedKey = DefineProperty<string>("SecondarySharedKey", ["secondarySharedKey"], isOutput: true, isSecure: true);
        }
    }
}
