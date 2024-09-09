using System.Drawing;


namespace SimpleRaytracer;




public partial class Form1 : Form
{
    Label canvas;
    Bitmap image;

    public Form1()
    {
        this.Size = new(600, 400);
        canvas = new Label();
        canvas.Size = this.Size;
        image = new Bitmap(Size.Width, Size.Height);

        this.Controls.Add(canvas);
        canvas.Paint += draw;

        Resize += scale;

    }

    void scale(object o, EventArgs ea)
    {
        
        canvas = new Label();
        canvas.Size = this.Size;
        image = new Bitmap(Size.Width, Size.Height);
    }

    void draw(object o, PaintEventArgs ea)
    {
        for (int y = 0; y < image.Height; y++)
        {
            for (int x = 0; x < image.Width; x++)
            {
                image.SetPixel(x, y, Color.Blue);
            }
        }

        ea.Graphics.DrawImageUnscaled(image, new Point());

    }

}
