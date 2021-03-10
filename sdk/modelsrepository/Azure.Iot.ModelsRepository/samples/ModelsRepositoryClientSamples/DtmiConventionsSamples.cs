// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Iot.ModelsRepository.Samples
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

        public static void GetDtmiToQualifiedPath()
        {
            #region Snippet:ModelsRepositorySamplesDtmiConventionsGetDtmiToQualifiedPath

            // This snippet shows obtaining a fully qualified path to a model file.
            
            // Local repository example
            string localRepository = "/path/to/repository";
            string fullyQualifiedModelPath = 
                DtmiConventions.DtmiToQualifiedPath("dtmi:com:example:Thermostat;1", localRepository);
            
            // Prints '/path/to/repository/dtmi/com/example/thermostat-1.json'
            Console.WriteLine(fullyQualifiedModelPath);

            // Remote repository example
            string remoteRepository = "https://contoso.com/models";
            fullyQualifiedModelPath =
                DtmiConventions.DtmiToQualifiedPath("dtmi:com:example:Thermostat;1", remoteRepository);

            // Prints 'https://contoso.com/models/dtmi/com/example/thermostat-1.json'
            Console.WriteLine(fullyQualifiedModelPath);

            #endregion Snippet:ModelsRepositorySamplesDtmiConventionsGetDtmiToQualifiedPath
        }
    }
}
