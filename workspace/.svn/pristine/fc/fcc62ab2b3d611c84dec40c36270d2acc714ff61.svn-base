namespace FVTS.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebMatrix.WebData;
    using System.Web.Security;
    using FVTS.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<FVTS.Models.UsersContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(FVTS.Models.UsersContext context)
        {
            WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            if (!roles.RoleExists("Administrator"))
            {
                roles.CreateRole("Administrator");
            }
            if (!roles.RoleExists("Coordinator"))
            {
                roles.CreateRole("Coordinator");
            }
            if (membership.GetUser("admin", false) == null)
            {
                membership.CreateUserAndAccount("admin", "admin");
            }
            if (!roles.GetRolesForUser("admin").Contains("Administrator"))
            {
                roles.AddUsersToRoles(new[] { "admin" }, new[] { "Administrator" });
            }
         }
    }
}
