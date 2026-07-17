namespace TravelTripProje.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BlogYorumGuncelleme : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blogs", "Baslik", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Blogs", "Açiklama", c => c.String(nullable: false, maxLength: 4000));
            AlterColumn("dbo.Yorumlars", "KullaniciAdi", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Yorumlars", "Mail", c => c.String(nullable: false));
            AlterColumn("dbo.Yorumlars", "Yorum", c => c.String(nullable: false, maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Yorumlars", "Yorum", c => c.String());
            AlterColumn("dbo.Yorumlars", "Mail", c => c.String());
            AlterColumn("dbo.Yorumlars", "KullaniciAdi", c => c.String());
            AlterColumn("dbo.Blogs", "Açiklama", c => c.String());
            AlterColumn("dbo.Blogs", "Baslik", c => c.String());
        }
    }
}
