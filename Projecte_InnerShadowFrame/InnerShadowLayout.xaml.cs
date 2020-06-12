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

        private SKColor shadowColor = Color.FromHex("#3A87D3").ToSKColor();
        private SKColor boxColor = Color.FromHex("#1C68AF").ToSKColor();
        private SKColor checkedColor = Color.FromHex("#F2CB3F").ToSKColor();

        public Double CanvasSize
        {
            get => (Double)GetValue(CanvasSizeProperty);
            set => SetValue(CanvasSizeProperty, value);
        }

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

        public static readonly BindableProperty CanvasSizeProperty =
            BindableProperty.Create(propertyName: nameof(CanvasSize), returnType: typeof(Double), declaringType: typeof(InnerShadowLayout));

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
                case nameof(CanvasSize):
                case nameof(Height):
                case nameof(Width):
                case nameof(ShadowRatio):
                case nameof(ShadowMaskSigma):
                    ShadowCanvas.InvalidateSurface();
                    break;
            }
        }

        //private static void OnCanvasSizeChanged(BindableObject bindable, object oldValue, object newValue)
        //{
        //    if (bindable is InnerShadowLayout typedBindable && newValue is Double typedValue)
        //    {
        //        typedBindable.ShadowCanvas.HeightRequest = typedValue;
        //        typedBindable.ShadowCanvas.WidthRequest = typedValue;
        //    }
        //}

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
                Color = this.BackgroundColor.ToSKColor(),
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
                StrokeWidth = innerHeight,
                MaskFilter = SKMaskFilter.CreateBlur(SKBlurStyle.Normal, ShadowMaskSigma)
            };
            canvas.DrawRect(innerY, innerX, innerWidth, innerHeight, innerPaint);
        }

        #endregion
    }
}