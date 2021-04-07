namespace SBSClientServerManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Userroles : DbMigration
    {
        public override void Up()
        {
            Sql(
                @"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'43cfe81f-7a2b-44ee-8a54-a8dbb3e8c0c5', N'admin@simplex.com', 0, N'AAfV5NIe5ynsXyaFFpSdCo+izBnLH/MEkbQVINWe0Vi4WB0Le2fNMbRWXWRdCGOBxw==', N'65f17658-f98b-4460-9b9a-acc9ded0cfa6', NULL, 0, 0, NULL, 1, 0, N'admin@simplex.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'eb262b11-bd77-4a67-aad7-476c2eb1c5f0', N'user@simplex.com', 0, N'AAPd2BrCJRwuzzxmMiV38106ngC+dQODz6ljhuKYRa4ZH4Q8nquhhyIp39FGuhYQbQ==', N'c44660cc-3c30-45f3-a209-fe8a69a98540', NULL, 0, 0, NULL, 1, 0, N'user@simplex.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'8f486217-6b7d-4de7-b449-ac18855f2bdf', N'CanManageAllClientDetails')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'43cfe81f-7a2b-44ee-8a54-a8dbb3e8c0c5', N'8f486217-6b7d-4de7-b449-ac18855f2bdf')


"
                );
            
        }
        
        public override void Down()
        {
        }
    }
}
