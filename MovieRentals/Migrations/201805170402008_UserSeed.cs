namespace MovieRentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserSeed : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'43a7e5bd-d41c-49a7-a797-183dcc2f7e9f', N'admn@movierentals.com', 0, N'AF6n1i10+gROK2f9g0TPeWG2tIZtcVyMNyKYSQIIp1Cppw0KRUNvt4GHMU0k/9WkFA==', N'ddec1344-e8e2-447b-8687-5dd58402792e', NULL, 0, 0, NULL, 1, 0, N'admn@movierentals.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b0e21af3-800e-4260-a326-ef38bdac7d65', N'guest@movierentals.com', 0, N'AFB+hOMYO7TewnRt7PyiY9kD8LOBiviYtKhikyBmeZgHw4a2SbMTVu2YJYJKsxBxXQ==', N'89992d96-8d33-4bd2-9dde-a74b4d39ed5a', NULL, 0, 0, NULL, 1, 0, N'guest@movierentals.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2815ec6e-c81c-4526-953b-f267a5809f5d', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'43a7e5bd-d41c-49a7-a797-183dcc2f7e9f', N'2815ec6e-c81c-4526-953b-f267a5809f5d')

");
        }
        
        public override void Down()
        {
        }
    }
}
