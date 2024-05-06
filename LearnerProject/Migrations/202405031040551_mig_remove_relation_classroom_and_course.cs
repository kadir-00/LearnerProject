namespace LearnerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_remove_relation_classroom_and_course : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClassRooms", "ClassRoom_ClassRoomId", "dbo.ClassRooms");
            DropForeignKey("dbo.Courses", "ClassRoomId", "dbo.ClassRooms");
            DropIndex("dbo.Courses", new[] { "ClassRoomId" });
            DropIndex("dbo.ClassRooms", new[] { "ClassRoom_ClassRoomId" });
            DropColumn("dbo.Courses", "ClassRoomId");
            DropColumn("dbo.ClassRooms", "ClassRoom_ClassRoomId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ClassRooms", "ClassRoom_ClassRoomId", c => c.Int());
            AddColumn("dbo.Courses", "ClassRoomId", c => c.Int(nullable: false));
            CreateIndex("dbo.ClassRooms", "ClassRoom_ClassRoomId");
            CreateIndex("dbo.Courses", "ClassRoomId");
            AddForeignKey("dbo.Courses", "ClassRoomId", "dbo.ClassRooms", "ClassRoomId", cascadeDelete: true);
            AddForeignKey("dbo.ClassRooms", "ClassRoom_ClassRoomId", "dbo.ClassRooms", "ClassRoomId");
        }
    }
}
