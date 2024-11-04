using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toast
{
    public class Toast : ToolTip
    {
        public int SIZE_X = 500;
        public int SIZE_Y = 50;
        public Color BackgroundColor = Color.FromArgb(40, 40, 40);
        public Color Fontcolor = Color.White;
        public Font Font = new Font("굴림", 9, FontStyle.Bold);
        public int LocationX = 100;
        public int LocationY = 100;
        public int duration = 3000;
        IWin32Window _owner;
        


        public Toast(IWin32Window OwnerForm)
        {

            this.OwnerDraw = true;
            this.Popup += new PopupEventHandler(this.OnPopup);
            this.Draw += new DrawToolTipEventHandler(this.OnDraw);
            //_owner = OwnerForm;
            _owner = (Form)OwnerForm;
        }

        string m_EndSpecialText;
        Color m_EndSpecialTextColor = Color.Black;

        public Color EndSpecialTextColor
        {
            get { return m_EndSpecialTextColor; }
            set { m_EndSpecialTextColor = value; }
        }

        public string EndSpecialText
        {
            get { return m_EndSpecialText; }
            set { m_EndSpecialText = value; }
        }

        private void OnPopup(object sender, PopupEventArgs e) // use this event to set the size of the tool tip
        {
            e.ToolTipSize = new Size(SIZE_X, SIZE_Y);
        }

        public void Show(string msg)
        {
            this.Show(msg, _owner,  LocationX, LocationY, duration);
        }
        
        //private void OnDraw(object sender, DrawToolTipEventArgs e) // use this event to customise the tool tip
        //{
        //    Graphics g = e.Graphics;

        //    //LinearGradientBrush b = new LinearGradientBrush(e.Bounds,
        //    //    Color.AntiqueWhite, Color.LightCyan, 45f);
        //    LinearGradientBrush b = new LinearGradientBrush(e.Bounds, Color.Indigo, Color.Honeydew, 60f);

        //    g.FillRectangle(b, e.Bounds);




        //    g.DrawRectangle(new Pen(Brushes.Transparent, 1), new Rectangle(e.Bounds.X, e.Bounds.Y,
        //        e.Bounds.Width - 1, e.Bounds.Height - 1));


        //    System.Drawing.Size toolTipTextSize = TextRenderer.MeasureText(e.ToolTipText, e.Font);

        //    g.DrawString(e.ToolTipText, new Font(e.Font, FontStyle.Bold), Brushes.White,
        //        new PointF((SIZE_X - toolTipTextSize.Width) / 2, (SIZE_Y - toolTipTextSize.Height) / 2));

        //    b.Dispose();
        //}

        private void OnDraw(object sender, DrawToolTipEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // 반경 설정
            int radius = 6;

            // Tooltip Bounds
            Rectangle rect = e.Bounds;

            // 라운드된 사각형 경로 생성
            using (GraphicsPath path = GetRoundedRectanglePath(rect, radius))
            {
                // 배경 그라데이션 브러시
                //using (LinearGradientBrush b = new LinearGradientBrush(rect, Color.FromArgb(230,230,230), Color.Honeydew, 60f))
                using (SolidBrush b = new SolidBrush(BackgroundColor))
                {
                    g.FillPath(b, path);
                }

                // 테두리
                using (Pen pen = new Pen(Color.Transparent, 1))
                {
                    g.DrawPath(pen, path);
                }

                // 텍스트 크기 측정
                Size toolTipTextSize = TextRenderer.MeasureText(e.ToolTipText, e.Font);

                // 텍스트 중앙 정렬 위치
                PointF textLocation = new PointF(
                    (rect.Width - toolTipTextSize.Width) / 2,
                    (rect.Height - toolTipTextSize.Height) / 2
                );

                // 텍스트 그리기
                g.DrawString(e.ToolTipText, new Font(e.Font, FontStyle.Bold), Brushes.White, textLocation);
            }
        }

        // 라운드된 사각형 경로 생성 함수
        private GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
        {
            int diameter = radius * 2;
            GraphicsPath path = new GraphicsPath();

            // 좌측 상단 모서리
            path.AddArc(rect.Left, rect.Top, diameter, diameter, 180, 90);
            path.AddLine(rect.Left + radius, rect.Top, rect.Right - radius, rect.Top);

            // 우측 상단 모서리
            path.AddArc(rect.Right - diameter, rect.Top, diameter, diameter, 270, 90);
            path.AddLine(rect.Right, rect.Top + radius, rect.Right, rect.Bottom - radius);

            // 우측 하단 모서리
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddLine(rect.Right - radius, rect.Bottom, rect.Left + radius, rect.Bottom);

            // 좌측 하단 모서리
            path.AddArc(rect.Left, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            return path;
        }
    }
}
