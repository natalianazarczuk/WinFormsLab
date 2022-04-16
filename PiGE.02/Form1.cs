using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PiGE._02
{
    public partial class Form1 : Form
    {
        private Button[] buttons;
        private Form newForm;
        TextBox width;
        TextBox height;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int width = 10;
            int height = 10;
            buttons = new Button[100];

            for (int i = 0; i < width * height; i++)
            {
                Random rnd = new Random();
                int x = rnd.Next(0, 2);

                buttons[i] = new Button()
                {
                    Dock = DockStyle.Fill,
                    FlatStyle = FlatStyle.Flat,
                    Margin = Padding.Empty,
                    BackColor = (x == 0) ? Color.Black : Color.White
                };
                buttons[i].Click += button_Click;

                tableLayoutPanel1.Controls.Add(buttons[i], i / width, i % height);

                button_Click(buttons[i], e);
            }

            //left labels
            for (int i = 0; i < height; i++)
            {
                int equal = 0;
                int col = 4;
                int range1 = width + 1;
                while (equal < width)
                {
                    Random rnd = new Random();
                    int x = rnd.Next(1, range1);
                    equal += x + 1;
                    range1 -= x + 1;

                    Label label = new Label();
                    label.TextAlign = ContentAlignment.MiddleRight;
                    label.Text = $"{x}";
                    tableleft.Controls.Add(label, col, i);
                    col--;
                }
            }

            //top labels
            for (int i = 0; i < width; i++)
            {
                int all = 0;
                int row = 4;
                int range2 = height + 1;
                while (all < height)
                {
                    Random rnd = new Random();
                    int x = rnd.Next(1, range2);
                    all += x + 1;
                    range2 -= x + 1;

                    Label label = new Label();
                    label.TextAlign = ContentAlignment.BottomCenter;
                    label.Text = $"{x}";
                    tabletop.Controls.Add(label, i, row);
                    row--;
                }
            }
        }

        void generate_board(int width, int height)
        {
            TableLayoutPanel newtable = new TableLayoutPanel();
            newtable.RowCount = height;
            newtable.ColumnCount = width;
            buttons = new Button[width * height];

            for (int i = 0; i < width * height; i++)
            {
                Random rnd = new Random();
                int x = rnd.Next(0, 2);

                buttons[i] = new Button()
                {
                    Dock = DockStyle.Fill,
                    FlatStyle = FlatStyle.Flat,
                    Margin = Padding.Empty,
                    BackColor = (x == 0) ? Color.Black : Color.White
                };
                buttons[i].Click += button_Click;
                tableLayoutPanel1.Controls.Add(buttons[i], i / width, i % height);

                //button_Click(buttons[i], e);
            }

            TableLayoutPanel newleft = new TableLayoutPanel();
            newleft.RowCount = height;
            newleft.ColumnCount = width / 2;
            for (int i = 0; i < height; i++)
            {
                int equal = 0;
                int col = 4;
                int range1 = width + 1;
                while (equal < width)
                {
                    Random rnd = new Random();
                    int x = rnd.Next(1, range1);
                    equal += x + 1;
                    range1 -= x + 1;

                    Label label = new Label();
                    label.TextAlign = ContentAlignment.MiddleRight;
                    label.Text = $"{x}";
                    tableleft.Controls.Add(label, col, i);
                    col--;
                }
            }

            TableLayoutPanel newtop = new TableLayoutPanel();
            newtop.RowCount = width;
            newtop.ColumnCount = height / 2;
            for (int i = 0; i < width; i++)
            {
                int all = 0;
                int row = 4;
                int range2 = height + 1;
                while (all < height)
                {
                    Random rnd = new Random();
                    int x = rnd.Next(1, range2);
                    all += x + 1;
                    range2 -= x + 1;

                    Label label = new Label();
                    label.TextAlign = ContentAlignment.BottomCenter;
                    label.Text = $"{x}";
                    tabletop.Controls.Add(label, i, row);
                    row--;
                }
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button.BackColor == Color.White)
                button.BackColor = Color.Black;
            else
                button.BackColor = Color.White;
        }

        private void NewGameItem1_Click(object sender, EventArgs e)
        {
             newForm = new Form();
            newForm.Text = "New Random Puzzle";

            width = new TextBox();
            height = new TextBox();
            width.Location = new Point(150, 50);
            height.Location = new Point(150, 100); ;
            newForm.Controls.Add(width);
            newForm.Controls.Add(height);

            Label wl = new Label();
            Label hl = new Label();
            wl.Location = new Point(50, 100);
            hl.Location = new Point(50, 50);
            wl.AutoSize = true;
            wl.Text = "Width";
            hl.Text = "Height";
            newForm.Controls.Add(wl);
            newForm.Controls.Add(hl);

            Button ok = new Button();
            ok.Location = new Point(50, 200);
            ok.Height = 40;
            ok.Text = "OK";
            ok.Click += ok_Click;
            newForm.Controls.Add(ok);

            Button cancel = new Button();
            cancel.Location = new Point(150, 200);
            cancel.Height = 40;
            cancel.Text = "Cancel";
            cancel.Click += cancel_Click;
            newForm.Controls.Add(cancel);

            newForm.MinimizeBox = false;
            newForm.MaximizeBox = false;
            newForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            newForm.StartPosition = FormStartPosition.CenterScreen;
            
            newForm.Show();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            int w, h;
            if (int.TryParse(width.Text, out w) && int.TryParse(height.Text, out h))
            {
                if (w < 2 || w > 15 || h < 2 || h > 15)
                {

                }
                else
                {
                    Form1 NewForm = new Form1();
                    NewForm.Show();
                    this.Dispose(false);
                    Form1_Load(sender, e);
                    newForm.Close();
                }
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.newForm.Close();
        }
    }
}
