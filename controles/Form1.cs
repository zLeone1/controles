using System.Windows.Forms;

namespace controles
{
    public partial class Form1 : Form
    {
        bool clicked = false;

        public Form1()
        {
            InitializeComponent();


            linkLabel1.Links.Add(0, 25, "https://tecmonclova.com/sitio/");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "cmd",
                    Arguments = $"/c start {e.Link.LinkData}",
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                System.Diagnostics.Process.Start(psi);
                clicked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el enlace: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (checkBox1.Checked == false)
            {
                textBox1.Text = "you have to check our page first!";
                return;
            }
            textBox1.Text = "Thank you";
            numericUpDown1.Value++;
            if (numericUpDown1.Value > 10)
            {
                textBox1.Text = "Thank you for all your likes we love you!!!!!!";
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (clicked == false)
            {
                textBox1.Text = "you didn't click it, please do!";
                checkBox1.Checked = false;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                numericUpDown1.Value = 0;
                textBox1.Text = "you have to check our page first!";
                return;
            }

        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text.Length == 10)
            {
                try
                {
                    DateTime date = Convert.ToDateTime(maskedTextBox1.Text);

                    TimeSpan datedifference = monthCalendar1.TodayDate - date;
                    textBox2.Text = $" Days between \n {date.ToShortDateString()} and \n {monthCalendar1.TodayDate.ToShortDateString()} is: {datedifference.Days}";

                }
                catch
                {
                    textBox2.Text = "date format incorrect";
                }

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;

            for (int i = 0; i <= progressBar1.Maximum; i++)
            {
                progressBar1.Value = i;

                Thread.Sleep(10);
            }

            btnStart.Enabled = true;
        }
    }
}