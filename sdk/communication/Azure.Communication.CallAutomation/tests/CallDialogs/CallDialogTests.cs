// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.Communication.CallAutomation.Tests.Infrastructure;

namespace Azure.Communication.CallAutomation.Tests.CallDialogs
{
    public class CallDialogTests : CallAutomationTestBase
    {
        private const string dialogId = "92e08834-b6ee-4ede-8956-9fefa27a691c";

        private static readonly Dictionary<string, object> dialogContextWithObject = new Dictionary<string, object>()
        {
            {
                "context",
                new Dictionary<string, object>
                {
                    { "name", 1 }
                }
            }
        };

        private static readonly Dictionary<string, object> dialogContextWithString = new Dictionary<string, object>()
        {
            {
                "context",
                "context"
            }
        };

        private static readonly StartDialogOptions _startDialogOptions = new StartDialogOptions(new PowerVirtualAgentsDialog("botAppId", new Dictionary<string, object>()))
        {
            OperationContext = "context"
        };

        private static readonly StartDialogOptions _startDialogWithCustomObjectOptions = new StartDialogOptions(new PowerVirtualAgentsDialog("botAppId", dialogContextWithObject))
        {
            OperationContext = "context"
        };

        private static readonly StartDialogOptions _startDialogWithStringOptions = new StartDialogOptions(new PowerVirtualAgentsDialog("botAppId", dialogContextWithString))
        {
            OperationContext = "context"
        };

        private static readonly StartDialogOptions _startDialogWithIdOptions = new StartDialogOptions(dialogId, new PowerVirtualAgentsDialog("botAppId", new Dictionary<string, object>()))
        {
            OperationContext = "context"
        };

        private const string DummyDialogStatusResponse = "{" +
                                    "\"dialogId\": \"dummyDialogId\"," +
                                    "\"dialogInputType\": \"powerVirtualAgent\"" +
                                    "}";

        private static CallDialog? _callDialog;

        private CallDialog GetCallDialog(int responseCode, string? responseContent = null)
        {
            CallAutomationClient serverCallRestClient = CreateMockCallAutomationClient(responseCode, responseContent: responseContent);
            return serverCallRestClient.GetCallConnection("callConnectionId").GetCallDialog();
        }

        [TestCaseSource(nameof(TestData_StartDialogAsync))]
        public async Task StartDialogAsync_Return201Created(Func<CallDialog, Task<Response<DialogResult>>> operation)
        {
            _callDialog = GetCallDialog(201, responseContent: DummyDialogStatusResponse);
            var result = await operation(_callDialog);
            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.Created, result.GetRawResponse().Status);
        }

