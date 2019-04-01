using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Az.Auth.FullDesktop.Test
{
    public class UserLoginTests : AuthFullDesktopTestBase
    {
        public UserLoginTests()
        {

        }

        [Fact]
        public void InteractiveUserLogin()
        {
            Type userProviderType = null;
            Type appProviderType = null;

            Assembly asm = Assembly.LoadFrom(GetProductAssemblyPath());
            var tknProviderTypes = asm.GetTypes().Where<Type>((t) => t.Name.Equals("UserTokenProvider", StringComparison.OrdinalIgnoreCase));
            var appTknProviderTypes = asm.GetTypes().Where<Type>((t) => t.Name.Equals("ApplicationTokenProvider", StringComparison.OrdinalIgnoreCase));

            if (tknProviderTypes.Any<Type>())
            {
                userProviderType = tknProviderTypes.First<Type>();
            }

            if (appTknProviderTypes.Any<Type>())
            {
                appProviderType = appTknProviderTypes.First<Type>();
            }

            var userLoginApis = userProviderType.GetMethods().Where<MethodInfo>((mi) => mi.Name.Contains("Login"));
            var deviceAuthApis = userProviderType.GetMethods().Where<MethodInfo>((mi) => mi.Name.Contains("LoginByDeviceCodeAsync"));
            var interactiveLoginApis = userProviderType.GetMethods().Where<MethodInfo>((mi) => mi.Name.Contains("LoginWithPromptAsync"));
            var appLoginApis = appProviderType.GetMethods().Where<MethodInfo>((mi) => mi.Name.Contains("Login"));

            Assert.Equal(5, userLoginApis.Count<MethodInfo>());
            Assert.Equal(0, interactiveLoginApis.Count<MethodInfo>());
            Assert.Equal(5, deviceAuthApis.Count<MethodInfo>());
            Assert.Equal(20, appLoginApis.Count<MethodInfo>());
        }
    }
}
