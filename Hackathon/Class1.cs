using System.Drawing;
using System.Windows.Forms;

public partial class TransparentPanel : UserControl
{
    public TransparentPanel()
    {
        
        SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        BackColor = Color.Transparent;
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        // Do not paint the background
    }
}
