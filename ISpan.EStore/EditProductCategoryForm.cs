using Ispan.Utility;
using ISpan.EStore.Infra.Extensions;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ISpan.EStore
{
	public partial class EditProductCategoryForm : Form
	{
		private int id;

		public EditProductCategoryForm( int id)
		{
			InitializeComponent();
			this.id = id;
			BindData(id);
		}
		private void EditProductForm_Load(object sender, EventArgs e)
		{
			BindData(id);
		}

		private void BindData(int id)
		{
			string sql = "SELECT * FROM ProductCategories WHERE Id=@id";
			var parameters = new SqlParameterBuilder()
				.AddNInt("Id", id)
				.Build();
			DataTable data = new SqlDbHelper("default").Select( sql, parameters);
			if(data.Rows.Count == 0)
			{
				MessageBox.Show("找不到要編輯的紀錄");
				this.DialogResult = DialogResult.OK;
				this.Close();
				return;
			}
			DataRow row = data.Rows[0];
			categoryNameTextBox.Text = row.Field<string>("CategoryName");
			displayOrderTextBox.Text = row.Field<int>("DisplayOrder").ToString();
		}

		private void updateButton_Click(object sender, EventArgs e)
		{
			string categoryName = categoryNameTextBox.Text;

			int displayOrder = displayOrderTextBox.Text.ToInt(-1);

			string sql = @"UPDATE ProductCategories
SET CategoryName=@CategoryName,DisplayOrder=@DisplayOrder
WHERE Id=@Id";

			var parameters = new SqlParameterBuilder()
				.AddNVarchar("CategoryName", 50, categoryName)
				.AddNInt("DisplayOrder", displayOrder)
				.AddNInt("Id",this.id)
				.Build();

			new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);

			this.DialogResult = DialogResult.OK;
		}

		private void deleteButton_Click(object sender, EventArgs e)
		{
			if(MessageBox.Show("您真的要刪除嗎?","刪除紀錄",MessageBoxButtons.YesNo) != DialogResult.Yes)
			{
				return;
			}
			string categoryName = categoryNameTextBox.Text;

			int displayOrder = displayOrderTextBox.Text.ToInt(-1);

			string sql = @"Delete From ProductCategories WHERE Id=@Id";

			var parameters = new SqlParameterBuilder()
				.AddNInt("Id", this.id)
				.Build();

			new SqlDbHelper("default").ExecuteNonQuery(sql, parameters);

			this.DialogResult = DialogResult.OK;
		}
	}
}
