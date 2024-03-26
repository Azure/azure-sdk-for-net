// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.ResourceManager.CognitiveServices;
using Azure.ResourceManager.CognitiveServices.Models;

namespace Azure.Provisioning.CognitiveServices
{
    /// <summary>
    /// Cognitive Services account deployment.
    /// </summary>
    public class CognitiveServicesAccountDeployment : Resource<CognitiveServicesAccountDeploymentData>
    {
        private const string ResourceTypeName = "Microsoft.CognitiveServices/accounts/deployments";
        private static CognitiveServicesAccountDeploymentData Empty (string name) => ArmCognitiveServicesModelFactory.CognitiveServicesAccountDeploymentData();

        /// <summary>
        /// Creates a new instance of the <see cref="CognitiveServicesAccount"/> class.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="model">The model.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="sku">The sku.</param>
        /// <param name="name">The name.</param>
        /// <param name="version">The version.</param>
        public CognitiveServicesAccountDeployment(
            IConstruct scope,
            CognitiveServicesAccountDeploymentModel model,
            CognitiveServicesAccount? parent = default,
            CognitiveServicesSku? sku = default,
            string name = "cs",
            string version = "2023-05-01")
            : this(scope, parent, name, version, false, (name) =>
                ArmCognitiveServicesModelFactory.CognitiveServicesAccountDeploymentData(
                    name: name,
                    // TODO why does the deployment also have a SKU
                    sku: sku ?? new CognitiveServicesSku("S0"),
                    properties: new CognitiveServicesAccountDeploymentProperties { Model = model }))
        {
        }

        private CognitiveServicesAccountDeployment(
            IConstruct scope,
            CognitiveServicesAccount? parent = default,
            string name = "cosmosDB",
            string version = "2023-04-15",
            bool isExisting = false,
            Func<string, CognitiveServicesAccountDeploymentData>? creator = null)
            : base(scope, parent, name, ResourceTypeName, version, creator ?? Empty, isExisting)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="CognitiveServicesAccount"/> class referencing an existing instance.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The resource name.</param>
        /// <param name="parent">The parent.</param>
        /// <returns>The KeyVault instance.</returns>
        public static CognitiveServicesAccountDeployment FromExisting(IConstruct scope, string name, CognitiveServicesAccount parent)
            => new CognitiveServicesAccountDeployment(scope, parent: parent, name: name, isExisting: true);

        /// <inheritdoc/>
        protected override Resource? FindParentInScope(IConstruct scope)
        {
            return scope.GetSingleResource<CognitiveServicesAccount>() ?? new CognitiveServicesAccount(scope);
        }
    }
}
