namespace MsCrmTools.SolutionComponentManager
{
    partial class MainControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAddExsting = new System.Windows.Forms.Button();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lvComponents = new MsCrmTools.SolutionComponentManager.UserControls.ComponentsView();
            this.lvSearchResults = new MsCrmTools.SolutionComponentManager.UserControls.ComponentsView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbbComponentType = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button1.Location = new System.Drawing.Point(8, 4);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 19);
            this.button1.TabIndex = 1;
            this.button1.Text = "Load Solution";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSearch.Location = new System.Drawing.Point(611, 4);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(60, 19);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnAddExsting
            // 
            this.btnAddExsting.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAddExsting.Location = new System.Drawing.Point(674, 4);
            this.btnAddExsting.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddExsting.Name = "btnAddExsting";
            this.btnAddExsting.Size = new System.Drawing.Size(227, 19);
            this.btnAddExsting.TabIndex = 5;
            this.btnAddExsting.Text = "Add select component to Target Solution";
            this.btnAddExsting.UseVisualStyleBackColor = true;
            this.btnAddExsting.Click += new System.EventHandler(this.btnAddExsting_Click);
            // 
            // txtKeyword
            // 
            this.txtKeyword.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtKeyword.Location = new System.Drawing.Point(505, 4);
            this.txtKeyword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(102, 20);
            this.txtKeyword.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(454, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Keyword";
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnRemove.Location = new System.Drawing.Point(111, 4);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(237, 19);
            this.btnRemove.TabIndex = 8;
            this.btnRemove.Text = "Remove select component from target solution";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lvComponents
            // 
            this.lvComponents.AutoScroll = true;
            this.lvComponents.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lvComponents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvComponents.Location = new System.Drawing.Point(0, 0);
            this.lvComponents.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lvComponents.Name = "lvComponents";
            this.lvComponents.Size = new System.Drawing.Size(428, 423);
            this.lvComponents.TabIndex = 2;
            // 
            // lvSearchResults
            // 
            this.lvSearchResults.AutoScroll = true;
            this.lvSearchResults.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lvSearchResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSearchResults.Location = new System.Drawing.Point(0, 0);
            this.lvSearchResults.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lvSearchResults.Name = "lvSearchResults";
            this.lvSearchResults.Size = new System.Drawing.Size(477, 423);
            this.lvSearchResults.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbbComponentType);
            this.panel1.Controls.Add(this.btnAddExsting);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtKeyword);
            this.panel1.Controls.Add(this.btnRemove);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(908, 32);
            this.panel1.TabIndex = 11;
            // 
            // cbbComponentType
            // 
            this.cbbComponentType.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cbbComponentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbComponentType.FormattingEnabled = true;
            this.cbbComponentType.Items.AddRange(new object[] {
            "Plugin Steps",
            "Plugin Assemblies",
            "Reports",
            "Web Resources",
            "Workflows"});
            this.cbbComponentType.Location = new System.Drawing.Point(352, 4);
            this.cbbComponentType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbbComponentType.Name = "cbbComponentType";
            this.cbbComponentType.Size = new System.Drawing.Size(91, 21);
            this.cbbComponentType.TabIndex = 9;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 32);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvComponents);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvSearchResults);
            this.splitContainer1.Size = new System.Drawing.Size(908, 423);
            this.splitContainer1.SplitterDistance = 428;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 12;
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(908, 455);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private UserControls.ComponentsView lvComponents;
        private UserControls.ComponentsView lvSearchResults;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAddExsting;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox cbbComponentType;
    }
}
