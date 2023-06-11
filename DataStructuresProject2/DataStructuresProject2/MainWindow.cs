using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataStructuresProject2
{
    /// <summary>
    /// Class to set all the event handlers for our main window.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class MainWindow : Form
    {
        PersonalLibrary lib = new PersonalLibrary(); // allows access to the library for all event handlers

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            WelcomeScreen();
            InitializeComponent();

        }

        /// <summary>
        /// "Splash screen" that greets the user upon opening of the main window.
        /// </summary>
        private void WelcomeScreen()
        {
            MessageBox.Show("Welcome to the Project 2 Personal Library! Here you will be able to upload a library from a text file, interact with and modify" +
                "the books in the library, change the owner of the library, and save any changes made. Thank you for choosing to use this program! ");
        }

        /// <summary>
        /// Dictates the editing process for the program whenever the Edit option is selected.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Paint event of the panel1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// Handles the Load event of the Form1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the listBox1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Click event of the openToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog libFile = new OpenFileDialog();

            libFile.InitialDirectory = Application.StartupPath + @".\.\LibraryData";
            libFile.Title = "Choose a Library to Display";
            libFile.Filter = "text files|*.txt|all files|*.*";

            if (libFile.ShowDialog() == DialogResult.Cancel)
                return;

            StreamReader rdr = null;
            Book b = null;
            PersonalLibrary currentLib = new PersonalLibrary();
            Person libraryOwner = null;
            FillLibrary(libFile, ref rdr, ref b, ref currentLib, ref libraryOwner);
        }

        /// <summary>
        /// Fills the library with book objects from a text file. Also sets the library owner.
        /// </summary>
        /// <param name="libFile">The library file.</param>
        /// <param name="rdr">The RDR.</param>
        /// <param name="b">The b.</param>
        /// <param name="currentLib">The current library.</param>
        /// <param name="libraryOwner">The library owner.</param>
        private void FillLibrary(OpenFileDialog libFile, ref StreamReader rdr, ref Book b, ref PersonalLibrary currentLib, ref Person libraryOwner)
        {
            try
            {
                rdr = new StreamReader(libFile.FileName);
                while (rdr.Peek() != -1)
                {
                    String[] fields = rdr.ReadLine().Split('|');
                    if (fields.Length != 8)
                    {
                        try
                        {
                            b = new Book((Type)Enum.Parse(typeof(Type), fields[0]), fields[1], fields[2], fields[3],
                                            (Category)Enum.Parse(typeof(Category), fields[4]), Convert.ToDecimal(fields[5]));
                            currentLib += b;

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An invalid Category or Print Type was found, so the book " + fields[1] + " could not be added.");
                        }
                    }
                    else
                    {
                        libraryOwner = new Person(fields[0], fields[1], fields[2], fields[3], fields[4], fields[5], fields[6], fields[7]);
                        if (fields.Contains("Invalid"))
                            MessageBox.Show("One or more fields of the owner are invalid; please update them to remove the 'Invalid' marker. ");
                        currentLib.Owner = libraryOwner;
                    }
                }

                for (int i = 0; i < currentLib.BookCount; i++)
                {
                    listBox1.Items.Add(currentLib[i].Title);    // adding the books to the list box
                    listBox1.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error loading the library. Please make sure an appropriate file is selected.");
                return;
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                    currentLib.SaveNeeded = true;
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the saveToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        /// <summary>
        /// Saves the file.
        /// </summary>
        private void SaveFile()
        {
            SaveFileDialog save = new SaveFileDialog();

            save.InitialDirectory = Application.StartupPath + @".\.\LibraryData";
            save.Title = "Save this Personal Library";
            save.Filter = "text files|*.txt|all files|*.*";

            if (save.ShowDialog() == DialogResult.Cancel)
                return;

            StreamWriter saveWrite = null;
            try
            {
                saveWrite = new StreamWriter(new FileStream(save.FileName, FileMode.Create, FileAccess.Write));
                saveWrite.WriteLine(lib.Owner.Name + '|' + lib.Owner.StreetAddress + '|' + lib.Owner.City +
                    '|' + lib.Owner.State + '|' + lib.Owner.ZipCode + '|' + lib.Owner.ID + '|' + lib.Owner.PhoneNumber + '|'
                    + lib.Owner.EmailAddress);

                for (int i = 0; i < lib.BookCount; i++)
                {
                    Book b = lib[i];
                    saveWrite.WriteLine(b.BookType.ToString() + '|' + b.Title + '|' + b.Author + '|' + b.Coauthor + '|' + b.BookCategory.ToString() +
                        '|' + b.Price.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error saving the file. Invalid data will not be saved. ");
                Application.Exit();
            }
            finally
            {
                if (saveWrite != null)
                    saveWrite.Close();
            }
            lib.SaveNeeded = false;
        }

        /// <summary>
        /// Handles the Click event of the aboutToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.Show();
        }

        /// <summary>
        /// Handles the Click event of the quitToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lib.SaveNeeded == true)
            {
                MessageBox.Show("There is unsaved data in the library. Would you like to save before closing? ", "Save Before You Go? ", MessageBoxButtons.OKCancel);

                if (MessageBox.Show("There is unsaved data in the library. Would you like to save before closing? ", "Save Before You Go? ", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    SaveFile();
                }
                else
                {
                    Application.Exit();
                }
            }
        }
    }
}
