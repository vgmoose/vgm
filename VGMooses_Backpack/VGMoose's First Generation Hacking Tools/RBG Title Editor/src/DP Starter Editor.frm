VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "comdlg32.OCX"
Begin VB.Form Form1 
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Pokemon Starter Editor"
   ClientHeight    =   2640
   ClientLeft      =   45
   ClientTop       =   315
   ClientWidth     =   4830
   BeginProperty Font 
      Name            =   "MS Sans Serif"
      Size            =   8.25
      Charset         =   0
      Weight          =   700
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   2640
   ScaleWidth      =   4830
   StartUpPosition =   2  'CenterScreen
   Begin MSComDlg.CommonDialog openfd 
      Left            =   1800
      Top             =   2040
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin VB.ComboBox start3 
      Enabled         =   0   'False
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   315
      ItemData        =   "DP Starter Editor.frx":0000
      Left            =   3240
      List            =   "DP Starter Editor.frx":0241
      TabIndex        =   4
      Top             =   1200
      Width           =   1455
   End
   Begin VB.ComboBox start2 
      Enabled         =   0   'False
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   315
      ItemData        =   "DP Starter Editor.frx":0922
      Left            =   1680
      List            =   "DP Starter Editor.frx":0B63
      TabIndex        =   3
      Top             =   1200
      Width           =   1455
   End
   Begin VB.ComboBox start1 
      Enabled         =   0   'False
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   315
      ItemData        =   "DP Starter Editor.frx":1244
      Left            =   120
      List            =   "DP Starter Editor.frx":1485
      TabIndex        =   2
      Top             =   1200
      Width           =   1455
   End
   Begin VB.CommandButton saverom 
      Caption         =   "Save"
      Enabled         =   0   'False
      Height          =   495
      Left            =   3360
      TabIndex        =   1
      Top             =   2040
      Width           =   1335
   End
   Begin VB.CommandButton openrom 
      Caption         =   "Open"
      Height          =   495
      Left            =   120
      TabIndex        =   0
      Top             =   2040
      Width           =   1335
   End
   Begin VB.Label headr 
      Height          =   255
      Left            =   1920
      TabIndex        =   10
      Top             =   1680
      Width           =   2415
   End
   Begin VB.Label lbl6 
      Caption         =   "Rom Name:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   840
      TabIndex        =   9
      Top             =   1680
      Width           =   975
   End
   Begin VB.Label Label1 
      Alignment       =   2  'Center
      Caption         =   "RBG Starter Editor"
      BeginProperty Font 
         Name            =   "OLIVEOIL"
         Size            =   18
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   0
      TabIndex        =   8
      Top             =   120
      Width           =   4815
   End
   Begin VB.Label Label3 
      Alignment       =   2  'Center
      Caption         =   "Starter Three"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   3240
      TabIndex        =   7
      Top             =   840
      Width           =   1455
   End
   Begin VB.Label lbl2 
      Alignment       =   2  'Center
      Caption         =   "Starter Two"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   1680
      TabIndex        =   6
      Top             =   840
      Width           =   1455
   End
   Begin VB.Label lbl1 
      Alignment       =   2  'Center
      Caption         =   "Starter One"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   120
      TabIndex        =   5
      Top             =   840
      Width           =   1455
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim TheFile As String
Dim starter1 As Byte
Dim header As String * 3

Private Sub openrom_Click()
Dim result As String
Dim point As Byte
Dim FileNum As Integer
Dim val As Integer
FileNum = FreeFile
With openfd
.Filter = "GB Roms|*.gb"
.DialogTitle = "Open Rom"
.ShowOpen
End With
result = openfd.FileName
If LenB(result) > 0 Then
TheFile = result
Open result For Binary As #FileNum
Get #FileNum, &H13D, header
If Not (header = "RED") And Not (header = "BLU") And Not (header = "GRE") Then
MsgBox "Unsupported Rom"
Close #FileNum
End
End If
start1.Enabled = True
start2.Enabled = True
start3.Enabled = True
saverom.Enabled = True

If header = "RED" Then
headr.Caption = "Pokemon Red"
ElseIf header = "BLU" Then
headr.Caption = "Pokemon Blue"
Else
headr.Caption = "Pokemon Green"
End If

If header = "RED" Or header = "BLU" Then
Seek #FileNum, &H3A1E6
Get #FileNum, , starter1
start1.ListIndex = CInt(starter1)
Seek #FileNum, &H3A1E9
Get #FileNum, , starter1
start2.ListIndex = CInt(starter1)
Seek #FileNum, &H3A1EC
Get #FileNum, , starter1
start3.ListIndex = CInt(starter1)
End If

If header = "GRE" Then
Seek #FileNum, &H3A557
Get #FileNum, , starter1
start1.ListIndex = CInt(starter1)
Seek #FileNum, &H3A55A
Get #FileNum, , starter1
start2.ListIndex = CInt(starter1)
Seek #FileNum, &H3A55D
Get #FileNum, , starter1
start3.ListIndex = CInt(starter1)
End If
Close #FileNum
End If

End Sub

Private Sub saverom_Click()
Dim FileNum As Integer
Dim val1 As Byte
FileNum = FreeFile
Open TheFile For Binary As #FileNum

If header = "RED" Or header = "BLUE" Then
Seek #FileNum, &H3A1E6
Put #FileNum, , start1.ListIndex
Seek #FileNum, &H3A1E9
Put #FileNum, , start2.ListIndex
Seek #FileNum, &H3A1EC
Put #FileNum, , start3.ListIndex
End If

If header = "GRE" Then
Seek #FileNum, &H3A557
Put #FileNum, , start1.ListIndex
Seek #FileNum, &H3A55A
Put #FileNum, , start2.ListIndex
Seek #FileNum, &H3A55D
Put #FileNum, , start3.ListIndex
End If

MsgBox "Starter's Changed"
End Sub
