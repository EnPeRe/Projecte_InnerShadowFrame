using SkiaSharp;
using SkiaSharp.Views.Forms;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projecte_InnerShadowFrame
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InnerShadowLayout : ContentView
    {
        #region .: Properties :.

        public bool HasInnerShadow
        {
            get { return (bool)GetValue(HasInnerShadowProperty); }
            set { SetValue(HasInnerShadowProperty, value); }
        }

        public float ShadowMaskSigma
        {
            get => (float)GetValue(ShadowMaskSigmaProperty);
            set => SetValue(ShadowMaskSigmaProperty, value);
        }

        public float ShadowSize
        {
            get { return (float)GetValue(ShadowSizeProperty); }
            set { SetValue(ShadowSizeProperty, value); }
        }

        #endregion

        #region .: Bindable Properties :.

        public static readonly BindableProperty HasInnerShadowProperty =
            BindableProperty.Create(nameof(HasInnerShadow), typeof(bool), typeof(InnerShadowLayout), false);

        public static readonly BindableProperty ShadowMaskSigmaProperty =
            BindableProperty.Create(propertyName: nameof(ShadowMaskSigma), returnType: typeof(float), declaringType: typeof(InnerShadowLayout),
                defaultValue: 9.0f);

        public static readonly BindableProperty ShadowSizeProperty =
            BindableProperty.Create(nameof(ShadowSize), typeof(float), typeof(InnerShadowLayout), 20f);

        #endregion

        #region .: Constructor :.

        public InnerShadowLayout()
        {
            InitializeComponent();

            ShadowCanvas.HeightRequest = this.HeightRequest;
            ShadowCanvas.WidthRequest = this.WidthRequest;
        }

        #endregion

        #region .: Property Changed's :.

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            switch (propertyName)
            {
                case nameof(HasInnerShadow):
                case nameof(Height):
                case nameof(Width):
                case nameof(ShadowMaskSigma):
                    ShadowCanvas.InvalidateSurface();
                    break;
            }
        }

        #endregion

        #region .: Private Methods :.

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;
            float height = info.Height;
            float width = info.Width;

            canvas.Clear();

            SKPaint innerPaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = Color.Black.ToSKColor(),
                MaskFilter = SKMaskFilter.CreateBlur(SKBlurStyle.Normal, ShadowMaskSigma)
            };
            canvas.DrawRect(ShadowSize, ShadowSize, width - (ShadowSize * 2), height - (ShadowSize * 2), innerPaint);
        }

        #endregion
    }
}