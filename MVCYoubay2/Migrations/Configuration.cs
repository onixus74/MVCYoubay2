namespace MVCYoubay2.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCYoubay2.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MVCYoubay2.Models.ApplicationDbContext";
        }

        protected override void Seed(MVCYoubay2.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            // Add Categories
            var Categories = new List<t_category> {
                new t_category {  categoryName = "Electronics" ,categoryId=1},
                new t_category {  categoryName = "Fashion",categoryId=2},
                new t_category {  categoryName = "Collectibles & Art",categoryId=3},
                new t_category {  categoryName = "Home & Gargen",categoryId=4},
                new t_category {  categoryName = "Sporting Goods",categoryId=5},
                new t_category {  categoryName = "Motors",categoryId=6},
            };

            foreach (var item in Categories)
            {
                context.t_category.AddOrUpdate(item);
            }

            //Add Subcategories
            var Subcategories = new List<t_subcategory> {
                new t_subcategory { categoryName="Phones",  category_categoryId=1 , subcategoryId = 1},
                new t_subcategory { categoryName="Cameras",  category_categoryId=1 , subcategoryId = 2},
                new t_subcategory { categoryName="Computers",  category_categoryId=1 , subcategoryId = 3},
                new t_subcategory { categoryName="Women",  category_categoryId=2 , subcategoryId = 4},
                new t_subcategory { categoryName="Men",  category_categoryId=2 , subcategoryId = 5},
                new t_subcategory { categoryName="Kids & Baby",  category_categoryId=2 , subcategoryId = 6},
                new t_subcategory { categoryName="Antiques",  category_categoryId=3 , subcategoryId = 7},
                new t_subcategory { categoryName="Collectibles",  category_categoryId=3 , subcategoryId = 8},

            };
            foreach (var item in Subcategories)
            {
                context.t_subcategory.AddOrUpdate(item);
            }


            //Add Products
            var Products = new List<t_product> {
                new t_product {
                    productName ="Asus G74sx",
                    sellerPrice =1400,
                    productDescription ="Asus PC Gamer 2011" ,
                    productImage ="Content/img/Electronics/Computers/asusg74sx.jpg" ,
                    seller_youBayUserId =2,
                    subcategory_subcategoryId =3 ,
                    productId =1
                },
                new t_product {
                    productName ="Alienware M18",
                    sellerPrice =3400,
                    productDescription ="Alienware PC Gamer 2014" ,
                    productImage ="Content/img/Electronics/Computers/alienwarem18.jpg" ,
                    seller_youBayUserId =2,
                    subcategory_subcategoryId =3 ,
                    productId =2
                },
                new t_product {
                    productName ="Macbook Pro",
                    sellerPrice =2400,
                    productDescription ="Apple Macbook Pro 2011" ,
                    productImage ="Content/img/Electronics/Computers/macbookpro.jpg" ,
                    seller_youBayUserId =2,
                    subcategory_subcategoryId =3 ,
                    productId =3
                },
            };

            foreach (var item in Products)
            {
                context.t_product.AddOrUpdate(item);
            }


        }
    }
}
