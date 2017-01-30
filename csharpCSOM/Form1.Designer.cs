namespace csharpCSOM
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnSelectFields = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nestedIncludesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cAMLQueryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataBindingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.batchExceptionHandlingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addEditListItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateListItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.librariesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addALibraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.addSampleDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnSelectFields);
            this.splitContainer1.Panel2.Controls.Add(this.button2);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Size = new System.Drawing.Size(671, 370);
            this.splitContainer1.SplitterDistance = 459;
            this.splitContainer1.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(459, 370);
            this.listBox1.TabIndex = 1;
            // 
            // btnSelectFields
            // 
            this.btnSelectFields.Location = new System.Drawing.Point(14, 82);
            this.btnSelectFields.Name = "btnSelectFields";
            this.btnSelectFields.Size = new System.Drawing.Size(75, 23);
            this.btnSelectFields.TabIndex = 2;
            this.btnSelectFields.Text = "select fields";
            this.btnSelectFields.UseVisualStyleBackColor = true;
            this.btnSelectFields.Click += new System.EventHandler(this.btnSelectFields_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(14, 42);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "load query";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "load lists";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionsToolStripMenuItem,
            this.librariesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(671, 32);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nestedIncludesToolStripMenuItem,
            this.cAMLQueryToolStripMenuItem,
            this.dataBindingToolStripMenuItem,
            this.addAListToolStripMenuItem,
            this.batchExceptionHandlingToolStripMenuItem,
            this.addEditListItemToolStripMenuItem,
            this.updateListItemToolStripMenuItem});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(42, 28);
            this.actionsToolStripMenuItem.Text = "Lists";
            // 
            // nestedIncludesToolStripMenuItem
            // 
            this.nestedIncludesToolStripMenuItem.Name = "nestedIncludesToolStripMenuItem";
            this.nestedIncludesToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.nestedIncludesToolStripMenuItem.Text = "Nested includes";
            this.nestedIncludesToolStripMenuItem.Click += new System.EventHandler(this.nestedIncludesToolStripMenuItem_Click);
            // 
            // cAMLQueryToolStripMenuItem
            // 
            this.cAMLQueryToolStripMenuItem.Name = "cAMLQueryToolStripMenuItem";
            this.cAMLQueryToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.cAMLQueryToolStripMenuItem.Text = "CAML Query";
            this.cAMLQueryToolStripMenuItem.Click += new System.EventHandler(this.cAMLQueryToolStripMenuItem_Click);
            // 
            // dataBindingToolStripMenuItem
            // 
            this.dataBindingToolStripMenuItem.Name = "dataBindingToolStripMenuItem";
            this.dataBindingToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.dataBindingToolStripMenuItem.Text = "Data binding";
            this.dataBindingToolStripMenuItem.Click += new System.EventHandler(this.dataBindingToolStripMenuItem_Click);
            // 
            // addAListToolStripMenuItem
            // 
            this.addAListToolStripMenuItem.Name = "addAListToolStripMenuItem";
            this.addAListToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.addAListToolStripMenuItem.Text = "Add a list";
            this.addAListToolStripMenuItem.Click += new System.EventHandler(this.addAListToolStripMenuItem_Click);
            // 
            // batchExceptionHandlingToolStripMenuItem
            // 
            this.batchExceptionHandlingToolStripMenuItem.Name = "batchExceptionHandlingToolStripMenuItem";
            this.batchExceptionHandlingToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.batchExceptionHandlingToolStripMenuItem.Text = "Batch Exception Handling";
            this.batchExceptionHandlingToolStripMenuItem.Click += new System.EventHandler(this.batchExceptionHandlingToolStripMenuItem_Click);
            // 
            // addEditListItemToolStripMenuItem
            // 
            this.addEditListItemToolStripMenuItem.Name = "addEditListItemToolStripMenuItem";
            this.addEditListItemToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.addEditListItemToolStripMenuItem.Text = "Add/Edit list item";
            this.addEditListItemToolStripMenuItem.Click += new System.EventHandler(this.addEditListItemToolStripMenuItem_Click);
            // 
            // updateListItemToolStripMenuItem
            // 
            this.updateListItemToolStripMenuItem.Name = "updateListItemToolStripMenuItem";
            this.updateListItemToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.updateListItemToolStripMenuItem.Text = "Update list item";
            this.updateListItemToolStripMenuItem.Click += new System.EventHandler(this.updateListItemToolStripMenuItem_Click);
            // 
            // librariesToolStripMenuItem
            // 
            this.librariesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addALibraryToolStripMenuItem,
            this.addSampleDocumentToolStripMenuItem});
            this.librariesToolStripMenuItem.Name = "librariesToolStripMenuItem";
            this.librariesToolStripMenuItem.Size = new System.Drawing.Size(63, 28);
            this.librariesToolStripMenuItem.Text = "Libraries";
            // 
            // addALibraryToolStripMenuItem
            // 
            this.addALibraryToolStripMenuItem.Name = "addALibraryToolStripMenuItem";
            this.addALibraryToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.addALibraryToolStripMenuItem.Text = "Add a library";
            this.addALibraryToolStripMenuItem.Click += new System.EventHandler(this.addALibraryToolStripMenuItem_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.menuStrip1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(671, 406);
            this.splitContainer2.SplitterDistance = 32;
            this.splitContainer2.TabIndex = 2;
            // 
            // addSampleDocumentToolStripMenuItem
            // 
            this.addSampleDocumentToolStripMenuItem.Name = "addSampleDocumentToolStripMenuItem";
            this.addSampleDocumentToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.addSampleDocumentToolStripMenuItem.Text = "Add sample document";
            this.addSampleDocumentToolStripMenuItem.Click += new System.EventHandler(this.addSampleDocumentToolStripMenuItem_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 406);
            this.Controls.Add(this.splitContainer2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "CSOM SharePoint Dev";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnSelectFields;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nestedIncludesToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStripMenuItem cAMLQueryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataBindingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addAListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem batchExceptionHandlingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addEditListItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateListItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem librariesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addALibraryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addSampleDocumentToolStripMenuItem;
    }
}

