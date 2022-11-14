using Ispan.Utility;
using ISpan.EStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ISpan.EStore
{

	public partial class ProductsForm : Form
	{
		private ProductIndexVM[] products = null;
		public ProductsForm()
		{
			InitializeComponent();
			InitForm();
			DisplayProducts();
		}
		public void InitForm() 
		{
			categoryIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			var sql = "SELECT * FROM ProductCategories ORDER BY DisplayOrder";
			var dbHelper = new SqlDbHelper("default");
			List<ProductCategoryVM> categories = dbHelper.Select(sql, null)
				.AsEnumerable()
				.Select(row => ToCategoryVM(row))
				.Prepend(new ProductCategoryVM{Id=0,CategoryName=String.Empty})
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
		private void DisplayProducts()
		{
			string sql = @"SELECT P.Id, P.ProductName, P.ListPrice, C.CategoryName
FROM Products P
INNER JOIN ProductCategories C 
ON P.CategoryId = C.Id";

			SqlParameter[] parameters = new SqlParameter[] { };
			int categorId = ((ProductCategoryVM)categoryIdComboBox.SelectedItem).Id;
			if(categorId > 0)
			{
				sql += " WHERE CategoryId =@CategoryId";
				parameters = new SqlParameterBuilder()
					.AddNInt("CategoryId",categorId)
					.Build();
			}


			sql += " ORDER BY C.DisplayOrder, P.ProductName";
			var dbHelper = new SqlDbHelper("default");
			products = dbHelper.Select(sql, parameters)
				.AsEnumerable()
				.Select(row => ParseToIndexVM(row))
				.ToArray();

			BindData(products);
		}
		private void BindData(ProductIndexVM[] data)
		{
			dataGridView1.DataSource=data;
		}

		private ProductIndexVM ParseToIndexVM(DataRow row)
		{
			return new ProductIndexVM
			{
				Id = row.Field<int>("Id"),
				CategoryName = row.Field<string>("CategoryName"),
				ProductName = row.Field<string>("ProductName"),
				ListPrice = row.Field<int>("ListPrice")
			};
		}

		private void searchButton_Click(object sender, EventArgs e)
		{
			DisplayProducts();
		}
		private void addnewButton_Click(object sender, EventArgs e)
		{
			var frm = new CreateProductForm();			
			DialogResult result = frm.ShowDialog();
			if (result == DialogResult.OK)
			{
				DisplayProducts();
			}
		}
		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			int rowIndx = e.RowIndex;
			if (rowIndx < 0) return;
			ProductIndexVM row = this.products[rowIndx];
			int id = row.Id;

			var frm = new EditProductForm(id);
			
			if (frm.ShowDialog() == DialogResult.OK)
			{
				DisplayProducts();
			}
		}
	}
}
