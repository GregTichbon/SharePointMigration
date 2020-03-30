namespace SharePointMigration
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.combo_site = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.text_username = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.text_password = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel_results = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.list_authors = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.list_users = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.list_large = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.list_ampersand = new System.Windows.Forms.ListBox();
            this.list_duplicates = new System.Windows.Forms.ListBox();
            this.list_summary = new System.Windows.Forms.ListBox();
            this.list_error = new System.Windows.Forms.ListBox();
            this.list_exclude = new System.Windows.Forms.ListBox();
            this.list_success = new System.Windows.Forms.ListBox();
            this.btn_login = new System.Windows.Forms.Button();
            this.panel_locations = new System.Windows.Forms.Panel();
            this.btn_Go = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.combo_library = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.text_folder = new System.Windows.Forms.TextBox();
            this.btn_selectfolder = new System.Windows.Forms.Button();
            this.label_status = new System.Windows.Forms.Label();
            this.panel_results.SuspendLayout();
            this.panel_locations.SuspendLayout();
            this.SuspendLayout();
            // 
            // combo_site
            // 
            this.combo_site.FormattingEnabled = true;
            this.combo_site.Items.AddRange(new object[] {
            "Christchurch",
            "Whanganui"});
            this.combo_site.Location = new System.Drawing.Point(46, 12);
            this.combo_site.Name = "combo_site";
            this.combo_site.Size = new System.Drawing.Size(193, 21);
            this.combo_site.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Site";
            // 
            // text_username
            // 
            this.text_username.Location = new System.Drawing.Point(344, 13);
            this.text_username.Name = "text_username";
            this.text_username.Size = new System.Drawing.Size(377, 20);
            this.text_username.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(280, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "User name";
            // 
            // text_password
            // 
            this.text_password.Location = new System.Drawing.Point(805, 17);
            this.text_password.Name = "text_password";
            this.text_password.PasswordChar = '*';
            this.text_password.Size = new System.Drawing.Size(377, 20);
            this.text_password.TabIndex = 23;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(746, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "Password";
            // 
            // panel_results
            // 
            this.panel_results.Controls.Add(this.label9);
            this.panel_results.Controls.Add(this.list_authors);
            this.panel_results.Controls.Add(this.label8);
            this.panel_results.Controls.Add(this.list_users);
            this.panel_results.Controls.Add(this.label7);
            this.panel_results.Controls.Add(this.list_large);
            this.panel_results.Controls.Add(this.label6);
            this.panel_results.Controls.Add(this.label5);
            this.panel_results.Controls.Add(this.label4);
            this.panel_results.Controls.Add(this.label3);
            this.panel_results.Controls.Add(this.label2);
            this.panel_results.Controls.Add(this.label1);
            this.panel_results.Controls.Add(this.list_ampersand);
            this.panel_results.Controls.Add(this.list_duplicates);
            this.panel_results.Controls.Add(this.list_summary);
            this.panel_results.Controls.Add(this.list_error);
            this.panel_results.Controls.Add(this.list_exclude);
            this.panel_results.Controls.Add(this.list_success);
            this.panel_results.Location = new System.Drawing.Point(3, 101);
            this.panel_results.Name = "panel_results";
            this.panel_results.Size = new System.Drawing.Size(1486, 619);
            this.panel_results.TabIndex = 30;
            this.panel_results.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(700, 128);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 37;
            this.label9.Text = "Authors";
            // 
            // list_authors
            // 
            this.list_authors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.list_authors.FormattingEnabled = true;
            this.list_authors.Location = new System.Drawing.Point(703, 144);
            this.list_authors.Name = "list_authors";
            this.list_authors.Size = new System.Drawing.Size(768, 95);
            this.list_authors.TabIndex = 36;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(700, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "Site Users";
            // 
            // list_users
            // 
            this.list_users.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.list_users.FormattingEnabled = true;
            this.list_users.Location = new System.Drawing.Point(703, 24);
            this.list_users.Name = "list_users";
            this.list_users.Size = new System.Drawing.Size(768, 95);
            this.list_users.TabIndex = 34;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 373);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Large files > 2Mb";
            // 
            // list_large
            // 
            this.list_large.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.list_large.FormattingEnabled = true;
            this.list_large.Location = new System.Drawing.Point(12, 389);
            this.list_large.Name = "list_large";
            this.list_large.Size = new System.Drawing.Size(671, 95);
            this.list_large.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 498);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Summary";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 253);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Files containing ampersand";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Duplicates";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Excluded";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(700, 373);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Errors";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(700, 251);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Successful";
            // 
            // list_ampersand
            // 
            this.list_ampersand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.list_ampersand.FormattingEnabled = true;
            this.list_ampersand.Location = new System.Drawing.Point(9, 269);
            this.list_ampersand.Name = "list_ampersand";
            this.list_ampersand.Size = new System.Drawing.Size(674, 95);
            this.list_ampersand.TabIndex = 25;
            // 
            // list_duplicates
            // 
            this.list_duplicates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.list_duplicates.FormattingEnabled = true;
            this.list_duplicates.Location = new System.Drawing.Point(9, 144);
            this.list_duplicates.Name = "list_duplicates";
            this.list_duplicates.Size = new System.Drawing.Size(674, 95);
            this.list_duplicates.TabIndex = 24;
            // 
            // list_summary
            // 
            this.list_summary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.list_summary.FormattingEnabled = true;
            this.list_summary.Location = new System.Drawing.Point(12, 514);
            this.list_summary.Name = "list_summary";
            this.list_summary.Size = new System.Drawing.Size(671, 95);
            this.list_summary.TabIndex = 23;
            // 
            // list_error
            // 
            this.list_error.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.list_error.FormattingEnabled = true;
            this.list_error.Location = new System.Drawing.Point(703, 389);
            this.list_error.Name = "list_error";
            this.list_error.Size = new System.Drawing.Size(760, 95);
            this.list_error.TabIndex = 22;
            // 
            // list_exclude
            // 
            this.list_exclude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.list_exclude.FormattingEnabled = true;
            this.list_exclude.Location = new System.Drawing.Point(9, 24);
            this.list_exclude.Name = "list_exclude";
            this.list_exclude.Size = new System.Drawing.Size(674, 95);
            this.list_exclude.TabIndex = 21;
            // 
            // list_success
            // 
            this.list_success.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.list_success.FormattingEnabled = true;
            this.list_success.Location = new System.Drawing.Point(703, 267);
            this.list_success.Name = "list_success";
            this.list_success.Size = new System.Drawing.Size(768, 95);
            this.list_success.TabIndex = 20;
            // 
            // btn_login
            // 
            this.btn_login.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_login.Location = new System.Drawing.Point(1188, 17);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(157, 20);
            this.btn_login.TabIndex = 32;
            this.btn_login.Text = "Login";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // panel_locations
            // 
            this.panel_locations.Controls.Add(this.btn_Go);
            this.panel_locations.Controls.Add(this.label14);
            this.panel_locations.Controls.Add(this.combo_library);
            this.panel_locations.Controls.Add(this.label13);
            this.panel_locations.Controls.Add(this.text_folder);
            this.panel_locations.Controls.Add(this.btn_selectfolder);
            this.panel_locations.Location = new System.Drawing.Point(3, 43);
            this.panel_locations.Name = "panel_locations";
            this.panel_locations.Size = new System.Drawing.Size(1374, 52);
            this.panel_locations.TabIndex = 33;
            this.panel_locations.Visible = false;
            // 
            // btn_Go
            // 
            this.btn_Go.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Go.Location = new System.Drawing.Point(1185, 17);
            this.btn_Go.Name = "btn_Go";
            this.btn_Go.Size = new System.Drawing.Size(157, 23);
            this.btn_Go.TabIndex = 37;
            this.btn_Go.Text = "Go";
            this.btn_Go.UseVisualStyleBackColor = true;
            this.btn_Go.Click += new System.EventHandler(this.btn_Go_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(799, 20);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(93, 13);
            this.label14.TabIndex = 36;
            this.label14.Text = "SharePoint Library";
            // 
            // combo_library
            // 
            this.combo_library.FormattingEnabled = true;
            this.combo_library.Location = new System.Drawing.Point(898, 17);
            this.combo_library.Name = "combo_library";
            this.combo_library.Size = new System.Drawing.Size(281, 21);
            this.combo_library.TabIndex = 35;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 13);
            this.label13.TabIndex = 34;
            this.label13.Text = "Starting Folder";
            // 
            // text_folder
            // 
            this.text_folder.Location = new System.Drawing.Point(119, 20);
            this.text_folder.Name = "text_folder";
            this.text_folder.Size = new System.Drawing.Size(599, 20);
            this.text_folder.TabIndex = 33;
            // 
            // btn_selectfolder
            // 
            this.btn_selectfolder.Location = new System.Drawing.Point(727, 18);
            this.btn_selectfolder.Name = "btn_selectfolder";
            this.btn_selectfolder.Size = new System.Drawing.Size(44, 23);
            this.btn_selectfolder.TabIndex = 32;
            this.btn_selectfolder.Text = "...";
            this.btn_selectfolder.UseVisualStyleBackColor = true;
            this.btn_selectfolder.Click += new System.EventHandler(this.btn_selectfolder_Click_1);
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_status.Location = new System.Drawing.Point(11, 735);
            this.label_status.MaximumSize = new System.Drawing.Size(500, 0);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(202, 24);
            this.label_status.TabIndex = 39;
            this.label_status.Text = "Waiting for login details";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1520, 819);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.panel_locations);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.panel_results);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.text_password);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.text_username);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.combo_site);
            this.Name = "Form1";
            this.Text = "Migrate";
            this.panel_results.ResumeLayout(false);
            this.panel_results.PerformLayout();
            this.panel_locations.ResumeLayout(false);
            this.panel_locations.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox combo_site;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox text_username;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox text_password;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Panel panel_results;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox list_authors;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox list_users;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox list_large;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox list_ampersand;
        private System.Windows.Forms.ListBox list_duplicates;
        private System.Windows.Forms.ListBox list_summary;
        private System.Windows.Forms.ListBox list_error;
        private System.Windows.Forms.ListBox list_exclude;
        private System.Windows.Forms.ListBox list_success;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Panel panel_locations;
        private System.Windows.Forms.Button btn_Go;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox combo_library;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox text_folder;
        private System.Windows.Forms.Button btn_selectfolder;
        private System.Windows.Forms.Label label_status;
    }
}

