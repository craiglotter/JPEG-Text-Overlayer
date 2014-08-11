Imports System.Drawing.Imaging
Imports System.IO

Public Class Sample
    Inherits System.Windows.Forms.Form

#Region "Private Members"
    Private m_OrigImage As Image
    Private m_Font As Font
    Private m_Color As Color
    Private m_switch As Boolean
#End Region

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        ' Store the original image:
        m_OrigImage = pbOverlay.Image
        m_Font = New Font(Me.Font, FontStyle.Bold)
        m_Color = Color.White
        cboPosition.Items.AddRange(New String() {"TopLeft", "TopCenter", "TopRight", "MiddleLeft", "MiddleCenter", "MiddleRight", "BottomLeft", "BottomCenter", "BottomRight"})
        cboPosition.SelectedIndex = 4 ' MiddleCenter
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents pbOverlay As System.Windows.Forms.PictureBox
    Friend WithEvents tbText As System.Windows.Forms.TextBox
    Friend WithEvents btnGo As System.Windows.Forms.Button
    Friend WithEvents btnFont As System.Windows.Forms.Button
    Friend WithEvents cbAlpha As System.Windows.Forms.CheckBox
    Friend WithEvents cbShadow As System.Windows.Forms.CheckBox
    Friend WithEvents FillSlider As System.Windows.Forms.TrackBar
    Friend WithEvents lblFill As System.Windows.Forms.Label
    Friend WithEvents cboPosition As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sample))
        Me.pbOverlay = New System.Windows.Forms.PictureBox
        Me.tbText = New System.Windows.Forms.TextBox
        Me.btnGo = New System.Windows.Forms.Button
        Me.btnFont = New System.Windows.Forms.Button
        Me.cbAlpha = New System.Windows.Forms.CheckBox
        Me.cbShadow = New System.Windows.Forms.CheckBox
        Me.FillSlider = New System.Windows.Forms.TrackBar
        Me.lblFill = New System.Windows.Forms.Label
        Me.cboPosition = New System.Windows.Forms.ComboBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        CType(Me.pbOverlay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FillSlider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbOverlay
        '
        Me.pbOverlay.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbOverlay.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.pbOverlay.Image = CType(resources.GetObject("pbOverlay.Image"), System.Drawing.Image)
        Me.pbOverlay.Location = New System.Drawing.Point(8, 8)
        Me.pbOverlay.Name = "pbOverlay"
        Me.pbOverlay.Size = New System.Drawing.Size(464, 144)
        Me.pbOverlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbOverlay.TabIndex = 0
        Me.pbOverlay.TabStop = False
        '
        'tbText
        '
        Me.tbText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbText.Location = New System.Drawing.Point(8, 160)
        Me.tbText.Name = "tbText"
        Me.tbText.Size = New System.Drawing.Size(232, 20)
        Me.tbText.TabIndex = 0
        Me.tbText.Text = "CodeUnit"
        '
        'btnGo
        '
        Me.btnGo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGo.BackColor = System.Drawing.Color.LawnGreen
        Me.btnGo.Location = New System.Drawing.Point(384, 192)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(88, 24)
        Me.btnGo.TabIndex = 4
        Me.btnGo.Text = "Overlay"
        Me.btnGo.UseVisualStyleBackColor = False
        '
        'btnFont
        '
        Me.btnFont.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFont.Location = New System.Drawing.Point(248, 160)
        Me.btnFont.Name = "btnFont"
        Me.btnFont.Size = New System.Drawing.Size(56, 24)
        Me.btnFont.TabIndex = 1
        Me.btnFont.Text = "Font..."
        '
        'cbAlpha
        '
        Me.cbAlpha.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbAlpha.Location = New System.Drawing.Point(312, 160)
        Me.cbAlpha.Name = "cbAlpha"
        Me.cbAlpha.Size = New System.Drawing.Size(64, 16)
        Me.cbAlpha.TabIndex = 2
        Me.cbAlpha.Text = "Alpha"
        '
        'cbShadow
        '
        Me.cbShadow.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbShadow.Location = New System.Drawing.Point(312, 176)
        Me.cbShadow.Name = "cbShadow"
        Me.cbShadow.Size = New System.Drawing.Size(72, 16)
        Me.cbShadow.TabIndex = 3
        Me.cbShadow.Text = "Shadow"
        '
        'FillSlider
        '
        Me.FillSlider.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FillSlider.Location = New System.Drawing.Point(48, 184)
        Me.FillSlider.Maximum = 100
        Me.FillSlider.Name = "FillSlider"
        Me.FillSlider.Size = New System.Drawing.Size(192, 45)
        Me.FillSlider.TabIndex = 5
        Me.FillSlider.TickFrequency = 10
        Me.FillSlider.Value = 80
        '
        'lblFill
        '
        Me.lblFill.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblFill.Location = New System.Drawing.Point(8, 184)
        Me.lblFill.Name = "lblFill"
        Me.lblFill.Size = New System.Drawing.Size(56, 32)
        Me.lblFill.TabIndex = 6
        Me.lblFill.Text = "Size: (80%)"
        '
        'cboPosition
        '
        Me.cboPosition.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPosition.Location = New System.Drawing.Point(248, 192)
        Me.cboPosition.Name = "cboPosition"
        Me.cboPosition.Size = New System.Drawing.Size(128, 21)
        Me.cboPosition.TabIndex = 7
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(432, 160)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(40, 24)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Save"
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(384, 160)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(40, 24)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "Load"
        '
        'Sample
        '
        Me.AcceptButton = Me.btnGo
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(480, 221)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cboPosition)
        Me.Controls.Add(Me.FillSlider)
        Me.Controls.Add(Me.cbShadow)
        Me.Controls.Add(Me.cbAlpha)
        Me.Controls.Add(Me.btnFont)
        Me.Controls.Add(Me.btnGo)
        Me.Controls.Add(Me.tbText)
        Me.Controls.Add(Me.pbOverlay)
        Me.Controls.Add(Me.lblFill)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(488, 255)
        Me.Name = "Sample"
        Me.Text = "JPEG Text Overlayer 20061102.1"
        CType(Me.pbOverlay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FillSlider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Event Handlers"

    Private Sub OrderOverlay()
        ' resize original to match current display dimensions
        Dim bmp As New Bitmap(m_OrigImage, pbOverlay.Width, pbOverlay.Height)

        ' convert string to enum value.  This is too much to frelling type!
        Dim pos As ContentAlignment = CType(System.Enum.Parse(GetType(ContentAlignment), cboPosition.SelectedItem.ToString), ContentAlignment)


        pbOverlay.Image = OverlayVB.Overlay.VBOverlay(bmp, tbText.Text, m_Font, m_Color, cbAlpha.Checked, cbShadow.Checked, pos, CSng(FillSlider.Value) / 100.0!)


    End Sub

    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click
        OrderOverlay()
    End Sub

    Private Sub btnFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFont.Click
        ' open font dialog:
        Dim dlg As New FontDialog()
        dlg.Color = m_Color
        dlg.Font = m_Font
        dlg.ShowColor = True
        dlg.ShowEffects = True
        dlg.AllowSimulations = True
        dlg.ShowApply = False
        If dlg.ShowDialog(Me) = DialogResult.OK Then
            m_Color = dlg.Color
            m_Font = dlg.Font
            OrderOverlay()
        End If
        dlg.Dispose()
    End Sub

    Private Sub FillSlider_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FillSlider.ValueChanged
        lblFill.Text = String.Format("Size:   ({0}%)", FillSlider.Value)
    End Sub
#End Region

#Region "Save To File"
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim bmp As Bitmap = New Bitmap(pbOverlay.Image)
        Dim dlg As New SaveFileDialog()
        dlg.AddExtension = True
        dlg.CheckPathExists = True
        dlg.CreatePrompt = False
        dlg.OverwritePrompt = True
        dlg.RestoreDirectory = False
        dlg.ValidateNames = True
        dlg.FileName = "Overlay"
        dlg.Filter = "Jpeg Image (*.jpg)|*.jpg|PNG (*.png)|*.png|Bitmap (*.bmp)|*.bmp"
        dlg.FilterIndex = 0
        If dlg.ShowDialog(Me) = DialogResult.OK Then
            Select Case dlg.FilterIndex ' NOT zero-based!
                Case 1 '"jpg"
                    ' get compression
                    Dim iQual As Integer = -1
                    Dim sQual As String = "90"
                    While (iQual < 0 Or iQual > 100)
                        sQual = InputBox("Enter jpg quality (0-100)", "JPG Quality", sQual)
                        Try
                            iQual = Integer.Parse(sQual)
                        Catch
                            iQual = -1
                        End Try
                    End While

                    Dim eps As EncoderParameters = New EncoderParameters(1)
                    eps.Param(0) = New EncoderParameter(Encoder.Quality, iQual)
                    Dim ici As ImageCodecInfo = GetEncoderInfo("image/jpeg")
                    bmp.Save(dlg.FileName, ici, eps)
                Case 2 '"png"
                    Dim ici As ImageCodecInfo = GetEncoderInfo("image/png")
                    bmp.Save(dlg.FileName, ImageFormat.Png)
                Case 3 '"bmp"
                    bmp.Save(dlg.FileName, ImageFormat.Bmp)
                Case Else
                    MsgBox("Unrecognized selection!", MsgBoxStyle.Exclamation)
            End Select
            dlg.Dispose()
        End If
    End Sub

    Private Function GetEncoderInfo(ByVal mimeType As String) As ImageCodecInfo
        Dim j As Integer
        Dim encoders As ImageCodecInfo()
        encoders = ImageCodecInfo.GetImageEncoders()
        For j = 0 To encoders.Length
            If encoders(j).MimeType = mimeType Then
                Return encoders(j)
            End If
        Next j
        Return Nothing
    End Function
#End Region

#Region "Load File"
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim dlg As New OpenFileDialog()
        dlg.AddExtension = True
        dlg.CheckFileExists = True
        dlg.CheckPathExists = True
        dlg.DefaultExt = "esp"
        dlg.Multiselect = False
        dlg.Filter = "Images (*.bmp, *.gif, *.jpg, *.png)|*.bmp;*.gif;*.jpg;*.jpeg;*.png"
        dlg.FilterIndex = 0
        If dlg.ShowDialog(Me) = DialogResult.OK Then
            Try
                Dim img As Image = Image.FromFile(dlg.FileName)
                If img.Width > 0 AndAlso img.Height > 0 Then
                    ' assign to the "original" image
                    m_OrigImage = img
                    Me.pbOverlay.Image = img
                    ' this just resizes window to match image size
                    Dim dx As Integer = img.Width - Me.pbOverlay.Width
                    Dim dy As Integer = img.Height - Me.pbOverlay.Height
                    Me.Width += dx
                    Me.Height += dy
                End If
            Catch ex As Exception
                MsgBox("Unable to read image: " & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Load Image")
            End Try
        End If
        dlg.Dispose()
    End Sub
#End Region


    Private Sub Sample_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OrderOverlay()
    End Sub

    Private Sub FillSlider_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FillSlider.Scroll
        OrderOverlay()
    End Sub

    Private Sub cbAlpha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbAlpha.CheckedChanged
        OrderOverlay()
    End Sub

    Private Sub cbShadow_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbShadow.CheckedChanged
        OrderOverlay()
    End Sub

    Private Sub cboPosition_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPosition.SelectedIndexChanged
        OrderOverlay()
    End Sub

    Private Sub tbText_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbText.TextChanged
        If Not tbText.Text = "CodeUnit" Then
            OrderOverlay()
        End If
    End Sub
End Class
