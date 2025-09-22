// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Xml.Linq;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Messaging.ServiceBus.Primitives;

namespace Azure.Messaging.ServiceBus.Administration
{
    internal static class RuleDescriptionExtensions
    {
        private static readonly string[] s_uriSchemeKeys = ["@", "?", "#"];

        public static void ValidateDescriptionName(this RuleProperties description)
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

            foreach (var uriSchemeKey in s_uriSchemeKeys)
            {
                if (description.Name.Contains(uriSchemeKey))
                {
#pragma warning disable CA2208 // Instantiate argument exceptions correctly
                    throw new ArgumentException(
                        Resources.CharacterReservedForUriScheme.FormatForUser(nameof(description.Name), uriSchemeKey),
                        nameof(description.Name));
#pragma warning restore CA2208 // Instantiate argument exceptions correctly
                }
            }
        }

        public static async Task<RuleProperties> ParseResponseAsync(Response response, ClientDiagnostics diagnostics)
        {
            try
            {
                string xml = await response.ReadAsStringAsync().ConfigureAwait(false);
                var xDoc = XElement.Parse(xml);
                if (!xDoc.IsEmpty)
                {
                    if (xDoc.Name.LocalName == "entry")
                    {
                        return ParseFromEntryElement(xDoc);
                    }
                }
            }
            catch (Exception ex) when (ex is not ServiceBusException)
            {
                throw new ServiceBusException(isTransient: false, message: "An error occurred while attempting to parse the rule property.", innerException: ex);
            }
            throw new ServiceBusException(
                "Rule was not found",
                ServiceBusFailureReason.MessagingEntityNotFound,
                innerException: new RequestFailedException(response));
        }

        public static async Task<List<RuleProperties>> ParsePagedResponseAsync(Response response, ClientDiagnostics diagnostics)
        {
            try
            {
                string xml = await response.ReadAsStringAsync().ConfigureAwait(false);
                var xDoc = XElement.Parse(xml);
                if (!xDoc.IsEmpty)
                {
                    if (xDoc.Name.LocalName == "feed")
                    {
                        var rules = new List<RuleProperties>();

                        var entryList = xDoc.Elements(XName.Get("entry", AdministrationClientConstants.AtomNamespace));
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
                throw new ServiceBusException(isTransient: false, message: "An error occurred while attempting to parse the collection of rule properties.", innerException: ex);
            }
            throw new ServiceBusException(
                "Rule was not found",
                ServiceBusFailureReason.MessagingEntityNotFound,
                innerException: new RequestFailedException(response));
        }

        private static RuleProperties ParseFromEntryElement(XElement xEntry)
        {
            var name = xEntry.Element(XName.Get("title", AdministrationClientConstants.AtomNamespace)).Value;
            var ruleDescription = new RuleProperties();

            var rdXml = xEntry.Element(XName.Get("content", AdministrationClientConstants.AtomNamespace))?
                .Element(XName.Get("RuleDescription", AdministrationClientConstants.ServiceBusNamespace));

            if (rdXml == null)
            {
                throw new ServiceBusException("Rule was not found", ServiceBusFailureReason.MessagingEntityNotFound);
            }

            foreach (var element in rdXml.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "Name":
                        ruleDescription.Name = element.Value;
                        break;
                    case "Filter":
                        ruleDescription.Filter = RuleFilterExtensions.ParseFromXElement(element);
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

        public static XDocument Serialize(this RuleProperties description)
        {
            XDocument doc = new XDocument(
                   new XElement(XName.Get("entry", AdministrationClientConstants.AtomNamespace),
                       new XElement(XName.Get("content", AdministrationClientConstants.AtomNamespace),
                           new XAttribute("type", "application/xml"),
                           description.SerializeRule())));

            return doc;
        }

        public static XElement SerializeRule(this RuleProperties description, string elementName = "RuleDescription")
        {
            return new XElement(
                XName.Get(elementName, AdministrationClientConstants.ServiceBusNamespace),
                description.Filter?.Serialize(),
                description.Action?.Serialize(),
                new XElement(XName.Get("Name", AdministrationClientConstants.ServiceBusNamespace), description.Name));
        }
    }
}
