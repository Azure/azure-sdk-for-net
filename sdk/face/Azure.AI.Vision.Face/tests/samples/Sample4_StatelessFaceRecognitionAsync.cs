// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.Vision.Face.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Vision.Face.Samples
{
    public partial class Sample4_StatelessFaceRecognition : FaceSamplesBase
    {
        [Test]
        public async Task GroupingAsync()
        {
            var client = CreateClient();
            #region Snippet:GroupAsync
            var targetImages = new (string, Uri)[] {
                ("Group image", new Uri(FaceTestConstant.UrlIdentification1Image)),
                ("Dad image 1", new Uri(FaceTestConstant.UrlFamily1Dad1Image)),
                ("Dad image 2", new Uri(FaceTestConstant.UrlFamily1Dad2Image)),
                ("Son image 1", new Uri(FaceTestConstant.UrlFamily1Son1Image))
            };
            var faceIds = new Dictionary<Guid, (FaceDetectionResult, string)>();

            foreach (var (imageName, targetImage) in targetImages)
            {
                var detectResponse = await client.DetectAsync(targetImage, FaceDetectionModel.Detection03, FaceRecognitionModel.Recognition04, true);
                Console.WriteLine($"Detected {detectResponse.Value.Count} face(s) in the image '{imageName}'.");
                foreach (var face in detectResponse.Value)
                {
                    faceIds[face.FaceId.Value] = (face, imageName);
                }
            }

            var groupResponse = await client.GroupAsync(faceIds.Keys);
            var groups = groupResponse.Value;

            Console.WriteLine($"Found {groups.Groups.Count} group(s) in the target images.");
            foreach (var group in groups.Groups)
            {
                Console.WriteLine($"Group: ");
                foreach (var faceId in group)
                {
                    Console.WriteLine($" {faceId} from '{faceIds[faceId].Item2}', face rectangle: {faceIds[faceId].Item1.FaceRectangle.Left}, {faceIds[faceId].Item1.FaceRectangle.Top}, {faceIds[faceId].Item1.FaceRectangle.Width}, {faceIds[faceId].Item1.FaceRectangle.Height}");
                }
            }

            Console.WriteLine($"Found {groups.MessyGroup.Count} face(s) that are not in any group.");
            foreach (var faceId in groups.MessyGroup)
            {
                Console.WriteLine($" {faceId} from '{faceIds[faceId].Item2}', face rectangle: {faceIds[faceId].Item1.FaceRectangle.Left}, {faceIds[faceId].Item1.FaceRectangle.Top}, {faceIds[faceId].Item1.FaceRectangle.Width}, {faceIds[faceId].Item1.FaceRectangle.Height}");
            }
            #endregion
        }

        [Test]
        public async Task VerificationAsync()
        {
            var client = CreateClient();
            #region Snippet:VerifyFaceToFaceAsync
            var data = new (string Name, Uri Uri)[] {
                ("Dad image 1", new Uri(FaceTestConstant.UrlFamily1Dad1Image)),
                ("Dad image 2", new Uri(FaceTestConstant.UrlFamily1Dad2Image)),
                ("Son image 1", new Uri(FaceTestConstant.UrlFamily1Son1Image))
            };
            var faceIds = new List<Guid>();

            foreach (var tuple in data)
            {
                var detectResponse = await client.DetectAsync(tuple.Uri, FaceDetectionModel.Detection03, FaceRecognitionModel.Recognition04, true);
                Console.WriteLine($"Detected {detectResponse.Value.Count} face(s) in the image '{tuple.Name}'.");
                faceIds.Add(detectResponse.Value.Single().FaceId.Value);
            }

            var verifyDad1Dad2Response = await client.VerifyFaceToFaceAsync(faceIds[0], faceIds[1]);
            Console.WriteLine($"Verification between Dad image 1 and Dad image 2: {verifyDad1Dad2Response.Value.Confidence}");
            Console.WriteLine($"Is the same person: {verifyDad1Dad2Response.Value.IsIdentical}");

            var verifyDad1SonResponse = await client.VerifyFaceToFaceAsync(faceIds[0], faceIds[2]);
            Console.WriteLine($"Verification between Dad image 1 and Son image 1: {verifyDad1SonResponse.Value.Confidence}");
            Console.WriteLine($"Is the same person: {verifyDad1SonResponse.Value.IsIdentical}");
            #endregion
        }

        [Test]
        public async Task FindSimilarAsync()
        {
            var client = CreateClient();
            #region Snippet:FindSimilarAsync
            var dadImage = new Uri(FaceTestConstant.UrlFamily1Dad1Image);
            var detectDadResponse = await client.DetectAsync(dadImage, FaceDetectionModel.Detection03, FaceRecognitionModel.Recognition04, true);
            Console.WriteLine($"Detected {detectDadResponse.Value.Count} face(s) in the Dad image.");
            var dadFaceId = detectDadResponse.Value.Single().FaceId.Value;

            var targetImage = new Uri(FaceTestConstant.UrlIdentification1Image);
            var detectResponse = await client.DetectAsync(targetImage, FaceDetectionModel.Detection03, FaceRecognitionModel.Recognition04, true);
            Console.WriteLine($"Detected {detectResponse.Value.Count} face(s) in the image.");
            var faceIds = detectResponse.Value.Select(face => face.FaceId.Value);

            var response = await client.FindSimilarAsync(dadFaceId, faceIds);
            var similarFaces = response.Value;
            Console.WriteLine($"Found {similarFaces.Count} similar face(s) in the target image.");
            foreach (var similarFace in similarFaces)
            {
                Console.WriteLine($"Face ID: {similarFace.FaceId}, confidence: {similarFace.Confidence}");
            }
            #endregion
        }
    }
}
