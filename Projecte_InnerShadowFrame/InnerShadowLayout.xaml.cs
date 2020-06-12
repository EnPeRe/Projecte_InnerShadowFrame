using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
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

        public float ShadowRatio
        {
            get => (float)GetValue(ShadowRatioProperty);
            set => SetValue(ShadowRatioProperty, value);
        }

        public float ShadowMaskSigma
        {
            get => (float)GetValue(ShadowMaskSigmaProperty);
            set => SetValue(ShadowMaskSigmaProperty, value);
        }

        #endregion

        #region .: Bindable Properties :.

        public static readonly BindableProperty HasInnerShadowProperty =
            BindableProperty.Create(nameof(HasInnerShadow), typeof(bool), typeof(InnerShadowLayout), false);

        public static readonly BindableProperty ShadowRatioProperty =
            BindableProperty.Create(propertyName: nameof(ShadowRatio), returnType: typeof(float), declaringType: typeof(InnerShadowLayout),
                defaultValue: 0.4f);

        public static readonly BindableProperty ShadowMaskSigmaProperty =
            BindableProperty.Create(propertyName: nameof(ShadowMaskSigma), returnType: typeof(float), declaringType: typeof(InnerShadowLayout),
                defaultValue: 9.0f);

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
                case nameof(ShadowRatio):
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
            float height = (float)info.Height;
            float width = (float)info.Width;

            canvas.Clear();

            SKPaint paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = Color.DeepSkyBlue.ToSKColor(),
                StrokeWidth = height
            };
            canvas.DrawRect(0, 0, width, height, paint);

            float ShadowCoordinateRatio = (1 - ShadowRatio) / 2;

            float innerWidth = (float)(width * ShadowRatio);
            float innerHeight = (float)(height * ShadowRatio);

            float innerX = (float)(width * ShadowCoordinateRatio);
            float innerY = (float)(height * ShadowCoordinateRatio);
            SKPaint innerPaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = Color.Firebrick.ToSKColor(),
                //StrokeWidth = height-50,
                MaskFilter = SKMaskFilter.CreateBlur(SKBlurStyle.Normal, ShadowMaskSigma)
            };
            canvas.DrawRect(10, 10, width-20, height-20, innerPaint);
        }

        #endregion
    }
}