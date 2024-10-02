// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Provisioning.CloudMachine;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace Azure.CloudMachine.Tests;

public class CloudMachineTests
{
    [Theory]
    [TestCase([new string[] { "--init" }])]
    [TestCase([new string[] { "" }])]
    public void Configure(string[] args)
    {
        if (CloudMachineInfrastructure.Configure(args, (cmi) => {
        })) return;

        CloudMachineClient cm = new();
        Console.WriteLine(cm.Id);
    }

    [Ignore("no recordings yet")]
    [Theory]
    [TestCase([new string[] { "--init" }])]
    [TestCase([new string[] { "" }])]
    public void Storage(string[] args)
    {
        if (CloudMachineInfrastructure.Configure(args, (cmi) => {
        })) return;

        CloudMachineClient cm = new();
        var uploaded = cm.Upload(new
        {
            Foo = 5,
            Bar = true
        });
        BinaryData downloaded = cm.Download(uploaded);
    }

    [Ignore("no recordings yet")]
    [Theory]
    [TestCase([new string[] { "--init" }])]
    [TestCase([new string[] { "" }])]
    public void Messaging(string[] args)
    {
        if (CloudMachineInfrastructure.Configure(args, (cmi) => {
        })) return;

        CloudMachineClient cm = new();
        cm.Send(new
        {
            Foo = 5,
            Bar = true
        });
    }

    public record Fact(string text);
    [Ignore("no recordings yet")]
    [Theory]
    [TestCase("""{ "id" : 1 }""")]
    public void E2EApp()
    {
        CloudMachineClient cm = new();
        cm.StrartReceiving<Fact>(ToDoReceived);
        cm.Uploaded<Fact>(ToDoUploaded);

        foreach ((string path, byte[] content) in SimulatedRequests)
        {
            switch (path)
            {
                case "add":
                    cm.Send(content);
                    break;
                case "search":
                    cm.Search(content);
            }
        }

        void ToDoReceived(Fact fact) => cm.Upload(fact);
        void ToDoUploaded(Fact fact) => cm.AI.AddFact(fact);
    }

    private IEnumerable<(string Path, byte[] Content)> SimulatedRequests => [
        ("add", BinaryData.FromObjectAsJson(new { text = "Our company name is Microsoft" }).ToArray()),
        ("search", BinaryData.FromObjectAsJson(new { text = "What's the name of your company?" }).ToArray()),
    ];
}
