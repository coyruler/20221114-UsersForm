using Ispan.Utility;
using ISpan.EStore.Infra.Extensions;
using ISpan.EStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ISpan.EStore
{
	public partial class CreateProductForm : Form
	{
		public CreateProductForm()
		{			
			InitializeComponent();
			InitForm();
		}
		public void InitForm()
		{
			categoryIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			var sql = "SELECT * FROM ProductCategories ORDER BY DisplayOrder";
			var dbHelper = new SqlDbHelper("default");
			List<ProductCategoryVM> categories = dbHelper.Select(sql, null)
				.AsEnumerable()
				.Select(row => ToCategoryVM(row))
				.ToList();
			this.categoryIdComboBox.DataSource = categories;
		}
		private ProductCategoryVM ToCategoryVM(DataRow row)
		{
			return new ProductCategoryVM
			{
				Id = row.Field<int>("Id"),
				CategoryName = row.Field<string>("CategoryName"),
				DisplayOrder = row.Field<int>("DisplayOrder"),
			};
		}
		private void saveButton_Click(object sender, EventArgs e)
		{
			int categoryId = ((ProductCategoryVM)this.categoryIdComboBox.SelectedItem).Id;
			string productName = productNameTextBox.Text;
			int listPrice = priceListTextBox.Text.ToInt(-1);

			ProductVM model = new ProductVM
			{
				CategoryId = categoryId,
				ProductName = productName,
				ListPrice = listPrice,
			};

			string errMsg = string.Empty;
			if (string.IsNullOrEmpty(model.ProductName)) errMsg += "商品名稱必甜\r\n";
			if (model.ListPrice < 0) errMsg += "牌價必須輸入大於或=0的正整數\r\n";

			if (string.IsNullOrEmpty(errMsg) == false)
			{
				MessageBox.Show(errMsg);
				return;
			}

			string sql = @"INSERT INTO  Products
(CategoryId, ProductName, ListPrice)
VALUES
(@CategoryId, @ProductName, @ListPrice)";

			var parameters = new SqlParameterBuilder()
				.AddNInt("CategoryId", model.CategoryId)
				.AddNVarchar("ProductName",50 , model.ProductName)
				.AddNInt("ListPrice", model.ListPrice)
				.Build();

			new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);

			this.DialogResult = DialogResult.OK;

		}
	}
}
