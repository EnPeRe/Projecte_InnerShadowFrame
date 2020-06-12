using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Projecte_InnerShadowFrame
{
    public class InnerShadowFrame : Frame
    {
        private SKCanvasView canvasView;

        //void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        //{
        //    SKImageInfo info = args.Info;
        //    SKSurface surface = args.Surface;
        //    SKCanvas canvas = surface.Canvas;
        //    float height = (float)info.Height;
        //    float width = (float)info.Width;

        //    canvas.Clear();

        //    if (IsChecked)
        //    {
        //        SKPaint paint = new SKPaint
        //        {
        //            Style = SKPaintStyle.Stroke,
        //            Color = checkedColor,
        //            StrokeWidth = height
        //        };
        //        canvas.DrawRect(0, 0, width, height, paint);
        //    }
        //    else
        //    {
        //        SKPaint paint = new SKPaint
        //        {
        //            Style = SKPaintStyle.Stroke,
        //            Color = shadowColor,
        //            StrokeWidth = height
        //        };
        //        canvas.DrawRect(0, 0, width, height, paint);

        //        float ShadowCoordinateRatio = (1 - ShadowRatio) / 2;

        //        float innerWidth = (float)(width * ShadowRatio);
        //        float innerHeight = (float)(height * ShadowRatio);

        //        float innerX = (float)(width * ShadowCoordinateRatio);
        //        float innerY = (float)(height * ShadowCoordinateRatio);
        //        SKPaint innerPaint = new SKPaint
        //        {
        //            Style = SKPaintStyle.Stroke,
        //            Color = boxColor,
        //            StrokeWidth = innerHeight,
        //            MaskFilter = SKMaskFilter.CreateBlur(SKBlurStyle.Normal, ShadowMaskSigma)
        //        };
        //        canvas.DrawRect(innerY, innerX, innerWidth, innerHeight, innerPaint);
        //    }
        //}
    }
}
