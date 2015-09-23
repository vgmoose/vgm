VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "comdlg32.OCX"
Begin VB.Form Form1 
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Attack Editor GB"
   ClientHeight    =   6630
   ClientLeft      =   45
   ClientTop       =   315
   ClientWidth     =   4095
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   6630
   ScaleWidth      =   4095
   StartUpPosition =   3  'Windows Default
   Begin MSComDlg.CommonDialog CommonDialog1 
      Left            =   3480
      Top             =   720
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin VB.Frame Frame6 
      Caption         =   "Hit Ratio."
      Height          =   615
      Left            =   120
      TabIndex        =   16
      Top             =   4440
      Width           =   1215
      Begin VB.TextBox ratio 
         Enabled         =   0   'False
         Height          =   285
         Left            =   120
         TabIndex        =   17
         Top             =   240
         Width           =   975
      End
   End
   Begin VB.Frame Frame3 
      Caption         =   "No."
      Height          =   615
      Left            =   120
      TabIndex        =   14
      Top             =   3720
      Width           =   975
      Begin VB.TextBox numb 
         Enabled         =   0   'False
         Height          =   285
         Left            =   120
         TabIndex        =   15
         Top             =   240
         Width           =   735
      End
   End
   Begin VB.Frame Frame4 
      Caption         =   "Effect"
      Height          =   735
      Left            =   120
      TabIndex        =   12
      Top             =   5160
      Width           =   3855
      Begin VB.ComboBox effect 
         Enabled         =   0   'False
         Height          =   315
         ItemData        =   "attack editor.frx":0000
         Left            =   120
         List            =   "attack editor.frx":0109
         TabIndex        =   13
         Top             =   240
         Width           =   3615
      End
   End
   Begin VB.Frame Frame7 
      Caption         =   "Type"
      Height          =   615
      Left            =   1440
      TabIndex        =   8
      Top             =   4440
      Width           =   2535
      Begin VB.ComboBox typebox 
         Enabled         =   0   'False
         Height          =   315
         ItemData        =   "attack editor.frx":06CC
         Left            =   120
         List            =   "attack editor.frx":0721
         TabIndex        =   9
         Top             =   240
         Width           =   2295
      End
   End
   Begin VB.Frame Frame5 
      Caption         =   "PP"
      Height          =   615
      Left            =   2640
      TabIndex        =   6
      Top             =   3720
      Width           =   1335
      Begin VB.TextBox pp 
         Alignment       =   2  'Center
         Enabled         =   0   'False
         Height          =   285
         Left            =   120
         MaxLength       =   2
         TabIndex        =   7
         Top             =   240
         Width           =   1095
      End
   End
   Begin VB.ListBox atklist 
      Enabled         =   0   'False
      Height          =   2010
      ItemData        =   "attack editor.frx":07D1
      Left            =   240
      List            =   "attack editor.frx":09C4
      TabIndex        =   2
      Top             =   1440
      Width           =   3615
   End
   Begin VB.CommandButton Command2 
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
      Height          =   495
      Left            =   120
      TabIndex        =   1
      Top             =   6000
      Width           =   3855
   End
   Begin VB.CommandButton Command1 
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
      Height          =   495
      Left            =   120
      TabIndex        =   0
      Top             =   120
      Width           =   3855
   End
   Begin VB.Frame Frame1 
      Caption         =   "Attack"
      Height          =   2415
      Left            =   120
      TabIndex        =   3
      Top             =   1200
      Width           =   3855
   End
   Begin VB.Frame Frame2 
      Caption         =   "Power"
      Height          =   615
      Left            =   1200
      TabIndex        =   4
      Top             =   3720
      Width           =   1335
      Begin VB.TextBox power 
         Alignment       =   2  'Center
         Enabled         =   0   'False
         Height          =   285
         Left            =   120
         MaxLength       =   3
         TabIndex        =   5
         Top             =   240
         Width           =   1095
      End
   End
   Begin VB.Label romname 
      Height          =   255
      Left            =   1440
      TabIndex        =   11
      Top             =   840
      Width           =   2295
   End
   Begin VB.Label Label1 
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
      Left            =   840
      TabIndex        =   10
      Top             =   840
      Width           =   495
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim filepath As String
Dim result As String
Dim i As Integer
Dim header As String * 3
Dim offset As String

