using System;
using System.Linq;
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
}