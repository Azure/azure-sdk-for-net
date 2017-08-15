// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.AppService.Fluent.WebDeployment.Definition;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System;

    internal partial class WebDeploymentImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> 
    {
        /// <summary>
        /// Gets username of the deployer.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IWebDeployment.Deployer
        {
            get
            {
                return this.Deployer();
            }
        }

        /// <summary>
        /// Gets whether the deployment operation has completed.
        /// </summary>
        bool Microsoft.Azure.Management.AppService.Fluent.IWebDeployment.Complete
        {
            get
            {
                return this.Complete();
            }
        }

        /// <summary>
        /// Gets the start time of the deploy operation.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.AppService.Fluent.IWebDeployment.StartTime
        {
            get
            {
                return this.StartTime();
            }
        }

        /// <summary>
        /// Gets the end time of the deploy operation.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.AppService.Fluent.IWebDeployment.EndTime
        {
            get
            {
                return this.EndTime();
            }
        }

        /// <summary>
        /// Specifies whether existing deployed files on the web app should be deleted.
        /// </summary>
        /// <param name="deleteExisting">If set to true, all files on the web app will be deleted. Default is false.</param>
        /// <return>The next definition stage.</return>
        WebDeployment.Definition.IWithExecute WebDeployment.Definition.IWithExistingDeploymentsDeleted.WithExistingDeploymentsDeleted(bool deleteExisting)
        {
            return this.WithExistingDeploymentsDeleted(deleteExisting) as WebDeployment.Definition.IWithExecute;
        }

        /// <summary>
        /// Adds an extra package to the deployment.
        /// </summary>
        /// <param name="packageUri">
        /// The URL to the package. It can be a publicly available link to
        /// the package zip, or an Azure Storage object with a SAS token.
        /// </param>
        /// <return>The next definition stage.</return>
        WebDeployment.Definition.IWithExecute WebDeployment.Definition.IWithAddOnPackage.WithAddOnPackage(string packageUri)
        {
            return this.WithAddOnPackage(packageUri) as WebDeployment.Definition.IWithExecute;
        }

        /// <summary>
        /// Specifies the XML file containing the parameters.
        /// </summary>
        /// <param name="fileUri">The XML file's URI.</param>
        /// <return>The next definition stage.</return>
        WebDeployment.Definition.IWithExecute WebDeployment.Definition.IWithSetParameters.WithSetParametersXmlFile(string fileUri)
        {
            return this.WithSetParametersXmlFile(fileUri) as WebDeployment.Definition.IWithExecute;
        }

        /// <summary>
        /// Adds a parameter for the deployment.
        /// </summary>
        /// <param name="name">Name of the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        /// <return>The next definition stage.</return>
        WebDeployment.Definition.IWithExecute WebDeployment.Definition.IWithSetParameters.WithSetParameter(string name, string value)
        {
            return this.WithSetParameter(name, value) as WebDeployment.Definition.IWithExecute;
        }

        /// <summary>
        /// Specifies the zipped package to deploy.
        /// </summary>
        /// <param name="packageUri">
        /// The URL to the package. It can be a publicly available link to
        /// the package zip, or an Azure Storage object with a SAS token.
        /// </param>
        /// <return>The next definition stage.</return>
        WebDeployment.Definition.IWithExecute WebDeployment.Definition.IWithPackageUri.WithPackageUri(string packageUri)
        {
            return this.WithPackageUri(packageUri) as WebDeployment.Definition.IWithExecute;
        }
    }
}