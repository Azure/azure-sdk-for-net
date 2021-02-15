using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Azure.ServiceBus.Management;
using Microsoft.Azure.ServiceBus.UnitTests;
using Xunit;

public class QueueDescriptionTests
{        
    [Theory]
    [InlineData("sb://fakepath/", 261)]
    [InlineData("", 261)]
    [DisplayTestMethodName]
    public void ForwardToThrowsArgumentOutOfRangeException(string baseUrl, int lengthOfName)  
    {
        var longName = string.Join(string.Empty, Enumerable.Repeat('a', lengthOfName));
        var sub = new QueueDescription("Fake SubscriptionName");
        
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => sub.ForwardTo = $"{baseUrl}{longName}");

        Assert.StartsWith($"Entity path '{longName}' exceeds the '260' character limit.", ex.Message);
        Assert.Equal($"ForwardTo", ex.ParamName);
    }

    [Theory]
    [InlineData("sb://fakepath/", 261)]
    [InlineData("", 261)]
    [DisplayTestMethodName]
    public void ForwardDeadLetteredMessagesToThrowsArgumentOutOfRangeException(string baseUrl, int lengthOfName)  
    {
        var longName = string.Join(string.Empty, Enumerable.Repeat('a', lengthOfName));
        var sub = new QueueDescription("Fake SubscriptionName");
        
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => sub.ForwardDeadLetteredMessagesTo = $"{baseUrl}{longName}");

        Assert.StartsWith($"Entity path '{longName}' exceeds the '260' character limit.", ex.Message);
        Assert.Equal($"ForwardDeadLetteredMessagesTo", ex.ParamName);
    }

    [Theory]
    [InlineData("sb://fakepath/", 261)]
    [InlineData("", 261)]
    [DisplayTestMethodName]
    public void PathToThrowsArgumentOutOfRangeException(string baseUrl, int lengthOfName)  
    {
        var longName = string.Join(string.Empty, Enumerable.Repeat('a', lengthOfName));
        var sub = new QueueDescription("Fake SubscriptionName");
        
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => sub.Path = $"{baseUrl}{longName}");

        Assert.StartsWith($"Entity path '{longName}' exceeds the '260' character limit.", ex.Message);
        Assert.Equal($"Path", ex.ParamName);
    }

    [Theory]
    [InlineData("sb://fakepath/", 260)]
    [InlineData("sb://fakepath//", 260)]
    [InlineData("", 260)]
    [DisplayTestMethodName]
    public void ForwardToAllowsMaxLengthMinusBaseUrl(string baseUrl, int lengthOfName)  
    {
        var longName = string.Join(string.Empty, Enumerable.Repeat('a', lengthOfName));
        var sub = new QueueDescription("Fake SubscriptionName");
        sub.ForwardTo = $"{baseUrl}{longName}";
        Assert.Equal($"{baseUrl}{longName}", sub.ForwardTo);
    }

    [Theory]
    [InlineData("sb://fakepath/", 260)]
    [InlineData("sb://fakepath//", 260)]
    [InlineData("", 260)]
    [DisplayTestMethodName]
    public void ForwardDeadLetteredMessagesToAllowsMaxLengthMinusBaseUrl(string baseUrl, int lengthOfName)  
    {
        var longName = string.Join(string.Empty, Enumerable.Repeat('a', lengthOfName));
        var sub = new QueueDescription("Fake SubscriptionName");
        sub.ForwardDeadLetteredMessagesTo = $"{baseUrl}{longName}";
        Assert.Equal($"{baseUrl}{longName}", sub.ForwardDeadLetteredMessagesTo);
    }

    [Theory]
    [InlineData("sb://fakepath/", 260)]
    [InlineData("sb://fakepath//", 260)]
    [InlineData("", 260)]
    [DisplayTestMethodName]
    public void PathAllowsMaxLengthMinusBaseUrl(string baseUrl, int lengthOfName)  
    {
        var longName = string.Join(string.Empty, Enumerable.Repeat('a', lengthOfName));
        var sub = new QueueDescription("Fake SubscriptionName");
        sub.Path = $"{baseUrl}{longName}";
        Assert.Equal($"{baseUrl}{longName}", sub.Path);
    }

    [Fact]
    [DisplayTestMethodName]
    public void UnknownElementsInAtomXmlHanldedRight()
    {
        string queueDescriptionXml = $@"<entry xmlns=""{ManagementClientConstants.AtomNamespace}"">" +
            $@"<title xmlns=""{ManagementClientConstants.AtomNamespace}"">testqueue1</title>" +
            $@"<content xmlns=""{ManagementClientConstants.AtomNamespace}"">" +
            $@"<QueueDescription xmlns=""{ManagementClientConstants.ServiceBusNamespace}"">" +
            $"<LockDuration>{XmlConvert.ToString(TimeSpan.FromMinutes(1))}</LockDuration>" +
            $"<MaxSizeInMegabytes>1024</MaxSizeInMegabytes>" +
            $"<RequiresDuplicateDetection>true</RequiresDuplicateDetection>" +
            $"<RequiresSession>true</RequiresSession>" +
            $"<DefaultMessageTimeToLive>{XmlConvert.ToString(TimeSpan.FromMinutes(60))}</DefaultMessageTimeToLive>" +
            $"<DeadLetteringOnMessageExpiration>false</DeadLetteringOnMessageExpiration>" +
            $"<DuplicateDetectionHistoryTimeWindow>{XmlConvert.ToString(TimeSpan.FromMinutes(2))}</DuplicateDetectionHistoryTimeWindow>" +
            $"<MaxDeliveryCount>10</MaxDeliveryCount>" +
            $"<EnableBatchedOperations>true</EnableBatchedOperations>" +            
            $"<IsAnonymousAccessible>false</IsAnonymousAccessible>" +
            $"<AuthorizationRules />" +
            $"<Status>Active</Status>" +
            $"<ForwardTo>fq1</ForwardTo>" +
            $"<UserMetadata></UserMetadata>" +
            $"<SupportOrdering>true</SupportOrdering>" +
            $"<AutoDeleteOnIdle>{XmlConvert.ToString(TimeSpan.FromMinutes(60))}</AutoDeleteOnIdle>" +
            $"<EnablePartitioning>false</EnablePartitioning>" +
            $"<EnableExpress>false</EnableExpress>" +
            $"<UnknownElement1>prop1</UnknownElement1>" +
            $"<UnknownElement2>prop2</UnknownElement2>" +
            $"<UnknownElement3>prop3</UnknownElement3>" +
            $"<UnknownElement4>prop4</UnknownElement4>" +
            $"<UnknownElement5><PropertyValue>prop5</PropertyValue></UnknownElement5>" +
            $"</QueueDescription>" +
            $"</content>" +
            $"</entry>";

        QueueDescription queueDesc = QueueDescriptionExtensions.ParseFromContent(queueDescriptionXml);
        Assert.NotNull(queueDesc.UnknownProperties);
        XDocument doc = QueueDescriptionExtensions.Serialize(queueDesc);

        XName queueDescriptionElementName = XName.Get("QueueDescription", ManagementClientConstants.ServiceBusNamespace);
        XElement expectedQueueDecriptionElement = XElement.Parse(queueDescriptionXml).Descendants(queueDescriptionElementName).FirstOrDefault();
        XElement serializedQueueDescritionElement = doc.Descendants(queueDescriptionElementName).FirstOrDefault();
        XNode expectedChildNode = expectedQueueDecriptionElement.FirstNode;
        XNode actualChildNode = serializedQueueDescritionElement.FirstNode;
        while (expectedChildNode != null)
        {
            Assert.NotNull(actualChildNode);
            Assert.True(XNode.DeepEquals(expectedChildNode, actualChildNode), $"QueueDescrition parsing and serialization combo didn't work as expected. {expectedChildNode.ToString()}");
            expectedChildNode = expectedChildNode.NextNode;
            actualChildNode = actualChildNode.NextNode;
        }
    }
}