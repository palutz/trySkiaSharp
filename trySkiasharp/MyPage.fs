namespace trySkiasharp

open System
open Xamarin.Forms
open SkiaSharp
open SkiaSharp.Views.Forms

open DrawSKiaDSL
open ScoreDrawDSL



//type DonutCharSK = 

type MyPage () =
  inherit ContentPage ()

  let layout = Grid()

  //do  layout.Children.Add(Label(XAlign = TextAlignment.Center, Text = "Welcome to F# Xamarin.Forms!"))

  //let OnPaintSurfaceEv (args: SKPaintSurfaceEventArgs) =
  //  //let argss = args :?> SKPaintSurfaceEventArgs
  //  let info = args.Info
  //  let surface = args.Surface
  //  let canvas = surface.Canvas

  //  do canvas.Clear()

  //  let paint = 
  //    new SKPaint (
  //          Style = SKPaintStyle.Stroke,
  //          Color = Color.Red.ToSKColor(),
  //          StrokeWidth = 1.0f
  //         )

  //  let donutW = 30.0f
  //  let halfDW = donutW / 2.0f
  //  let paintDonut =  
  //    new SKPaint (
  //          Style = SKPaintStyle.Stroke,
  //          Color = Color.Blue.ToSKColor(),
  //          StrokeWidth = donutW
  //        )

  //  //let w2 = (info.Width / 2) |> float32
  //  //let h2 = (info.Height / 2) |> float32
  //  //let rr = w2

  //  ///   
  //  let createRectangleForArc halfInner radius centerx centery   =
  //    new SKRect(centerx - radius + halfInner, centery - radius + halfInner, centerx + radius - halfInner, centery + radius - halfInner)

  //  let rr = 90.0f    
    
  //  let createRectForDonutGraph = createRectangleForArc halfDW rr


  //  let w1 = 150.0f
  //  let h1 = 150.0f

  //  let w2 = 350.0f
  //  let h2 = 350.0f

  //  let w3 = 250.0f
  //  let h3 = 600.0f

  //  let path = new SKPath()
  //  let rect1 = createRectForDonutGraph w1 h1 
  //  let rect2 = createRectForDonutGraph w2 h2
  //  let rect3 = createRectForDonutGraph w3 h3 

  //  let str1 = "Balance"
  //  let str1b = "£ 5.00"

  //  let txtPaint = 
  //    new SKPaint (
  //      Color = SKColors.Purple
  //    )

  //  let txtWidth = txtPaint.MeasureText str1
  //  // 90% of available space
  //  do txtPaint.TextSize <- 0.9f * rr * txtPaint.TextSize / txtWidth 

  //  do
  //    path.AddArc(rect1, 0.0f, 270.0f)
  //    path.AddArc(rect2, 0.0f, 180.0f)
  //    path.AddArc(rect3, 0.0f, 90.0f)
  //    canvas.DrawPath(path, paintDonut)
  //    canvas.DrawCircle( w1, h1, rr, paint)
  //    canvas.DrawCircle( w2, h2, rr, paint)
  //    canvas.DrawCircle( w3, h3, rr, paint)
  //    canvas.DrawText(str1, (rect1.MidX |> float32) - txtWidth, (rect1.MidY |> float32) - txtPaint.TextSize, txtPaint)
  //    //canvas.DrawText(str1, w1 - txtWidth / 2.0f, h1, txtPaint)

  let OnPaintSurfaceEv (args: SKPaintSurfaceEventArgs) =
    let info = args.Info
    let surface = args.Surface
    let canvas = surface.Canvas
    let path = new SKPath()

    let x = info.Width
    let y = info.Height
    let rect = Math.Min(x, y)
    let donutCanvas = paintDonutChart canvas path
    let donut = new DonutChart(x /2, y /2, rect /2 , None)
    let donutRing = new DonutRing(30, (donut.radius / 3))

    let str = sprintf

    //let donut2 = new DonutChart(350, 350, 90, "Text01" |> Some)
    //let donutRing2 = new DonutRing(50, (donut2.radius / 3))

    //let donut3 = new DonutChart(250, 600, 90, "This is another text" |> Some)
    //let donutRing3 = new DonutRing(60, (donut3.radius / 3))

    do
      canvas.Clear()
      donutCanvas donut donutRing
      //donutCanvas donut2 donutRing2
      //donutCanvas donut3 donutRing3

           
  let canvasView = new SKCanvasView()
   
  let grid = new Grid()
  do
    let chartLabel = 
       Label(FontSize = Device.GetNamedSize(NamedSize.Small, typeof<Label>),
                      VerticalOptions = LayoutOptions.Center,
                      HorizontalTextAlignment = TextAlignment.Center,
                      Text = "this a string")
    grid.Children.Add(chartLabel, 1, 0)
    grid.RowDefinitions.Add(RowDefinition(Height = new GridLength(3.0, GridUnitType.Star)))
    grid.RowDefinitions.Add(RowDefinition(Height = new GridLength(4.0, GridUnitType.Star)))
    grid.RowDefinitions.Add(RowDefinition(Height = new GridLength(3.0, GridUnitType.Star)))
    grid.Children.Add(canvasView, 0, 1)
    grid.Children.Add(chartLabel, 0, 1)
    canvasView.PaintSurface.Add(OnPaintSurfaceEv)
    layout.Children.Add grid
    //layout.Children.Add canvasView

    //layout.Children.Add chartLabel

    base.Content <- layout