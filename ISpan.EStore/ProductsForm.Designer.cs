namespace ISpan.EStore
{
	partial class ProductsForm
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
            this.components = new System.ComponentModel.Container();
            this.categoryIdComboBox = new System.Windows.Forms.ComboBox();
            this.productCategoryVMBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.productCategoryVMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.searchButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productIndexVMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.productCategoryVMBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productCategoryVMBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productIndexVMBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // categoryIdComboBox
            // 
            this.categoryIdComboBox.DataSource = this.productCategoryVMBindingSource1;
            this.categoryIdComboBox.DisplayMember = "CategoryName";
            this.categoryIdComboBox.FormattingEnabled = true;
            this.categoryIdComboBox.Location = new System.Drawing.Point(33, 28);
            this.categoryIdComboBox.Name = "categoryIdComboBox";
            this.categoryIdComboBox.Size = new System.Drawing.Size(121, 20);
            this.categoryIdComboBox.TabIndex = 0;
            this.categoryIdComboBox.ValueMember = "Id";
            // 
            // productCategoryVMBindingSource1
            // 
            this.productCategoryVMBindingSource1.DataSource = typeof(ISpan.EStore.Models.ViewModels.ProductCategoryVM);
            // 
            // productCategoryVMBindingSource
            // 
            this.productCategoryVMBindingSource.DataSource = typeof(ISpan.EStore.Models.ViewModels.ProductCategoryVM);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(161, 28);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(443, 28);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addnewButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.categoryNameDataGridViewTextBoxColumn,
            this.productNameDataGridViewTextBoxColumn,
            this.listPriceDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.productIndexVMBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(33, 92);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(485, 196);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // categoryNameDataGridViewTextBoxColumn
            // 
            this.categoryNameDataGridViewTextBoxColumn.DataPropertyName = "CategoryName";
            this.categoryNameDataGridViewTextBoxColumn.HeaderText = "分類名稱";
            this.categoryNameDataGridViewTextBoxColumn.Name = "categoryNameDataGridViewTextBoxColumn";
            // 
            // productNameDataGridViewTextBoxColumn
            // 
            this.productNameDataGridViewTextBoxColumn.DataPropertyName = "ProductName";
            this.productNameDataGridViewTextBoxColumn.HeaderText = "品名";
            this.productNameDataGridViewTextBoxColumn.Name = "productNameDataGridViewTextBoxColumn";
            // 
            // listPriceDataGridViewTextBoxColumn
            // 
            this.listPriceDataGridViewTextBoxColumn.DataPropertyName = "ListPrice";
            this.listPriceDataGridViewTextBoxColumn.HeaderText = "牌價";
            this.listPriceDataGridViewTextBoxColumn.Name = "listPriceDataGridViewTextBoxColumn";
            // 
            // productIndexVMBindingSource
            // 
            this.productIndexVMBindingSource.DataSource = typeof(ISpan.EStore.Models.ViewModels.ProductIndexVM);
            // 
            // ProductsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 356);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.categoryIdComboBox);
            this.Name = "ProductsForm";
            this.Text = "ProductsFrom";
            ((System.ComponentModel.ISupportInitialize)(this.productCategoryVMBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productCategoryVMBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productIndexVMBindingSource)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox categoryIdComboBox;
		private System.Windows.Forms.Button searchButton;
		private System.Windows.Forms.Button addButton;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn categoryNameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn listPriceDataGridViewTextBoxColumn;
		private System.Windows.Forms.BindingSource productIndexVMBindingSource;
		private System.Windows.Forms.BindingSource productCategoryVMBindingSource;
		private System.Windows.Forms.BindingSource productCategoryVMBindingSource1;
	}
}