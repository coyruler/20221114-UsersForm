using Ispan.Utility;
using ISpan.EStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISpan.EStore
{
	public partial class UsersForm : Form
	{
        private UsersIndexVM[] users = null;
        public UsersForm()
		{
			InitializeComponent();
            InitForm();
            DisplayUsers();
        }
        public void InitForm()
        {
            userIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            var sql = "SELECT * FROM Users ORDER BY DisplayOrder";
            var dbHelper = new SqlDbHelper("default");
            List<UserCategoryVM> categories = dbHelper.Select(sql, null)
                .AsEnumerable()
                .Select(row => ToCategoryVM(row))
                .Prepend(new UserCategoryVM { Id = 0, Name = String.Empty })
                .ToList();
            this.userIdComboBox.DataSource = categories;
        }
        private UserCategoryVM ToCategoryVM(DataRow row)
        {
            return new UserCategoryVM
            {
                Id = row.Field<int>("Id"),
                Name = row.Field<string>("CategoryName"),
                DisplayOrder = row.Field<int>("DisplayOrder"),
            };
        }
        private void DisplayUsers()
        {
            string sql = @"SELECT * FROM Users P";

            SqlParameter[] parameters = new SqlParameter[] { };
            int categorId = ((ProductCategoryVM)userIdComboBox.SelectedItem).Id;
            if (categorId > 0)
            {
                sql += " WHERE CategoryId =@CategoryId";
                parameters = new SqlParameterBuilder()
                    .AddNInt("CategoryId", categorId)
                    .Build();
            }


            sql += " ORDER BY C.DisplayOrder, P.ProductName";
            var dbHelper = new SqlDbHelper("default");
            users = dbHelper.Select(sql, parameters)
                .AsEnumerable()
                .Select(row => ParseToIndexVM(row))
                .ToArray();

            BindData(users);
        }
        private void BindData(UsersIndexVM[] data)
        {
            dataGridView1.DataSource = data;
        }

        private UsersIndexVM ParseToIndexVM(DataRow row)
        {
            return new UsersIndexVM
            {
                Index = row.Field<int>("Id"),
                Name = row.Field<string>("Name"),
                Account = row.Field<string>("Account"),
                Password = row.Field<int>("Password")
            };
        }


        private void searchButton_Click(object sender, EventArgs e)
		{
            DisplayUsers();
        }

		private void addnewButton_Click(object sender, EventArgs e)
		{
            var frm = new CreateUserForm();
            DialogResult result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                DisplayUsers();
            }
        }

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
            int rowIndx = e.RowIndex;
            if (rowIndx < 0) return;
            UsersIndexVM row = this.users[rowIndx];
            int id = row.Index;

            var frm = new EditProductForm(id);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                DisplayUsers();
            }
        }
	}
}
