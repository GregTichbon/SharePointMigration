namespace SharePointMigration
{
    partial class Migrate
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
            this.panel_locations = new System.Windows.Forms.Panel();
            this.btn_Go = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.combo_library = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.text_folder = new System.Windows.Forms.TextBox();
            this.btn_selectfolder = new System.Windows.Forms.Button();
            this.label_status = new System.Windows.Forms.Label();
            this.btn_login = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.text_password = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.text_username = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.combo_site = new System.Windows.Forms.ComboBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button_login = new System.Windows.Forms.Button();
            this.text_extensions = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.check_createfolders = new System.Windows.Forms.CheckBox();
            this.text_removefolderfield = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel_locations.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_locations
            // 
            this.panel_locations.Controls.Add(this.label1);
            this.panel_locations.Controls.Add(this.label2);
            this.panel_locations.Controls.Add(this.text_extensions);
            this.panel_locations.Controls.Add(this.text_removefolderfield);
            this.panel_locations.Controls.Add(this.check_createfolders);
            this.panel_locations.Controls.Add(this.btn_Go);
            this.panel_locations.Controls.Add(this.label14);
            this.panel_locations.Controls.Add(this.combo_library);
            this.panel_locations.Controls.Add(this.label13);
            this.panel_locations.Controls.Add(this.text_folder);
            this.panel_locations.Controls.Add(this.btn_selectfolder);
            this.panel_locations.Location = new System.Drawing.Point(139, 100);
            this.panel_locations.Name = "panel_locations";
            this.panel_locations.Size = new System.Drawing.Size(1374, 161);
            this.panel_locations.TabIndex = 48;
            this.panel_locations.Visible = false;
            // 
            // btn_Go
            // 
            this.btn_Go.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Go.Location = new System.Drawing.Point(1190, 16);
            this.btn_Go.Name = "btn_Go";
            this.btn_Go.Size = new System.Drawing.Size(157, 99);
            this.btn_Go.TabIndex = 37;
            this.btn_Go.Text = "Go";
            this.btn_Go.UseVisualStyleBackColor = true;
            this.btn_Go.Click += new System.EventHandler(this.btn_Go_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(668, 20);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(93, 13);
            this.label14.TabIndex = 36;
            this.label14.Text = "SharePoint Library";
            // 
            // combo_library
            // 
            this.combo_library.FormattingEnabled = true;
            this.combo_library.Location = new System.Drawing.Point(767, 17);
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
            this.text_folder.Location = new System.Drawing.Point(93, 19);
            this.text_folder.Name = "text_folder";
            this.text_folder.Size = new System.Drawing.Size(513, 20);
            this.text_folder.TabIndex = 33;
            // 
            // btn_selectfolder
            // 
            this.btn_selectfolder.Location = new System.Drawing.Point(612, 16);
            this.btn_selectfolder.Name = "btn_selectfolder";
            this.btn_selectfolder.Size = new System.Drawing.Size(44, 23);
            this.btn_selectfolder.TabIndex = 32;
            this.btn_selectfolder.Text = "...";
            this.btn_selectfolder.UseVisualStyleBackColor = true;
            this.btn_selectfolder.Click += new System.EventHandler(this.btn_selectfolder_Click);
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_status.Location = new System.Drawing.Point(135, 315);
            this.label_status.MaximumSize = new System.Drawing.Size(500, 0);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(202, 24);
            this.label_status.TabIndex = 49;
            this.label_status.Text = "Waiting for login details";
            // 
            // btn_login
            // 
            this.btn_login.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_login.Location = new System.Drawing.Point(1327, -419);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(157, 20);
            this.btn_login.TabIndex = 47;
            this.btn_login.Text = "Login";
            this.btn_login.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(885, 34);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 45;
            this.label12.Text = "Password";
            // 
            // text_password
            // 
            this.text_password.Location = new System.Drawing.Point(944, 31);
            this.text_password.Name = "text_password";
            this.text_password.PasswordChar = '*';
            this.text_password.Size = new System.Drawing.Size(377, 20);
            this.text_password.TabIndex = 44;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(419, 34);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 13);
            this.label11.TabIndex = 43;
            this.label11.Text = "User name";
            // 
            // text_username
            // 
            this.text_username.Location = new System.Drawing.Point(483, 27);
            this.text_username.Name = "text_username";
            this.text_username.Size = new System.Drawing.Size(377, 20);
            this.text_username.TabIndex = 42;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(155, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 13);
            this.label10.TabIndex = 41;
            this.label10.Text = "Site";
            // 
            // combo_site
            // 
            this.combo_site.FormattingEnabled = true;
            this.combo_site.Items.AddRange(new object[] {
            "Christchurch",
            "Whanganui",
            "Northland"});
            this.combo_site.Location = new System.Drawing.Point(186, 27);
            this.combo_site.Name = "combo_site";
            this.combo_site.Size = new System.Drawing.Size(193, 21);
            this.combo_site.TabIndex = 40;
            // 
            // button_login
            // 
            this.button_login.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_login.Location = new System.Drawing.Point(1329, 31);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(157, 20);
            this.button_login.TabIndex = 50;
            this.button_login.Text = "Login";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // text_extensions
            // 
            this.text_extensions.Location = new System.Drawing.Point(85, 95);
            this.text_extensions.Name = "text_extensions";
            this.text_extensions.Size = new System.Drawing.Size(1097, 20);
            this.text_extensions.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 52;
            this.label1.Text = "Extensions";
            // 
            // check_createfolders
            // 
            this.check_createfolders.AutoSize = true;
            this.check_createfolders.Location = new System.Drawing.Point(1065, 22);
            this.check_createfolders.Name = "check_createfolders";
            this.check_createfolders.Size = new System.Drawing.Size(94, 17);
            this.check_createfolders.TabIndex = 39;
            this.check_createfolders.Text = "Create Folders";
            this.check_createfolders.UseVisualStyleBackColor = true;
            this.check_createfolders.CheckedChanged += new System.EventHandler(this.check_createfolders_CheckedChanged);
            // 
            // text_removefolderfield
            // 
            this.text_removefolderfield.Location = new System.Drawing.Point(193, 58);
            this.text_removefolderfield.Name = "text_removefolderfield";
            this.text_removefolderfield.Size = new System.Drawing.Size(513, 20);
            this.text_removefolderfield.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Remove from \"Folder Origin\" Field";
            // 
            // Migrate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1771, 348);
            this.Controls.Add(this.button_login);
            this.Controls.Add(this.panel_locations);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.text_password);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.text_username);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.combo_site);
            this.Name = "Migrate";
            this.Text = "SharePoint Migration Tool";
            this.panel_locations.ResumeLayout(false);
            this.panel_locations.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_locations;
        private System.Windows.Forms.Button btn_Go;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox combo_library;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox text_folder;
        private System.Windows.Forms.Button btn_selectfolder;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox text_password;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox text_username;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox combo_site;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.TextBox text_extensions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox check_createfolders;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox text_removefolderfield;
    }
}