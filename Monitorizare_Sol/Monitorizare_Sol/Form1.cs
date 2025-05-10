using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using Microsoft.Data.SqlClient;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Net.Mail;
using System.Net;
using Microsoft.VisualBasic;


namespace Login
{


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            panelLogin.Visible = true;
            panelMonitorizare.Visible = false;
            panelLogin.BringToFront();

            panelLogin.Visible = true;
            panelMonitorizare.Visible = false;

            textPass.PasswordChar = '•';
            this.textUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textUser_KeyDown);
            this.textPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textPass_KeyDown);
            ck_b_shpass.Checked = false;
            link_fpass.LinkClicked += new LinkLabelLinkClickedEventHandler(link_fpass_LinkClicked);
            button_Conectare.Click += new EventHandler(button_Conectare_Click);
            button_salvare.Click += new EventHandler(button_salvare_Click);
            button_verificare.Click += new EventHandler(button_verificare_Click);
            button_refresh.Click += new EventHandler(button_refresh_Click);
            button_Export.Click += new EventHandler(button_Export_Click);

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void Login()
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Pagina_Login;Integrated Security=True;TrustServerCertificate=True"))
                {
                    con.Open();
                    string query = "SELECT COUNT(*) FROM login WHERE Username=@Username AND Password=@Password";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Username", textUser.Text);
                    cmd.Parameters.AddWithValue("@Password", textPass.Text);

                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Logarea a fost făcută cu succes", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Ascunde login, arată monitorizare
                        panelLogin.Visible = false;
                        panelMonitorizare.Visible = true;
                        panelMonitorizare.BringToFront();

                        // Inițializează porturile COM
                        comboBox1.Items.Clear();
                        comboBox1.Items.AddRange(SerialPort.GetPortNames());
                    }
                    else
                    {
                        MessageBox.Show("Username sau parolă incorecte", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textPass.Clear();
                        textUser.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la conectare: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void textPass_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Login();
            }
        }

        private void textUser_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                textPass.Focus();
            }
        }

        private void b_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ck_b_shpass_CheckedChanged(object sender, EventArgs e)
        {
            textPass.PasswordChar = ck_b_shpass.Checked ? '\0' : '•';
        }

        private void link_fpass_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
        {
            string username = Microsoft.VisualBasic.Interaction.InputBox("Introdu numele de utilizator pentru a-ți recupera parola.", "Recuperare parolă", "");

            if (!string.IsNullOrEmpty(username))
            {
                try
                {
                    using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Pagina_Login;Integrated Security=True;TrustServerCertificate=True"))
                    {
                        con.Open();

                        string query = "SELECT Password, Email FROM login WHERE Username = @Username";
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@Username", username);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string? password = reader["Password"]?.ToString();
                                    string? email = reader["Email"]?.ToString();

                                    if (!string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(email))
                                    {
                                        TrimiteEmailCuParola(email, username, password);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Parola sau emailul nu sunt disponibile pentru acest utilizator.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Utilizatorul nu a fost găsit.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la conectarea cu baza de date: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Te rog introdu un nume de utilizator.", "Atenție", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TrimiteEmailCuParola(string destinatar, string utilizator, string parola)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("vizireanuanamaria0@gmail.com");
                mail.To.Add(destinatar);
                mail.Subject = "Recuperare parolă";
                mail.Body = $"Salut, {utilizator}!\n\nParola ta este: {parola}\n\nTe rugăm să o schimbi dacă ai suspiciuni de securitate.";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("vizireanuanamaria0@gmail.com", "dxgh jlfc nonh ytlu"); // aici pui parola generată
                smtp.EnableSsl = true;
                smtp.Send(mail);

                MessageBox.Show("Emailul a fost trimis cu succes la adresa: " + destinatar, "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la trimiterea emailului: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void b_login_Click(object sender, EventArgs e)
        {

        }

        private void textPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void textUser_TextChanged_1(object sender, EventArgs e)
        {

        }

        SerialPort serialPort = new SerialPort();


        private void label_subtitlu2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Titlu_Click(object sender, EventArgs e)
        {

        }

        private void label_Port_Click(object sender, EventArgs e)
        {

        }

        private void button_Conectare_Click(object? sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedItem == null)
                {
                    MessageBox.Show("Vă rugăm să selectați un port din listă.");
                    return;
                }

                serialPort.PortName = comboBox1.SelectedItem.ToString(); // Portul selectat, ex: COM3
                serialPort.BaudRate = 9600;
                serialPort.DataReceived += SerialPort_DataReceived;
                serialPort.Open();

                MessageBox.Show("Conectat cu succes!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la conectare: " + ex.Message);
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string linie = serialPort.ReadLine(); // ex: Hidratare:459;Temperatura:33;Umiditate:20

                // Ignoră orice alt text care nu începe corect
                if (!linie.Contains("Hidratare") || !linie.Contains("Temperatura") || !linie.Contains("Umiditate"))
                    return;

                string[] parti = linie.Split(';');

                string hidratare = "", temperatura = "", umiditate = "";

                foreach (string parte in parti)
                {
                    if (parte.StartsWith("Hidratare:"))
                        hidratare = parte.Replace("Hidratare:", "").Trim();
                    if (parte.StartsWith("Temperatura:"))
                        temperatura = parte.Replace("Temperatura:", "").Trim();
                    if (parte.StartsWith("Umiditate:"))
                        umiditate = parte.Replace("Umiditate:", "").Trim();
                }

                // Actualizează UI-ul
                this.BeginInvoke(new Action(() =>
                {
                    label_temp.Text = temperatura + " °C";
                    label_umiditate.Text = umiditate + " %";
                    label_niv_hidratare.Text = hidratare;
                }));
            }
            catch (Exception) { }
        }

        private void label_subtitlu1_Click(object sender, EventArgs e)
        {

        }

        private void textBox_Temp_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_temp_Click(object sender, EventArgs e)
        {

        }

        private void textBox_Umiditate_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_umiditate_Click(object sender, EventArgs e)
        {

        }

        private void textBox_niv_hidratare_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_niv_hidratare_Click(object sender, EventArgs e)
        {

        }

        private void button_refresh_Click(object? sender, EventArgs e)
        {
            try
            {
                // 1. Resetarea valorilor etichetelor la starea inițială
                label_temp.Text = " ";
                label_umiditate.Text = " ";
                label_niv_hidratare.Text = " ";
                label1.Text = "";  // Șterge plantele recomandate

                // 2. Verifică dacă portul serial este deschis și trimite comanda pentru a obține date noi
                if (serialPort.IsOpen)
                {
                    serialPort.WriteLine("GET_DATA");  // Sau orice comandă corespunzătoare senzorului
                }
                else
                {
                    MessageBox.Show("Portul serial nu este conectat.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la actualizarea datelor: " + ex.Message);
            }
        }


        private void button_salvare_Click(object? sender, EventArgs e)
        {
            try
            {
                // Folosim direct textul din label-uri (care conține unități)
                string temperatura = label_temp.Text; // ex: "29 °C"
                string umiditate = label_umiditate.Text; // ex: "45 %"
                string hidratare = label_niv_hidratare.Text;

                DateTime now = DateTime.Now;
                DateTime data = now.Date;
                TimeSpan ora = now.TimeOfDay;

                using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Masuratori;Integrated Security=True;TrustServerCertificate=True"))
                {
                    con.Open();

                    string query = @"
                        INSERT INTO date_masurate (Data_adaugare, Ora_adaugare, Temperatura, Umiditate, Nivel_umiditate)
                        VALUES (@data, @ora, @temperatura, @umiditate, @hidratare)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@data", data);
                        cmd.Parameters.AddWithValue("@ora", ora);
                        cmd.Parameters.AddWithValue("@temperatura", temperatura);
                        cmd.Parameters.AddWithValue("@umiditate", umiditate);
                        cmd.Parameters.AddWithValue("@hidratare", hidratare);

                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                            MessageBox.Show("Date salvate cu succes în baza de date Masuratori!");
                        else
                            MessageBox.Show("Salvarea nu a reușit.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la salvare: " + ex.Message);
            }
        }



        private void button_verificare_Click(object? sender, EventArgs e)
        {
            try
            {
                // Extrage valorile măsurate și elimină unitățile de măsură
                float temperatura = float.Parse(label_temp.Text.Replace("°C", "").Trim());
                float umiditate = float.Parse(label_umiditate.Text.Replace("%", "").Trim());
                float hidratare = float.Parse(label_niv_hidratare.Text.Trim());

                using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=MonitorizareSol;Integrated Security=True;TrustServerCertificate=True"))
                {
                    con.Open();

                    string query = @"
                        SELECT P.Nume
                        FROM Recomandare R
                        JOIN Plante P ON R.Cod_P = P.Cod_P
                        JOIN Tipuri_Plante T ON P.Cod_T = T.Cod_T
                        WHERE 
                            @temperatura BETWEEN TRY_CAST(REPLACE(REPLACE(R.Temp_min, '°C', ''), ' ', '') AS FLOAT) 
                                           AND TRY_CAST(REPLACE(REPLACE(R.Temp_max, '°C', ''), ' ', '') AS FLOAT)
                            AND @umiditate BETWEEN TRY_CAST(REPLACE(REPLACE(R.Umiditate_min, '%', ''), ' ', '') AS FLOAT) 
                                              AND TRY_CAST(REPLACE(REPLACE(R.Umiditate_max, '%', ''), ' ', '') AS FLOAT)
                            AND @hidratare BETWEEN R.Nivel_umid_min AND R.Nivel_umid_max
                        ORDER BY P.Nume";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@temperatura", temperatura);
                        cmd.Parameters.AddWithValue("@umiditate", umiditate);
                        cmd.Parameters.AddWithValue("@hidratare", hidratare);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<string> planteRecomandate = new List<string>();

                            while (reader.Read())
                            {
                                var nume = reader["Nume"]?.ToString();
                                if (!string.IsNullOrEmpty(nume))
                                {
                                    planteRecomandate.Add(nume);
                                }
                            }

                            if (planteRecomandate.Count > 0)
                            {
                                label1.Text = "Plante recomandate:\n" + string.Join("\n", planteRecomandate);
                            }
                            else
                            {
                                label1.Text = "Nicio plantă nu se potrivește cu condițiile măsurate.";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la verificare: " + ex.Message + "\n" + ex.StackTrace);
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button_Export_Click(object? sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=MonitorizareSol;Integrated Security=True;TrustServerCertificate=True"))
                {
                    con.Open();

                    string query = @"
                            SELECT P.Nume, R.Descriere
                            FROM Recomandare R
                            JOIN Plante P ON R.Cod_P = P.Cod_P
                            JOIN Tipuri_Plante T ON P.Cod_T = T.Cod_T
                            WHERE 
                                @temperatura BETWEEN TRY_CAST(REPLACE(REPLACE(R.Temp_min, '°C', ''), ' ', '') AS FLOAT) 
                                               AND TRY_CAST(REPLACE(REPLACE(R.Temp_max, '°C', ''), ' ', '') AS FLOAT)
                                AND @umiditate BETWEEN TRY_CAST(REPLACE(REPLACE(R.Umiditate_min, '%', ''), ' ', '') AS FLOAT) 
                                                  AND TRY_CAST(REPLACE(REPLACE(R.Umiditate_max, '%', ''), ' ', '') AS FLOAT)
                                AND @hidratare BETWEEN R.Nivel_umid_min AND R.Nivel_umid_max
                            ORDER BY P.Nume";

                    float temperatura = float.Parse(label_temp.Text.Replace("°C", "").Trim());
                    float umiditate = float.Parse(label_umiditate.Text.Replace("%", "").Trim());
                    float hidratare = float.Parse(label_niv_hidratare.Text.Trim());

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@temperatura", temperatura);
                        cmd.Parameters.AddWithValue("@umiditate", umiditate);
                        cmd.Parameters.AddWithValue("@hidratare", hidratare);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            SaveFileDialog saveDialog = new SaveFileDialog();
                            saveDialog.Filter = "PDF files (*.pdf)|*.pdf";
                            saveDialog.FileName = "RecomandariPlante.pdf";

                            if (saveDialog.ShowDialog() != DialogResult.OK)
                                return;

                            string path = saveDialog.FileName;

                            Document document = new Document(PageSize.A4, 40, 40, 40, 40);
                            PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));
                            document.Open();

                            DateTime now = DateTime.Now;
                            string data = now.ToString("dd-MM-yyyy"); // Formatul datei: zi-luna-an
                            string ora = now.ToString("HH:mm:ss"); // Formatul orei: ora:minut:secundă


                            // Încarcă fontul Arial din sistem (de obicei se găsește în Windows Fonts)
                            string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                            BaseFont arialBase = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                            iTextSharp.text.Font titluFont = new iTextSharp.text.Font(arialBase, 30, iTextSharp.text.Font.BOLD, BaseColor.DARK_GRAY);
                            iTextSharp.text.Font infoFont = new iTextSharp.text.Font(arialBase, 11, iTextSharp.text.Font.NORMAL);
                            iTextSharp.text.Font subtitluFont = new iTextSharp.text.Font(arialBase, 20, iTextSharp.text.Font.BOLD, BaseColor.DARK_GRAY);
                            iTextSharp.text.Font headerFont = new iTextSharp.text.Font(arialBase, 12, iTextSharp.text.Font.BOLD);
                            iTextSharp.text.Font notaFont = new iTextSharp.text.Font(arialBase, 10, iTextSharp.text.Font.ITALIC, BaseColor.LIGHT_GRAY);
                            iTextSharp.text.Font data_oraFont = new iTextSharp.text.Font(arialBase, 11, iTextSharp.text.Font.BOLD);

                            // Titlu
                            Paragraph titlu = new Paragraph("Raport de Monitorizare a Calității Solului", titluFont);

                            titlu.Alignment = Element.ALIGN_CENTER;
                            titlu.SpacingAfter = 25;
                            document.Add(titlu);

                            // Informații despre condiții
                            document.Add(new Paragraph("Acest raport prezintă analiza condițiilor actuale ale solului, realizată prin intermediul sistemului de monitorizare automată. Informațiile au fost colectate în mod automat și sunt utile pentru evaluarea adecvării mediului pentru creșterea plantelor.", infoFont));
                            document.Add(new Paragraph(" "));

                            document.Add(new Paragraph("_________________________________", infoFont));
                            document.Add(new Paragraph("Data măsurării: " + data, infoFont));
                            document.Add(new Paragraph("Ora măsurării: " + ora, infoFont));
                            document.Add(new Paragraph("_________________________________", infoFont));

                            document.Add(new Paragraph(" "));

                            document.Add(new Paragraph("Condiții Măsurate:", subtitluFont));
                            document.Add(new Paragraph(" "));

                            document.Add(new Paragraph("• Temperatura: " + temperatura + " °C", infoFont));
                            document.Add(new Paragraph("• Umiditatea: " + umiditate + " %", infoFont));
                            document.Add(new Paragraph("• Nivel de hidratare al solului: " + hidratare, infoFont));
                            document.Add(new Paragraph(" "));

                            document.Add(new Paragraph("Analiză și Recomandări:", subtitluFont));
                            document.Add(new Paragraph(" "));

                            document.Add(new Paragraph("Pe baza valorilor înregistrate, sistemul a identificat următoarele plante care se dezvoltă în mod optim în aceste condiții. Recomandările sunt formulate în funcție de intervalele de temperatură, umiditate și nivel de umiditate specifice fiecărei plante.", infoFont));
                            document.Add(new Paragraph(" "));



                            PdfPTable table = new PdfPTable(2);
                            table.WidthPercentage = 100;
                            table.SetWidths(new float[] { 1f, 3f });
                            table.SpacingBefore = 10;

                            // Celule antet
                            PdfPCell header1 = new PdfPCell(new Phrase("Nume Plantă", headerFont));
                            header1.BackgroundColor = BaseColor.LIGHT_GRAY;
                            header1.HorizontalAlignment = Element.ALIGN_CENTER;
                            header1.Padding = 5;

                            PdfPCell header2 = new PdfPCell(new Phrase("Descriere", headerFont));
                            header2.BackgroundColor = BaseColor.LIGHT_GRAY;
                            header2.HorizontalAlignment = Element.ALIGN_CENTER;
                            header2.Padding = 5;

                            table.AddCell(header1);
                            table.AddCell(header2);

                            bool existaDate = false;

                            while (reader.Read())
                            {
                                existaDate = true;

                                PdfPCell numeCell = new PdfPCell(new Phrase(reader["Nume"].ToString(), infoFont));
                                numeCell.Padding = 5;
                                PdfPCell descriereCell = new PdfPCell(new Phrase(reader["Descriere"].ToString(), infoFont));
                                descriereCell.Padding = 5;

                                table.AddCell(numeCell);
                                table.AddCell(descriereCell);
                            }

                            if (existaDate)
                            {
                                document.Add(table);

                                // Notă de subsol
                                document.Add(new Paragraph(" "));
                                document.Add(new Paragraph("___________________________________________________________________________________________", notaFont));

                                Paragraph nota = new Paragraph(
                                    "Notă: Recomandările sunt orientative și pot fi influențate de factori suplimentari precum tipul de sol, expunerea la lumină sau calitatea apei.",
                                    notaFont
                                );
                                nota.SpacingBefore = 20;
                                nota.Alignment = Element.ALIGN_JUSTIFIED;
                                document.Add(nota);


                                MessageBox.Show("PDF generat cu succes!");
                            }
                            else
                            {
                                document.Add(new Paragraph("Nu există plante recomandate pentru condițiile actuale.", infoFont));
                                MessageBox.Show("Nu s-au găsit plante pentru export.");
                            }

                            document.Close();

                            System.Diagnostics.Process.Start("explorer.exe", path);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la exportul PDF: " + ex.Message);
            }
        }

        private void panelMonitorizare_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelLogin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void panelLogin_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