Private Sub atklist_Click()
Dim FileNum As Integer
Dim num1 As Byte
Dim val As Integer
Dim offset As String
Dim hitratio As Single
FileNum = FreeFile
If LenB(result) > 0 Then
filepath = result
Open result For Binary As #FileNum
i = atklist.ListIndex

If (header = "RED") Or (header = "BLU") Or (header = "YEL") Then
offset = &H38001
ElseIf (header = "GRE") Then
offset = &H39659
End If

If atklist.ListIndex = i Then
Seek #FileNum, offset + (i * 6)
Get #FileNum, , num1
numb.Text = num1
Seek #FileNum, offset + (i * 6) + 1
Get #FileNum, , num1
effect.ListIndex = CInt(num1)
Seek #FileNum, offset + (i * 6) + 2
Get #FileNum, , num1
power.Text = num1
Seek #FileNum, offset + (i * 6) + 3
Get #FileNum, , num1
typebox.ListIndex = num1
Seek #FileNum, offset + (i * 6) + 4
Get #FileNum, , num1
hitratio = num1 / 255
ratio.Text = hitratio
Seek #FileNum, offset + (i * 6) + 5
Get #FileNum, , num1
pp.Text = num1
End If
Close #FileNum
End If

End Sub

Private Sub Command1_Click()
Dim FileNum As Integer
FileNum = FreeFile
With CommonDialog1
.Filter = "Gameboy Roms|*.gb;*.gbc"
.DialogTitle = "Open Rom"
.ShowOpen
End With
result = CommonDialog1.FileName
If LenB(result) > 0 Then
filepath = result
Open result For Binary As #FileNum
Get #FileNum, &H13D, header
If Not (header = "RED") And Not (header = "BLU") And Not (header = "GRE") And Not (header = "YEL") Then
MsgBox "Unsupported Rom"
Close #FileNum
End
End If
atklist.Enabled = True
power.Enabled = True
typebox.Enabled = True
pp.Enabled = True
effect.Enabled = True
Command2.Enabled = True
ratio.Enabled = True
If header = "RED" Then
romname.Caption = "Pokemon Red"
ElseIf header = "BLU" Then
romname.Caption = "Pokemon Blue"
ElseIf header = "GRE" Then
romname.Caption = "Pokemon Green"
ElseIf header = "YEL" Then
romname.Caption = "Pokemon Yellow"
End If
Close #FileNum
End If
End Sub

Private Sub Command2_Click()
Dim FileNum As Integer
Dim val1 As Byte
FileNum = FreeFile
filepath = result
If atklist.ListIndex = (0 - 1) Then
MsgBox "Please Click an Attack to Begin"
ElseIf power.Text > 255 Or ratio.Text > 1 Then
MsgBox "Insufficient Value in One box"
Else
Open result For Binary As #FileNum
If (header = "RED") Or (header = "BLU") Or (header = "YEL") Then
offset = &H38001
ElseIf (header = "GRE") Then
offset = &H39659
End If

Seek #FileNum, offset + (i * 6) + 1
val1 = effect.ListIndex
Put #FileNum, , val1

Seek #FileNum, offset + (i * 6) + 2
val1 = power.Text
Put #FileNum, , val1

Seek #FileNum, offset + (i * 6) + 3
val1 = typebox.ListIndex
Put #FileNum, , val1

Seek #FileNum, offset + (i * 6) + 4
val1 = hitratio.Text
Put #FileNum, , val1

Seek #FileNum, offset + (i * 6) + 5
val1 = pp.Text
Put #FileNum, , val1

Close #FileNum
MsgBox "Attack Edited"
End If
End Sub

