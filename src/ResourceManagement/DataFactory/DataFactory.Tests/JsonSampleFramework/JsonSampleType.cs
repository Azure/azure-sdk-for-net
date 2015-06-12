// ==============================================================================
//  Copyright (c) Microsoft Corporation. All Rights Reserved.
// ==============================================================================

namespace Microsoft.DataPipeline.TestFramework
{
    public enum JsonSampleType
    {
        /// <summary>
        /// The sample should be used in client and backend tests.
        /// </summary>
        Both = 0, 

        /// <summary>
        /// The sample should be used in client tests only. 
        /// </summary>
        ClientOnly = 1,

        /// <summary>
        /// The sample should be used in backend tests only. 
        /// </summary>
        BackendOnly = 2
    }
}
