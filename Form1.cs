using System.Drawing;


namespace SimpleRaytracer;




public partial class Form1 : Form
{
    Label canvas;
    Bitmap image;
    Raytracer r = new Raytracer();


    public Form1()
    {
        this.Size = new(600, 400);
        canvas = new Label();
        canvas.Size = this.ClientSize;
        image = new Bitmap(ClientSize.Width, ClientSize.Height);

        this.Controls.Add(canvas);
        canvas.Paint += draw;

        ClientSizeChanged += scale;

        KeyDown += Control;

    }

    void Control(object o, KeyEventArgs e)
    {
        if (e.KeyData == Keys.D || e.KeyData == Keys.Right)
        {
            r.cam.pos += new G4(0.5f, 0, 0, 0);
            this.Invalidate();
            canvas.Invalidate();
        }

        if (e.KeyData == Keys.A || e.KeyData == Keys.Left)
        {
            r.cam.pos += new G4(-0.5f, 0, 0, 0);
            this.Invalidate();
            canvas.Invalidate();
        }

    }

    void scale(object o, EventArgs ea)
    {
        
        canvas = new Label();
        canvas.Size = this.ClientSize;
        image = new Bitmap(ClientSize.Width, ClientSize.Height);
        this.Invalidate();
    }

    void draw(object o, PaintEventArgs ea)
    {
        for (int y = 0; y < image.Height; y++)
        {
            for (int x = 0; x < image.Width; x++)
            {
                image.SetPixel(x, y, r.pixel(x,y,image.Size));
            }
        }

        ea.Graphics.DrawImageUnscaled(image, new Point());

    }

}
