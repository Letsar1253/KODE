using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Net;


namespace test1
{
    public partial class Form1 : Form
    {
        private ParseJSON DataJSON;
        public Form1()
        {
            InitializeComponent();
            InitializeDataJSON();
            InitializeListView();
            InitializationPanelPics();
            InitializationMainTxt();

        }
        //парс json
        private void InitializeDataJSON()
        {
            DataJSON = JsonConvert.DeserializeObject<ParseJSON>(File.ReadAllText("Recipes.json"));
        }
        //скачивание картнок из интернета по ссылке
        static public void SaveImage(string urlImage, string filename, System.Drawing.Imaging.ImageFormat format)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(urlImage);
            request.Method = "GET";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.99 Safari/537.36";
            String test = String.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream dataStream = response.GetResponseStream())
                {
                    using (var output = new FileStream(filename, FileMode.Create, FileAccess.Write))
                    {
                        dataStream.CopyTo(output);
                        output.Dispose();
                    }
                }
            }
        }
        //описание таблицы
        private void InitializeListView()
        {
            this.ListView1.BackColor = System.Drawing.SystemColors.Control;
            this.ListView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ListView1.Location = new System.Drawing.Point(0, 0);
            this.ListView1.Name = "ListView1";
            this.ListView1.TabIndex = 0;
            this.ListView1.Font = new Font("Tahoma", 12, FontStyle.Bold);
            this.ListView1.View = System.Windows.Forms.View.Details;
            this.ListView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            //создание колонок
            ColumnHeader columnHeader0 = new ColumnHeader();
            columnHeader0.Text = "Image";
            columnHeader0.TextAlign = HorizontalAlignment.Left;
            columnHeader0.Width = 150;

            ColumnHeader columnHeader1 = new ColumnHeader();
            columnHeader1.Text = "Name";
            columnHeader1.TextAlign = HorizontalAlignment.Left;
            columnHeader1.Width = 300;

            ColumnHeader columnHeader2 = new ColumnHeader();
            columnHeader2.Text = "Description";
            columnHeader2.TextAlign = HorizontalAlignment.Center;
            columnHeader2.Width = 500;

            ColumnHeader columnHeader3 = new ColumnHeader();
            columnHeader3.Text = "Difficulty";
            columnHeader3.TextAlign = HorizontalAlignment.Right;
            columnHeader3.Width = 150;

            this.ListView1.Columns.Add(columnHeader0);
            this.ListView1.Columns.Add(columnHeader1);
            this.ListView1.Columns.Add(columnHeader2);
            this.ListView1.Columns.Add(columnHeader3);

            string[] name = new string[this.DataJSON.recipes.Length],
                description = new string[this.DataJSON.recipes.Length],
                instuctions = new string[this.DataJSON.recipes.Length];
            int[] difficulty = new int[this.DataJSON.recipes.Length];
            string[][] images = new string [this.DataJSON.recipes.Length][];
            //инициализация данных из json
            for (int i = 0; i < this.DataJSON.recipes.Length; i++)
            { 
                name[i] = DataJSON.recipes[i].name;
                description[i] = DataJSON.recipes[i].description;
                instuctions[i] = DataJSON.recipes[i].instructions;
                difficulty[i] = DataJSON.recipes[i].difficulty;
                images[i] = DataJSON.recipes[i].images;
            }

            //картинки для таблицы
            string url, a;
            ImageList imageList = new ImageList();
            Image img;
            for (int i = 0; i < this.DataJSON.recipes.Length; i++)
            {
                url = DataJSON.recipes[i].images[0];
                SaveImage(url, "main" + i.ToString() + ".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                a = Directory.GetCurrentDirectory() + @"/main" + i.ToString() + ".jpeg";
                imageList.ImageSize = new Size(150, 150);
                using (var stream = File.OpenRead(a))
                {
                    img = new Bitmap(stream);
                }
                imageList.Images.Add(img);
                File.Delete(a);
            }

            ListView1.SmallImageList = imageList;
            for (int count = 0; count < this.DataJSON.recipes.Length; count++)
            {
                ListViewItem listItem = new ListViewItem(new string[] {"", name[count], description[count], difficulty[count].ToString() });
                listItem.ImageIndex = count;
                ListView1.Items.Add(listItem);
            }         
            this.Controls.Add(ListView1);
        }
        //текстовое поле
        public void InitializationMainTxt()
        {
            this.MainTxt.Location = new Point(624, 12);
            this.MainTxt.Size = new Size(490, 485);
            this.MainTxt.BackColor = System.Drawing.SystemColors.ControlLight;
            this.MainTxt.Multiline = true;
            this.MainTxt.AcceptsTab = true;
            this.MainTxt.WordWrap = true;
            this.MainTxt.ReadOnly = true;
            this.MainTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MainTxt.Visible = false;
            this.MainTxt.Font = new Font("Tahoma", 12, FontStyle.Bold);
        }
        //панель картинок
        public void InitializationPanelPics()
        {
            this.PanelPics.Location = new Point(0, 0);
            this.PanelPics.Size = new Size(615, 560);
            this.PanelPics.Visible = false;
            this.PanelPics.VerticalScroll.Enabled = false;
            this.PanelPics.VerticalScroll.Visible = false;
            this.PanelPics.VerticalScroll.Maximum = 0;
            this.PanelPics.AutoScroll = true;
            this.Controls.Add(PanelPics);
        }
        //событие перехода к подробностям
        private void ListView1_SelectedIndexChanged_UsingItems(object sender, System.EventArgs e)
        {
            this.ListView1.Visible = false;
            this.ButtonBack.Visible = true;
            this.MainTxt.Visible = true;
            this.PanelPics.Visible = true;
            this.MainTxt.Clear();
            //подробности
            ListView.SelectedIndexCollection indeces = this.ListView1.SelectedIndices;
            foreach (int index in indeces)
            {
                //текст для подробностей
                this.MainTxt.AppendText("Name : ", Color.BlueViolet);
                this.MainTxt.AppendText(DataJSON.recipes[index].name + "\r\n" + "\r\n", Color.Black);
                this.MainTxt.AppendText("Difficulty : ", Color.BlueViolet);
                this.MainTxt.AppendText(DataJSON.recipes[index].difficulty + "\r\n" + "\r\n", Color.Black);
                this.MainTxt.AppendText("Description : ", Color.BlueViolet);
                this.MainTxt.AppendText(DataJSON.recipes[index].description + "\r\n" + "\r\n", Color.Black);
                this.MainTxt.AppendText("Instuctions : ", Color.BlueViolet);
                this.MainTxt.AppendText(DataJSON.recipes[index].instructions, Color.Black);
                //картинки для подробностей
                string url, a;
                Image img;
                for (int i = 0; i < DataJSON.recipes[index].images.Length; i++)
                {

                    a = Directory.GetCurrentDirectory() + @"/add" + index.ToString() + "_" + i.ToString() + ".jpeg";
                    if (!File.Exists(a))
                    {
                        url = DataJSON.recipes[index].images[i];
                        SaveImage(url, "add" + index.ToString() + "_" + i.ToString() + ".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    PictureBox pic = new PictureBox();
                    using (var stream = File.OpenRead(a))
                    {
                        img = new Bitmap(stream);
                    }
                    pic.SizeMode = PictureBoxSizeMode.Zoom;
                    switch (DataJSON.recipes[index].images.Length)
                    {
                        case 1:
                            pic.Size = new Size(600, 545);
                            break;
                        case 2:
                            pic.Size = new Size(600, 267);
                            break;
                        default:
                            pic.Size = new Size(294, 267);
                            break;
                    }
                    pic.Location = new Point(12 + 306 * (i / 2), 12 + 279 * (i % 2));
                    pic.Image = img;
                    pic.Visible = true;
                    File.Delete(a);
                    this.PanelPics.Controls.Add(pic);
                }
                this.Controls.Add(PanelPics);
            }
        }
        //удаление картинок с панели
        public void RemoveItemsPanelPics()
        {
            for (int i = 0; i < this.PanelPics.Controls.Count; )
            {
                this.PanelPics.Controls.Remove(this.PanelPics.Controls[i]);
            }
        }
        //событие возврата к таблице
        private void ButtonBack_Click(object sender, EventArgs e)
        {
            RemoveItemsPanelPics();   
            this.ListView1.Visible = true;
            this.ButtonBack.Visible = false;
            this.MainTxt.Visible = false;
            this.PanelPics.Visible = false;
        }
    }

}
