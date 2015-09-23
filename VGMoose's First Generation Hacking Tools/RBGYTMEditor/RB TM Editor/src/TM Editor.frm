VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "comdlg32.OCX"
Begin VB.Form Form1 
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "RBYG TM Editor"
   ClientHeight    =   4080
   ClientLeft      =   45
   ClientTop       =   315
   ClientWidth     =   4425
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   4080
   ScaleWidth      =   4425
   StartUpPosition =   3  'Windows Default
   Begin MSComDlg.CommonDialog CommonDialog1 
      Left            =   3720
      Top             =   1920
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin VB.CommandButton open 
      Caption         =   "Open"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   615
      Left            =   1800
      TabIndex        =   3
      Top             =   2640
      Width           =   2535
   End
   Begin VB.CommandButton save 
      Caption         =   "Save"
      Enabled         =   0   'False
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   615
      Left            =   1800
      TabIndex        =   2
      Top             =   3360
      Width           =   2535
   End
   Begin VB.Frame Frame2 
      Caption         =   "Contains:"
      Height          =   1695
      Left            =   1920
      TabIndex        =   1
      Top             =   120
      Width           =   2415
      Begin VB.ListBox List2 
         Enabled         =   0   'False
         Height          =   1230
         ItemData        =   "TM Editor.frx":0000
         Left            =   120
         List            =   "TM Editor.frx":01F3
         TabIndex        =   7
         Top             =   240
         Width           =   2175
      End
   End
   Begin VB.Frame Frame1 
      Caption         =   "TM:"
      Height          =   3855
      Left            =   120
      TabIndex        =   0
      Top             =   120
      Width           =   1575
      Begin VB.ListBox List1 
         Enabled         =   0   'False
         Height          =   3375
         ItemData        =   "TM Editor.frx":0956
         Left            =   120
         List            =   "TM Editor.frx":09F0
         TabIndex        =   6
         Top             =   240
         Width           =   1335
      End
   End
   Begin VB.Label romname 
      Caption         =   "???"
      Height          =   255
      Left            =   2280
      TabIndex        =   5
      Top             =   2160
      Width           =   1695
   End
   Begin VB.Label lbl 
      Caption         =   "Rom:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   1800
      TabIndex        =   4
      Top             =   2160
      Width           =   495
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim FilePath As String
Dim result As String
Dim i As Integer
Dim header As String * 3

Public Function Write1Byte(FilePath As String, Start As Long, Data As String)
On Error Resume Next
Dim iFile As Long     'Thanks Darthatron
Dim bytData As Byte
    Start = Start + 1
    iFile = FreeFile
    Open FilePath For Binary As iFile
        bytData = CInt("&H" & Right("00" & Data, 2))
    Put iFile, Start, bytData
    Close iFile
End Function

Private Sub List1_Click()
Dim FileNum As Integer
Dim num1 As Byte
FileNum = FreeFile
If LenB(result) > 0 Then
FilePath = result
Open result For Binary As #FileNum
i = List1.ListIndex
If header = "RED" Or header = "BLU" Then
If List1.ListIndex = i Then
Seek #FileNum, &H13774 + i
Get #FileNum, , num1
List2.ListIndex = num1 - 1
End If
End If

If header = "GRE" Then
If List1.ListIndex = i Then
Seek #FileNum, &H12277 + i
Get #FileNum, , num1
List2.ListIndex = num1 - 1
End If
End If

If header = "YEL" Then
If List1.ListIndex = i Then
Seek #FileNum, &H1232E + i
Get #FileNum, , num1
List2.ListIndex = num1 - 1
End If
End If

Close #FileNum
End If

End Sub

Private Sub open_Click()
Dim FileNum As Integer
FileNum = FreeFile
With CommonDialog1
.Filter = "GB Roms|*.gb;*.gbc"
.DialogTitle = "Open Rom"
.ShowOpen
End With
result = CommonDialog1.FileName
If LenB(result) > 0 Then
FilePath = result
Open result For Binary As #FileNum
Get #FileNum, &H13D, header
If Not (header = "RED") And Not (header = "BLU") And Not (header = "GRE") And Not (header = "YEL") Then
MsgBox "Unsupported Rom"
Close #FileNum
End
End If
save.Enabled = True
List1.Enabled = True
List2.Enabled = True
If header = "RED" Then
romname.Caption = "Pokemon Red"
ElseIf header = "BLU" Then
romname.Caption = "Pokemon Blue"
ElseIf header = "YEL" Then
romname.Caption = "Pokemon Yellow"
Else
romname.Caption = "Pokemon Green"
End If
Close #FileNum
End If
End Sub

Private Sub save_Click()
Dim FileNum As Integer
Dim val1 As Byte
FileNum = FreeFile
If LenB(result) > 0 Then
FilePath = result
Open result For Binary As #FileNum
If header = "RED" Or header = "BLU" Then
Write1Byte result, &H13773 + i, CInt(List2.ListIndex + 1)
End If

If header = "GRE" Then
Write1Byte result, &H12276 + i, CInt(List2.ListIndex + 1)
End If

If header = "YEL" Then
Write1Byte result, &H1232D + i, CInt(List2.ListIndex + 1)
End If

Close #FileNum
End If
MsgBox "TM Changed"
End Sub
