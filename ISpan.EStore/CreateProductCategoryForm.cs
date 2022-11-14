using Ispan.Utility;
using ISpan.EStore.Infra.Extensions;
using System;
using System.Windows.Forms;

namespace ISpan.EStore
{
	public partial class CreateProductCategoryForm : Form
	{
		public CreateProductCategoryForm()
		{
			InitializeComponent();
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
			string categoryName = categoryNameTextBox.Text;

			int displayOrder = displayOrderTextBox.Text.ToInt(-1);

			string sql = @"INSERT INTO  ProductCategories
(CategoryName,DisplayOrder)
VALUES
(@CategoryName,@DisplayOrder)";

			var parameters = new SqlParameterBuilder()
				.AddNVarchar("CategoryName", 50, categoryName)
				.AddNInt("DisplayOrder", displayOrder)
				.Build();

			new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);

			MessageBox.Show("紀錄已新增");
			this.DialogResult =DialogResult.OK;

		}
	}
}
