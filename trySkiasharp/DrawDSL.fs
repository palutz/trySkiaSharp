namespace trySkiasharp


module ScoreDrawDSL =

  type ScoreColor = 
    | Blue = 0
    | Red = 1
    | White = 2
    | Gray = 3
    | Green = 4
    | Purple = 5


  type DonutChart(centerx : int, centery : int, innerRad : int) = 
    member this.centerX = centerx
    member this. centerY = centery
    member this.innerRadius = innerRad


  type DonutChartWithText(centerx, centery, innerRad, txt) = 
    inherit DonutChart(centerx, centery, innerRad)
    member this.text = txt 


module DrawSKiaDSL =
  open System
  open SkiaSharp
  open SkiaSharp.Views.Forms
  open ScoreDrawDSL


  let Score2SkiaColor (c : ScoreColor) =
    match c with
      | Blue -> Xamarin.Forms.Color.Blue.ToSKColor()
      | Red -> Xamarin.Forms.Color.Red.ToSKColor()
      | Purple -> Xamarin.Forms.Color.Purple.ToSKColor()
      | Green -> Xamarin.Forms.Color.Green.ToSKColor()
      | Gray -> Xamarin.Forms.Color.Gray.ToSKColor()
      | White -> Xamarin.Forms.Color.White.ToSKColor()
      | _ -> Xamarin.Forms.Color.White.ToSKColor()   // default

  
  let painter (color: ScoreColor) width =
    new SKPaint(
        Style = SKPaintStyle.Stroke,
        Color = (color |> Score2SkiaColor),
        StrokeWidth = width
      )

  let createSKRectForArc halfInner radius centerx centery   =
    new SKRect(centerx - radius + halfInner, centery - radius + halfInner, centerx + radius - halfInner, centery + radius - halfInner)


  type SKiaDonutChart (skCircle, donutPaint) =

  




   


