// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.Sms.Tests.samples
{
    /// <summary>
    /// Samples that are used in the README.md file.
    /// </summary>
    public partial class Sample1_SmsClient
    {
        public SmsClient CreateSmsClient()
        {
            #region Snippet:Azure_Communication_Sms_Tests_Samples_CreateSmsClient
            string connectionString = "YOUR_CONNECTION_STRING"; // Find your Communication Services resource in the Azure portal
            SmsClient client = new SmsClient(connectionString);
            #endregion Snippet:Azure_Communication_Sms_Tests_Samples_CreateSmsClient
            return client;
        }
    }
}
