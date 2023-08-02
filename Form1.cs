using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment11_2
{
    public partial class Form1 : Form
    {
        BookRepository bookRepository;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bookRepository = new BookRepository();
            bookGrid.DataSource = bookRepository.GetAll();
            btnSubmit.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void Clear()
        {
            txtAuthor.Clear();
            txtDesc.Clear();
            txtTitle.Clear();
            txtISBN.Clear();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtAuthor.Text) && !string.IsNullOrEmpty(txtISBN.Text) 
                && !string.IsNullOrEmpty(txtDesc.Text) && !string.IsNullOrEmpty(txtTitle.Text))
            {
                var newBook = new BooksDB();
                newBook.ISBN = int.Parse(txtISBN.Text);
                newBook.Title = txtTitle.Text;
                newBook.Description = txtDesc.Text;
                newBook.Author_Name = txtAuthor.Text;
                bookRepository.AddRecord(newBook);
                MessageBox.Show("New book added");
            }
            Clear();
            btnSubmit.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtAuthor.Clear();
            txtISBN.Clear();
            txtTitle.Clear();
            txtDesc.Clear();
            btnSubmit.Enabled = true;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            var id = bookGrid.CurrentRow.Cells[0].Value;
            var bookToUpdate = bookRepository.FindBook((int)id);
            txtAuthor.Text = bookToUpdate.Title.ToString();
            txtDesc.Text = bookToUpdate.Description.ToString();
            txtISBN.Text = bookToUpdate.ISBN.ToString();
            txtDesc.Text = bookToUpdate.Description.ToString();
            btnUpdate.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var id = int.Parse(txtISBN.Text);
            var bookToUpdate = bookRepository.FindBook(id);
            bookToUpdate.Title = txtAuthor.Text;
            bookToUpdate.Description = txtDesc.Text;
            bookToUpdate.Author_Name = txtAuthor.Text;
            bookToUpdate.ISBN = int.Parse(txtISBN.Text);
            bookRepository.UpdateRecord(id, bookToUpdate);
            MessageBox.Show("Record Updated");
            Clear();
            btnUpdate.Enabled = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            bookGrid.DataSource = bookRepository.GetAll();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = bookGrid.CurrentRow.Cells[0].Value;
            int isbn = Convert.ToInt32(id);
            var bookToUpdate = bookRepository.FindBook(isbn);
            bookRepository.DeleteRecord(bookToUpdate);
            MessageBox.Show("Record deleted, bye book nice to read ya!");
        }
    }
}
