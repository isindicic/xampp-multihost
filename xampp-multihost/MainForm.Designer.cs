
namespace SindaSoft.XamppMultihost
{
    partial class MainForm
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
            this.lbVHosts = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnExplore = new System.Windows.Forms.Button();
            this.btnEditVHosts = new System.Windows.Forms.Button();
            this.btnEditHosts = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnFixHosts = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbVHosts
            // 
            this.lbVHosts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbVHosts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVHosts.FormattingEnabled = true;
            this.lbVHosts.ItemHeight = 20;
            this.lbVHosts.Location = new System.Drawing.Point(15, 20);
            this.lbVHosts.Name = "lbVHosts";
            this.lbVHosts.Size = new System.Drawing.Size(1044, 324);
            this.lbVHosts.TabIndex = 0;
            this.lbVHosts.SelectedIndexChanged += new System.EventHandler(this.lbVHosts_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(15, 359);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(122, 54);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Create";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(146, 359);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(122, 54);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen.Location = new System.Drawing.Point(278, 359);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(122, 54);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Open in browser";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnExplore
            // 
            this.btnExplore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExplore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExplore.Location = new System.Drawing.Point(406, 359);
            this.btnExplore.Name = "btnExplore";
            this.btnExplore.Size = new System.Drawing.Size(122, 54);
            this.btnExplore.TabIndex = 1;
            this.btnExplore.Text = "Open in explorer";
            this.btnExplore.UseVisualStyleBackColor = true;
            this.btnExplore.Click += new System.EventHandler(this.btnExplore_Click);
            // 
            // btnEditVHosts
            // 
            this.btnEditVHosts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditVHosts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditVHosts.Location = new System.Drawing.Point(913, 359);
            this.btnEditVHosts.Name = "btnEditVHosts";
            this.btnEditVHosts.Size = new System.Drawing.Size(146, 54);
            this.btnEditVHosts.TabIndex = 1;
            this.btnEditVHosts.Text = "Edit httpd-vhosts.conf";
            this.btnEditVHosts.UseVisualStyleBackColor = true;
            this.btnEditVHosts.Click += new System.EventHandler(this.btnEditVHosts_Click);
            // 
            // btnEditHosts
            // 
            this.btnEditHosts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditHosts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditHosts.Location = new System.Drawing.Point(761, 359);
            this.btnEditHosts.Name = "btnEditHosts";
            this.btnEditHosts.Size = new System.Drawing.Size(146, 54);
            this.btnEditHosts.TabIndex = 1;
            this.btnEditHosts.Text = "Edit hosts";
            this.btnEditHosts.UseVisualStyleBackColor = true;
            this.btnEditHosts.Click += new System.EventHandler(this.btnEditHosts_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(16, 429);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(1042, 48);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.Text = "---";
            // 
            // btnFixHosts
            // 
            this.btnFixHosts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFixHosts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFixHosts.Location = new System.Drawing.Point(534, 359);
            this.btnFixHosts.Name = "btnFixHosts";
            this.btnFixHosts.Size = new System.Drawing.Size(122, 54);
            this.btnFixHosts.TabIndex = 1;
            this.btnFixHosts.Text = "Add to hosts file";
            this.btnFixHosts.UseVisualStyleBackColor = true;
            this.btnFixHosts.Visible = false;
            this.btnFixHosts.Click += new System.EventHandler(this.btnFixHosts_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 486);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnEditHosts);
            this.Controls.Add(this.btnEditVHosts);
            this.Controls.Add(this.btnFixHosts);
            this.Controls.Add(this.btnExplore);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lbVHosts);
            this.MinimumSize = new System.Drawing.Size(1000, 300);
            this.Name = "MainForm";
            this.Text = "XAMPP Multihosts";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbVHosts;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnExplore;
        private System.Windows.Forms.Button btnEditVHosts;
        private System.Windows.Forms.Button btnEditHosts;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnFixHosts;
    }
}

