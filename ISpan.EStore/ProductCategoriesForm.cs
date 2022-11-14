using Ispan.Utility;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ISpan.EStore
{
	public partial class ProductCategoriesForm : Form
	{
		DataTable categories;
		public ProductCategoriesForm()
		{
			InitializeComponent();	
			DisplayProductCatetories();
		}

		private void DisplayProductCatetories()
		{
			string sql = "SELECT * FROM ProductCategories ORDER BY DisplayOrder";
			categories = new SqlDbHelper("default").Select(sql,null);

			BindData(categories);
		}

		private void BindData(DataTable model)
		{
			dataGridView1.DataSource = model;
		}

		private void addnewButton_Click(object sender, EventArgs e)
		{
			var frm = new CreateProductCategoryForm();
			//frm.Show();
			DialogResult result = frm.ShowDialog();
			if(result == DialogResult.OK)
			{
				DisplayProductCatetories();
			}
		}

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			int rowIndx = e.RowIndex;
			if (rowIndx < 0) return;
			DataRow row = this.categories.Rows[rowIndx];
			int id = row.Field<int>("id");

			var frm = new EditProductCategoryForm(id);
			//frm.Show();
			DialogResult result = frm.ShowDialog();
			if (result == DialogResult.OK)
			{
				DisplayProductCatetories();
			}
		}

	}
}
