namespace Roslinky
{
    partial class CategoryManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoryManager));
            this.buttonAddCat = new System.Windows.Forms.Button();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.textBoxCategory = new System.Windows.Forms.TextBox();
            this.buttonAnihilation = new System.Windows.Forms.Button();
            this.buttonType = new System.Windows.Forms.Button();
            this.buttonDeleteType = new System.Windows.Forms.Button();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.textBoxType = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonAddCat
            // 
            this.buttonAddCat.Location = new System.Drawing.Point(271, 12);
            this.buttonAddCat.Name = "buttonAddCat";
            this.buttonAddCat.Size = new System.Drawing.Size(93, 23);
            this.buttonAddCat.TabIndex = 0;
            this.buttonAddCat.Text = "Dodaj kategorie";
            this.buttonAddCat.UseVisualStyleBackColor = true;
            this.buttonAddCat.Click += new System.EventHandler(this.buttonAddCat_Click);
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Location = new System.Drawing.Point(13, 42);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(251, 21);
            this.comboBoxCategory.TabIndex = 1;
            this.comboBoxCategory.SelectedIndexChanged += new System.EventHandler(this.comboBoxCategory_SelectedIndexChanged);
            // 
            // textBoxCategory
            // 
            this.textBoxCategory.Location = new System.Drawing.Point(13, 13);
            this.textBoxCategory.Name = "textBoxCategory";
            this.textBoxCategory.Size = new System.Drawing.Size(251, 20);
            this.textBoxCategory.TabIndex = 2;
            // 
            // buttonAnihilation
            // 
            this.buttonAnihilation.Location = new System.Drawing.Point(271, 39);
            this.buttonAnihilation.Name = "buttonAnihilation";
            this.buttonAnihilation.Size = new System.Drawing.Size(75, 23);
            this.buttonAnihilation.TabIndex = 3;
            this.buttonAnihilation.Text = "Usuń";
            this.buttonAnihilation.UseVisualStyleBackColor = true;
            this.buttonAnihilation.Click += new System.EventHandler(this.buttonAnihilation_Click);
            // 
            // buttonType
            // 
            this.buttonType.Location = new System.Drawing.Point(271, 69);
            this.buttonType.Name = "buttonType";
            this.buttonType.Size = new System.Drawing.Size(75, 23);
            this.buttonType.TabIndex = 4;
            this.buttonType.Text = "Dodaj typ";
            this.buttonType.UseVisualStyleBackColor = true;
            this.buttonType.Click += new System.EventHandler(this.buttonType_Click);
            // 
            // buttonDeleteType
            // 
            this.buttonDeleteType.Location = new System.Drawing.Point(271, 99);
            this.buttonDeleteType.Name = "buttonDeleteType";
            this.buttonDeleteType.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteType.TabIndex = 5;
            this.buttonDeleteType.Text = "Usuń";
            this.buttonDeleteType.UseVisualStyleBackColor = true;
            this.buttonDeleteType.Click += new System.EventHandler(this.buttonDeleteType_Click);
            // 
            // comboBoxType
            // 
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(13, 97);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(251, 21);
            this.comboBoxType.TabIndex = 6;
            // 
            // textBoxType
            // 
            this.textBoxType.Location = new System.Drawing.Point(13, 71);
            this.textBoxType.Name = "textBoxType";
            this.textBoxType.Size = new System.Drawing.Size(251, 20);
            this.textBoxType.TabIndex = 7;
            // 
            // CategoryManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 135);
            this.Controls.Add(this.textBoxType);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.buttonDeleteType);
            this.Controls.Add(this.buttonType);
            this.Controls.Add(this.buttonAnihilation);
            this.Controls.Add(this.textBoxCategory);
            this.Controls.Add(this.comboBoxCategory);
            this.Controls.Add(this.buttonAddCat);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CategoryManager";
            this.Text = "Menager kategorii";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CategoryManager_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddCat;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.TextBox textBoxCategory;
        private System.Windows.Forms.Button buttonAnihilation;
        private System.Windows.Forms.Button buttonType;
        private System.Windows.Forms.Button buttonDeleteType;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.TextBox textBoxType;
    }
}