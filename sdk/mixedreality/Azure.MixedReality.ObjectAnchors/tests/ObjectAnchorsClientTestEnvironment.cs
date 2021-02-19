// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Reflection;
using Azure.Core.TestFramework;

namespace Azure.MixedReality.ObjectAnchors.Tests
{
    public class ObjectAnchorsClientTestEnvironment : TestEnvironment
    {
        private string AssetsFolderName = "Assets";

        /// <summary>
        /// The absolute path of the directory where the running assembly is located.
        /// </summary>
        /// <value>The absolute path of the current working directory.</value>
        private static string CurrentWorkingDirectory => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        /// <summary>
        /// Gets the account domain.
        /// </summary>
        /// <remarks>
        /// Set the MIXEDREALITY_AOA_ACCOUNT_DOMAIN environment variable.
        /// </remarks>
        public string AccountDomain => GetRecordedVariable("AOA_ACCOUNT_DOMAIN");

        /// <summary>
        /// Gets the account identifier.
        /// </summary>
        /// <remarks>
        /// Set the MIXEDREALITY_AOA_ACCOUNT_ID environment variable.
        /// </remarks>
        public string AccountId => GetRecordedVariable("AOA_ACCOUNT_ID");

        /// <summary>
        /// Gets the account identifier.
        /// </summary>
        /// <remarks>
        /// Set the MIXEDREALITY_AOA_ACCOUNT_KEY environment variable.
        /// </remarks>
        public string AccountKey => GetRecordedVariable("AOA_ACCOUNT_KEY", options => options.IsSecret());

        /// <summary>
        /// Gets the asset's local file path
        /// </summary>
        /// <remarks>
        /// Set the MIXEDREALITY_AOA_ASSET_LOCAL_FILE_NAME environment variable.
        /// </remarks>
        public string AssetLocalFilePath => Path.Combine(CurrentWorkingDirectory, AssetsFolderName, GetRecordedVariable("AOA_ASSET_LOCAL_FILE_NAME"));

        /// <summary>
        /// Gets the asset's local file path
        /// </summary>
        /// <remarks>
        /// Set the MIXEDREALITY_AOA_MODEL_DOWNLOAD_LOCAL_FILE_NAME environment variable.
        /// </remarks>
        public string ModelDownloadLocalFilePath => Path.Combine(CurrentWorkingDirectory, GetRecordedVariable("AOA_MODEL_DOWNLOAD_LOCAL_FILE_NAME"));

        /// <summary>
        /// Gets the asset's gravity vector's x component
        /// </summary>
        /// <remarks>
        /// Set the MIXEDREALITY_AOA_ASSET_GRAVITY_X environment variable.
        /// </remarks>
        public float AssetGravityX => float.Parse(GetRecordedVariable("AOA_ASSET_GRAVITY_X"));

        /// <summary>
        /// Gets the asset's gravity vector's y component
        /// </summary>
        /// <remarks>
        /// Set the MIXEDREALITY_AOA_ASSET_GRAVITY_Y environment variable.
        /// </remarks>
        public float AssetGravityY => float.Parse(GetRecordedVariable("AOA_ASSET_GRAVITY_Y"));

        /// <summary>
        /// Gets the asset's gravity vector's z component
        /// </summary>
        /// <remarks>
        /// Set the MIXEDREALITY_AOA_ASSET_GRAVITY_Z environment variable.
        /// </remarks>
        public float AssetGravityZ => float.Parse(GetRecordedVariable("AOA_ASSET_GRAVITY_Z"));

        /// <summary>
        /// Gets the asset's scale
        /// </summary>
        /// <remarks>
        /// Set the MIXEDREALITY_AOA_ASSET_SCALE environment variable.
        /// </remarks>
        public float AssetScale => float.Parse(GetRecordedVariable("AOA_ASSET_SCALE"));
    }
}
