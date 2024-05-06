namespace LearnerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        AboutId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        ImageUrl = c.String(),
                        Item1 = c.String(),
                        Item2 = c.String(),
                        Item3 = c.String(),
                    })
                .PrimaryKey(t => t.AboutId);
            
            CreateTable(
                "dbo.Banners",
                c => new
                    {
                        BannerId = c.Int(nullable: false, identity: true),
                        Title = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BannerId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        Icon = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                        ImageUrl = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoryId = c.Int(nullable: false),
                        ClassRoomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.ClassRooms", t => t.ClassRoomId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.ClassRoomId);
            
            CreateTable(
                "dbo.ClassRooms",
                c => new
                    {
                        ClassRoomId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Icon = c.String(),
                        Description = c.String(),
                        ClassRoom_ClassRoomId = c.Int(),
                    })
                .PrimaryKey(t => t.ClassRoomId)
                .ForeignKey("dbo.ClassRooms", t => t.ClassRoom_ClassRoomId)
                .Index(t => t.ClassRoom_ClassRoomId);
            
            CreateTable(
                "dbo.CourseRegisters",
                c => new
                    {
                        CourseRegisterId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseRegisterId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        ReviewValue = c.Double(nullable: false),
                        Comment = c.String(),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.FAQs",
                c => new
                    {
                        FAQId = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                        Answer = c.String(),
                        ImageUrl = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FAQId);
            
            CreateTable(
                "dbo.Teslimonials",
                c => new
                    {
                        TeslimonialId = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(),
                        Title = c.String(),
                        ImageUrl = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.TeslimonialId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Reviews", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CourseRegisters", "StudentId", "dbo.Students");
            DropForeignKey("dbo.CourseRegisters", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "ClassRoomId", "dbo.ClassRooms");
            DropForeignKey("dbo.ClassRooms", "ClassRoom_ClassRoomId", "dbo.ClassRooms");
            DropForeignKey("dbo.Courses", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Reviews", new[] { "StudentId" });
            DropIndex("dbo.Reviews", new[] { "CourseId" });
            DropIndex("dbo.CourseRegisters", new[] { "CourseId" });
            DropIndex("dbo.CourseRegisters", new[] { "StudentId" });
            DropIndex("dbo.ClassRooms", new[] { "ClassRoom_ClassRoomId" });
            DropIndex("dbo.Courses", new[] { "ClassRoomId" });
            DropIndex("dbo.Courses", new[] { "CategoryId" });
            DropTable("dbo.Teslimonials");
            DropTable("dbo.FAQs");
            DropTable("dbo.Reviews");
            DropTable("dbo.Students");
            DropTable("dbo.CourseRegisters");
            DropTable("dbo.ClassRooms");
            DropTable("dbo.Courses");
            DropTable("dbo.Categories");
            DropTable("dbo.Banners");
            DropTable("dbo.Abouts");
        }
    }
}
