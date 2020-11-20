using Shop.Core.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace shop.DataAccess.SqL {
    public class ShopContext : DbContext {
        // Votre contexte a été configuré pour utiliser une chaîne de connexion « ShopContext » du fichier 
        // de configuration de votre application (App.config ou Web.config). Par défaut, cette chaîne de connexion cible 
        // la base de données « shop.DataAccess.SqL.ShopContext » sur votre instance LocalDb. 
        // 
        // Pour cibler une autre base de données et/ou un autre fournisseur de base de données, modifiez 
        // la chaîne de connexion « ShopContext » dans le fichier de configuration de l'application.
        public ShopContext()
            : base("name=ShopContext") {
        }

        // Ajoutez un DbSet pour chaque type d'entité à inclure dans votre modèle. Pour plus d'informations 
        // sur la configuration et l'utilisation du modèle Code First, consultez http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}