// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Communication.JobRouter.Tests.RouterClients
{
    public class ExpressionRuleTests
    {
        [Test]
        public void ConstructorWithLanguageDoesNotExists()
        {
            Assert.Throws<MissingMethodException>(() =>
            {
                var rule = Activator.CreateInstance(typeof(ExpressionRule), "PowerFx", "expression");
            });
        }

        [Test]
        public void LanguageOnExpressionContainerDoesNotHaveSetter()
        {
            var type = typeof(ExpressionRule);
            var languagePropertyInfo = type.GetProperty("Language");
            if (languagePropertyInfo is not null)
            {
                var getSetMethodForLanguage = languagePropertyInfo.GetSetMethod();
                Assert.IsNull(getSetMethodForLanguage);
            }
        }
    }
}
