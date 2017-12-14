using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Vidly.Data.Migrations
{
    public partial class SeedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
INSERT INTO [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'0deb739c-460a-444a-b4d3-4d304cabc880', N'abd5f986-41dc-4438-a765-a842a051a273', N'MovieManager', N'MOVIEMANAGER')
INSERT INTO [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'614d7c2d-d8e4-4dbe-b00d-084c5078fc3e', N'd628dfb0-8e98-4550-bf4f-9b98da6f34c2', N'CustomerManager', N'CUSTOMERMANAGER')
INSERT INTO [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'f43a0a72-7b2d-4e36-8c98-955df7496c87', N'8931b59b-01ad-4a45-b1a4-d32e8008edf1', N'Admin', N'ADMIN')

INSERT INTO [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'64596e20-7243-4960-af88-d4b4a7a6e8c4', 0, N'd3ced848-6bd1-4ace-ab92-48069f380d12', N'admin@sakadream.me', 0, 1, NULL, N'ADMIN@SAKADREAM.ME', N'ADMIN@SAKADREAM.ME', N'AQAAAAEAACcQAAAAELubWh2c8hBvR3J9GrKDaaGSWYFzIpHMukIYIhXUnh0++mMHyKHoPp/dAuG9Jnh+KA==', NULL, 0, N'cef4840a-540f-4ea1-a52e-ae9400fdbbdc', 0, N'admin@sakadream.me')
INSERT INTO [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'8dccc002-04cd-4664-a69a-ebe01efe27ec', 0, N'9d502bfa-a24f-4aa4-a967-f0037934eed4', N'cm@sakadream.me', 0, 1, NULL, N'CM@SAKADREAM.ME', N'CM@SAKADREAM.ME', N'AQAAAAEAACcQAAAAEIhGJ1m9Yckpfh8j0ziz5fMJZ/r3iCBSAdvV+aGuriZBv3PsC+VHulJ38CCE0rd6sw==', NULL, 0, N'2f3e42b9-b237-4bf4-8e96-43c0d84e1098', 0, N'cm@sakadream.me')
INSERT INTO [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'c9c75ee3-9da6-4da3-8249-73ea0a73c5f6', 0, N'98fb39b3-e883-47a8-b405-c6bf87298b6e', N'bahaimt@gmail.com', 0, 1, NULL, N'BAHAIMT@GMAIL.COM', N'BAHAIMT@GMAIL.COM', N'AQAAAAEAACcQAAAAEE7iTRRWWS78s4Jz3cIvvBr8ezKd+mcddvasucWmgCmqfnpNA+gJwq03ubGWkdOmCg==', NULL, 0, N'ce1f3eed-806d-4bba-a478-7497e25edad2', 0, N'bahaimt@gmail.com')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'64596e20-7243-4960-af88-d4b4a7a6e8c4', N'0deb739c-460a-444a-b4d3-4d304cabc880')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8dccc002-04cd-4664-a69a-ebe01efe27ec', N'614d7c2d-d8e4-4dbe-b00d-084c5078fc3e')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c9c75ee3-9da6-4da3-8249-73ea0a73c5f6', N'f43a0a72-7b2d-4e36-8c98-955df7496c87')
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