        [TestCaseSource(nameof(TestData_StartDialog))]
        public void StartDialog_Return201Created(Func<CallDialog, Response<DialogResult>> operation)
        {
            _callDialog = GetCallDialog(201, responseContent: DummyDialogStatusResponse);
            var result = operation(_callDialog);
            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.Created, result.GetRawResponse().Status);
        }

        [TestCaseSource(nameof(TestData_StartDialogWithIdAsync))]
        public async Task StartDialogWithIdAsync_Return201Created(Func<CallDialog, Task<Response<DialogResult>>> operation)
        {
            _callDialog = GetCallDialog(201, responseContent: DummyDialogStatusResponse);
            var result = await operation(_callDialog);
            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.Created, result.GetRawResponse().Status);
            Assert.AreEqual(result.Value.DialogId, dialogId);
        }

        [TestCaseSource(nameof(TestData_StartDialogWithId))]
        public void StartDialogWithId_Return201Created(Func<CallDialog, Response<DialogResult>> operation)
        {
            _callDialog = GetCallDialog(201, responseContent: DummyDialogStatusResponse);
            var result = operation(_callDialog);
            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.Created, result.GetRawResponse().Status);
            Assert.AreEqual(result.Value.DialogId, dialogId);
        }

        [TestCaseSource(nameof(TestData_UpdateDialogAsync))]
        public async Task UpdateDialogAsync_Return200OK(Func<CallDialog, Task<Response>> operation)
        {
            _callDialog = GetCallDialog(200);
            var result = await operation(_callDialog);
            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.OK, result.Status);
        }

        [TestCaseSource(nameof(TestData_UpdateDialog))]
        public void UpdateDialog_Return200OK(Func<CallDialog, Response> operation)
        {
            _callDialog = GetCallDialog(200);
            var result = operation(_callDialog);
            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.OK, result.Status);
        }

        [TestCaseSource(nameof(TestData_StopDialogAsync))]
        public async Task StopDialogAsync_Return204NoContent(Func<CallDialog, Task<Response<DialogResult>>> operation)
        {
            _callDialog = GetCallDialog(204);
            var result = await operation(_callDialog);
            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.NoContent, result.GetRawResponse().Status);
        }

        [TestCaseSource(nameof(TestData_StopDialog))]
        public void StopDialog_Return204NoContent(Func<CallDialog, Response<DialogResult>> operation)
        {
            _callDialog = GetCallDialog(204);
            var result = operation(_callDialog);
            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.NoContent, result.GetRawResponse().Status);
        }

        private static IEnumerable<object?[]> TestData_StartDialogAsync()
        {
            return new[]
            {
                new Func<CallDialog, Task<Response<DialogResult>>>?[]
                {
                    callDialog => callDialog.StartDialogAsync(_startDialogOptions)
                },
                new Func<CallDialog, Task<Response<DialogResult>>>?[]
                {
                    callDialog => callDialog.StartDialogAsync(_startDialogWithIdOptions)
                },
            };
        }

        private static IEnumerable<object?[]> TestData_StartDialog()
        {
            return new[]
            {
                new Func<CallDialog, Response<DialogResult>>?[]
                {
                    callDialog => callDialog.StartDialog(_startDialogOptions)
                },
                new Func<CallDialog, Response<DialogResult>>?[]
                {
                    callDialog => callDialog.StartDialog(_startDialogWithIdOptions)
                },
            };
        }

        private static IEnumerable<object?[]> TestData_StartDialogWithIdAsync()
        {
            return new[]
            {
                new Func<CallDialog, Task<Response<DialogResult>>>?[]
                {
                    callDialog => callDialog.StartDialogAsync(_startDialogWithIdOptions)
                },
            };
        }

        private static IEnumerable<object?[]> TestData_StartDialogWithId()
        {
            return new[]
            {
                new Func<CallDialog, Response<DialogResult>>?[]
                {
                    callDialog => callDialog.StartDialog(_startDialogWithIdOptions)
                },
            };
        }

        private static IEnumerable<object?[]> TestData_UpdateDialogAsync()
        {
            return new[]
            {
                new Func<CallDialog, Task<Response>>?[]
                {
                    callDialog => callDialog.UpdateDialogAsync(new UpdateDialogOptions(dialogId, new AzureOpenAIDialogUpdate(dialogContextWithObject)))
                },
                new Func<CallDialog, Task<Response>>?[]
                {
                    callDialog => callDialog.UpdateDialogAsync(new UpdateDialogOptions(dialogId, new AzureOpenAIDialogUpdate(dialogContextWithString)))
                },
            };
        }
        private static IEnumerable<object?[]> TestData_UpdateDialog()
        {
            return new[]
            {
                new Func<CallDialog, Response>?[]
                {
                    callDialog => callDialog.UpdateDialog(new UpdateDialogOptions(dialogId, new AzureOpenAIDialogUpdate(dialogContextWithObject)))
                },
                new Func<CallDialog, Response>?[]
                {
                    callDialog => callDialog.UpdateDialog(new UpdateDialogOptions(dialogId, new AzureOpenAIDialogUpdate(dialogContextWithString)))
                },
            };
        }

        private static IEnumerable<object?[]> TestData_StopDialogAsync()
        {
            return new[]
            {
                new Func<CallDialog, Task<Response<DialogResult>>>?[]
                {
                    callDialog => callDialog.StopDialogAsync("dialogId")
                },
            };
        }
        private static IEnumerable<object?[]> TestData_StopDialog()
        {
            return new[]
            {
                new Func<CallDialog, Response<DialogResult>>?[]
                {
                    callDialog => callDialog.StopDialog("dialogId")
                },
            };
        }
    }
}
