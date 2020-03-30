using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SharePoint.Client;
using System.Security;
using System.Net;
using System.Security.AccessControl;
using OfficeOpenXml;
using System.Xml;

namespace SharePointMigration
{
    public partial class Migrate : System.Windows.Forms.Form
    {
        private static Migrate form = null;
        public static string allowedfilesString = "doc, docx, docm, xls, xlsx, xlsm, ppt, pptx, pub, txt, pdf, jpg, gif, png, dotx, rtf";
        public static string[] allowedfiles;
        public static string tab = "\t";
        public static string siteUrl;
        public static Boolean doTest = false;
        public static string testSite = "Whanganui";
        public static string testFolder = @"x:\TOH Activities\Driver Licence";
        public static string testLibrary = "Documents";
        public static Boolean doFiles = true;
        public static Boolean doMigrate = false;
        public static Boolean doExcel = true;
        public static System.Data.DataTable filetable = new System.Data.DataTable("files");
        public static System.Data.DataTable siteuserstable = new System.Data.DataTable("siteusers");
        public static string ExcelFile = "C:\\temp\\SharePointMigration.xlsx";
        public static int folderstartpos = 1;

        public Migrate()
        {
            InitializeComponent();
            form = this;
            label_status.MaximumSize = new Size(form.Size.Width - 50, 0);
            text_extensions.Text = allowedfilesString;
            if (doTest)
            {
                MessageBox.Show("Running in Test Mode");
            }
            form.Text += " " + Application.ProductVersion;
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            if (doTest)
            {
                combo_site.Text = testSite;
                text_username.Text = "gtichbon@teorahou.org.nz";
                text_password.Text = "Linus007b";
            }
            if (combo_site.Text == "" || text_username.Text == "" || text_password.Text == "")
            {
                MessageBox.Show("Please fill in all the parameters.");
                return;
            }

            siteUrl = "https://teorahou.sharepoint.com/sites/" + combo_site.Text;

            using (ClientContext ctx = new ClientContext(siteUrl))
            {
                label_status.Text = "Logging in";
                System.Windows.Forms.Application.DoEvents();

                ctx.Credentials = Credentials(); //   new SharePointOnlineCredentials("gtichbon@teorahou.org.nz", passWord);

                label_status.Text = "Getting document libraries";
                System.Windows.Forms.Application.DoEvents();
               
                var Lists = ctx.LoadQuery(ctx.Web.Lists);
                ctx.ExecuteQuery();
                foreach (var list in Lists)
                {
                    if (list.BaseType.ToString() == "DocumentLibrary")
                    {
                        form.combo_library.Items.Add(list.Title);
                    }
                }
               
                label_status.Text = "Getting site users";

                //System.Data.DataTable siteuserstable = new System.Data.DataTable("siteusers");

                siteuserstable.Columns.Add("ID", typeof(int));
                siteuserstable.Columns.Add("Title", typeof(string));

                System.Windows.Forms.Application.DoEvents();

                var siteUsers = ctx.LoadQuery(ctx.Web.SiteUsers);
                ctx.ExecuteQuery();
                foreach (var user in siteUsers)
                {
                    siteuserstable.Rows.Add(user.Id, user.Title);
                }
            }
            panel_locations.Show();

            label_status.Text = "Waiting for location details";
        }

        private static SharePointOnlineCredentials Credentials()
        {
            SecureString passWord = new SecureString();
            //foreach (char c in "Wanganui15".ToCharArray()) passWord.AppendChar(c);
            //return new NetworkCredential("MobileApp", passWord, "wdc-nt");

            //foreach (char c in "Linus007b".ToCharArray()) passWord.AppendChar(c);
            //return new NetworkCredential("OnlineService", passWord, "wdc-nt");

            foreach (char c in form.text_password.Text.ToCharArray()) passWord.AppendChar(c);
            return new SharePointOnlineCredentials(form.text_username.Text, passWord);

        }

