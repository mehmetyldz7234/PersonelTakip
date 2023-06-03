using System.Windows.Forms;

namespace PersonelTakip
{
    public partial class Form1 : Form
    {
        crud_op crud = new crud_op();

        public Form1()
        {


            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            crud.Add(textBox2.Text, textBox3.Text, Convert.ToInt16(textBox4.Text), Convert.ToInt16(textBox5.Text), textBox6.Text, textBox7.Text, textBox8.Text);
            crud.List(dataGridView1);

        }

        private void Form1_Load(object sender, EventArgs e)
        {


            // Sütunlarý tanýmla
            dataGridView1.Columns.Add("personel_id", "ID");
            dataGridView1.Columns.Add("personel_name", "Name");
            dataGridView1.Columns.Add("personel_surname", "Surname");
            dataGridView1.Columns.Add("personel_yevmiye", "Yevmiye");
            dataGridView1.Columns.Add("personel_mesai", "Mesai");
            dataGridView1.Columns.Add("personel_telno", "Tel No");
            dataGridView1.Columns.Add("personel_eposta", "Eposta");
            dataGridView1.Columns.Add("personel_alan", "Alan");

            crud.List(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            crud.Update(Convert.ToInt16(textBox1.Text), textBox2.Text, textBox3.Text, Convert.ToInt16(textBox4.Text), Convert.ToInt16(textBox5.Text), textBox6.Text, textBox7.Text, textBox8.Text);
            crud.List(dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            crud.Delete(Convert.ToInt16(textBox1.Text));
            crud.List(dataGridView1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            crud.List(dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0) // Sadece satýr hücrelerini kontrol et
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                // Ýlgili hücrelerin deðerlerini TextBox kontrollerine yazdýr
                textBox1.Text = row.Cells["personel_id"].Value.ToString();
                textBox2.Text = row.Cells["personel_name"].Value.ToString();
                textBox3.Text = row.Cells["personel_surname"].Value.ToString();
                textBox4.Text = row.Cells["personel_yevmiye"].Value.ToString();
                textBox5.Text = row.Cells["personel_mesai"].Value.ToString();
                textBox6.Text = row.Cells["personel_telno"].Value.ToString();
                textBox7.Text = row.Cells["personel_eposta"].Value.ToString();
                textBox8.Text = row.Cells["personel_alan"].Value.ToString();
                // Diðer TextBox kontrollerinin deðerlerini burada güncelleyin...
            }
        }

        // DataGridView kontrolündeki hücreye týklandýðýnda çalýþacak olay

    }
}