namespace MVCYoubay2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.t_assistantitems",
                c => new
                    {
                        assistantItemsId = c.Long(nullable: false, identity: true),
                        affirmativeAnswer = c.String(),
                        affirmativeAnswerQuery = c.String(),
                        negativeAnswer = c.String(),
                        negativeAnswerQuery = c.String(),
                        questionDisplayPriority = c.Int(),
                        questionText = c.String(),
                        subcategory_subcategoryId = c.Long(),
                        t_subcategory_subcategoryId = c.Long(),
                    })
                .PrimaryKey(t => t.assistantItemsId)
                .ForeignKey("dbo.t_subcategory", t => t.t_subcategory_subcategoryId)
                .Index(t => t.t_subcategory_subcategoryId);
            
            CreateTable(
                "dbo.t_subcategory",
                c => new
                    {
                        subcategoryId = c.Long(nullable: false, identity: true),
                        categoryName = c.String(),
                        category_categoryId = c.Long(),
                        assistantAvatarImage = c.String(),
                        categoryDisplayPriority = c.Int(),
                        isActive = c.Boolean(),
                        subcategoryAttributesAndTypes = c.String(),
                        t_category_categoryId = c.Long(),
                    })
                .PrimaryKey(t => t.subcategoryId)
                .ForeignKey("dbo.t_category", t => t.t_category_categoryId)
                .Index(t => t.t_category_categoryId);
            
            CreateTable(
                "dbo.t_category",
                c => new
                    {
                        categoryId = c.Long(nullable: false, identity: true),
                        categoryDisplayPriority = c.Int(),
                        categoryName = c.String(),
                    })
                .PrimaryKey(t => t.categoryId);
            
            CreateTable(
                "dbo.t_product",
                c => new
                    {
                        productId = c.Int(nullable: false, identity: true),
                        productName = c.String(),
                        productDescription = c.String(),
                        sellerPrice = c.Single(nullable: false),
                        subcategory_subcategoryId = c.Int(nullable: false),
                        quantityAvailable = c.Int(nullable: false),
                        productIWmage = c.String(),
                        isDisabledByAdmin = c.Boolean(),
                        isDisabledBySeller = c.Boolean(),
                        subcategoryAttributesAndValues = c.String(),
                        seller_youBayUserId = c.Long(),
                        t_user_youBayUserId = c.Long(),
                        t_user_youBayUserId1 = c.Long(),
                        t_subcategory_subcategoryId = c.Long(),
                        t_user_youBayUserId2 = c.Long(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        ApplicationUser_Id1 = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.productId)
                .ForeignKey("dbo.t_user", t => t.t_user_youBayUserId)
                .ForeignKey("dbo.t_user", t => t.t_user_youBayUserId1)
                .ForeignKey("dbo.t_subcategory", t => t.t_subcategory_subcategoryId)
                .ForeignKey("dbo.t_user", t => t.t_user_youBayUserId2)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id1)
                .Index(t => t.t_user_youBayUserId)
                .Index(t => t.t_user_youBayUserId1)
                .Index(t => t.t_subcategory_subcategoryId)
                .Index(t => t.t_user_youBayUserId2)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id1);
            
            CreateTable(
                "dbo.t_auction",
                c => new
                    {
                        auctionId = c.Long(nullable: false, identity: true),
                        currentPrice = c.Single(),
                        endTime = c.DateTime(),
                        startTime = c.DateTime(),
                        buyer_youBayUserId = c.Long(),
                        product_productId = c.Long(),
                        t_product_productId = c.Int(),
                        t_user_youBayUserId = c.Long(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.auctionId)
                .ForeignKey("dbo.t_product", t => t.t_product_productId)
                .ForeignKey("dbo.t_user", t => t.t_user_youBayUserId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.t_product_productId)
                .Index(t => t.t_user_youBayUserId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.t_user",
                c => new
                    {
                        youBayUserId = c.Long(nullable: false, identity: true),
                        USER_TYPE = c.String(),
                        birthday = c.DateTime(),
                        countryOfResidence = c.String(),
                        email = c.String(),
                        emailActivationToken = c.String(),
                        firstName = c.String(),
                        isActive = c.Boolean(),
                        isBanned = c.Boolean(),
                        lastName = c.String(),
                        phoneNumber = c.String(),
                        complaintPercentage = c.Single(),
                        gamificationScore = c.Single(),
                        sellerBadges = c.String(),
                        sellerDescription = c.String(),
                        sellerIsSuspiciousFlag = c.Boolean(),
                        sellerLogo = c.String(),
                        totalSales = c.Single(),
                        canAddAdvertisement = c.Boolean(),
                        canExportData = c.Boolean(),
                        canManageCategories = c.Boolean(),
                        canManageManagers = c.Boolean(),
                        canModerateSellersAndBuyers = c.Boolean(),
                        accountBalance = c.Single(),
                        addressCity = c.String(),
                        addressLine1 = c.String(),
                        addressLine2 = c.String(),
                        buyerBadges = c.String(),
                        iSMale = c.Boolean(),
                        totalSpending = c.Single(),
                        customizedAds_customizedAdsId = c.Long(),
                        t_customizedads_customizedAdsId = c.Long(),
                        t_product_productId = c.Int(),
                    })
                .PrimaryKey(t => t.youBayUserId)
                .ForeignKey("dbo.t_customizedads", t => t.t_customizedads_customizedAdsId)
                .ForeignKey("dbo.t_product", t => t.t_product_productId)
                .Index(t => t.t_customizedads_customizedAdsId)
                .Index(t => t.t_product_productId);
            
            CreateTable(
                "dbo.t_customizedads",
                c => new
                    {
                        customizedAdsId = c.Long(nullable: false, identity: true),
                        customizedMessage = c.String(),
                        endDate = c.DateTime(),
                        importanceScore = c.Single(),
                        isACustomizedMarketingAd = c.Boolean(),
                        isAPurchasedAd = c.Boolean(),
                        startDate = c.DateTime(),
                        product_productId = c.Long(),
                        t_product_productId = c.Int(),
                    })
                .PrimaryKey(t => t.customizedAdsId)
                .ForeignKey("dbo.t_product", t => t.t_product_productId)
                .Index(t => t.t_product_productId);
            
            CreateTable(
                "dbo.t_historyofviews",
                c => new
                    {
                        buyerId = c.Long(nullable: false, identity: true),
                        productId = c.Long(nullable: false),
                        theDate = c.DateTime(nullable: false),
                        client = c.Int(),
                        comment = c.String(),
                        t_product_productId = c.Int(),
                        t_user_youBayUserId = c.Long(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.buyerId)
                .ForeignKey("dbo.t_product", t => t.t_product_productId)
                .ForeignKey("dbo.t_user", t => t.t_user_youBayUserId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.t_product_productId)
                .Index(t => t.t_user_youBayUserId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.t_orderandreview",
                c => new
                    {
                        buyerId = c.Long(nullable: false, identity: true),
                        productId = c.Long(nullable: false),
                        theDate = c.DateTime(nullable: false),
                        buyerHasLeftAReview = c.Boolean(),
                        hasFiledComplaint = c.Boolean(),
                        initialMessageToSeller = c.String(),
                        oderFulfilledBySeller = c.Boolean(),
                        orderDeliveredToBuyer = c.Boolean(),
                        pricePaidByBuyer = c.Single(),
                        productRating = c.Int(),
                        reviewText = c.String(),
                        reviewTitle = c.String(),
                        t_product_productId = c.Int(),
                        t_user_youBayUserId = c.Long(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.buyerId)
                .ForeignKey("dbo.t_product", t => t.t_product_productId)
                .ForeignKey("dbo.t_user", t => t.t_user_youBayUserId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.t_product_productId)
                .Index(t => t.t_user_youBayUserId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.t_producthistory",
                c => new
                    {
                        productHistoryId = c.Long(nullable: false, identity: true),
                        historyDate = c.DateTime(),
                        productImageHistory = c.String(),
                        productMainDescriptionHistory = c.String(),
                        productNameHistory = c.String(),
                        productShortDescriptionHistory = c.String(),
                        quantityAvailableHistory = c.Int(),
                        sellerPriceHistory = c.Single(),
                        subcategoryAdditionalValuesHistory = c.String(),
                        product_productId = c.Long(),
                        t_product_productId = c.Int(),
                    })
                .PrimaryKey(t => t.productHistoryId)
                .ForeignKey("dbo.t_product", t => t.t_product_productId)
                .Index(t => t.t_product_productId);
            
            CreateTable(
                "dbo.t_specialpromotion",
                c => new
                    {
                        specialPromotionId = c.Long(nullable: false, identity: true),
                        dealDescription = c.String(),
                        dealDisabledByAdmin = c.Boolean(),
                        endDate = c.DateTime(),
                        reductionPercentage = c.Single(),
                        startDate = c.DateTime(),
                        product_productId = c.Long(),
                        t_product_productId = c.Int(),
                    })
                .PrimaryKey(t => t.specialPromotionId)
                .ForeignKey("dbo.t_product", t => t.t_product_productId)
                .Index(t => t.t_product_productId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        USER_TYPE = c.String(),
                        youBayUserId = c.Long(nullable: false),
                        birthday = c.DateTime(),
                        countryOfResidence = c.String(),
                        emailActivationToken = c.String(),
                        FirstName = c.String(),
                        isActive = c.Boolean(),
                        isBanned = c.Boolean(),
                        lastName = c.String(),
                        complaintPercentage = c.Single(),
                        gamificationScore = c.Single(),
                        sellerBadges = c.String(),
                        sellerDescription = c.String(),
                        sellerIsSuspiciousFlag = c.Boolean(),
                        sellerLogo = c.String(),
                        totalSales = c.Single(),
                        canAddAdvertisement = c.Boolean(),
                        canExportData = c.Boolean(),
                        canManageCategories = c.Boolean(),
                        canManageManagers = c.Boolean(),
                        canModerateSellersAndBuyers = c.Boolean(),
                        accountBalance = c.Single(),
                        addressCity = c.String(),
                        addressLine1 = c.String(),
                        addressLine2 = c.String(),
                        buyerBadges = c.String(),
                        iSMale = c.Boolean(),
                        totalSpending = c.Single(),
                        customizedAds_customizedAdsId = c.Long(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        t_customizedads_customizedAdsId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.t_customizedads", t => t.t_customizedads_customizedAdsId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.t_customizedads_customizedAdsId);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.t_product", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.t_product", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.t_orderandreview", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.t_historyofviews", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "t_customizedads_customizedAdsId", "dbo.t_customizedads");
            DropForeignKey("dbo.t_auction", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.t_user", "t_product_productId", "dbo.t_product");
            DropForeignKey("dbo.t_product", "t_user_youBayUserId2", "dbo.t_user");
            DropForeignKey("dbo.t_product", "t_subcategory_subcategoryId", "dbo.t_subcategory");
            DropForeignKey("dbo.t_specialpromotion", "t_product_productId", "dbo.t_product");
            DropForeignKey("dbo.t_producthistory", "t_product_productId", "dbo.t_product");
            DropForeignKey("dbo.t_product", "t_user_youBayUserId1", "dbo.t_user");
            DropForeignKey("dbo.t_product", "t_user_youBayUserId", "dbo.t_user");
            DropForeignKey("dbo.t_orderandreview", "t_user_youBayUserId", "dbo.t_user");
            DropForeignKey("dbo.t_orderandreview", "t_product_productId", "dbo.t_product");
            DropForeignKey("dbo.t_historyofviews", "t_user_youBayUserId", "dbo.t_user");
            DropForeignKey("dbo.t_historyofviews", "t_product_productId", "dbo.t_product");
            DropForeignKey("dbo.t_user", "t_customizedads_customizedAdsId", "dbo.t_customizedads");
            DropForeignKey("dbo.t_customizedads", "t_product_productId", "dbo.t_product");
            DropForeignKey("dbo.t_auction", "t_user_youBayUserId", "dbo.t_user");
            DropForeignKey("dbo.t_auction", "t_product_productId", "dbo.t_product");
            DropForeignKey("dbo.t_subcategory", "t_category_categoryId", "dbo.t_category");
            DropForeignKey("dbo.t_assistantitems", "t_subcategory_subcategoryId", "dbo.t_subcategory");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "t_customizedads_customizedAdsId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.t_specialpromotion", new[] { "t_product_productId" });
            DropIndex("dbo.t_producthistory", new[] { "t_product_productId" });
            DropIndex("dbo.t_orderandreview", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.t_orderandreview", new[] { "t_user_youBayUserId" });
            DropIndex("dbo.t_orderandreview", new[] { "t_product_productId" });
            DropIndex("dbo.t_historyofviews", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.t_historyofviews", new[] { "t_user_youBayUserId" });
            DropIndex("dbo.t_historyofviews", new[] { "t_product_productId" });
            DropIndex("dbo.t_customizedads", new[] { "t_product_productId" });
            DropIndex("dbo.t_user", new[] { "t_product_productId" });
            DropIndex("dbo.t_user", new[] { "t_customizedads_customizedAdsId" });
            DropIndex("dbo.t_auction", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.t_auction", new[] { "t_user_youBayUserId" });
            DropIndex("dbo.t_auction", new[] { "t_product_productId" });
            DropIndex("dbo.t_product", new[] { "ApplicationUser_Id1" });
            DropIndex("dbo.t_product", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.t_product", new[] { "t_user_youBayUserId2" });
            DropIndex("dbo.t_product", new[] { "t_subcategory_subcategoryId" });
            DropIndex("dbo.t_product", new[] { "t_user_youBayUserId1" });
            DropIndex("dbo.t_product", new[] { "t_user_youBayUserId" });
            DropIndex("dbo.t_subcategory", new[] { "t_category_categoryId" });
            DropIndex("dbo.t_assistantitems", new[] { "t_subcategory_subcategoryId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.t_specialpromotion");
            DropTable("dbo.t_producthistory");
            DropTable("dbo.t_orderandreview");
            DropTable("dbo.t_historyofviews");
            DropTable("dbo.t_customizedads");
            DropTable("dbo.t_user");
            DropTable("dbo.t_auction");
            DropTable("dbo.t_product");
            DropTable("dbo.t_category");
            DropTable("dbo.t_subcategory");
            DropTable("dbo.t_assistantitems");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
    }
}
