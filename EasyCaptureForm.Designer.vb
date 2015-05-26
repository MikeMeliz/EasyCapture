<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EasyCaptureForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EasyCaptureForm))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lstVideoSources = New System.Windows.Forms.ListBox()
        Me.PhotoPictureBox = New System.Windows.Forms.PictureBox()
        Me.btnCapturePhoto = New System.Windows.Forms.Button()
        Me.btnStopCamera = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PhotoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Location = New System.Drawing.Point(2, 45)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(593, 420)
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(280, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Video Sources:"
        '
        'lstVideoSources
        '
        Me.lstVideoSources.FormattingEnabled = True
        Me.lstVideoSources.Location = New System.Drawing.Point(365, 9)
        Me.lstVideoSources.Name = "lstVideoSources"
        Me.lstVideoSources.Size = New System.Drawing.Size(230, 30)
        Me.lstVideoSources.TabIndex = 5
        '
        'PhotoPictureBox
        '
        Me.PhotoPictureBox.Location = New System.Drawing.Point(505, 386)
        Me.PhotoPictureBox.Name = "PhotoPictureBox"
        Me.PhotoPictureBox.Size = New System.Drawing.Size(85, 68)
        Me.PhotoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PhotoPictureBox.TabIndex = 18
        Me.PhotoPictureBox.TabStop = False
        '
        'btnCapturePhoto
        '
        Me.btnCapturePhoto.Location = New System.Drawing.Point(9, 2)
        Me.btnCapturePhoto.Name = "btnCapturePhoto"
        Me.btnCapturePhoto.Size = New System.Drawing.Size(161, 37)
        Me.btnCapturePhoto.TabIndex = 19
        Me.btnCapturePhoto.Text = "Capture Photo"
        Me.btnCapturePhoto.UseVisualStyleBackColor = True
        '
        'btnStopCamera
        '
        Me.btnStopCamera.Location = New System.Drawing.Point(176, 2)
        Me.btnStopCamera.Name = "btnStopCamera"
        Me.btnStopCamera.Size = New System.Drawing.Size(98, 37)
        Me.btnStopCamera.TabIndex = 20
        Me.btnStopCamera.Text = "Close Camera"
        Me.btnStopCamera.UseVisualStyleBackColor = True
        '
        'EasyCaptureForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 468)
        Me.Controls.Add(Me.btnStopCamera)
        Me.Controls.Add(Me.btnCapturePhoto)
        Me.Controls.Add(Me.PhotoPictureBox)
        Me.Controls.Add(Me.lstVideoSources)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "EasyCaptureForm"
        Me.Text = "EasyCapture!"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PhotoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lstVideoSources As System.Windows.Forms.ListBox
    Friend WithEvents PhotoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents btnCapturePhoto As System.Windows.Forms.Button
    Friend WithEvents btnStopCamera As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
