namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tasks", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tasks", "Name", c => c.Int(nullable: false));
        }
    }
}
