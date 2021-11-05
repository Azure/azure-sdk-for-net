// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.IoT.ModelsRepository.Samples
{
    internal class DtmiConventionsSamples
    {
        public static void IsValidDtmi()
        {
            #region Snippet:ModelsRepositorySamplesDtmiConventionsIsValidDtmi

            // This snippet shows how to validate a given DTMI string is well-formed.

            // Returns true
            DtmiConventions.IsValidDtmi("dtmi:com:example:Thermostat;1");

            // Returns false
            DtmiConventions.IsValidDtmi("dtmi:com:example:Thermostat");

            #endregion Snippet:ModelsRepositorySamplesDtmiConventionsIsValidDtmi
        }

        public static void GetModelUri()
        {
            #region Snippet:ModelsRepositorySamplesDtmiConventionsGetModelUri

            // This snippet shows obtaining a fully qualified path to a model file.

            // Local repository example
            Uri localRepositoryUri = new Uri("file:///path/to/repository/");
            string fullyQualifiedModelPath =
                DtmiConventions.GetModelUri("dtmi:com:example:Thermostat;1", localRepositoryUri).AbsolutePath;

            // Prints '/path/to/repository/dtmi/com/example/thermostat-1.json'
            Console.WriteLine(fullyQualifiedModelPath);

            // Remote repository example
            Uri remoteRepositoryUri = new Uri("https://contoso.com/models/");
            fullyQualifiedModelPath =
                DtmiConventions.GetModelUri("dtmi:com:example:Thermostat;1", remoteRepositoryUri).AbsoluteUri;

            // Prints 'https://contoso.com/models/dtmi/com/example/thermostat-1.json'
            Console.WriteLine(fullyQualifiedModelPath);

            #endregion Snippet:ModelsRepositorySamplesDtmiConventionsGetModelUri
        }
    }
}
