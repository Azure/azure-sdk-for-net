using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Azure.ServiceBus.Management;
using Microsoft.Azure.ServiceBus.UnitTests;
using Xunit;

public class SubscriptionDescriptionTests
{        
    [Theory]
    [InlineData("sb://fakepath/", 261)]
    [InlineData("", 261)]
    [DisplayTestMethodName]
    public void ForwardToThrowsArgumentOutOfRangeException(string baseUrl, int lengthOfName)  
    {
        var longName = string.Join(string.Empty, Enumerable.Repeat('a', lengthOfName));
        var sub = new SubscriptionDescription("sb://fakeservicebus", "Fake SubscriptionName");
        
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
        var sub = new SubscriptionDescription("sb://fakeservicebus", "Fake SubscriptionName");
        
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => sub.ForwardDeadLetteredMessagesTo = $"{baseUrl}{longName}");

        Assert.StartsWith($"Entity path '{longName}' exceeds the '260' character limit.", ex.Message);
        Assert.Equal($"ForwardDeadLetteredMessagesTo", ex.ParamName);
    }

    [Theory]
    [InlineData("sb://fakepath/", 260)]
    [InlineData("sb://fakepath//", 260)]
    [InlineData("", 260)]
    [DisplayTestMethodName]
    public void ForwardToAllowsMaxLengthMinusBaseUrl(string baseUrl, int lengthOfName)  
    {
        var longName = string.Join(string.Empty, Enumerable.Repeat('a', lengthOfName));
        var sub = new SubscriptionDescription("sb://fakeservicebus", "Fake SubscriptionName");
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
        var sub = new SubscriptionDescription("sb://fakeservicebus", "Fake SubscriptionName");
        sub.ForwardDeadLetteredMessagesTo = $"{baseUrl}{longName}";
        Assert.Equal($"{baseUrl}{longName}", sub.ForwardDeadLetteredMessagesTo);
    }

    [Fact]
    [DisplayTestMethodName]
    public void UnknownElementsInAtomXmlHanldedRight()
    {
        string subscriptionDescriptionXml = $@"<entry xmlns=""{ManagementClientConstants.AtomNamespace}"">" +
            $@"<title xmlns=""{ManagementClientConstants.AtomNamespace}"">testqueue1</title>" +
            $@"<content xmlns=""{ManagementClientConstants.AtomNamespace}"">" +
            $@"<SubscriptionDescription xmlns=""{ManagementClientConstants.ServiceBusNamespace}"">" +
            $"<LockDuration>{XmlConvert.ToString(TimeSpan.FromMinutes(1))}</LockDuration>" +
            $"<RequiresSession>true</RequiresSession>" +
            $"<DefaultMessageTimeToLive>{XmlConvert.ToString(TimeSpan.FromMinutes(60))}</DefaultMessageTimeToLive>" +
            $"<DeadLetteringOnMessageExpiration>false</DeadLetteringOnMessageExpiration>" +
            $"<DeadLetteringOnFilterEvaluationExceptions>false</DeadLetteringOnFilterEvaluationExceptions>" +
            $"<MaxDeliveryCount>10</MaxDeliveryCount>" +
            $"<EnableBatchedOperations>true</EnableBatchedOperations>" +
            $"<Status>Active</Status>" +
            $"<ForwardTo>fq1</ForwardTo>" +
            $"<UserMetadata></UserMetadata>" +
            $"<AutoDeleteOnIdle>{XmlConvert.ToString(TimeSpan.FromMinutes(60))}</AutoDeleteOnIdle>" +
            $"<IsClientAffine>prop1</IsClientAffine>" +
            $"<ClientAffineProperties><ClientId>xyz</ClientId><IsDurable>false</IsDurable><IsShared>true</IsShared></ClientAffineProperties>" +
            $"<UnknownElement3>prop3</UnknownElement3>" +
            $"<UnknownElement4>prop4</UnknownElement4>" +
            $"</SubscriptionDescription>" +
            $"</content>" +
            $"</entry>";

        SubscriptionDescription subscriptionDesc = SubscriptionDescriptionExtensions.ParseFromContent("abcd", subscriptionDescriptionXml);
        Assert.NotNull(subscriptionDesc.UnknownProperties);
        XDocument doc = SubscriptionDescriptionExtensions.Serialize(subscriptionDesc);

        XName subscriptionDescriptionElementName = XName.Get("SubscriptionDescription", ManagementClientConstants.ServiceBusNamespace);
        XElement expectedSubscriptionDecriptionElement = XElement.Parse(subscriptionDescriptionXml).Descendants(subscriptionDescriptionElementName).FirstOrDefault();
        XElement serializedSubscriptionDescritionElement = doc.Descendants(subscriptionDescriptionElementName).FirstOrDefault();
        XNode expectedChildNode = expectedSubscriptionDecriptionElement.FirstNode;
        XNode actualChildNode = serializedSubscriptionDescritionElement.FirstNode;
        while (expectedChildNode != null)
        {
            Assert.NotNull(actualChildNode);
            Assert.True(XNode.DeepEquals(expectedChildNode, actualChildNode), $"SubscriptionDescrition parsing and serialization combo didn't work as expected. {expectedChildNode.ToString()}");
            expectedChildNode = expectedChildNode.NextNode;
            actualChildNode = actualChildNode.NextNode;
        }
    }
}