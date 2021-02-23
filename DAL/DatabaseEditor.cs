using BE;
using Google.Apis.Drive.v3;
using System;
using System.Collections.Generic;

namespace DAL
{
    class DatabaseEditor
    {
        /*
        public static float GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return (float)(int)((random.NextDouble() * (maximum - minimum) + minimum) * 10) / 10;
        }

        public static void Main(string[] args)
        {


            //GoogleDriveAPITool googleDrive = new GoogleDriveAPITool();
            //List<GoogleDriveFile> collection = googleDrive.GetDriveFiles();
            //GoogleDriveFile folder = googleDrive.GetDriveFolder("208199638");
            //string folderId = folder.Id;
            //List<GoogleDriveFile> images = new List<GoogleDriveFile>();
            //foreach (GoogleDriveFile item in collection)
            //{
            //    if (item.Parents != null && item.Parents.Contains(folderId))
            //        images.Add(item);
            //}
            //foreach (GoogleDriveFile item in images)
            //{
            //    string fileId = item.Id;
            //    string FilePath = googleDrive.DownloadGoogleFile(fileId);
            //    googleDrive.DeleteGoogleFile(fileId);
            //}


            IDAL dal = new DalImp(null);

            int counter = 0;

            List<string[]> list = new List<string[]>();
            list.Add(new string[] { "רמי לוי", "נתניה פולג" });
            list.Add(new string[] { "רמי לוי", "מבשרת ציון" });
            list.Add(new string[] { "רמי לוי", "גבעת שאול" });

            list.Add(new string[] { "אושר עד", "סגולה" });
            list.Add(new string[] { "אושר עד", "לוד" });
            list.Add(new string[] { "אושר עד", "חדרה" });

            list.Add(new string[] { "יינות ביתן", "כפר סבא" });
            list.Add(new string[] { "יינות ביתן", "מעלה אדומים" });
            list.Add(new string[] { "יינות ביתן", "מעלות" });

            list.Add(new string[] { "שופרסל", "מכבים רעות" });
            list.Add(new string[] { "שופרסל", "כפר גנים" });
            list.Add(new string[] { "שופרסל", "שוהם" });

            foreach (var item in list)
            {
                dal.AddItem(
            new Item()
            {
                Id = (++counter).ToString(),
                Name = "לחם",
                Description = "לחם אנגל טרי פרוס",
                Price = GetRandomNumber(4, 6),
                ShopName = item[0],
                BranchName = item[1],
                ImagePath = "/WpfApp;component/ItemImages/לחם.jpg"
            });

                dal.AddItem(
                new Item()
                {
                    Id = (++counter).ToString(),
                    Name = "חלב",
                    Description = "חלב תנובה 5% שומן",
                    Price = GetRandomNumber(4, 6),
                    ShopName = item[0],
                    BranchName = item[1],
                    ImagePath = "/WpfApp;component/ItemImages/חלב.jpg"

                });
                dal.AddItem(
                new Item()
                {
                    Id = (++counter).ToString(),
                    Name = "מילקי",
                    Description = "מעדן שוקולד קצפת",
                    Price = GetRandomNumber(3, 6),
                    ShopName = item[0],
                    BranchName = item[1],
                    ImagePath = "/WpfApp;component/ItemImages/מילקי.jpg"

                });
                dal.AddItem(
              new Item()
              {
                  Id = (++counter).ToString(),
                  Name = "ביצים",
                  Description = "קרטון 20 ביצים מידה L",
                  Price = GetRandomNumber(10, 14),
                  ShopName = item[0],
                  BranchName = item[1],
                  ImagePath = "/WpfApp;component/ItemImages/ביצים.jpg"

              });
                dal.AddItem(
              new Item()
              {
                  Id = (++counter).ToString(),
                  Name = "כריות נוגט",
                  Description = "כריות תלמה בטעם נוגט",
                  Price = GetRandomNumber(25, 35),
                  ShopName = item[0],
                  BranchName = item[1],
                  ImagePath = "/WpfApp;component/ItemImages/כריות בטעם נוגט.jpg"

              });
                dal.AddItem(
            new Item()
            {
                Id = (++counter).ToString(),
                Name = "קפה עלית",
                Description = "פולי קפה מיובשים טחונים",
                Price = GetRandomNumber(22, 26),
                ShopName = item[0],
                BranchName = item[1],
                ImagePath = "/WpfApp;component/ItemImages/קפה עלית.jpg"

            });
                dal.AddItem(
            new Item()
            {
                Id = (++counter).ToString(),
                Name = "פסטרמה כתף בקר",
                Description = "חתיכות כתף בטעם מפולפל",
                Price = GetRandomNumber(24, 26),
                ShopName = item[0],
                BranchName = item[1],
                ImagePath = "/WpfApp;component/ItemImages/פסטרמה כתף בקר.jpg"

            });

                dal.AddItem(
               new Item()
               {
                   Id = (++counter).ToString(),
                   Name = "פיתות",
                   Description = "מארז 10 יחידות פיתה טרי",
                   Price = GetRandomNumber(9, 10),
                   ShopName = item[0],
                   BranchName = item[1],
                   ImagePath = "/WpfApp;component/ItemImages/פיתות.jpg"
               });

                dal.AddItem(
               new Item()
               {
                   Id = (++counter).ToString(),
                   Name = "חלב שקדים",
                   Description = "חלב תנובה דל שומן",
                   Price = GetRandomNumber(5, 6),
                   ShopName = item[0],
                   BranchName = item[1],
                   ImagePath = "/WpfApp;component/ItemImages/חלב שקדים.jpg"

               });


                dal.AddItem(
              new Item()
              {
                  Id = (++counter).ToString(),
                  Name = "black כריות",
                  Description = "כריות תלמה black",
                  Price = GetRandomNumber(28, 32),
                  ShopName = item[0],
                  BranchName = item[1],
                  ImagePath = "/WpfApp;component/ItemImages/כריות BLACK.png"

              });


                dal.AddItem(
             new Item()
             {
                 Id = (++counter).ToString(),
                 Name = "קוראסון שוקולד",
                 Description = "קוראסון שוקולד חלב עם פצפוצים",
                 Price = GetRandomNumber(4, 6),
                 ShopName = item[0],
                 BranchName = item[1],
                 ImagePath = "/WpfApp;component/ItemImages/קרואסון שוקולד.jpg"
             });

                dal.AddItem(
               new Item()
               {
                   Id = (++counter).ToString(),
                   Name = "חלב דל לקטוז",
                   Description = "חלב תנובה ללא לקטוז",
                   Price = GetRandomNumber(7, 8),
                   ShopName = item[0],
                   BranchName = item[1],
                   ImagePath = "/WpfApp;component/ItemImages/חלב דל לקטוז.jpg"

               });

                dal.AddItem(
              new Item()
              {
                  Id = (++counter).ToString(),
                  Name = "ביצי חופש",
                  Description = "קרטון 20 ביצים מידה M",
                  Price = GetRandomNumber(17, 18),
                  ShopName = item[0],
                  BranchName = item[1],
                  ImagePath = "/WpfApp;component/ItemImages/ביצי חופש.jpg"

              });


                dal.AddItem(
            new Item()
            {
                Id = (++counter).ToString(),
                Name = "פסטרמה בדבש",
                Description = "חתיכות חזה עוף בטעם דבש",
                Price = GetRandomNumber(19, 21),
                ShopName = item[0],
                BranchName = item[1],
                ImagePath = "/WpfApp;component/ItemImages/פסטרמה בדבש.jpg"

            });


                dal.AddItem(
            new Item()
            {
                Id = (++counter).ToString(),
                Name = "במבה אוסם",
                Description = "במבה אוסם שקית גדולה 75 גרם",
                Price = GetRandomNumber(30, 32),
                ShopName = item[0],
                BranchName = item[1],
                ImagePath = "/WpfApp;component/ItemImages/במבה אוסם.png"

            });
                dal.AddItem(
            new Item()
            {
                Id = (++counter).ToString(),
                Name = "ביסלי אוסם",
                Description = "ביסלי אוסם שקית גדולה 75 גרם",
                Price = GetRandomNumber(30, 31),
                ShopName = item[0],
                BranchName = item[1],
                ImagePath = "/WpfApp;component/ItemImages/ביסלי אוסם.jpg"

            });

                }

                //    //dal.AddUser(new User("s", "s", "s", "s", "s"));
                //    var s = dal.GetAllItems();
                //    var d = dal.GetAllUsers(x => x.Id == "2");

                //Console.ReadKey();

            }\
                */
    }

}
