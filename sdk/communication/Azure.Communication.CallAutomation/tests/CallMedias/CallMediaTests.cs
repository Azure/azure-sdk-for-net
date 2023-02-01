// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.Communication.CallAutomation.Tests.Infrastructure;

namespace Azure.Communication.CallAutomation.Tests.CallMedias
{
    public class CallMediaTests : CallAutomationTestBase
    {
        private static readonly IEnumerable<CommunicationIdentifier> _target = new CommunicationIdentifier[]
        {
            new CommunicationUserIdentifier("id")
        };
        private static readonly FileSource _fileSource = new FileSource(new System.Uri("file://path/to/file"));
        private static readonly TextSource _textSource = new TextSource("PlayTTS test text.", "en-US-ElizabethNeural");
        private static readonly PlayOptions _options = new PlayOptions()
        {
            Loop = false,
            OperationContext = "context"
        };

        private static List<string> s_strings = new List<string>()
        {
            "The first test string to be recognized by cognition service.",
            "The second test string to be recognized by cognition service",
            "The third test string to be recognized by cognition service"
        };

        private static RecognizeChoice _recognizeChoice1 = new RecognizeChoice("testLabel1", s_strings);
        private static RecognizeChoice _recognizeChoice2 = new RecognizeChoice("testLabel2", s_strings);

        private static readonly List<RecognizeChoice> s_recognizeChoices = new List<RecognizeChoice>()
        {
            _recognizeChoice1,
            _recognizeChoice2
        };

        private static readonly CallMediaRecognizeOptions _dmtfRecognizeOptions = new CallMediaRecognizeDtmfOptions(new CommunicationUserIdentifier("targetUserId"), maxTonesToCollect: 5)
        {
            InterruptCallMediaOperation = true,
            InterToneTimeout = TimeSpan.FromSeconds(10),
            StopTones = new DtmfTone[] { DtmfTone.Pound },
            InitialSilenceTimeout = TimeSpan.FromSeconds(5),
            InterruptPrompt = true,
            OperationContext = "operationContext",
            Prompt = new FileSource(new Uri("https://localhost"))
        };
        private static CallMediaRecognizeOptions _choiceRecognizeOptions = new CallMediaRecognizeChoiceOptions(new CommunicationUserIdentifier("targetUserId"), s_recognizeChoices)
        {
            InterruptCallMediaOperation = true,
            InitialSilenceTimeout = TimeSpan.FromSeconds(5),
            InterruptPrompt = true,
            OperationContext = "operationContext",
            Prompt = new TextSource("PlayTTS test text.")
            {
                SourceLocale = "en-US",
                VoiceGender = GenderType.Female,
                VoiceName = "LULU"
            }
        };

        private static readonly CallMediaRecognizeOptions _emptyRecognizeOptions = new CallMediaRecognizeDtmfOptions(new CommunicationUserIdentifier("targetUserId"), maxTonesToCollect: 1);

        private static CallMedia? _callMedia;

        [SetUp]
        public void Setup()
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(202);
            _callMedia = callAutomationClient.GetCallConnection("callConnectionId").GetCallMedia();
            _fileSource.PlaySourceId = "playSourceId";
        }

        [TestCaseSource(nameof(TestData_PlayOperationsAsync))]
        public async Task PlayOperationsAsync_Return202Accepted(Func<CallMedia, Task<Response<PlayResult>>> operation)
        {
            if (_callMedia != null)
            {
                var result = await operation(_callMedia);
                Assert.IsNotNull(result);
                Assert.AreEqual((int)HttpStatusCode.Accepted, result.GetRawResponse().Status);
            }
        }

        [TestCaseSource(nameof(TestData_CancelOperationsAsync))]
        public async Task CancelOperationsAsync_Return202Accepted(Func<CallMedia, Task<Response<CancelAllMediaOperationsResult>>> operation)
        {
            if (_callMedia != null)
            {
                var result = await operation(_callMedia);
                Assert.IsNotNull(result);
                Assert.AreEqual((int)HttpStatusCode.Accepted, result.GetRawResponse().Status);
            }
        }

        [TestCaseSource(nameof(TestData_RecognizeOperationsAsync))]
        public async Task RecognizeOperationsAsync_Return202Accepted(Func<CallMedia, Task<Response<StartRecognizingResult>>> operation)
        {
            if (_callMedia != null)
            {
                var result = await operation(_callMedia);
                Assert.IsNotNull(result);
                Assert.AreEqual((int)HttpStatusCode.Accepted, result.GetRawResponse().Status);
            }
        }

        [TestCaseSource(nameof(TestData_PlayOperations))]
        public void MediaOperations_Return202Accepted(Func<CallMedia, Response<PlayResult>> operation)
        {
            if (_callMedia != null)
            {
                var result = operation(_callMedia);
                Assert.IsNotNull(result);
                Assert.AreEqual((int)HttpStatusCode.Accepted, result.GetRawResponse().Status);
            }
        }

        [TestCaseSource(nameof(TestData_CancelOperations))]
        public void CancelOperations_Return202Accepted(Func<CallMedia, Response<CancelAllMediaOperationsResult>> operation)
        {
            if (_callMedia != null)
            {
                var result = operation(_callMedia);
                Assert.IsNotNull(result);
                Assert.AreEqual((int)HttpStatusCode.Accepted, result.GetRawResponse().Status);
            }
        }

