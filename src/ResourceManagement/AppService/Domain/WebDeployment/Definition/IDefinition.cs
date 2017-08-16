// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent.WebDeployment.Definition
{
    using Microsoft.Azure.Management.AppService.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The first stage of a web deployment definition.
    /// </summary>
    public interface IWithPackageUri 
    {
        /// <summary>
        /// Specifies the zipped package to deploy.
        /// </summary>
        /// <param name="packageUri">
        /// The URL to the package. It can be a publicly available link to
        /// the package zip, or an Azure Storage object with a SAS token.
        /// </param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebDeployment.Definition.IWithExecute WithPackageUri(string packageUri);
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for
    /// the resource to be created, but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithExecute  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IExecutable<Microsoft.Azure.Management.AppService.Fluent.IWebDeployment>,
        Microsoft.Azure.Management.AppService.Fluent.WebDeployment.Definition.IWithExistingDeploymentsDeleted,
        Microsoft.Azure.Management.AppService.Fluent.WebDeployment.Definition.IWithAddOnPackage,
        Microsoft.Azure.Management.AppService.Fluent.WebDeployment.Definition.IWithSetParameters
    {
    }

    /// <summary>
    /// A web deployment definition stage allowing specifying whether to delete existing deployments.
    /// </summary>
    public interface IWithExistingDeploymentsDeleted 
    {
        /// <summary>
        /// Specifies whether existing deployed files on the web app should be deleted.
        /// </summary>
        /// <param name="deleteExisting">If set to true, all files on the web app will be deleted. Default is false.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebDeployment.Definition.IWithExecute WithExistingDeploymentsDeleted(bool deleteExisting);
    }

    /// <summary>
    /// A web deployment definition stage allowing adding more packages.
    /// </summary>
    public interface IWithAddOnPackage 
    {
        /// <summary>
        /// Adds an extra package to the deployment.
        /// </summary>
        /// <param name="packageUri">
        /// The URL to the package. It can be a publicly available link to
        /// the package zip, or an Azure Storage object with a SAS token.
        /// </param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebDeployment.Definition.IWithExecute WithAddOnPackage(string packageUri);
    }

    /// <summary>
    /// A web deployment definition stage allowing specifying parameters.
    /// </summary>
    public interface IWithSetParameters 
    {
        /// <summary>
        /// Specifies the XML file containing the parameters.
        /// </summary>
        /// <param name="fileUri">The XML file's URI.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebDeployment.Definition.IWithExecute WithSetParametersXmlFile(string fileUri);

        /// <summary>
        /// Adds a parameter for the deployment.
        /// </summary>
        /// <param name="name">Name of the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        /// <return>The next definition stage.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebDeployment.Definition.IWithExecute WithSetParameter(string name, string value);
    }

    /// <summary>
    /// The entirety of web deployment parameters definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.AppService.Fluent.WebDeployment.Definition.IWithPackageUri,
        Microsoft.Azure.Management.AppService.Fluent.WebDeployment.Definition.IWithExecute
    {
    }
}