        private void btn_Go_Click(object sender, EventArgs e)
        {
            if (doTest)
            {
                combo_library.Text = testLibrary;
                text_folder.Text = testFolder;
            }

            if (combo_library.Text == "" || text_folder.Text == "" || form.text_extensions.Text == "")
            {
                MessageBox.Show("Please fill in all the parameters.");
                return;
            }
            if(!text_folder.Text.StartsWith(text_removefolderfield.Text))
            {
                MessageBox.Show("Invalid: Remove from 'Folder Origin' field");
                return;
            }
            folderstartpos = text_removefolderfield.Text.Length;

            allowedfiles = form.text_extensions.Text.Replace(" ","").Split(',');

            DataColumn column = new DataColumn("CTR");
            column.DataType = System.Type.GetType("System.Int32");
            column.AutoIncrement = true;
            column.AutoIncrementSeed = 1;
            column.AutoIncrementStep = 1;
            column.ReadOnly = true;
            filetable.Columns.Add(column);


            filetable.Columns.Add("Name", typeof(string));
            filetable.Columns.Add("Version", typeof(int));
            filetable.Columns.Add("Extension", typeof(string));
            filetable.Columns.Add("Folders", typeof(string));
            filetable.Columns.Add("Author", typeof(string));
            filetable.Columns.Add("Created", typeof(DateTime));
            filetable.Columns.Add("Modified", typeof(DateTime));
            filetable.Columns.Add("Security", typeof(string));
            filetable.Columns.Add("Size", typeof(Int32));
            filetable.Columns.Add("Status", typeof(string));

            //filetable.Rows.Add("Name", "Extension", "Folders", "Author", DateTime.UtcNow, DateTime.UtcNow, "Security", 0, "Test");
            //int x = filetable.Rows.Count;


            //Name, Extension, Folders, Author, Created, Modified, Security, Size, Status

            
            

            string libName = combo_library.Text.Replace(" ", "_x0020_");
            string startpath = text_folder.Text;
            string filePath = "c:\\temp\\sharepointtest.txt";
            string fileName = filePath.Substring(filePath.LastIndexOf("\\") + 1);

            if (doFiles)
            {
                label_status.Text = "Starting file analysis";

                TraverseTree(startpath);
            }

            DataView dv = new DataView(filetable);
            System.Data.DataTable dvfiles = dv.ToTable();
            foreach (DataRow filerow in dvfiles.Rows)
            {
                //Console.WriteLine(filerow["Name"].ToString() + " " + filerow["Version"].ToString());
                /*
                string sel = "[Name] = '" + siterow["Name"] + "'";
                DataView dv3 = new DataView(filetable, sel, "", DataViewRowState.CurrentRows);
                System.Data.DataTable dvindexess = dv3.ToTable(true, "Index");
                foreach (DataRow indexrow in dvindexess.Rows)
                {
                    string z = siterow["Name"].ToString();

                    z = indexrow["Index"].ToString();

                    sel = "[Name] = '" + siterow["Name"] + "' AND [Index] = '" + indexrow["Index"] + "'";
                    DataView dv4 = new DataView(filetable, sel, "", DataViewRowState.CurrentRows);
                    System.Data.DataTable dvfields = dv4.ToTable();
                    foreach (DataRow fieldrow in dvfields.Rows)
                    {
                        string y = fieldrow["Field"].ToString();
                    }
                }
                */
            }
            //Large Files
            string sel = "[Status] = 'Success' and [Size] > 2000000";
            DataView dvfolders = new DataView(filetable, sel, "", DataViewRowState.CurrentRows);
            System.Data.DataTable dtfolders = dvfolders.ToTable();
            foreach (DataRow myrow in dtfolders.Rows)
            {
                string x = myrow["Name"].ToString();
            }

            /*
            System.Data.DataTable dtduplicates = filetable.AsEnumerable()
               .GroupBy(r => new { Col1 = r["Name"] })
               .Count()
               .CopyToDataTable();
               */
            /*
                        var query = from row in filetable.AsEnumerable()
                                    group row by row.Field<string>("Name") into names
                                    select new
                                    {
                                        Name = names.Key,
                                        CountOfFiles = names.Count()
                                    };

                        foreach (var myrow in query)
                        {
                            if(myrow.CountOfFiles > 1) { 
                                Console.WriteLine("{0}\t{1}", myrow.Name, myrow.CountOfFiles);
                            }
                        }
            */

            form.label_status.Text = "Complete";

            if (doExcel)
            {
                form.label_status.Text += " - Report at: " + ExcelFile;
            }
        }

