using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace toDoListApp
{
    public partial class toDoList : Form
    {
        // Declare a DataTable to store the to-do list items
        private DataTable todoList = new DataTable();

        // Flag to indicate if a task is being edited
        private bool isEditing = false;

        public toDoList()
        {
            InitializeComponent();
        }

        // Initialize the form and set up the DataGridView with columns
        private void Form1_Load(object sender, EventArgs e)
        {
            // Create columns for the "Title" and "Description" fields of tasks
            todoList.Columns.Add("Title");
            todoList.Columns.Add("Description");

            // Bind the DataGridView control to the DataTable to display the data
            toDoListView.DataSource = todoList;
        }

        // Clear the text boxes for entering a new task
        private void newButton_Click(object sender, EventArgs e)
        {
            titleTextBox.Text = "";
            descriptionTextBox.Text = "";
        }

        // Retrieve data for editing a selected task
        private void editButton_Click(object sender, EventArgs e)
        {
            isEditing = true;

            // Get the row index of the selected cell in the DataGridView
            int rowIndex = toDoListView.CurrentCell.RowIndex;

            // Fill titleTextBox and descriptionTextBox with the data from the selected row
            titleTextBox.Text = todoList.Rows[rowIndex].ItemArray[0].ToString();
            descriptionTextBox.Text = todoList.Rows[rowIndex].ItemArray[1].ToString();
        }

        // Delete the selected task
        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the row index of the selected cell in the DataGridView
                int rowIndex = toDoListView.CurrentCell.RowIndex;

                // Delete the corresponding row from the DataTable
                todoList.Rows[rowIndex].Delete();
            }
            catch (Exception ex)
            {
                // Handle any errors during deletion
                Console.WriteLine("Error: " + ex);
            }
        }

        // Save the edited or new task to the DataTable
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (isEditing)
            {
                // Update the existing task in the DataTable
                int rowIndex = toDoListView.CurrentCell.RowIndex;
                todoList.Rows[rowIndex]["Title"] = titleTextBox.Text;
                todoList.Rows[rowIndex]["Description"] = descriptionTextBox.Text;
            }
            else
            {
                // Add a new task to the DataTable
                todoList.Rows.Add(titleTextBox.Text, descriptionTextBox.Text);
            }

            // Clear the text boxes
            titleTextBox.Text = "";
            descriptionTextBox.Text = "";
        }

        // Close the application
        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}