// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Linq;
using Azure.Core;
using Azure.Messaging.ServiceBus.Management;
using Azure.Messaging.ServiceBus.Primitives;

namespace Azure.Messaging.ServiceBus.Filters
{
    internal static class RuleDescriptionExtensions
    {
        public static void ValidateDescriptionName(this RuleDescription description)
        {
            Argument.AssertNotNullOrWhiteSpace(description.Name, nameof(description.Name));
            Argument.AssertNotTooLong(description.Name, Constants.RuleNameMaximumLength, nameof(description.Name));

            if (description.Name.Contains(Constants.PathDelimiter) || description.Name.Contains(@"\"))
            {
#pragma warning disable CA2208 // Instantiate argument exceptions correctly. Specifying the Name property
                               // is more intuitive, than just description.
                throw new ArgumentException(
                    Resources.InvalidCharacterInEntityName.FormatForUser(Constants.PathDelimiter, description.Name),
                    nameof(description.Name));
#pragma warning restore CA2208 // Instantiate argument exceptions correctly
            }

            string[] uriSchemeKeys = { "@", "?", "#" };
            foreach (var uriSchemeKey in uriSchemeKeys)
            {
                if (description.Name.Contains(uriSchemeKey))
                {
                    throw new ArgumentException(
                        nameof(description.Name),
                        Resources.CharacterReservedForUriScheme.FormatForUser(nameof(description.Name), uriSchemeKey));
                }
            }
        }

        public static RuleDescription ParseFromContent(string xml)
        {
            try
            {
                var xDoc = XElement.Parse(xml);
                if (!xDoc.IsEmpty)
                {
                    if (xDoc.Name.LocalName == "entry")
                    {
                        return ParseFromEntryElement(xDoc);
                    }
                }
            }
            catch (Exception ex) when (!(ex is ServiceBusException))
            {
                //throw new ServiceBusException(false, ex);
            }
            return null;
            //throw new MessagingEntityNotFoundException("Rule was not found");
        }

        public static IList<RuleDescription> ParseCollectionFromContent(string xml)
        {
            try
            {
                var xDoc = XElement.Parse(xml);
                if (!xDoc.IsEmpty)
                {
                    if (xDoc.Name.LocalName == "feed")
                    {
                        var rules = new List<RuleDescription>();

                        var entryList = xDoc.Elements(XName.Get("entry", ManagementClientConstants.AtomNamespace));
                        foreach (var entry in entryList)
                        {
                            rules.Add(ParseFromEntryElement(entry));
                        }

                        return rules;
                    }
                }
            }
            catch (Exception ex) when (!(ex is ServiceBusException))
            {
                //throw new ServiceBusException(false, ex);
            }
            return null;
            //throw new MessagingEntityNotFoundException("Rule was not found");
        }

        private static RuleDescription ParseFromEntryElement(XElement xEntry)
        {
            var name = xEntry.Element(XName.Get("title", ManagementClientConstants.AtomNamespace)).Value;
            var ruleDescription = new RuleDescription();

            var rdXml = xEntry.Element(XName.Get("content", ManagementClientConstants.AtomNamespace))?
                .Element(XName.Get("RuleDescription", ManagementClientConstants.ServiceBusNamespace));

            if (rdXml == null)
            {
                //throw new MessagingEntityNotFoundException("Rule was not found");
            }

            foreach (var element in rdXml.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "Name":
                        ruleDescription.Name = element.Value;
                        break;
                    case "Filter":
                        ruleDescription.Filter = FilterExtensions.ParseFromXElement(element);
                        break;
                    case "Action":
                        ruleDescription.Action = RuleActionExtensions.ParseFromXElement(element);
                        break;
                    case "CreatedAt":
                        ruleDescription.CreatedAt = DateTime.Parse(element.Value, CultureInfo.InvariantCulture);
                        break;
                }
            }

            return ruleDescription;
        }

        public static XDocument Serialize(this RuleDescription description)
        {
            XDocument doc = new XDocument(
                   new XElement(XName.Get("entry", ManagementClientConstants.AtomNamespace),
                       new XElement(XName.Get("content", ManagementClientConstants.AtomNamespace),
                           new XAttribute("type", "application/xml"),
                           description.SerializeRule())));

            return doc;
        }

        public static XElement SerializeRule(this RuleDescription description, string elementName = "RuleDescription")
        {
            return new XElement(
                XName.Get(elementName, ManagementClientConstants.ServiceBusNamespace),
                description.Filter?.Serialize(),
                description.Action?.Serialize(),
                new XElement(XName.Get("Name", ManagementClientConstants.ServiceBusNamespace), description.Name));
        }
    }
}
