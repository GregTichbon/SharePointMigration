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
using System.Runtime.InteropServices;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Excel;


namespace SharePointMigration
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        private static Form1 form = null;
        public static string[] allowedfiles = { "doc", "docx", "docm", "xls", "xlsx", "xlsm", "ppt", "pptx", "pub", "txt", "pdf" };
        public static Dictionary<string,int> counts = new Dictionary<string,int>();
        public static Dictionary<string, int> authors = new Dictionary<string, int>();
        public static Dictionary<string, string> successfulfiles = new Dictionary<string, string>();
        public static string tab = "\t";
        public static string siteUrl;
        public static Boolean doTest = true;
        public static string testSite = "Whanganui";
        public static string testFolder = @"x:\TOH Activities";
        public static string testLibrary = "Documents";
        public static Boolean doFiles = true;
        public static Boolean doMigrate = false;
        public static Boolean doExcel = false;
        public static System.Data.DataTable filetable;

        public Form1()
        {
            
            InitializeComponent();
            form = this;
            label_status.MaximumSize = new Size(form.Size.Width - 50, 0);

        }

        private void btn_Go_Click(object sender, EventArgs e)
        {
            System.Data.DataTable filetable = new System.Data.DataTable("files");

            filetable.Columns.Add("FileName", typeof(string));
            filetable.Columns.Add("Folders", typeof(string));
            filetable.Columns.Add("Author", typeof(string));
            filetable.Columns.Add("Created", typeof(DateTime));
            filetable.Columns.Add("Modified", typeof(DateTime));

            if (doTest)
            {
                combo_library.Text = testLibrary;
                text_folder.Text = testFolder;
            }
            if (combo_library.Text == "" || text_folder.Text == "")
            {
                MessageBox.Show("Please fill in all the parameters.");
                return;
            }

            panel_results.Show();

            string libName = combo_library.Text.Replace(" ", "_x0020_");
            string startpath = text_folder.Text;
            string filePath = "c:\\temp\\sharepointtest.txt";
            string fileName = filePath.Substring(filePath.LastIndexOf("\\") + 1);

            if (doFiles) {
                label_status.Text = "Starting file analysis";

                TraverseTree(startpath);
            }
            /*
            var duplicateNames = from filePaths in Directory.GetFiles(startpath, "*", SearchOption.AllDirectories)
                                 group filePaths by Path.GetFileName(filePaths) into files
                                 where files.Count() > 1
                                 select files;

            int x = duplicateNames.Count();

            foreach (var f in duplicateNames)
            {
                Console.WriteLine(f.Key);
            }
            */

            //testing on best way to suss duplicates




            /*

            DataView dv2 = new DataView(filetable);
            System.Data.DataTable dvSites = dv2.ToTable(true, "Name");
            foreach (DataRow siterow in dvSites.Rows)
            {
                string x = siterow["Name"].ToString();

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
            }
            */



            foreach (KeyValuePair<string, string> duplicates in successfulfiles)
            {
                string vfilepath;
                if (duplicates.Value.Contains(tab))
                {
                    int v = 1;
                    foreach (string filename in duplicates.Value.Split('\t')) {
                        vfilepath = filename +" v" + v.ToString();
                        uploadtoSharePoint(vfilepath);
                    }
                } else
                {
                    vfilepath = duplicates.Value;
                }
            }



            if (doMigrate)
            {
                using (ClientContext ctx = new ClientContext(siteUrl))
                {
                    ctx.Credentials = Credentials(); //   new SharePointOnlineCredentials("gtichbon@teorahou.org.nz", passWord);

                    FileCreationInformation fcInfo = new FileCreationInformation();
                    fcInfo.Url = fileName;
                    fcInfo.Overwrite = false;
                    fcInfo.Content = System.IO.File.ReadAllBytes(filePath);

                    Web myWeb = ctx.Web;
                    List myLibrary = myWeb.Lists.GetByTitle(libName);
                    Microsoft.SharePoint.Client.File uploadedFile = myLibrary.RootFolder.Files.Add(fcInfo);
                    //ctx.Load(myLibrary.ContentTypes);

                    try { 
                        ctx.ExecuteQuery();
                    }
                    catch (Exception ex)
                    {
                        if(ex.Message.StartsWith("A file with the name"))
                        {
                        }
                        form.list_error.Items.Add(ex.Message);
                    }
                    //ContentType myContentType = myLibrary.ContentTypes.Where(ct => ct.Name == "Picture").First();
                    uploadedFile.ListItemAllFields["Title"] = "Greg was here";
                    uploadedFile.ListItemAllFields.Update();
                    ctx.ExecuteQuery();
                }
            }
            form.label_status.Text = "Complete";

            if (doExcel)
            {
                form.label_status.Text += "Report at: C:\\temp\\SharePointMigration.xlsx";
            }
        }

        public static void uploadtoSharePoint(string filepath)
        {
            string filename = "xx";
            string folder = "";
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
                    //Console.WriteLine(e.Message);
                    form.list_error.Items.Add(e.Message);
                    
                    continue;
                }
                catch (System.IO.DirectoryNotFoundException e)
                {
                    //Console.WriteLine(e.Message);
                    form.list_error.Items.Add(e.Message);
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
                        security += "Account:" + ace.IdentityReference.Value + tab + "Type:" + ace.AccessControlType + tab + "Rights:" + ace.FileSystemRights + tab + "Inherited:" + ace.IsInherited + tab;
                    }
                    form.list_success.Items.Add("Folder" + tab + currentDir + tab + security);

                    files = System.IO.Directory.GetFiles(currentDir);
                }

                catch (UnauthorizedAccessException e)
                {
                    //Console.WriteLine(e.Message);
                    form.list_error.Items.Add(e.Message);
                    continue;
                }

                catch (System.IO.DirectoryNotFoundException e)
                {
                    //Console.WriteLine(e.Message);
                    form.list_error.Items.Add(e.Message);
                    continue;
                }
                // Perform the required action on each file here.
                // Modify this block to perform your required task.
                foreach (string file in files)
                {
                    string security = "";
                    try
                    {
                        // Perform whatever action is required in your scenario.
                        System.IO.FileInfo fi = new System.IO.FileInfo(file);
                        string extn = fi.Extension.ToLower();
                        Boolean exclude = false;
                        string key = "";
                        if (fi.Name.StartsWith("~"))
                        {
                            exclude = true;
                            key = "Failed" + tab + "~";
                        }
                        else if (!allowedfiles.Any(extn.Contains))
                        {
                            exclude = true;
                            key = "Failed" + tab + extn;
                        }
                        if (exclude)
                        {
                            form.list_exclude.Items.Add(file);
                        }
                        else
                        {
                            if(fi.Length > 2000000)
                            {
                                form.list_large.Items.Add(file);
                            }

                            //string author = System.IO.File.GetAccessControl(file).GetOwner(typeof(System.Security.Principal.NTAccount)).ToString();
                            FileSecurity fSecurity = System.IO.File.GetAccessControl(file);
                            string author = fSecurity.GetOwner(typeof(System.Security.Principal.NTAccount)).ToString();
                            AuthorizationRuleCollection acl = fSecurity.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount));
                            foreach (FileSystemAccessRule ace in acl)
                            {
                                security += "Account:" + ace.IdentityReference.Value + tab + "Type:" + ace.AccessControlType +  tab + "Rights:" + ace.FileSystemRights + tab + "Inherited:" + ace.IsInherited + tab;
                            }

                            if (!authors.ContainsKey(author))
                            {
                                authors[author] = 0;
                            }
                            authors[author]++; // = counts[key] + 1;

                            string uniqueFile = file; // + " " + fi.LastWriteTime;
                            string uniqueName = fi.Name; // + " " + fi.LastWriteTime;

                            if (!successfulfiles.ContainsKey(uniqueName))
                            {
                                successfulfiles[uniqueName] = uniqueFile;
                            } else
                            {
                                successfulfiles[uniqueName] += tab + uniqueFile;
                            }

                            form.list_success.Items.Add("File" + tab + uniqueFile + tab + security);
                            filetable.Rows.Add(uniqueFile, 1, "B", "C");

                            key = "Success" + tab + extn;

                        }
                        if (!counts.ContainsKey(key))
                        {
                            counts[key] = 0;
                        }
                        counts[key]++; // = counts[key] + 1;

                        if(fi.Name.Contains("&"))
                        {
                            form.list_ampersand.Items.Add(file);
                        }
                    }
                    catch (System.IO.FileNotFoundException e)
                    {
                        // If file was deleted by a separate application
                        //  or thread since the call to TraverseTree()
                        // then just continue.
                        //Console.WriteLine(e.Message);
                        form.list_error.Items.Add(e.Message);
                        continue;
                    }
                }

                // Push the subdirectories onto the stack for traversal.
                // This could also be done before handing the files.
                foreach (string str in subDirs)
                    dirs.Push(str);
            }

            foreach (KeyValuePair<string, int> entry in counts)
            {
                form.list_summary.Items.Add(entry.Value.ToString() + tab + entry.Key);
            }
            foreach (KeyValuePair<string, int> author in authors)
            {
                form.list_authors.Items.Add(author.Value.ToString() + tab + author.Key);
            }
            foreach (KeyValuePair<string, string> duplicates in successfulfiles)
            {
                if(duplicates.Value.Contains(tab))
                {
                    form.list_duplicates.Items.Add(duplicates.Value);
                }
            }

            form.label_status.Text = "Creating Excel Analasis document (C:\\temp\\SharePointMigration.xlsx)";
            System.Windows.Forms.Application.DoEvents();

            /*
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\temp\SharePointMigration.tsv"))
            {
                foreach (var item in form.list_success.Items)
                {
                    file.WriteLine("Success" + tab + item.ToString());
                }
                foreach (var item in form.list_error.Items)
                {
                    file.WriteLine("Error" + tab + item.ToString());
                }
                foreach (var item in form.list_exclude.Items)
                {
                    file.WriteLine("Excluded" + tab + item.ToString());
                }
                foreach (var item in form.list_ampersand.Items)
                {
                    file.WriteLine("Ampersand" + tab + item.ToString());
                }
                foreach (var item in form.list_duplicates.Items)
                {
                    file.WriteLine("Duplicate" + tab + item.ToString());
                }
                foreach (var item in form.list_summary.Items)
                {
                    file.WriteLine("Summary" + tab + item.ToString());
                }
                foreach (var item in form.list_large.Items)
                {
                    file.WriteLine("Large" + tab + item.ToString());
                }
                foreach (var item in form.list_users.Items)
                {
                    file.WriteLine("Site User" + tab + item.ToString());
                }
                foreach (var item in form.list_authors.Items)
                {
                    file.WriteLine("Author" + tab + item.ToString());
                }
            }
            */
            if (doExcel)
            {
                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                Workbook ExcelWorkBook = ExcelApp.Application.Workbooks.Add();

                createworksheet(ExcelWorkBook, 1, "Successful", form.list_success);
                createworksheet(ExcelWorkBook, 2, "Errors", form.list_error);
                createworksheet(ExcelWorkBook, 3, "Excluded", form.list_exclude);
                createworksheet(ExcelWorkBook, 4, "With &", form.list_ampersand);
                createworksheet(ExcelWorkBook, 5, "Duplicates", form.list_duplicates);
                createworksheet(ExcelWorkBook, 6, "Summary", form.list_summary);
                createworksheet(ExcelWorkBook, 7, "> 2mb", form.list_large);   //https://www.youtube.com/watch?v=g39RLflzonI&list=PLaIJswamN5lSSYPatSGSG5IC_gZXpBNdv&index=10
                createworksheet(ExcelWorkBook, 8, "Users", form.list_users);
                createworksheet(ExcelWorkBook, 9, "Authors", form.list_authors);

                ExcelWorkBook.SaveAs(@"C:\temp\SharePointMigration.xlsx");
                ExcelWorkBook.Close();
                ExcelApp.Quit();
                //Marshal.ReleaseComObject(ExcelWorkSheet);
                Marshal.ReleaseComObject(ExcelWorkBook);
                Marshal.ReleaseComObject(ExcelApp);
            }
        }

        private static void createworksheet(Workbook wb, int wsCtr, string wsName, System.Windows.Forms.ListBox lb)
        {
            Worksheet ws = wb.Worksheets.Add();
            ws.Name = wsName;

            ws.Cells[1, 1] = "";

            int r = 1;

            foreach (var item in lb.Items)
            {
                r++;
                int c = 0;
                foreach(var value in item.ToString().Split('\t'))
                {
                    c++;
                    ws.Cells[r, c] = value;
                }
            }
        }

        private static SharePointOnlineCredentials Credentials()
        {
            SecureString passWord = new SecureString();
            //foreach (char c in "Wanganui15".ToCharArray()) passWord.AppendChar(c);
            //return new NetworkCredential("MobileApp", passWord, "wdc-nt");

            //foreach (char c in "Linus007b".ToCharArray()) passWord.AppendChar(c);
            //return new NetworkCredential("OnlineService", passWord, "wdc-nt");

            foreach (char c in "Linus007b".ToCharArray()) passWord.AppendChar(c);
            return new SharePointOnlineCredentials("gtichbon@teorahou.org.nz", passWord);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btn_selectfolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if(fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                text_folder.Text = fbd.SelectedPath;
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
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
                System.Windows.Forms.Application.DoEvents();

                var siteUsers = ctx.LoadQuery(ctx.Web.SiteUsers);
                ctx.ExecuteQuery();
                foreach (var user in siteUsers)
                {
                    form.list_users.Items.Add(user.Id.ToString() + tab + user.Title);
                }
            }
            panel_locations.Show();

            label_status.Text = "Waiting for location details";
        }

        private void btn_selectfolder_Click_1(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                text_folder.Text = fbd.SelectedPath;
            }
        }
    }
}
