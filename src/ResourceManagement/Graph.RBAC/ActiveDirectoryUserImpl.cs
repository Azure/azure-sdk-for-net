// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Implementation for User and its parent interfaces.
    /// </summary>
    public partial class ActiveDirectoryUserImpl :
        CreatableUpdatable<IActiveDirectoryUser, UserInner, ActiveDirectoryUserImpl, IHasId, ActiveDirectoryUser.Update.IUpdate>,
        IActiveDirectoryUser,
        ActiveDirectoryUser.Definition.IDefinition,
        ActiveDirectoryUser.Update.IUpdate
    {
        private GraphRbacManager manager;
        private UserCreateParametersInner createParameters;
        private UserUpdateParametersInner updateParameters;
        private string emailAlias;

        string IHasId.Id => Inner.ObjectId;

        GraphRbacManager IHasManager<GraphRbacManager>.Manager => manager;

        internal ActiveDirectoryUserImpl(UserInner innerObject, GraphRbacManager manager)
                : base(innerObject.DisplayName, innerObject)
        {
            this.manager = manager;
            this.createParameters = new UserCreateParametersInner
            {
                DisplayName = Name,
                AccountEnabled = true
            };
            this.updateParameters = new UserUpdateParametersInner
            {
                DisplayName = Name
            };
        }

        public string Mail()
        {
            return Inner.Mail;
        }

        public GraphRbacManager Manager()
        {
            return manager;
        }

        public string SignInName()
        {
            return Inner.SignInName;
        }

        public string Id()
        {
            return Inner.ObjectId;
        }

        public string UserPrincipalName()
        {
            return Inner.UserPrincipalName;
        }

        public string MailNickname()
        {
            return Inner.MailNickname;
        }

        public CountryISOCode UsageLocation()
        {
            return CountryISOCode.Parse(Inner.UsageLocation);
        }

        public ActiveDirectoryUserImpl WithUserPrincipalName(string userPrincipalName)
        {
            createParameters.UserPrincipalName = userPrincipalName;
            if (IsInCreateMode() || updateParameters.MailNickname != null)
            {
                Regex regex = new Regex("@.+$");
                WithMailNickname(regex.Replace(userPrincipalName, ""));
            }
            return this;
        }

        public ActiveDirectoryUserImpl WithEmailAlias(string emailAlias)
        {
            this.emailAlias = emailAlias;
            return this;
        }

        public ActiveDirectoryUserImpl WithPassword(string password)
        {
            createParameters.PasswordProfile = new PasswordProfile
            {
                Password = password
            };
            return this;
        }

        private void WithMailNickname(string mailNickname)
        {
            createParameters.MailNickname = mailNickname;
            updateParameters.MailNickname = mailNickname;
        }

        public ActiveDirectoryUserImpl WithPromptToChangePasswordOnLogin(bool promptToChangePasswordOnLogin)
        {
            createParameters.PasswordProfile.ForceChangePasswordNextLogin = promptToChangePasswordOnLogin;
            return this;
        }

        public ActiveDirectoryUserImpl WithAccountEnabled(bool accountEnabled)
        {
            createParameters.AccountEnabled = accountEnabled;
            updateParameters.AccountEnabled = accountEnabled;
            return this;
        }

        public ActiveDirectoryUserImpl WithUsageLocation(CountryISOCode usageLocation)
        {
            createParameters.UsageLocation = usageLocation.Value;
            updateParameters.UsageLocation = usageLocation.Value;
            return this;
        }

        public override async Task<IActiveDirectoryUser> CreateResourceAsync(CancellationToken cancellationToken)
        {
            if (IsInCreateMode())
            {
                if (emailAlias != null)
                {
                    var domains = await manager.Inner.Domains.ListAsync(cancellationToken: cancellationToken);
                    foreach (var domain in domains)
                    {
                        if (domain.IsVerified != null && domain.IsDefault != null
                            && domain.IsVerified.Value && domain.IsDefault.Value)
                        {
                            if (emailAlias != null)
                            {
                                WithUserPrincipalName(emailAlias + "@" + domain.Name);
                                break;
                            }
                        }
                    }
                }
                SetInner(await manager.Inner.Users.CreateAsync(createParameters, cancellationToken));
                return this;
            }
            else
            {
                await manager.Inner.Users.UpdateAsync(Id(), updateParameters, cancellationToken);
                return await RefreshAsync(cancellationToken);
            }
        }

        protected override async Task<UserInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await manager.Inner.Users.GetAsync(Id(), cancellationToken);
        }

        private bool IsInCreateMode()
        {
            return Id() == null;
        }
    }
}