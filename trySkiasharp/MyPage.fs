﻿namespace trySkiasharp

open System
open Xamarin.Forms
open SkiaSharp
open SkiaSharp.Views.Forms

open DrawDSL


//type DonutCharSK = 

type MyPage () =
  inherit ContentPage ()

  let layout = Grid()

  //do  layout.Children.Add(Label(XAlign = TextAlignment.Center, Text = "Welcome to F# Xamarin.Forms!"))

  let OnPaintSurfaceEv (args: SKPaintSurfaceEventArgs) =
    //let argss = args :?> SKPaintSurfaceEventArgs
    let info = args.Info
    let surface = args.Surface
    let canvas = surface.Canvas

    do canvas.Clear()

    let paint = 
      new SKPaint (
            Style = SKPaintStyle.Stroke,
            Color = Color.Red.ToSKColor(),
            StrokeWidth = 1.0f
           )

    let donutW = 30.0f
    let halfDW = donutW / 2.0f
    let paintDonut =  
      new SKPaint (
            Style = SKPaintStyle.Stroke,
            Color = Color.Blue.ToSKColor(),
            StrokeWidth = donutW
          )

    //let w2 = (info.Width / 2) |> float32
    //let h2 = (info.Height / 2) |> float32
    //let rr = w2

    ///   
    let createRectangleForArc halfInner radius centerx centery   =
      new SKRect(centerx - radius + halfInner, centery - radius + halfInner, centerx + radius - halfInner, centery + radius - halfInner)

    let rr = 90.0f    
    
    let createRectForDonutGraph = createRectangleForArc halfDW rr


    let w1 = 150.0f
    let h1 = 150.0f

    let w2 = 350.0f
    let h2 = 350.0f

    let w3 = 250.0f
    let h3 = 600.0f

    let path = new SKPath()
    let rect1 = createRectForDonutGraph w1 h1 
    let rect2 = createRectForDonutGraph w2 h2
    let rect3 = createRectForDonutGraph w3 h3 

    let str1 = "Balance"
    let str1b = "£ 5.00"

    let txtPaint = 
      new SKPaint (
        Color = SKColors.Purple
      )

    let txtWidth = txtPaint.MeasureText str1
    // 90% of available space
    do txtPaint.TextSize <- 0.9f * rr * txtPaint.TextSize / txtWidth 

    do
      path.AddArc(rect1, 0.0f, 270.0f)
      path.AddArc(rect2, 0.0f, 180.0f)
      path.AddArc(rect3, 0.0f, 90.0f)
      canvas.DrawPath(path, paintDonut)
      canvas.DrawCircle( w1, h1, rr, paint)
      canvas.DrawCircle( w2, h2, rr, paint)
      canvas.DrawCircle( w3, h3, rr, paint)
      canvas.DrawText(str1, (rect1.MidX |> float32) - txtWidth, (rect1.MidY |> float32) - txtPaint.TextSize, txtPaint)
      //canvas.DrawText(str1, w1 - txtWidth / 2.0f, h1, txtPaint)
           
  let canvasView = new SKCanvasView()
  do 
    canvasView.PaintSurface.Add(OnPaintSurfaceEv)
    layout.Children.Add canvasView

    base.Content <- layout