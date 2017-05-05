namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Todoes", "User", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Todoes", "User");
        }
    }
}
