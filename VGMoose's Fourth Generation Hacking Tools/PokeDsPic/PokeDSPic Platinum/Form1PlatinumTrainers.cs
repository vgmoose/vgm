namespace ImageConverter
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Resources;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class Form1 : Form
    {
        private ComboBox comboBox1;
        private Bitmap m_bitmap;
        private Button m_btnSaveAs;
        private int m_height0;
        private PictureBox m_pictureBox;
        private int m_width0;
        private MainMenu mainMenu1;
        private MenuItem menuAutomatch;
        private MenuItem menuItem1;
        private MenuItem menuItem10;
        private MenuItem menuItem11;
        private MenuItem menuItem12;
        private MenuItem menuItem13;
        private MenuItem menuItem2;
        private MenuItem menuItem3;
        private MenuItem menuItem4;
        private MenuItem menuItem5;
        private MenuItem menuItem6;
        private MenuItem menuItem7;
        private MenuItem menuItem8;
        private MenuItem menuItem9;
        private NarcReader nr;
        private Button OpenPng;
        private Rectangle rect;

        public Form1()
        {
            this.InitializeComponent();
            this.m_bitmap = null;
            this.m_width0 = this.m_pictureBox.Size.Width;
            this.m_height0 = this.m_pictureBox.Size.Height;
        }

        protected void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "*.*|*.*";
            string filter = dialog.Filter;
            dialog.Title = "Bin File";
            dialog.ShowHelp = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read);
                this.MakeImage(fs);
                this.m_btnSaveAs.Enabled = true;
            }
        }

        protected void btnSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Save Image As";
            dialog.OverwritePrompt = true;
            dialog.CheckPathExists = true;
            dialog.Filter = "*.png|*.png";
            dialog.ShowHelp = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = dialog.FileName;
                this.m_bitmap.Save(fileName, ImageFormat.Png);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.comboBox1.Items.IndexOf(this.comboBox1.Text);
            if (this.nr.fe[index].Size == 0x1930)
            {
                this.nr.OpenEntry(index);
                this.MakeImage(this.nr.fs);
                this.nr.Close();
                this.m_btnSaveAs.Enabled = true;
                if (this.menuAutomatch.Checked)
                {
                    for (int i = 0; i < 20; i++)
                    {
                        if (this.nr.fe[index - i].Size == 0x228)
                        {
                            this.nr.OpenEntry(index - i);
                            this.SetPal(this.nr.fs);
                            this.nr.Close();
                            break;
                        }
                    }
                }
            }
            /*if (this.nr.fe[index].Size == 0x228)
            {
                this.nr.OpenEntry(index);
                this.SetPal(this.nr.fs);
                this.nr.Close();
            }*/
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    this.m_pictureBox.Dispose();
                    this.m_btnSaveAs.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        private void InitializeComponent()
        {
            ResourceManager manager = new ResourceManager(typeof(Form1));
            this.m_pictureBox = new PictureBox();
            this.m_btnSaveAs = new Button();
            this.OpenPng = new Button();
            this.mainMenu1 = new MainMenu();
            this.menuItem1 = new MenuItem();
            this.menuItem2 = new MenuItem();
            this.menuItem8 = new MenuItem();
            this.menuItem11 = new MenuItem();
            this.menuItem12 = new MenuItem();
            this.menuItem9 = new MenuItem();
            this.menuAutomatch = new MenuItem();
            this.menuItem3 = new MenuItem();
            this.menuItem4 = new MenuItem();
            this.menuItem5 = new MenuItem();
            this.menuItem6 = new MenuItem();
            this.menuItem7 = new MenuItem();
            this.menuItem10 = new MenuItem();
            this.menuItem13 = new MenuItem();
            this.comboBox1 = new ComboBox();
            base.SuspendLayout();
            this.m_pictureBox.BackColor = SystemColors.ControlDark;
            this.m_pictureBox.BorderStyle = BorderStyle.Fixed3D;
            this.m_pictureBox.Location = new Point(12, 0x10);
            this.m_pictureBox.Name = "m_pictureBox";
            this.m_pictureBox.Size = new Size(320, 160);
            this.m_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            this.m_pictureBox.TabIndex = 2;
            this.m_pictureBox.TabStop = false;
            this.m_btnSaveAs.Enabled = false;
            this.m_btnSaveAs.Location = new Point(0x100, 0xb8);
            this.m_btnSaveAs.Name = "m_btnSaveAs";
            this.m_btnSaveAs.Size = new Size(0x41, 0x19);
            this.m_btnSaveAs.TabIndex = 1;
            this.m_btnSaveAs.Text = "SavePng..";
            this.m_btnSaveAs.Click += new EventHandler(this.btnSaveAs_Click);
            this.OpenPng.Location = new Point(0xb8, 0xb8);
            this.OpenPng.Name = "OpenPng";
            this.OpenPng.Size = new Size(0x44, 0x19);
            this.OpenPng.TabIndex = 3;
            this.OpenPng.Text = "OpenPng..";
            this.OpenPng.Click += new EventHandler(this.OpenPng_Click);
            this.mainMenu1.MenuItems.AddRange(new MenuItem[] { this.menuItem1, this.menuItem9, this.menuItem3, this.menuItem10 });
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new MenuItem[] { this.menuItem2, this.menuItem8, this.menuItem11, this.menuItem12 });
            this.menuItem1.Text = "&File";
            this.menuItem2.Index = 0;
            this.menuItem2.Text = "&Open narc...";
            this.menuItem2.Click += new EventHandler(this.menuItem2_Click);
            this.menuItem8.Index = 1;
            this.menuItem8.Text = "&Write to narc...";
            this.menuItem8.Click += new EventHandler(this.menuItem8_Click);
            this.menuItem11.Index = 2;
            this.menuItem11.Text = "Open&Png...";
            this.menuItem11.Click += new EventHandler(this.OpenPng_Click);
            this.menuItem12.Index = 3;
            this.menuItem12.Text = "&SavePng...";
            this.menuItem12.Click += new EventHandler(this.btnSaveAs_Click);
            this.menuItem9.Index = 1;
            this.menuItem9.MenuItems.AddRange(new MenuItem[] { this.menuAutomatch });
            this.menuItem9.Text = "&Options";
            this.menuAutomatch.Checked = true;
            this.menuAutomatch.Index = 0;
            this.menuAutomatch.Text = "Auto &match Pal";
            this.menuAutomatch.Click += new EventHandler(this.menuAutomatch_Click);
            this.menuItem3.Index = 2;
            this.menuItem3.MenuItems.AddRange(new MenuItem[] { this.menuItem4, this.menuItem5, this.menuItem6, this.menuItem7 });
            this.menuItem3.Text = "&Expert";
            this.menuItem4.Index = 0;
            this.menuItem4.Text = "&Open Direct";
            this.menuItem4.Click += new EventHandler(this.btnOpen_Click);
            this.menuItem5.Index = 1;
            this.menuItem5.Text = "Open &Pal Direct";
            this.menuItem5.Click += new EventHandler(this.OpenPal_Click);
            this.menuItem6.Index = 2;
            this.menuItem6.Text = "&Save Direct";
            this.menuItem6.Click += new EventHandler(this.SaveBinary_Click);
            this.menuItem7.Index = 3;
            this.menuItem7.Text = "S&ave Pal Direct";
            this.menuItem7.Click += new EventHandler(this.menuItem7_Click);
            this.menuItem10.Index = 3;
            this.menuItem10.MenuItems.AddRange(new MenuItem[] { this.menuItem13 });
            this.menuItem10.Text = "?";
            this.menuItem13.Index = 0;
            this.menuItem13.Text = "About";
            this.menuItem13.Click += new EventHandler(this.menuItem13_Click);
            this.comboBox1.DropDownWidth = 0xd0;
            this.comboBox1.Location = new Point(12, 0xb8);
            this.comboBox1.MaxDropDownItems = 0x10;
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new Size(160, 0x15);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new EventHandler(this.comboBox1_SelectedIndexChanged);
            this.AutoScaleBaseSize = new Size(5, 13);
            base.ClientSize = new Size(0x15a, 0xd7);
            base.Controls.Add(this.comboBox1);
            base.Controls.Add(this.OpenPng);
            base.Controls.Add(this.m_pictureBox);
            base.Controls.Add(this.m_btnSaveAs);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            //base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.Menu = this.mainMenu1;
            base.Name = "Form1";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Pokemon Ds/Pic Platinum Trainers";
            base.ResumeLayout(false);
        }

        [STAThread]
        public static void Main(string[] args)
        {
            Application.Run(new Form1());
        }

        private void MakeImage(FileStream fs)
        {
            fs.Seek(0x30L, SeekOrigin.Current);
            BinaryReader reader = new BinaryReader(fs);
            ushort[] numArray = new ushort[0xc80];
            for (int i = 0; i < 0xc80; i++)
            {
                numArray[i] = reader.ReadUInt16();
            }
            uint num = numArray[0x0];
            for (int j = 0; j <0xc80; j++)
            {
                ushort[] numArray2;
                IntPtr ptr2;
                (numArray2 = numArray)[(int) (ptr2 = (IntPtr) j)] = (ushort) (numArray2[(int) ptr2]^ ((ushort) (num & 0xffff)));
                num *= 0x41c64e6d;
                num += 0x6073;
            }
            this.m_bitmap = new Bitmap(160, 80, PixelFormat.Format8bppIndexed);
            this.rect = new Rectangle(0, 0, 160, 80);
            byte[] source = new byte[0x3200];
            for (int k = 0; k < 0xc80; k++)
            {
                source[k * 4] = (byte) (numArray[k] & 15);
                source[(k * 4) + 1] = (byte) ((numArray[k] >> 4) & 15);
                source[(k * 4) + 2] = (byte) ((numArray[k] >> 8) & 15);
                source[(k * 4) + 3] = (byte) ((numArray[k] >> 12) & 15);
            }
            BitmapData bitmapdata = this.m_bitmap.LockBits(this.rect, ImageLockMode.WriteOnly, this.m_bitmap.PixelFormat);
            IntPtr destination = bitmapdata.Scan0;
            Marshal.Copy(source, 0, destination, 0x3200);
            this.m_bitmap.UnlockBits(bitmapdata);
            Bitmap bitmap = new Bitmap(1, 1, PixelFormat.Format4bppIndexed);

            ColorPalette palette = bitmap.Palette;
            for (int m = 0; m <0x10 ; m++)
            {
                palette.Entries[m] = Color.FromArgb(m << 4, m << 4, m << 4);
            }
            this.m_bitmap.Palette = palette;
            this.m_pictureBox.Image = this.m_bitmap;
        }

        private void menuAutomatch_Click(object sender, EventArgs e)
        {
            this.menuAutomatch.Checked = !this.menuAutomatch.Checked;
        }

        private void menuItem13_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ds/Pic Platinum Trainers, modified version by SCV\n Original Ds/Pic (C) 2007 loadingNOW", "Info");
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "*.narc|*.narc";
            string filter = dialog.Filter;
            dialog.Title = "Open narc file";
            this.comboBox1.Items.Clear();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.nr = new NarcReader(dialog.FileName);
                for (int i = 0; i < this.nr.Entrys; i++)
                {
                    this.comboBox1.Items.Add(string.Format("Item{0} ({1:X})", i, this.nr.fe[i].Size));
                }
            }
        }

        private void menuItem7_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "*.bin|*.bin";
            dialog.OverwritePrompt = true;
            string filter = dialog.Filter;
            dialog.Title = "Save Pal File";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(dialog.FileName, FileMode.Create, FileAccess.Write);
                this.SavePal(fs);
                fs.Close();
            }
        }

        private void menuItem8_Click(object sender, EventArgs e)
        {
            int index = this.comboBox1.Items.IndexOf(this.comboBox1.Text);
            if (this.nr.fe[index].Size == 0x1930)
            {
                this.nr.OpenEntry(index);
                this.SaveBin(this.nr.fs);
                this.nr.Close();
            }
            if (this.nr.fe[index].Size == 0x228)
            {
                this.nr.OpenEntry(index);
                this.SavePal(this.nr.fs);
                this.nr.Close();
            }
        }

        private void OpenPal_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "*.*|*.*";
            string filter = dialog.Filter;
            dialog.InitialDirectory = Environment.CurrentDirectory;
            dialog.Title = "Pal File";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read);
                this.SetPal(fs);
            }
        }

        private void OpenPng_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Open Image As";
            dialog.CheckPathExists = true;
            dialog.Filter = "*.png|*.png";
            dialog.ShowHelp = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = dialog.FileName;
                this.m_bitmap = new Bitmap(fileName);
                if (this.m_bitmap.PixelFormat != PixelFormat.Format8bppIndexed)
                {
                    MessageBox.Show("Png has to be 8bpp Indexed! This image will probably not work.");
                }
                if ((this.m_bitmap.Height != 80) || (this.m_bitmap.Width != 160))
                {
                    MessageBox.Show("Binmap hast to be 80x160. Bitmap will be Scaled");
                    this.m_bitmap = new Bitmap(this.m_bitmap, 160, 80);
                }
                this.m_pictureBox.Image = this.m_bitmap;
                this.m_btnSaveAs.Enabled = true;
            }
        }

        private void SaveBin(FileStream fs)
        {
            BinaryWriter writer = new BinaryWriter(fs);
            this.rect = new Rectangle(0, 0, 160, 80);
            BitmapData bitmapdata = this.m_bitmap.LockBits(this.rect, ImageLockMode.ReadOnly, this.m_bitmap.PixelFormat);
            IntPtr source = bitmapdata.Scan0;
            byte[] destination = new byte[0x3200];
            Marshal.Copy(source, destination, 0, 0x3200);
            this.m_bitmap.UnlockBits(bitmapdata);
            ushort[] numArray = new ushort[0xc80];
            for (int i = 0; i < 0xc80; i++)
            {
                numArray[i] = (ushort) ((((destination[i * 4] & 15) | ((destination[(i * 4) + 1] & 15) << 4)) | ((destination[(i * 4) + 2] & 15) << 8)) | ((destination[(i * 4) + 3] & 15) << 12));
            }
            uint num2 = 0; /*0x7a53;
            for (int j = 0xc7f; j >= 0; j--)
            {
                num2 += numArray[j];
            }*/
            for (int k = 0; k < 0xc80; k++)
            {
                ushort[] numArray2;
                IntPtr ptr2;
                (numArray2 = numArray)[(int) (ptr2 = (IntPtr) k)] = (ushort) (numArray2[(int) ptr2] ^ ((ushort) (num2 & 0xffff)));
                num2 *= 0x41c64e6d;
                num2 += 0x6073;
            }
            byte[] buffer2 = new byte[] { 
                0x52, 0x47, 0x43, 0x4e, 0xff, 0xfe, 0, 1, 0x30, 0x19, 0, 0, 0x10, 0, 1, 0, 
                0x52, 0x41, 0x48, 0x43, 0x20, 0x19, 0, 0, 10, 0, 20, 0, 3, 0, 0, 0, 
                0, 0, 0, 0, 1, 0, 0, 0, 0, 0x19, 0, 0, 0x18, 0, 0, 0
             };
            for (int m = 0; m < 0x30; m++)
            {
                writer.Write(buffer2[m]);
            }
            for (int n = 0; n < 0xc80; n++)
            {
                writer.Write(numArray[n]);
            }
        }

        private void SaveBinary_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Save Image As";
            dialog.OverwritePrompt = true;
            dialog.CheckPathExists = true;
            dialog.Filter = "*.bin|*.bin";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(dialog.FileName, FileMode.Create, FileAccess.Write);
                this.SaveBin(fs);
            }
        }

        private void SavePal(FileStream fs)
        {
            byte[] buffer = new byte[] { 
                0x52, 0x4c, 0x43, 0x4e, 0xff, 0xfe, 0, 1, 0x48, 0, 0, 0, 0x10, 0, 1, 0, 
                0x54, 0x54, 0x4c, 80, 0x38, 0, 0, 0, 4, 0, 10, 0, 0, 0, 0, 0, 
                0x20, 0, 0, 0, 0x10, 0, 0, 0
             };
            BinaryWriter writer = new BinaryWriter(fs);
            writer.Write(buffer, 0, 40);
            ColorPalette palette = this.m_bitmap.Palette;
            ushort[] numArray = new ushort[0x10];
            for (int i = 0; i < 0x10; i++)
            {
                numArray[i] = (ushort) ((((palette.Entries[i].R >> 3) & 0x1f) | (((palette.Entries[i].G >> 3) & 0x1f) << 5)) | (((palette.Entries[i].B >> 3) & 0x1f) << 10));
            }
            for (int j = 0; j < 0x10; j++)
            {
                writer.Write(numArray[j]);
            }
        }

        private void SetPal(FileStream fs)
        {
            if (this.m_bitmap == null)
            {
                MessageBox.Show("Select an Image first");
            }
            else
            {
                fs.Seek(40L, SeekOrigin.Current);
                ushort[] numArray = new ushort[0x10];
                BinaryReader reader = new BinaryReader(fs);
                for (int i = 0; i < 0x10; i++)
                {
                    numArray[i] = reader.ReadUInt16();
                }
                Bitmap bitmap = new Bitmap(1, 1, PixelFormat.Format4bppIndexed);
                ColorPalette palette = bitmap.Palette;
                for (int j = 0; j < 0x10; j++)
                {
                    palette.Entries[j] = Color.FromArgb((numArray[j] & 0x1f) << 3, ((numArray[j] >> 5) & 0x1f) << 3, ((numArray[j] >> 10) & 0x1f) << 3);
                }
                this.m_bitmap.Palette = palette;
                this.m_pictureBox.Image = this.m_bitmap;
            }
        }
    }
}

