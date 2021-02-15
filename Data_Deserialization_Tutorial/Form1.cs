using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Data_Deserialization_Tutorial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            XmlSerializer serializerXml = new XmlSerializer(typeof(DeveloperXml));

            using (var stringreader = new StringReader(richTextBox1.Text))
            {

              DeveloperXml developerxml = (DeveloperXml)  serializerXml.Deserialize(stringreader);

                richTextBox3.AppendText(developerxml.Id.ToString() + Environment.NewLine);

                richTextBox3.AppendText(developerxml.Name + Environment.NewLine);

                richTextBox3.AppendText(developerxml.Salary.ToString() + Environment.NewLine);

            }




        }

        private void Form1_Load(object sender, EventArgs e)
        {

            #region XML Serialization

            DeveloperXml developerXml = new DeveloperXml()
            {
                Id = 1,
                Name = "John",
                Salary = 2300
            };


            XmlSerializer serializerXml = new XmlSerializer(typeof(DeveloperXml));

            using (var stringwriter = new StringWriter())
            {
                serializerXml.Serialize(stringwriter, developerXml);

                richTextBox1.Text = stringwriter.ToString();
            }


            #endregion


            #region Json Serialization

            DeveloperJson developerJson = new DeveloperJson()
            {
                Id = 1,
                Name = "John",
                Salary = 2300

            };

            JavaScriptSerializer serializerJson = new JavaScriptSerializer();

            richTextBox2.Text = serializerJson.Serialize(developerJson);



            #endregion


            #region HTML region 

            richTextBox5.Text = @"<!DOCTYPE html>
<html>

<p style='color:red'> This is a sample ! </p>
     

     </html>
     " ;






            #endregion


        }

        private void button3_Click(object sender, EventArgs e)
        {

            richTextBox4.Clear();

            JavaScriptSerializer serializerJson = new JavaScriptSerializer();

            DeveloperJson developerJson = serializerJson.Deserialize<DeveloperJson>(richTextBox2.Text);


            richTextBox4.AppendText(developerJson.Id.ToString() + Environment.NewLine);

            richTextBox4.AppendText(developerJson.Name + Environment.NewLine);

            richTextBox4.AppendText(developerJson.Salary.ToString() + Environment.NewLine);


        }

    
        private void button2_Click(object sender, EventArgs e)
        {

           



        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox4.Clear();

            // This will work even if DeveloperJson class does not exist
            //by the power of dynamic keyword ! 

            JavaScriptSerializer serializerJson = new JavaScriptSerializer();

            dynamic developerJson = serializerJson.Deserialize<dynamic>(richTextBox2.Text);

            richTextBox4.AppendText(developerJson["Id"].ToString() + Environment.NewLine);

            richTextBox4.AppendText(developerJson["Name"] + Environment.NewLine);

            richTextBox4.AppendText(developerJson["Salary"].ToString() + Environment.NewLine);


        }




        private void button5_Click(object sender, EventArgs e)
        {

            string page = richTextBox5.Text;

            string start = "red'>";

            int start_index = page.IndexOf(start);

            string end = "</p>";

            int end_index = page.IndexOf(end);

            string target = page.Substring(start_index, end_index - start_index)
                .Replace(start,"");

            richTextBox6.Text = target;

        }


        private static HttpClient client = new HttpClient();

        private async  void button2_Click_1(object sender, EventArgs e)
        {

            richTextBox7.Clear();
            richTextBox8.Clear();

            try
            {

           // install xampp and put the sample file inside htdocs folder  and start xampp before sending the request

                string page = await client.GetStringAsync("http://localhost/sample.json");

                richTextBox7.Text = page;

                JavaScriptSerializer serializerJson = new JavaScriptSerializer();

                dynamic developerJson = serializerJson.Deserialize<dynamic>(page);

                richTextBox8.AppendText(developerJson["Id"].ToString() + Environment.NewLine);

                richTextBox8.AppendText(developerJson["Name"] + Environment.NewLine);

                richTextBox8.AppendText(developerJson["Salary"].ToString() + Environment.NewLine);

                
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private async  void button6_Click(object sender, EventArgs e)
        {
            richTextBox7.Clear();
            richTextBox8.Clear();


            try
            {

            // install xampp and put the sample file inside htdocs folder  and start xampp before sending the request

                string page = await client.GetStringAsync("http://localhost/sample.xml");

                richTextBox7.Text = page;


                XmlSerializer serializerXml = new XmlSerializer(typeof(DeveloperXml));

                using (var stringreader = new StringReader(page))
                {

                    DeveloperXml developerxml = (DeveloperXml)serializerXml.Deserialize(stringreader);

                    richTextBox8.AppendText(developerxml.Id.ToString() + Environment.NewLine);

                    richTextBox8.AppendText(developerxml.Name + Environment.NewLine);

                    richTextBox8.AppendText(developerxml.Salary.ToString() + Environment.NewLine);

                }


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }

        private async  void button7_Click(object sender, EventArgs e)
        {

            richTextBox7.Clear();
            richTextBox8.Clear();

            try
            {

            // install xampp and put the sample file inside htdocs folder  and start xampp before sending the request

                string page = await client.GetStringAsync("http://localhost/sample.html");

                richTextBox7.Text = page;

              
                string start = "red'>";

                int start_index = page.IndexOf(start);

                string end = "</p>";

                int end_index = page.IndexOf(end);

                string target = page.Substring(start_index, end_index - start_index)
                    .Replace(start, "");

                richTextBox8.Text = target;


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }


    }
}
