namespace IceCreamApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CountryId = c.Long(),
                        Line1 = c.String(),
                        Line2 = c.String(),
                        StateId = c.Long(),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .ForeignKey("dbo.States", t => t.StateId)
                .Index(t => t.CountryId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Abbreviation = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IceCreams",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CreationCost = c.Double(nullable: false),
                        ImageLink = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AddressId = c.Long(),
                        ManagerName = c.String(),
                        Phone = c.String(),
                        StoreName = c.String(),
                        OperationalStatus = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.StoreIceCreams",
                c => new
                    {
                        StoreRefId = c.Long(nullable: false),
                        IceCreamRefId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.StoreRefId, t.IceCreamRefId })
                .ForeignKey("dbo.Stores", t => t.StoreRefId, cascadeDelete: true)
                .ForeignKey("dbo.IceCreams", t => t.IceCreamRefId, cascadeDelete: true)
                .Index(t => t.StoreRefId)
                .Index(t => t.IceCreamRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StoreIceCreams", "IceCreamRefId", "dbo.IceCreams");
            DropForeignKey("dbo.StoreIceCreams", "StoreRefId", "dbo.Stores");
            DropForeignKey("dbo.Stores", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Addresses", "StateId", "dbo.States");
            DropForeignKey("dbo.Addresses", "CountryId", "dbo.Countries");
            DropIndex("dbo.StoreIceCreams", new[] { "IceCreamRefId" });
            DropIndex("dbo.StoreIceCreams", new[] { "StoreRefId" });
            DropIndex("dbo.Stores", new[] { "AddressId" });
            DropIndex("dbo.Addresses", new[] { "StateId" });
            DropIndex("dbo.Addresses", new[] { "CountryId" });
            DropTable("dbo.StoreIceCreams");
            DropTable("dbo.Stores");
            DropTable("dbo.IceCreams");
            DropTable("dbo.States");
            DropTable("dbo.Countries");
            DropTable("dbo.Addresses");
        }
    }
}
