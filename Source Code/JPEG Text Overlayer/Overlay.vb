Imports System
Imports System.Drawing
Imports System.Drawing.Imaging

Public Class Overlay
        ' "Old" signature overloaded to call new method w/extra parameters
    Public Shared Function VBOverlay(ByVal img As Image, ByVal OverlayText As String, ByVal OverlayFont As Font, _
            ByVal OverlayColor As Color, ByVal AddAlpha As Boolean, ByVal AddShadow As Boolean) As Bitmap
        Return VBOverlay(img, OverlayText, OverlayFont, OverlayColor, AddAlpha, AddShadow, _
            ContentAlignment.MiddleCenter, 0.8!)
    End Function

    ' Draw text directly onto an image (scaled for best-fit)
    ' Written to be called from a module (just on the form for simplicity)
    Public Shared Function VBOverlay(ByVal img As Image, ByVal OverlayText As String, ByVal OverlayFont As Font, _
            ByVal OverlayColor As Color, ByVal AddAlpha As Boolean, ByVal AddShadow As Boolean, _
            ByVal Position As Drawing.ContentAlignment, ByVal PercentFill As Single) As Bitmap
        If OverlayText > "" AndAlso PercentFill > 0 Then
            ' create bitmap and graphics used for drawing
            ' "clone" image but use 24RGB format
            Dim bmp As New Bitmap(img.Width, img.Height, Drawing.Imaging.PixelFormat.Format24bppRgb)
            Dim g As Graphics = Graphics.FromImage(bmp)
            g.DrawImage(img, 0, 0)

            Dim alpha As Integer = 255
            If AddAlpha Then
                ' Compute transparency: Longer text should be less transparent or it gets lost.
                alpha = 90 + (OverlayText.Length * 2)
                If alpha >= 255 Then alpha = 255
            End If
            ' Create the brush based on the color and alpha
            Dim b As New SolidBrush(Color.FromArgb(alpha, OverlayColor))

            ' Measure the text to render (unscaled, unwrapped)
            Dim strFormat As StringFormat = StringFormat.GenericTypographic
            Dim s As SizeF = g.MeasureString(OverlayText, OverlayFont, 100000, strFormat)

            ' Enlarge font to specified fill (estimated by AREA)
            Dim zoom As Single = CSng(Math.Sqrt((CDbl(img.Width * img.Height) * PercentFill) / CDbl(s.Width * s.Height)))
            Dim sty As FontStyle = OverlayFont.Style
            Dim f As New Font(OverlayFont.FontFamily, CSng(OverlayFont.Size) * zoom, sty)
            Console.WriteLine("Starting Zoom: " & zoom & ", Font Size: " & f.Size & ", Alpha: " & alpha)

            ' Measure using new font size, allow to wrap as needed.
            ' Could rotate the overlay at a 30-45 deg. angle (trig would give correct angle).
            ' Of course, then the area covered would be less than "straight" text.
            ' I'll leave those calculations for someone else....
            Dim charFit, linesFit As Integer
            Dim SQRTFill As Single = CSng(Math.Sqrt(PercentFill))
            strFormat.FormatFlags = StringFormatFlags.NoClip 'Or StringFormatFlags.LineLimit 'Or StringFormatFlags.MeasureTrailingSpaces
            strFormat.Trimming = StringTrimming.Word
            Dim layout As New SizeF(CSng(img.Width) * SQRTFill, CSng(img.Height) * 1.5!) ' fit to width, allow height to go over
            Console.WriteLine("Target size: " & layout.Width & ", " & layout.Height)
            s = g.MeasureString(OverlayText, f, layout, strFormat, charFit, linesFit)

            ' Reduce size until it actually fits...
            ' Most text only has to be reduced 1 or 2 times.
            Do Until s.Height <= CSng(img.Height) * SQRTFill AndAlso s.Width <= layout.Width
                Console.WriteLine("Reducing font size: area required = " & s.Width & ", " & s.Height)
                zoom = Math.Max(s.Height / (CSng(img.Height) * SQRTFill), s.Width / layout.Width)
                zoom = f.Size / zoom
                If zoom > 16 Then zoom = CSng(Math.Floor(zoom)) ' use a whole number to reduce "jaggies"
                If zoom >= f.Size Then zoom -= 1
                f = New Font(OverlayFont.FontFamily, zoom, sty)
                s = g.MeasureString(OverlayText, f, layout, strFormat, charFit, linesFit)
                If zoom <= 1 Then Exit Do ' bail
            Loop
            Console.WriteLine("Final Font Size: " & f.Size & ", area: " & s.Width & ", " & s.Height)

            ' Determine draw area based on placement
            Dim rect As RectangleF
            Select Case Position
                Case ContentAlignment.TopLeft ' =1
                    rect = New RectangleF(f.Size * 0.15!, _
                        (f.Size * 0.1!), _
                        layout.Width, _
                        CSng(img.Height) * SQRTFill)
                Case ContentAlignment.TopCenter ' =2
                    rect = New RectangleF((bmp.Width - s.Width) / 2, _
                        (f.Size * 0.1!), _
                        layout.Width, _
                        CSng(img.Height) * SQRTFill)
                Case ContentAlignment.TopRight ' =4
                    rect = New RectangleF((bmp.Width - s.Width) - (f.Size * 0.1!), _
                        (f.Size * 0.1!), _
                        layout.Width, _
                        CSng(img.Height) * SQRTFill)
                Case ContentAlignment.MiddleLeft ' =16  huh?  where's 8?
                    rect = New RectangleF(f.Size * 0.15!, _
                        (bmp.Height - s.Height) / 2, _
                        layout.Width, _
                        CSng(img.Height) * SQRTFill)
                Case ContentAlignment.MiddleCenter ' =32
                    rect = New RectangleF((bmp.Width - s.Width) / 2, _
                        (bmp.Height - s.Height) / 2, _
                        layout.Width, _
                        CSng(img.Height) * SQRTFill)
                Case ContentAlignment.MiddleRight '=64
                    rect = New RectangleF((bmp.Width - s.Width) - (f.Size * 0.1!), _
                        (bmp.Height - s.Height) / 2, _
                        layout.Width, _
                        CSng(img.Height) * SQRTFill)
                Case ContentAlignment.BottomLeft ' =256  and 128?
                    rect = New RectangleF(f.Size * 0.15!, _
                        (bmp.Height - s.Height) - (f.Size * 0.1!), _
                        layout.Width, _
                        CSng(img.Height) * SQRTFill)
                Case ContentAlignment.BottomCenter ' =512
                    rect = New RectangleF((bmp.Width - s.Width) / 2, _
                        (bmp.Height - s.Height) - (f.Size * 0.1!), _
                        layout.Width, _
                        CSng(img.Height) * SQRTFill)
                Case ContentAlignment.BottomRight ' =1024
                    rect = New RectangleF((bmp.Width - s.Width) - (f.Size * 0.1!), _
                        (bmp.Height - s.Height) - (f.Size * 0.1!), _
                        layout.Width, _
                        CSng(img.Height) * SQRTFill)
            End Select

            ' Add rendering hint (thx to Thomas)
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias

            If AddShadow Then
                ' Add "drop shadow" at half transparency and offset by 1/10 font size
                Dim shadow As New SolidBrush(Color.FromArgb(CInt(alpha / 2), OverlayColor))
                Dim sRect As New RectangleF(rect.X - (f.Size * 0.1!), rect.Y - (f.Size * 0.1!), rect.Width, rect.Height)
                g.DrawString(OverlayText, f, shadow, sRect, strFormat)
            End If

            ' Finally, draw centered text!
            g.DrawString(OverlayText, f, b, rect, strFormat)

            ' clean-up
            g.Dispose()
            b.Dispose()
            f.Dispose()
            Return bmp
        Else
            ' nothing to overlay!  regurgitate image
            Return New Bitmap(img)
        End If
    End Function
End Class
