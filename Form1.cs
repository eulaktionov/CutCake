using System.Diagnostics;
using System.Net.Security;


namespace CutCake
{
    public partial class Form1 : Form
    {
        int WinLeft = 0;
        int WinTop = 0;
        const int unit = 40;
        Label labelWidth;
        NumericUpDown numericUpDownWidth;
        Label labelHeight;
        NumericUpDown numericUpDownHeight;
        TextBox textBoxCount;
        Button buttonCut;
        List<RectForm> forms = new();
        //List<RectangleF> rectangles=new List<Ob>();
        int _countCuts;
        float _width;
        float _height;
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            this.Size = new Size(500, 400);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            labelHeight = new Label()
            {
                Location = new Point(0, 0),
                Text = "Height"
            };
            numericUpDownHeight = new NumericUpDown()
            {
                Location = new Point(100, 0),
            };
            labelWidth = new Label()
            {
                Location = new Point(0, 100),
                Text = "Width"
            };
            numericUpDownWidth = new NumericUpDown()
            {
                Location = new Point(100, 100),
            };
            textBoxCount = new TextBox()
            {
                Location = new Point(50, 150),
            };
            buttonCut = new Button()
            {
                Dock = DockStyle.Bottom,
                Text = "Cut cake",
            };
            buttonCut.Click += ButtonCut_Click;
            Controls.AddRange(new Control[] { labelHeight, numericUpDownHeight, labelWidth, numericUpDownWidth, buttonCut, textBoxCount });
        }

        private void ButtonCut_Click(object? sender, EventArgs e)
        {
            //_countCuts = int.Parse(textBoxCount.Text);
            //_height = (int)numericUpDownHeight.Value;
            //_width = (int)numericUpDownWidth.Value;
            _countCuts = 4;
            _height = 4;
            _width = 4;
            RecCutCake(new List<Ob>() { new Ob() { rectangleF = new RectangleF(0, 0, _height, _width), count = _countCuts }, }, 0);
        }
        public void RecCutCake(List<Ob> cakes, int level)
        {
            Debug.WriteLine($"Cakes count:{ cakes.Count} , level: {level}");
            //Print(cakes);
            if(cakes.Count == _countCuts)
            {
                Print(cakes);
            }
            else
            {
                for(int i = 0; i < cakes.Count; i++)
                {
                    if(cakes[i].count > 1)
                    {
                        Debug.WriteLine($"I:{i}");
                        Ob cutCake = cakes[i];

                        for(int k = 1; k < cutCake.count; k++)
                        {
                            Debug.WriteLine($"VJ:{k}");

                            List<Ob> os = new List<Ob>(cakes);
                            os.RemoveAt(i);

                            RectangleF rectangleLeft = new RectangleF(cutCake.rectangleF.X, cutCake.rectangleF.Y, cutCake.rectangleF.Width*k / cutCake.count , cutCake.rectangleF.Height);
                            RectangleF rectangleRight = new RectangleF(rectangleLeft.X+rectangleLeft.Width, rectangleLeft.Y, cutCake.rectangleF.Width - rectangleLeft.Width, cutCake.rectangleF.Height);
                            os.Add(new Ob() { rectangleF = rectangleLeft, count = k });
                            os.Add(new Ob() { rectangleF = rectangleRight, count = cutCake.count - k });
                            RecCutCake(os, level+1);
                        }
                        for(int k = 1; k < cutCake.count; k++)
                        {
                            Debug.WriteLine($"HJ:{k}");

                            List<Ob> os = new List<Ob>(cakes);
                            os.RemoveAt(i);

                            RectangleF rectangleTop = new RectangleF(cutCake.rectangleF.X, cutCake.rectangleF.Y, cutCake.rectangleF.Width , cutCake.rectangleF.Height*k / cutCake.count);
                            RectangleF rectangleBottom = new RectangleF(rectangleTop.X, rectangleTop.Y+rectangleTop.Height, cutCake.rectangleF.Width, cutCake.rectangleF.Height-rectangleTop.Height);
                            os.Add(new Ob() { rectangleF = rectangleTop, count = k });
                            os.Add(new Ob() { rectangleF = rectangleBottom, count = cutCake.count - k });
                            RecCutCake(os, level + 1);
                        }
                    }
                }
            }
        }
        public void Print(List<Ob> objects)
        {
            RectForm form = new(unit, (int)_height,
                (int)_width, objects)
            {
                Top = WinTop,
                Left = WinLeft
            };
            if(form.RaisinsSuccess())
            {
                form.Show();
                forms.Add(form);
                WinLeft += form.Width + unit / 2;
                if(WinLeft + form.Width > Screen.PrimaryScreen.Bounds.Width)
                {
                    WinTop += form.Height + unit / 2;
                    WinLeft = 0;
                }
            }

        }
    }
    public struct Ob
    {
        public RectangleF rectangleF { get; set; }
        public int count { get; set; }
    }
}