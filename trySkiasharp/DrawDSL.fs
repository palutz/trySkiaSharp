namespace trySkiasharp


module ScoreDrawDSL =

  type DonutRing = 
    struct
      val ringW : int
      val ringPercInCent : int
      new(ringperc : int, w : int) = {
        ringPercInCent = ringperc
        ringW = w
        }
    end


  type DonutChart =
    struct
      val centerX : int
      val centerY : int
      val radius : int
      val text : string option
      new(x : int, y : int, r : int, txt : string option) = {
          centerX  = x
          centerY  = y
          radius = r
          text = txt
        }
    end



module DrawSKiaDSL =
  open Xamarin.Forms
  open SkiaSharp
  open SkiaSharp.Views.Forms
  open ScoreDrawDSL

  
  let painterShape (color: SKColor) width =
    new SKPaint
      (
        Style = SKPaintStyle.Stroke,
        Color = color,
        StrokeWidth = (width |> float32)
      )

  
  let painterText (color: SKColor) =
    new SKPaint( Color = color )
    


  let createSKRectForArc width radius centerx centery =
    let halfWidth = width / 2.0f
    new SKRect(centerx - radius + halfWidth, centery - radius + halfWidth, centerx + radius - halfWidth, centery + radius - halfWidth)

  let convertPercent2Angle (percInCent : int) = 
    percInCent |> float32 |> (*) 3.6f   // / 3.6 = 360 / 100
  
  let paintDonutChart (canvas: SKCanvas) (path: SKPath) (donut : DonutChart) (dntRing: DonutRing) =
    //let hr = (dntRing.ringW |> float32) / 2.0f
    let rect = createSKRectForArc (dntRing.ringW |> float32) (donut.radius |> float32) (donut.centerX |> float32) (donut.centerY |> float32)
    do
      path.AddArc(rect, 0.0f, (convertPercent2Angle dntRing.ringPercInCent))
      canvas.DrawPath(path, painterShape (Color.Gray.ToSKColor()) (dntRing.ringW |> float32))
      canvas.DrawCircle(
                          donut.centerX |> float32,
                          donut.centerY |> float32, 
                          donut.radius |> float32,
                          painterShape (Color.Gray.ToSKColor()) 3.0f
                        )
      match donut.text with 
      | Some str -> 
              let txtPaint = painterText (Color.Black.ToSKColor())
              let txtWidth = txtPaint.MeasureText str
              canvas.DrawText(str, (rect.MidX |> float32) - txtWidth, (rect.MidY |> float32) - txtPaint.TextSize, txtPaint)
      | _ -> ()