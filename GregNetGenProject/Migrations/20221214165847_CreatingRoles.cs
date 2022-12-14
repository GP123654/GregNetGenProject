using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable


//CODE TAKEN FROM HERE AND ADAPTED BY ME
//https://www.youtube.com/watch?v=E8JaZdtXTBQ


namespace GregNetGenProject.Migrations
{
    /// <inheritdoc />
    public partial class CreatingRoles : Migration
    {
        private string ReporterRoleId = Guid.NewGuid().ToString();
        private string UserRoleId = Guid.NewGuid().ToString();
        private string AdminRoleId = Guid.NewGuid().ToString();

        //private string User1Id = Guid.NewGuid().ToString();
        //private string User2Id = Guid.NewGuid().ToString();

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            SeedRolesSQL(migrationBuilder);

            //SeedUser(migrationBuilder);

            SeedUserRoles(migrationBuilder);
        }

        private void SeedRolesSQL(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            VALUES ('{AdminRoleId}', 'Admin', 'ADMIN', null);");
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            VALUES ('{ReporterRoleId}', 'Reporter', 'REPORTER', null);");
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            VALUES ('{UserRoleId}', 'User', 'USER', null);");
        }
        /*
        private void SeedUser(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @$"INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], 
[Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], 
[PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) 
VALUES 
(N'{User1Id}', N'test2@test.ca', N'TEST2@TEST.CA', 
N'test2@test.ca', N'TEST2@TEST.CA', 0, 
N'AQAAAAEAACcQAAAAEDGQ5wwj6Iz0lXHIZ5IwuvgSO88jrSBT1etWcDYjJN5CBNDKvddZcEeixYBYmcdFag==', 
N'YUPAFWNGZI2UC5FOITC7PX5J7XZTAZAA', N'8e150555-a20d-4610-93ff-49c5af44f749', NULL, 0, 0, NULL, 1, 0)");

            migrationBuilder.Sql(
                @$"INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], 
[Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], 
[PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) 
VALUES 
(N'{User2Id}', N'test3@test.ca', N'TEST3@TEST.CA', 
N'test3@test.ca', N'TEST3@TEST.CA', 0, 
N'AQAAAAEAACcQAAAAEDGQ5wwj6Iz0lXHIZ5IwuvgSO88jrSBT1etWcDYjJN5CBNDKvddZcEeixYBYmcdFag==', 
N'YUPAFWNGZI2UC5FOITC7PX5J7XZTAZAA', N'8e150555-a20d-4610-93ff-49c5af44f749', NULL, 0, 0, NULL, 1, 0)");
        }*/

        private void SeedUserRoles(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@$"
        INSERT INTO [dbo].[AspNetUserRoles]
           ([UserId]
           ,[RoleId])
        VALUES
           ('4763d0bb-9261-4db1-b5b8-325b9ebf0ab2', '{AdminRoleId}');");

            migrationBuilder.Sql(@$"
        INSERT INTO [dbo].[AspNetUserRoles]
           ([UserId]
           ,[RoleId])
        VALUES
           ('67331377-3432-4726-887e-89b2fd2280dc', '{ReporterRoleId}');");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