        [TestCaseSource(nameof(TestData_RecognizeOperations))]
        public void RecognizeOperations_Return202Accepted(Func<CallMedia, Response<StartRecognizingResult>> operation)
        {
            if (_callMedia != null)
            {
                var result = operation(_callMedia);
                Assert.IsNotNull(result);
                Assert.AreEqual((int)HttpStatusCode.Accepted, result.GetRawResponse().Status);
            }
        }
        [TestCaseSource(nameof(TestData_PlayOperationsAsync))]
        public void PlayOperationsAsync_Return404NotFound(Func<CallMedia, Task<Response<PlayResult>>> operation)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(404);
            _callMedia = callAutomationClient.GetCallConnection("callConnectionId").GetCallMedia();

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(
                async () => await operation(_callMedia));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_CancelOperationsAsync))]
        public void CancelOperationsAsync_Return404NotFound(Func<CallMedia, Task<Response<CancelAllMediaOperationsResult>>> operation)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(404);
            _callMedia = callAutomationClient.GetCallConnection("callConnectionId").GetCallMedia();

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(
                async () => await operation(_callMedia));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_RecognizeOperationsAsync))]
        public void RecognizeOperationsAsync_Return404NotFound(Func<CallMedia, Task<Response<StartRecognizingResult>>> operation)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(404);
            _callMedia = callAutomationClient.GetCallConnection("callConnectionId").GetCallMedia();

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(
                async () => await operation(_callMedia));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_PlayOperations))]
        public void PlayOperations_Return404NotFound(Func<CallMedia, Response<PlayResult>> operation)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(404);
            _callMedia = callAutomationClient.GetCallConnection("callConnectionId").GetCallMedia();

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(
                () => operation(_callMedia));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_CancelOperations))]
        public void CancelOperations_Return404NotFound(Func<CallMedia, Response<CancelAllMediaOperationsResult>> operation)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(404);
            _callMedia = callAutomationClient.GetCallConnection("callConnectionId").GetCallMedia();

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(
                () => operation(_callMedia));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_RecognizeOperations))]
        public void MediaOperations_Return404NotFound(Func<CallMedia, Response<StartRecognizingResult>> operation)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(404);
            _callMedia = callAutomationClient.GetCallConnection("callConnectionId").GetCallMedia();

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(
                () => operation(_callMedia));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        private static IEnumerable<object?[]> TestData_PlayOperationsAsync()
        {
            return new[]
            {
                new Func<CallMedia, Task<Response<PlayResult>>>?[]
                {
                   callMedia => callMedia.PlayAsync(_fileSource, _target, _options)
                },
                new Func<CallMedia, Task<Response<PlayResult>>>?[]
                {
                   callMedia => callMedia.PlayToAllAsync(_fileSource, _options)
                },
                new Func<CallMedia, Task<Response<PlayResult>>>?[]
                {
                   callMedia => callMedia.PlayAsync(_textSource, _target, _options)
                },
                new Func<CallMedia, Task<Response<PlayResult>>>?[]
                {
                   callMedia => callMedia.PlayToAllAsync(_textSource, _options)
                },
            };
        }

        private static IEnumerable<object?[]> TestData_CancelOperationsAsync()
        {
            return new[]
            {
                new Func<CallMedia, Task<Response<CancelAllMediaOperationsResult>>>?[]
                {
                   callMedia => callMedia.CancelAllMediaOperationsAsync()
                },
            };
        }

        private static IEnumerable<object?[]> TestData_RecognizeOperationsAsync()
        {
            return new[]
            {
                new Func<CallMedia, Task<Response<StartRecognizingResult>>>?[]
                {
                   callMedia => callMedia.StartRecognizingAsync(_dmtfRecognizeOptions)
                },
                new Func<CallMedia, Task<Response<StartRecognizingResult>>>?[]
                {
                   callMedia => callMedia.StartRecognizingAsync(_choiceRecognizeOptions)
                },
                new Func<CallMedia, Task<Response<StartRecognizingResult>>>?[]
                {
                   callMedia => callMedia.StartRecognizingAsync(_emptyRecognizeOptions)
                }
            };
        }

        private static IEnumerable<object?[]> TestData_PlayOperations()
        {
            return new[]
            {
                new Func<CallMedia, Response<PlayResult>>?[]
                {
                   callMedia => callMedia.Play(_fileSource, _target, _options)
                },
                new Func<CallMedia, Response<PlayResult>>?[]
                {
                   callMedia => callMedia.PlayToAll(_fileSource, _options)
                },
                new Func<CallMedia, Response<PlayResult>>?[]
                {
                   callMedia => callMedia.Play(_textSource, _target, _options)
                },
                new Func<CallMedia, Response<PlayResult>>?[]
                {
                   callMedia => callMedia.PlayToAll(_textSource, _options)
                },
            };
        }

        private static IEnumerable<object?[]> TestData_CancelOperations()
        {
            return new[]
            {
                new Func<CallMedia, Response<CancelAllMediaOperationsResult>>?[]
                {
                   callMedia => callMedia.CancelAllMediaOperations()
                },
            };
        }

        private static IEnumerable<object?[]> TestData_RecognizeOperations()
        {
            return new[]
            {
                new Func<CallMedia, Response<StartRecognizingResult>>?[]
                {
                   callMedia => callMedia.StartRecognizing(_dmtfRecognizeOptions)
                },
                new Func<CallMedia, Response<StartRecognizingResult>>?[]
                {
                   callMedia => callMedia.StartRecognizing(_choiceRecognizeOptions)
                },
                new Func<CallMedia, Response<StartRecognizingResult>>?[]
                {
                   callMedia => callMedia.StartRecognizing(_emptyRecognizeOptions)
                }
            };
        }
    }
}
