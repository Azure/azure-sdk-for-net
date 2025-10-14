// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Health.Deidentification
{
    [CodeGenType("DeidentificationModelFactory")]
    public partial class HealthDeidentificationModelFactory
    {
        /// <summary> Request body for de-identification operation. </summary>
        /// <param name="inputText"> Input text to de-identify. </param>
        /// <param name="operationType"> Operation to perform on the input documents. </param>
        /// <param name="customizations"> Customization parameters to override default service behaviors. </param>
        /// <returns> A new <see cref="Deidentification.DeidentificationContent"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DeidentificationContent DeidentificationContent(string inputText, DeidentificationOperationType? operationType, DeidentificationCustomizationOptions customizations)
        {
            return DeidentificationContent(inputText, operationType, null, customizations);
        }
    }
}
