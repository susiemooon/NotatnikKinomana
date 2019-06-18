namespace NotatnikKinomana.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DoObejrzeniaFilm",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FilmID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Film", t => t.FilmID, cascadeDelete: true)
                .Index(t => t.FilmID);
            
            CreateTable(
                "dbo.Film",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        nazwa = c.String(),
                        opis = c.String(),
                        data_premiery = c.DateTime(nullable: false),
                        plakat = c.String(),
                        srednia_ocen = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Gatunek",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Kraj",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        nazwa = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Osoba",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        imie = c.String(),
                        nazwisko = c.String(),
                        KrajID = c.Int(nullable: false),
                        data_urodzenia = c.DateTime(nullable: false),
                        biografia = c.String(),
                        photo = c.String(),
                        profesja = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Kraj", t => t.KrajID, cascadeDelete: true)
                .Index(t => t.KrajID);
            
            CreateTable(
                "dbo.Rola",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        nazwa = c.String(),
                        photo = c.String(),
                        filmID = c.Int(nullable: false),
                        aktorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Osoba", t => t.aktorID, cascadeDelete: true)
                .ForeignKey("dbo.Film", t => t.filmID, cascadeDelete: true)
                .Index(t => t.filmID)
                .Index(t => t.aktorID);
            
            CreateTable(
                "dbo.Recenzja",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        tytul = c.String(),
                        tekst = c.String(),
                        ocena = c.Int(nullable: false),
                        autorID = c.String(),
                        FilmID = c.Int(nullable: false),
                        autor_username = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Uzytkownik", t => t.autor_username)
                .ForeignKey("dbo.Film", t => t.FilmID, cascadeDelete: true)
                .Index(t => t.FilmID)
                .Index(t => t.autor_username);
            
            CreateTable(
                "dbo.Uzytkownik",
                c => new
                    {
                        username = c.String(nullable: false, maxLength: 128),
                        email = c.String(),
                        haslo = c.String(),
                    })
                .PrimaryKey(t => t.username);
            
            CreateTable(
                "dbo.ObejrzanyFilm",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FilmID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Film", t => t.FilmID, cascadeDelete: true)
                .Index(t => t.FilmID);
            
            CreateTable(
                "dbo.GatunekFilm",
                c => new
                    {
                        Gatunek_ID = c.Int(nullable: false),
                        Film_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Gatunek_ID, t.Film_ID })
                .ForeignKey("dbo.Gatunek", t => t.Gatunek_ID, cascadeDelete: true)
                .ForeignKey("dbo.Film", t => t.Film_ID, cascadeDelete: true)
                .Index(t => t.Gatunek_ID)
                .Index(t => t.Film_ID);
            
            CreateTable(
                "dbo.KrajFilm",
                c => new
                    {
                        Kraj_ID = c.Int(nullable: false),
                        Film_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Kraj_ID, t.Film_ID })
                .ForeignKey("dbo.Kraj", t => t.Kraj_ID, cascadeDelete: true)
                .ForeignKey("dbo.Film", t => t.Film_ID, cascadeDelete: true)
                .Index(t => t.Kraj_ID)
                .Index(t => t.Film_ID);
            
            CreateTable(
                "dbo.UzytkownikDoObejrzeniaFilm",
                c => new
                    {
                        Uzytkownik_username = c.String(nullable: false, maxLength: 128),
                        DoObejrzeniaFilm_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Uzytkownik_username, t.DoObejrzeniaFilm_ID })
                .ForeignKey("dbo.Uzytkownik", t => t.Uzytkownik_username, cascadeDelete: true)
                .ForeignKey("dbo.DoObejrzeniaFilm", t => t.DoObejrzeniaFilm_ID, cascadeDelete: true)
                .Index(t => t.Uzytkownik_username)
                .Index(t => t.DoObejrzeniaFilm_ID);
            
            CreateTable(
                "dbo.ObejrzanyFilmUzytkownik",
                c => new
                    {
                        ObejrzanyFilm_ID = c.Int(nullable: false),
                        Uzytkownik_username = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ObejrzanyFilm_ID, t.Uzytkownik_username })
                .ForeignKey("dbo.ObejrzanyFilm", t => t.ObejrzanyFilm_ID, cascadeDelete: true)
                .ForeignKey("dbo.Uzytkownik", t => t.Uzytkownik_username, cascadeDelete: true)
                .Index(t => t.ObejrzanyFilm_ID)
                .Index(t => t.Uzytkownik_username);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DoObejrzeniaFilm", "FilmID", "dbo.Film");
            DropForeignKey("dbo.Recenzja", "FilmID", "dbo.Film");
            DropForeignKey("dbo.Recenzja", "autor_username", "dbo.Uzytkownik");
            DropForeignKey("dbo.ObejrzanyFilmUzytkownik", "Uzytkownik_username", "dbo.Uzytkownik");
            DropForeignKey("dbo.ObejrzanyFilmUzytkownik", "ObejrzanyFilm_ID", "dbo.ObejrzanyFilm");
            DropForeignKey("dbo.ObejrzanyFilm", "FilmID", "dbo.Film");
            DropForeignKey("dbo.UzytkownikDoObejrzeniaFilm", "DoObejrzeniaFilm_ID", "dbo.DoObejrzeniaFilm");
            DropForeignKey("dbo.UzytkownikDoObejrzeniaFilm", "Uzytkownik_username", "dbo.Uzytkownik");
            DropForeignKey("dbo.Rola", "filmID", "dbo.Film");
            DropForeignKey("dbo.Rola", "aktorID", "dbo.Osoba");
            DropForeignKey("dbo.Osoba", "KrajID", "dbo.Kraj");
            DropForeignKey("dbo.KrajFilm", "Film_ID", "dbo.Film");
            DropForeignKey("dbo.KrajFilm", "Kraj_ID", "dbo.Kraj");
            DropForeignKey("dbo.GatunekFilm", "Film_ID", "dbo.Film");
            DropForeignKey("dbo.GatunekFilm", "Gatunek_ID", "dbo.Gatunek");
            DropIndex("dbo.ObejrzanyFilmUzytkownik", new[] { "Uzytkownik_username" });
            DropIndex("dbo.ObejrzanyFilmUzytkownik", new[] { "ObejrzanyFilm_ID" });
            DropIndex("dbo.UzytkownikDoObejrzeniaFilm", new[] { "DoObejrzeniaFilm_ID" });
            DropIndex("dbo.UzytkownikDoObejrzeniaFilm", new[] { "Uzytkownik_username" });
            DropIndex("dbo.KrajFilm", new[] { "Film_ID" });
            DropIndex("dbo.KrajFilm", new[] { "Kraj_ID" });
            DropIndex("dbo.GatunekFilm", new[] { "Film_ID" });
            DropIndex("dbo.GatunekFilm", new[] { "Gatunek_ID" });
            DropIndex("dbo.ObejrzanyFilm", new[] { "FilmID" });
            DropIndex("dbo.Recenzja", new[] { "autor_username" });
            DropIndex("dbo.Recenzja", new[] { "FilmID" });
            DropIndex("dbo.Rola", new[] { "aktorID" });
            DropIndex("dbo.Rola", new[] { "filmID" });
            DropIndex("dbo.Osoba", new[] { "KrajID" });
            DropIndex("dbo.DoObejrzeniaFilm", new[] { "FilmID" });
            DropTable("dbo.ObejrzanyFilmUzytkownik");
            DropTable("dbo.UzytkownikDoObejrzeniaFilm");
            DropTable("dbo.KrajFilm");
            DropTable("dbo.GatunekFilm");
            DropTable("dbo.ObejrzanyFilm");
            DropTable("dbo.Uzytkownik");
            DropTable("dbo.Recenzja");
            DropTable("dbo.Rola");
            DropTable("dbo.Osoba");
            DropTable("dbo.Kraj");
            DropTable("dbo.Gatunek");
            DropTable("dbo.Film");
            DropTable("dbo.DoObejrzeniaFilm");
        }
    }
}
