// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Vision.Face.Samples
{
    public partial class FaceSamples
    {
        private static Uri TestImage = new("https://raw.githubusercontent.com/Azure-Samples/cognitive-services-sample-data-files/master/Face/images/detection1.jpg");

        [RecordedTest]
        public async Task LargePersonGroupSample()
        {
            var administrationClient = CreateAdministrationClient();
            var groupId = "lpg_family1";
/*
            await administrationClient.CreateLargePersonGroupAsync(groupId, "Family 1", userData: "A sweet family", recognitionModel: FaceRecognitionModel.Recognition04);

            var createPersonResponse1 = await administrationClient.CreateLargePersonGroupPersonAsync(groupId, "Bill", userData: "Dad");
            var personId1 = createPersonResponse1.Value.PersonId;
            await administrationClient.AddLargePersonGroupPersonFaceFromUrlAsync(groupId, personId1, TestImage);
*/
            var op = await administrationClient.TrainLargePersonGroupAsync(WaitUntil.Started, groupId);
            Console.WriteLine("=================================================");
            Console.WriteLine(op.GetRawResponse());
            var s = await op.UpdateStatusAsync();
            Console.WriteLine(s.Content);
        }
    }
}
