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