        public static void TraverseTree(string root)
        {
            // Data structure to hold names of subfolders to be
            // examined for files.
            Stack<string> dirs = new Stack<string>(20);

            if (!System.IO.Directory.Exists(root))
            {
                throw new ArgumentException();
            }
            dirs.Push(root);

            while (dirs.Count > 0)
            {
                string currentDir = dirs.Pop();
                form.label_status.Text = "Processing folder: " + currentDir;
                System.Windows.Forms.Application.DoEvents();

                string[] subDirs;
                try
                {
                    subDirs = System.IO.Directory.GetDirectories(currentDir);
                }
                // An UnauthorizedAccessException exception will be thrown if we do not have
                // discovery permission on a folder or file. It may or may not be acceptable 
                // to ignore the exception and continue enumerating the remaining files and 
                // folders. It is also possible (but unlikely) that a DirectoryNotFound exception 
                // will be raised. This will happen if currentDir has been deleted by
                // another application or thread after our call to Directory.Exists. The 
                // choice of which exceptions to catch depends entirely on the specific task 
                // you are intending to perform and also on how much you know with certainty 
                // about the systems on which this code will run.
                catch (UnauthorizedAccessException e)
                {
                    MessageBox.Show(e.Message);
                    continue;
                }
                catch (System.IO.DirectoryNotFoundException e)
                {
                    MessageBox.Show(e.Message);
                    continue;
                }

                string[] files = null;
                try
                {
                    string security = "";
                    DirectorySecurity dSecurity = System.IO.Directory.GetAccessControl(currentDir);
                    string author = dSecurity.GetOwner(typeof(System.Security.Principal.NTAccount)).ToString();
                    AuthorizationRuleCollection acl = dSecurity.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount));
                    foreach (FileSystemAccessRule ace in acl)
                    {
                        if (ace.IdentityReference.Value != "NT AUTHORITY\\SYSTEM")
                        {
                            security += "Account:" + ace.IdentityReference.Value + " | " + "Type:" + ace.AccessControlType + " | " + "Rights:" + ace.FileSystemRights + " | " + "Inherited:" + ace.IsInherited + "\n";
                        }
                    }
                    //Name, Extension, Folders, Author, Created, Modified, Security, Size, Status
                    filetable.Rows.Add(null, currentDir.Substring(folderstartpos), null, null, null, null, null, null, security, null, "folder");
                    files = System.IO.Directory.GetFiles(currentDir);
                }

                catch (UnauthorizedAccessException e)
                {
                    MessageBox.Show(e.Message);
                    continue;
                }

