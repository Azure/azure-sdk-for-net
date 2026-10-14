// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.IO;
using Azure.AI.Extensions.OpenAI.Tests.Samples;
using NUnit.Framework;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI.Tests;

[NonParallelizable]
public class BrowserAutomationSampleTests
{
    private static StreamingResponseUpdate ReadUpdate(string json) => ModelReaderWriter.Read<StreamingResponseUpdate>(
        BinaryData.FromString(json), ModelReaderWriterOptions.Json, OpenAIContext.Default);

    private static string CaptureOutput(params string[] updates)
    {
        TextWriter originalOutput = Console.Out;
        using StringWriter output = new();
        try
        {
            Console.SetOut(output);
            foreach (string update in updates)
            {
                Sample_BrowserAutomotion.ParseResponse(ReadUpdate(update));
            }
            return output.ToString();
        }
        finally
        {
            Console.SetOut(originalOutput);
        }
    }

    [Test]
    public void PrintsCompleteTextOnceWithoutDeltas()
    {
        string output = CaptureOutput(
            """{"type":"response.output_text.delta","sequence_number":1,"item_id":"msg_1","output_index":0,"content_index":0,"delta":"Example"}""",
            """{"type":"response.output_text.done","sequence_number":2,"item_id":"msg_1","output_index":0,"content_index":0,"text":"Example Domain"}""");

        Assert.That(output, Is.EqualTo($"Response done with full message: Example Domain{Environment.NewLine}"));
    }

    [Test]
    public void LogsGaBrowserActionWithoutSessionId()
    {
        string output = CaptureOutput(
            """{"type":"response.output_item.done","sequence_number":1,"output_index":0,"item":{"type":"remote_function_call","id":"item_1","name":"browser_navigate","call_id":"call_1","arguments":"{\"url\":\"https://example.com\",\"browserSessionId\":\"secret-session\"}"}}""");

        Assert.That(output, Does.Contain("Browser action: browser_navigate, call ID: call_1"));
        Assert.That(output, Does.Contain("\"url\":\"https://example.com\""));
        Assert.That(output, Does.Not.Contain("browserSessionId"));
        Assert.That(output, Does.Not.Contain("secret-session"));
    }

    [Test]
    public void LogsGaBrowserActionOutputWithoutRawOutput()
    {
        string output = CaptureOutput(
            """{"type":"response.output_item.done","sequence_number":1,"output_index":0,"item":{"type":"remote_function_call_output","id":"item_2","call_id":"call_1","output":"https://sensitive-live-view.example/?token=secret"}}""");

        Assert.That(output, Is.EqualTo($"Browser action completed: call_1{Environment.NewLine}"));
    }

    [Test]
    public void ErrorEventThrows()
    {
        StreamingResponseUpdate update = ReadUpdate(
            """{"type":"error","sequence_number":1,"code":"browser_error","message":"Browser failed","param":null}""");

        Assert.That(() => Sample_BrowserAutomotion.ParseResponse(update),
            Throws.TypeOf<InvalidOperationException>().With.Message.Contains("browser_error"));
    }

    [TestCase("response.failed", "failed")]
    [TestCase("response.incomplete", "incomplete")]
    public void UnsuccessfulResponseThrows(string eventType, string status)
    {
        StreamingResponseUpdate update = ReadUpdate($$$$"""
            {"type":"{{{{eventType}}}}","sequence_number":1,"response":{"id":"resp_1","object":"response","created_at":0,"status":"{{{{status}}}}","model":"model","output":[],"error":{"code":"server_error","message":"Browser failed"}}}
            """);

        Assert.Throws<InvalidOperationException>(() => Sample_BrowserAutomotion.ParseResponse(update));
    }

    [TestCase("response.created", "in_progress", false)]
    [TestCase("response.completed", "completed", true)]
    public void OnlyCompletedResponseSignalsSuccess(string eventType, string status, bool expected)
    {
        StreamingResponseUpdate update = ReadUpdate($$$"""
            {"type":"{{{eventType}}}","sequence_number":1,"response":{"id":"resp_1","object":"response","created_at":0,"status":"{{{status}}}","model":"model","output":[]}}
            """);

        Assert.That(Sample_BrowserAutomotion.ParseResponse(update), Is.EqualTo(expected));
    }
}
