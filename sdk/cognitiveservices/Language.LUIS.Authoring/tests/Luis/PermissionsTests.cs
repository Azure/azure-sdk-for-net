namespace LUIS.Authoring.Tests.Luis
{
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring.Models;
    using Xunit;

    [Collection("TestCollection")]
    public class PermissionsTests : BaseTest
    {
        [Fact]
        public void ListPermissions()
        {
            UseClientFor(async client =>
            {
                var collaborators = new CollaboratorsArray
                {
                    Emails = new string[]
                    {
                        "guest@outlook.com",
                        "invited.user@live.com"
                    }
                };

                await client.Permissions.UpdateAsync(GlobalAppId, collaborators);
                var result = await client.Permissions.ListAsync(GlobalAppId);

                var userToRemove = new UserCollaborator
                {
                    Email = "guest@outlook.com"
                };
                await client.Permissions.DeleteAsync(GlobalAppId, userToRemove);
                userToRemove = new UserCollaborator
                {
                    Email = "invited.user@live.com"
                };
                await client.Permissions.DeleteAsync(GlobalAppId, userToRemove);

                Assert.Equal(OwnerEmail, result.Owner);
                Assert.Equal(new string[] { "guest@outlook.com", "invited.user@live.com" }, result.Emails);
            });
        }

        [Fact]
        public void AddPermission()
        {
            UseClientFor(async client =>
            {
                var userToAdd = new UserCollaborator
                {
                    Email = "guest@outlook.com"
                };

                await client.Permissions.AddAsync(GlobalAppId, userToAdd);
                var result = await client.Permissions.ListAsync(GlobalAppId);
                await client.Permissions.DeleteAsync(GlobalAppId, userToAdd);

                Assert.True(result.Emails.Contains(userToAdd.Email));
            });
        }

        [Fact]
        public void DeletePermission()
        {
            UseClientFor(async client =>
            {
                var userToRemove = new UserCollaborator
                {
                    Email = "guest@outlook.com"
                };

                await client.Permissions.AddAsync(GlobalAppId, userToRemove);
                await client.Permissions.DeleteAsync(GlobalAppId, userToRemove);
                var result = await client.Permissions.ListAsync(GlobalAppId);

                Assert.False(result.Emails.Contains(userToRemove.Email));
            });
        }

        [Fact]
        public void UpdatePermission()
        {
            UseClientFor(async client =>
            {
                var collaborators = new CollaboratorsArray
                {
                    Emails = new string[] 
                    {
                        "guest@outlook.com",
                        "invited.user@live.com"
                    }
                };

                await client.Permissions.UpdateAsync(GlobalAppId, collaborators);
                var result = await client.Permissions.ListAsync(GlobalAppId);
                await client.Permissions.UpdateAsync(GlobalAppId, new CollaboratorsArray { Emails = new string[0] });

                Assert.Equal(collaborators.Emails, result.Emails);
            });
        }
    }
}
