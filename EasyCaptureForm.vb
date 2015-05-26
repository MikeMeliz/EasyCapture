'---Εισαγωγή Βιβλιοθηκών Windows---
Imports System.Runtime.InteropServices

Public Class EasyCaptureForm
    '---Δήλωση σταθερών για εντολές Cameras---
    Const WM_CAP_START = &H400S
    Const WS_CHILD = &H40000000
    Const WS_VISIBLE = &H10000000

    Const WM_CAP_DRIVER_CONNECT = WM_CAP_START + 10
    Const WM_CAP_DRIVER_DISCONNECT = WM_CAP_START + 11
    Const WM_CAP_EDIT_COPY = WM_CAP_START + 30
    Const WM_CAP_SEQUENCE = WM_CAP_START + 62
    Const WM_CAP_FILE_SAVEAS = WM_CAP_START + 23

    Const WM_CAP_SET_SCALE = WM_CAP_START + 53
    Const WM_CAP_SET_PREVIEWRATE = WM_CAP_START + 52
    Const WM_CAP_SET_PREVIEW = WM_CAP_START + 50

    Const SWP_NOMOVE = &H2S
    Const SWP_NOSIZE = 1
    Const SWP_NOZORDER = &H4S
    Const HWND_BOTTOM = 1

    '---Δήλωση Μεταβλητής για αλλαγή ονόματος αποθηκευμένης εικόνας---
    Dim x As Integer


    '--The capGetDriverDescription function retrieves the version description of the capture driver--
    Declare Function capGetDriverDescriptionA Lib "avicap32.dll" _
       (ByVal wDriverIndex As Short, _
        ByVal lpszName As String, ByVal cbName As Integer, ByVal lpszVer As String, _
        ByVal cbVer As Integer) As Boolean

    '--The capCreateCaptureWindow function creates a capture window--
    Declare Function capCreateCaptureWindowA Lib "avicap32.dll" _
       (ByVal lpszWindowName As String, ByVal dwStyle As Integer, _
        ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, _
        ByVal nHeight As Short, ByVal hWnd As Integer, _
        ByVal nID As Integer) As Integer

    '--This function sends the specified message to a window or windows--
    Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
       (ByVal hwnd As Integer, ByVal Msg As Integer, ByVal wParam As Integer, _
       <MarshalAs(UnmanagedType.AsAny)> ByVal lParam As Object) As Integer

    '--Sets the position of the window relative to the screen buffer--
    Declare Function SetWindowPos Lib "user32" Alias "SetWindowPos" _
       (ByVal hwnd As Integer, _
        ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer, _
        ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer

    '--This function destroys the specified window--
    Declare Function DestroyWindow Lib "user32" (ByVal hndw As Integer) As Boolean

    Dim VideoSource As Integer
    Dim hWnd As Integer

    '--disconnect from video source---
    Private Sub StopPreviewWindow()
        SendMessage(hWnd, WM_CAP_DRIVER_DISCONNECT, VideoSource, 0)
        DestroyWindow(hWnd)
    End Sub

    '---list all the various video sources---
    Private Sub ListVideoSources()
        Dim DriverName As String = Space(80)
        Dim DriverVersion As String = Space(80)
        For i As Integer = 0 To 9
            If capGetDriverDescriptionA(i, DriverName, 80, DriverVersion, 80) Then
                lstVideoSources.Items.Add(DriverName.Trim)
            End If
        Next
    End Sub

    '---save the image---
    Private Sub CaptureImage()
        Dim data As IDataObject
        Dim bmap As Image

        '---copy the image to the clipboard---
        SendMessage(hWnd, WM_CAP_EDIT_COPY, 0, 0)

        '---retrieve the image from clipboard and convert it 
        ' to the bitmap format
        data = Clipboard.GetDataObject()
        If data.GetDataPresent(GetType(System.Drawing.Bitmap)) Then
            bmap = _
               CType(data.GetData(GetType(System.Drawing.Bitmap)),  _
               Image)
            PhotoPictureBox.Image = bmap

        End If
    End Sub


    '---preview the selected video source---
    Private Sub PreviewVideo(ByVal pbCtrl As PictureBox)
        hWnd = capCreateCaptureWindowA(VideoSource, WS_VISIBLE Or WS_CHILD, 0, 0, 0, _
            0, pbCtrl.Handle.ToInt32, 0)
        If SendMessage(hWnd, WM_CAP_DRIVER_CONNECT, VideoSource, 0) Then
            '---set the preview scale---
            SendMessage(hWnd, WM_CAP_SET_SCALE, True, 0)
            '---set the preview rate (ms)---
            SendMessage(hWnd, WM_CAP_SET_PREVIEWRATE, 30, 0)
            '---start previewing the image---
            SendMessage(hWnd, WM_CAP_SET_PREVIEW, True, 0)
            '---resize window to fit in PictureBox control---
            SetWindowPos(hWnd, HWND_BOTTOM, 0, 0, _
               pbCtrl.Width, pbCtrl.Height, _
               SWP_NOMOVE Or SWP_NOZORDER)
        Else
            '--error connecting to video source---
            DestroyWindow(hWnd)
        End If
    End Sub


    Private Sub lstVideoSources_SelectedIndexChanged( _
       ByVal sender As System.Object, ByVal e As System.EventArgs) _
       Handles lstVideoSources.SelectedIndexChanged

        '---stop video in case it is on---
        StopPreviewWindow()
        '---check which video source is selected---
        VideoSource = lstVideoSources.SelectedIndex
        '---preview the selected video source
        PreviewVideo(PictureBox1)
    End Sub

    Private Sub btnStopCamera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStopCamera.Click
        StopPreviewWindow()
    End Sub

    Private Sub btnCapturePhoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapturePhoto.Click
        Dim bt As Image
        x = x + 1
        CaptureImage()
        SendMessage(hWnd, WM_CAP_EDIT_COPY, 1, 0)
        bt = Clipboard.GetImage
        bt.Save(Application.StartupPath & "\Picture" & x & ".jpg", Imaging.ImageFormat.Jpeg)
    End Sub

    Private Sub EasyCaptureForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '---list all the video sources---
        ListVideoSources()
    End Sub
End Class
