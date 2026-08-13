// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning.Models
{
    [CodeGenSuppress("MachineLearningAzureDataLakeGen2Datastore", typeof(MachineLearningDatastoreCredentials), typeof(string), typeof(string))]
    public partial class MachineLearningAzureDataLakeGen2Datastore
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningAzureDataLakeGen2Datastore"/>. </summary>
        // TODO: Remove this compatibility constructor after https://github.com/microsoft/typespec/issues/11588 is fixed.
        public MachineLearningAzureDataLakeGen2Datastore(MachineLearningDatastoreCredentials credentials, string filesystem, string accountName)
            : base(credentials, DatastoreType.AzureDataLakeGen2)
        {
            Argument.AssertNotNull(credentials, nameof(credentials));
            Argument.AssertNotNull(accountName, nameof(accountName));
            Argument.AssertNotNull(filesystem, nameof(filesystem));

            AccountName = accountName;
            Filesystem = filesystem;
        }
    }
}