                catch (System.IO.DirectoryNotFoundException e)
                {
                    MessageBox.Show(e.Message);
                    continue;
                }
                // Perform the required action on each file here.
                // Modify this block to perform your required task.
                foreach (string file in files)
                {
                    string status = "Success";
                    string security = "";
                    try
                    {
                        // Perform whatever action is required in your scenario.
                        if (file != @"x:\TOH Activities\Youth Work\Youthwork Team\TOH.accde")
                        {

                            System.IO.FileInfo fi = new System.IO.FileInfo(file);
                            string extn = fi.Extension.ToLower();
                            if (fi.Name.StartsWith("~"))
                            {
                                status = "Starts with ~";
                            }
                            else if (!allowedfiles.Any(extn.Contains))
                            {
                                status = "Excluded Extension";
                            }

                            //string author = System.IO.File.GetAccessControl(file).GetOwner(typeof(System.Security.Principal.NTAccount)).ToString();
                            FileSecurity fSecurity = System.IO.File.GetAccessControl(file);
                            string author = fSecurity.GetOwner(typeof(System.Security.Principal.NTAccount)).ToString();
                            AuthorizationRuleCollection acl = fSecurity.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount));
                            foreach (FileSystemAccessRule ace in acl)
                            {
                                if (ace.IdentityReference.Value != "NT AUTHORITY\\SYSTEM")
                                {
                                    security += "Account:" + ace.IdentityReference.Value + " | " + "Type:" + ace.AccessControlType + " | " + "Rights:" + ace.FileSystemRights + " | " + "Inherited:" + ace.IsInherited + "\n";
                                }
                            }
                            //CTR, FileName, Version, Extension, Folders, Author, Created, Modified, Security, Size, Status
                            int version = 0;

                            DataRow dr = (from r in filetable.AsEnumerable()
                                          where (string)r["Name"] == fi.Name
                                          orderby r["version"] descending
                                          select r).FirstOrDefault();
                            if (dr != null)
                            {
                                if ((int)dr["version"] == 0)
                                {
                                    dr["version"] = 1;

                                }
                                version = (int)dr["version"] + 1;
                            }

                            filetable.Rows.Add(null, fi.Name, version, extn, fi.DirectoryName.Substring(folderstartpos), author, fi.CreationTimeUtc, fi.LastWriteTimeUtc, security, fi.Length, status);
                        }
                    }
                    catch (System.IO.FileNotFoundException e)
                    {
                        // If file was deleted by a separate application
                        //  or thread since the call to TraverseTree()
                        // then just continue.
                        MessageBox.Show(e.Message);
                        continue;
                    }
                }

                // Push the subdirectories onto the stack for traversal.
                // This could also be done before handing the files.
                foreach (string str in subDirs)
                    dirs.Push(str);
            }


            if (doExcel)
            {
                form.label_status.Text = "Creating Excel Analasis document (" + ExcelFile + ")";
                System.Windows.Forms.Application.DoEvents();

                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                using (var p = new ExcelPackage())
                {
                    {
                        //ALL
                        var wsAll = p.Workbook.Worksheets.Add("All");
                        wsAll.Cells["A1"].LoadFromDataTable(filetable, true);

                        //LARGE
                        DataView dvlarge = new DataView(filetable, "[size] > 2000000", "", DataViewRowState.CurrentRows);
                        System.Data.DataTable dtlarge = dvlarge.ToTable();
                        var wsLarge = p.Workbook.Worksheets.Add("> 2Mb");
                        wsLarge.Cells["A1"].LoadFromDataTable(dtlarge, true);

                        //TILDE
                        DataView dvTilde = new DataView(filetable, "[Status] = 'Starts with ~'", "", DataViewRowState.CurrentRows);
                        System.Data.DataTable dtTilde = dvTilde.ToTable();
                        var wsTilde = p.Workbook.Worksheets.Add("Starts with ~");
                        wsTilde.Cells["A1"].LoadFromDataTable(dtTilde, true);

                        //EXCLUDED EXTENSIONS
                        DataView dvExtension = new DataView(filetable, "[Status] = 'Excluded Extension'", "", DataViewRowState.CurrentRows);
                        System.Data.DataTable dtExtension = dvExtension.ToTable();
                        var wsExtension = p.Workbook.Worksheets.Add("Excluded Extension");
                        wsExtension.Cells["A1"].LoadFromDataTable(dtExtension, true);

                        //DataView dvAuthor = new DataView(filetable, "", "", DataViewRowState.CurrentRows);
                        //System.Data.DataTable dtAuthor = dvAuthor.ToTable(true,"Author");
                        //var wsAuthor = p.Workbook.Worksheets.Add("Author");
                        //wsAuthor.Cells["A1"].LoadFromDataTable(dtAuthor, true);

                        //AUTHORS
                        var results = from row in filetable.AsEnumerable()
                                      group row by row.Field<string>("Author") into g
                                      select new
                                      {
                                          AuthorName = g.Key,
                                          Count = g.Count()
                                      };

                        DataTable queryResults = new DataTable();
                        queryResults.Columns.Add("AuthorName", typeof(string));
                        queryResults.Columns.Add("Count", typeof(int));

                        foreach (var result in results)
                            queryResults.Rows.Add(new object[] { result.AuthorName, result.Count });

                        var wsAuthor = p.Workbook.Worksheets.Add("Author");
                        wsAuthor.Cells["A1"].LoadFromDataTable(queryResults,true);

                        //SITE USERS
                        var wsSiteusers = p.Workbook.Worksheets.Add("Site Users");
                        wsSiteusers.Cells["A1"].LoadFromDataTable(siteuserstable, true);

                        //DUPLICATES
                        DataView dvDuplicate = new DataView(filetable, "[Version] <> 0 and [Status] = 'Success'", "", DataViewRowState.CurrentRows);
                        dvDuplicate.Sort = "Name ASC, Version ASC";
                        System.Data.DataTable dtDuplicate = dvDuplicate.ToTable();
                        var wsDuplicate = p.Workbook.Worksheets.Add("Duplicates");
                        wsDuplicate.Cells["A1"].LoadFromDataTable(dtDuplicate, true);

                        //SUMMARY
                        var Summaryresults = from row in filetable.AsEnumerable()
                                             group row by new { Extension = row.Field<string>("Extension"), Status = row.Field<string>("Status") } into g
                                             select new
                                             {
                                                 extension = g.Key.Extension,
                                                 status = g.Key.Status,
                                                 count = g.Count()
                                             };

                        DataTable dtSummary = new DataTable();
                        dtSummary.Columns.Add("Status", typeof(string));
                        dtSummary.Columns.Add("Extension", typeof(string));
                        dtSummary.Columns.Add("Count", typeof(int));

                        foreach (var result in Summaryresults)
                            dtSummary.Rows.Add(new object[] { result.status, result.extension, result.count });

                        DataView dvSummary = dtSummary.DefaultView;
                        dvSummary.Sort = "Status ASC, Extension ASC";
                        DataTable dtSummarySorted = dvSummary.ToTable();

                        var wsSummary = p.Workbook.Worksheets.Add("Summary");
                        wsSummary.Cells["A1"].LoadFromDataTable(dtSummarySorted, true);


                        p.SaveAs(new FileInfo(ExcelFile));

                    }
                }
                //Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                //Workbook ExcelWorkBook = ExcelApp.Application.Workbooks.Add();

                /*
                createworksheet(ExcelWorkBook, 1, "Successful", this.list_success);
                createworksheet(ExcelWorkBook, 2, "Errors", this.list_error);
                createworksheet(ExcelWorkBook, 3, "Excluded", this.list_exclude);
                createworksheet(ExcelWorkBook, 4, "With &", this.list_ampersand);
                createworksheet(ExcelWorkBook, 5, "Duplicates", this.list_duplicates);
                createworksheet(ExcelWorkBook, 6, "Summary", this.list_summary);
                createworksheet(ExcelWorkBook, 7, "> 2mb", this.list_large);   //https://www.youtube.com/watch?v=g39RLflzonI&list=PLaIJswamN5lSSYPatSGSG5IC_gZXpBNdv&index=10
                createworksheet(ExcelWorkBook, 8, "Users", this.list_users);
                createworksheet(ExcelWorkBook, 9, "Authors", this.list_authors);
                */
                //ExcelWorkBook.SaveAs(@"C:\temp\SharePointMigration.xlsx");
                //ExcelWorkBook.Close();
                //ExcelApp.Quit();
                //Marshal.ReleaseComObject(ExcelWorkSheet);
                //Marshal.ReleaseComObject(ExcelWorkBook);
                //Marshal.ReleaseComObject(ExcelApp);
            }
        }

        private void btn_selectfolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                text_folder.Text = fbd.SelectedPath;
            }
        }

        public static Folder CreateFolder(Web web, string listTitle, string fullFolderUrl)
        {
            /* Usage
            using (var ctx = new ClientContext("https://contoso.onmicrosoft.com/"))
            {
                   ctx.Credentials = new Microsoft.SharePoint.Client.SharePointOnlineCredentials("username", "password");
                   var folder = CreateFolder(ctx.Web, "Shared Documents", "FolderA/SubFolderA/SubSubFolderA");
             }
             */
             if (string.IsNullOrEmpty(fullFolderUrl))
                throw new ArgumentNullException("fullFolderUrl");
            var list = web.Lists.GetByTitle(listTitle);
            return CreateFolderInternal(web, list.RootFolder, fullFolderUrl);
        }

        private static Folder CreateFolderInternal(Web web, Folder parentFolder, string fullFolderUrl)
        {
            var folderUrls = fullFolderUrl.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            string folderUrl = folderUrls[0];
            var curFolder = parentFolder.Folders.Add(folderUrl);
            web.Context.Load(curFolder);
            web.Context.ExecuteQuery();

            if (folderUrls.Length > 1)
            {
                var subFolderUrl = string.Join("/", folderUrls, 1, folderUrls.Length - 1);
                return CreateFolderInternal(web, curFolder, subFolderUrl);
            }
            return curFolder;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void check_createfolders_CheckedChanged(object sender, EventArgs e)
        {
            if(check_createfolders.Checked) {
                MessageBox.Show("Please only do this if you are 100% sure it is the best course of action");
                MessageBox.Show("Serious!!");
            }
        }
    }
}
