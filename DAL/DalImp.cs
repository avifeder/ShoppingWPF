﻿using BE;
using IronBarCode;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace DAL
{
    public class DalImp : IDAL
    {
        #region other
        public User currentUser { get; set; }
        public DalImp(User user)
        {
            currentUser = user;
        }
        public void CreatePDF(List<object[]> items)
        {
            //Create a new PDF document.
            PdfDocument doc = new PdfDocument();
            //Add a page.
            PdfPage page = doc.Pages.Add();
            //Create a PdfGrid.
            PdfGrid pdfGrid = new PdfGrid();
            //Loads the image from disk
            string CSPath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName).FullName;
            string ImagePath = Path.Combine(CSPath, @"DAL\Images\LongLogo.jpeg");
            PdfImage image = PdfImage.FromFile(ImagePath);
            RectangleF bounds = new RectangleF(50, 0, 400, 150);
            //Draws the image to the PDF page
            page.Graphics.DrawImage(image, bounds);
            Font font = new Font("Ariel", 14);
            PdfFont pdfFont = new PdfTrueTypeFont(font, true);
            PdfStringFormat format = new PdfStringFormat();
            //Set right-to-left text direction for RTL text
            format.TextDirection = PdfTextDirection.RightToLeft;
            format.Alignment = PdfTextAlignment.Right;

            //Draw grid to the page of PDF document.
            PdfBrush solidBrush = new PdfSolidBrush(new PdfColor(126, 151, 173));
            bounds = new RectangleF(0, bounds.Bottom + 90, page.Graphics.ClientSize.Width, 30);
            //Draws a rectangle to place the heading in that region.
            page.Graphics.DrawRectangle(solidBrush, bounds);
            //Creates a text element to add the invoice number
            PdfTextElement element = new PdfTextElement("", pdfFont);
            element.Brush = PdfBrushes.White;
            //Draws the heading on the page
            PdfLayoutResult result = element.Draw(page, new PointF(10, bounds.Top + 8));
            string currentDate = DateTime.Now.ToString("MM/dd/yyyy");
            //Measures the width of the text to place it in the correct location
            SizeF textSize = pdfFont.MeasureString(currentDate);
            PointF textPosition = new PointF(page.Graphics.ClientSize.Width - textSize.Width + 70, result.Bounds.Y);
            //Draws the date by using DrawString method
            page.Graphics.DrawString(currentDate, pdfFont, element.Brush, textPosition, format);
            //Creates text elements to add the address and draw it to the page.
            element = new PdfTextElement("רשימת הקניות שלך:", pdfFont);
            element.Brush = new PdfSolidBrush(new PdfColor(126, 155, 203));
            element.StringFormat = format;
            result = element.Draw(page, new PointF(page.Graphics.ClientSize.Width - textSize.Width + 70, result.Bounds.Bottom + 25));
            PdfPen linePen = new PdfPen(new PdfColor(126, 151, 173), 0.70f);
            PointF startPoint = new PointF(0, result.Bounds.Bottom + 3);
            PointF endPoint = new PointF(page.Graphics.ClientSize.Width, result.Bounds.Bottom + 3);
            //Draws a line at the bottom of the address
            page.Graphics.DrawLine(linePen, startPoint, endPoint);



            //Create a DataTable.
            DataTable dataTable = new DataTable();
            //Add columns to the DataTable
            dataTable.Columns.Add("הכי זול אצל:");
            dataTable.Columns.Add("כמות");
            dataTable.Columns.Add("תיאור");
            dataTable.Columns.Add("שם");
            //Add rows to the DataTable.
            foreach (var item in items)
            {
                dataTable.Rows.Add(item);
            }

            //Creates the datasource for the table
            DataTable Details = dataTable;
            //Creates a PDF grid
            PdfGrid grid = new PdfGrid();
            grid.Style.Font = pdfFont;

            //Adds the data source
            grid.DataSource = Details;
            //Creates the grid cell styles
            PdfGridCellStyle cellStyle = new PdfGridCellStyle();
            cellStyle.Borders.All = PdfPens.White;
            //PdfGridRow header = grid.Headers[0];
            //Creates the header style
            PdfGridCellStyle headerStyle = new PdfGridCellStyle();
            headerStyle.Borders.All = new PdfPen(new PdfColor(126, 151, 173));
            headerStyle.BackgroundBrush = new PdfSolidBrush(new PdfColor(126, 151, 173));
            headerStyle.TextBrush = PdfBrushes.White;
            headerStyle.Font = pdfFont;
            headerStyle.StringFormat = format;
            //Applies the header style
            grid.Headers[0].ApplyStyle(headerStyle);
            foreach (PdfGridColumn Column in grid.Columns)
            {
                Column.Format = format;
            }
            cellStyle.Borders.Bottom = new PdfPen(new PdfColor(217, 217, 217), 0.70f);
            cellStyle.Font = pdfFont;
            cellStyle.TextBrush = new PdfSolidBrush(new PdfColor(131, 130, 136));
            cellStyle.StringFormat = format;


            //Creates the layout format for grid
            PdfGridLayoutFormat layoutFormat = new PdfGridLayoutFormat();
            // Creates layout format settings to allow the table pagination
            layoutFormat.Layout = PdfLayoutType.Paginate;
            //Draws the grid to the PDF page.
            PdfGridLayoutResult gridResult = grid.Draw(page, new RectangleF(new PointF(0, result.Bounds.Bottom + 40), new SizeF(page.Graphics.ClientSize.Width, page.Graphics.ClientSize.Height - 100)), layoutFormat);

            pdfGrid.Draw(page, new PointF(10, 10));


            //Save the document.
            try
            {
                doc.Save("Output.pdf");
                System.Diagnostics.Process.Start("Output.pdf");
            }
            catch
            {

            }
            //close the document
            doc.Close(true);
        }
        #endregion

        #region google drive

        public List<PurchaseItem> GetLastPurchase()
        {
            List<PurchaseItem> LastPurchase = new List<PurchaseItem>();
            var currentUserId = currentUser.Id;
            
            try
            {
                GetImagesFromDrive(currentUserId);
                UpdateUserList(currentUserId);
            }
            catch
            {

            }

            string CSPath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName).FullName;
            string FolderPath = Path.Combine(CSPath, @"DAL\UsersLists\" + currentUserId + ".txt" );

            string [] UserList = File.ReadAllLines(FolderPath);

            foreach (string Id in UserList)
            {
                PurchaseItem tempPurchaseItem = new PurchaseItem()
                {
                    UserId = currentUserId,
                    ItemId = Id.Split(',')[0],
                    Date =  DateTime.Parse(Id.Split(',')[1])
                };

                LastPurchase.Add(tempPurchaseItem);
            }

            return LastPurchase;
        }
        private string GetDateTaken(string FileName)
        {
            try
            {
                string Name = FileName.Split('\\').Last().Replace(",", "");
                string[] date = Name.Split();
                string PurchaseDate = date[1] + "/" + date[0] + "/" + date[2];
                return DateTime.Parse(PurchaseDate).ToString();
            }
            catch
            {
                return DateTime.Today.ToString();
            }
        }
        private void UpdateUserList(string user)
        {
            string CSPath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName).FullName;
            string FolderPath = Path.Combine(CSPath, @"DAL\GoogleDriveFiles\");

            string[] Files = Directory.GetFiles(FolderPath);
            StreamWriter userList = new StreamWriter(Path.Combine(CSPath, @"DAL\UsersLists\" + user + ".txt"), append: true);
            foreach (string file in Files)
            {
                string ItemId = AnalaysQRCode(file);
                if (ItemId != null && GetAllItems().Select(item => item.Id).ToList().Contains(ItemId))
                {
                    userList.WriteLineAsync(ItemId + "," + GetDateTaken(file));
                }
                File.Delete(file);
            }
            userList.Close();
        }


        private string AnalaysQRCode(string Path)
        {
            BarcodeResult ItemId = BarcodeReader.QuicklyReadOneBarcode(Path, BarcodeEncoding.QRCode);
            if (ItemId != null)
                return ItemId.Text;
            return null;
        }
        private void GetImagesFromDrive(string FolderName)
        {
            GoogleDriveAPITool googleDrive = new GoogleDriveAPITool();
            List<GoogleDriveFile> collection = googleDrive.GetDriveFiles();
            GoogleDriveFile folder = googleDrive.GetDriveFolder(FolderName);
            if (folder != null)
            {
                string folderId = folder.Id;
                List<GoogleDriveFile> images = new List<GoogleDriveFile>();
                foreach (GoogleDriveFile item in collection)
                {
                    if (item.Parents != null && item.Parents.Contains(folderId))
                        images.Add(item);
                }
                foreach (GoogleDriveFile item in images)
                {
                    string fileId = item.Id;
                    string FilePath = googleDrive.DownloadGoogleFile(fileId);
                    googleDrive.DeleteGoogleFile(fileId);
                }
            }
        }

        #endregion

        #region update db
        //public void updatePurchases(Purchase newPurchase, Purchase oldPurchase)
        //{
        //    using (var ctx = new ShopsDB())
        //    {
        //        ctx.Purchases.Remove(oldPurchase);
        //        ctx.Purchases.Add(newPurchase);
        //        ctx.SaveChanges();
        //    }
        //}

        #endregion

        #region add to db
        public void AddUser(User user)
        {            
            using (var ctx = new ShopsDB())
            {
                ctx.Users.Add(user);
                ctx.SaveChanges();
            }
            string CSPath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName).FullName;
            string FolderPath = Path.Combine(CSPath, @"DAL\UsersLists\" + user.Id + ".txt");
            if (!File.Exists(FolderPath))
                File.Create(FolderPath);
        }

        public void AddPurchase(PurchaseItem purchaseItem)
        {
            using (var ctx = new ShopsDB())
            {
                ctx.PurchaseItems.Add(purchaseItem);
                ctx.SaveChanges();
                DeletePurchaseFromUserFile(purchaseItem);
            }
        }
        public void DeletePurchaseFromUserFile(PurchaseItem purchaseItem)
        {
            string CSPath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName).FullName;
            string FolderPath = Path.Combine(CSPath, @"DAL\UsersLists\" + purchaseItem.UserId + ".txt");          
            string[] UserList = File.ReadAllLines(FolderPath);

            foreach (string purchase in UserList)
            {
                string ItemId = purchase.Split(',')[0];

                if (ItemId == purchaseItem.ItemId && purchase.Split(',')[1] == purchaseItem.Date.ToString())
                {
                    var tempFile = Path.GetTempFileName();
                    var linesToKeep = File.ReadLines(FolderPath).Where(l => l != purchase);
                    File.WriteAllLines(tempFile, linesToKeep);
                    File.Delete(FolderPath);
                    File.Move(tempFile, FolderPath);
                    break;
                }

            }
        }
        public void AddItem(Item item)
        {
            using (var ctx = new ShopsDB())
            {
                ctx.Items.Add(item);
                ctx.SaveChanges();
            }
        }
        #endregion

        #region get from db
        public List<Item> GetAllItems(Func<Item, bool> predicate = null)
        {
            List<Item> result = new List<Item>();
            using (var context = new ShopsDB())
            {
                if (predicate == null)
                {
                    result = context.Items.ToList();
                }
                else
                {
                    result = context.Items.Where(predicate).ToList();
                }
            }
            return result;
        }

        public List<PurchaseItem> GetAllPurchases(Func<PurchaseItem, bool> predicate = null)
        {
            List<PurchaseItem> result = new List<PurchaseItem>();
            using (var context = new ShopsDB())
            {
                if (predicate == null)
                {
                    result = context.PurchaseItems.Where(purchase => purchase.UserId == currentUser.Id).ToList();
                }
                else
                {
                    result = context.PurchaseItems.Where(purchase => purchase.UserId == currentUser.Id).Where(predicate).ToList();
                }
            }
            return result;
        }
        public List<PurchaseItem> GetAllPurchasesOfAllUsers()
        {
            List<PurchaseItem> result = new List<PurchaseItem>();
            using (var context = new ShopsDB())
            {
                
                result = context.PurchaseItems.ToList();
                
            }
            return result;
        }
        
        public List<User> GetAllUsers(Func<User, bool> predicate = null)
        {
            List<User> result = new List<User>();
            using (var context = new ShopsDB())
            {
                if (predicate == null)
                {
                    result = context.Users.ToList();
                }
                else
                {
                    result = context.Users.Where(predicate).ToList();
                }
            }
            return result;
        }
#endregion

       
    }
}
