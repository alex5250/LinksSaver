using System;
using System.Windows.Forms;

using IniParser;
using IniParser.Model;
namespace SchoolLinks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static void GoToSite(string url)
        {
            System.Diagnostics.Process.Start(url);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Links Saver Windows";
            dataGridView1.RowTemplate.Height = 35;
        
            var parser = new FileIniDataParser();

            // This load the INI file, reads the data contained in the file, 
            // and parses that data
        
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "Lesson name";
            dataGridView1.Columns[1].Name = "Lesson link";

        
            IniData data = parser.ReadFile("lessons.ini");
            //Iterate through all the sections
            foreach (SectionData section in data.Sections)
            {


                //Iterate through all the keys in the current section
                //printing the values
                foreach (KeyData key in section.Keys)


                    dataGridView1.Rows.Add(section.SectionName, key.Value);

            }
            DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            {
                button.Name = "Join";
                button.HeaderText = "Join";
                button.Text = "Join";
                button.UseColumnTextForButtonValue = true; //dont forget this line
                dataGridView1.Columns.Add(button);
                dataGridView1.CellClick += dataGridViewSoftware_CellClick;
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AllowUserToResizeColumns = true;


        }

        private void dataGridViewSoftware_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Join"].Index)
            {
                //Do something with your button.
                var val = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex-1].Value;
                GoToSite((string)val);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
